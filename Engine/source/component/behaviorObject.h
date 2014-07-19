#ifndef _BEHAVIOR_OBJECT_H_
#define _BEHAVIOR_OBJECT_H_

#ifndef _GAMEBASE_H_
#include "T3D/gameBase/gameBase.h"
#endif
#ifndef _ICALLMETHOD_H_
#include "console/ICallMethod.h"
#endif
#ifndef _CONSOLEINTERNAL_H_
#include "console/consoleInternal.h"
#endif

#ifndef _BEHAVIORTEMPLATE_H_
#include "component/behaviors/behaviorTemplate.h"
#endif
#ifndef _BEHAVIORINSTANCE_H_
#include "component/behaviors/behaviorInstance.h"
#endif
#ifndef _BEHAVIORINTERFACE_H_
#include "component/interfaces/behaviorInterface.h"
#endif

#ifndef _PLATFORM_THREADS_MUTEX_H_
#include "platform/threads/mutex.h"
#endif
#ifndef _STRINGFUNCTIONS_H_
#include "core/strings/stringFunctions.h"
#endif
#ifndef _SIMSET_H_
#include "console/simSet.h"
#endif
#ifndef _TVECTOR_H_
#include "core/util/tVector.h"
#endif
#ifndef _STRINGTABLE_H_
#include "core/stringTable.h"
#endif
#ifndef _SIMOBJECT_H_
#include "console/simObject.h"
#endif

#include "core/util/safeDelete.h"

#ifdef TORQUE_DEBUG
	#ifndef _TDICTIONARY_H_
	#include "core/util/tDictionary.h"
	#endif
#endif

class BehaviorObject;
class BehaviorInstance;
class BehaviorTemplate;

class BehaviorListInterface
{
   typedef BehaviorInterface Parent;
   friend class BehaviorObject;

private:
   SimObjectPtr<BehaviorObject> mOwner; ///< BehaviorObject will directly modify this value

public:
   /// Default constructor
   BehaviorListInterface() : mOwner(NULL) {};

   /// Destructor
   virtual ~BehaviorListInterface() 
   { 
      mOwner = NULL;
   }

   /// This will return true if the interface is valid
   virtual bool isValid() const 
   { 
      return mOwner != NULL; 
   }

   /// Get the owner of this interface
   BehaviorObject *getOwner() { return mOwner; }
   const BehaviorObject *getOwner() const { return mOwner; }

public:
   virtual bool addBehavior( BehaviorInstance *bi );
   virtual bool removeBehavior( BehaviorInstance *bi );
   virtual const SimSet &getBehaviors() const;
   virtual BehaviorInstance *getBehavior( StringTableEntry behaviorTemplateName );
   virtual BehaviorInstance *getBehavior( S32 index );
   virtual void clearBehaviors();
   virtual bool reOrder( BehaviorInstance *obj, U32 desiredIndex /* = 0 */ );
   virtual U32 getBehaviorCount() const;
   virtual const char *callMethodOnBehaviors( S32 argc, const char *argv[] );
};

class BehaviorObject : public GameBase, public ICallMethod
{
   typedef GameBase Parent;
   friend class BehaviorInterface;
   friend class BehaviorListInterface;
   friend class BehaviorInstance;

   //////////////////////////////////////////////////////////////////////////
   // ICallMethod stuff
   // Allows us to handle console method calls
#ifdef TORQUE_DEBUG
   typedef Map<StringTableEntry, S32> callMethodMetricType;

   // Call Method Debug Stat.
   callMethodMetricType mCallMethodMetrics;
#endif

protected:
   /// Internal callMethod : Actually does component notification and script method execution
   ///  @attention This method does some magic to the argc argv to make Con::execute act properly
   ///   as such it's internal and should not be exposed or used except by this class
   virtual const char* _callMethod( U32 argc, const char *argv[], bool callThis = true );

   virtual const char *_callBehaviorMethod( U32 argc, const char *argv[], bool callThis /* = true  */ );

public:

#ifdef TORQUE_DEBUG
   /// Call Method Metrics.
   const callMethodMetricType& getCallMethodMetrics( void ) const { return mCallMethodMetrics; };

   /// Inject Method Call.
   void injectMethodCall( const char* method );
#endif

   /// Call Method
   virtual const char* callMethodArgList( U32 argc, const char *argv[], bool callThis = true );

   /// Call Method format string
   const char* callMethod( S32 argc, const char* methodName, ... );

   //////////////////////////////////////////////////////////////////////////
   // DynamicConsoleMethodComponent Overrides
   virtual bool handlesConsoleMethod( const char *fname, S32 *routingId );

   //////////////////////////////////////////////////////////////////////////
   // Behavior stuff
   // These are the functions that handle behavior management
private:
   SimSet mBehaviors;
	Vector<BehaviorInstance*> mToLoadBehaviors;
	bool   mStartBehaviorUpdate;
	bool   mDelayUpdate;
   bool   mLoadedBehaviors;

protected:
   BehaviorInterface mPublicBehaviorInterface;
   BehaviorInterfaceCache mInterfaceCache;  ///< Stores the interfaces exposed by this entity's behaviors. 

   enum MaskBits 
   {
	   BehaviorsMask				 = Parent::NextFreeMask << 0,
	   NextFreeMask             = Parent::NextFreeMask << 1
   };

   // [neo, 5/10/2007 - #3010]
   bool  mInBehaviorCallback; ///<  

   /// Should adding of behaviors be deferred from onAdd() to be called by derived classe manually?
   virtual bool deferAddingBehaviors() const { return false; }

public:
   virtual void write( Stream &stream, U32 tabStop, U32 flags = 0  );
   //virtual void registerInterfaces( BehaviorObject *owner );

   bool registerCachedInterface( const char *type, const char *name, BehaviorInstance *interfaceOwner, BehaviorInterface *cinterface );
	bool removeCachedInterface( const char *type, const char *name, BehaviorInstance *interfaceOwner );

   // [neo, 5/11/2007]
   // Refactored onAdd() code into this method so it can be deferred by derived classes.
   /// Attach behaviors listed as special fields (derived classes can override this and defer!)
   virtual void addBehaviors();

   //////////////////////////////////////////////////////////////////////////
   /// Behavior interface  (Move this to protected?)
   virtual bool addBehavior( BehaviorInstance *bi );
   virtual bool removeBehavior( BehaviorInstance *bi, bool deleteBehavior = true );
   virtual const SimSet &getBehaviors() const { return mBehaviors; };
   virtual BehaviorInstance *getBehavior( StringTableEntry behaviorTemplateName );
   virtual BehaviorInstance *getBehavior( S32 index );
   virtual BehaviorInstance *getBehaviorByType( StringTableEntry behaviorTypeName );
   virtual BehaviorInstance *getBehavior( BehaviorTemplate *bTemplate );

   BehaviorInstance *getBehavior();
   template <class T>
   T *getBehavior();

   virtual void clearBehaviors(bool deleteBehaviors = true);
   virtual bool reOrder( BehaviorInstance *obj, U32 desiredIndex /* = 0 */ );
   virtual U32 getBehaviorCount() const { return mBehaviors.size(); }
	void updateBehaviors();
	void setBehaviorsDirty();
	/// This forces the network update of a single specific behavior
	/// The force update arg is for special-case behaviors that are explicitly networked to certain clients
	/// Such as the camera, and it will override the check if the template defines if it's networked or not
	void setBehaviorDirty(BehaviorInstance *bI, bool forceUpdate = false);
   void callOnBehaviors( String function );

   //Interfaces hook
   virtual bool getInterfaces( BehaviorInterfaceList *list, const char *type = NULL, const char *name = NULL, const BehaviorInstance *owner = NULL, bool notOwner = false ); // const omission intentional

   /// These two methods allow for easy query of component interfaces if you know
   /// exactly what you are looking for, and don't mind being passed back the first
   /// matching result.
   BehaviorInterface *getInterface( const char *type = NULL, const char *name = NULL, const BehaviorInstance *owner = NULL, bool notOwner = false );

   template <class T>
   T *getInterface( const char *type = NULL, const char *name = NULL, const BehaviorInstance *owner = NULL, bool notOwner = false );



public:
	BehaviorObject();
   ~BehaviorObject(){}

	bool onAdd();
	void onRemove();

	virtual void onPostAdd();

	virtual void addObject( SimObject* object );

   Box3F getObjectBox() { return mObjBox; }
   MatrixF getWorldToObj() { return mWorldToObj; }
   MatrixF getObjToWorld() { return mObjToWorld; }

   virtual void setObjectBox(Box3F objBox){}
   virtual void setWorldBox(Box3F wrldBox) { mWorldBox = wrldBox; }

	bool areBehaviorsLoaded() { return mLoadedBehaviors; }

	U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
	void unpackUpdate(NetConnection *con, BitStream *stream);

	S32 isBehaviorPackable(NetConnection *con, BehaviorInstance* bI);

   DECLARE_CONOBJECT(BehaviorObject);
};

template <class T>
T *BehaviorObject::getBehavior()
{
	for( SimSet::iterator b = mBehaviors.begin(); b != mBehaviors.end(); b++ )
	{
		// We can do this because both are in the string table
		if( dynamic_cast<T *>(*b) != NULL )
			return static_cast<T *>(*b);
	}

	return NULL;
}

//Get behavior by interface

template <class T>
T *BehaviorObject::getInterface( const char *type /* = NULL */, const char *name /* = NULL */, 
                              const BehaviorInstance *owner /* = NULL */, bool notOwner /* = false  */ )
{
   BehaviorInterfaceList iLst;

   if( getInterfaces( &iLst, type, name, owner, notOwner ) )
   {
      BehaviorInterfaceListIterator itr = iLst.begin();

      while( itr != iLst.end() && dynamic_cast<T *>( *itr ) == NULL )
         itr++;

      if( itr != iLst.end() )
         return static_cast<T *>( *itr );
   }

   return NULL;
}

inline bool BehaviorListInterface::addBehavior( BehaviorInstance *bi )
{
   VALID_INTERFACE_ASSERT(BehaviorObject);

   if ( getOwner() == NULL )
      return false;

   return reinterpret_cast<BehaviorObject *>( getOwner() )->addBehavior( bi );
}

inline bool BehaviorListInterface::removeBehavior( BehaviorInstance *bi )
{
   VALID_INTERFACE_ASSERT(BehaviorObject);

   if ( getOwner() == NULL )
      return false;

   return reinterpret_cast<BehaviorObject *>( getOwner() )->removeBehavior( bi );
}

inline const SimSet &BehaviorListInterface::getBehaviors() const
{
   VALID_INTERFACE_ASSERT(BehaviorObject);
   return reinterpret_cast<const BehaviorObject *>( getOwner() )->getBehaviors();
}

inline BehaviorInstance *BehaviorListInterface::getBehavior( StringTableEntry behaviorTemplateName )
{
   VALID_INTERFACE_ASSERT(BehaviorObject);

   if ( getOwner() == NULL )
      return NULL;

   return reinterpret_cast<BehaviorObject *>( getOwner() )->getBehavior( behaviorTemplateName );
}

inline BehaviorInstance *BehaviorListInterface::getBehavior( S32 index )
{
   VALID_INTERFACE_ASSERT(BehaviorObject);

   if ( getOwner() == NULL )
      return NULL;

   return reinterpret_cast<BehaviorObject *>( getOwner() )->getBehavior( index );
}

inline void BehaviorListInterface::clearBehaviors()
{
   VALID_INTERFACE_ASSERT(BehaviorObject);

   if ( getOwner() != NULL )
      reinterpret_cast<BehaviorObject *>( getOwner() )->clearBehaviors();
}

inline bool BehaviorListInterface::reOrder( BehaviorInstance *obj, U32 desiredIndex /* = 0 */ )
{
   VALID_INTERFACE_ASSERT(BehaviorObject);

   if ( getOwner() == NULL )
      return false;

   return reinterpret_cast<BehaviorObject *>( getOwner() )->reOrder( obj, desiredIndex );
}

inline U32 BehaviorListInterface::getBehaviorCount() const
{
   VALID_INTERFACE_ASSERT(BehaviorObject);

   if ( getOwner() == NULL )
      return 0;

   return reinterpret_cast<const BehaviorObject *>( getOwner() )->getBehaviorCount();
}

inline const char *BehaviorListInterface::callMethodOnBehaviors( S32 argc, const char *argv[] )
{
   VALID_INTERFACE_ASSERT(BehaviorObject);

   if ( getOwner() == NULL )
   {
      char* empty = Con::getReturnBuffer(4);
      empty[0] = 0;

      return empty;
   }

   return reinterpret_cast<BehaviorObject *>( getOwner() )->_callMethod( argc, argv, false );
}
#endif