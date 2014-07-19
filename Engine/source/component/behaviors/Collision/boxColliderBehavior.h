//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#ifndef _BOX_COLLISION_BEHAVIOR_H_
#define _BOX_COLLISION_BEHAVIOR_H_
#include "component/behaviors/Collision/collisionBehavior.h"

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
#ifndef _Entity_H_
   #include "T3D/Entity.h"
#endif

#ifndef _RENDER_INTERFACES_H_
   #include "component/behaviors/render/renderInterfaces.h"
#endif

#ifndef _COLLISION_INTERFACES_H_
   #include "component/behaviors/collision/collisionInterfaces.h"
#endif

class TSShapeInstance;
class SceneRenderState;
class BoxColliderBehaviorInstance;
//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class bBoxConvex: public Convex
{
   Point3F getVertex(S32 v);
   void emitEdge(S32 v1,S32 v2,const MatrixF& mat,ConvexFeature* cf);
   void emitFace(S32 fi,const MatrixF& mat,ConvexFeature* cf);
public:
   //
   Point3F mCenter;
   VectorF mSize;

   bBoxConvex() { mType = BoxConvexType; }
   void init(SceneObject* obj) { mObject = obj; }

   Point3F support(const VectorF& v) const;
   void getFeatures(const MatrixF& mat,const VectorF& n, ConvexFeature* cf);
   void getPolyList(AbstractPolyList* list);
};


class BoxColliderBehavior : public CollisionBehavior
{
   typedef CollisionBehavior Parent;

public:
   BoxColliderBehavior();
   virtual ~BoxColliderBehavior();
   DECLARE_CONOBJECT(BoxColliderBehavior);

   static void initPersistFields();

   //override to pass back a BoxColliderBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class BoxColliderBehaviorInstance : public CollisionBehaviorInstance
{
   typedef CollisionBehaviorInstance Parent;

	//this exists pretty much solely so we can render stuff while in the editor. We're not really a render class, but being able to render
	//can be pretty important sometimes - like when editing
	class editorRenderInterface : public PrepRenderImageInterface
	{
		virtual void prepRenderImage( SceneRenderState *state )
		{
			BoxColliderBehaviorInstance *bI = reinterpret_cast<BoxColliderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				bI->prepRenderImage(state);
		}
	};

	class boxColInterface : public CollisionInterface
	{
		virtual bool checkCollisions( const F32 travelTime, Point3F *velocity, Point3F start )
		{
			BoxColliderBehaviorInstance *bI = reinterpret_cast<BoxColliderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->checkCollisions(travelTime, velocity, start);
			return false;
		}

		virtual CollisionList *getCollisionList()
		{
			BoxColliderBehaviorInstance *bI = reinterpret_cast<BoxColliderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->getCollisionList();
			return NULL;
		}

		virtual Collision *getCollision(S32 col)
		{
			BoxColliderBehaviorInstance *bI = reinterpret_cast<BoxColliderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->getCollision(col);
			return NULL;
		}
	};

	class boxConvexInterface : public BuildConvexInterface
	{
		virtual void buildConvex(const Box3F& box, Convex* convex)
		{
			BoxColliderBehaviorInstance *bI = reinterpret_cast<BoxColliderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				bI->buildConvex(box, convex);
		}
	};

	editorRenderInterface mEditorRenderInterface;
	boxColInterface mColInterface;
	boxConvexInterface mConvexInterface;

protected:
	Point3F colliderScale;

public:
   BoxColliderBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~BoxColliderBehaviorInstance();
   DECLARE_CONOBJECT(BoxColliderBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual void prepRenderImage( SceneRenderState *state );

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   virtual void onBehaviorRemove();
   virtual void onBehaviorAdd();

	virtual void registerInterfaces();
	virtual void unregisterInterfaces();

   void prepCollision();
   void _updatePhysics();

   virtual bool buildConvex(const Box3F& box, Convex* convex);
   virtual bool castRay(const Point3F &start, const Point3F &end, RayInfo* info);

   virtual bool updateCollisions(F32 time, VectorF vector, VectorF velocity);

   virtual void updateWorkingCollisionSet(const U32 mask);
};

#endif // _BEHAVIORTEMPLATE_H_
