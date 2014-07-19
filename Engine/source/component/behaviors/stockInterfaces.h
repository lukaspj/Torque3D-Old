#ifndef _STOCK_INTERFACES_H_
#define _STOCK_INTERFACES_H_

#ifndef _SCENERENDERSTATE_H_
   #include "scene/sceneRenderState.h"
#endif
#ifndef _BEHAVIORINTERFACE_H_
	#include "component/behaviorInterface.h"
#endif
/*#ifndef _GEOMETRY_H_
	#include "math/mGeometry.h"
#endif*/

//Basically a file for generic interfaces that many behaviors may make use of
class SetTransformInterface : public BehaviorInterface
{
public:
   virtual void setTransform( MatrixF transform );
   virtual void setTransform( Point3F pos, EulerF rot );
   //void setTransform( TransformF transform );
};

class UpdateInterface : public BehaviorInterface
{
public:
	virtual void processTick(const Move* move){}
	virtual void interpolateTick(F32 dt){}
	virtual void advanceTime(F32 dt){}
};

class BehaviorFieldInterface : public BehaviorInterface
{
public:
	virtual void onFieldChange(const char* fieldName, const char* newValue){};
};

class CameraInterface : public BehaviorInterface
{
public:
	virtual bool getCameraTransform(F32* pos,MatrixF* mat)=0;
};

class CastRayInterface : public BehaviorInterface
{
public:
	virtual bool castRay(const Point3F &start, const Point3F &end, RayInfo* info)=0;
};

class EditorInspectInterface : public BehaviorInterface
{
public:
	virtual void onInspect()=0;
	virtual void onEndInspect()=0;
};

#endif