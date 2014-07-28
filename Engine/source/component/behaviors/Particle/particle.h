#ifndef _PARTICLE_H_
#define _PARTICLE_H_
#include <platform/types.h>
#include <math/mPoint3.h>
#include <core/util/tVector.h>

struct Particle
{
   Point3F  pos;     // current instantaneous position
   Point3F  vel;     //   "         "         velocity
   Point3F  acc;     // Constant acceleration
   Point3F  orientDir;  // direction particle should go if using oriented particles

   U32            totalLifetime;   // Total ms that this instance should be "live"

   U32            currentAge;
   F32            spinSpeed;
   Particle *     next;
};

class ParticlePool
{
public:
   ParticlePool();

   ParticlePool(U32 initSize);

   bool AddParticle(Particle*& part);
   void RemoveParticle(Particle* previousParticle);
   Particle* GetParticleHead() { return &part_list_head; };
   void AdvanceTime(U32 numMSToUpdate);
   S32 getCount() { return n_parts; }
   S32 getCapacity() { return n_part_capacity; }

private:

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
   S32 mPartListInitSize;
};
#endif