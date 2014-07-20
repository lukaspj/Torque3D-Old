//This is basically a helper file that has general-usage behavior interfaces for rendering
#ifndef _PHYSICS_INTERFACES_H_
#define _PHYSICS_INTERFACES_H_

#ifndef _BEHAVIORINTERFACE_H_
	#include "component/interfaces/behaviorInterface.h"
#endif

class VelocityInterface : public BehaviorInterface
{
public:
	virtual VectorF getVelocity()=0;
};

class ParticlePhysicsInterface : public BehaviorInterface
{
public:

   Point3F getDragCoefficient();
   F32 getWindCoefficient();
   Point3F getGravityCoefficient();
};

#endif