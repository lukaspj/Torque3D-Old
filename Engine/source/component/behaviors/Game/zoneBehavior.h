//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
#ifndef _ZONE_BEHAVIOR_H_
#define _ZONE_BEHAVIOR_H_

#ifndef _BEHAVIORTEMPLATE_H_
	#include "component/behaviors/behaviorTemplate.h"
#endif

//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class ZoneBehavior : public BehaviorTemplate
{
   typedef BehaviorTemplate Parent;

public:
   ZoneBehavior();
   virtual ~ZoneBehavior();
   DECLARE_CONOBJECT(ZoneBehavior);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   //override to pass back a ExampleBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class ZoneBehaviorInstance : public BehaviorInstance
{
   typedef BehaviorInstance Parent;

public:
   ZoneBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~ZoneBehaviorInstance();
   DECLARE_CONOBJECT(ZoneBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual void onBehaviorAdd();
   virtual void onBehaviorRemove();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);
};

#endif // _ZONE_BEHAVIOR_H_
