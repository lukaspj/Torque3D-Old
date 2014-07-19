//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#ifndef _BEHAVIORTEMPLATE_H_
#define _BEHAVIORTEMPLATE_H_

#ifndef _NETOBJECT_H_
#include "sim/netObject.h"
#endif

#include "component/behaviors/behaviorInstance.h"

//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class BehaviorTemplate : public NetObject
{
   typedef NetObject Parent;
   friend class BehaviorInstance; //TODO: Remove this

public:
   struct BehaviorField
   {
      StringTableEntry mFieldName;
      StringTableEntry mFieldDescription;

      StringTableEntry mFieldType;
      StringTableEntry mUserData;

      StringTableEntry mDefaultValue;

	  StringTableEntry mGroup;

	  StringTableEntry mDependency;

	  bool mHidden;
   };

protected:
   StringTableEntry mFriendlyName;
   StringTableEntry mDescription;
   
   StringTableEntry mFromResource;
   StringTableEntry mBehaviorGroup;
   StringTableEntry mBehaviorType;
   StringTableEntry mNetworkType;
   StringTableEntry mTemplateName;
   
   Vector<StringTableEntry> mDependencies;
   Vector<BehaviorField> mFields;

   bool mNetworked;

public:
   BehaviorTemplate();
   virtual ~BehaviorTemplate();
   DECLARE_CONOBJECT(BehaviorTemplate);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   void pushUpdate();

   /// @name Creation Methods
   /// @{

   /// Create a BehaviorInstance from this template
   /// @return   BehaviorInstance   returns the newly created BehaviorInstance object
   virtual BehaviorInstance *createInstance();

   bool setupFields( BehaviorInstance *bi, bool forceSetup = false );
   /// @}

   /// @name Adding Named Fields
   /// @{

   /// Adds a named field to a BehaviorTemplate that can specify a description, data type, default value and userData
   ///
   /// @param   fieldName    The name of the Field
   /// @param   desc         The Description of the Field
   /// @param   type         The Type of field that this is, example 'Text' or 'Bool'
   /// @param   defaultValue The Default value of this field
   /// @param   userData     An extra optional field that can be used for user data
   void addBehaviorField(const char *fieldName, const char *desc, const char *type, const char *defaultValue = NULL, const char *userData = NULL, bool hidden = false);

   /// Returns the number of BehaviorField's on this template
   inline S32 getBehaviorFieldCount() { return mFields.size(); };

   /// Gets a BehaviorField by its index in the mFields vector 
   /// @param idx  The index of the field in the mField vector
   inline BehaviorField *getBehaviorField(S32 idx)
   {
      if(idx < 0 || idx >= mFields.size())
         return NULL;

      return &mFields[idx];
   }

   BehaviorField *getBehaviorField(const char* fieldName);

   const char* getBehaviorType() { return mBehaviorType; }

   const char *getDescriptionText(const char *desc);

   const char *getName() { return mTemplateName; }

	bool isNetworked() { return mNetworked; }

   void beginFieldGroup(const char* groupName);
   void endFieldGroup();

   void addDependency(StringTableEntry name);
   /// @}

   /// @name Description
   /// @{
   static bool setDescription( void *object, const char *index, const char *data );
   static const char* getDescription(void* obj, const char* data);

   /// @Primary usage functions
   /// @These are used by the various engine-based behaviors to integrate with the component classes
   enum NetMaskBits 
   {
      UpdateMask = BIT(0)
   };

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);
   /// @}

};
#endif // _BEHAVIORTEMPLATE_H_
