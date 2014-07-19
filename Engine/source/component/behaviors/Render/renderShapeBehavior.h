//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#ifndef _RENDERSHAPEBEHAVIOR_H_
#define _RENDERSHAPEBEHAVIOR_H_

#ifndef _BEHAVIORTEMPLATE_H_
#include "component/behaviors/behaviorTemplate.h"
#endif
#ifndef _BEHAVIORINSTANCE_H_
#include "component/behaviors/behaviorInstance.h"
#endif

#ifndef __RESOURCE_H__
	#include "core/resource.h"
#endif
#ifndef _TSSHAPE_H_
	#include "ts/tsShape.h"
#endif
#ifndef _SCENERENDERSTATE_H_
   #include "scene/sceneRenderState.h"
#endif
#ifndef _MBOX_H_
   #include "math/mBox.h"
#endif
#ifndef _ACTOR_H_
   #include "T3D/Entity.h"
#endif
/*#ifndef _PATH_H_
#include "core/util/path.h"
#endif*/

/*#ifndef _STOCK_INTERFACES_H_
   #include "component/behaviors/stockInterfaces.h"
#endif*/

#ifndef _RENDER_INTERFACES_H_
	#include "component/behaviors/Render/renderInterfaces.h"
#endif

class TSShapeInstance;
class SceneRenderState;
//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class RenderShapeBehavior : public BehaviorTemplate
{
   typedef BehaviorTemplate Parent;

public:
   RenderShapeBehavior();
   virtual ~RenderShapeBehavior();
   DECLARE_CONOBJECT(RenderShapeBehavior);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   //override to pass back a RenderBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class RenderShapeBehaviorInstance : public BehaviorInstance
{
   typedef BehaviorInstance Parent;

   enum
   {
	   ShapeMask = Parent::NextFreeMask,
	   NextFreeMask = Parent::NextFreeMask << 1,
   };

   /*class geoInterface : public GeometryInterface
   {
		virtual Geometry* getGeometry()
		{
			RenderShapeBehaviorInstance *bI = reinterpret_cast<RenderShapeBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->getGeometry();
			return NULL;
		}
   };*/

   class renderInterface : public PrepRenderImageInterface
	{
		virtual void prepRenderImage( SceneRenderState *state )
		{
			RenderShapeBehaviorInstance *bI = reinterpret_cast<RenderShapeBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				bI->prepRenderImage(state);
		}
	};

	class shapeInterface : public TSShapeInstanceInterface
	{
		virtual TSShapeInstance* getShapeInstance()
		{
			RenderShapeBehaviorInstance *bI = reinterpret_cast<RenderShapeBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->getShape();
			return NULL;
		}
	};

	class inspectInterface : public EditorInspectInterface
	{
		virtual void onInspect()
		{
			RenderShapeBehaviorInstance *bI = reinterpret_cast<RenderShapeBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				bI->onInspect();
		}

		virtual void onEndInspect()
		{
			RenderShapeBehaviorInstance *bI = reinterpret_cast<RenderShapeBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				bI->onEndInspect();
		}
	};

	//geoInterface mGeometryInterface;
	renderInterface mRenderInterface;
	shapeInterface mShapeInterface;
	inspectInterface mInspectInterface;

protected:
   StringTableEntry		mShapeName;
   Resource<TSShape>		mShape;
   TSShapeInstance *		mShapeInstance;
   Box3F						mShapeBounds;
	Point3F					mCenterOffset;

	class boneObject : public SimGroup
	{
		RenderShapeBehaviorInstance *mOwner;
	public:
		boneObject(RenderShapeBehaviorInstance *owner){ mOwner = owner;}

		StringTableEntry mBoneName;
		S32 mItemID;

		virtual void addObject(SimObject *obj);
	};

	Vector<boneObject*> mNodesList;

public:
   RenderShapeBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~RenderShapeBehaviorInstance();
   DECLARE_CONOBJECT(RenderShapeBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

	virtual void inspectPostApply();

   virtual void prepRenderImage(SceneRenderState *state );

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   Box3F getShapeBounds() { return mShapeBounds; }

	MatrixF getNodeTransform(S32 nodeIdx);
	S32 getNodeByName(String nodeName);

   void updateShape();
   virtual void onBehaviorRemove();
   virtual void onBehaviorAdd();

   static bool _setShape( void *object, const char *index, const char *data );
	const char* _getShape( void *object, const char *data );

   TSShapeInstance* getShape() { return mShapeInstance; }
	void _onResourceChanged( const Torque::Path &path );

   virtual bool castRayRendered(const Point3F &start, const Point3F &end, RayInfo *info);

   void mountObjectToNode(SceneObject* objB, String node, MatrixF txfm);

   //virtual Geometry* getGeometry();

	virtual void onInspect();
	virtual void onEndInspect();
};

#endif // _BEHAVIORTEMPLATE_H_
