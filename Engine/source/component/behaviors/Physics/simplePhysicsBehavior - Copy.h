//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#ifndef _SIMPLE_PHYSICS_BEHAVIOR_H_
#define _SIMPLE_PHYSICS_BEHAVIOR_H_

#ifndef _PHYSICSBEHAVIOR_H_
#include "component/behaviors/Physics/physicsBehavior.h"
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
#ifndef _ENTITY_H_
   #include "T3D/Entity.h"
#endif
#ifndef _CONVEX_H_
   #include "collision/convex.h"
#endif
#ifndef _BOXCONVEX_H_
#include "collision/boxConvex.h"
#endif

#ifndef _PHYSICS_INTERFACES_H_
#include "component/behaviors/Physics/physicsInterfaces.h"
#endif

class SceneRenderState;
class PhysicsBody;
class SimplePhysicsBehaviorInstance;
//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class SimplePhysicsBehavior : public PhysicsBehavior
{
   typedef PhysicsBehavior Parent;

public:
   SimplePhysicsBehavior();
   virtual ~SimplePhysicsBehavior();
   DECLARE_CONOBJECT(SimplePhysicsBehavior);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   //override to pass back a StaticSimplePhysicsBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class SimplePhysicsBehaviorInstance : public PhysicsBehaviorInstance
{
   typedef PhysicsBehaviorInstance Parent;

	class velInterface : public VelocityInterface
	{
		virtual VectorF getVelocity()
		{
			SimplePhysicsBehaviorInstance *bI = reinterpret_cast<SimplePhysicsBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->getVelocity();
			return VectorF(0,0,0);
		}
	};

	velInterface mVelInterface;

protected:
   F32 mBuoyancy;
   F32 mFriction;
   F32 mElasticity;
   F32 mMaxVelocity;
   bool mSticky;

   U32 mIntegrationCount;

   Point3F moveSpeed;

   Point3F mStickyCollisionPos;
   Point3F mStickyCollisionNormal;

public:
   SimplePhysicsBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~SimplePhysicsBehaviorInstance();
   DECLARE_CONOBJECT(SimplePhysicsBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual void processTick(const Move* move);
   virtual void interpolateTick(F32 dt);
   virtual void updatePos(const F32 dt);
   void updateForces();

   void updateMove(const Move* move);
   Point3F _move( const F32 travelTime );

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   virtual void onBehaviorRemove();

	void registerInterfaces();
	void unregisterInterfaces();

   virtual void setVelocity(const VectorF& vel);

   //
   DECLARE_CALLBACK( void, updateMove, ( SimplePhysicsBehaviorInstance* obj ) );
};

#endif // _BEHAVIORTEMPLATE_H_
