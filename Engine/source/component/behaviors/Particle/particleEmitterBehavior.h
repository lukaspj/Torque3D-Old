//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
#ifndef _PARTICLE_EMITTER_BEHAVIOR_H_
#define _PARTICLE_EMITTER_BEHAVIOR_H_

#ifndef _BEHAVIORTEMPLATE_H_
	#include "component/behaviors/behaviorTemplate.h"
#endif
#include "particle.h"

//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class ParticleEmitterBehavior : public BehaviorTemplate
{
   typedef BehaviorTemplate Parent;

public:
   ParticleEmitterBehavior();
   virtual ~ParticleEmitterBehavior();
   DECLARE_CONOBJECT(ParticleEmitterBehavior);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   //override to pass back a ExampleBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class ParticleEmitterBehaviorInstance : public BehaviorInstance, public UpdateInterface
{
   typedef BehaviorInstance Parent;

public:
   ParticleEmitterBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~ParticleEmitterBehaviorInstance();
   DECLARE_CONOBJECT(ParticleEmitterBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual void onBehaviorAdd();
   virtual void onBehaviorRemove();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);
   
   virtual void processTick(const Move* move);
   virtual void advanceTime(F32 dt);

private:
   bool mDead;

   U32 mLifetimeMS;
   U32 mElapsedTimeMS;
   U32 mNextParticleTime;
   U32 mInternalClock;
   Point3F mLastPosition;
   bool mHasLastPosition;
   U32 mEjectionPeriodMS;
   U32 mPeriodVarianceMS;
   bool mOverrideAdvance;
   static Point3F mWindVelocity;
   S32 mPartListInitSize;
   U32 mPartLifetimeMS;
   U32 mPartLifetimeVarianceMS;

   void updateBBox() {};
   void emitParticles(const Point3F& point,
                        const Point3F& axis,
                        const Point3F& velocity,
                        const U32      numMilliseconds);
   void allocPrimBuffer(S32 n_part_capacity);
   void addParticle(Point3F const& pos, Point3F const& axis, Point3F const& vel, Point3F const& axisx);
   void simulate(U32 ms);

   //   These members are for implementing a link-list of the active emitter 
   //   particles. Member part_store contains blocks of particles that can be
   //   chained in a link-list. Usually the first part_store block is large
   //   enough to contain all the particles but it can be expanded in emergency
   //   circumstances.
   Vector <Particle*> part_store;
   Particle*  part_freelist;
   Particle   part_list_head;
   S32        n_part_capacity;
   S32        n_parts;
   S32       mCurBuffSize;
};

#endif // _PARTICLE_EMITTER_BEHAVIOR_H_
