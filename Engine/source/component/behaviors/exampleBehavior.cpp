//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
#include "console/consoleTypes.h"
#include "component/behaviors/exampleBehavior.h"
#include "core/util/safeDelete.h"
#include "console/consoleTypes.h"
#include "console/consoleObject.h"
#include "core/stream/bitStream.h"
#include "console/engineAPI.h"
#include "sim/netConnection.h"

//////////////////////////////////////////////////////////////////////////
// Constructor/Destructor
//////////////////////////////////////////////////////////////////////////

ExampleBehavior::ExampleBehavior()
{
	mNetFlags.set(Ghostable | ScopeAlways);
}

ExampleBehavior::~ExampleBehavior()
{
   for(S32 i = 0;i < mFields.size();++i)
   {
      BehaviorField &field = mFields[i];
      SAFE_DELETE_ARRAY(field.mFieldDescription);
   }

   SAFE_DELETE_ARRAY(mDescription);
}

IMPLEMENT_CO_NETOBJECT_V1(ExampleBehavior);

//////////////////////////////////////////////////////////////////////////
BehaviorInstance *ExampleBehavior::createInstance()
{
   ExampleBehaviorInstance *instance = new ExampleBehaviorInstance(this);

   setupFields( instance );

   if(instance->registerObject())
      return instance;

   delete instance;
   return NULL;
}

bool ExampleBehavior::onAdd()
{
   if(! Parent::onAdd())
      return false;

   return true;
}

void ExampleBehavior::onRemove()
{
   Parent::onRemove();
}
void ExampleBehavior::initPersistFields()
{
   Parent::initPersistFields();
}

U32 ExampleBehavior::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);
	return retMask;
}

void ExampleBehavior::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);
}

//==========================================================================================
//==========================================================================================
ExampleBehaviorInstance::ExampleBehaviorInstance( BehaviorTemplate *btemplate ) 
{
   mTemplate = btemplate;
   mBehaviorOwner = NULL;

   mNetFlags.set(Ghostable);
}

ExampleBehaviorInstance::~ExampleBehaviorInstance()
{
}
IMPLEMENT_CO_NETOBJECT_V1(ExampleBehaviorInstance);

bool ExampleBehaviorInstance::onAdd()
{
   if(! Parent::onAdd())
      return false;

   return true;
}

void ExampleBehaviorInstance::onRemove()
{
   Parent::onRemove();
}

//This is mostly a catch for situations where the behavior is re-added to the object and the like and we may need to force an update to the behavior
void ExampleBehaviorInstance::onBehaviorAdd()
{
   Parent::onBehaviorAdd();

   mBehaviorOwner->registerCachedInterface( "example", "doSomething", this, &mExampleInterface );
}

void ExampleBehaviorInstance::onBehaviorRemove()
{
   Parent::onBehaviorRemove();
}

void ExampleBehaviorInstance::initPersistFields()
{
   Parent::initPersistFields();
}

U32 ExampleBehaviorInstance::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);
	return retMask;
}

void ExampleBehaviorInstance::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);
}