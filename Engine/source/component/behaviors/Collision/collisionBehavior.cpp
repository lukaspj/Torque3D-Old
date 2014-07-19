//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#include "component/behaviors/Collision/collisionBehavior.h"

#include "platform/platform.h"
#include "console/consoleTypes.h"
#include "core/util/safeDelete.h"
#include "core/resourceManager.h"
#include "core/stream/fileStream.h"
#include "console/consoleTypes.h"
#include "console/consoleObject.h"
#include "ts/tsShapeInstance.h"
#include "core/stream/bitStream.h"
#include "gfx/gfxTransformSaver.h"
#include "console/engineAPI.h"
#include "lighting/lightQuery.h"
#include "T3D/gameBase/gameConnection.h"
#include "collision/extrudedPolyList.h"
#include "collision/clippedPolyList.h"
#include "collision/earlyOutPolyList.h"
#include "collision/concretePolyList.h"
#include "collision/optimizedPolyList.h"

//#include "component/behaviors/Physics/physicsBehavior.h"

#include "component/behaviors/Physics/physicsInterfaces.h"


//ideally these get dropped later for behaviors instead
#include "T3D/trigger.h"
#include "T3D/physicalZone.h"
#include "T3D/item.h"


IMPLEMENT_CALLBACK( CollisionBehaviorInstance, onCollision, void, ( BehaviorInstance* obj, SceneObject *collObj, VectorF vec, F32 len ), ( obj, collObj, vec, len ),
   "@brief Called when we collide with another object.\n\n"
   "@param obj The ShapeBase object\n"
   "@param collObj The object we collided with\n"
   "@param vec Collision impact vector\n"
   "@param len Length of the impact vector\n" );

IMPLEMENT_CALLBACK( CollisionBehaviorInstance, onRaycastCollision, void, ( BehaviorInstance* obj, SceneObject *collObj, Point3F pos, Point3F normal ), ( obj, collObj, pos, normal ),
   "@brief Called when we collide with another object.\n\n"
   "@param obj The ShapeBase object\n"
   "@param collObj The object we collided with\n"
   "@param vec Collision impact vector\n"
   "@param len Length of the impact vector\n" );

IMPLEMENT_CALLBACK( CollisionBehaviorInstance, onContact, void, ( BehaviorInstance* obj, SceneObject *collObj ), ( obj, collObj ),
   "@brief Called when we collide with another object.\n\n"
   "@param obj The ShapeBase object\n"
   "@param collObj The object we collided with\n"
   "@param vec Collision impact vector\n"
   "@param len Length of the impact vector\n" );

//////////////////////////////////////////////////////////////////////////
// Constructor/Destructor
//////////////////////////////////////////////////////////////////////////

//SceneObject* BehaviorPolysoupConvex::smCurObject = NULL;

CollisionBehavior::CollisionBehavior()
{
	addBehaviorField("blockColldingObject", "If enabled, will stop colliding objects from passing through.", "bool", "1", "");

	addBehaviorField("collisionMasks", "Lets us define what masks to collide against.", "collisionMask", "-1", "");

	mNetFlags.set(Ghostable | ScopeAlways);
}

CollisionBehavior::~CollisionBehavior()
{
   for(S32 i = 0;i < mFields.size();++i)
   {
      BehaviorField &field = mFields[i];
      SAFE_DELETE_ARRAY(field.mFieldDescription);
   }

   SAFE_DELETE_ARRAY(mDescription);
}

IMPLEMENT_CO_NETOBJECT_V1(CollisionBehavior);

//////////////////////////////////////////////////////////////////////////
BehaviorInstance *CollisionBehavior::createInstance()
{
   CollisionBehaviorInstance *instance = new CollisionBehaviorInstance(this);

   setupFields( instance );

   if(instance->registerObject())
      return instance;

   delete instance;
   return NULL;
}

bool CollisionBehavior::onAdd()
{
   if(! Parent::onAdd())
      return false;

   return true;
}

void CollisionBehavior::onRemove()
{
   Parent::onRemove();
}
void CollisionBehavior::initPersistFields()
{
   Parent::initPersistFields();
}

U32 CollisionBehavior::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);
	return retMask;
}

void CollisionBehavior::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);
}

//==========================================================================================

Chunker<CollisionBehaviorInstance::CollisionTimeout> sTimeoutChunker;
CollisionBehaviorInstance::CollisionTimeout* CollisionBehaviorInstance::sFreeTimeoutList = 0;

//==========================================================================================
CollisionBehaviorInstance::CollisionBehaviorInstance( BehaviorTemplate *btemplate ) 
{
   mTemplate = btemplate;
   mBehaviorOwner = NULL;

   mCollisionTol = 0.1f;
   mContactTol = 0.1f;
   mTimeoutList = NULL;
   mConvexList = new Convex;

   sMoveRetryCount = 5;
   sNormalElasticity = 0.01f;

   mBlockColliding = true;

   mNetFlags.set(Ghostable);
}

CollisionBehaviorInstance::~CollisionBehaviorInstance()
{
}
IMPLEMENT_CO_NETOBJECT_V1(CollisionBehaviorInstance);

bool CollisionBehaviorInstance::onAdd()
{
   if(! Parent::onAdd())
      return false;
	  
   //mBehaviorOwner->registerCachedInterface("collision", "checkCollisions", this, &mColInterface );

   return true;
}

void CollisionBehaviorInstance::onRemove()
{
   SAFE_DELETE( mConvexList );

   CollisionTimeout* ptr = mTimeoutList;
   while (ptr) {
      CollisionTimeout* cur = ptr;
      ptr = ptr->next;
      cur->next = sFreeTimeoutList;
      sFreeTimeoutList = cur;
   }

   Parent::onRemove();
}

void CollisionBehaviorInstance::onBehaviorAdd()
{
   Parent::onBehaviorAdd();

   //mBehaviorOwner->registerCachedInterface( "collision", "checkCollisions", this, &mCollisionInterface );
}

void CollisionBehaviorInstance::onBehaviorRemove()
{
   mConvexList->nukeList();
   

   Parent::onBehaviorRemove();
}

void CollisionBehaviorInstance::initPersistFields()
{
   Parent::initPersistFields();

   addField("blockColldingObject", TypeBool, Offset(mBlockColliding, CollisionBehaviorInstance), "");

}

U32 CollisionBehaviorInstance::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);

	if(stream->writeFlag( mask & InitialUpdateMask ) )
		stream->writeFlag(mBlockColliding);

	return retMask;
}

void CollisionBehaviorInstance::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);

	if(stream->readFlag())
		mBlockColliding = stream->readFlag();
}
void CollisionBehaviorInstance::processTick(const Move* move)
{
	mCollisionList.clear();

	BehaviorInterface *bI = mBehaviorOwner->getInterface(NULL, "getVelocity");
	if(!bI)
		return;

	VelocityInterface *vI = dynamic_cast<VelocityInterface*>(bI);

	if(vI)
	{
		VectorF velocity = vI->getVelocity();
	
		//No need to update our working set if we don't have our convex or we're not moving
		if(mConvexList && mConvexList->getObject() && !velocity.isZero())
			updateWorkingCollisionSet((U32)-1);
	}
}

/*void CollisionBehaviorInstance::updateWorkingCollisionSet(const U32 mask)
{
   Box3F convexBox = mConvexList->getBoundingBox(mBehaviorOwner->getTransform(), mBehaviorOwner->getScale());
   F32 len = (/*getVelocity().len()*//*0 + 50) * TickSec;
   F32 l = (len * 1.1) + 0.1;  // fudge factor
   convexBox.minExtents -= Point3F(l, l, l);
   convexBox.maxExtents += Point3F(l, l, l);

   mBehaviorOwner->disableCollision();
   mConvexList->updateWorkingList(convexBox, mask);
   mBehaviorOwner->enableCollision();
}

bool CollisionBehaviorInstance::updateCollisions(F32 time, VectorF vector, VectorF velocity)
{
	// Update collision information
	MatrixF mat = mBehaviorOwner->getTransform();

	mCollisionList.clear();

	F32 scaledColTol = getMax(mCollisionTol, mCollisionTol * velocity.len());

	CollisionState *state = mConvexList->findClosestState(mat, mBehaviorOwner->getScale(), scaledColTol);
    if (state && state->dist <= scaledColTol) 
		mConvexList->getCollisionInfo(mat, mBehaviorOwner->getScale(), &mCollisionList, scaledColTol);

	bool collided = resolveCollision(mCollisionList, velocity);
    resolveContacts(mCollisionList, velocity, time);
    return collided;
}*/

/*Point3F CollisionBehaviorInstance::scanCollision( const F32 travelTime, Point3F *velocity )
{
	if(!mConvexList || !mConvexList->getObject())
		return mBehaviorOwner->getTransform().getPosition() + *velocity * travelTime;

   // Try and move to new pos
   F32 totalMotion  = 0.0f;

   Point3F start;
   Point3F initialPosition;
   mBehaviorOwner->getTransform().getColumn(3,&start);
   initialPosition = start;

   Box3F scaledBox = mBehaviorOwner->getObjBox();
   scaledBox.minExtents.convolve( mBehaviorOwner->getScale() );
   scaledBox.maxExtents.convolve( mBehaviorOwner->getScale() );

   Collision     outCol;
   CollisionList collisionList;
   static CollisionList physZoneCollisionList;

   collisionList.clear();
   physZoneCollisionList.clear();

   MatrixF collisionMatrix(true);
   collisionMatrix.setColumn(3, start);

   VectorF firstNormal(0.0f, 0.0f, 0.0f);
   F32 time = travelTime;
   U32 count = 0;

    Box3F wBox;
    static Polyhedron sBoxPolyhedron;
    static ExtrudedPolyList sExtrudedPolyList;
    static ExtrudedPolyList sPhysZonePolyList;
	Vector<SceneObject*> overlapObjects;

   for (; count < sMoveRetryCount; count++) {
	  F32 speed = velocity->len();
	  if (!speed)
		 break;

	  Point3F end = start + *velocity * time;
	  Point3F distance = end - start;

	  Box3F objBox = mBehaviorOwner->getObjBox();
	  if (mFabs(distance.x) < objBox.len_x() &&
          mFabs(distance.y) < objBox.len_y() &&
          mFabs(distance.z) < objBox.len_z())
      {

		  Point3F end = start + *velocity * time;
		  VectorF vector = end - start;

		  if (checkEarlyOut(start, *velocity, time))
		  {
			 totalMotion += (end - start).len();
			 start = end;
			 break;
		  }
		  updateCollisions(time, vector, *velocity);

		  if(collisionList.getCount() == 0 )
		  {
			 totalMotion += (end - start).len();
			 start = end;
			 break;
		  }
	  }
   }

   if (count == sMoveRetryCount)
   {
	  // Failed to move
	  start = initialPosition;
	  velocity->set(0.0f, 0.0f, 0.0f);
   }

   handleCollision(outCol, *velocity);
	   
   return start;
}*/

bool CollisionBehaviorInstance::checkCollisions( const F32 travelTime, Point3F *velocity, Point3F start )
{
	if(!mConvexList || !mConvexList->getObject())
		return false;

	Point3F end = start + *velocity * travelTime;

	VectorF vector = end - start;

	mCollisionList.clear();

	if (checkEarlyOut(start, *velocity, travelTime))
		return false;

	bool collided = updateCollisions(travelTime, vector, *velocity);

    handleCollisionList(mCollisionList, *velocity);
	   
	//Basically, if this is false, we still track collisions as normal, but we don't
	//stop the colliding objects, instead only firing off callbacks.
	//This lets use act like a trigger.
	if(mBlockColliding)
		return collided;
	else
		return false;
}

void CollisionBehaviorInstance::handleCollision( Collision &col, VectorF velocity )
{
	if ( !isGhost() && col.object /*&& col.object != mContactInfo.contactObject */)
	   queueCollision( col.object, velocity - col.object->getVelocity() );
}

void CollisionBehaviorInstance::handleCollisionList( CollisionList &collisionList, VectorF velocity )
{
	Collision col;

	if (collisionList.getCount() > 0)
		col = collisionList[collisionList.getCount() - 1];

	for (U32 i=0; i<collisionList.getCount(); ++i)
	{
		Collision& colCheck = collisionList[i];
		if (colCheck.object)
		{
			SceneObject* obj = static_cast<SceneObject*>(col.object);
			if (obj->getTypeMask() & PlayerObjectType)
			{
				handleCollision( colCheck, velocity );
			}
			else
			{
				col = colCheck;
			}
		}
	}
	
	handleCollision( col, velocity );
}


bool CollisionBehaviorInstance::checkEarlyOut(Point3F start, VectorF velocity, F32 time)
{
  Point3F end = start + velocity * time;
  Point3F distance = end - start;

   Box3F scaledBox = mBehaviorOwner->getObjBox();
   scaledBox.minExtents.convolve( mBehaviorOwner->getScale() );
   scaledBox.maxExtents.convolve( mBehaviorOwner->getScale() );

  if (mFabs(distance.x) < mBehaviorOwner->getObjBox().len_x() &&
	  mFabs(distance.y) < mBehaviorOwner->getObjBox().len_y() &&
	  mFabs(distance.z) < mBehaviorOwner->getObjBox().len_z())
  {
	 // We can potentially early out of this.  If there are no polys in the clipped polylist at our
	 //  end position, then we can bail, and just set start = end;
	 Box3F wBox = mConvexList->getBoundingBox(mBehaviorOwner->getTransform(), mBehaviorOwner->getScale());  
	 wBox.minExtents += distance;  
	 wBox.maxExtents += distance;

	 static EarlyOutPolyList eaPolyList;
	 eaPolyList.clear();
	 eaPolyList.mNormal.set(0.0f, 0.0f, 0.0f);
	 eaPolyList.mPlaneList.clear();
	 eaPolyList.mPlaneList.setSize(6);
	 eaPolyList.mPlaneList[0].set(wBox.minExtents,VectorF(-1.0f, 0.0f, 0.0f));
	 eaPolyList.mPlaneList[1].set(wBox.maxExtents,VectorF(0.0f, 1.0f, 0.0f));
	 eaPolyList.mPlaneList[2].set(wBox.maxExtents,VectorF(1.0f, 0.0f, 0.0f));
	 eaPolyList.mPlaneList[3].set(wBox.minExtents,VectorF(0.0f, -1.0f, 0.0f));
	 eaPolyList.mPlaneList[4].set(wBox.minExtents,VectorF(0.0f, 0.0f, -1.0f));
	 eaPolyList.mPlaneList[5].set(wBox.maxExtents,VectorF(0.0f, 0.0f, 1.0f));

	 // Build list from convex states here...
	 CollisionWorkingList& rList = mConvexList->getWorkingList();
	 CollisionWorkingList* pList = rList.wLink.mNext;
	 while (pList != &rList) {
		Convex* pConvex = pList->mConvex;
		if (pConvex->getObject()->getTypeMask() & CollisionMoveMask) {
		   Box3F convexBox = pConvex->getBoundingBox();
		   if (wBox.isOverlapped(convexBox))
		   {
			  // No need to separate out the physical zones here, we want those
			  //  to cause a fallthrough as well...
			  pConvex->getPolyList(&eaPolyList);
		   }
		}
		pList = pList->wLink.mNext;
	 }

	 if (eaPolyList.isEmpty())
	 {
		return true;
	 }
  }
  return false;
}

/*void CollisionBehaviorInstance::findContact( bool *run, VectorF *contactNormal )
{
   SceneObject *contactObject = NULL;

   Vector<SceneObject*> overlapObjects;
   //if ( mPhysicsRep )
  //    mPhysicsRep->findContact( &contactObject, contactNormal, &overlapObjects );
   //else
   //{
       //_findContact( &contactObject, contactNormal, &overlapObjects );

	   Point3F pos;
	   mBehaviorOwner->getTransform().getColumn(3,&pos);

	   Box3F wBox;
	   Point3F exp(0,0,sTractionDistance);
	   //wBox.minExtents = pos + mBehaviorOwner->getObjBox()/*mScaledBox*///.minExtents - exp;
	   //wBox.maxExtents.x = pos.x + mBehaviorOwner->getObjBox()/*mScaledBox*/.maxExtents.x;
	   //wBox.maxExtents.y = pos.y + mBehaviorOwner->getObjBox()/*mScaledBox*/.maxExtents.y;
	   //wBox.maxExtents.z = pos.z + mBehaviorOwner->getObjBox()/*mScaledBox*/.minExtents.z + sTractionDistance;

	   /*static ClippedPolyList polyList;
	   polyList.clear();
	   polyList.doConstruct();
	   polyList.mNormal.set(0.0f, 0.0f, 0.0f);
	   polyList.setInterestNormal(Point3F(0.0f, 0.0f, -1.0f));

	   polyList.mPlaneList.setSize(6);
	   polyList.mPlaneList[0].setYZ(wBox.minExtents, -1.0f);
	   polyList.mPlaneList[1].setXZ(wBox.maxExtents, 1.0f);
	   polyList.mPlaneList[2].setYZ(wBox.maxExtents, 1.0f);
	   polyList.mPlaneList[3].setXZ(wBox.minExtents, -1.0f);
	   polyList.mPlaneList[4].setXY(wBox.minExtents, -1.0f);
	   polyList.mPlaneList[5].setXY(wBox.maxExtents, 1.0f);
	   Box3F plistBox = wBox;

	   // Expand build box as it will be used to collide with items.
	   // PickupRadius will be at least the size of the box.
	   F32 pd = sCollisionDelta;
	   wBox.minExtents.x -= pd; wBox.minExtents.y -= pd;
	   wBox.maxExtents.x += pd; wBox.maxExtents.y += pd;
	   wBox.maxExtents.z = pos.z + mBehaviorOwner->getObjBox()/*mScaledBox*///.maxExtents.z;

	   // Build list from convex states here...
	   /*CollisionWorkingList& rList = mConvexList->getWorkingList();
	   CollisionWorkingList* pList = rList.wLink.mNext;
	   while (pList != &rList)
	   {
		  Convex* pConvex = pList->mConvex;

		  U32 objectMask = pConvex->getObject()->getTypeMask();
	      
		  if (  ( objectMask & sCollisionMoveMask ) &&
				!( objectMask & PhysicalZoneObjectType ) )
		  {
			 Box3F convexBox = pConvex->getBoundingBox();
			 if (plistBox.isOverlapped(convexBox))
				pConvex->getPolyList(&polyList);
		  }
		  else
			 overlapObjects.push_back( pConvex->getObject() );

		  pList = pList->wLink.mNext;
	   }

	   if (!polyList.isEmpty())
	   {
		  // Pick flattest surface
		  F32 bestVd = -1.0f;
		  ClippedPolyList::Poly* poly = polyList.mPolyList.begin();
		  ClippedPolyList::Poly* end = polyList.mPolyList.end();
		  for (; poly != end; poly++)
		  {
			 F32 vd = poly->plane.z;       // i.e.  mDot(Point3F(0,0,1), poly->plane);
			 if (vd > bestVd)
			 {
				bestVd = vd;
				contactObject = poly->object;
				*contactNormal = poly->plane;
			 }
		  }
	   }
   //}

   // Check for triggers, corpses and items.
   const U32 filterMask = isGhost() ? sClientCollisionContactMask : sServerCollisionContactMask;
   for ( U32 i=0; i < overlapObjects.size(); i++ )
   {
      SceneObject *obj = overlapObjects[i];
      U32 objectMask = obj->getTypeMask();

      if ( !( objectMask & filterMask ) )
         continue;

      // Check: triggers, corpses and items...
      //
      if (objectMask & TriggerObjectType)
      {
         Trigger* pTrigger = static_cast<Trigger*>( obj );
         pTrigger->potentialEnterObject(mBehaviorOwner);
      }
      else if (objectMask & CorpseObjectType)
      {
         // If we've overlapped the worldbounding boxes, then that's it...
         if ( mBehaviorOwner->getWorldBox().isOverlapped( obj->getWorldBox() ) )
         {
            ShapeBase* col = static_cast<ShapeBase*>( obj );
            queueCollision(col,getVelocity() - col->getVelocity());
         }
      }
      else if (objectMask & ItemObjectType)
      {
         // If we've overlapped the worldbounding boxes, then that's it...
         Item* item = static_cast<Item*>( obj );
         if (  mBehaviorOwner->getWorldBox().isOverlapped(item->getWorldBox()) &&
               (GameBase*)item->getCollisionObject() != (GameBase*)mBehaviorOwner && 
               !item->isHidden() )
            queueCollision(item,getVelocity() - item->getVelocity());
      }
   }

   F32 vd = (*contactNormal).z;
   *run = vd > mCos(mDegToRad(sMoveSurface));//mDataBlock->runSurfaceCos;
   //*jump = vd > mCos(mDegToRad(sMoveSurface));//mDataBlock->jumpSurfaceCos;

   mContactObject = contactObject;
}*/

//----------------------------------------------------------------------------
/** Resolve contact forces
Resolve contact forces using the "penalty" method. Forces are generated based
on the depth of penetration and the moment of inertia at the point of contact.
*/
/*bool CollisionBehaviorInstance::resolveContacts(CollisionList& cList, VectorF velocity, F32 dt)
{
   // Use spring forces to manage contact constraints.
	if(cList.getCount() <= 0)
		return false;

	BehaviorInstance* bI = mBehaviorOwner->getBehaviorByType("PhysicsBehavior");
    if(!bI)
	   return false;

   PhysicsBehaviorInstance *pBI = reinterpret_cast<PhysicsBehaviorInstance*>(bI);

   F32 scaledColTol = getMax(mCollisionTol, mCollisionTol * velocity.len());

   // Use spring forces to manage contact constraints.
   bool collided = false;
   Point3F t,p(0,0,0),l(0,0,0);
   F32 friction = 0.7f; //TODO:  remove hardcode
   for (S32 i = 0; i < cList.getCount(); i++) 
   {
      const Collision& c = cList[i];
      if (c.distance < mContactTol) 
      {
         // Velocity into the surface
         Point3F v,r;
         pBI->getOriginVector(c.point,&r);
         pBI->getVelocity(r,&v);
         F32 vn = mDot(v,c.normal);

         // Only interested in velocities less than mDataBlock->contactTol,
         // velocities greater than that are dealt with as collisions.
         if (mFabs(vn) < scaledColTol) 
         {
            collided = true;

            // Penetration force. This is actually a spring which
            // will seperate the body from the collision surface.
            F32 zi = 2 * mFabs(pBI->getZeroImpulse(r,c.normal));
            F32 s = (scaledColTol - c.distance) * zi - ((vn / mContactTol) * zi);
            Point3F f = c.normal * s;

            // Friction impulse, calculated as a function of the
            // amount of force it would take to stop the motion
            // perpendicular to the normal.
            Point3F uv = v - (c.normal * vn);
            F32 ul = uv.len();
            if (s > 0 && ul) 
            {
               uv /= -ul;
               F32 u = ul * pBI->getZeroImpulse(r,uv);
               s *= friction;
               if (u > s)
                  u = s;
               f += uv * u;
            }

            // Accumulate forces
            p += f;
         }
      }
   }

   // Contact constraint forces act over time...
   pBI->accumulateForce(dt, p);
   pBI->updateVelocity(dt);
   return true;

   /*bool collided = false;
   Point3F t, p(0,0,0), l(0,0,0);
   F32 friction = 0.7f; //TODO:  remove hardcode
   for (S32 i = 0; i < cList.getCount(); i++) 
   {
      Collision& c = cList[i];
      if (c.distance < mCollisionTol) 
      {

         // Velocity into the surface
         Point3F v,r;
         pBI->getOriginVector(c.point,&r);
         pBI->getVelocity(r,&v);
         F32 vn = mDot(v,c.normal);

         // Only interested in velocities less than contactTol,
         // velocities greater than that are dealt with as collisions.
         if (mFabs(vn) < mCollisionTol) 
         {
            collided = true;

            // Penetration force. This is actually a spring which
            // will seperate the body from the collision surface.
            F32 zeroImp = 2 * mFabs(pBI->getZeroImpulse(r,c.normal));
            F32 spring = (mCollisionTol - c.distance) * zeroImp - ((vn / mCollisionTol) * zeroImp);
            Point3F force = c.normal * spring;

            // Friction impulse, calculated as a function of the
            // amount of force it would take to stop the motion
            // perpendicular to the normal.
            Point3F uv = v - (c.normal * vn);
            F32 ul = uv.len();
            if (spring > 0 && ul) 
            {
               uv /= -ul;
               F32 u = ul * pBI->getZeroImpulse(r, uv);
               spring *= friction;
               if (u > spring)
                  u = spring;
               force += uv * u;
            }

            // Accumulate forces
            p += force;
            //mCross(r, force, &t);
            //l += t;
         }
      }
   }

   // Contact constraint forces act over time...
   pBI->accumulateForce(dt, p);
   pBI->updateVelocity(dt);
   //rigidBody.linMomentum += p * dt;
   //rigidBody.angMomentum += l * dt;
   //rigidBody.updateVelocity();
   return true;*/
//}


//----------------------------------------------------------------------------
/*bool CollisionBehaviorInstance::resolveCollision(CollisionList& cList, VectorF velocity)
{
   // Apply impulses to resolve collision
   if(cList.getCount() <= 0)
		return false;

   BehaviorInstance* bI = mBehaviorOwner->getBehaviorByType("PhysicsBehavior");
   if(!bI)
	   return false;

   PhysicsBehaviorInstance *pBI = reinterpret_cast<PhysicsBehaviorInstance*>(bI);

   F32 scaledColTol = getMax(mCollisionTol, mCollisionTol * velocity.len());

   bool collided = false;
   for (S32 i = 0; i < cList.getCount(); i++) 
   {
      Collision& c = cList[i];
      if (c.distance < scaledColTol) 
      {
         // Velocity into surface
         Point3F v,r;
         pBI->getOriginVector(c.point,&r);
         pBI->getVelocity(r,&v);
         F32 vn = mDot(v,c.normal);

         // Only interested in velocities greater than sContactTol,
         // velocities less than that will be dealt with as contacts
         // "constraints".
         if (vn < -mContactTol) 
         {
            // Apply impulses to the rigid body to keep it from
            // penetrating the surface.
            pBI->resolveCollision(cList[i].point,
               cList[i].normal);
            collided  = true;

            // Keep track of objects we collide with
            if (!isGhost() && c.object->getTypeMask() & ShapeBaseObjectType) 
            {
               ShapeBase* col = static_cast<ShapeBase*>(c.object);
               queueCollision(col,v - col->getVelocity());
            }
         }
      }
   }

   return collided;
}*/

void CollisionBehaviorInstance::queueCollision( SceneObject *obj, const VectorF &vec)
{
   // Add object to list of collisions.
   SimTime time = Sim::getCurrentTime();
   S32 num = obj->getId();

   CollisionTimeout** adr = &mTimeoutList;
   CollisionTimeout* ptr = mTimeoutList;
   while (ptr) {
      if (ptr->objectNumber == num) {
         if (ptr->expireTime < time) {
            ptr->expireTime = time + CollisionTimeoutValue;
            ptr->object = obj;
            ptr->vector = vec;
         }
         return;
      }
      // Recover expired entries
      if (ptr->expireTime < time) {
         CollisionTimeout* cur = ptr;
         *adr = ptr->next;
         ptr = ptr->next;
         cur->next = sFreeTimeoutList;
         sFreeTimeoutList = cur;
      }
      else {
         adr = &ptr->next;
         ptr = ptr->next;
      }
   }

   // New entry for the object
   if (sFreeTimeoutList != NULL)
   {
      ptr = sFreeTimeoutList;
      sFreeTimeoutList = ptr->next;
      ptr->next = NULL;
   }
   else
   {
      ptr = sTimeoutChunker.alloc();
   }

   ptr->object = obj;
   ptr->objectNumber = obj->getId();
   ptr->vector = vec;
   ptr->expireTime = time + CollisionTimeoutValue;
   ptr->next = mTimeoutList;

   mTimeoutList = ptr;
}

/*void CollisionBehaviorInstance::notifyCollision()
{
   // Notify all the objects that were just stamped during the queueing
   // process.
   SimTime expireTime = Sim::getCurrentTime() + CollisionTimeoutValue;
   for (CollisionTimeout* ptr = mTimeoutList; ptr; ptr = ptr->next)
   {
      if (ptr->expireTime == expireTime && ptr->object)
      {
         SimObjectPtr<SceneObject> safePtr(ptr->object);
         SimObjectPtr<SceneObject> safeThis(mBehaviorOwner);
         //onCollision(ptr->object,ptr->vector);

		 //callback
		 if (!isGhost())
		 {
			 String moveVec = String(Con::getFloatArg(ptr->vector.x)) 
				+ " " + String(Con::getFloatArg(ptr->vector.y)) + " " + String(Con::getFloatArg(ptr->vector.z));
			 Con::executef(this, "onCollision", ptr->object->getIdString(), moveVec, Con::getFloatArg(ptr->vector.len()) );
			//onCollision_callback( this, ptr->object->getIdString(), moveVec, Con::getFloatArg(ptr->vector.len()) );
		 }

         ptr->object = 0;

         if(!bool(safeThis))
            return;

         if(bool(safePtr))
            safePtr->onCollision(mBehaviorOwner,ptr->vector);

         if(!bool(safeThis))
            return;
      }
   }
}*/

/*Convex CollisionBehaviorInstance::buildConvex(Geometry geo)
{
    //parse the geometry and return out a convex
	return ;
}*/