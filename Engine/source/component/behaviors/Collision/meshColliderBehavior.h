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

#ifndef _SCENERENDERSTATE_H_
   #include "scene/sceneRenderState.h"
#endif
#ifndef _RENDERPASSMANAGER_H_
   #include "renderInstance/renderPassManager.h"
#endif

class TSShapeInstance;
class SceneRenderState;
class MeshColliderBehaviorInstance;
//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class MeshColliderPolysoupConvex : public Convex
{
   typedef Convex Parent;
   friend class MeshColliderBehaviorInstance;

public:
   MeshColliderPolysoupConvex();
   ~MeshColliderPolysoupConvex() {};

public:
   Box3F                box;
   Point3F              verts[4];
   PlaneF               normal;
   S32                  idx;
   TSMesh               *mesh;

   static SceneObject* smCurObject;
	static TSShapeInstance* smCurShapeInstance;

	Convex* mNext;

public:

	void init(SceneObject* obj) { mObject = obj; }

   // Returns the bounding box in world coordinates
   Box3F getBoundingBox() const;
   Box3F getBoundingBox(const MatrixF& mat, const Point3F& scale) const;

   void getFeatures(const MatrixF& mat,const VectorF& n, ConvexFeature* cf);

   // This returns a list of convex faces to collide against
   void getPolyList(AbstractPolyList* list);

	// Renders the convex list. Used for debugging
	virtual void render();

	// This returns all the polies in our convex list
	// It's really meant for debugging purposes
	void getAllPolyList(AbstractPolyList *list);

   // This returns the furthest point from the input vector
   Point3F support(const VectorF& v) const;
};

class MeshColliderBehavior : public CollisionBehavior
{
   typedef CollisionBehavior Parent;

public:
   MeshColliderBehavior();
   virtual ~MeshColliderBehavior();
   DECLARE_CONOBJECT(MeshColliderBehavior);

   static void initPersistFields();

   //override to pass back a MeshColliderBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class MeshColliderBehaviorInstance : public CollisionBehaviorInstance
{
   typedef CollisionBehaviorInstance Parent;

	class editorRenderInterface : public PrepRenderImageInterface
	{
		virtual void prepRenderImage( SceneRenderState *state )
		{
			MeshColliderBehaviorInstance *bI = reinterpret_cast<MeshColliderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				bI->prepRenderImage(state);
		}
	};

	class boxColInterface : public CollisionInterface
	{
		virtual bool checkCollisions( const F32 travelTime, Point3F *velocity, Point3F start )
		{
			MeshColliderBehaviorInstance *bI = reinterpret_cast<MeshColliderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->checkCollisions(travelTime, velocity, start);
			return false;
		}

		virtual CollisionList *getCollisionList()
		{
			MeshColliderBehaviorInstance *bI = reinterpret_cast<MeshColliderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->getCollisionList();
			return NULL;
		}

		virtual Collision *getCollision(S32 col)
		{
			MeshColliderBehaviorInstance *bI = reinterpret_cast<MeshColliderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->getCollision(col);
			return NULL;
		}
	};

	class boxConvexInterface : public BuildConvexInterface
	{
		virtual void buildConvex(const Box3F& box, Convex* convex)
		{
			MeshColliderBehaviorInstance *bI = reinterpret_cast<MeshColliderBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				bI->buildConvex(box, convex);
		}
	};

	editorRenderInterface mEditorRenderInterface;
	boxColInterface mColInterface;
	boxConvexInterface mConvexInterface;

protected:
	Convex *mConvexList;

	Vector<S32> mCollisionDetails;

public:
   MeshColliderBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~MeshColliderBehaviorInstance();
   DECLARE_CONOBJECT(MeshColliderBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

	virtual void registerInterfaces();
	virtual void unregisterInterfaces();

	virtual void update();

   virtual void prepRenderImage( SceneRenderState *state );
	virtual void renderConvex( ObjectRenderInst *ri, SceneRenderState *state, BaseMatInstance *overrideMat );

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   virtual void onBehaviorRemove();
   virtual void onBehaviorAdd();

   void prepCollision();
   void _updatePhysics();

   virtual bool buildConvex(const Box3F& box, Convex* convex);
   virtual bool castRay(const Point3F &start, const Point3F &end, RayInfo* info);

	bool buildConvexOpcode( TSShapeInstance* sI, S32 dl, const Box3F &bounds, Convex *c, Convex *list );

	bool buildMeshOpcode(  TSShapeInstance::MeshObjectInstance *meshInstance, const MatrixF &meshToObjectMat, 
																				S32 objectDetail, const Box3F &bounds, Convex *convex, Convex *list);

   virtual bool updateCollisions(F32 time, VectorF vector, VectorF velocity);

   virtual void updateWorkingCollisionSet(const U32 mask);

	TSShapeInstance* getShapeInstance();
};

#endif // _BEHAVIORTEMPLATE_H_
