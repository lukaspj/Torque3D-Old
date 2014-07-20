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
#include <T3D/fx/particle.h>
#include <T3D/gameBase/gameProcess.h>
#include <component/behaviors/Physics/physicsInterfaces.h>

//////////////////////////////////////////////////////////////////////////
// Constructor/Destructor
//////////////////////////////////////////////////////////////////////////

ParticleEmitterBehavior::ParticleEmitterBehavior()
{
	mNetFlags.set(Ghostable | ScopeAlways);
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
ParticleEmitterBehaviorInstance::ParticleEmitterBehaviorInstance( BehaviorTemplate *btemplate ) 
{
   mTemplate = btemplate;
   mBehaviorOwner = NULL;

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

   // remove dead particles
   Particle* last_part = &part_list_head;
   for (Particle* part = part_list_head.next; part != NULL; part = part->next)
   {
     part->currentAge += numMSToUpdate;
     if (part->currentAge > part->totalLifetime)
     {
       n_parts--;
       last_part->next = part->next;
       part->next = part_freelist;
       part_freelist = part;
       part = last_part;
     }
     else
     {
       last_part = part;
     }
   }

   AssertFatal( n_parts >= 0, "ParticleEmitter: negative part count!" );

   /*if (n_parts < 1 && mDeleteWhenEmpty)
   {
      mDeleteOnTick = true;
      return;
   }*/

   if( numMSToUpdate != 0 && n_parts > 0 )
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
         Particle* last_part = part_list_head.next;
         if (advanceMS > last_part->totalLifetime) 
         {
           part_list_head.next = last_part->next;
           n_parts--;
           last_part->next = part_freelist;
           part_freelist = last_part;
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
                 a -= mWindVelocity * physics->getWindCoefficient();
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
   n_parts++;
   if (n_parts > n_part_capacity || n_parts > mPartListInitSize)
   {
      // In an emergency we allocate additional particles in blocks of 16.
      // This should happen rarely.
      Particle* store_block = new Particle[16];
      part_store.push_back(store_block);
      n_part_capacity += 16;
      for (S32 i = 0; i < 16; i++)
      {
        store_block[i].next = part_freelist;
        part_freelist = &store_block[i];
      }
      allocPrimBuffer(n_part_capacity); // allocate larger primitive buffer or will crash 
   }
   Particle* pNew = part_freelist;
   part_freelist = pNew->next;
   pNew->next = part_list_head.next;
   part_list_head.next = pNew;

   pNew->pos = pos;
   pNew->vel = Point3F(0,0,0);
   pNew->orientDir = Point3F(0,0,1);
   pNew->acc.set(0, 0, 0);
   pNew->currentAge = 0;

   // Calculate this instance's lifetime...
   pNew->totalLifetime = mPartLifetimeMS;
   if (mPartLifetimeVarianceMS != 0)
      pNew->totalLifetime += S32(gRandGen.randI() % (2 * mPartLifetimeVarianceMS + 1)) - S32(mPartLifetimeVarianceMS);
}

void ParticleEmitterBehaviorInstance::simulate(U32 ms)
{
   // TODO: Prefetch

   for (Particle* part = part_list_head.next; part != NULL; part = part->next)
   {
      F32 t = F32(ms) / 1000.0;

      Point3F a = part->acc;
      part->vel += a * t;
      part->pos += part->vel * t;
   }
}