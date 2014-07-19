//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

#include "platform/platform.h"
#include "T3D/Entity.h"
#include "core/stream/bitStream.h"
#include "console/consoleTypes.h"
#include "console/consoleObject.h"
#include "sim/netConnection.h"
#include "scene/sceneRenderState.h"
#include "scene/sceneManager.h"
#include "T3D/gameBase/gameProcess.h"
#include "console/engineAPI.h"
#include "T3D/gameBase/gameConnection.h"
#include "math/mathIO.h"
#include "component/behaviors/behaviorTemplate.h"
#include "math/mTransform.h"

#include "T3D/tagLibrary.h"

#include "Component/Behaviors/stockInterfaces.h"
#include "Component/Behaviors/Render/renderInterfaces.h"
#include "Component/Behaviors/Collision/collisionInterfaces.h"

#include "gui/controls/guiTreeViewCtrl.h"

#include "T3D/prefab.h"

extern bool gEditingMission;

namespace TagManager
{
	extern TagLibrary *gTagLibrary;
	extern void initTagLibrary();
}

IMPLEMENT_CO_NETOBJECT_V1(Entity);

ConsoleDocClass( Entity,
   "@brief Base Entity class.\n\n"

   "Entity is typically made up of a shape and up to two particle emitters.  In most cases Entity objects are "
   "not created directly.  They are usually produced automatically by other means, such as through the Explosion "
   "class.  When an explosion goes off, its ExplosionData datablock determines what Entity to emit.\n"
   
   "@tsexample\n"
   "datablock ExplosionData(GrenadeLauncherExplosion)\n"
   "{\n"
   "   // Assiging Entity data\n"
   "   Entity = GrenadeEntity;\n\n"
   "   // Adjust how Entity is ejected\n"
   "   EntityThetaMin = 10;\n"
   "   EntityThetaMax = 60;\n"
   "   EntityNum = 4;\n"
   "   EntityNumVariance = 2;\n"
   "   EntityVelocity = 25;\n"
   "   EntityVelocityVariance = 5;\n\n"
   "   // Note: other ExplosionData properties are not listed for this example\n"
   "};\n"
   "@endtsexample\n\n"

   "@note Entity are client side only objects.\n"

   "@see EntityData\n"
   "@see ExplosionData\n"
   "@see Explosion\n"

   "@ingroup FX\n"
);

Entity::Entity()
{
   mTypeMask |= DynamicShapeObjectType | StaticObjectType;
   mNetFlags.set(Ghostable | ScopeAlways);

   mPhysicsRep = NULL;

   mRot = Point3F(0,0,0);
}

Entity::~Entity()
{

}

void Entity::initPersistFields()
{
   Parent::initPersistFields();

   removeField("DataBlock");

   addGroup( "Transform" );
   addProtectedField( "eulerRotation", TypePoint3F, Offset( mRot, Entity ),
         &_setEulerRotation, &defaultProtectedGetFn,
         "Object world orientation." );
   endGroup( "Transform" );
}

//
bool Entity::_setEulerRotation( void *object, const char *index, const char *data )
{
   Entity* so = static_cast<Entity*>( object );
   if ( so )
   {
	  EulerF rot;
      Con::setData( TypePoint3F, &rot, 0, 1, &data );

		so->setRotation( rot );
   }
   return false;
}

/*const char *Entity::_getEulerRotation( void *object, const char *data )
//bool Entity::_getEulerRotation( void *object, const char *index, const char *data )
{
   Entity* so = static_cast<Entity*>( object );
   if ( so )
   {
	   EulerF rot;
      //Con::setData( TypePoint3F, &rot, 0, 1, &data );

		//so->setRotation( rot );



		AngAxisF aa(*(MatrixF *) dptr);
		aa.axis.normalize();
		char* returnBuffer = Con::getReturnBuffer(256);
		dSprintf(returnBuffer,256,"%g %g %g %g",aa.axis.x,aa.axis.y,aa.axis.z,mRadToDeg(aa.angle));
		return returnBuffer;
   }
   return false;
}*/

EulerF R2DEuler(EulerF eul)
{
	EulerF ret = EulerF(mRadToDeg(eul.x), mRadToDeg(eul.y), mRadToDeg(eul.z));
	return ret;
}

EulerF D2REuler(EulerF eul)
{
	EulerF ret = EulerF(mDegToRad(eul.x), mDegToRad(eul.y), mDegToRad(eul.z));
	return ret;
}

bool Entity::onAdd()
{
   if( !Parent::onAdd() )
      return false;

   mObjBox = Box3F(Point3F(-1, -1, -1), Point3F(1, 1, 1));

   resetWorldBox();
   setObjectBox(mObjBox);

   //setRenderTransform(mObjBox);

   mRot = R2DEuler(getTransform().toEuler());
   //mRot = EulerF(mRadToDeg(rot.x), mRadToDeg(rot.y), mRadToDeg(rot.z));

   addToScene();

	//When we add the entity on the server, we add it to the tagLibrary, if the tagLibrary hasn't been initialized yet, we do that now
	if(!TagManager::gTagLibrary)
		TagManager::initTagLibrary();

	//Once we know we have the tagLibrary, we register ourselves to it
	TagManager::gTagLibrary->addEntity(this);

   //Make sure we get positioned
   setMaskBits(TransformMask);

   return true;
}

void Entity::onRemove()
{
   clearBehaviors(true);
   removeFromScene();

   Parent::onRemove();
}

void Entity::pushEvent(const char* eventName, Vector<const char*> eventParams)
{
	//An event happened, pass it to all our behaviors so if they react to that, they do their thing
	for(U32 b=0; b < getBehaviorCount(); b++)
	{
		if(getBehavior(b)->isEnabled())
			getBehavior(b)->handleEvent(eventName, eventParams);
	}
}

//Updating
void Entity::processTick(const Move* move)
{
	if(!isHidden()) 
	{
		BehaviorInterfaceList iLst;

		if(getInterfaces( &iLst, NULL, "processTick", NULL))
		{
			// Lets process the list that we've gotten back, and find the interface that
			// we want.
			UpdateInterface *scQueriedInterface = NULL;

			for( BehaviorInterfaceListIterator i = iLst.begin(); i != iLst.end(); i++ )
			{
				scQueriedInterface = dynamic_cast<UpdateInterface *>( *i );

				if( scQueriedInterface != NULL )
					scQueriedInterface->processTick(move);
			}
		}
	
		if (isMounted()) 
		{
			MatrixF mat;
			//Use transform from mount
			mMount.object->getMountTransform(mMount.node,mMount.xfm,&mat);

			EulerF euRot = R2DEuler(mat.toEuler());
			mRot = euRot;

			Parent::setTransform(mat);
		}
	}
}

void Entity::advanceTime( F32 dt )
{
	if(!isHidden()) 
	{
		BehaviorInterfaceList iLst;

		if(getInterfaces( &iLst, NULL, "advanceTime", NULL))
		{
			// Lets process the list that we've gotten back, and find the interface that
			// we want.
			UpdateInterface *scQueriedInterface = NULL;

			for( BehaviorInterfaceListIterator i = iLst.begin(); i != iLst.end(); i++ )
			{
				scQueriedInterface = dynamic_cast<UpdateInterface *>( *i );

				if( scQueriedInterface != NULL )
					scQueriedInterface->advanceTime(dt);
			}
		}

		if(isMounted())
		{
		  MatrixF mat;
		  mMount.object->getRenderMountTransform( dt, mMount.node, mMount.xfm, &mat );

		  Parent::setTransform(mat);
		  Parent::setRenderTransform(mat);
		}
	}
}

void Entity::interpolateTick(F32 dt)
{
   Parent::interpolateTick(dt);

   if (isMounted()) {
      MatrixF mat;
      //Use transform from mount
      mMount.object->getRenderMountTransform(dt, mMount.node,mMount.xfm,&mat);

	   Parent::setRenderTransform(mat);
   }

	if(!isHidden()) 
	{
		BehaviorInterfaceList iLst;

		if(getInterfaces( &iLst, NULL, "interpolateTick", NULL))
		{
			// Lets process the list that we've gotten back, and find the interface that
			// we want.
			UpdateInterface *scQueriedInterface = NULL;

			for( BehaviorInterfaceListIterator i = iLst.begin(); i != iLst.end(); i++ )
			{
				scQueriedInterface = dynamic_cast<UpdateInterface *>( *i );

				if( scQueriedInterface != NULL )
					scQueriedInterface->interpolateTick(dt);
			}
		}
	}
}

//Render
void Entity::prepRenderImage( SceneRenderState *state )
{
	BehaviorInterfaceList iLst;

	if(getInterfaces( &iLst, NULL, "prepRenderImage"))
	{
		// Lets process the list that we've gotten back, and find the interface that
		// we want.
		PrepRenderImageInterface *scQueriedInterface = NULL;

		for( BehaviorInterfaceListIterator i = iLst.begin(); i != iLst.end(); i++ )
		{
			scQueriedInterface = dynamic_cast<PrepRenderImageInterface *>( *i );

			if( scQueriedInterface != NULL )
				scQueriedInterface->prepRenderImage(state);
		}
	}

	//rendering stuff specifically if we're in the editors
	if(gEditingMission)
	{
		if(getInterfaces( &iLst, NULL, "editorPrepRenderImage"))
		{
			// Lets process the list that we've gotten back, and find the interface that
			// we want.
			PrepRenderImageInterface *scQueriedInterface = NULL;

			for( BehaviorInterfaceListIterator i = iLst.begin(); i != iLst.end(); i++ )
			{
				scQueriedInterface = dynamic_cast<PrepRenderImageInterface *>( *i );

				if( scQueriedInterface != NULL )
					scQueriedInterface->prepRenderImage(state);
			}
		}
	}
}

//Networking
U32 Entity::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
   U32 retMask = Parent::packUpdate(con, mask, stream);

   if( stream->writeFlag( mask & TransformMask ) )
   {
	   //mathWrite( *stream, getScale() );
	   stream->writeAffineTransform( mObjToWorld ); 
	   mathWrite( *stream, mRot );
   }

	if( stream->writeFlag( mask & MountedMask ) )
   {
		mathWrite( *stream, mMount.xfm.getPosition() );
	   mathWrite( *stream, mMount.xfm.toEuler() );
	}

   if( stream->writeFlag( mask & BoundsMask ) )
   {
   	   mathWrite( *stream, mObjBox );
   }

   return retMask;
}

void Entity::unpackUpdate(NetConnection *con, BitStream *stream)
{
   Parent::unpackUpdate(con, stream);

   if( stream->readFlag() )
   {
	   /*Point3F scale;
	   mathRead( *stream, &scale );
	   setScale( scale);*/
	   
	   MatrixF objToWorld;
       stream->readAffineTransform( &objToWorld );  

	   mathRead( *stream, &mRot );
	   setTransform(objToWorld);
	   //setTransform( objToWorld.getPosition(), mRot );
   }

	if( stream->readFlag() )
   {
		Point3F mountOffset;
		EulerF mountRot;
		mathRead( *stream, &mountOffset );
	   mathRead( *stream, &mountRot );

		mountRot = R2DEuler(mountRot);

		setMountOffset(mountOffset);
		setMountRotation(mountRot);
	}

   if( stream->readFlag() )
   {
	   mathRead( *stream, &mObjBox );
	   resetWorldBox();
   }
}

//Manipulation
void Entity::setTransform(const MatrixF &mat)
{
	setMaskBits(TransformMask);

	if (isMounted()) 
	{
		// Use transform from mounted object

		if(mat.getPosition() != mMount.xfm.getPosition())
			setMountOffset(mat.getPosition() - mMount.object->getPosition());

		Point3F matEul = mat.toEuler();
		//matEul.x *= -1;

		mRot = Point3F(mRadToDeg(matEul.x), mRadToDeg(matEul.y), mRadToDeg(matEul.z));

		if(matEul != Point3F(0,0,0))
		{
			Point3F mountEul = mMount.object->getTransform().toEuler();
			Point3F diff = matEul - mountEul;

			setMountRotation(Point3F(mRadToDeg(diff.x), mRadToDeg(diff.y), mRadToDeg(diff.z)));
		}
		else
		{
			setMountRotation(Point3F(0,0,0));
		}

		//Parent::setTransform(mat);
   }
	else
	{
		//Are we part of a prefab?
		Prefab* p = Prefab::getPrefabByChild(this);
		if(p)
		{
			//just let our prefab know we moved
			p->childTransformUpdated(this, mat);
		}
		else
		{
			Parent::setTransform(mat);
		}
	}

	/*if(isServerObject())
	{
		Vector<const char*> args;

		char *returnBuffer = Con::getReturnBuffer(256);

	    Point3F pos;
	    mat.getColumn(3,&pos);
	    AngAxisF aa(mat);
	    dSprintf(returnBuffer,256,"%g %g %g %g %g %g %g",
				pos.x,pos.y,pos.z,aa.axis.x,aa.axis.y,aa.axis.z,aa.angle);
	    //return returnBuffer;

		/*const char* string = argbuffer;*/
		/*args.push_back(returnBuffer);

		pushEvent("setTransform", args);
	}*/
}

void Entity::setRotation(EulerF rotation)
{
	MatrixF temp, imat, xmat, ymat, zmat;

	if(isMounted())
	{
		Point3F mountEul = mMount.object->getTransform().toEuler();

		mountEul = Point3F(mRadToDeg(mountEul.x), mRadToDeg(mountEul.y), mRadToDeg(mountEul.z));

		EulerF mountTransEul = mMount.xfm.toEuler();
		mountTransEul = Point3F(mRadToDeg(mountTransEul.x), mRadToDeg(mountTransEul.y), mRadToDeg(mountTransEul.z));

		Point3F diff = rotation - mountEul;

		Point3F radRot = Point3F(mDegToRad(diff.x), mDegToRad(diff.y), mDegToRad(diff.z));
		xmat.set(EulerF(radRot.x,0,0));
		ymat.set(EulerF(0.0f, radRot.y, 0.0f));
		zmat.set(EulerF(0,0,radRot.z));

		imat.mul(zmat, xmat);
		temp.mul(imat, ymat);

		temp.setColumn(3, mMount.xfm.getPosition());

		mMount.xfm = temp;
		setMaskBits(MountedMask);
	}		
	else
	{
		Point3F radRot = Point3F(mDegToRad(rotation.x), mDegToRad(rotation.y), mDegToRad(rotation.z));
		xmat.set(EulerF(radRot.x,0,0));
		ymat.set(EulerF(0.0f, radRot.y, 0.0f));
		zmat.set(EulerF(0,0,radRot.z));

		imat.mul(zmat, xmat);
		temp.mul(imat, ymat);

		temp.setColumn(3, getPosition());

		setTransform(temp);
	}

	mRot = rotation;
}

void Entity::setTransform(Point3F position, EulerF rotation)
{
	MatrixF temp, imat, xmat, ymat, zmat;

	Point3F radRot = Point3F(mDegToRad(rotation.x), mDegToRad(rotation.y), mDegToRad(rotation.z));
	xmat.set(EulerF(radRot.x,0,0));
	ymat.set(EulerF(0.0f, radRot.y, 0.0f));
	zmat.set(EulerF(0,0,radRot.z));

	imat.mul(zmat, xmat);
	temp.mul(imat, ymat);

	temp.setColumn(3, position);

	mRot = rotation;

	setTransform(temp);
}

void Entity::setMountOffset(Point3F posOffset)
{
	if(isMounted())
	{
		mMount.xfm.setColumn(3, posOffset);
		setMaskBits(MountedMask);
	}
}

void Entity::setMountRotation(EulerF rotOffset)
{
	if(isMounted())
	{
		MatrixF temp, imat, xmat, ymat, zmat;

		Point3F radRot = Point3F(mDegToRad(rotOffset.x), mDegToRad(rotOffset.y), mDegToRad(rotOffset.z));
		xmat.set(EulerF(radRot.x,0,0));
		ymat.set(EulerF(0.0f, radRot.y, 0.0f));
		zmat.set(EulerF(0,0,radRot.z));

		imat.mul(zmat, xmat);
		temp.mul(imat, ymat);

		temp.setColumn(3, mMount.xfm.getPosition());

		mMount.xfm = temp;
		setMaskBits(MountedMask);
	}
}
//
void Entity::getCameraTransform(F32* pos,MatrixF* mat)
{
	BehaviorInterfaceList iLst;

	if(getInterfaces( &iLst, NULL, "getCameraTransform", NULL))
	{
		// Lets process the list that we've gotten back, and find the interface that
		// we want.
		CameraInterface *scQueriedInterface = NULL;

		for( BehaviorInterfaceListIterator i = iLst.begin(); i != iLst.end(); i++ )
		{
			scQueriedInterface = dynamic_cast<CameraInterface *>( *i );

			if( scQueriedInterface != NULL )
				if(scQueriedInterface->getCameraTransform(pos, mat))
					return;
		}
	}
}

void Entity::getMountTransform( S32 index, const MatrixF &xfm, MatrixF *outMat )
{
	TSShapeInstanceInterface* tsI = getInterface<TSShapeInstanceInterface>();

	if(tsI)
	{
		tsI->getShapeInstance()->animate();
		S32 nodeCount = tsI->getShapeInstance()->getShape()->nodes.size();

		if(index >= 0 && index < nodeCount)
		{
			MatrixF mountTransform = tsI->getShapeInstance()->mNodeTransforms[index];
			mountTransform.mul( xfm );
			const Point3F& scale = getScale();

			// The position of the mount point needs to be scaled.
			Point3F position = mountTransform.getPosition();
			position.convolve( scale );
			mountTransform.setPosition( position );

			// Also we would like the object to be scaled to the model.
			outMat->mul(mObjToWorld, mountTransform);
			return;
		}
	}

   // Then let SceneObject handle it.
   Parent::getMountTransform( index, xfm, outMat );      
}

void Entity::getRenderMountTransform( F32 delta, S32 index, const MatrixF &xfm, MatrixF *outMat )
{
	TSShapeInstanceInterface* tsI = getInterface<TSShapeInstanceInterface>();

	if(tsI)
	{
		tsI->getShapeInstance()->animate();
		S32 nodeCount = tsI->getShapeInstance()->getShape()->nodes.size();

		if(index >= 0 && index < nodeCount)
		{
			MatrixF mountTransform = tsI->getShapeInstance()->mNodeTransforms[index];
			mountTransform.mul( xfm );
			const Point3F& scale = getScale();

			// The position of the mount point needs to be scaled.
			Point3F position = mountTransform.getPosition();
			position.convolve( scale );
			mountTransform.setPosition( position );

			// Also we would like the object to be scaled to the model.
			outMat->mul(getRenderTransform(), mountTransform);
			return;
		}
	}

   // Then let SceneObject handle it.
   Parent::getMountTransform( index, xfm, outMat );      
}
//
//These basically just redirect to any collision behaviors we have
bool Entity::castRay(const Point3F &start, const Point3F &end, RayInfo* info)
{
	for(U32 b=0; b < getBehaviorCount(); b++)
	{
		if(getBehavior(b)->isEnabled())
			if(getBehavior(b)->castRay(start, end, info))
				return true;
	}
	return false;
}

bool Entity::castRayRendered(const Point3F &start, const Point3F &end, RayInfo *info)
{
	BehaviorInterfaceList iLst;

	if(getInterfaces( &iLst, NULL, "castRayRendered", NULL))
	{
		// Lets process the list that we've gotten back, and find the interface that
		// we want.
		CastRayRenderedInterface *scQueriedInterface = NULL;

		for( BehaviorInterfaceListIterator i = iLst.begin(); i != iLst.end(); i++ )
		{
			scQueriedInterface = dynamic_cast<CastRayRenderedInterface *>( *i );

			if( scQueriedInterface != NULL )
				if(scQueriedInterface->castRayRendered(start, end, info))
					return true;
		}
	}

	/*for(U32 b=0; b < getBehaviorCount(); b++)
	{
		if(getBehavior(b)->isEnabled())
			if(getBehavior(b)->castRayRendered(start, end, info))
				return true;
	}*/
	return false;
}

bool Entity::buildPolyList(PolyListContext context, AbstractPolyList* polyList, const Box3F &box, const SphereF &sphere)
{
	/*for(U32 b=0; b < getBehaviorCount(); b++){
		CollisionBehaviorInstance *cB = dynamic_cast<CollisionBehaviorInstance*>(getBehavior(b));
		if(cB && (cB->getBehaviorType() == String("Collision")))
		{
			return cB->buildPolyList(context,polyList,box,sphere);
		}
	}*/
	return false;
}

void Entity::buildConvex(const Box3F& box, Convex* convex)
{
	BehaviorInterfaceList iLst;

	if(getInterfaces( &iLst, NULL, "buildConvex", NULL))
	{
		// Lets process the list that we've gotten back, and find the interface that
		// we want.
		BuildConvexInterface *scQueriedInterface = NULL;

		for( BehaviorInterfaceListIterator i = iLst.begin(); i != iLst.end(); i++ )
		{
			scQueriedInterface = dynamic_cast<BuildConvexInterface *>( *i );

			if( scQueriedInterface != NULL ){
				scQueriedInterface->buildConvex(box, convex);
			}
		}
	}

	/*for(U32 b=0; b < getBehaviorCount(); b++)
	{
		if(getBehavior(b)->isEnabled())
			getBehavior(b)->;
	}*/
}

//
// Mounting and heirarchy manipulation
void Entity::mountObject(SceneObject* objB, MatrixF txfm)
{
	Parent::mountObject(objB, -1, txfm);
}

void Entity::mountObject( SceneObject *obj, S32 node, const MatrixF &xfm )
{
	Parent::mountObject(obj, node, xfm);
}

void Entity::onMount( SceneObject *obj, S32 node )
{      
   deleteNotify( obj );

   // Are we mounting to a GameBase object?
   Entity *entityObj = dynamic_cast<Entity*>( obj );

   if ( entityObj && entityObj->getControlObject() != this )
      processAfter( entityObj );

   if (!isGhost()) {
      setMaskBits(MountedMask);

	  //TODO implement this callback
      //onMount_callback( this, obj, node );
   }
}

void Entity::onUnmount( SceneObject *obj, S32 node )
{
   clearNotify(obj);

   Entity *entityObj = dynamic_cast<Entity*>( obj );

   if ( entityObj && entityObj->getControlObject() != this )
      clearProcessAfter();

   if (!isGhost()) {
      setMaskBits(MountedMask);
      
	  //TODO implement this callback
	  //onUnmount_callback( this, obj, node );
   }
}

//Heirarchy stuff
void Entity::addObject( SimObject* object )
{
	Parent::addObject(object);	
	
	Entity* e = dynamic_cast<Entity*>(object);
	if(e)
	{
		MatrixF offset;

		//offset.mul(getWorldTransform(), e->getWorldTransform());
		
		//check if we're mounting to a node on a shape we have
		String node = e->getDataField("mountNode", NULL);
		if(!node.isEmpty())
		{
			TSShapeInterface *sI = getInterface<TSShapeInterface>();
			if(sI)
			{
				TSShape* shape = sI->getShape();
				S32 nodeIdx = shape->findNode(node);

				mountObject(e, nodeIdx, MatrixF::Identity);
			}
			else
			{
				mountObject(e, MatrixF::Identity);
			}
		}
		else
		{
			mountObject(e, MatrixF::Identity);
		}
		
		//e->setMountOffset(e->getPosition() - getPosition());

		//Point3F diff = getWorldTransform().toEuler() - e->getWorldTransform().toEuler();

		//e->setMountRotation(Point3F(mRadToDeg(diff.x),mRadToDeg(diff.y),mRadToDeg(diff.z)));

		//mountObject(e, offset);
	}
}

void Entity::removeObject( SimObject* object )
{
	SceneObject* so = dynamic_cast<SceneObject*>(object);
	if(so)
		unmountObject(so);

	Parent::removeObject(object);
}

void Entity::onInspect()
{
	BehaviorInterfaceList iLst;

	if(getInterfaces( &iLst, NULL, "onInspect", NULL))
	{
		// Lets process the list that we've gotten back, and find the interface that
		// we want.
		EditorInspectInterface *scQueriedInterface = NULL;

		for( BehaviorInterfaceListIterator i = iLst.begin(); i != iLst.end(); i++ )
		{
			scQueriedInterface = dynamic_cast<EditorInspectInterface *>( *i );

			if( scQueriedInterface != NULL ){
				scQueriedInterface->onInspect();
			}
		}
	}
}

void Entity::onEndInspect()
{
	BehaviorInterfaceList iLst;

	if(getInterfaces( &iLst, NULL, "onEndInspect", NULL))
	{
		// Lets process the list that we've gotten back, and find the interface that
		// we want.
		EditorInspectInterface *scQueriedInterface = NULL;

		for( BehaviorInterfaceListIterator i = iLst.begin(); i != iLst.end(); i++ )
		{
			scQueriedInterface = dynamic_cast<EditorInspectInterface *>( *i );

			if( scQueriedInterface != NULL ){
				scQueriedInterface->onEndInspect();
			}
		}
	}
}

//
void Entity::setObjectBox(Box3F objBox) 
{ 
	mObjBox = objBox; 
	resetWorldBox(); 
	
	if(isServerObject())
		setMaskBits(BoundsMask); 
}
//Behaviors
BehaviorInstance * Entity::behavior(const char *name)
{
   /*StringTableEntry stName = StringTable->insert(name);
   VectorPtr<SimComponent *>&componentList = lockComponentList();

   for( SimComponentIterator nItr = componentList.begin(); nItr != componentList.end(); nItr++ )
   {
      BehaviorInstance *pComponent = dynamic_cast<BehaviorInstance*>(*nItr);
      if( pComponent && StringTable->insert(pComponent->getTemplateName()) == stName )
      {
         unlockComponentList();
         return pComponent;
      }
   }

   unlockComponentList();*/

   return NULL;
}



ConsoleMethod(Entity, behavior, S32, 3, 3, "(string behaviorName) - Gets the behavior instance ID off of the object based on the behavior name passed.\n"
                                                   "@param behaviorName The name of the behavior you want to get the instance ID of.\n"
                                                   "@return (integer behaviorID) The id of the behavior instance.")
{
   BehaviorInstance *inst = object->behavior(argv[2]);
   return inst ? inst->getId() : 0;
}

DefineEngineMethod( Entity, mountObject, bool,
   ( SceneObject* objB, TransformF txfm ), ( MatrixF::Identity ),
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
   if ( objB )
   {
	   //BUG: Unsure how it broke, but atm the default transform passed in here is rotated 180 degrees. This doesn't happen
	   //for the SceneObject mountobject method. Hackish, but for now, just default to a clean MatrixF::Identity
      object->mountObject( objB, /*MatrixF::Identity*/txfm.getMatrix() );
      return true;
   }
   return false;
}

DefineEngineMethod( Entity, setMountOffset, void,
   ( Point3F posOffset ), ( Point3F(0,0,0) ),
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
  object->setMountOffset( posOffset );
}

DefineEngineMethod( Entity, setMountRotation, void,
   ( EulerF rotOffset ), ( EulerF(0,0,0) ),
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
  object->setMountRotation( rotOffset );
}

DefineEngineMethod( Entity, getMountTransform, TransformF, (),,
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
	MatrixF mat;
	object->getMountTransform(0, MatrixF::Identity, &mat);
	return mat;
}

ConsoleMethod( Entity, queueEvent, void, 3, 0, "( String eventName, String eventArg, ... )"
              "Adds an event for the entity to pass down to it's behaviors to process.")
{
   Vector<const char*> args;
   for(U32 i=3; i < argc; i++)
   {
	  args.push_back(argv[i]);
   }

   object->pushEvent(argv[2], args);
}


DefineEngineMethod( Entity, setBox, void,
   ( Point3F box ), ( Point3F(1,1,1) ),
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
  object->setObjectBox( Box3F(-box, box) );
}

DefineEngineMethod( Entity, getEulerRotation, Point3F,
   (),,
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
	return object->getRotation();
}