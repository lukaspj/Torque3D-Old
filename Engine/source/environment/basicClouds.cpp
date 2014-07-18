//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

#include "platform/platform.h"
#include "platform/profiler.h"
#include "console/consoleTypes.h"
#include "basicClouds.h"

#include "gfx/gfxTransformSaver.h"
#include "gfx/gfxTextureManager.h"
#include "core/stream/fileStream.h"
#include "core/stream/bitStream.h"
#include "scene/sceneRenderState.h"
#include "renderInstance/renderPassManager.h"
#include "materials/shaderData.h"
#include "math/mathIO.h"
#include "taml/tamlCustom.h"


ConsoleDocClass( BasicClouds,
   "@brief Renders up to three layers of scrolling cloud-cover textures overhead.\n\n"   
   
   "%BasicClouds always renders overhead, following the camera. It is intended "
   "as part of the background of your level, rendering in front of Sky/Sun "
   "type objects and behind everything else.\n\n"

   "The parameters controlling the rendering of each texture are refered to "
   "and grouped as 'layers'. They are rendered in sequential order, so, layer 1 "
   "obscures layer 0, and so on.\n\n"

   "BasicClouds is not affected by scene lighting and is therefore not appropriate "
   "for scenes in which lighting radically changes, such as day/night.\n\n"

   "@ingroup Atmosphere"
);


U32 BasicClouds::smVertStride = 50;
U32 BasicClouds::smStrideMinusOne = 49;
U32 BasicClouds::smVertCount = 50 * 50;
U32 BasicClouds::smTriangleCount = smStrideMinusOne * smStrideMinusOne * 2;

BasicClouds::BasicClouds()
{
   mTypeMask |= EnvironmentObjectType | StaticObjectType;
   mNetFlags.set(Ghostable | ScopeAlways);

   mLayerEnabled[0] = true;
   mLayerEnabled[1] = true;
   mLayerEnabled[2] = true;

   // Default textures are assigned by the ObjectBuilderGui.
   //mTexName[0] = "art/skies/clouds/cloud1";
   //mTexName[1] = "art/skies/clouds/cloud2";
   //mTexName[2] = "art/skies/clouds/cloud3";

   mHeight[0] = 4.0f;
   mHeight[1] = 3.0f;
   mHeight[2] = 2.0f;
   
   mTexSpeed[0] = 0.0005f;
   mTexSpeed[1] = 0.001f;
   mTexSpeed[2] = 0.0003f;
   
   mTexScale[0] = 1.0;
   mTexScale[1] = 1.0;
   mTexScale[2] = 1.0;

   mTexDirection[0].set( 1.0f, 0.0f );
   mTexDirection[1].set( 1.0f, 0.0f );
   mTexDirection[2].set( 1.0f, 0.0f );
   
   mTexOffset[0].set( 0.5f, 0.5f );
   mTexOffset[1].set( 0.5f, 0.5f );
   mTexOffset[2].set( 0.5f, 0.5f );
}

IMPLEMENT_CO_NETOBJECT_V1( BasicClouds );

// ConsoleObject...


bool BasicClouds::onAdd()
{
   if ( !Parent::onAdd() )
      return false;

   setGlobalBounds();
   resetWorldBox();

   addToScene();

   if ( isClientObject() )
   {
      _initTexture();
      _initBuffers();

      // Find ShaderData
      ShaderData *shaderData;
      mShader = Sim::findObject( "BasicCloudsShader", shaderData ) ? shaderData->getShader() : NULL;
      if ( !mShader )
      {
         Con::errorf( "BasicClouds::onAdd - could not find BasicCloudsShader" );
         return false;
      }

      // Create ShaderConstBuffer and Handles
      mShaderConsts = mShader->allocConstBuffer();
      mModelViewProjSC = mShader->getShaderConstHandle( "$modelView" );
      mTimeSC = mShader->getShaderConstHandle( "$accumTime" );
      mTexScaleSC = mShader->getShaderConstHandle( "$texScale" );
      mTexDirectionSC = mShader->getShaderConstHandle( "$texDirection" );
      mTexOffsetSC = mShader->getShaderConstHandle( "$texOffset" );

      // Create StateBlocks
      GFXStateBlockDesc desc;
      desc.setCullMode( GFXCullNone );
      desc.setBlend( true );
      desc.setZReadWrite( false, false );
      desc.samplersDefined = true;
      desc.samplers[0].addressModeU = GFXAddressWrap;
      desc.samplers[0].addressModeV = GFXAddressWrap;
      desc.samplers[0].addressModeW = GFXAddressWrap;
      desc.samplers[0].magFilter = GFXTextureFilterLinear;
      desc.samplers[0].minFilter = GFXTextureFilterLinear;
      desc.samplers[0].mipFilter = GFXTextureFilterLinear;
      desc.samplers[0].textureColorOp = GFXTOPModulate;
      
      mStateblock = GFX->createStateBlock( desc );      
   }

   return true;
}

void BasicClouds::onRemove()
{
   removeFromScene();

   Parent::onRemove();
}

struct BasicCloudsHeightWriteFn : public AbstractClassRep::WriteDataNotify
{
   bool fn(void* obj, StringTableEntry pFieldName, const char* idx = NULL) const
   {
      BasicClouds* cloud = static_cast<BasicClouds*>(obj);
      F32 defVal;
      U32 i = dAtoi(idx);
      switch (i)
      {
      case 0:
         defVal = 4.0f;
         break;
      case 1:
         defVal = 3.0f;
         break;
      case 2:
         defVal = 2.0f;
         break;
      default:
         defVal = 0.0f;
      }
      if(dAtof(cloud->getDataField(pFieldName,idx)) == defVal)
         return false;
      return true;
   }
};

struct BasicCloudsTexSpeedWriteFn : public AbstractClassRep::WriteDataNotify
{
   bool fn(void* obj, StringTableEntry pFieldName, const char* idx = NULL) const
   {
      BasicClouds* cloud = static_cast<BasicClouds*>(obj);
      F32 defVal;
      U32 i = dAtoi(idx);
      switch (i)
      {
      case 0:
         defVal = 0.0005f;
         break;
      case 1:
         defVal = 0.001f;
         break;
      case 2:
         defVal = 0.0003f;
         break;
      default:
         defVal = 0.0f;
      }
      if(dAtof(cloud->getDataField(pFieldName,idx)) == defVal)
         return false;
      return true;
   }
};

void BasicClouds::initPersistFields()
{
   addGroup( "BasicClouds" );

      addArray( "Layers", TEX_COUNT );

         addField( "layerEnabled", TypeBool, Offset( mLayerEnabled, BasicClouds ), new DefaultBoolWriteFn(true), TEX_COUNT,
            "Enable or disable rendering of this layer." );

         addField( "texture", TypeImageFilename, Offset( mTexName, BasicClouds ), TEX_COUNT,
            "Texture for this layer." );

         addField( "texScale", TypeF32, Offset( mTexScale, BasicClouds ), new DefaultFloatWriteFn(1.0f), TEX_COUNT,
            "Texture repeat for this layer." );

         addField( "texDirection", TypePoint2F, Offset( mTexDirection, BasicClouds ), new DefaultValueWriteFn("1 0"), TEX_COUNT,
            "Texture scroll direction for this layer, relative to the world axis." );

         addField( "texSpeed", TypeF32, Offset( mTexSpeed, BasicClouds ), new BasicCloudsTexSpeedWriteFn(), TEX_COUNT,
            "Texture scroll speed for this layer." );   

         addField( "texOffset", TypePoint2F, Offset( mTexOffset, BasicClouds ), new DefaultValueWriteFn("0.5 0.5"), TEX_COUNT,
            "UV offset for this layer." );

         addField( "height", TypeF32, Offset( mHeight, BasicClouds ), new BasicCloudsHeightWriteFn(), TEX_COUNT,
            "Abstract number which controls the curvature and height of the dome mesh" );

      endArray( "Layers" );      

   endGroup( "BasicClouds" );

   Parent::initPersistFields();
}

void BasicClouds::inspectPostApply()
{
   Parent::inspectPostApply();
   setMaskBits( BasicCloudsMask );
}


// NetObject...


U32 BasicClouds::packUpdate( NetConnection *conn, U32 mask, BitStream *stream )
{
   U32 retMask = Parent::packUpdate( conn, mask, stream );

   for ( U32 i = 0; i < TEX_COUNT; i++ )
   {
      stream->writeFlag( mLayerEnabled[i] );

      stream->write( mTexName[i] );

      stream->write( mTexScale[i] );
      mathWrite( *stream, mTexDirection[i] );
      stream->write( mTexSpeed[i] );   
      mathWrite( *stream, mTexOffset[i] );
      
      stream->write( mHeight[i] );
   }
   
   return retMask;
}

void BasicClouds::unpackUpdate( NetConnection *conn, BitStream *stream )
{
   Parent::unpackUpdate( conn, stream );

   for ( U32 i = 0; i < TEX_COUNT; i++ )
   {
      mLayerEnabled[i] = stream->readFlag();

      stream->read( &mTexName[i] );
      
      stream->read( &mTexScale[i] );      
      mathRead( *stream, &mTexDirection[i] );
      stream->read( &mTexSpeed[i] );
      mathRead( *stream, &mTexOffset[i] );

      stream->read( &mHeight[i] );
   }

   if ( isProperlyAdded() )
   {
      // We could check if the height or texture have actually changed.
      _initBuffers();
      _initTexture();
   }
}


// SceneObject...


void BasicClouds::prepRenderImage( SceneRenderState *state )
{
   PROFILE_SCOPE( BasicClouds_prepRenderImage );

   bool isEnabled = false;
   for ( U32 i = 0; i < TEX_COUNT; i++ )
   {
      if ( mLayerEnabled[i] )
      {
         isEnabled = true;
         break;
      }
   }

   if ( !isEnabled )
      return;

   // This should be sufficient for most objects that don't manage zones, and
   // don't need to return a specialized RenderImage...
   ObjectRenderInst *ri = state->getRenderPass()->allocInst< ObjectRenderInst >();
   ri->renderDelegate.bind( this, &BasicClouds::renderObject );
   ri->type = RenderPassManager::RIT_Sky;
   ri->defaultKey = 0;
   ri->defaultKey2 = 0;
   state->getRenderPass()->addInst( ri );
}

void BasicClouds::renderObject( ObjectRenderInst *ri, SceneRenderState *state, BaseMatInstance *mi )
{
   GFXTransformSaver saver;

   Point3F camPos = state->getCameraPosition();
   MatrixF xfm(true);
   xfm.setPosition(camPos);
   GFX->multWorld(xfm);   

   if ( state->isReflectPass() )
      GFX->setProjectionMatrix( state->getSceneManager()->getNonClipProjection() );

   GFX->setShader( mShader );
   GFX->setShaderConstBuffer( mShaderConsts );
   GFX->setStateBlock( mStateblock );

   MatrixF xform(GFX->getProjectionMatrix());
   xform *= GFX->getViewMatrix();
   xform *= GFX->getWorldMatrix();

   mShaderConsts->setSafe( mModelViewProjSC, xform );
   mShaderConsts->setSafe( mTimeSC, (F32)Sim::getCurrentTime() / 1000.0f );
   GFX->setPrimitiveBuffer( mPB );

   for ( U32 i = 0; i < TEX_COUNT; i++ )
   {      
      if ( !mLayerEnabled[i] )
         continue;

      mShaderConsts->setSafe( mTexScaleSC, mTexScale[i] );
      mShaderConsts->setSafe( mTexDirectionSC, mTexDirection[i] * mTexSpeed[i] );
      mShaderConsts->setSafe( mTexOffsetSC, mTexOffset[i] );         

      GFX->setTexture( 0, mTexture[i] );                            
      GFX->setVertexBuffer( mVB[i] );            

      GFX->drawIndexedPrimitive( GFXTriangleList, 0, 0, smVertCount, 0, smTriangleCount );
   }
}


// BasicClouds Internal Methods....


void BasicClouds::_initTexture()
{
   for ( U32 i = 0; i < TEX_COUNT; i++ )
   {
      if ( !mLayerEnabled[i] )
      {
         mTexture[i] = NULL;
         continue;
      }

      if ( mTexName[i].isNotEmpty() )
      mTexture[i].set( mTexName[i], &GFXDefaultStaticDiffuseProfile, "BasicClouds" );

      if ( mTexture[i].isNull() )
         mTexture[i].set( GFXTextureManager::getWarningTexturePath(), &GFXDefaultStaticDiffuseProfile, "BasicClouds" );
   }
}

void BasicClouds::_initBuffers()
{      
   // Primitive Buffer...  Is shared for all Layers.

   mPB.set( GFX, smTriangleCount * 3, smTriangleCount, GFXBufferTypeStatic );

   U16 *pIdx = NULL;   
   mPB.lock(&pIdx);     
   U32 curIdx = 0; 

   for ( U32 y = 0; y < smStrideMinusOne; y++ )
   {
      for ( U32 x = 0; x < smStrideMinusOne; x++ )
      {
         U32 offset = x + y * smVertStride;

         pIdx[curIdx] = offset;
         curIdx++;
         pIdx[curIdx] = offset + 1;
         curIdx++;
         pIdx[curIdx] = offset + smVertStride + 1;
         curIdx++;

         pIdx[curIdx] = offset;
         curIdx++;
         pIdx[curIdx] = offset + smVertStride + 1;
         curIdx++;
         pIdx[curIdx] = offset + smVertStride;
         curIdx++;
      }
   }

   mPB.unlock();   

   // Vertex Buffer... 
   // Each layer has their own so they can be at different heights.

   for ( U32 i = 0; i < TEX_COUNT; i++ )
   {
      Point3F vertScale( 16.0f, 16.0f, mHeight[i] );
      F32 zOffset = -( mCos( mSqrt( 1.0f ) ) + 0.01f );
      
      mVB[i].set( GFX, smVertCount, GFXBufferTypeStatic );   
      GFXVertexPT *pVert = mVB[i].lock(); 

      for ( U32 y = 0; y < smVertStride; y++ )
      {
         F32 v = ( (F32)y / (F32)smStrideMinusOne - 0.5f ) * 2.0f;

         for ( U32 x = 0; x < smVertStride; x++ )
         {
            F32 u = ( (F32)x / (F32)smStrideMinusOne - 0.5f ) * 2.0f;

            F32 sx = u;
            F32 sy = v;
            F32 sz = mCos( mSqrt( sx*sx + sy*sy ) ) + zOffset;

            pVert->point.set( sx, sy, sz );
            pVert->point *= vertScale;
            pVert->texCoord.set( u, v );   
            pVert++;
         }
      }

      mVB[i].unlock();
   } 
}

static StringTableEntry layersCustomNodeName = StringTable->insert("Layers");
static StringTableEntry layerNodeName = StringTable->insert("Layer");
static StringTableEntry layerEnabledName = StringTable->insert("Enabled");
static StringTableEntry layerName = StringTable->insert("Texture");
static StringTableEntry layerScaleName = StringTable->insert("Scale");
static StringTableEntry layerDirName = StringTable->insert("Direction");
static StringTableEntry layerSpeedName = StringTable->insert("Speed");
static StringTableEntry layerOffsetName = StringTable->insert("Offset");
static StringTableEntry layerHeightName = StringTable->insert("Height");

void BasicClouds::onTamlCustomWrite( TamlCustomNodes& customNodes )
{
   // Debug Profiling.
   PROFILE_SCOPE(BasicClouds_OnTamlCustomWrite);

   // Call parent.
   Parent::onTamlCustomWrite( customNodes );

   if (TEX_COUNT > 0)
   {
      // Add cell custom node.
      TamlCustomNode* pCustomCellNodes = customNodes.addNode( layersCustomNodeName );

      // Iterate explicit frames.
      for( U8 i = 0; i < TEX_COUNT; i++ )
      {
         bool texEnabled = mLayerEnabled[i];
         String texName = mTexName[i];
         F32 texScale = mTexScale[i];
         Point2F texDir = mTexDirection[i];
         F32 texSpeed = mTexSpeed[i];
         Point2F texOffset = mTexOffset[i];
         F32 height = mHeight[i];

         const AbstractClassRep::Field* enabledField = findField(StringTable->insert("layerEnabled"));
         const AbstractClassRep::Field* nameField = findField(StringTable->insert("texture"));
         const AbstractClassRep::Field* scaleField = findField(StringTable->insert("texScale"));
         const AbstractClassRep::Field* dirField = findField(StringTable->insert("texDirection"));
         const AbstractClassRep::Field* speedField = findField(StringTable->insert("texSpeed"));
         const AbstractClassRep::Field* offsetField = findField(StringTable->insert("texOffset"));
         const AbstractClassRep::Field* heightField = findField(StringTable->insert("height"));

         // Add cell alias.
         TamlCustomNode* pNode = pCustomCellNodes->addNode( layerNodeName );

         char buf[2];
         dSprintf(buf,2,"%d",i);
         // Add cell properties.
         if(enabledField->writeDataFn->fn(this, enabledField->pFieldname, buf))
            pNode->addField( layerEnabledName, texEnabled );
         if(nameField->writeDataFn->fn(this, nameField->pFieldname, buf))
            pNode->addField( layerName, texName.c_str() );
         if(scaleField->writeDataFn->fn(this, scaleField->pFieldname, buf))
            pNode->addField( layerScaleName, texScale );
         if(dirField->writeDataFn->fn(this, dirField->pFieldname, buf))
            pNode->addField( layerDirName, texDir );
         if(speedField->writeDataFn->fn(this, speedField->pFieldname, buf))
            pNode->addField( layerSpeedName, texSpeed );
         if(offsetField->writeDataFn->fn(this, offsetField->pFieldname, buf))
            pNode->addField( layerOffsetName, texOffset );
         if(heightField->writeDataFn->fn(this, heightField->pFieldname, buf))
            pNode->addField( layerHeightName, height );
      }
   }
}

void BasicClouds::onTamlCustomRead( const TamlCustomNodes& customNodes )
{
   // Debug Profiling.
   PROFILE_SCOPE(BasicClouds_OnTamlCustomRead);

   // Call parent.
   Parent::onTamlCustomRead( customNodes );

   // Find cell custom node.
   const TamlCustomNode* pCustomCellNodes = customNodes.findNode( layersCustomNodeName );

   // Continue if we have explicit cells.
   if ( pCustomCellNodes != NULL )
   {
      // Fetch children cell nodes.
      const TamlCustomNodeVector& cellNodes = pCustomCellNodes->getChildren();

      U8 idx = 0;

      // Iterate cells.
      for( TamlCustomNodeVector::const_iterator cellNodeItr = cellNodes.begin(); cellNodeItr != cellNodes.end(); ++cellNodeItr )
      {
         // Fetch cell node.
         TamlCustomNode* pCellNode = *cellNodeItr;

         // Fetch node name.
         StringTableEntry nodeName = pCellNode->getNodeName();

         // Is this a valid alias?
         if ( nodeName != layerNodeName )
         {
            // No, so warn.
            Con::warnf( "BasicClouds::onTamlCustomRead() - Encountered an unknown custom name of '%s'.  Only '%s' is valid.", nodeName, layerNodeName );
            continue;
         }

         // Fetch fields.
         const TamlCustomFieldVector& fields = pCellNode->getFields();

         // Iterate property fields.
         for ( TamlCustomFieldVector::const_iterator fieldItr = fields.begin(); fieldItr != fields.end(); ++fieldItr )
         {
            // Fetch field.
            const TamlCustomField* pField = *fieldItr;

            // Fetch field name.
            StringTableEntry fieldName = pField->getFieldName();

            // Check common fields.
            if ( fieldName == layerEnabledName )
            {
               pField->getFieldValue( mLayerEnabled[idx] );
            }
            else if ( fieldName == layerName )
            {
               mTexName[idx] = String(pField->getFieldValue());
            }
            else if ( fieldName == layerScaleName )
            {
               pField->getFieldValue( mTexScale[idx] );
            }
            else if ( fieldName == layerDirName )
            {
               pField->getFieldValue( mTexDirection[idx] );
            }
            else if ( fieldName == layerSpeedName )
            {
               pField->getFieldValue( mTexSpeed[idx] );
            }
            else if ( fieldName == layerOffsetName )
            {
               pField->getFieldValue( mTexOffset[idx] );
            }
            else if ( fieldName == layerHeightName )
            {
               pField->getFieldValue( mHeight[idx] );
            }
            else
            {
               // Unknown name so warn.
               Con::warnf( "BasicClouds::onTamlCustomRead() - Encountered an unknown custom field name of '%s'.", fieldName );
               continue;
            }
         }
         idx++;
      }
   }
}