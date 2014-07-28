#ifndef _EMITTER_INTERFACES_H_
#define _EMITTER_INTERFACES_H_

#ifndef _BEHAVIORINTERFACE_H_
	#include "component/interfaces/behaviorInterface.h"
#endif

#include "particle.h"

class ParticleSimulationInterface : public BehaviorInterface
{
public:

   virtual ParticlePool getPool() = 0;
   virtual Point3F getLastPosition() = 0;
};

#endif