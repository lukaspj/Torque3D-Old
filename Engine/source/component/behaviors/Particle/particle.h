#ifndef _PARTICLE_H_
#define _PARTICLE_H_
#include <platform/typesWin32.h>
#include <math/mPoint3.h>

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

#endif