#include "component/behaviorObject.h"
#include "platform/platform.h"
#include "core/stream/bitStream.h"
#include "console/consoleTypes.h"
#include "console/consoleObject.h"
#include "sim/netConnection.h"
//#include "scene/sceneRenderState.h"
//#include "scene/sceneManager.h"
//#include "T3D/gameBase/gameProcess.h"
#include "console/engineAPI.h"
//#include "T3D/gameBase/gameConnection.h"
#include "math/mathIO.h"
//#include "component/behaviors/behaviorTemplate.h"
#include "math/mTransform.h"
#include "core/strings/stringUnit.h"
#include "core/frameAllocator.h"

extern ExprEvalState gEvalState;

IMPLEMENT_CO_NETOBJECT_V1(BehaviorObject);

BehaviorObject::BehaviorObject() : mInBehaviorCallback( false )
{
  SIMSET_SET_ASSOCIATION( mBehaviors );
}

bool BehaviorObject::onAdd()
{
	if( !Parent::onAdd() )
      return false;

	//we do this only on the server because loaded behaviors only exist in the mission file, which is loaded on the server. 
   //if(isServerObject())
		addBehaviors();

	return true;
}

void BehaviorObject::onRemove()
{
   // Remove all behaviors and notify
   clearBehaviors();

   // Call parent
   Parent::onRemove();
}

void BehaviorObject::onPostAdd()
{
	if(isServerObject())
	{
		for( SimSet::iterator i = mBehaviors.begin(); i != mBehaviors.end(); i++ )
		{
			BehaviorInstance *bI = dynamic_cast<BehaviorInstance *>( *i );

			bI->getTemplate()->setupFields( bI );

			//const char* fart = bI->getDataField(StringTable->insert("clientOwner"), NULL);

			//if(bI->isMethod("onAdd"))
			//	Con::executef(bI, "onAdd");
		}

		mLoadedBehaviors = true;
	}
}

void BehaviorObject::addObject( SimObject* object )
{
	//We'll structure this for now so that behaviors don't show up as leaf elements in the inspector tree.
	//Later on, we'll figure out how we can make them interactive via the inspector, such as drag-n-dropping 
	//or gathering sub-object data like bones from a rendershapebehavior's mesh so we can do stuff with them as well
	BehaviorInstance* bhvr = dynamic_cast<BehaviorInstance*>(object);
	if(bhvr)
	{
		addBehavior(bhvr); 
	}
	else
	{
		Parent::addObject(object);
	}
}

U32 BehaviorObject::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
   U32 retMask = Parent::packUpdate(con, mask, stream);

   //pass our behaviors around
   if( mask & BehaviorsMask || mask & InitialUpdateMask)
   {
		stream->writeFlag(true);
		//now, we run through a list of our to-be-sent behaviors and begin sending them
		//if any fail, we keep our list and re-queue the mask
		S32 behaviorCount = mToLoadBehaviors.size();

		//build our 'ready' list
		//This requires both the instance and the instances' template to be prepped(if the template hasn't been ghosted,
		//then we know we shouldn't be passing the instance's ghosts around yet)
		U32 ghostedBhvrCnt = 0;
		for(U32 i=0; i < behaviorCount; i++)
		{
			if(isBehaviorPackable(con, mToLoadBehaviors[i]) != -1)
				ghostedBhvrCnt++;
		}

		if(ghostedBhvrCnt != 0)
		{
			stream->writeFlag(true);

			stream->writeFlag(mStartBehaviorUpdate);

			//if not all the behaviors have been ghosted, we'll need another pass
			if(ghostedBhvrCnt != behaviorCount)
				retMask |= BehaviorsMask;

			//write the currently ghosted behavior count
			stream->writeInt(ghostedBhvrCnt, 16);

			for(U32 i=0; i < mToLoadBehaviors.size(); i++)
			{
				//now fetch them and pass the ghost
				S32 ghostIndex = isBehaviorPackable(con, mToLoadBehaviors[i]);
				if(ghostIndex != -1)
				{
					stream->writeInt(ghostIndex, NetConnection::GhostIdBitSize);
					mToLoadBehaviors.erase(i);
					i--;

					mStartBehaviorUpdate = false;
				}
			}
		}
		else if(behaviorCount)  
		{
			//on the odd chance we have behaviors to ghost, but NONE of them have been yet, just set the flag now
			stream->writeFlag(false);
			retMask |= BehaviorsMask;
		}
		else
			stream->writeFlag(false);
   }
	else
		stream->writeFlag(false);

   return retMask;
}

void BehaviorObject::unpackUpdate(NetConnection *con, BitStream *stream)
{
   Parent::unpackUpdate(con, stream);

	//Behavior Mask
   if( stream->readFlag() )
   {
		//are we passing any behaviors currently?
		if(stream->readFlag())
		{
			//if we've just started the update, clear our behaviors
			if(stream->readFlag())
				clearBehaviors(false);

			S32 behaviorCount = stream->readInt(16);
	   
			for(U32 i=0; i < behaviorCount; i++)
			{
				S32 gIndex = stream->readInt( NetConnection::GhostIdBitSize );
				addBehavior(dynamic_cast<BehaviorInstance*>( con->resolveGhost( gIndex ) ));		   
			}
		}
   }
}

S32 BehaviorObject::isBehaviorPackable(NetConnection *con, BehaviorInstance* bI)
{
	if(bI)
	{
		S32 ghostIdx = con->getGhostIndex(bI);
		S32 templateGhostIdx = con->getGhostIndex(bI->getTemplate());
		if(ghostIdx != -1 && templateGhostIdx != -1)
			return ghostIdx;
	}

	return -1;
}
//-----------------------------------------------------------
// Function name:  BehaviorObject::handlesConsoleMethod
// Summary:
//-----------------------------------------------------------
bool BehaviorObject::handlesConsoleMethod( const char *fname, S32 *routingId )
{
   // CodeReview [6/25/2007 justind]
   // If we're deleting the BehaviorObject, don't forward the call to the
   // behaviors, the parent onRemove will handle freeing them
   // This should really be handled better, and is in the Parent implementation
   // but behaviors are a special case because they always want to be called BEFORE
   // the parent to act.
   if( dStricmp( fname, "delete" ) == 0 )
      return Parent::handlesConsoleMethod( fname, routingId );

   // [neo, 5/10/2007 - #3010]
   // Make sure we honor the flag!
   /*if( !mInBehaviorCallback )
   {
      for( SimSet::iterator nItr = mBehaviors.begin(); nItr != mBehaviors.end(); nItr++ )
      {
         SimObject *pComponent = dynamic_cast<SimObject *>(*nItr);
         if( pComponent != NULL && pComponent->isMethod( fname ) )
         {
            *routingId = -2; // -2 denotes method on component
            return true;
         }
      }
   }*/

   // Let parent handle it
   return Parent::handlesConsoleMethod( fname, routingId );
}

const char *BehaviorObject::callMethod( S32 argc, const char* methodName, ... )
{
   const char *argv[128];
   methodName = StringTable->insert( methodName );

   argc++;

   va_list args;
   va_start(args, methodName);
   for(S32 i = 0; i < argc; i++)
      argv[i+2] = va_arg(args, const char *);
   va_end(args);

   // FIXME: the following seems a little excessive. I wonder why it's needed?
   argv[0] = methodName;
   argv[1] = methodName;
   argv[2] = methodName;

   return callMethodArgList( argc , argv );
}

#ifdef TORQUE_DEBUG
/// Inject Method Call.
void BehaviorObject::injectMethodCall( const char* method )
{
   // Get Call Method.
   StringTableEntry callMethod = StringTable->insert( method );

   // Find Call Method Metric.
   callMethodMetricType::Iterator itr = mCallMethodMetrics.find( callMethod );

   // Did we find the method?
   if ( itr == mCallMethodMetrics.end() )
   {
      // No, so set the call count to initially be 1.
      itr = mCallMethodMetrics.insert( callMethod, 1 );
   }
   else
   {
      // Increment Call Count.
      itr->value++;
   }
}
#endif

const char* BehaviorObject::callMethodArgList( U32 argc, const char *argv[], bool callThis)
{
#ifdef TORQUE_DEBUG
   injectMethodCall( argv[0] );
#endif

   return _callBehaviorMethod( argc, argv, callThis );
}

const char *BehaviorObject::_callMethod( U32 argc, const char *argv[], bool callThis )
{
	SimObject *pThis = dynamic_cast<SimObject *>( this );
	AssertFatal( pThis, "BehaviorObject::_callMethod : this should always exist!" );

	if( pThis == NULL )
	{
		char* empty = Con::getReturnBuffer(4);
		empty[0] = 0;

		return empty;
	}

	const char *cbName = StringTable->insert(argv[0]);

	// Set Owner Field
	const char* result = "";
	if(callThis)
		result = Con::execute( pThis, argc, argv, true ); // true - exec method onThisOnly, not on DCMCs

	return result;
}

// Call all components that implement methodName giving them a chance to operate
// Components are called in reverse order of addition
const char *BehaviorObject::_callBehaviorMethod( U32 argc, const char *argv[], bool callThis )
{   
	
   // [neo, 5/10/2007 - #3010]
   // We don't want behaviors to call a method on its owner which would recursively call it
   // again on the behavior and cause an infinite loop so we mark it when calling the behavior
   // method and trap it if it reenters and force it to call the method on this object.
   // This is a quick fix for now and I will review this before the end of the release.
   if( mBehaviors.empty())
	   return _callMethod( argc, argv, callThis );

   const char *cbName = StringTable->insert(argv[0]);
   const char* fnRet = "";

   //-JR
   //TODO: There are some odd outlier cases with callbacks during closing/disconnection, such as the setControl
   //where it doesn't correctly set the object id for the callback. we're forcing it here for now, but
   //we'll need to trackdown the actual problem later
   char idBuf[12];
   dSprintf(idBuf, sizeof(idBuf), "%d", this->getId());
   argv[1] = idBuf;

   if(mInBehaviorCallback)
	   return _callMethod(argc, argv, true);
   
   // CodeReview The tools ifdef here is because we don't want behaviors getting calls during
   //            design time.  For example an onCollision call when an object with collision
   //            enabled and an 'explode on collision' behavior is dragged over another object
   //            with collision enable in the scene while designing.   Is this incorrect? [2/27/2007 justind]
   // CodeReview [tom, 3/9/2007] That seems semi-sensible, unless you want some kind of 
   // behavior preview functionality in the editor. Something feels slightly wrong
   // about ifdef'ing this out, though.

   // Copy the arguments to avoid weird clobbery situations.
   FrameTemp<char *> argPtrs (argc);
   
   U32 strdupWatermark = FrameAllocator::getWaterMark();
   for( S32 i = 0; i < argc; i++ )
   {
      argPtrs[i] = reinterpret_cast<char *>( FrameAllocator::alloc( dStrlen( argv[i] ) + 1 ) );
      dStrcpy( argPtrs[i], argv[i] );
   }

   for( SimSet::iterator i = mBehaviors.begin(); i != mBehaviors.end(); i++ )
   {
      BehaviorInstance *pBehavior = dynamic_cast<BehaviorInstance *>( *i );
      AssertFatal( pBehavior, "BehaviorObject::_callBehaviorMethod - Bad behavior instance in list." );
      AssertFatal( pBehavior->getId() > 0, "Invalid id for behavior component" );

      if( pBehavior == NULL )
         continue;

      // Use the BehaviorInstance's namespace
      Namespace *pNamespace = pBehavior->getNamespace();
	  Namespace *tNamespace = pBehavior->getTemplateNamespace();
      if(!pNamespace && !tNamespace)
         continue;

      // Lookup the Callback Namespace entry and then splice callback
      Namespace::Entry *pNSEntry = pNamespace->lookup(cbName);
      if( pNSEntry )
      {
         // Set %this to our BehaviorInstance's Object ID
         argPtrs[1] = const_cast<char *>( pBehavior->getIdString() );

         // [neo, 5/10/2007 - #3010]
         // Set flag so we can call the method on this object directly, should the
         // behavior have 'overloaded' a method on the owner object.
         mInBehaviorCallback = true;

         // Change the Current Console object, execute, restore Object
         SimObject *save = gEvalState.thisObject;
         gEvalState.thisObject = pBehavior;
         fnRet = pNSEntry->execute(argc, const_cast<const char **>( ~argPtrs ), &gEvalState);
         gEvalState.thisObject = save;

         // [neo, 5/10/2007 - #3010]
         // Reset flag
         mInBehaviorCallback = false;
      }
	  
	  //Now try our template namespace, make sure we haven't returned something already
	  pNSEntry = tNamespace->lookup(cbName);
	  if(pNSEntry && (!fnRet || !fnRet[0]))
	  {
		 // Set %this to our BehaviorInstance's Object ID
         argPtrs[1] = const_cast<char *>( pBehavior->getIdString() );

         // [neo, 5/10/2007 - #3010]
         // Set flag so we can call the method on this object directly, should the
         // behavior have 'overloaded' a method on the owner object.
         mInBehaviorCallback = true;

         // Change the Current Console object, execute, restore Object
         SimObject *save = gEvalState.thisObject;
         gEvalState.thisObject = pBehavior;
         //const char *ret = pNSEntry->execute(argc, const_cast<const char **>( ~argPtrs ), &gEvalState);
		 fnRet = pNSEntry->execute(argc, const_cast<const char **>( ~argPtrs ), &gEvalState);
         gEvalState.thisObject = save;

         // [neo, 5/10/2007 - #3010]
         // Reset flag
         mInBehaviorCallback = false;
	  }
   }

   // Pass this up to the parent since a BehaviorObject is still a DynamicConsoleMethodComponent
   // it needs to be able to contain other components and behave properly
   if(!fnRet || !fnRet[0])
	   fnRet = _callMethod( argc, argv, callThis );
   else
	   _callMethod( argc, argv, callThis ); //we already have our return from elsewhere, so run it, but ignore the return

   // Clean up.
   FrameAllocator::setWaterMark( strdupWatermark );

   return fnRet;
}

//
void BehaviorObject::addBehaviors()
{
   //AssertFatal( mBehaviors.size() == 0, "BehaviorObject::addBehaviors() already called!" );

   const char *bField = "";
   const char *sField = "";

   // Check for data fields which contain packed behaviors, and instantiate them
   // As a side note, this is the most obfuscated conditional block I think I've ever written   
   for( int i = 0; dStrcmp( bField = getDataField( StringTable->insert( avar( "_behavior%d", i ) ), NULL ), "" ) != 0; i++ )
   {
      AssertFatal( ( StringUnit::getUnitCount( bField, "\t" ) - 1 ) % 2 == 0, "Fields should always be in sets of two!" );

      // Grab the template name, make sure the sim knows about it or we are hosed anyway
      StringTableEntry templateName = StringTable->insert( StringUnit::getUnit( bField, 0, "\t" ) );
      BehaviorTemplate *tpl = dynamic_cast<BehaviorTemplate *>( Sim::findObject( templateName ) );
      if( tpl == NULL )
      {
         // If anyone wants to know, let them.
         if( isMethod( "onBehaviorMissing" ) )
            Con::executef(this, "onBehaviorMissing", templateName );
         else
            Con::warnf("BehaviorObject::addBehaviors - Missing Behavior %s", templateName );

         // Skip it, it's invalid.
         setDataField( StringTable->insert( avar( "_behavior%d", i ) ), NULL, "" );

         continue;
      }

      // create instance
      BehaviorInstance *inst = tpl->createInstance();

      // Sub loop to set up the fields with the values that got written out
      S32 index = 1;
      while( index < StringUnit::getUnitCount( bField, "\t" ) )
      {
         StringTableEntry slotName = StringTable->insert( StringUnit::getUnit( bField, index++, "\t" ) );
         const char* slotValue = StringUnit::getUnit( bField, index++, "\t" );
         
		 //check if it's a regular behavior field, or one of our special instanced fields
		 if(!tpl->getBehaviorField(slotName))
			 inst->addBehaviorField(slotName, slotValue);
		 else
			 inst->setDataField( slotName, NULL, slotValue );
      }

      // Add to behaviors
      addBehavior( inst );

	  //check for sub fields to this
      for( int sfi = 1; dStrcmp( sField = getDataField( StringTable->insert( avar( "_behavior%d_%d", i, sfi ) ), NULL ), "" ) != 0; sfi++ )
	  {
		  S32 sindex = 0;
		  while( sindex < StringUnit::getUnitCount( sField, "\t" ) )
		  {
			 StringTableEntry slotName = StringTable->insert( StringUnit::getUnit( sField, sindex++, "\t" ) );
			 const char* slotValue = StringUnit::getUnit( sField, sindex++, "\t" );
			 
			 //check if it's a regular behavior field, or one of our special instanced fields
			 if(!tpl->getBehaviorField(slotName))
				 inst->addBehaviorField(slotName, slotValue);
			 else
				 inst->setDataField( slotName, NULL, slotValue );
		  }

		  setDataField( StringTable->insert( avar( "_behavior%d_%d", i, sfi ) ), NULL, "" );
	  }

	  //clear the dynamic fields of the behaviors so they're not cluttering the insepctor
	  setDataField( StringTable->insert( avar( "_behavior%d", i ) ), NULL, "" );
   }

   //Callback for letting scripts know we're done loading our behaviors
   if(isServerObject())
	   Con::executef(this, "onBehaviorsLoaded");

   //Now alert the behaviors they've been added for their callback
   for( SimSet::iterator b = mBehaviors.begin(); b != mBehaviors.end(); b++ )
   {
	   BehaviorInstance *bI = reinterpret_cast<BehaviorInstance *>(*b);

	   if(isServerObject()){
		   if(bI->isMethod("onAdd"))
				Con::executef(bI, "onAdd");
	   }
   }

   mLoadedBehaviors = true;
}

bool BehaviorObject::addBehavior( BehaviorInstance *bi )
{
	BehaviorTemplate *bT = bi->getTemplate();
	if( bi == NULL || !bi->isProperlyAdded())
      return false;

	if(bi->isServerObject())
		if(!bi->getTemplate())
			return false;

   mBehaviors.pushObject( bi );

   // Register the component with this owner.
   bi->setBehaviorOwner( this );

   // May want to look @ the return value here and optionally pushobject etc

	//updateBehaviors();
	if(bi->isServerObject())
		setBehaviorDirty(bi);

	//We're configured, so enable it
	bi->setEnabled(true);

	//And do the behavior onAdd callback
	//in case the behavior needs to do initializations on the owner
   bi->onBehaviorAdd(); 

   //update/check dependencies
   /*for(U32 i=0; i < mBehaviors.size(); i++)
   {
      
   }*/

   //and if this is a behavior added after the initial load, do our callback
   if(mLoadedBehaviors)
   {
	   if(isServerObject()){
		   if(bi->isMethod("onAdd"))
				Con::executef(bi, "onAdd");
	   }
   }

   return true;
}

//////////////////////////////////////////////////////////////////////////

bool BehaviorObject::removeBehavior( BehaviorInstance *bi, bool deleteBehavior )
{
   if( bi == NULL )
      return false;

   for( SimSet::iterator nItr = mBehaviors.begin(); nItr != mBehaviors.end(); nItr++ )
   {
      if( *nItr == bi )
      {
         mBehaviors.removeObject( *nItr );
		 //setMaskBits(BehaviorsMask);

         AssertFatal( bi->isProperlyAdded(), "Don't know how but a behavior instance is not registered w/ the sim" );

		 bi->onBehaviorRemove(); //in case the behavior needs to do cleanup on the owner

		 if( bi->isMethod("onRemove") )
			 Con::executef(bi, "onRemove" );

         if (deleteBehavior)
            bi->deleteObject();

         return true;
      }
   }

   return false;
}

//////////////////////////////////////////////////////////////////////////
//NOTE:
//The actor class calls this and flags the deletion of the behaviors to false so that behaviors that should no longer be attached during
//a network update will indeed be removed from the object. The reason it doesn't delete them is because when clearing the local behavior
//list, it would delete them, purging the ghost, and causing a crash when the unpack update tried to fetch any existing behaviors' ghosts
//to re-add them. Need to implement a clean clear function that will clear the local list, and only delete unused behaviors during an update.
void BehaviorObject::clearBehaviors(bool deleteBehaviors)
{
   while( mBehaviors.size() > 0 )
   {
      BehaviorInstance *bi = dynamic_cast<BehaviorInstance *>( mBehaviors.first() );
      removeBehavior( bi, deleteBehaviors);
   }
}

BehaviorInterface *BehaviorObject::getInterface(const char *type /* = NULL */, const char *name /* = NULL */, 
                                               const BehaviorInstance *owner /* = NULL */, bool notOwner /* = false  */)
{
   BehaviorInterfaceList iLst;

   if( getInterfaces( &iLst, type, name, owner, notOwner ) )
      return iLst[0];

   return NULL;
}

bool BehaviorObject::getInterfaces( BehaviorInterfaceList *list, const char *type /* = NULL */, const char *name /* = NULL  */,
                                 const BehaviorInstance *owner /* = NULL */, bool notOwner /* = false */ )
{
   AssertFatal( list != NULL, "Passing NULL for a list is not supported functionality for SimComponents." );
   return ( mInterfaceCache.enumerate( list, type, name, owner, notOwner ) > 0 );
}

bool BehaviorObject::registerCachedInterface( const char *type, const char *name, BehaviorInstance *interfaceOwner, BehaviorInterface *cinterface )
{
   if( mInterfaceCache.add( type, name, interfaceOwner, cinterface ) )
   {
      cinterface->mOwner = interfaceOwner;

      return true;
   }

   // So this is not a good assert, because it will get triggered due to the recursive
   // nature of interface caching. I want to keep it here, though, just so nobody
   // else thinks, "Oh I'll add an assert here."
   //
   //AssertFatal( false, avar( "registerCachedInterface failed, probably because interface with type '%s', name '%s' and owner with SimObjectId '%d' already exists",
   //   type, name, interfaceOwner->getId() ) );

   return false;
}

bool BehaviorObject::removeCachedInterface( const char *type, const char *name, BehaviorInstance *interfaceOwner )
{
   if( mInterfaceCache.remove( type, name, interfaceOwner ) )
      return true;

   return false;
}

//////////////////////////////////////////////////////////////////////////
BehaviorInstance *BehaviorObject::getBehavior( S32 index )
{
   if( index < mBehaviors.size() )
      return reinterpret_cast<BehaviorInstance *>(mBehaviors[index]);

   return NULL;
}

BehaviorInstance *BehaviorObject::getBehavior( BehaviorTemplate *bTemplate )
{
   for( SimSet::iterator b = mBehaviors.begin(); b != mBehaviors.end(); b++ )
   {
      // We can do this because both are in the string table
	  BehaviorInstance *bI = reinterpret_cast<BehaviorInstance *>(*b);

	  if(bI->getTemplate()->getId() == bTemplate->getId())
		  return bI;
   }

	return NULL;
}

BehaviorInstance *BehaviorObject::getBehavior( StringTableEntry behaviorTemplateName )
{
   for( SimSet::iterator b = mBehaviors.begin(); b != mBehaviors.end(); b++ )
   {
      // We can do this because both are in the string table
	  BehaviorInstance *bI = reinterpret_cast<BehaviorInstance *>(*b);
	  if(bI->getTemplate())
	  {
		  String dsgdh = bI->getTemplateName();
		  if(!dStrcmp(bI->getTemplateName(), behaviorTemplateName) 
			  || !dStrcmp(bI->getTemplate()->getBehaviorType(), behaviorTemplateName))
			 return reinterpret_cast<BehaviorInstance *>( *b );
	  }
   }

   return NULL;
}

BehaviorInstance *BehaviorObject::getBehaviorByType( StringTableEntry behaviorTypeName )
{
   for( SimSet::iterator b = mBehaviors.begin(); b != mBehaviors.end(); b++ )
   {
      // We can do this because both are in the string table
	   BehaviorInstance *bI = reinterpret_cast<BehaviorInstance *>(*b);
	   if(!dStrcmp(bI->getTemplate()->getBehaviorType(), behaviorTypeName))
		   return bI;
   }

   return NULL;
}

//////////////////////////////////////////////////////////////////////////

bool BehaviorObject::reOrder( BehaviorInstance *obj, U32 desiredIndex )
{
   if( desiredIndex > mBehaviors.size() )
      return false;

   SimObject *target = mBehaviors.at( desiredIndex );
   return mBehaviors.reOrder( obj, target );
}

//////////////////////////////////////////////////////////////////////////

void BehaviorObject::callOnBehaviors( String function )
{
   for( SimSet::iterator b = mBehaviors.begin(); b != mBehaviors.end(); b++ )
   {
		BehaviorInstance *bI = reinterpret_cast<BehaviorInstance *>(*b);
		if((bI)->isMethod(function.c_str()))
			Con::executef(bI, function);
   }
}

void BehaviorObject::updateBehaviors()
{
	for( SimSet::iterator b = mBehaviors.begin(); b != mBehaviors.end(); b++ )
   {
		// We can do this because both are in the string table
		BehaviorInstance *bI = reinterpret_cast<BehaviorInstance *>(*b);

		bI->update();
	}
}

void BehaviorObject::setBehaviorsDirty()
{ 
	if(mToLoadBehaviors.empty())
		mStartBehaviorUpdate = true;

	//we need to build a list of behaviors that need to be pushed across the network
	for( SimSet::iterator b = mBehaviors.begin(); b != mBehaviors.end(); b++ )
   {
      // We can do this because both are in the string table
	  BehaviorInstance *bI = reinterpret_cast<BehaviorInstance *>(*b);

		if(bI->getTemplate()->isNetworked())
		{
			bool unique = true;
			for(U32 i=0; i < mToLoadBehaviors.size(); i++)
			{	
				if(mToLoadBehaviors[i]->getId() == bI->getId())
				{
					unique = false;
					break;
				}
			}
			if(unique)
				mToLoadBehaviors.push_back(bI);
		}
	}

	setMaskBits(BehaviorsMask); 
}

void BehaviorObject::setBehaviorDirty(BehaviorInstance *bI, bool forceUpdate)
{ 
	SimSet::iterator itr = mBehaviors.find(mBehaviors.begin(), mBehaviors.end(), bI);

	if(!itr)
		return;

	//if(mToLoadBehaviors.empty())
	//	mStartBehaviorUpdate = true;

	if(bI->getTemplate()->isNetworked() || forceUpdate)
	{
		bool unique = true;
		for(U32 i=0; i < mToLoadBehaviors.size(); i++)
		{	
			if(mToLoadBehaviors[i]->getId() == bI->getId())
			{
				unique = false;
				break;
			}
		}
		if(unique)
			mToLoadBehaviors.push_back(bI);
	}

	setMaskBits(BehaviorsMask);
}

//
static void writeTabs(Stream &stream, U32 count)
{
   char tab[] = "   ";
   while(count--)
      stream.write(3, (void*)tab);
}

void BehaviorObject::write( Stream &stream, U32 tabStop, U32 flags )
{
   // Do *not* call parent on this

   /*VectorPtr<BehaviorObject *> &componentList = lockComponentList();
   // export selected only?
   if( ( flags & SelectedOnly ) && !isSelected() )
   {
      for( BehaviorObjectIterator i = componentList.begin(); i != componentList.end(); i++ )
         (*i)->write(stream, tabStop, flags);

      goto write_end;
   }*/

   //catch if we have any written behavior fields already in the file, and clear them. We don't need to double-up
   //the entries for no reason.
   /*if(getFieldDictionary())
   {
		//get our dynamic field count, then parse through them to see if they're a behavior or not

		//reset it
		SimFieldDictionary* fieldDictionary = getFieldDictionary();
		SimFieldDictionaryIterator itr(fieldDictionary);
		for (S32 i = 0; i < fieldDictionary->getNumFields(); i++)
		{
			if (!(*itr))
				break;
			
			SimFieldDictionary::Entry* entry = *itr;
			if(strstr(entry->slotName, "_behavior"))
			{
				entry->slotName = "";
				entry->value = "";
			}

			++itr;
		}
   }*/
   //all existing written behavior fields should be cleared. now write the object block

	writeTabs( stream, tabStop );
   char buffer[1024];
   dSprintf( buffer, sizeof(buffer), "new %s(%s) {\r\n", getClassName(), getName() ? getName() : "" );
   stream.write( dStrlen(buffer), buffer );
   writeFields( stream, tabStop + 1 );

	stream.write( 1, "\n" );
   ////first, write out our behavior objects

   // NOW we write the behavior fields proper
   if( mBehaviors.size() > 0 )
   {
      // Pack out the behaviors into fields
      U32 i = 0;
      for( SimSet::iterator b = mBehaviors.begin(); b != mBehaviors.end(); b++ )
      {
			BehaviorInstance *bi = dynamic_cast<BehaviorInstance*>(*b);

   		writeTabs( stream, tabStop + 1 );
			char buffer[1024];
			dSprintf( buffer, sizeof(buffer), "new %s(%s) {\r\n", bi->getClassName(), bi->getName() ? bi->getName() : "" );
			stream.write( dStrlen(buffer), buffer );
			//bi->writeFields( stream, tabStop + 2 );

			bi->packToStream( stream, tabStop + 2, i-1, flags );

         writeTabs( stream, tabStop + 1 );
			stream.write( 4, "};\r\n" );
      }
   }

   //
	stream.write(2, "\r\n");
	for(U32 i = 0; i < size(); i++)
	{
		SimObject* child = ( *this )[ i ];
		if( child->getCanSave() )
			child->write(stream, tabStop + 1, flags);
	}

   writeTabs( stream, tabStop );
   stream.write( 4, "};\r\n" );

//write_end:
   //unlockComponentList();
}

//Console Methods
DefineConsoleMethod( BehaviorObject, callOnBehaviors, void, (const char* functionName),,
   "Get the number of static fields on the object.\n"
   "@return The number of static fields defined on the object." )
{
   object->callOnBehaviors(functionName);
}

ConsoleMethod( BehaviorObject, callMethod, void, 3, 64 , "(methodName, argi) Calls script defined method\n"
			  "@param methodName The method's name as a string\n"
			  "@param argi Any arguments to pass to the method\n"
			  "@return No return value"
			  "@note %obj.callMethod( %methodName, %arg1, %arg2, ... );\n")

{
   object->callMethodArgList( argc - 1, argv + 2 );
}

ConsoleMethod( BehaviorObject, addBehaviors, void, 2, 2, "() - Add all fielded behaviors\n"
			  "@return No return value")
{
	object->addBehaviors();
}

ConsoleMethod( BehaviorObject, addBehavior, bool, 3, 3, "(BehaviorInstance bi) - Add a behavior to the object\n"
														   "@param bi The behavior instance to add"
														   "@return (bool success) Whether or not the behavior was successfully added")
{
	BehaviorInstance *bhvrInst = dynamic_cast<BehaviorInstance *>( Sim::findObject( argv[2] ) );
	
	if(bhvrInst != NULL)
	{
		bool success = object->addBehavior( bhvrInst );

		if(success)
		{
			//Placed here so we can differentiate against adding a new behavior during runtime, or when we load all
			//fielded behaviors on mission load. This way, we can ensure that we only call the callback
			//once everything is loaded. This avoids any problems with looking for behaviors that haven't been added yet, etc.
			if(bhvrInst->isMethod("onBehaviorAdd"))
			   Con::executef(bhvrInst, "onBehaviorAdd");
			return true;
		}
	}

	return false;
}

ConsoleMethod( BehaviorObject, removeBehavior, bool, 3, 4, "(BehaviorInstance bi, [bool deleteBehavior = true])\n"
															  "@param bi The behavior instance to remove\n"
															  "@param deleteBehavior Whether or not to delete the behavior\n"
															  "@return (bool success) Whether the behavior was successfully removed")
{
   bool deleteBehavior = true;
   if (argc > 3)
      deleteBehavior = dAtob(argv[3]);

   return object->removeBehavior( dynamic_cast<BehaviorInstance *>( Sim::findObject( argv[2] ) ), deleteBehavior );
}

ConsoleMethod( BehaviorObject, clearBehaviors, void, 2, 2, "() - Clear all behavior instances\n"
			  "@return No return value")
{
   object->clearBehaviors();
}

ConsoleMethod( BehaviorObject, getBehaviorByIndex, S32, 3, 3, "(int index) - Gets a particular behavior\n"
																 "@param index The index of the behavior to get\n"
																 "@return (BehaviorInstance bi) The behavior instance you requested")
{
   BehaviorInstance *bInstance = object->getBehavior( dAtoi(argv[2]) );

   return ( bInstance != NULL ) ? bInstance->getId() : 0;
}

ConsoleMethod( BehaviorObject, getBehavior, S32, 3, 3, "(BehaviorTemplate BehaviorTemplateName) - gets a behavior\n"
														  "@param BehaviorTemplateName The name of the template of the behavior instance you want\n"
														  "@return (BehaviorInstance bi) The behavior instance you requested")
{
   BehaviorTemplate* templ;
   if( !Sim::findObject( argv[ 2 ], templ ) )
   {
      Con::errorf( "%s::getBehavior(): invalid template: %s", argv[ 0 ], argv[ 2 ] );
      return 0;
   }
   
   BehaviorInstance *bInstance = object->getBehavior( templ );

   return ( bInstance != NULL ) ? bInstance->getId() : 0;
}

ConsoleMethod( BehaviorObject, getBehaviorByType, S32, 3, 3, "(string BehaviorTemplateName) - gets a behavior\n"
														  "@param BehaviorTemplateName The name of the template of the behavior instance you want\n"
														  "@return (BehaviorInstance bi) The behavior instance you requested")
{
   BehaviorInstance *bInstance = object->getBehaviorByType( StringTable->insert( argv[2] ) );

   return ( bInstance != NULL ) ? bInstance->getId() : 0;
}

ConsoleMethod( BehaviorObject, reOrder, bool, 3, 3, "(BehaviorInstance inst, [int desiredIndex = 0])\n"
													   "@param inst The behavior instance you want to reorder\n"
													   "@param desiredIndex The index you want the behavior instance to be reordered to\n"
													   "@return (bool success) Whether or not the behavior instance was successfully reordered" )
{
   BehaviorInstance *inst = dynamic_cast<BehaviorInstance *>( Sim::findObject( argv[1] ) );

   if( inst == NULL )
      return false;

   U32 idx = 0;
   if( argc > 2 )
      idx = dAtoi( argv[2] );

   return object->reOrder( inst, idx );
}

ConsoleMethod( BehaviorObject, getBehaviorCount, S32, 2, 2, "() - Get the count of behaviors on an object\n"
															   "@return (int count) The number of behaviors on an object")
{
   return object->getBehaviorCount();
}

DefineConsoleMethod( BehaviorObject, setBehaviorsDirty, void, (),,
   "Get the number of static fields on the object.\n"
   "@return The number of static fields defined on the object." )
{
   object->updateBehaviors();
}

DefineConsoleMethod( BehaviorObject, setBehaviorDirty, void, (S32 behaviorID, bool forceUpdate), ( 0, false ),
   "Get the number of static fields on the object.\n"
   "@return The number of static fields defined on the object." )
{
	BehaviorInstance* bI;
	if(Sim::findObject(behaviorID, bI))
		object->setBehaviorDirty(bI, forceUpdate);
}