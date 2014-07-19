//This is basically a helper file that has general-usage behavior interfaces for rendering
#ifndef _RENDER_INTERFACES_H_
#define _RENDER_INTERFACES_H_

#ifndef _BEHAVIORINTERFACE_H_
	#include "component/interfaces/behaviorInterface.h"
#endif
#ifndef _TSSHAPE_H_
	#include "ts/TSShape.h"
#endif
#ifndef _TSSHAPEINSTANCE_H_
	#include "ts/TSShapeInstance.h"
#endif
/*#ifndef _GEOMETRY_H_
	#include "math/mGeometry.h"
#endif*/

class PrepRenderImageInterface : public BehaviorInterface
{
public:
	virtual void prepRenderImage(SceneRenderState *state )=0;
};

class TSShapeInterface : public BehaviorInterface
{
public:
	virtual TSShape* getShape()=0;
};

class TSShapeInstanceInterface : public BehaviorInterface
{
public:
	virtual TSShapeInstance* getShapeInstance()=0;
};

/*class GeometryInterface : public BehaviorInterface
{
public:
	virtual Geometry* getGeometry()=0;
};*/

class CastRayRenderedInterface : public BehaviorInterface
{
public:
	virtual bool castRayRendered(const Point3F &start, const Point3F &end, RayInfo* info)=0;
};

#endif