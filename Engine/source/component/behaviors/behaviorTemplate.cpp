//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#include "platform/platform.h"
#include "console/simBase.h"
#include "console/consoleTypes.h"
#include "component/behaviors/behaviorTemplate.h"
#include "core/util/safeDelete.h"
#include "core/resourceManager.h"
#include "core/stream/fileStream.h"
#include "core/stream/bitStream.h"

//////////////////////////////////////////////////////////////////////////
// Constructor/Destructor
//////////////////////////////////////////////////////////////////////////

BehaviorTemplate::BehaviorTemplate()
{
   mFriendlyName = StringTable->lookup("");
   mFromResource = StringTable->lookup("");
   mBehaviorType = StringTable->lookup("");
   mBehaviorGroup = StringTable->lookup("");
   mNetworkType = StringTable->lookup("");
   mTemplateName = StringTable->lookup("");
   //mDependency = StringTable->lookup("");

   mNetworked = false;

   // [tom, 1/12/2007] We manage the memory for the description since it
   // could be loaded from a file and thus massive. This is accomplished with
   // protected fields, but since they still call Con::getData() the field
   // needs to always be valid. This is pretty lame.
   mDescription = new char [1];
   ((char *)mDescription)[0] = 0;

   addBehaviorField("enabled", "Toggles if this behavior is active or not.", "bool", "1", "");

   mNetFlags.set(Ghostable);

   setScopeAlways();
}

BehaviorTemplate::~BehaviorTemplate()
{
   for(S32 i = 0;i < mFields.size();++i)
   {
      BehaviorField &field = mFields[i];
      SAFE_DELETE_ARRAY(field.mFieldDescription);
   }

   SAFE_DELETE_ARRAY(mDescription);
}

IMPLEMENT_CO_NETOBJECT_V1(BehaviorTemplate);

#define DECLARE_NATIVE_BEHAVIOR( BehaviorTemplate )                   \
	 BehaviorTemplate* staticBehaviorTemplate = new BehaviorTemplate; \
     Sim::gNativeBehaviorSet->addObject(staticBehaviorTemplate);

//////////////////////////////////////////////////////////////////////////

void BehaviorTemplate::initPersistFields()
{
   addGroup("Behavior");
	  addField("behaviorType", TypeCaseString, Offset(mBehaviorType, BehaviorTemplate), "The type of behavior.");
	  addField("networkType", TypeCaseString, Offset(mNetworkType, BehaviorTemplate), "The type of behavior.");
      addField("friendlyName", TypeCaseString, Offset(mFriendlyName, BehaviorTemplate), "Human friendly name of this behavior");
      addProtectedField("description", TypeCaseString, Offset(mDescription, BehaviorTemplate), &setDescription, &getDescription, new DefaultNonEmptyStringWriteFn(),
         "The description of this behavior which can be set to a \"string\" or a fileName\n");

	  addField("networked", TypeBool, Offset(mNetworked, BehaviorTemplate), "Is this behavior ghosted to clients?");
   endGroup("Behavior");

   Parent::initPersistFields();
}

//////////////////////////////////////////////////////////////////////////

bool BehaviorTemplate::setDescription( void *object, const char *index, const char *data )
{
   BehaviorTemplate *bT = static_cast<BehaviorTemplate *>(object);
   SAFE_DELETE_ARRAY(bT->mDescription);
   bT->mDescription = bT->getDescriptionText(data);

   // We return false since we don't want the console to mess with the data
   return false;
}

const char * BehaviorTemplate::getDescription(void* obj, const char* data)
{
   BehaviorTemplate *object = static_cast<BehaviorTemplate *>(obj);

   return object->mDescription ? object->mDescription : "";
}

//////////////////////////////////////////////////////////////////////////

bool BehaviorTemplate::onAdd()
{
   if(! Parent::onAdd())
      return false;

	setScopeAlways();

   setMaskBits(UpdateMask);

   Sim::gBehaviorSet->addObject(this);

   //force the callback
   //Con::executef(this, "onAdd");

   if(isServerObject()){
	   mTemplateName = Parent::getName();

	   if(mTemplateName == NULL || !dStrcmp(mTemplateName, ""))
		   mTemplateName = getClassRep()->getClassName();
   }

   return true;
}

void BehaviorTemplate::onRemove()
{
   Sim::gBehaviorSet->removeObject(this);

   Parent::onRemove();
}

U32 BehaviorTemplate::packUpdate(NetConnection *con, U32 mask, BitStream *stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);

	if(stream->writeFlag(mask & UpdateMask))
	{
		stream->writeString(mNetworkType);
		stream->writeString(mBehaviorType);
		stream->writeString(mTemplateName);
	}

	return retMask;
}

void BehaviorTemplate::unpackUpdate(NetConnection *con, BitStream *stream)
{
	Parent::unpackUpdate(con, stream);

	char buf[256];
	if(stream->readFlag()){
		stream->readString(buf);
		mNetworkType = StringTable->insert(buf);

		stream->readString(buf);
		mBehaviorType = StringTable->insert(buf);

		stream->readString(buf);
		mTemplateName = StringTable->insert(buf);
	}
}

//////////////////////////////////////////////////////////////////////////

 bool BehaviorTemplate::setupFields( BehaviorInstance *bi, bool forceSetup )
 {
    for(S32 i = 0;i < mFields.size();++i)
    {
       BehaviorField &field = mFields[i];

		 //check if this field already has data or not
		 //if it's blank, we're good to continue setting it.
		 //bi->getClassRep()->findField(
		 const char* data = bi->getDataField(StringTable->insert(field.mFieldName), NULL);

		 if(forceSetup || !dStrcmp(data, ""))
			bi->setDataField(field.mFieldName, NULL, field.mDefaultValue);
    }
 
    return true;
 }

//////////////////////////////////////////////////////////////////////////

void BehaviorTemplate::addBehaviorField(const char *fieldName, const char *desc, const char *type, const char *defaultValue /* = NULL */, const char *userData /* = NULL */, /*const char* dependency /* = NULL *//*,*/ bool hidden /* = false */)
{
   StringTableEntry stFieldName = StringTable->insert(fieldName);

   for(S32 i = 0;i < mFields.size();++i)
   {
      if(mFields[i].mFieldName == stFieldName)
         return;
   }

   BehaviorField field;
   field.mFieldName = stFieldName;
   field.mFieldType = StringTable->insert(type ? type : "");
   field.mUserData = StringTable->insert(userData ? userData : "");
   field.mDefaultValue = StringTable->insert(defaultValue ? defaultValue : "");
   field.mFieldDescription = getDescriptionText(desc);

   //field.mDependency = StringTable->insert(dependency ? dependency : "");

   field.mGroup = mBehaviorGroup;

   field.mHidden = hidden;

   mFields.push_back(field);
}

BehaviorTemplate::BehaviorField* BehaviorTemplate::getBehaviorField(const char *fieldName)
{
   StringTableEntry stFieldName = StringTable->insert(fieldName);

   for(S32 i = 0;i < mFields.size();++i)
   {
      if(mFields[i].mFieldName == stFieldName)
         return &mFields[i];
   }

   return NULL;
}
//////////////////////////////////////////////////////////////////////////

const char * BehaviorTemplate::getDescriptionText(const char *desc)
{
   if(desc == NULL)
      return NULL;

   char *newDesc;

   // [tom, 1/12/2007] If it isn't a file, just do it the easy way
   if(! Platform::isFile(desc))
   {
      newDesc = new char [dStrlen(desc) + 1];
      dStrcpy(newDesc, desc);

      return newDesc;
   }

   FileStream str;
   str.open( desc, Torque::FS::File::Read );

   Stream *stream = &str;
   if(stream == NULL){
	  str.close();
      return NULL;
   }

   U32 size = stream->getStreamSize();
   if(size > 0)
   {
      newDesc = new char [size + 1];
      if(stream->read(size, (void *)newDesc))
         newDesc[size] = 0;
      else
      {
         SAFE_DELETE_ARRAY(newDesc);
      }
   }

   str.close();
   delete stream;
   //ResourceManager->closeStream(stream);

   return newDesc;
}
//////////////////////////////////////////////////////////////////////////

BehaviorInstance *BehaviorTemplate::createInstance()
{
   BehaviorInstance *instance = new BehaviorInstance(this);

   setupFields( instance );

   if(instance->registerObject())
      return instance;

   delete instance;
   return NULL;
}

void BehaviorTemplate::pushUpdate()
{
	setMaskBits(UpdateMask);
}

void BehaviorTemplate::beginFieldGroup(const char* groupName)
{
	if(dStrcmp(mBehaviorGroup, ""))
	{
		Con::errorf("BehaviorTemplate: attempting to begin new field group with a group already begun!");
		return;
	}

	mBehaviorGroup = StringTable->insert(groupName);
}

void BehaviorTemplate::endFieldGroup()
{
	mBehaviorGroup = StringTable->insert("");
}

void BehaviorTemplate::addDependency(StringTableEntry name)
{
	mDependencies.push_back_unique(name);
}

//////////////////////////////////////////////////////////////////////////
// Console Methods
//////////////////////////////////////////////////////////////////////////
ConsoleMethod(BehaviorTemplate, beginGroup, void, 3, 3, "(groupName)\n"
              "Starts the grouping for following fields being added to be grouped into\n"
              "@param groupName The name of this group\n"
              "@param desc The Description of this field\n"
			  "@param type The DataType for this field (default, int, float, Point2F, bool, enum, Object, keybind, color)\n"
              "@param defaultValue The Default value for this field\n"
			  "@param userData An extra data field that can be used for custom data on a per-field basis<br>Usage for default types<br>"
			  "-enum: a TAB separated list of possible values<br>"
			  "-object: the T2D object type that are valid choices for the field.  The object types observe inheritance, so if you have a t2dSceneObject field you will be able to choose t2dStaticSrpites, t2dAnimatedSprites, etc.\n"
              "@return Nothing\n")
{
   object->beginFieldGroup(argv[2]);
}

ConsoleMethod(BehaviorTemplate, endGroup, void, 2, 2, "()\n"
              "Ends the grouping for prior fields being added to be grouped into\n"
              "@param groupName The name of this group\n"
              "@param desc The Description of this field\n"
			  "@param type The DataType for this field (default, int, float, Point2F, bool, enum, Object, keybind, color)\n"
              "@param defaultValue The Default value for this field\n"
			  "@param userData An extra data field that can be used for custom data on a per-field basis<br>Usage for default types<br>"
			  "-enum: a TAB separated list of possible values<br>"
			  "-object: the T2D object type that are valid choices for the field.  The object types observe inheritance, so if you have a t2dSceneObject field you will be able to choose t2dStaticSrpites, t2dAnimatedSprites, etc.\n"
              "@return Nothing\n")
{
   object->endFieldGroup();
}
ConsoleMethod(BehaviorTemplate, addBehaviorField, void, 5, 8, "(fieldName, desc, type, [defaultValue, userData, hidden])\n"
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
   const char *defValue = argc > 5 ? argv[5] : NULL;
   const char *typeInfo = argc > 6 ? argv[6] : NULL;
   bool hidden = argc > 7 ? dAtob(argv[7]) : false;
   
   object->addBehaviorField(argv[2], argv[3], argv[4], defValue, typeInfo, hidden);
}

ConsoleMethod(BehaviorTemplate, getBehaviorFieldCount, S32, 2, 2, "() - Get the number of BehaviorField's on this object\n"
              "@return Returns the number of BehaviorFields as a nonnegative integer\n")
{
   return object->getBehaviorFieldCount();
}

// [tom, 1/12/2007] Field accessors split into multiple methods to allow space
// for long descriptions and type data.

ConsoleMethod(BehaviorTemplate, getBehaviorField, const char *, 3, 3, "(int index) - Gets a Tab-Delimited list of information about a BehaviorField specified by Index\n"
              "@param index The index of the behavior\n"
			  "@return FieldName, FieldType and FieldDefaultValue, each separated by a TAB character.\n")
{
   BehaviorTemplate::BehaviorField *field = object->getBehaviorField(dAtoi(argv[2]));
   if(field == NULL)
      return "";

   char *buf = Con::getReturnBuffer(1024);
   dSprintf(buf, 1024, "%s\t%s\t%s\t%s", field->mFieldName, field->mFieldType, field->mDefaultValue, field->mGroup);

   return buf;
}

ConsoleMethod(BehaviorTemplate, setBehaviorField, const char *, 3, 3, "(int index) - Gets a Tab-Delimited list of information about a BehaviorField specified by Index\n"
              "@param index The index of the behavior\n"
			  "@return FieldName, FieldType and FieldDefaultValue, each separated by a TAB character.\n")
{
   BehaviorTemplate::BehaviorField *field = object->getBehaviorField(dAtoi(argv[2]));
   if(field == NULL)
      return "";

   char *buf = Con::getReturnBuffer(1024);
   dSprintf(buf, 1024, "%s\t%s\t%s", field->mFieldName, field->mFieldType, field->mDefaultValue);

   return buf;
}

ConsoleMethod(BehaviorTemplate, getBehaviorFieldUserData, const char *, 3, 3, "(int index) - Gets the UserData associated with a field by index in the field list\n"
			  "@param index The index of the behavior\n"
			  "@return Returns a string representing the user data of this field\n")
{
   BehaviorTemplate::BehaviorField *field = object->getBehaviorField(dAtoi(argv[2]));
   if(field == NULL)
      return "";

   return field->mUserData;
}

ConsoleMethod(BehaviorTemplate, getBehaviorFieldDescription, const char *, 3, 3, "(int index) - Gets a field description by index\n"
			  "@param index The index of the behavior\n"
              "@return Returns a string representing the description of this field\n")
{
   BehaviorTemplate::BehaviorField *field = object->getBehaviorField(dAtoi(argv[2]));
   if(field == NULL)
      return "";

   return field->mFieldDescription ? field->mFieldDescription : "";
}

ConsoleMethod(BehaviorTemplate, addDependency, void, 3, 3, "(string behaviorName) - Gets a field description by index\n"
			  "@param index The index of the behavior\n"
              "@return Returns a string representing the description of this field\n")
{
   object->addDependency(argv[2]);
}

//////////////////////////////////////////////////////////////////////////

ConsoleMethod(BehaviorTemplate, createInstance, S32, 2, 2, "() - Create an instance of this behavior\n"
			  "@return (BehaviorInstance inst) The behavior instance created")
{
   BehaviorInstance *inst = object->createInstance();
   return inst ? inst->getId() : 0;
}
