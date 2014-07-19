//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#include "component/behaviors/behaviorTemplate.h"

#ifndef _AnimationBehavior_H_
#define _AnimationBehavior_H_

#ifndef _TSSHAPE_H_
	#include "ts/tsShapeInstance.h"
#endif
#ifndef _ENTITY_H_
   #include "T3D/Entity.h"
#endif
#ifndef _RENDERSHAPEBEHAVIOR_H_
	#include "component/behaviors/render/renderShapeBehavior.h"
#endif

class TSShapeInstance;
class TSThread;
class SceneRenderState;
class AnimationBehaviorInstance;
//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class AnimationBehavior : public BehaviorTemplate
{
   typedef BehaviorTemplate Parent;

public:
   AnimationBehavior();
   virtual ~AnimationBehavior();
   DECLARE_CONOBJECT(AnimationBehavior);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   //override to pass back a AnimationBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class AnimationBehaviorInstance : public BehaviorInstance
{
   typedef BehaviorInstance Parent;
public:
   enum PublicConstants {
      ThreadSequenceBits = 6,
      MaxSequenceIndex = (1 << ThreadSequenceBits) - 1,
	  MaxScriptThreads = 16,            ///< Should be a power of 2
	  
   };

   enum MaskBits {
      ThreadMaskN   = Parent::NextFreeMask << 0,
	   ThreadMask    = (ThreadMaskN << MaxScriptThreads) - ThreadMaskN,
		NextFreeMask  = ThreadMaskN << MaxScriptThreads
   };

protected:
   struct Thread {
      /// State of the animation thread.
      enum State {
         Play, Stop, Pause, Destroy
      };
      TSThread* thread; ///< Pointer to 3space data.
      U32 state;        ///< State of the thread
                        ///
                        ///  @see Thread::State
      S32 sequence;     ///< The animation sequence which is running in this thread.
	  F32 timescale;    ///< Timescale
      U32 sound;        ///< Handle to sound.
      bool atEnd;       ///< Are we at the end of this thread?
      F32 position;
   };

   Thread mAnimationThreads[MaxScriptThreads];

public:
   AnimationBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~AnimationBehaviorInstance();
   DECLARE_CONOBJECT(AnimationBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual void onBehaviorAdd();
   virtual void onBehaviorRemove();

   //virtual void handleEvent(const char* eventName, Vector<const char*> eventParams);

   //virtual bool setBehaviorSubField( const char *data );

    //shortcut function. finds if our owner has a renderShape behavior and gets the shape instance
    RenderShapeBehaviorInstance* getShapeBehavior();

    virtual void processTick(const Move* move);
	virtual void advanceTime(F32 dt);

	virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
	virtual void unpackUpdate(NetConnection *con, BitStream *stream);

    const char *getThreadSequenceName( U32 slot );
	bool setThreadSequence(U32 slot, S32 seq, bool reset = true, bool transition = true, F32 transitionTime = 0.5);
	void updateThread(Thread& st);
	bool stopThread(U32 slot);
	bool destroyThread(U32 slot);
	bool pauseThread(U32 slot);
	bool playThread(U32 slot);
	bool setThreadPosition( U32 slot, F32 pos );
	bool setThreadDir(U32 slot,bool forward);
	bool setThreadTimeScale( U32 slot, F32 timeScale );
	void stopThreadSound(Thread& thread);
	void startSequenceSound(Thread& thread);
	void advanceThreads(F32 dt);

	S32 getThreadSequenceID(S32 slot);

	//other helper functions
	S32 getAnimationCount();
	S32 getAnimationIndex( const char* name );
	const char* getAnimationName(S32 index);

	//callbacks
	DECLARE_CALLBACK( void, onAnimationStart, ( BehaviorInstance* obj, const String& animName ) );
	DECLARE_CALLBACK( void, onAnimationEnd, ( BehaviorInstance* obj, const char* animName ) );
	DECLARE_CALLBACK( void, onAnimationTrigger, ( BehaviorInstance* obj, const String& animName, S32 triggerID ) );
};

#endif // _BEHAVIORTEMPLATE_H_