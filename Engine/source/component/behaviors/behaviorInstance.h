//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
#ifndef _BEHAVIORINSTANCE_H_
#define _BEHAVIORINSTANCE_H_

#ifndef _NETOBJECT_H_
#include "sim/netObject.h"
#endif

#ifndef _BEHAVIOR_OBJECT_H_
#include "component/behaviorObject.h"
#endif
#ifndef _BEHAVIORTEMPLATE_H_
#include "component/behaviors/behaviorTemplate.h"
#endif
#ifndef _STOCK_INTERFACES_H_
#include "component/behaviors/stockInterfaces.h"
#endif

// Forward refs
class BehaviorTemplate;
class BehaviorObject;

//////////////////////////////////////////////////////////////////////////
/// An Instance of a given Object Behavior
///
/// A BehaviorInstance object is created from a BehaviorTemplate object 
/// that defines it's Default Values, 
class BehaviorInstance : public NetObject, public ICallMethod
{
   typedef NetObject Parent;

protected:
   BehaviorTemplate		 *mTemplate;
   BehaviorObject        *mBehaviorOwner;
   //Used for compound namespaces for the callbacks
   Namespace			 *mTemplateNameSpace;
   bool					 mHidden;
   bool					 mEnabled;
	bool					 mInitialized;

   struct BehaviorInstanceUpdateInterface : public UpdateInterface
   {
		inline virtual void processTick(const Move* move)
		{
			BehaviorInstance *bI = getOwner();
			if(bI && bI->isEnabled())
				bI->processTick(move);
		}
		inline virtual void interpolateTick(F32 dt)
		{
			BehaviorInstance *bI = getOwner();
			if(bI && bI->isEnabled())
				bI->interpolateTick(dt);
		}
		inline virtual void advanceTime(F32 dt)
		{
			BehaviorInstance *bI = getOwner();
			if(getOwner() && bI->isEnabled())
				bI->advanceTime(dt);
		}
   };
   BehaviorInstanceUpdateInterface mUpdateInterface;

   //This is for dynamic fields we may want to save out to file, etc.
   struct behaviorFields
   {
		StringTableEntry mFieldName;
		StringTableEntry mDefaultValue;
   };

   Vector<behaviorFields> mBehaviorFields;


public:
   BehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~BehaviorInstance();
   DECLARE_CONOBJECT(BehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual bool isMethod( const char* methodName ); //this is used because some behaviors have compound namespaces
   Namespace* getTemplateNamespace() { return mTemplateNameSpace; }

   // This must be called before the object is registered with the sim
   void setBehaviorClass(StringTableEntry className, StringTableEntry superClass)
   {
      mClassName = className;
      mSuperClassName = superClass;
   }

   void setBehaviorOwner( BehaviorObject* pOwner ) { mBehaviorOwner = pOwner; };
   inline BehaviorObject *getBehaviorOwner() { return mBehaviorOwner ? mBehaviorOwner : NULL; };

   // Read-Only field accessor (never allows write)
   static bool setOwner( void *object, const char *index, const char *data ) { return true; };

   BehaviorTemplate *getTemplate()        { return mTemplate; }
   const char *getTemplateName();

   const char * checkDependencies();

   bool	isEnabled() { return mEnabled; }
   void setEnabled(bool toggle) { mEnabled = toggle; setMaskBits(EnableMask); }
	bool  isInitalized() { return mInitialized; }

   virtual void packToStream( Stream &stream, U32 tabStop, S32 behaviorID, U32 flags = 0 );

   void addBehaviorField(const char* fieldName, const char* value);
   void removeBehaviorField(const char* fieldName);

	virtual void onStaticModified( const char* slotName, const char* newValue ); ///< Called when a static field is modified.
   virtual void onDynamicModified(const char* slotName, const char*newValue = NULL); ///< Called when a dynamic field is modified.
	/// This is what we actually use to check if the modified field is one of our behavior fields. If it is, we update and make the correct callbacks
	void checkBehaviorFieldModified( const char* slotName, const char* newValue );

   //not used here, basically only exists to smooth the usage of custom behavior instances that might
   enum NetMaskBits 
   {
      InitialUpdateMask = BIT(0),
	   UpdateMask = BIT(1),
	   EnableMask = BIT(2),
	   NextFreeMask = BIT(3)
   };

   /*enum
   {
	   MaxRemoteCommandArgs = 20
   };*/

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);
   void pushUpdate();

	virtual void update();

   virtual void onBehaviorAdd();
   virtual void onBehaviorRemove();

	virtual void registerInterfaces();
	virtual void unregisterInterfaces();

    virtual void processTick(const Move* move);
	virtual void interpolateTick(F32 dt){}
	virtual void advanceTime(F32 dt){}

   //virtual void prepRenderImage(SceneRenderState *state){}

   virtual bool castRay(const Point3F &start, const Point3F &end, RayInfo* info){ return false; }
   virtual bool castRayRendered(const Point3F &start, const Point3F &end, RayInfo *info){ return false; }

   virtual bool buildPolyList(PolyListContext context, AbstractPolyList* polyList, const Box3F &box, const SphereF &){ return false; }
   virtual bool buildConvex(const Box3F& box, Convex* convex) { return false; }

   //
   virtual bool getCameraTransform(F32* pos,MatrixF* mat) { return false; }

   //Interface hooks
   template <class T>
   T *getInterface();

   //callOn_ functions
   void callOnServer(S32 argc, const char **argv);
   void callOnClient(S32 argc, const char **argv);
   void sendCommand(NetConnection *conn, S32 argc, const char **argv);

   virtual bool handlesConsoleMethod(const char * fname, S32 * routingId);
   const char* callMethodArgList( U32 argc, const char *argv[], bool callThis  = true   );
   const char* callMethod( S32 argc, const char* methodName, ... );

   virtual void handleEvent(const char* eventName, Vector<const char*> eventParams){ }

   //Callbacks
   DECLARE_CALLBACK( void, Update, ( const char* move, const char* rot/*const Point3F& move, const Point3F& rot*/ ) );
   DECLARE_CALLBACK( void, onTrigger, ( U32 triggerID ) );
};
#endif // _BEHAVIORINSTANCE_H_
