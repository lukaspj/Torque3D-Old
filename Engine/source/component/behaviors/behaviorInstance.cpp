//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#include "component/behaviors/behaviorInstance.h"
#include "component/behaviors/behaviorTemplate.h"
#include "console/consoleTypes.h"
#include "console/consoleInternal.h"
#include "core/stream/bitStream.h"
#include "sim/netConnection.h"
#include "core/frameAllocator.h"
#include "console/engineAPI.h"

#include "T3D/gameBase/moveManager.h" //TEMP

#include "T3D/prefab.h"

extern ExprEvalState gEvalState;

//////////////////////////////////////////////////////////////////////////
// Callbacks
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CALLBACK( BehaviorInstance, Update, void, ( const char* move, const char* rot/*Point3F move, Point3F rot*/ ), ( move, rot ),
   "@brief Called when the player changes poses.\n\n"
   "@param obj The Player object\n"
   "@param oldPose The pose the player is switching from.\n"
   "@param newPose The pose the player is switching to.\n");

IMPLEMENT_CALLBACK( BehaviorInstance, onTrigger, void, ( U32 triggerID ), ( triggerID ),
   "@brief Called when the player changes poses.\n\n"
   "@param obj The Player object\n"
   "@param oldPose The pose the player is switching from.\n"
   "@param newPose The pose the player is switching to.\n");

//////////////////////////////////////////////////////////////////////////
// Constructor/Destructor
//////////////////////////////////////////////////////////////////////////

BehaviorInstance::BehaviorInstance( BehaviorTemplate *btemplate ) : mTemplate( btemplate )
{
   mBehaviorOwner = NULL;
   mTemplateNameSpace = NULL;
   mHidden = false;
   mEnabled = true;
	mInitialized = false;
}

BehaviorInstance::~BehaviorInstance()
{
}

IMPLEMENT_CO_NETOBJECT_V1(BehaviorInstance);

//////////////////////////////////////////////////////////////////////////

void BehaviorInstance::initPersistFields()
{
   addGroup("Behavior");
      addField("template", TypeSimObjectName, Offset(mTemplate, BehaviorInstance), "Template this instance was created from");
      // Read-only field, set always returns false
      addProtectedField( "Owner", TypeSimObjectPtr, Offset(mBehaviorOwner, BehaviorInstance), &setOwner, &defaultProtectedGetFn, new DefaultNonEmptyStringWriteFn(), "" );
	  addField("hidden", TypeBool, Offset(mHidden, BehaviorInstance), "Flags if this behavior is shown in the editor or not");
	  addField("enabled", TypeBool, Offset(mEnabled, BehaviorInstance), "Flags if this behavior is active or not");
   endGroup("Behavior");

   //addGroup( "Ungrouped" );

   /*  removeField("name");
                  
   endGroup( "Ungrouped" );

   addGroup( "Object" );

      removeField( "internalName", TypeString, Offset(mInternalName, SimObject), 
         "Optional name that may be used to lookup this object within a SimSet.");

      removeField( "parentGroup", TYPEID< SimObject >(), Offset(mGroup, SimObject), &setProtectedParent, &defaultProtectedGetFn, 
         "Group hierarchy parent of the object." );

      removeField( "class", TypeString, Offset(mClassName, SimObject), &setClass, &defaultProtectedGetFn,
         "Script class of object." );

      removeField( "superClass", TypeString, Offset(mSuperClassName, SimObject), &setSuperClass, &defaultProtectedGetFn,
         "Script super-class of object." );

      // For legacy support
      removeField( "className", TypeString, Offset(mClassName, SimObject), &setClass, &defaultProtectedGetFn,
         "Script class of object.", AbstractClassRep::FIELD_HideInInspectors );

   endGroup( "Object" );
   
   addGroup( "Editing" );
   
      addProtectedField( "hidden", TypeBool, NULL,
         &_setHidden, &_getHidden,
         "Whether the object is visible." );
      addProtectedField( "locked", TypeBool, NULL,
         &_setLocked, &_getLocked,
         "Whether the object can be edited." );
   
   endGroup( "Editing" );
   
   addGroup( "Persistence" );

      addProtectedField( "canSave", TypeBool, Offset( mFlags, SimObject ),
         &_setCanSave, &_getCanSave,
         "Whether the object can be saved out. If false, the object is purely transient in nature." );

      addField( "canSaveDynamicFields", TypeBool, Offset(mCanSaveFieldDictionary, SimObject), 
         "True if dynamic fields (added at runtime) should be saved. Defaults to true." );
   
      addProtectedField( "persistentId", TypePID, Offset( mPersistentId, SimObject ),
         &_setPersistentID, &defaultProtectedGetFn,
         "The universally unique identifier for the object." );
   
   endGroup( "Persistence" );*/

   Parent::initPersistFields();
}
//////////////////////////////////////////////////////////////////////////

bool BehaviorInstance::onAdd()
{
   if(! Parent::onAdd())
      return false;

   mNetFlags.set(Ghostable);

   setMaskBits(InitialUpdateMask);

   // Store this object's namespace
   mTemplateNameSpace = Namespace::global()->find(getTemplateName());
   //mNameSpace = getClassRep()->getNameSpace();

	if(mTemplate && isServerObject())
	{
		if(mTemplate->isNetworked())
			setScopeAlways();
	}

   return true;
}

void BehaviorInstance::onRemove()
{
   Parent::onRemove();
}

void BehaviorInstance::onBehaviorAdd()
{
	registerInterfaces();
}

void BehaviorInstance::onBehaviorRemove()
{
	unregisterInterfaces();
}

void BehaviorInstance::registerInterfaces()
{
	mBehaviorOwner->registerCachedInterface( "update", "processTick", this, &mUpdateInterface );
	mBehaviorOwner->registerCachedInterface( "update", "advanceTime", this, &mUpdateInterface );
	mBehaviorOwner->registerCachedInterface( "update", "interpolateTick", this, &mUpdateInterface );
}

void BehaviorInstance::unregisterInterfaces()
{
	mBehaviorOwner->removeCachedInterface( "update", "processTick", this );
	mBehaviorOwner->removeCachedInterface( "update", "advanceTime", this );
	mBehaviorOwner->removeCachedInterface( "update", "interpolateTick", this );
}

/*bool BehaviorInstance::isPackable(NetConnection *con)
{
	NetObject *n = con->resolveGhost(
	S32 gIndex = stream->readInt( NetConnection::GhostIdBitSize );
        mTemplate = dynamic_cast<BehaviorTemplate*>( con->resolveGhost( gIndex ) );

		gIndex = stream->readInt( NetConnection::GhostIdBitSize );
        mBehaviorOwner = dynamic_cast<BehaviorObject*>( con->resolveGhost( gIndex ) );
}*/

U32 BehaviorInstance::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retmask = Parent::packUpdate(con, mask, stream);

	if ( mask & InitialUpdateMask )
	{
		S32 tmpltGhostID = con->getGhostIndex(mTemplate);
		S32 ownerGhostID = con->getGhostIndex(mBehaviorOwner);

		if(tmpltGhostID != -1 && ownerGhostID != -1)
		{
			stream->writeFlag( true );
			stream->writeInt(tmpltGhostID, NetConnection::GhostIdBitSize);
			stream->writeInt(ownerGhostID, NetConnection::GhostIdBitSize);
		}
		else 
		{
			retmask |= InitialUpdateMask;
			stream->writeFlag( false );
		}
	}
	else
		stream->writeFlag( false );


	if(stream->writeFlag(mask & (EnableMask | InitialUpdateMask)))
		//mathWrite( *stream, colliderScale );
		stream->writeFlag(mEnabled);

	/*S32 ghostIndex = con->getGhostIndex(mTemplate);
	if(stream->writeFlag(ghostIndex != -1))	{
		stream->writeRangedU32(U32(ghostIndex), 0, NetConnection::MaxGhostCount);

		//pass our adjusted namespace, just incase we need it
		stream->writeString(mTemplateNameSpace->mName);
	}


	//and the owner
	if(stream->writeFlag(mBehaviorOwner != NULL && con->getGhostIndex(mBehaviorOwner) != -1))
	{
		ghostIndex = con->getGhostIndex(mBehaviorOwner);
		stream->writeRangedU32(U32(ghostIndex), 0, NetConnection::MaxGhostCount);
	}

	stream->writeFlag(mEnabled);*/

	return retmask;
}

void BehaviorInstance::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);

	//Update Mask
	if(stream->readFlag())
	{
		S32 gIndex = stream->readInt( NetConnection::GhostIdBitSize );
        mTemplate = dynamic_cast<BehaviorTemplate*>( con->resolveGhost( gIndex ) );

		gIndex = stream->readInt( NetConnection::GhostIdBitSize );
        mBehaviorOwner = dynamic_cast<BehaviorObject*>( con->resolveGhost( gIndex ) );
	}

	if(stream->readFlag())
		mEnabled = stream->readFlag();

	//check if our namespace exists, and initialize it if it doesn't
	/*if(!getNamespace())
	{
		if(isClientObject())
		{
		   SimObject *temp = new SimObject();
		   temp->assignName(mTemplate->getName());
		   delete temp;
		}
	}*/
}

//catch any behavior field updates
void BehaviorInstance::onStaticModified( const char* slotName, const char* newValue )
{
	Parent::onStaticModified(slotName, newValue);

	//If we don't have an owner yet, then this is probably the initial setup, so we don't need the console callbacks yet.
	if(!mBehaviorOwner)
		return;

	checkBehaviorFieldModified(slotName, newValue);
}

void BehaviorInstance::onDynamicModified( const char* slotName, const char* newValue )
{
	Parent::onDynamicModified(slotName, newValue);

	//If we don't have an owner yet, then this is probably the initial setup, so we don't need the console callbacks yet.
	if(!mBehaviorOwner)
		return;

	checkBehaviorFieldModified(slotName, newValue);
}

void BehaviorInstance::checkBehaviorFieldModified( const char* slotName, const char* newValue )
{
	//find if it's a behavior field
	for( int i = 0; i < mTemplate->getBehaviorFieldCount(); i++ )
    {
		BehaviorTemplate::BehaviorField *field = mTemplate->getBehaviorField( i );
		if(!dStrcmp(field->mFieldName, slotName))
		{
			//we have a match, do the script callback that we updated a field
			if(isMethod("onInspectorUpdate"))
				Con::executef(this, "onInspectorUpdate", slotName);

			/*BehaviorFieldInterface *bInterface = mBehaviorOwner->getInterface<BehaviorFieldInterface)();

			BehaviorInterface *bInterface = dynamic_cast<BehaviorFieldInterface*>(mBehaviorOwner->getInterface(NULL, "behaviorFieldUpdate", NULL));

			if(bInterface)
			{
				BehaviorFieldInterface *bInterface = dynamic_cast<BehaviorFieldInterface*>(bInterface)
				bInterface->onFieldChange(slotName, newValue);
			}*/
			//Lastly, notify up to our owner's parent(s). If one is a prefab, we inform it it's now dirty
			Prefab* p = Prefab::getPrefabByChild(mBehaviorOwner);
			if(p)
				p->setDirty();
			return;
		}
	}

	//if it's not in the template, it may still be a instance field, so check them too
	for( int i = 0; i < mBehaviorFields.size(); i++ )
    {
		if(!dStrcmp(mBehaviorFields[i].mFieldName, slotName))
		{
			//we have a match, do the script callback that we updated a field
			if(isMethod("onInspectorUpdate"))
				Con::executef(this, "onInspectorUpdate", slotName);

			/*BehaviorFieldInterface *bInterface = dynamic_cast<BehaviorFieldInterface*>(mBehaviorOwner->getInterface(NULL, "behaviorFieldUpdate", NULL));

			if(bInterface)
			{
				bInterface->onFieldChange(slotName, newValue);
			}*/
			//Lastly, notify up to our owner's parent(s). If one is a prefab, we inform it it's now dirty
			Prefab* p = Prefab::getPrefabByChild(mBehaviorOwner);
			if(p)
				p->setDirty();
			return;
		}
	}
}

//force it to update the masks
void BehaviorInstance::pushUpdate()
{
	setMaskBits(0xFFFFFFFF);
}

void BehaviorInstance::update()
{
	//check through our other behaviors and check that dependencies are met, etc.
	bool allMet = true;
	for(U32 i=0; i < mTemplate->mDependencies.size(); i++)
	{
		if(!mBehaviorOwner->getBehavior(mTemplate->mDependencies[i]))
			allMet = false;
	}

	if(allMet)
		mEnabled = true;
	else
		mEnabled = false;

	//then, push a networking update to ensure the client is up to date on everything
	pushUpdate();
}

bool BehaviorInstance::isMethod( const char* methodName )
{
	//return Parent::isMethod(methodName);
   if( !methodName || !methodName[0] )
      return false;

   StringTableEntry stname = StringTable->insert( methodName );

   if( getNamespace() )
   {
	   if(getNamespace()->lookup(stname) != NULL)
		   return true;
   }
   if( mTemplateNameSpace )
   {
	   if(mTemplateNameSpace->lookup(stname) != NULL)
		   return true;
   }

   return false;
}

const char *BehaviorInstance::callMethod( S32 argc, const char* methodName, ... )
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

bool BehaviorInstance::handlesConsoleMethod( const char *fname, S32 *routingId )
{
   // CodeReview [6/25/2007 justind]
   // If we're deleting the BehaviorObject, don't forward the call to the
   // behaviors, the parent onRemove will handle freeing them
   // This should really be handled better, and is in the Parent implementation
   // but behaviors are a special case because they always want to be called BEFORE
   // the parent to act.
   if( dStricmp( fname, "delete" ) == 0 )
      return Parent::handlesConsoleMethod( fname, routingId );

   if(isMethod( fname ))
   {
	   *routingId = -2;
	   return true;
   }

   // Let parent handle it
   return Parent::handlesConsoleMethod( fname, routingId );
}
//////////////////////////////////////////////////////////////////////////
void BehaviorInstance::packToStream( Stream &stream, U32 tabStop, S32 behaviorID, U32 flags /* = 0  */ )
{
   String bufString = "";
   S32 breakCount = 0;
   char buffer[1024];

   // This is a specialized write that just wants a single line which will represent the behavior
   // so it can be serialized. The stream should already be set up so all we have to do is write
   // out a string to the stream, and the calling method will take care of the rest.

   // Write out common info
	stream.writeTabs( tabStop );
   dSprintf( buffer, sizeof( buffer ), "template = \"%s\";\n", getTemplateName() );

   bufString = buffer;
   stream.write( dStrlen( buffer ), buffer );

   // Write out the fields which the behavior template knows about
   for( int i = 0; i < mTemplate->getBehaviorFieldCount(); i++ )
   {
      BehaviorTemplate::BehaviorField *field = mTemplate->getBehaviorField( i );
      const char *objFieldValue = getDataField( field->mFieldName, NULL );

      // If the field holds the same value as the template's default value than it
      // will get initialized by the template, and so it won't be included just
      // to try to keep the object files looking as non-horrible as possible.
      if( dStrcmp( field->mDefaultValue, objFieldValue ) != 0 )
      {
			dSprintf( buffer, sizeof( buffer ), "%s = \"%s\";\n", field->mFieldName, ( dStrlen( objFieldValue ) > 0 ? objFieldValue : "0" ) );

			stream.writeTabs( tabStop );
			stream.write( dStrlen( buffer ), buffer );
      }
   }

   //Catch any dynamic behavior fields we'd want to keep for later
   for( int i = 0; i < mBehaviorFields.size(); i++ )
   {
	    const char* fieldName = mBehaviorFields[i].mFieldName;
	    const char* fieldValue = getDataField(mBehaviorFields[i].mFieldName, NULL);
		dSprintf( buffer, sizeof( buffer ), "%s = %s;\n", fieldName, ( dStrlen( fieldValue ) > 0 ? fieldValue : "0" ) );

		stream.writeTabs( tabStop );
		stream.write( dStrlen( buffer ), buffer );
   }

   //stream.write(4, "\";\r\n" );
}

void BehaviorInstance::addBehaviorField(const char* fieldName, const char* value)
{
	//if this field already exists, just update it.
	for(U32 i=0; i < mBehaviorFields.size(); i++)
	{
		if(!dStrcmp(mBehaviorFields[i].mFieldName, fieldName)){
			mBehaviorFields[i].mDefaultValue = StringTable->insert(value);
			setDataField( mBehaviorFields[i].mFieldName, NULL, mBehaviorFields[i].mDefaultValue );
			return;
		}
	}

	//Otherwise, set the field up, and store it
	behaviorFields field;
	field.mFieldName = StringTable->insert(fieldName);
	field.mDefaultValue = StringTable->insert(value);

	mBehaviorFields.push_back(field);

	setDataField( field.mFieldName, NULL, field.mDefaultValue );
}

void BehaviorInstance::removeBehaviorField(const char* fieldName)
{
	for(U32 i=0; i < mBehaviorFields.size(); i++)
	{
		if(!dStrcmp(mBehaviorFields[i].mFieldName, fieldName)){
			mBehaviorFields.erase(i);
			return;
		}
	}

	setDataField( fieldName, NULL, "" );
}

const char * BehaviorInstance::getTemplateName()
{
   if(mTemplate)
   {
	   StringTableEntry name = mTemplate->getName();
	   return name ? name : "";
   }
   
   return "";
}

const char * BehaviorInstance::checkDependencies()
{
   char buffer[1024];

   for(U32 i=0; i < mTemplate->mDependencies.size(); i++)
   {
		if(mBehaviorOwner->getBehavior(mTemplate->mDependencies[i]) == NULL)
			dSprintf(buffer, 1024, "%s %s", buffer, mTemplate->mDependencies[i]);
   }
   
   return buffer;
}

/*void BehaviorInstance::setDataField(StringTableEntry slotName, const char *array, const char *value)
{
	Parent::setDataField(slotName, array, value);
	
	pushUpdate();
}

void BehaviorInstance::onStaticModified(const char* slotName, const char* newValue)
{
	Parent::onStaticModified(slotName, newValue);

	pushUpdate();
}

void BehaviorInstance::inspectPostApply()
{
   // Apply any transformations set in the editor
   Parent::inspectPostApply();

   if(isServerObject()) 
      setMaskBits(0xFFFFFFFF);
}*/
void BehaviorInstance::processTick(const Move* move)
{
	if( isServerObject() /*&& getTemplate()->isMethod("onProcessTick")*/)
	{
		String moveVec = "";
		String moveRot = "";

		if(move)
		{
			moveVec = String(Con::getFloatArg(move->x)) 
				+ " " + String(Con::getFloatArg(move->y)) + " " + String(Con::getFloatArg(move->z));

			moveRot = String(Con::getFloatArg(move->pitch)) 
				+ " " + String(Con::getFloatArg(move->roll)) + " " + String(Con::getFloatArg(move->yaw));
		}
		/*if(this->isMethod("Update"))
		{
			String moveVec = String(Con::getFloatArg(move->x)) 
				+ " " + String(Con::getFloatArg(move->y)) + " " + String(Con::getFloatArg(move->z));

			String moveRot = String(Con::getFloatArg(move->pitch)) 
				+ " " + String(Con::getFloatArg(move->roll)) + " " + String(Con::getFloatArg(move->yaw));

			Con::executef(this, "Update", moveVec.c_str(), moveRot.c_str());
		}*/

		//Point3F moveVec = Point3F(move->x, move->y, move->z);
		//Point3F moveRot = Point3F(move->pitch, move->roll, move->yaw);
		//Update_callback( moveVec, moveRot );

		if(this->isMethod("Update"))
			Con::executef(this, "Update", moveVec.c_str(), moveRot.c_str());

		if(move)
		{
			for(U32 i=0; i < MaxTriggerKeys; i++)
			{
				if(move->trigger[i] && this->isMethod("onMoveTrigger"))
					Con::executef(this, "onMoveTrigger", Con::getIntArg(i));
					//onTrigger_callback(i);
			}
		}
	}
}

//
template <class T>
T *BehaviorInstance::getInterface()
{
	if(mInterface)
		return static_cast<T *>( *this );

	return NULL;
}

//
const char* BehaviorInstance::callMethodArgList( U32 argc, const char *argv[], bool callThis /* = true  */ )
{
   // Set Owner
   SimObject *pThis = dynamic_cast<SimObject *>( this );
   AssertFatal( pThis, "DynamicConsoleMethodComponent::callMethod : this should always exist!" );

   if( pThis == NULL )
   {
      char* empty = Con::getReturnBuffer(4);
      empty[0] = 0;

      return empty;
   }

   const char *cbName = StringTable->insert(argv[0]);
   const char* fnRet = "";

   FrameTemp<char *> argPtrs (argc);
   
   U32 strdupWatermark = FrameAllocator::getWaterMark();
   for( S32 i = 0; i < argc; i++ )
   {
      argPtrs[i] = reinterpret_cast<char *>( FrameAllocator::alloc( dStrlen( argv[i] ) + 1 ) );
      dStrcpy( argPtrs[i], argv[i] );
   }
   
   // Use the BehaviorInstance's namespace
   Namespace *pNamespace = getNamespace();
   Namespace *tNamespace = getTemplateNamespace();
   if(!pNamespace && !tNamespace)
      return "";

   // Lookup the Callback Namespace entry and then splice callback
   Namespace::Entry *pNSEntry = tNamespace->lookup(cbName);
   if( pNSEntry )
   {
     // Set %this to our BehaviorInstance's Object ID
     argPtrs[1] = const_cast<char *>( getIdString() );

     // Change the Current Console object, execute, restore Object
     SimObject *save = gEvalState.thisObject;
     gEvalState.thisObject = this;
     fnRet = pNSEntry->execute(argc, const_cast<const char **>( ~argPtrs ), &gEvalState);
     gEvalState.thisObject = save;
	 return fnRet;
  }
  
  pNSEntry = pNamespace->lookup(cbName);
  if(pNSEntry && (!fnRet || !fnRet[0]))
  {
	 // Set %this to our BehaviorInstance's Object ID
     argPtrs[1] = const_cast<char *>( getIdString() );

     // Change the Current Console object, execute, restore Object
     SimObject *save = gEvalState.thisObject;
     gEvalState.thisObject = this;
     //const char *ret = pNSEntry->execute(argc, const_cast<const char **>( ~argPtrs ), &gEvalState);
	 fnRet = pNSEntry->execute(argc, const_cast<const char **>( ~argPtrs ), &gEvalState);
     gEvalState.thisObject = save;
	 return fnRet;
  }

   return fnRet;
}

//////////////////////////////////////////////////////////////////////////
// Console Methods
//////////////////////////////////////////////////////////////////////////
ConsoleMethod(BehaviorInstance, addBehaviorField, void, 4, 4, "(fieldName, value)\n"
              "Adds a named BehaviorField to a Behavior Template\n"
              "@param fieldName The name of this field\n"
              "@param desc The Description of this field\n"
			  "@param type The DataType for this field (default, int, float, Point2F, bool, enum, Object, keybind, color)\n"
              "@param defaultValue The Default value for this field\n"
			  "@param userData An extra data field that can be used for custom data on a per-field basis<br>Usage for default types<br>"
			  "-enum: a TAB separated list of possible values<br>"
			  "-object: the T2D object type that are valid choices for the field.  The object types observe inheritance, so if you have a t2dSceneObject field you will be able to choose t2dStaticSrpites, t2dAnimatedSprites, etc.\n"
              "@return Nothing\n")
{
   object->addBehaviorField(argv[2], argv[3]);
}

ConsoleMethod(BehaviorInstance, removeBehaviorField, void, 3, 3, "(fieldName)\n"
              "Adds a named BehaviorField to a Behavior Template\n"
              "@param fieldName The name of this field\n"
              "@param desc The Description of this field\n"
			  "@param type The DataType for this field (default, int, float, Point2F, bool, enum, Object, keybind, color)\n"
              "@param defaultValue The Default value for this field\n"
			  "@param userData An extra data field that can be used for custom data on a per-field basis<br>Usage for default types<br>"
			  "-enum: a TAB separated list of possible values<br>"
			  "-object: the T2D object type that are valid choices for the field.  The object types observe inheritance, so if you have a t2dSceneObject field you will be able to choose t2dStaticSrpites, t2dAnimatedSprites, etc.\n"
              "@return Nothing\n")
{
   object->removeBehaviorField(argv[2]);
}

ConsoleMethod(BehaviorInstance, getTemplateName, const char *, 2, 2, "() - Get the template name of this behavior\n"
																	 "@return (string name) The name of the template this behaivor was created from")
{
   const char *name = object->getTemplateName();
   return name ? name : "";
}

ConsoleMethod(BehaviorInstance, isEnabled, bool, 2, 2, "() - Get the template name of this behavior\n"
																	 "@return (string name) The name of the template this behaivor was created from")
{
   return object->isEnabled();
}

ConsoleMethod(BehaviorInstance, setEnabled, void, 3, 3, "() - Get the template name of this behavior\n"
																	 "@return (string name) The name of the template this behaivor was created from")
{
   object->setEnabled(dAtob(argv[2]));
}

ConsoleMethod(BehaviorInstance, forceUpdate, void, 2, 2, "() - We get the first behavior of the requested type on our owner object.\n"
																	 "@return (string name) The type of the behavior we're requesting")
{
	object->setMaskBits(0xFFFFFFFF);
}

DefineConsoleMethod( BehaviorInstance, inspectorApply, void, (),,
   "Get the number of static fields on the object.\n"
   "@return The number of static fields defined on the object." )
{
   object->inspectPostApply();
}