//This is basically a helper file that has general-usage behavior interfaces for rendering
#ifndef _PHYSICS_INTERFACES_H_
#define _PHYSICS_INTERFACES_H_

#ifndef _BEHAVIORINTERFACE_H_
	#include "component/interfaces/behaviorInterface.h"
#endif

class VelocityInterface : public BehaviorInterface
{
public:
	virtual VectorF getVelocity() = 0;
};

class ParticlePhysicsInterface : public BehaviorInterface
{
public:

   virtual Point3F getDragCoefficient() = 0;
   virtual F32 getWindCoefficient() = 0;
   virtual Point3F getGravityCoefficient() = 0;
};

#endif