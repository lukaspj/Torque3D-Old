//This is basically a helper file that has general-usage behavior interfaces for rendering
#ifndef _COLLISION_INTERFACES_H_
#define _COLLISION_INTERFACES_H_

#ifndef _BEHAVIORINTERFACE_H_
	#include "component/interfaces/behaviorInterface.h"
#endif

#ifndef _CONVEX_H_
   #include "collision/convex.h"
#endif

class CollisionInterface : public BehaviorInterface
{
public:
	virtual bool checkCollisions( const F32 travelTime, Point3F *velocity, Point3F start )=0;

	virtual CollisionList *getCollisionList()=0;

	virtual Collision *getCollision(S32 col)=0;
};

class BuildConvexInterface : public BehaviorInterface
{
public:
	virtual void buildConvex(const Box3F& box, Convex* convex)=0;
};

#endif