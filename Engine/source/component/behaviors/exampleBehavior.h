//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
#ifndef _EXAMPLEBEHAVIOR_H_
#define _EXAMPLEBEHAVIOR_H_

#ifndef _BEHAVIORTEMPLATE_H_
	#include "component/behaviors/behaviorTemplate.h"
#endif

//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class ExampleBehavior : public BehaviorTemplate
{
   typedef BehaviorTemplate Parent;

public:
   ExampleBehavior();
   virtual ~ExampleBehavior();
   DECLARE_CONOBJECT(ExampleBehavior);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   //override to pass back a ExampleBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class ExampleBehaviorInstance : public BehaviorInstance
{
   typedef BehaviorInstance Parent;

   struct ExampleBehaviorInterface : public BehaviorInterface
   {
		inline bool doSomething()
		{
			ExampleBehaviorInstance *bI = reinterpret_cast<ExampleBehaviorInstance*>(getOwner());
			if(bI)
				return bI->doSomething();
			return false;
		}
   };

   ExampleBehaviorInterface mExampleInterface;

protected:
   bool doSomething() { return true; }

public:
   ExampleBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~ExampleBehaviorInstance();
   DECLARE_CONOBJECT(ExampleBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual void onBehaviorAdd();
   virtual void onBehaviorRemove();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);
};

#endif // _EXAMPLEBEHAVIOR_H_
