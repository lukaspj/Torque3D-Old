//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#include "component/behaviors/Animation/AnimationBehavior.h"
#include "component/behaviors/render/renderShapeBehavior.h"

#include "platform/platform.h"
#include "console/consoleTypes.h"
#include "core/util/safeDelete.h"
#include "core/resourceManager.h"
#include "core/stream/fileStream.h"
#include "console/consoleTypes.h"
#include "console/consoleObject.h"
#include "ts/tsShapeInstance.h"
#include "core/stream/bitStream.h"
//#include "console/consoleInternal.h"
#include "sim/netConnection.h"
#include "gfx/gfxTransformSaver.h"
#include "console/engineAPI.h"
#include "lighting/lightQuery.h"

#include "gfx/sim/debugDraw.h" 

extern bool gEditingMission;

//////////////////////////////////////////////////////////////////////////
// Callbacks
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CALLBACK( AnimationBehaviorInstance, onAnimationStart, void, ( BehaviorInstance* obj, const String& animName ), ( obj, animName ),
   "@brief Called when we collide with another object.\n\n"
   "@param obj The ShapeBase object\n"
   "@param collObj The object we collided with\n"
   "@param vec Collision impact vector\n"
   "@param len Length of the impact vector\n" );

IMPLEMENT_CALLBACK( AnimationBehaviorInstance, onAnimationEnd, void, ( BehaviorInstance* obj, const char* animName ), ( obj, animName ),
   "@brief Called when we collide with another object.\n\n"
   "@param obj The ShapeBase object\n"
   "@param collObj The object we collided with\n"
   "@param vec Collision impact vector\n"
   "@param len Length of the impact vector\n" );

IMPLEMENT_CALLBACK( AnimationBehaviorInstance, onAnimationTrigger, void, ( BehaviorInstance* obj, const String& animName, S32 triggerID ), ( obj, animName, triggerID ),
   "@brief Called when we collide with another object.\n\n"
   "@param obj The ShapeBase object\n"
   "@param collObj The object we collided with\n"
   "@param vec Collision impact vector\n"
   "@param len Length of the impact vector\n" );

//////////////////////////////////////////////////////////////////////////
// Constructor/Destructor
//////////////////////////////////////////////////////////////////////////

AnimationBehavior::AnimationBehavior()
{
	mNetFlags.set(Ghostable | ScopeAlways);

	mNetworked = true;
}

AnimationBehavior::~AnimationBehavior()
{
   for(S32 i = 0;i < mFields.size();++i)
   {
      BehaviorField &field = mFields[i];
      SAFE_DELETE_ARRAY(field.mFieldDescription);
   }

   SAFE_DELETE_ARRAY(mDescription);
}

IMPLEMENT_CO_NETOBJECT_V1(AnimationBehavior);

//////////////////////////////////////////////////////////////////////////
BehaviorInstance *AnimationBehavior::createInstance()
{
   AnimationBehaviorInstance *instance = new AnimationBehaviorInstance(this);

   setupFields( instance );

   if(instance->registerObject())
      return instance;

   delete instance;
   return NULL;
}

bool AnimationBehavior::onAdd()
{
   if(! Parent::onAdd())
      return false;

   return true;
}

void AnimationBehavior::onRemove()
{
   Parent::onRemove();
}
void AnimationBehavior::initPersistFields()
{
   Parent::initPersistFields();
}

U32 AnimationBehavior::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);
	return retMask;
}

void AnimationBehavior::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);
}

/*void AnimationBehavior::handleEvent(const char* eventName, Vector<const char*> eventParams)
{
	if(!dStrcmp("playAnimation", eventName))
	{
		
	}
}*/

//==========================================================================================
//==========================================================================================
AnimationBehaviorInstance::AnimationBehaviorInstance( BehaviorTemplate *btemplate ) 
{
   mTemplate = btemplate;
   mBehaviorOwner = NULL;

   for (U32 i = 0; i < MaxScriptThreads; i++) {
      mAnimationThreads[i].sequence = -1;
      mAnimationThreads[i].thread = 0;
      mAnimationThreads[i].sound = 0;
      mAnimationThreads[i].state = Thread::Stop;
      mAnimationThreads[i].atEnd = false;
	   mAnimationThreads[i].timescale = 1.f;
	   mAnimationThreads[i].position = -1.f;
   }

   mNetFlags.set(Ghostable);
}

AnimationBehaviorInstance::~AnimationBehaviorInstance()
{
}
IMPLEMENT_CO_NETOBJECT_V1(AnimationBehaviorInstance);

bool AnimationBehaviorInstance::onAdd()
{
   if(! Parent::onAdd())
      return false;

   for (U32 i = 0; i < MaxScriptThreads; i++) {
         Thread& st = mAnimationThreads[i];
         if (st.sequence != -1) {
            // TG: Need to see about suppressing non-cyclic sounds
            // if the sequences were activated before the object was
            // ghosted.
            // TG: Cyclic animations need to have a random pos if
            // they were started before the object was ghosted.

            // If there was something running on the old shape, the thread
            // needs to be reset. Otherwise we assume that it's been
            // initialized either by the constructor or from the server.
            bool reset = st.thread != 0;
            st.thread = 0;
            
            //st.sequence = getShapeBehavior()->getShape()->getShape()->findSequence( prevSeqName );

            if ( st.sequence != -1 )
            {
               setThreadSequence( i, st.sequence, reset );                              
            }            
         }

		 if(st.thread)
			updateThread(st);
      }

   return true;
}

void AnimationBehaviorInstance::onRemove()
{
   Parent::onRemove();
}

//This is mostly a catch for situations where the behavior is re-added to the object and the like and we may need to force an update to the behavior
void AnimationBehaviorInstance::onBehaviorAdd()
{
   Parent::onBehaviorAdd();
}

void AnimationBehaviorInstance::onBehaviorRemove()
{
   Parent::onBehaviorRemove();
}

void AnimationBehaviorInstance::initPersistFields()
{
   Parent::initPersistFields();
}

U32 AnimationBehaviorInstance::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);

	if( mask & (ThreadMask))
	{
		if(!mBehaviorOwner)
		{
			stream->writeFlag( false );
		}
		else if( con->getGhostIndex(mBehaviorOwner) != -1 )
		{
			stream->writeFlag( true );
			for (int i = 0; i < MaxScriptThreads; i++) 
			{
				Thread& st = mAnimationThreads[i];
				if (stream->writeFlag( (st.sequence != -1 || st.state == Thread::Destroy) && (mask & (ThreadMaskN << i)) ) ) 
				{
					stream->writeInt(st.sequence,ThreadSequenceBits);
					stream->writeInt(st.state,2);
					stream->write(st.timescale);
					stream->write(st.position);
					stream->writeFlag(st.atEnd);
				}
			}
		}
		else
		{
			for (int i = 0; i < MaxScriptThreads; i++) 
				if(mask & (ThreadMaskN << i))
					retMask |= ThreadMaskN << i; //try it again untill our dependency is ghosted

			stream->writeFlag( false );
		}
	}

	/*if (stream->writeFlag(mask & ThreadMask)) {
      for (int i = 0; i < MaxScriptThreads; i++) {
         Thread& st = mAnimationThreads[i];
         if (stream->writeFlag( (st.sequence != -1 || st.state == Thread::Destroy) && (mask & (ThreadMaskN << i)) ) ) {
            stream->writeInt(st.sequence,ThreadSequenceBits);
            stream->writeInt(st.state,2);
            stream->write(st.timescale);
            stream->write(st.position);
            stream->writeFlag(st.atEnd);
         }
      }
   }*/

	return retMask;
}

void AnimationBehaviorInstance::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);

	if (stream->readFlag()) 
	{
      for (S32 i = 0; i < MaxScriptThreads; i++) 
		{
         if (stream->readFlag()) 
			{
            Thread& st = mAnimationThreads[i];
            U32 seq = stream->readInt(ThreadSequenceBits);
            st.state = stream->readInt(2);
				stream->read( &st.timescale );
				stream->read( &st.position );
            st.atEnd = stream->readFlag();
            if (!st.thread || st.sequence != seq && st.state != Thread::Destroy)
               setThreadSequence(i,seq,false);
            else
               updateThread(st);
         }
      }
   }
}

void AnimationBehaviorInstance::processTick(const Move* move)
{
	Parent::processTick(move);

	if (isServerObject()) {
		// Server only...
		advanceThreads(TickSec);

		//draw the bones as points
		/*if(gEditingMission)
		{
			getShapeBehavior()->getShape()->animate();
			S32 boneCount = getShapeBehavior()->getShape()->getShape()->nodes.size();
			for(S32 i=0; i < boneCount; i++)
			{
				MatrixF mountTransform = getShapeBehavior()->getShape()->mNodeTransforms[i];
				//mountTransform.mul( xfm );
				//const Point3F& scale = mBehaviorOwner->getScale();

				// The position of the mount point needs to be scaled.
				//Point3F position = mountTransform.getPosition();
				//position.convolve( scale );
				//mountTransform.setPosition( position );

				//mountTransform.mul(mBehaviorOwner->getObjToWorld());

				DebugDrawer * debugDraw = DebugDrawer::get();  
				if (debugDraw)  
				{  
					Point3F min = mountTransform.getPosition() + Point3F(-0.1,-0.1,-0.1);
					Point3F max = mountTransform.getPosition() + Point3F(0.1,0.1,0.1);

					debugDraw->drawBox(min, max, ColorI(255, 255, 255, 128));
					debugDraw->setLastTTL(TickSec);
				} 
			}
		}*/
	}
}

void AnimationBehaviorInstance::advanceTime(F32 dt)
{
	Parent::advanceTime(dt);

   // On the client, the shape threads and images are
   // advanced at framerate.
   advanceThreads(dt);
}
//
const char *AnimationBehaviorInstance::getThreadSequenceName( U32 slot )
{
	Thread& st = mAnimationThreads[slot];
	if ( st.sequence == -1 )
	{
		// Invalid Animation.
		return "";
	}

	// Name Index
	const U32 nameIndex = getShapeBehavior()->getShape()->getShape()->sequences[st.sequence].nameIndex;

	// Return Name.
	return getShapeBehavior()->getShape()->getShape()->getName( nameIndex );
}

bool AnimationBehaviorInstance::setThreadSequence(U32 slot, S32 seq, bool reset, bool transition, F32 transTime)
{
   if(!getShapeBehavior())
	   return false;

   Thread& st = mAnimationThreads[slot];
   if (st.thread && st.sequence == seq && st.state == Thread::Play)
      return true;

   // Handle a -1 sequence, as this may be set when a thread has been destroyed.
   if(seq == -1)
      return true;

   if (seq < MaxSequenceIndex)
	{
      setMaskBits(ThreadMaskN << slot);
      st.sequence = seq;

      if (reset)
		{
         st.state = Thread::Play;
         st.atEnd = false;
		 st.timescale = 1.f;
		 st.position = 0.f;
      }

      if (getShapeBehavior()->getShape()) 
		{
         if (!st.thread)
            st.thread = getShapeBehavior()->getShape()->addThread();

			if(transition)
			{
				getShapeBehavior()->getShape()->transitionToSequence(st.thread, seq, st.position, transTime, true);
			}
			else
			{
				getShapeBehavior()->getShape()->setSequence(st.thread,seq,0);
				stopThreadSound(st);
			}

			updateThread(st);
      }
      return true;
   }
   return false;
}

S32 AnimationBehaviorInstance::getThreadSequenceID(S32 slot)
{
	if (slot >= 0 && slot < AnimationBehaviorInstance::MaxScriptThreads) 
	{ 
		return mAnimationThreads[slot].sequence; 
	} 
	else 
	{ 
		return -1; 
	}
}

void AnimationBehaviorInstance::updateThread(Thread& st)
{
	switch (st.state)
	{
		case Thread::Stop:
			{
				getShapeBehavior()->getShape()->setTimeScale( st.thread, 1.f );
				getShapeBehavior()->getShape()->setPos( st.thread, ( st.timescale > 0.f ) ? 0.0f : 1.0f );
			} // Drop through to pause state

		case Thread::Pause:
			{
				if ( st.position != -1.f )
				{
					getShapeBehavior()->getShape()->setTimeScale( st.thread, 1.f );
					getShapeBehavior()->getShape()->setPos( st.thread, st.position );
				}

				getShapeBehavior()->getShape()->setTimeScale( st.thread, 0.f );
				stopThreadSound( st );
			} break;

		case Thread::Play:
			{
				if (st.atEnd)
				{
					getShapeBehavior()->getShape()->setTimeScale(st.thread,1);
					getShapeBehavior()->getShape()->setPos( st.thread, ( st.timescale > 0.f ) ? 1.0f : 0.0f );
					getShapeBehavior()->getShape()->setTimeScale(st.thread,0);
					stopThreadSound(st);
               st.state = Thread::Stop;
				}
				else
				{
					if ( st.position != -1.f )
					{
						getShapeBehavior()->getShape()->setTimeScale( st.thread, 1.f );
						getShapeBehavior()->getShape()->setPos( st.thread, st.position );
					}

					getShapeBehavior()->getShape()->setTimeScale(st.thread, st.timescale );
					if (!st.sound)
					{
						startSequenceSound(st);
					}
				}
			} break;

      case Thread::Destroy:
         {
				stopThreadSound(st);
            st.atEnd = true;
            st.sequence = -1;
            if(st.thread)
            {
               getShapeBehavior()->getShape()->destroyThread(st.thread);
               st.thread = 0;
            }
         } break;
	}
}

bool AnimationBehaviorInstance::stopThread(U32 slot)
{
   Thread& st = mAnimationThreads[slot];
   if (st.sequence != -1 && st.state != Thread::Stop) {
      setMaskBits(ThreadMaskN << slot);
      st.state = Thread::Stop;
      updateThread(st);
      return true;
   }
   return false;
}

bool AnimationBehaviorInstance::destroyThread(U32 slot)
{
   Thread& st = mAnimationThreads[slot];
   if (st.sequence != -1 && st.state != Thread::Destroy) {
      setMaskBits(ThreadMaskN << slot);
      st.state = Thread::Destroy;
      updateThread(st);
      return true;
   }
   return false;
}

bool AnimationBehaviorInstance::pauseThread(U32 slot)
{
   Thread& st = mAnimationThreads[slot];
   if (st.sequence != -1 && st.state != Thread::Pause) {
      setMaskBits(ThreadMaskN << slot);
      st.state = Thread::Pause;
      updateThread(st);
      return true;
   }
   return false;
}

bool AnimationBehaviorInstance::playThread(U32 slot)
{
   Thread& st = mAnimationThreads[slot];
   if (st.sequence != -1 && st.state != Thread::Play) {
      setMaskBits(ThreadMaskN << slot);
      st.state = Thread::Play;
      updateThread(st);
      return true;
   }
   return false;
}

bool AnimationBehaviorInstance::setThreadPosition( U32 slot, F32 pos )
{
	Thread& st = mAnimationThreads[slot];
	if (st.sequence != -1)
	{
		setMaskBits(ThreadMaskN << slot);
		st.position = pos;
		st.atEnd = false;
		updateThread(st);

		return true;
	}
	return false;
}

bool AnimationBehaviorInstance::setThreadDir(U32 slot,bool forward)
{
	Thread& st = mAnimationThreads[slot];
	if (st.sequence != -1)
	{
		if ( ( st.timescale >= 0.f ) != forward )
		{
			setMaskBits(ThreadMaskN << slot);
			st.timescale *= -1.f ;
			st.atEnd = false;
			updateThread(st);
		}
		return true;
	}
	return false;
}

bool AnimationBehaviorInstance::setThreadTimeScale( U32 slot, F32 timeScale )
{
	Thread& st = mAnimationThreads[slot];
	if (st.sequence != -1)
	{
		if (st.timescale != timeScale)
		{
			setMaskBits(ThreadMaskN << slot);
			st.timescale = timeScale;
			updateThread(st);
		}
		return true;
	}
	return false;
}

void AnimationBehaviorInstance::stopThreadSound(Thread& thread)
{
   if (thread.sound) {
   }
}

void AnimationBehaviorInstance::startSequenceSound(Thread& thread)
{
   if (!isGhost() || !thread.thread)
      return;
   stopThreadSound(thread);
}

void AnimationBehaviorInstance::advanceThreads(F32 dt)
{
   for (U32 i = 0; i < MaxScriptThreads; i++) 
	{
      Thread& st = mAnimationThreads[i];
      if (st.thread) 
		{
         if (!getShapeBehavior()->getShape()->getShape()->sequences[st.sequence].isCyclic() && !st.atEnd &&
			 ( ( st.timescale > 0.f )? getShapeBehavior()->getShape()->getPos(st.thread) >= 1.0:
              getShapeBehavior()->getShape()->getPos(st.thread) <= 0)) 
			{
            st.atEnd = true;
            updateThread(st);
            
				if (!isGhost()) 
				{
					//onAnimationEnd_callback(this, st.thread->getSequenceName());
					Con::executef(this, "onAnimationEnd", st.thread->getSequenceName());
				}
				Vector<const char*> arg;
				arg.push_back(st.thread->getSequenceName());
				((Entity*)mBehaviorOwner)->pushEvent("animationEnd", arg);
         }

         // Make sure the thread is still valid after the call to onEndSequence_callback().
         // Someone could have called destroyThread() while in there.
         if(st.thread)
         {
            getShapeBehavior()->getShape()->advanceTime(dt,st.thread);
         }

			if (getShapeBehavior()->getShape() && !isGhost()) 
			{  
				for (U32 i = 1; i < 32; i++)
				{  
					if (getShapeBehavior()->getShape()->getTriggerState(i)) 
					{  
						const char* animName = st.thread->getSequenceName().c_str();
						onAnimationTrigger_callback(this,animName,i);  

						Vector<const char*> arg;
						arg.push_back(st.thread->getSequenceName());
						//TODO: add trigger ID
						((Entity*)mBehaviorOwner)->pushEvent("animationTrigger", arg);
					}  
				}  
			}
      }
   }
}

//Checks if we have a shape
RenderShapeBehaviorInstance* AnimationBehaviorInstance::getShapeBehavior()
{
	BehaviorInstance* bI = mBehaviorOwner->getBehavior<RenderShapeBehaviorInstance>();
   //BehaviorInstance* bI = mBehaviorOwner->getBehavior( "RenderShapeBehavior" );
   if(!bI || !bI->isEnabled())
	  return NULL; 

   return (reinterpret_cast<RenderShapeBehaviorInstance*>(bI));
}

S32 AnimationBehaviorInstance::getAnimationCount()
{
	RenderShapeBehaviorInstance *rSI = getShapeBehavior();

	if(rSI)
		return rSI->getShape()->getShape()->sequences.size();
	else
		return 0;
	
}

S32 AnimationBehaviorInstance::getAnimationIndex( const char* name )
{
	RenderShapeBehaviorInstance *rSI = getShapeBehavior();

	if(rSI)
		return rSI->getShape()->getShape()->findSequence( name );
	else
		return -1;
}

const char* AnimationBehaviorInstance::getAnimationName(S32 index)
{
	RenderShapeBehaviorInstance *rSI = getShapeBehavior();

	if(rSI)
	{
		if(index >= 0 && index < rSI->getShape()->getShape()->sequences.size())
			return rSI->getShape()->getShape()->getName( rSI->getShape()->getShape()->sequences[index].nameIndex );
	}
	
	return "";
}

//
DefineEngineMethod( AnimationBehaviorInstance, playThread, bool, ( S32 slot, const char* name, bool transition, F32 transitionTime ), ( -1, "", true, 0.5 ),
   "@brief Start a new animation thread, or restart one that has been paused or "
   "stopped.\n\n"

   "@param slot thread slot to play. Valid range is 0 - 3)\n"  // 3 = AnimationBehaviorInstance::MaxScriptThreads-1
   "@param name name of the animation sequence to play in this slot. If not "
   "specified, the paused or stopped thread in this slot will be resumed.\n"
   "@return true if successful, false if failed\n\n"

   "@tsexample\n"
   "%obj.playThread( 0, \"ambient\" );      // Play the ambient sequence in slot 0\n"
   "%obj.setThreadTimeScale( 0, 0.5 );    // Play at half-speed\n"
   "%obj.pauseThread( 0 );                // Pause the sequence\n"
   "%obj.playThread( 0 );                 // Resume playback\n"
   "%obj.playThread( 0, \"spin\" );         // Replace the sequence in slot 0\n"
   "@endtsexample\n"
   
   "@see pauseThread()\n"
   "@see stopThread()\n"
   "@see setThreadDir()\n"
   "@see setThreadTimeScale()\n"
   "@see destroyThread()\n")
{
   if (slot >= 0 && slot < AnimationBehaviorInstance::MaxScriptThreads) 
	{
      if (!dStrEqual(name, "")) 
		{
			if(object->getShapeBehavior())
			{
				if (object->getShapeBehavior()->getShape()->getShape()) 
				{
					S32 seq = object->getShapeBehavior()->getShape()->getShape()->findSequence(name);
					if (seq != -1 && object->setThreadSequence(slot,seq,true,transition,transitionTime))
					{
						return true;
					}
					else if(seq == -1)
					{
						//We tried to play a non-existaint sequence, so stop the thread just in case
						object->destroyThread(slot);
						return false;
					}
				}
			}
      }
      else
		{
         if (object->playThread(slot))
            return true;
		}
   }

   return false;
}

DefineEngineMethod( AnimationBehaviorInstance, setThreadDir, bool, ( S32 slot, bool fwd ),,
   "@brief Set the playback direction of an animation thread.\n\n"

   "@param slot thread slot to modify\n"
   "@param fwd true to play the animation forwards, false to play backwards\n"
   "@return true if successful, false if failed\n\n"
   
   "@see playThread()\n" )
{
   if (slot >= 0 && slot < AnimationBehaviorInstance::MaxScriptThreads) {
      if (object->setThreadDir(slot,fwd))
         return true;
   }
   return false;
}

DefineEngineMethod( AnimationBehaviorInstance, setThreadTimeScale, bool, ( S32 slot, F32 scale ),,
   "@brief Set the playback time scale of an animation thread.\n\n"

   "@param slot thread slot to modify\n"
   "@param scale new thread time scale (1=normal speed, 0.5=half speed etc)\n"
   "@return true if successful, false if failed\n\n"
   
   "@see playThread\n" )
{
   if (slot >= 0 && slot < AnimationBehaviorInstance::MaxScriptThreads) {
      if (object->setThreadTimeScale(slot,scale))
         return true;
   }
   return false;
}

DefineEngineMethod( AnimationBehaviorInstance, setThreadPosition, bool, ( S32 slot, F32 pos ),,
   "@brief Set the position within an animation thread.\n\n"

   "@param slot thread slot to modify\n"
   "@param pos position within thread\n"
   "@return true if successful, false if failed\n\n"
   
   "@see playThread\n" )
{
   if (slot >= 0 && slot < AnimationBehaviorInstance::MaxScriptThreads) {
      if (object->setThreadPosition(slot,pos))
         return true;
   }
   return false;
}

DefineEngineMethod( AnimationBehaviorInstance, setThreadAnimation, bool, ( S32 slot, const char* name ), ( "" ),
   "@brief Force-sets the animation in a particular thread without starting it playing."

   "@param slot thread slot to play. Valid range is 0 - 3)\n"  // 3 = AnimationBehaviorInstance::MaxScriptThreads-1
   "@param name name of the animation sequence to play in this slot. If not "
   "specified, the paused or stopped thread in this slot will be resumed.\n"
   "@return true if successful, false if failed\n\n")
{
   if (slot >= 0 && slot < AnimationBehaviorInstance::MaxScriptThreads) 
	{
      if (!dStrEqual(name, "")) 
		{
			if(object->getShapeBehavior())
			{
				if (object->getShapeBehavior()->getShape() && object->getShapeBehavior()->getShape()->getShape()) 
				{
					S32 seq = object->getShapeBehavior()->getShape()->getShape()->findSequence(name);
					if(object->getThreadSequenceID(slot) != seq)
					{
						object->destroyThread(slot);
						if (seq != -1)
						{
							object->setThreadSequence(slot,seq,false,false);
							S32 seqtest = object->getThreadSequenceID(slot);
							return true;
						}
					}
				}
			}
      }
      else
		{
         object->destroyThread(slot);
			return false;
		}
   }

   return false;
}

DefineEngineMethod( AnimationBehaviorInstance, stopThread, bool, ( S32 slot ),,
   "@brief Stop an animation thread.\n\n"

   "If restarted using playThread, the animation "
   "will start from the beginning again.\n"
   "@param slot thread slot to stop\n"
   "@return true if successful, false if failed\n\n"
   
   "@see playThread\n" )
{
   if (slot >= 0 && slot < AnimationBehaviorInstance::MaxScriptThreads) {
      if (object->stopThread(slot))
         return true;
   }
   return false;
}

DefineEngineMethod( AnimationBehaviorInstance, destroyThread, bool, ( S32 slot ),,
   "@brief Destroy an animation thread, which prevents it from playing.\n\n"

   "@param slot thread slot to destroy\n"
   "@return true if successful, false if failed\n\n"
   
   "@see playThread\n" )
{
   if (slot >= 0 && slot < AnimationBehaviorInstance::MaxScriptThreads) {
      if (object->destroyThread(slot))
         return true;
   }
   return false;
}

DefineEngineMethod( AnimationBehaviorInstance, pauseThread, bool, ( S32 slot ),,
   "@brief Pause an animation thread.\n\n"
   
   "If restarted using playThread, the animation "
   "will resume from the paused position.\n"
   "@param slot thread slot to stop\n"
   "@return true if successful, false if failed\n\n"
   
   "@see playThread\n" )
{
   if (slot >= 0 && slot < AnimationBehaviorInstance::MaxScriptThreads) {
      if (object->pauseThread(slot))
         return true;
   }
   return false;
}

DefineEngineMethod( AnimationBehaviorInstance, getAnimationCount, S32, ( ),,
   "Get the total number of sequences in the shape.\n"
   "@return the number of sequences in the shape\n\n" )
{
   return object->getAnimationCount();
}

DefineEngineMethod( AnimationBehaviorInstance, getAnimationIndex, S32, ( const char* name ),,
   "Find the index of the sequence with the given name.\n"
   "@param name name of the sequence to lookup\n"
   "@return index of the sequence with matching name, or -1 if not found\n\n"
   "@tsexample\n"
   "// Check if a given sequence exists in the shape\n"
   "if ( %this.getSequenceIndex( \"walk\" ) == -1 )\n"
   "   echo( \"Could not find 'walk' sequence\" );\n"
   "@endtsexample\n" )
{
   return object->getAnimationIndex( name );
}

DefineEngineMethod( AnimationBehaviorInstance, getAnimationName, const char*, ( S32 index ),,
   "Get the name of the indexed sequence.\n"
   "@param index index of the sequence to query (valid range is 0 - getSequenceCount()-1)\n"
   "@return the name of the sequence\n\n"
   "@tsexample\n"
   "// print the name of all sequences in the shape\n"
   "%count = %this.getSequenceCount();\n"
   "for ( %i = 0; %i < %count; %i++ )\n"
   "   echo( %i SPC %this.getSequenceName( %i ) );\n"
   "@endtsexample\n" )
{
   return object->getAnimationName(index);
}