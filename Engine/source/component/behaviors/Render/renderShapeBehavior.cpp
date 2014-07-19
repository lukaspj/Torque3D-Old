//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#include "platform/platform.h"
#include "console/consoleTypes.h"
#include "component/behaviors/Render/renderShapeBehavior.h"
#include "core/util/safeDelete.h"
#include "core/resourceManager.h"
#include "core/stream/fileStream.h"
#include "console/consoleTypes.h"
#include "console/consoleObject.h"
#include "ts/tsShapeInstance.h"
#include "core/stream/bitStream.h"
//#include "console/consoleInternal.h"
#include "sim/netConnection.h"
#include "gfx/gfxTransformSaver.h"
#include "console/engineAPI.h"
#include "lighting/lightQuery.h"
#include "math/mTransform.h"

#include "gfx/sim/debugDraw.h"  
//
#include "gui/controls/guiTreeViewCtrl.h"

//////////////////////////////////////////////////////////////////////////
// Constructor/Destructor
//////////////////////////////////////////////////////////////////////////

RenderShapeBehavior::RenderShapeBehavior()
{
    addBehaviorField("shapeName", "Shape file to be rendered by this object.", "modelFile", "", "");
	addBehaviorField("shapeOffset", "Shape file to be rendered by this object.", "text", "", "text");
	mNetFlags.set(Ghostable | ScopeAlways);

	mFriendlyName = "Render Shape";
    mBehaviorType = "Render";

	mDescription = getDescriptionText("Causes the object to render a 3d shape using the file provided.");

	mNetworked = true;

   setScopeAlways();
}

RenderShapeBehavior::~RenderShapeBehavior(){}

IMPLEMENT_CO_NETOBJECT_V1(RenderShapeBehavior);

//////////////////////////////////////////////////////////////////////////
BehaviorInstance *RenderShapeBehavior::createInstance()
{
   RenderShapeBehaviorInstance *instance = new RenderShapeBehaviorInstance(this);

   setupFields( instance );

   if(instance->registerObject())
      return instance;

   delete instance;
   return NULL;
}

bool RenderShapeBehavior::onAdd()
{
   if(! Parent::onAdd())
      return false;

   String narp = mTemplateName;

   return true;
}

void RenderShapeBehavior::onRemove()
{
   Parent::onRemove();
}
void RenderShapeBehavior::initPersistFields()
{
   Parent::initPersistFields();
}

U32 RenderShapeBehavior::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);
	return retMask;
}

void RenderShapeBehavior::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);
}

//==========================================================================================
void RenderShapeBehaviorInstance::boneObject::addObject(SimObject* object)
{
	//Parent::addObject(object);
	SceneObject* sc = dynamic_cast<SceneObject*>(object);
	if(sc && mOwner && mOwner->getShape())
	{
		S32 nodeID = mOwner->getShape()->getShape()->findNode(mBoneName);

		//we may have a offset on the shape's center
		//so make sure we accomodate for that when setting up the mount offsets
		MatrixF mat = mOwner->getShape()->mNodeTransforms[nodeID];
		//mat.setPosition(mat.getPosition() + mOwner->getShape()->getShape()->center);

		mOwner->getBehaviorOwner()->mountObject(sc, nodeID, mat);
	}
}

//==========================================================================================
RenderShapeBehaviorInstance::RenderShapeBehaviorInstance( BehaviorTemplate *btemplate ) 
{
   mTemplate = btemplate;
   mBehaviorOwner = NULL;
   mShapeName = StringTable->insert("");
   mShapeInstance = NULL;
   mNetFlags.set(Ghostable | ScopeAlways);
}

RenderShapeBehaviorInstance::~RenderShapeBehaviorInstance()
{
}
IMPLEMENT_CO_NETOBJECT_V1(RenderShapeBehaviorInstance);

bool RenderShapeBehaviorInstance::onAdd()
{
   if(! Parent::onAdd())
      return false;

	// Register for the resource change signal.
   ResourceManager::get().getChangedSignal().notify( this, &RenderShapeBehaviorInstance::_onResourceChanged );

   //get the default shape, if any
   updateShape();

   return true;
}

void RenderShapeBehaviorInstance::onBehaviorAdd()
{
   Parent::onBehaviorAdd();

   //mBehaviorOwner->registerCachedInterface( "geometry", "getGeometry", this, &mGeometryInterface );
	mBehaviorOwner->registerCachedInterface( "render", "prepRenderImage", this, &mRenderInterface );
	mBehaviorOwner->registerCachedInterface( "render", "getShapeInstance", this, &mShapeInterface );

	mBehaviorOwner->registerCachedInterface( "editor", "onInspect", this, &mInspectInterface );

}

void RenderShapeBehaviorInstance::onRemove()
{
   if(mShapeInstance)
   {
	   delete mShapeInstance;
	   mShapeInstance = NULL;
   }

   Parent::onRemove();
}

void RenderShapeBehaviorInstance::onBehaviorRemove()
{
   if(mBehaviorOwner)
   {
	    Point3F pos = mBehaviorOwner->getPosition(); //store our center pos
		mBehaviorOwner->setObjectBox(Box3F(Point3F(-1,-1,-1), Point3F(1,1,1)));
		//mBehaviorOwner->resetWorldBox();
		mBehaviorOwner->setPosition(pos);
   }

   Parent::onBehaviorRemove();
}


void RenderShapeBehaviorInstance::initPersistFields()
{
   Parent::initPersistFields();

   //create a hook to our internal variables
	addField("shapeName",   TypeShapeFilename,  Offset( mShapeName, RenderShapeBehaviorInstance ), 
			"%Path and filename of the model file (.DTS, .DAE) to use for this TSStatic." );
   //addProtectedField("shapeName", TypeShapeFilename, Offset(mShapeName, RenderShapeBehaviorInstance), &_setShape, defaultProtectedGetFn);
}

bool RenderShapeBehaviorInstance::_setShape( void *object, const char *index, const char *data )
{
	RenderShapeBehaviorInstance *rbI = static_cast<RenderShapeBehaviorInstance*>(object);
	rbI->mShapeName = StringTable->insert(data);
	rbI->updateShape(); //make sure we force the update to resize the owner bounds
	rbI->setMaskBits(ShapeMask);

	return true;
}

void RenderShapeBehaviorInstance::_onResourceChanged( const Torque::Path &path )
{
   if ( path != Torque::Path( mShapeName ) )
      return;
   
   updateShape();
   setMaskBits(ShapeMask);
}

void RenderShapeBehaviorInstance::inspectPostApply()
{
	Parent::inspectPostApply();

	updateShape();
	setMaskBits(ShapeMask);
}

U32 RenderShapeBehaviorInstance::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);

	if( mask & (ShapeMask | InitialUpdateMask))
	{
		if(!mBehaviorOwner)
		{
			stream->writeFlag( false );
		}
		else if( con->getGhostIndex(mBehaviorOwner) != -1 )
		{
			stream->writeFlag( true );
			stream->writeString( mShapeName );
		}
		else
		{
			retMask |= ShapeMask; //try it again untill our dependency is ghosted
			stream->writeFlag( false );
		}
	}

	return retMask;
}

void RenderShapeBehaviorInstance::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);

	if(stream->readFlag())
	{
		mShapeName = stream->readSTString();
		updateShape();
	}
}

void RenderShapeBehaviorInstance::prepRenderImage( SceneRenderState *state )
{
   if(!mEnabled)
	   return;

   // get shape detail...we might not even need to be drawn
   Entity *o = dynamic_cast<Entity*>(getBehaviorOwner());
   Box3F box = getBehaviorOwner()->getWorldBox();
   Point3F cameraOffset = getBehaviorOwner()->getWorldBox().getClosestPoint( state->getDiffuseCameraPosition() ) - state->getDiffuseCameraPosition();
   F32 dist = cameraOffset.len();
   if (dist < 0.01f)
      dist = 0.01f;

   Point3F objScale = getBehaviorOwner()->getScale();
   F32 invScale = (1.0f/getMax(getMax(objScale.x,objScale.y),objScale.z));

   if(mShapeInstance)
   {
	   mShapeInstance->setDetailFromDistance( state, dist * invScale );
	   if (mShapeInstance->getCurrentDetail() < 0 )
		   return;
   }
   else if(!getBehaviorOwner()->gShowBoundingBox)
	   return;

   // Debug rendering of the shape bounding box.
   /*if ( getBehaviorOwner()->gShowBoundingBox )
   {
      ObjectRenderInst *ri = state->getRenderPass()->allocInst<ObjectRenderInst>();
      ri->renderDelegate.bind( this, &ShapeBase::_renderBoundingBox );
      ri->objectIndex = -1;
      ri->type = RenderPassManager::RIT_Editor;
      state->getRenderPass()->addInst( ri );
   }*/

   if( mShapeInstance )
   {
		GFXTransformSaver saver;

		// Set up our TS render state. 
		TSRenderState rdata;
		rdata.setSceneState( state );

		// We might have some forward lit materials
		// so pass down a query to gather lights.
		LightQuery query;
		query.init( getBehaviorOwner()->getWorldSphere() );
		rdata.setLightQuery( &query );

		MatrixF mat = getBehaviorOwner()->getRenderTransform();
		Point3F center = mShapeInstance->getShape()->center;
		Point3F position = mat.getPosition();
		
		getBehaviorOwner()->getObjToWorld().mulP(center);

		Point3F posOffset = position - center;
		
		//mat.setPosition(position + posOffset);
		mat.scale( objScale );

		GFX->setWorldMatrix( mat );

		mShapeInstance->animate();
		mShapeInstance->render( rdata );
   }

   //ColorI colr = mShapeInstance->getShape()->meshes[0]->mVertexData[0].color;
}

void RenderShapeBehaviorInstance::updateShape()
{
	if (mShapeName && mShapeName[0] != '\0')
	{
		mShape = ResourceManager::get().load(mShapeName);

		if(!mShape)
		{
			Con::errorf("RenderShapeBehavior::updateShape : failed to load shape file!");
			return; //if it failed to load, bail out
		}

		if(mShapeInstance)
			delete mShapeInstance;

		mShapeInstance = new TSShapeInstance( mShape, isClientObject() );

		if(mBehaviorOwner != NULL)
		{
			Entity* e = dynamic_cast<Entity*>(mBehaviorOwner);

			Point3F min, max, pos;
			pos = e->getPosition();

			e->getWorldToObj().mulP(pos);

			min = mShape->bounds.minExtents - (pos + mShapeInstance->getShape()->center);
			max = mShape->bounds.maxExtents - (pos + mShapeInstance->getShape()->center);

			//min = mShape->bounds.minExtents;
			//max = mShape->bounds.maxExtents;

			mShapeBounds.set(min, max);

			e->setObjectBox(Box3F(min, max));
			//e->setObjectBox(Box3F(min, max));

			//mBehaviorOwner->setObjectBox(Box3F(Point3F(-3, -3, -3), Point3F(3, 3, 3)));
			//mBehaviorOwner->resetWorldBox();
			//e->setMaskBits(Entity::BoundsMask);
		}
	}
}

MatrixF RenderShapeBehaviorInstance::getNodeTransform(S32 nodeIdx)
{
	if( mShapeInstance )
   {
		S32 nodeCount = mShapeInstance->getShape()->nodes.size();

		if(nodeIdx >= 0 && nodeIdx < nodeCount)
		{
			mShapeInstance->animate();
			MatrixF mountTransform = mShapeInstance->mNodeTransforms[nodeIdx];
			mountTransform.mul(mBehaviorOwner->getTransform());

			return mountTransform;
		}
	}

	return MatrixF::Identity;
}

S32 RenderShapeBehaviorInstance::getNodeByName(String nodeName)
{
	if( mShapeInstance )
   {
		S32 nodeIdx = mShapeInstance->getShape()->findNode(nodeName);

		return nodeIdx;
	}

	return -1;
}

bool RenderShapeBehaviorInstance::castRayRendered(const Point3F &start, const Point3F &end, RayInfo *info)
{
   return false;
   /*if ( !mShapeInstance )
      return false;

   // Cast the ray against the currently visible detail
   RayInfo localInfo;
   bool res = mShapeInstance->castRayOpcode( mShapeInstance->getCurrentDetail(), start, end, &localInfo );

   if ( res )
   {
      *info = localInfo;
      info->object = mBehaviorOwner;
      return true;
   }

   return false;*/
}

void RenderShapeBehaviorInstance::mountObjectToNode(SceneObject* objB, String node, MatrixF txfm)
{
	const char* test;
	test = node.c_str();
	if(dIsdigit(test[0])){
		getBehaviorOwner()->mountObject(objB, dAtoi(node), txfm);
	}
	else{
		S32 idx = getShape()->getShape()->findNode(node);
		getBehaviorOwner()->mountObject(objB, idx, txfm);
	}
}

/*Geometry* RenderShapeBehaviorInstance::getGeometry()
{
	return NULL;
}*/

void RenderShapeBehaviorInstance::onInspect()
{
	return;
	//accumulate a temporary listing of objects to represent the bones
	//then we add these to our object here, and finally add our object to our owner specifically
	//so that we, and all the bones under us, show in the heirarchy of the scene
	//The objects we use are a special simgroup class just for us, that have specific callbacks
	//in the event an entity is mounted to it.

	//mBehaviorOwner->addObject(this);
	/*GuiTreeViewCtrl *editorTree = dynamic_cast<GuiTreeViewCtrl*>(Sim::findObject("EditorTree"));
	if(!editorTree)
		return;

	if(mNodesList.empty())
	{
		if(!mShapeInstance)
			return;

		GuiTreeViewCtrl::Item *newItem, *parentItem;

		parentItem = editorTree->getItem(editorTree->findItemByObjectId(mBehaviorOwner->getId()));

		S32 componentID = editorTree->insertItem(parentItem->getID(), "RenderShapeBehavior");

		newItem = editorTree->getItem(componentID);
		newItem->mInspectorInfo.mObject = this;
		newItem->mState.set(GuiTreeViewCtrl::Item::DenyDrag);

		TSShape* shape = mShapeInstance->getShape();
		S32 nodeCount = shape->nodes.size();

		String nodeName, parentName;

		for(U32 i=0; i < nodeCount; i++)
		{
			S32 nID = shape->nodes[i].nameIndex;
			S32 pID = shape->nodes[i].parentIndex;
			S32 parentItemID;

			nodeName = shape->getNodeName(shape->nodes[i].nameIndex);
			if(pID != -1)
			{
				bool found = false;
				for(U32 b=0; b < mNodesList.size(); b++)
				{
					if(!dStrcmp(mNodesList[b]->mBoneName, shape->getNodeName(pID)))
					{
						parentItemID = mNodesList[b]->mItemID;
						found = true;
						break;
					}
				}

				if(!found)
					parentItemID = componentID;
			}
			else
			{
				parentItemID = componentID;
			}

			S32 boneID = editorTree->insertItem(parentItemID, nodeName);
			newItem = editorTree->getItem(boneID);

			boneObject *b = new boneObject(this);
			b->mBoneName = nodeName;
			b->mItemID = boneID;

			mNodesList.push_back(b);

			newItem->mInspectorInfo.mObject = b;
			newItem->mState.set(GuiTreeViewCtrl::Item::ForceItemName);
			newItem->mState.set(GuiTreeViewCtrl::Item::InspectorData);
			newItem->mState.set(GuiTreeViewCtrl::Item::ForceDragTarget);
			newItem->mState.set(GuiTreeViewCtrl::Item::DenyDrag);

			//while we're here, check our parent to see if anything is mounted to this node.
			//if it is, hijack the item and move it under us!
			for (SceneObject* itr = mBehaviorOwner->getMountList(); itr; itr = itr->getMountLink())
			{
				if(itr->getMountNode() == i)
				{
					newItem = editorTree->getItem(editorTree->findItemByObjectId(itr->getId()));
					newItem->mParent = editorTree->getItem(boneID);
				}
			}
		}

		/*GuiTreeViewCtrl::Item *newItem, *parentItem;

		parentItem = editorTree->getItem(editorTree->findItemByObjectId(mBehaviorOwner->getId()));

		S32 componentID = editorTree->insertItem(parentItem->getID(), "RenderShapeBehavior");

		newItem = editorTree->getItem(componentID);
		newItem->mInspectorInfo.mObject = this;
		newItem->mState.set(GuiTreeViewCtrl::Item::DenyDrag);

		boneObject *b = new boneObject(this);
		b->mBoneName = StringTable->insert("Root");

		mNodesList.push_back(b);

		S32 boneID = editorTree->insertItem(componentID, b->mBoneName);
		newItem = editorTree->getItem(boneID);

		newItem->mInspectorInfo.mObject = b;
		newItem->mState.set(GuiTreeViewCtrl::Item::ForceItemName);
		newItem->mState.set(GuiTreeViewCtrl::Item::InspectorData);
		newItem->mState.set(GuiTreeViewCtrl::Item::ForceDragTarget);
		newItem->mState.set(GuiTreeViewCtrl::Item::DenyDrag);*/

		//editorTree->buildVisibleTree(true);
	//}

}

void RenderShapeBehaviorInstance::onEndInspect()
{
	//mBehaviorOwner->removeObject(this);
}

DefineEngineMethod( RenderShapeBehaviorInstance, getShapeBounds, Box3F, (),,
   "@brief Get the cobject we're in contact with.\n\n"

   "The controlling client is the one that will send moves to us to act on.\n"

   "@return the ID of the controlling GameConnection, or 0 if this object is not "
   "controlled by any client.\n"
   
   "@see GameConnection\n")
{
	return object->getShapeBounds();
}

DefineEngineMethod( RenderShapeBehaviorInstance, mountObject, bool,
   ( SceneObject* objB, String node, TransformF txfm ), ( MatrixF::Identity ),
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
   if ( objB )
   {
	   //BUG: Unsure how it broke, but atm the default transform passed in here is rotated 180 degrees. This doesn't happen
	   //for the SceneObject mountobject method. Hackish, but for now, just default to a clean MatrixF::Identity
      object->mountObjectToNode( objB, node, /*MatrixF::Identity*/txfm.getMatrix() );
      return true;
   }
   return false;
}

DefineEngineMethod( RenderShapeBehaviorInstance, getNodeTransform, TransformF,
   ( S32 node ), ( -1 ),
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
   if ( node != -1 )
   {

	   //BUG: Unsure how it broke, but atm the default transform passed in here is rotated 180 degrees. This doesn't happen
	   //for the SceneObject mountobject method. Hackish, but for now, just default to a clean MatrixF::Identity
      //object->mountObjectToNode( objB, node, /*MatrixF::Identity*/txfm.getMatrix() );
		MatrixF mat = object->getNodeTransform(node);
      return mat;
   }

	return TransformF::Identity;
}

DefineEngineMethod( RenderShapeBehaviorInstance, getNodeEulerRot, EulerF,
   ( S32 node, bool radToDeg ), ( -1, true ),
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
   if ( node != -1 )
   {

	   //BUG: Unsure how it broke, but atm the default transform passed in here is rotated 180 degrees. This doesn't happen
	   //for the SceneObject mountobject method. Hackish, but for now, just default to a clean MatrixF::Identity
      //object->mountObjectToNode( objB, node, /*MatrixF::Identity*/txfm.getMatrix() );
		MatrixF mat = object->getNodeTransform(node);

		EulerF eul = mat.toEuler();
		if(radToDeg)
			eul = EulerF(mRadToDeg(eul.x), mRadToDeg(eul.y), mRadToDeg(eul.z));

		return eul;
   }

	return EulerF(0,0,0);
}

DefineEngineMethod( RenderShapeBehaviorInstance, getNodePosition, Point3F,
   ( S32 node ), ( -1 ),
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
   if ( node != -1 )
   {

	   //BUG: Unsure how it broke, but atm the default transform passed in here is rotated 180 degrees. This doesn't happen
	   //for the SceneObject mountobject method. Hackish, but for now, just default to a clean MatrixF::Identity
      //object->mountObjectToNode( objB, node, /*MatrixF::Identity*/txfm.getMatrix() );
		MatrixF mat = object->getNodeTransform(node);

		return mat.getPosition();
   }

	return Point3F(0,0,0);
}

DefineEngineMethod( RenderShapeBehaviorInstance, getNodeByName, S32,
   ( String nodeName ),,
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
	if ( !nodeName.isEmpty() )
   {
	   //BUG: Unsure how it broke, but atm the default transform passed in here is rotated 180 degrees. This doesn't happen
	   //for the SceneObject mountobject method. Hackish, but for now, just default to a clean MatrixF::Identity
      //object->mountObjectToNode( objB, node, /*MatrixF::Identity*/txfm.getMatrix() );
		S32 node = object->getNodeByName(nodeName);

		return node;
   }

	return -1;
}