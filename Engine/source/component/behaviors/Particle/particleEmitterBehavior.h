//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
#ifndef _PARTICLE_EMITTER_BEHAVIOR_H_
#define _PARTICLE_EMITTER_BEHAVIOR_H_

#ifndef _BEHAVIORTEMPLATE_H_
	#include "component/behaviors/behaviorTemplate.h"
#endif
#include "component/behaviors/Particle/particle.h"
#include <component/behaviors/Particle/particleInterfaces.h>

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

class ParticleEmitterBehaviorInstance : public BehaviorInstance
{
   typedef BehaviorInstance Parent;

   class particleSimulationInterface : public ParticleSimulationInterface
   {
   public:
      virtual ParticlePool getPool()
      {
			ParticleEmitterBehaviorInstance *bI = reinterpret_cast<ParticleEmitterBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->getPool();
         return ParticlePool();
      };
      virtual Point3F getLastPosition()
      {
			ParticleEmitterBehaviorInstance *bI = reinterpret_cast<ParticleEmitterBehaviorInstance*>(getOwner());
			if(bI && bI->isEnabled())
				return bI->getLastPosition();
         return Point3F::One;
      };
   };

   particleSimulationInterface mParticleSimulationInterface;

   ParticlePool getPool()
   {
      return mParticlePool;
   };

   Point3F getLastPosition()
   {
      return mLastPosition;
   };

public:
   ParticleEmitterBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~ParticleEmitterBehaviorInstance();
   DECLARE_CONOBJECT(ParticleEmitterBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual void onBehaviorAdd();
   virtual void onBehaviorRemove();

   void registerInterfaces();
   void unregisterInterfaces();

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
   S32 mPartListInitSize;
   U32 mPartLifetimeMS;
   U32 mPartLifetimeVarianceMS;
   F32 mSpinSpeed;
   F32 mSpinRandomMin;
   F32 mSpinRandomMax;
   F32 mConstantAcceleration;
   F32 mInheritedVelFactor;

   void updateBBox() {};
   void emitParticles(const Point3F& point,
                        const Point3F& axis,
                        const Point3F& velocity,
                        const U32      numMilliseconds);
   void addParticle(Point3F const& pos, Point3F const& axis, Point3F const& vel, Point3F const& axisx);
   void simulate(U32 ms);

   ParticlePool mParticlePool;
};

#endif // _PARTICLE_EMITTER_BEHAVIOR_H_
