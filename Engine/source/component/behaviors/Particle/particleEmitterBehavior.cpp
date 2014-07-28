//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
#include "console/consoleTypes.h"
#include "particleEmitterBehavior.h"
#include "core/util/safeDelete.h"
#include "console/consoleTypes.h"
#include "console/consoleObject.h"
#include "core/stream/bitStream.h"
#include "console/engineAPI.h"
#include "sim/netConnection.h"
#include <T3D/gameBase/gameProcess.h>
#include <component/behaviors/Physics/physicsInterfaces.h>
#include <T3D/fx/particleEmitter.h>

//////////////////////////////////////////////////////////////////////////
// Constructor/Destructor
//////////////////////////////////////////////////////////////////////////

ParticleEmitterBehavior::ParticleEmitterBehavior()
{
	mNetFlags.set(Ghostable | ScopeAlways);
   
	mFriendlyName = "Particle Emission";
   mBehaviorType = "Particle";

	mDescription = getDescriptionText("Causes the object to emit particles.");

	mNetworked = true;

   setScopeAlways();
}

ParticleEmitterBehavior::~ParticleEmitterBehavior()
{
   for(S32 i = 0;i < mFields.size();++i)
   {
      BehaviorField &field = mFields[i];
      SAFE_DELETE_ARRAY(field.mFieldDescription);
   }

   SAFE_DELETE_ARRAY(mDescription);
}

IMPLEMENT_CO_NETOBJECT_V1(ParticleEmitterBehavior);

//////////////////////////////////////////////////////////////////////////
BehaviorInstance *ParticleEmitterBehavior::createInstance()
{
   ParticleEmitterBehaviorInstance *instance = new ParticleEmitterBehaviorInstance(this);

   setupFields( instance );

   if(instance->registerObject())
      return instance;

   delete instance;
   return NULL;
}

bool ParticleEmitterBehavior::onAdd()
{
   if(! Parent::onAdd())
      return false;

   return true;
}

void ParticleEmitterBehavior::onRemove()
{
   Parent::onRemove();
}
void ParticleEmitterBehavior::initPersistFields()
{
   Parent::initPersistFields();
}

U32 ParticleEmitterBehavior::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);
	return retMask;
}

void ParticleEmitterBehavior::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);
}

//==========================================================================================
//==========================================================================================

static const F32 sgDefaultConstantAcceleration = 0.f;
static const F32 sgDefaultSpinSpeed = 1.f;
static const F32 sgDefaultSpinRandomMin = 0.f;
static const F32 sgDefaultSpinRandomMax = 0.f;

ParticleEmitterBehaviorInstance::ParticleEmitterBehaviorInstance( BehaviorTemplate *btemplate ) 
{
   mTemplate = btemplate;
   mBehaviorOwner = NULL;
   
   mDead = false;

   mLifetimeMS = 0;
   mElapsedTimeMS = 0;
   mNextParticleTime = 0;
   mInternalClock = 0;
   mLastPosition.set(0, 0, 0);
   mHasLastPosition = false;
   mEjectionPeriodMS = 100;
   mPeriodVarianceMS = 0;
   mOverrideAdvance = false;
   mPartLifetimeMS = 1000;
   mPartLifetimeVarianceMS = 0;
   mInheritedVelFactor   = 0.0f;
   mConstantAcceleration = sgDefaultConstantAcceleration;
   mSpinSpeed            = sgDefaultSpinSpeed;
   mSpinRandomMin        = sgDefaultSpinRandomMin;
   mSpinRandomMax        = sgDefaultSpinRandomMax;

   // Max lifetime divided by minimum time between each emitted particle.
   U32 partListInitSize = (mPartLifetimeMS + mPartLifetimeVarianceMS) / (mEjectionPeriodMS - mPeriodVarianceMS);
   partListInitSize += 8; // add 8 as "fudge factor" to make sure it doesn't realloc if it goes over by 1
   mParticlePool = ParticlePool(partListInitSize);

   mNetFlags.set(Ghostable);
}

ParticleEmitterBehaviorInstance::~ParticleEmitterBehaviorInstance()
{
}
IMPLEMENT_CO_NETOBJECT_V1(ParticleEmitterBehaviorInstance);

bool ParticleEmitterBehaviorInstance::onAdd()
{
   if(! Parent::onAdd())
      return false;

   return true;
}

void ParticleEmitterBehaviorInstance::onRemove()
{
   Parent::onRemove();
}

//This is mostly a catch for situations where the behavior is re-added to the object and the like and we may need to force an update to the behavior
void ParticleEmitterBehaviorInstance::onBehaviorAdd()
{
   Parent::onBehaviorAdd();
}

void ParticleEmitterBehaviorInstance::onBehaviorRemove()
{
   Parent::onBehaviorRemove();
}

void ParticleEmitterBehaviorInstance::registerInterfaces()
{
   Parent::registerInterfaces();
	mBehaviorOwner->registerCachedInterface( "particle", "simulation", this, &mParticleSimulationInterface );
}

void ParticleEmitterBehaviorInstance::unregisterInterfaces()
{
   Parent::unregisterInterfaces();
	mBehaviorOwner->removeCachedInterface( "particle", "simulation", this );
}

void ParticleEmitterBehaviorInstance::initPersistFields()
{
   Parent::initPersistFields();
}

U32 ParticleEmitterBehaviorInstance::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);
	return retMask;
}

void ParticleEmitterBehaviorInstance::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);
}

void ParticleEmitterBehaviorInstance::processTick(Move const* move)
{
   /*if( mDeleteOnTick == true )
   {
      mDead = true;
      deleteObject();
   }*/
}

void ParticleEmitterBehaviorInstance::advanceTime(F32 dt)
{
   if( dt < 0.00001 ) return;

   Parent::advanceTime(dt);

   if( dt > 0.5 ) dt = 0.5;

   if( mDead ) return;

   mElapsedTimeMS += (S32)(dt * 1000.0f);

   U32 numMSToUpdate = (U32)(dt * 1000.0f);
   if( numMSToUpdate == 0 ) return;

   // TODO: Prefetch

   mParticlePool.AdvanceTime(numMSToUpdate);

//   if(!mActive)
//      return;

   Point3F emitPoint, emitVelocity;
   Point3F emitAxis(0, 0, 1);
   getBehaviorOwner()->getTransform().mulV(emitAxis);
   getBehaviorOwner()->getTransform().getColumn(3, &emitPoint);
   emitVelocity = emitAxis * getBehaviorOwner()->getVelocity();

   emitParticles(emitPoint,
                  emitAxis,
                  emitVelocity, (U32)(dt * 1000.0f));

   /*if (n_parts < 1 && mDeleteWhenEmpty)
   {
      mDeleteOnTick = true;
      return;
   }*/

   if( numMSToUpdate != 0 && mParticlePool.getCount() > 0 )
   {
      simulate( numMSToUpdate );
   }
}

void ParticleEmitterBehaviorInstance::emitParticles(const Point3F& point,
                                                      const Point3F& axis,
                                                      const Point3F& velocity,
                                                      const U32      numMilliseconds)
{
   if( mDead ) return;
   
   //if( mParticleDataBlocks.empty() )
   //   return;

   // lifetime over - no more particles
   if( mLifetimeMS > 0 && mElapsedTimeMS > mLifetimeMS )
   {
      return;
   }

   U32 currTime = 0;
   bool particlesAdded = false;

   Point3F axisx;
   if( mFabs(axis.z) < 0.9f )
      mCross(axis, Point3F(0, 0, 1), &axisx);
   else
      mCross(axis, Point3F(0, 1, 0), &axisx);
   axisx.normalize();

   if( mNextParticleTime != 0 )
   {
      // Need to handle next particle
      //
      if( mNextParticleTime > numMilliseconds )
      {
         // Defer to next update
         //  (Note that this introduces a potential spatial irregularity if the owning
         //   object is accelerating, and updating at a low frequency)
         //
         mNextParticleTime -= numMilliseconds;
         mInternalClock += numMilliseconds;
         mLastPosition = point;
         mHasLastPosition = true;
         return;
      }
      else
      {
         currTime       += mNextParticleTime;
         mInternalClock += mNextParticleTime;
         // Emit particle at curr time

         // Create particle at the correct position
         addParticle(point, axis, velocity, axisx);
         particlesAdded = true;
         mNextParticleTime = 0;
      }
   }

   while( currTime < numMilliseconds )
   {
      S32 nextTime = mEjectionPeriodMS;
      if( mPeriodVarianceMS != 0 )
      {
         nextTime += S32(gRandGen.randI() % (2 * mPeriodVarianceMS + 1)) -
                     S32(mPeriodVarianceMS);
      }
      AssertFatal(nextTime > 0, "Error, next particle ejection time must always be greater than 0");

      if( currTime + nextTime > numMilliseconds )
      {
         mNextParticleTime = (currTime + nextTime) - numMilliseconds;
         mInternalClock   += numMilliseconds - currTime;
         AssertFatal(mNextParticleTime > 0, "Error, should not have deferred this particle!");
         break;
      }

      currTime       += nextTime;
      mInternalClock += nextTime;

      // Create particle at the correct position
      addParticle(point, axis, velocity, axisx);
      particlesAdded = true;

      //   This override-advance code is restored in order to correctly adjust
      //   animated parameters of particles allocated within the same frame
      //   update. Note that ordering is important and this code correctly 
      //   adds particles in the same newest-to-oldest ordering of the link-list.
      //
      // NOTE: We are assuming that the just added particle is at the head of our
      //  list.  If that changes, so must this...
      U32 advanceMS = numMilliseconds - currTime;
      if (mOverrideAdvance == false && advanceMS != 0) 
      {
         Particle* last_part = mParticlePool.GetParticleHead()->next;
         if (advanceMS > last_part->totalLifetime) 
         {
            mParticlePool.RemoveParticle(mParticlePool.GetParticleHead());
         } 
         else 
         {
            if (advanceMS != 0)
            {
              ParticlePhysicsInterface* physics = getBehaviorOwner()->getInterface<ParticlePhysicsInterface>();
              if(physics)
              {
                 F32 t = F32(advanceMS) / 1000.0;
                 Point3F a = last_part->acc;
                 a -= last_part->vel * physics->getDragCoefficient();
                 // For some reason the WindManager sets the wind velocity here...
                 //  - Precipitation also gets the wind velocity this way.
                 a -= ParticleEmitter::mWindVelocity * physics->getWindCoefficient();
                 a += Point3F(0.0f, 0.0f, -9.81f) * physics->getGravityCoefficient();

                 last_part->vel += a * t;
                 last_part->pos += last_part->vel * t;
              }
            }
         }
      }
   }

   // DMMFIX: Lame and slow...
   if( particlesAdded == true )
      updateBBox();

   mLastPosition = point;
   mHasLastPosition = true;
}

//-----------------------------------------------------------------------------
// addParticle
//-----------------------------------------------------------------------------
void ParticleEmitterBehaviorInstance::addParticle(const Point3F& pos,
                                                    const Point3F& axis,
                                                    const Point3F& vel,
                                                    const Point3F& axisx)
{
   Particle* pNew;
   mParticlePool.AddParticle(pNew);
   //if(mParticlePool.AddParticle(pNew))
      //allocPrimBuffer(mParticlePool.getCapacity()); // allocate larger primitive buffer or will crash 

   pNew->pos = pos;
   pNew->vel = Point3F(0,0,0);
   pNew->orientDir = Point3F(0,0,1);
   pNew->acc.set(0, 0, 0);
   pNew->currentAge = 0;

   // Calculate the constant accleration...
   pNew->vel += vel * mInheritedVelFactor;
   pNew->acc  = pNew->vel * mConstantAcceleration;

   // Calculate this instance's lifetime...
   pNew->totalLifetime = mPartLifetimeMS;
   if (mPartLifetimeVarianceMS != 0)
      pNew->totalLifetime += S32(gRandGen.randI() % (2 * mPartLifetimeVarianceMS + 1)) - S32(mPartLifetimeVarianceMS);
   // assign spin amount
   pNew->spinSpeed = mSpinSpeed * gRandGen.randF( mSpinRandomMin, mSpinRandomMax );
}

void ParticleEmitterBehaviorInstance::simulate(U32 ms)
{
   // TODO: Prefetch

   for (Particle* part = mParticlePool.GetParticleHead()->next; part != NULL; part = part->next)
   {
      F32 t = F32(ms) / 1000.0;

      Point3F a = part->acc;
      part->vel += a * t;
      part->pos += part->vel * t;
   }
}