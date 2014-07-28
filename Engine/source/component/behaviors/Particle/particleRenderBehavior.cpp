#include "particleRenderBehavior.h"
#include <component/behaviors/Particle/particleInterfaces.h>
#include <T3D/fx/particleEmitter.h>
#include <core/stream/bitStream.h>

// Enum tables used for fields blendStyle, srcBlendFactor, dstBlendFactor.
// Note that the enums for srcBlendFactor and dstBlendFactor are consistent
// with the blending enums used in Torque Game Builder.

//typedef ParticleRenderInst::BlendStyle billboardParticleBlendStyle;
//DefineEnumType( billboardParticleBlendStyle );
//
//ImplementEnumType( billboardParticleBlendStyle,
//   "The type of visual blending style to apply to the particles.\n"
//   "@ingroup FX\n\n")
//   { ParticleRenderInst::BlendNormal,         "NORMAL",        "No blending style.\n" },
//   { ParticleRenderInst::BlendAdditive,       "ADDITIVE",      "Adds the color of the pixel to the frame buffer with full alpha for each pixel.\n" },
//   { ParticleRenderInst::BlendSubtractive,    "SUBTRACTIVE",   "Subtractive Blending. Reverses the color model, causing dark colors to have a stronger visual effect.\n" },
//   { ParticleRenderInst::BlendPremultAlpha,   "PREMULTALPHA",  "Color blends with the colors of the imagemap rather than the alpha.\n" },
//EndImplementEnumType;

//////////////////////////////////////////////////////////////////////////
// Constructor/Destructor
//////////////////////////////////////////////////////////////////////////

ParticleRenderBehavior::ParticleRenderBehavior()
{
	mNetFlags.set(Ghostable | ScopeAlways);

   addBehaviorField("textureName", "BillboardTexture.", "text", "", "text");

	mFriendlyName = "Render Particles";
   mBehaviorType = "Render";

	mDescription = getDescriptionText("Causes the object to render particles.");

	mNetworked = true;

   setScopeAlways();
}

ParticleRenderBehavior::~ParticleRenderBehavior()
{
   for(S32 i = 0;i < mFields.size();++i)
   {
      BehaviorField &field = mFields[i];
      SAFE_DELETE_ARRAY(field.mFieldDescription);
   }

   SAFE_DELETE_ARRAY(mDescription);
}

IMPLEMENT_CO_NETOBJECT_V1(ParticleRenderBehavior);

//////////////////////////////////////////////////////////////////////////
BehaviorInstance *ParticleRenderBehavior::createInstance()
{
   ParticleRenderBehaviorInstance *instance = new ParticleRenderBehaviorInstance(this);

   setupFields( instance );

   if(instance->registerObject())
      return instance;

   delete instance;
   return NULL;
}

bool ParticleRenderBehavior::onAdd()
{
   if(! Parent::onAdd())
      return false;

   return true;
}

void ParticleRenderBehavior::onRemove()
{
   Parent::onRemove();
}
void ParticleRenderBehavior::initPersistFields()
{
   Parent::initPersistFields();
}

U32 ParticleRenderBehavior::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);
	return retMask;
}

void ParticleRenderBehavior::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);
}

//==========================================================================================
//==========================================================================================

IMPLEMENT_CO_NETOBJECT_V1(ParticleRenderBehaviorInstance);

ParticleRenderBehaviorInstance::ParticleRenderBehaviorInstance( BehaviorTemplate *btemplate ) 
{
   mTemplate = btemplate;
   mBehaviorOwner = NULL;
   
   mCurBuffSize = 0;
   
   mSoftnessDistance = 1.0f;
   mTextureHandle = NULL;
   mTextureName = NULL;
   mTexCoords[0].set(0.0,0.0);   // texture coords at 4 corners
   mTexCoords[1].set(0.0,1.0);   // of particle quad
   mTexCoords[2].set(1.0,1.0);   // (defaults to entire particle)
   mTexCoords[3].set(1.0,0.0);
   
   mRenderReflection = true;
   mHighResOnly = true;

   mSortParticles = false;
   mOrientParticles = false;
   mOrientOnVelocity = true;
   mReverseOrder = false;
   mAlignParticles = false;
   mAlignDirection = Point3F(0.0f, 1.0f, 0.0f);
   
   //mBlendStyle = ParticleRenderInst::BlendStyle::BlendUndefined;
   mBlendStyle = ParticleRenderInst::BlendStyle::BlendAdditive;
   mAmbientFactor = 0.0f;
   
   S32 i;
   for( i=0; i<PDC_NUM_KEYS; i++ )
   {
      mColors[i].set( 1.0, 1.0, 1.0, 1.0 );
      mSizes[i] = 1.0;
   }

   mTimes[0] = 0.0f;
   mTimes[1] = 0.33f;
   mTimes[2] = 0.66f;
   mTimes[3] = 1.0f;

   mNetFlags.set(Ghostable);
}

ParticleRenderBehaviorInstance::~ParticleRenderBehaviorInstance()
{
}

bool ParticleRenderBehaviorInstance::onAdd()
{
   if(! Parent::onAdd())
      return false;

   // load emitter texture if specified
   if (mTextureName)
   {
      mTextureHandle = GFXTexHandle(mTextureName, &GFXDefaultStaticDiffuseProfile, avar("%s() - textureHandle (line %d)", __FUNCTION__, __LINE__));
      if (!mTextureHandle)
      {
         Con::errorf("Missing particle emitter texture: %s", mTextureName);
         return false;
      }
   }

   return true;
}

void ParticleRenderBehaviorInstance::onPostAdd()
{
   allocPrimBuffer();
}

void ParticleRenderBehaviorInstance::onRemove()
{
   Parent::onRemove();
}

//This is mostly a catch for situations where the behavior is re-added to the object and the like and we may need to force an update to the behavior
void ParticleRenderBehaviorInstance::onBehaviorAdd()
{
   Parent::onBehaviorAdd();
}

void ParticleRenderBehaviorInstance::onBehaviorRemove()
{
   Parent::onBehaviorRemove();
}

void ParticleRenderBehaviorInstance::registerInterfaces()
{
   Parent::registerInterfaces();
	mBehaviorOwner->registerCachedInterface( "render", "prepRenderImage", this, &mRenderInterface );
}

void ParticleRenderBehaviorInstance::unregisterInterfaces()
{
   Parent::unregisterInterfaces();
	mBehaviorOwner->removeCachedInterface( "render", "prepRenderImage", this );
}

void ParticleRenderBehaviorInstance::initPersistFields()
{
   addField( "textureName", TYPEID< StringTableEntry >(), Offset(mTextureName, ParticleRenderBehaviorInstance),
      "Texture file to use for this particle." );
   Parent::initPersistFields();
}

U32 ParticleRenderBehaviorInstance::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);
   if (stream->writeFlag(mTextureName != 0))
     stream->writeString(mTextureName);
	return retMask;
}

void ParticleRenderBehaviorInstance::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);
   mTextureName = (stream->readFlag()) ? stream->readSTString() : 0;
}

F32 ParticleRenderBehaviorInstance::getParticleSize(Particle const* part)
{
   AssertFatal(part->totalLifetime > 0, "Particle lifetime must be larger than 0.");
   F32 t = F32(part->currentAge) / F32(part->totalLifetime);
   AssertFatal(t <= 1.0f, "Out out bounds filter function for particle.");

   for( U32 i = 1; i < PDC_NUM_KEYS; i++ )
   {
      if( mTimes[i] >= t )
      {
         F32 firstPart = t - mTimes[i-1];
         F32 total     = mTimes[i] -
                         mTimes[i-1];

         firstPart /= total;

         return (mSizes[i-1] * (1.0 - firstPart)) +
                        (mSizes[i]   * firstPart);
      }
   }
}

ColorF ParticleRenderBehaviorInstance::getParticleColor(Particle const* part)
{
   AssertFatal(part->totalLifetime > 0, "Particle lifetime must be larger than 0.");
   F32 t = F32(part->currentAge) / F32(part->totalLifetime);
   AssertFatal(t <= 1.0f, "Out out bounds filter function for particle.");

   for( U32 i = 1; i < PDC_NUM_KEYS; i++ )
   {
      if( mTimes[i] >= t )
      {
         F32 firstPart = t - mTimes[i-1];
         F32 total     = mTimes[i] -
                         mTimes[i-1];

         firstPart /= total;
         ColorF outCol;
         outCol.interpolate(mColors[i-1], mColors[i], firstPart);
         return outCol;
      }
   }
}

void ParticleRenderBehaviorInstance::prepRenderImage(SceneRenderState* state)
{
   ParticleSimulationInterface* simulation = getBehaviorOwner()->getInterface<ParticleSimulationInterface>();
   if(!simulation)
      return;
   ParticlePool partPool = simulation->getPool();
   if( state->isReflectPass() && !mRenderReflection )
      return;

   // Never render into shadows.
   if (state->isShadowPass())
      return;

   PROFILE_SCOPE(ParticleEmitter_prepRenderImage);

   if (  //mDead ||
         partPool.getCount() == 0 || 
         partPool.GetParticleHead()->next == NULL )
      return;

   RenderPassManager *renderManager = state->getRenderPass();
   const Point3F &camPos = state->getCameraPosition();
   copyToVB( camPos, state->getAmbientLightColor() );

   if (!mVertBuff.isValid())
      return;

   if(primBuff.isNull() || !primBuff.isValid())
      allocPrimBuffer();

   ParticleRenderInst *ri = renderManager->allocInst<ParticleRenderInst>();

   ri->vertBuff = &mVertBuff;
   ri->primBuff = &primBuff;
   ri->translucentSort = true;
   ri->type = RenderPassManager::RIT_Particle;
   // TODO: Should be getRenderWorldBox()
   ri->sortDistSq = getBehaviorOwner()->getWorldBox().getSqDistanceToPoint( camPos );

   // Draw the system offscreen unless the highResOnly flag is set on the datablock
   ri->systemState = ( mHighResOnly ? PSS_AwaitingHighResDraw : PSS_AwaitingOffscreenDraw );

   ri->modelViewProj = renderManager->allocUniqueXform(  GFX->getProjectionMatrix() * 
                                                         GFX->getViewMatrix() * 
                                                         GFX->getWorldMatrix() );

   // Update position on the matrix before multiplying it
   mBBObjToWorld.setPosition(simulation->getLastPosition());

   ri->bbModelViewProj = renderManager->allocUniqueXform( *ri->modelViewProj * mBBObjToWorld );

   ri->count = partPool.getCount();

   ri->blendStyle = mBlendStyle;

   // use first particle's texture unless there is an emitter texture to override it
   if (mTextureHandle)
     ri->diffuseTex = &*(mTextureHandle);

   ri->softnessDistance = mSoftnessDistance; 

   // Sort by texture too.
   ri->defaultKey = ri->diffuseTex ? (U32)ri->diffuseTex : (U32)ri->vertBuff;

   renderManager->addInst( ri );
}

//-----------------------------------------------------------------------------
// alloc PrimitiveBuffer
// The datablock allocates this static index buffer because it's the same
// for all of the emitters - each particle quad uses the same index ordering
//-----------------------------------------------------------------------------
void ParticleRenderBehaviorInstance::allocPrimBuffer()
{
   ParticleSimulationInterface* simulation = getBehaviorOwner()->getInterface<ParticleSimulationInterface>();
   if(!simulation)
      return;
   ParticlePool partPool = simulation->getPool();
   // create index buffer based on that size
   U32 indexListSize = partPool.getCapacity() * 6; // 6 indices per particle
   U16 *indices = new U16[ indexListSize ];

   for( U32 i=0; i<partPool.getCapacity(); i++ )
   {
      // this index ordering should be optimal (hopefully) for the vertex cache
      U16 *idx = &indices[i*6];
      volatile U32 offset = i * 4;  // set to volatile to fix VC6 Release mode compiler bug
      idx[0] = 0 + offset;
      idx[1] = 1 + offset;
      idx[2] = 3 + offset;
      idx[3] = 1 + offset;
      idx[4] = 3 + offset;
      idx[5] = 2 + offset;
   }


   U16 *ibIndices;
   GFXBufferType bufferType = GFXBufferTypeStatic;

#ifdef TORQUE_OS_XENON
   // Because of the way the volatile buffers work on Xenon this is the only
   // way to do this.
   bufferType = GFXBufferTypeVolatile;
#endif
   primBuff.set( GFX, indexListSize, 0, bufferType );
   primBuff.lock( &ibIndices );
   dMemcpy( ibIndices, indices, indexListSize * sizeof(U16) );
   primBuff.unlock();

   delete [] indices;
}

//-----------------------------------------------------------------------------
// Copy particles to vertex buffer
//-----------------------------------------------------------------------------

// structure used for particle sorting.
struct SortParticle
{
   Particle* p;
   F32       k;
};

// qsort callback function for particle sorting
S32 QSORT_CALLBACK behavior_cmpSortParticles(const void* p1, const void* p2)
{
   const SortParticle* sp1 = (const SortParticle*)p1;
   const SortParticle* sp2 = (const SortParticle*)p2;

   if (sp2->k > sp1->k)
      return 1;
   else if (sp2->k == sp1->k)
      return 0;
   else
      return -1;
}

void ParticleRenderBehaviorInstance::copyToVB(Point3F const& camPos, ColorF const& ambientColor)
{
   ParticleSimulationInterface* simulation = getBehaviorOwner()->getInterface<ParticleSimulationInterface>();
   ParticlePool partPool = simulation->getPool();

   static Vector<SortParticle> orderedVector(__FILE__, __LINE__);

   PROFILE_START(ParticleEmitter_copyToVB);

   PROFILE_START(ParticleEmitter_copyToVB_Sort);
   // build sorted list of particles (far to near)
   if (mSortParticles)
   {
     orderedVector.clear();

     MatrixF modelview = GFX->getWorldMatrix();
     Point3F viewvec; modelview.getRow(1, &viewvec);

     // add each particle and a distance based sort key to orderedVector
     for (Particle* pp = partPool.GetParticleHead()->next; pp != NULL; pp = pp->next)
     {
       orderedVector.increment();
       orderedVector.last().p = pp;
       orderedVector.last().k = mDot(pp->pos, viewvec);
     }

     // qsort the list into far to near ordering
     dQsort(orderedVector.address(), orderedVector.size(), sizeof(SortParticle), behavior_cmpSortParticles);
   }
   PROFILE_END();

#if defined(TORQUE_OS_XENON)
   // Allocate writecombined since we don't read back from this buffer (yay!)
   if(mVertBuff.isNull())
      mVertBuff = new GFX360MemVertexBuffer(GFX, 1, getGFXVertexFormat<ParticleVertexType>(), sizeof(ParticleVertexType), GFXBufferTypeDynamic, PAGE_WRITECOMBINE);
   if( n_parts > mCurBuffSize )
   {
      mCurBuffSize = n_parts;
      mVertBuff.resize(n_parts * 4);
   }

   ParticleVertexType *buffPtr = mVertBuff.lock();
#else
   static Vector<ParticleVertexType> tempBuff(2048);
   tempBuff.reserve( partPool.getCount()*4 + 64); // make sure tempBuff is big enough
   ParticleVertexType *buffPtr = tempBuff.address(); // use direct pointer (faster)
#endif
   
   if (mOrientParticles)
   {
      PROFILE_START(ParticleEmitter_copyToVB_Orient);

      if (mReverseOrder)
      {
        buffPtr += 4*(partPool.getCount()-1);
        // do sorted-oriented particles
        if (mSortParticles)
        {
          SortParticle* partPtr = orderedVector.address();
          for (U32 i = 0; i < partPool.getCount(); i++, partPtr++, buffPtr-=4 )
             setupOriented(partPtr->p, camPos, ambientColor, buffPtr);
        }
        // do unsorted-oriented particles
        else
        {
          for (Particle* partPtr = partPool.GetParticleHead()->next; partPtr != NULL; partPtr = partPtr->next, buffPtr-=4)
             setupOriented(partPtr, camPos, ambientColor, buffPtr);
        }
      }
      else
      {
        // do sorted-oriented particles
        if (mSortParticles)
        {
          SortParticle* partPtr = orderedVector.address();
          for (U32 i = 0; i < partPool.getCount(); i++, partPtr++, buffPtr+=4 )
             setupOriented(partPtr->p, camPos, ambientColor, buffPtr);
        }
        // do unsorted-oriented particles
        else
        {
          for (Particle* partPtr = partPool.GetParticleHead()->next; partPtr != NULL; partPtr = partPtr->next, buffPtr+=4)
             setupOriented(partPtr, camPos, ambientColor, buffPtr);
        }
      }
	  PROFILE_END();
   }
   else if (mAlignParticles)
   {
      PROFILE_START(ParticleEmitter_copyToVB_Aligned);

      if (mReverseOrder)
      {
         buffPtr += 4*(partPool.getCount()-1);

         // do sorted-oriented particles
         if (mSortParticles)
         {
            SortParticle* partPtr = orderedVector.address();
            for (U32 i = 0; i < partPool.getCount(); i++, partPtr++, buffPtr-=4 )
               setupAligned(partPtr->p, ambientColor, buffPtr);
         }
         // do unsorted-oriented particles
         else
         {
            Particle *partPtr = partPool.GetParticleHead()->next;
            for (; partPtr != NULL; partPtr = partPtr->next, buffPtr-=4)
               setupAligned(partPtr, ambientColor, buffPtr);
         }
      }
      else
      {
         // do sorted-oriented particles
         if (mSortParticles)
         {
            SortParticle* partPtr = orderedVector.address();
            for (U32 i = 0; i < partPool.getCount(); i++, partPtr++, buffPtr+=4 )
               setupAligned(partPtr->p, ambientColor, buffPtr);
         }
         // do unsorted-oriented particles
         else
         {
            Particle *partPtr = partPool.GetParticleHead()->next;
            for (; partPtr != NULL; partPtr = partPtr->next, buffPtr+=4)
               setupAligned(partPtr, ambientColor, buffPtr);
         }
      }
	  PROFILE_END();
   }
   else
   {
      PROFILE_START(ParticleEmitter_copyToVB_NonOriented);
      // somewhat odd ordering so that texture coordinates match the oriented
      // particles
      Point3F basePoints[4];
      basePoints[0] = Point3F(-1.0, 0.0,  1.0);
      basePoints[1] = Point3F(-1.0, 0.0, -1.0);
      basePoints[2] = Point3F( 1.0, 0.0, -1.0);
      basePoints[3] = Point3F( 1.0, 0.0,  1.0);

      MatrixF camView = GFX->getWorldMatrix();
      camView.transpose();  // inverse - this gets the particles facing camera

      if (mReverseOrder)
      {
        buffPtr += 4*(partPool.getCount()-1);
        // do sorted-billboard particles
        if (mSortParticles)
        {
          SortParticle *partPtr = orderedVector.address();
          for( U32 i=0; i<partPool.getCount(); i++, partPtr++, buffPtr-=4 )
             setupBillboard( partPtr->p, basePoints, camView, ambientColor, buffPtr );
        }
        // do unsorted-billboard particles
        else
        {
          for (Particle* partPtr = partPool.GetParticleHead()->next; partPtr != NULL; partPtr = partPtr->next, buffPtr-=4)
             setupBillboard( partPtr, basePoints, camView, ambientColor, buffPtr );
        }
      }
      else
      {
        // do sorted-billboard particles
        if (mSortParticles)
        {
          SortParticle *partPtr = orderedVector.address();
          for( U32 i=0; i<partPool.getCount(); i++, partPtr++, buffPtr+=4 )
             setupBillboard( partPtr->p, basePoints, camView, ambientColor, buffPtr );
        }
        // do unsorted-billboard particles
        else
        {
          for (Particle* partPtr = partPool.GetParticleHead()->next; partPtr != NULL; partPtr = partPtr->next, buffPtr+=4)
             setupBillboard( partPtr, basePoints, camView, ambientColor, buffPtr );
        }
      }

      PROFILE_END();
   }

#if defined(TORQUE_OS_XENON)
   mVertBuff.unlock();
#else
   PROFILE_START(ParticleEmitter_copyToVB_LockCopy);
   // create new VB if emitter size grows
   if( !mVertBuff || partPool.getCount() > mCurBuffSize )
   {
      mCurBuffSize = partPool.getCount();
      mVertBuff.set( GFX, partPool.getCount() * 4, GFXBufferTypeDynamic );
   }
   // lock and copy tempBuff to video RAM
   ParticleVertexType *verts = mVertBuff.lock();
   dMemcpy( verts, tempBuff.address(), partPool.getCount() * 4 * sizeof(ParticleVertexType) );
   mVertBuff.unlock();
   PROFILE_END();
#endif

   PROFILE_END();
}

//-----------------------------------------------------------------------------
// Set up particle for billboard style render
//-----------------------------------------------------------------------------
void ParticleRenderBehaviorInstance::setupBillboard( Particle *part,
                                      Point3F *basePts,
                                      const MatrixF &camView,
                                      const ColorF &ambientColor,
                                      ParticleVertexType *lVerts )
{
   F32 width     = getParticleSize(part) * 0.5f;
   F32 spinAngle = part->spinSpeed * part->currentAge * ParticleEmitter::AgedSpinToRadians;

   F32 sy, cy;
   mSinCos(spinAngle, sy, cy);

   const F32 ambientLerp = mClampF( mAmbientFactor, 0.0f, 1.0f );
   ColorF partCol = mLerp( getParticleColor(part), ( getParticleColor(part) * ambientColor ), ambientLerp );

   // fill four verts, use macro and unroll loop
   #define fillVert(){ \
      lVerts->point.x = cy * basePts->x - sy * basePts->z;  \
      lVerts->point.y = 0.0f;                                \
      lVerts->point.z = sy * basePts->x + cy * basePts->z;  \
      camView.mulV( lVerts->point );                        \
      lVerts->point *= width;                               \
      lVerts->point += part->pos;                           \
      lVerts->color = partCol; } \

   // Here we deal with UVs for animated particle (billboard)
   //if (part->dataBlock->animateTexture)
   //{ 
   //  S32 fm = (S32)(part->currentAge*(1.0/1000.0)*part->dataBlock->framesPerSec);
   //  U8 fm_tile = part->dataBlock->animTexFrames[fm % part->dataBlock->numFrames];
   //  S32 uv[4];
   //  uv[0] = fm_tile + fm_tile/part->dataBlock->animTexTiling.x;
   //  uv[1] = uv[0] + (part->dataBlock->animTexTiling.x + 1);
   //  uv[2] = uv[1] + 1;
   //  uv[3] = uv[0] + 1;

   //  fillVert();
   //  // Here and below, we copy UVs from particle datablock's current frame's UVs (billboard)
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[0]];
   //  ++lVerts;
   //  ++basePts;

   //  fillVert();
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[1]];
   //  ++lVerts;
   //  ++basePts;

   //  fillVert();
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[2]];
   //  ++lVerts;
   //  ++basePts;

   //  fillVert();
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[3]];
   //  ++lVerts;
   //  ++basePts;

   //  return;
   //}

   fillVert();
   // Here and below, we copy UVs from particle datablock's texCoords (billboard)
   lVerts->texCoord = mTexCoords[0];
   ++lVerts;
   ++basePts;

   fillVert();
   lVerts->texCoord = mTexCoords[1];
   ++lVerts;
   ++basePts;

   fillVert();
   lVerts->texCoord = mTexCoords[2];
   ++lVerts;
   ++basePts;

   fillVert();
   lVerts->texCoord = mTexCoords[3];
   ++lVerts;
   ++basePts;
}

//-----------------------------------------------------------------------------
// Set up oriented particle
//-----------------------------------------------------------------------------
void ParticleRenderBehaviorInstance::setupOriented( Particle *part,
                                     const Point3F &camPos,
                                     const ColorF &ambientColor,
                                     ParticleVertexType *lVerts )
{
   Point3F dir;

   if( mOrientOnVelocity )
   {
      // don't render oriented particle if it has no velocity
      if( part->vel.magnitudeSafe() == 0.0 ) return;
      dir = part->vel;
   }
   else
   {
      dir = part->orientDir;
   }

   Point3F dirFromCam = part->pos - camPos;
   Point3F crossDir;
   mCross( dirFromCam, dir, &crossDir );
   crossDir.normalize();
   dir.normalize();

   F32 width = getParticleSize(part) * 0.5f;
   dir *= width;
   crossDir *= width;
   Point3F start = part->pos - dir;
   Point3F end = part->pos + dir;

   const F32 ambientLerp = mClampF( mAmbientFactor, 0.0f, 1.0f );
   ColorF partCol = mLerp( getParticleColor(part), ( getParticleColor(part) * ambientColor ), ambientLerp );

   // Here we deal with UVs for animated particle (oriented)
   //if (part->dataBlock->animateTexture)
   //{ 
   //   // Let particle compute the UV indices for current frame
   //   S32 fm = (S32)(part->currentAge*(1.0f/1000.0f)*part->dataBlock->framesPerSec);
   //   U8 fm_tile = part->dataBlock->animTexFrames[fm % part->dataBlock->numFrames];
   //   S32 uv[4];
   //   uv[0] = fm_tile + fm_tile/part->dataBlock->animTexTiling.x;
   //   uv[1] = uv[0] + (part->dataBlock->animTexTiling.x + 1);
   //   uv[2] = uv[1] + 1;
   //   uv[3] = uv[0] + 1;

   //  lVerts->point = start + crossDir;
   //  lVerts->color = partCol;
   //  // Here and below, we copy UVs from particle datablock's current frame's UVs (oriented)
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[0]];
   //  ++lVerts;

   //  lVerts->point = start - crossDir;
   //  lVerts->color = partCol;
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[1]];
   //  ++lVerts;

   //  lVerts->point = end - crossDir;
   //  lVerts->color = partCol;
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[2]];
   //  ++lVerts;

   //  lVerts->point = end + crossDir;
   //  lVerts->color = partCol;
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[3]];
   //  ++lVerts;

   //  return;
   //}

   lVerts->point = start + crossDir;
   lVerts->color = partCol;
   // Here and below, we copy UVs from particle datablock's texCoords (oriented)
   lVerts->texCoord = mTexCoords[0];
   ++lVerts;

   lVerts->point = start - crossDir;
   lVerts->color = partCol;
   lVerts->texCoord = mTexCoords[1];
   ++lVerts;

   lVerts->point = end - crossDir;
   lVerts->color = partCol;
   lVerts->texCoord = mTexCoords[2];
   ++lVerts;

   lVerts->point = end + crossDir;
   lVerts->color = partCol;
   lVerts->texCoord = mTexCoords[3];
   ++lVerts;
}

void ParticleRenderBehaviorInstance::setupAligned( const Particle *part, 
                                    const ColorF &ambientColor,
                                    ParticleVertexType *lVerts )
{
   // The aligned direction will always be normalized.
   Point3F dir = mAlignDirection;

   // Find a right vector for this particle.
   Point3F right;
   if (mFabs(dir.y) > mFabs(dir.z))
      mCross(Point3F::UnitZ, dir, &right);
   else
      mCross(Point3F::UnitY, dir, &right);
   right.normalize();

   // If we have a spin velocity.
   if ( !mIsZero( part->spinSpeed ) )
   {
      F32 spinAngle = part->spinSpeed * part->currentAge * ParticleEmitter::AgedSpinToRadians;

      // This is an inline quaternion vector rotation which
      // is faster that QuatF.mulP(), but generates different
      // results and hence cannot replace it right now.

      F32 sin, qw;
      mSinCos( spinAngle * 0.5f, sin, qw );
      F32 qx = dir.x * sin;
      F32 qy = dir.y * sin;
      F32 qz = dir.z * sin;

      F32 vx = ( right.x * qw ) + ( right.z * qy ) - ( right.y * qz );
      F32 vy = ( right.y * qw ) + ( right.x * qz ) - ( right.z * qx );
      F32 vz = ( right.z * qw ) + ( right.y * qx ) - ( right.x * qy );
      F32 vw = ( right.x * qx ) + ( right.y * qy ) + ( right.z * qz );

      right.x = ( qw * vx ) + ( qx * vw ) + ( qy * vz ) - ( qz * vy );
      right.y = ( qw * vy ) + ( qy * vw ) + ( qz * vx ) - ( qx * vz );
      right.z = ( qw * vz ) + ( qz * vw ) + ( qx * vy ) - ( qy * vx );
   }

   // Get the cross vector.
   Point3F cross;
   mCross(right, dir, &cross);

   F32 width = getParticleSize(part) * 0.5f;
   right *= width;
   cross *= width;
   Point3F start = part->pos - right;
   Point3F end = part->pos + right;

   const F32 ambientLerp = mClampF( mAmbientFactor, 0.0f, 1.0f );
   ColorF partCol = mLerp( getParticleColor(part), ( getParticleColor(part) * ambientColor ), ambientLerp );

   // Here we deal with UVs for animated particle
   //if (part->dataBlock->animateTexture)
   //{ 
   //   // Let particle compute the UV indices for current frame
   //   S32 fm = (S32)(part->currentAge*(1.0f/1000.0f)*part->dataBlock->framesPerSec);
   //   U8 fm_tile = part->dataBlock->animTexFrames[fm % part->dataBlock->numFrames];
   //   S32 uv[4];
   //   uv[0] = fm_tile + fm_tile/part->dataBlock->animTexTiling.x;
   //   uv[1] = uv[0] + (part->dataBlock->animTexTiling.x + 1);
   //   uv[2] = uv[1] + 1;
   //   uv[3] = uv[0] + 1;

   //  lVerts->point = start + cross;
   //   lVerts->color = partCol;
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[0]];
   //  ++lVerts;

   //  lVerts->point = start - cross;
   //   lVerts->color = partCol;
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[1]];
   //  ++lVerts;

   //  lVerts->point = end - cross;
   //   lVerts->color = partCol;
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[2]];
   //  ++lVerts;

   //  lVerts->point = end + cross;
   //   lVerts->color = partCol;
   //  lVerts->texCoord = part->dataBlock->animTexUVs[uv[3]];
   //  ++lVerts;
   //}

   // Here and below, we copy UVs from particle datablock's texCoords
   lVerts->point = start + cross;
   lVerts->color = partCol;
   lVerts->texCoord = mTexCoords[0];
   ++lVerts;

   lVerts->point = start - cross;
   lVerts->color = partCol;
   lVerts->texCoord = mTexCoords[1];
   ++lVerts;

   lVerts->point = end - cross;
   lVerts->color = partCol;
   lVerts->texCoord = mTexCoords[2];
   ++lVerts;

   lVerts->point = end + cross;
   lVerts->color = partCol;
   lVerts->texCoord = mTexCoords[3];
   ++lVerts;
}