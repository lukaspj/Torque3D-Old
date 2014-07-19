//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#ifndef _COLLISIONBEHAVIOR_H_
#define _COLLISIONBEHAVIOR_H_
#include "component/behaviors/behaviorTemplate.h"

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
#ifndef _ENTITY_H_
   #include "T3D/Entity.h"
#endif
#ifndef _CONVEX_H_
   #include "collision/convex.h"
#endif
#ifndef _BOXCONVEX_H_
#include "collision/boxConvex.h"
#endif
#ifndef _RIGID_H_
#include "T3D/rigid.h"
#endif

#ifndef _RENDER_INTERFACES_H_
#include "component/behaviors/Render/renderInterfaces.h"
#endif

#ifndef _COLLISION_INTERFACES_H_
#include "component/behaviors/Collision/collisionInterfaces.h"
#endif

#ifndef _STOCK_INTERFACES_H_
   #include "component/behaviors/stockInterfaces.h"
#endif

//class TSShapeInstance;
class SceneRenderState;
class CollisionBehaviorInstance;
//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
struct ContactInfo 
{
  bool contacted, move;
  SceneObject *contactObject;
  VectorF  contactNormal;
  Point3F  contactPoint;
  F32	   contactTime;
  S32	   contactTimer;

  void clear()
  {
     contacted=move=false; 
     contactObject = NULL; 
     contactNormal.set(0,0,0);
	 contactTime = 0.f;
	 contactTimer = 0;
  }

  ContactInfo() { clear(); }

};

/*class CollisionInterface : public BehaviorInterface
{
public:
	virtual bool checkCollisions( const F32 travelTime, Point3F *velocity, Point3F start )=0;
	virtual CollisionList *getCollisionList()=0;
	virtual Collision *getCollision(S32 col)=0;
};*/

class CollisionBehavior : public BehaviorTemplate
{
   typedef BehaviorTemplate Parent;

public:
   CollisionBehavior();
   virtual ~CollisionBehavior();
   DECLARE_CONOBJECT(CollisionBehavior);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   //override to pass back a StaticCollisionBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class CollisionBehaviorInstance : public BehaviorInstance
{
   typedef BehaviorInstance Parent;

   struct CollisionBehaviorInterface : public CollisionInterface
   {
		inline bool checkCollisions( const F32 travelTime, Point3F *velocity, Point3F start )
		{
			CollisionBehaviorInstance *bI = reinterpret_cast<CollisionBehaviorInstance*>(getOwner());
			if(bI)
				return bI->checkCollisions(travelTime, velocity, start);
		}

		inline CollisionList *getCollisionList()
		{
			CollisionBehaviorInstance *bI = reinterpret_cast<CollisionBehaviorInstance*>(getOwner());
			if(bI)
				return bI->getCollisionList();
		}

		inline Collision *getCollision(S32 col) 
		{ 
			CollisionBehaviorInstance *bI = reinterpret_cast<CollisionBehaviorInstance*>(getOwner());
			if(bI)
				return bI->getCollision(col);
		}
   };

   CollisionBehaviorInterface mCollisionInterface;

protected:
	Convex *mConvexList;
	F32 mCollisionTol;
	F32 mContactTol;


	U32 sClientCollisionContactMask;
	U32 sServerCollisionContactMask;
	U32 CollisionMoveMask;
	S32 sMoveRetryCount;
	F32 sNormalElasticity;

	bool mBlockColliding;

public:
   struct CollisionTimeout 
   {
      CollisionTimeout* next;
      SceneObject* object;
      U32 objectNumber;
      SimTime expireTime;
      VectorF vector;
   };
   CollisionTimeout* mTimeoutList;
   static CollisionTimeout* sFreeTimeoutList;

   enum PublicConstants { 
	   CollisionTimeoutValue = 250
   };

   CollisionList mCollisionList;

   Box3F         mWorkingQueryBox;

   CollisionBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~CollisionBehaviorInstance();
   DECLARE_CONOBJECT(CollisionBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   virtual void processTick(const Move* move);

   virtual void onBehaviorAdd();
   virtual void onBehaviorRemove();

   Convex *getConvexList() { return mConvexList; }

   CollisionList *getCollisionList() { return &mCollisionList; }

   Collision *getCollision(S32 col) { if(col < mCollisionList.getCount() && col >= 0) return &mCollisionList[col];
										 else return NULL; }

   virtual bool castRay(const Point3F &start, const Point3F &end, RayInfo* info){return false;}
   virtual bool castRayRendered(const Point3F &start, const Point3F &end, RayInfo *info){return false;}

   virtual bool buildPolyList(PolyListContext context, AbstractPolyList* polyList, const Box3F &box, const SphereF &){return false;}
   virtual bool buildConvex(const Box3F& box, Convex* convex){return false;}

   void queueCollision( SceneObject *obj, const VectorF &vec);
   //void notifyCollision();
   virtual void updateWorkingCollisionSet(const U32 mask){return;}

   virtual void prepRenderImage( SceneRenderState *state ){}

   //
   void handleCollision( Collision &col, VectorF velocity );
   void handleCollisionList( CollisionList &colList, VectorF velocity );
   //virtual bool updateCollisions(VectorF velocity, Vector<SceneObject*> *outOverlapObjects);
   virtual bool updateCollisions(F32 time, VectorF vector, VectorF velocity){return false;}

   //Regular progressive collision hooks
   void findContact( bool *run, VectorF *contactNormal );
   Point3F scanCollision( const F32 travelTime, Point3F *velocity/*, Collision *outCol*/ );
   bool checkEarlyOut(Point3F start, VectorF velocity, F32 time);
   bool checkCollisions( const F32 travelTime, Point3F *velocity, Point3F start );

   virtual bool resolveContacts(CollisionList& cList, VectorF velocity, F32 dt){return false;}
   virtual bool resolveCollision(CollisionList& cList, VectorF velocity){return false;}

   //Callbacks
   DECLARE_CALLBACK( void, onCollision, ( BehaviorInstance* obj, SceneObject* collObj, VectorF vec, F32 len ) );
   DECLARE_CALLBACK( void, onRaycastCollision, ( BehaviorInstance* obj, SceneObject* collObj, Point3F pos, Point3F normal ) );
   DECLARE_CALLBACK( void, onContact, ( BehaviorInstance* obj, SceneObject* collObj ) );
};

#endif // _BEHAVIORTEMPLATE_H_
