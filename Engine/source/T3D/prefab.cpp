//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

#include "platform/platform.h"
#include "T3D/prefab.h"

#include "math/mathIO.h"
#include "core/stream/bitStream.h"
#include "scene/sceneRenderState.h"
#include "gfx/gfxTransformSaver.h"
#include "renderInstance/renderPassManager.h"
#include "console/consoleTypes.h"
#include "core/volume.h"
#include "console/engineAPI.h"
#include "T3D/physics/physicsShape.h"
#include "core/util/path.h"

#include "util/TSCodeParser.h"

// We use this locally ( within this file ) to prevent infinite recursion
// while loading prefab files that contain other prefabs.
static Vector<String> sPrefabFileStack;

Map<SimObjectId,SimObjectId> Prefab::smChildToPrefabMap;

IMPLEMENT_CO_NETOBJECT_V1(Prefab);

ConsoleDocClass( Prefab,
   "@brief A collection of arbitrary objects which can be allocated and manipulated as a group.\n\n"
   
   "%Prefab always points to a (.prefab) file which defines its objects. In "
   "fact more than one %Prefab can reference this file and both will update "
   "if the file is modified.\n\n"
   
   "%Prefab is a very simple object and only exists on the server. When it is "
   "created it allocates children objects by reading the (.prefab) file like "
   "a list of instructions.  It then sets their transform relative to the %Prefab "
   "and Torque networking handles the rest by ghosting the new objects to clients. "
   "%Prefab itself is not ghosted.\n\n"
   
   "@ingroup enviroMisc"   
);

IMPLEMENT_CALLBACK( Prefab, onLoad, void, ( SimGroup *children ), ( children ),
   "Called when the prefab file is loaded and children objects are created.\n"
   "@param children SimGroup containing all children objects.\n"
);

Prefab::Prefab()
{
   // Not ghosted unless we're editing
   mNetFlags.clear(Ghostable);

	mDirty = false;

   mTypeMask |= StaticObjectType;
}

Prefab::~Prefab()
{
}

void Prefab::initPersistFields()
{
   addGroup( "Prefab" );

      addProtectedField( "filename", TypePrefabFilename, Offset( mFilename, Prefab ),         
                         &protectedSetFile, &defaultProtectedGetFn,
                         "(.prefab) File describing objects within this prefab." );

		addField( "isDirty", TypeBool, Offset( mDirty, Prefab ), "Object world orientation." );

   endGroup( "Prefab" );

   Parent::initPersistFields();
}

extern bool gEditingMission;

bool Prefab::onAdd()
{
   if ( !Parent::onAdd() )
      return false;

   mObjBox.set( Point3F( -0.5f, -0.5f, -0.5f ),
      Point3F(  0.5f,  0.5f,  0.5f ) );

   resetWorldBox();
   
   // Not added to the scene unless we are editing.
   if ( gEditingMission )
      onEditorEnable();

   // Only the server-side prefab needs to create/update child objects.
   // We rely on regular Torque ghosting of the individual child objects
   // to take care of the rest.
   if ( isServerObject() )
   {
		if(!mDirty)
			_loadFile( true );
      _updateChildren();
   }

   return true;
}

void Prefab::onRemove()
{
   if ( isServerObject() )
      _closeFile( true );

   removeFromScene();
   Parent::onRemove();
}

void Prefab::onEditorEnable()
{
   if ( isClientObject() )
      return;

   // Just in case we are already in the scene, lets not cause an assert.   
   if ( mContainer != NULL )
      return;

   // Enable ghosting so we can see this on the client.
   mNetFlags.set(Ghostable);
   setScopeAlways();
   addToScene();

   Parent::onEditorEnable();
}

void Prefab::onEditorDisable()
{   
   if ( isClientObject() )
      return;

   // Just in case we are not in the scene, lets not cause an assert.   
   if ( mContainer == NULL )
      return;

   // Do not need this on the client if we are not editing.
   removeFromScene();
   mNetFlags.clear(Ghostable);
   clearScopeAlways();

   Parent::onEditorDisable();
}

void Prefab::inspectPostApply()
{
   Parent::inspectPostApply();
}

void Prefab::setTransform(const MatrixF & mat)
{
   Parent::setTransform( mat ); 

   if ( isServerObject() )
   {
      setMaskBits( TransformMask );
      _updateChildren();
   }
}

void Prefab::setScale(const VectorF & scale)
{
   Parent::setScale( scale ); 

   if ( isServerObject() )
   {
      setMaskBits( TransformMask );
      _updateChildren();
   }
}

U32 Prefab::packUpdate( NetConnection *conn, U32 mask, BitStream *stream )
{
   U32 retMask = Parent::packUpdate( conn, mask, stream );

   mathWrite(*stream,mObjBox);

   if ( stream->writeFlag( mask & FileMask ) )
   {
      stream->write( mFilename );
   }

   if ( stream->writeFlag( mask & TransformMask ) )
   {
      mathWrite(*stream, getTransform());
      mathWrite(*stream, getScale());
   }

   return retMask;
}

void Prefab::unpackUpdate(NetConnection *conn, BitStream *stream)
{
   Parent::unpackUpdate(conn, stream);

   mathRead(*stream, &mObjBox);
   resetWorldBox();

   // FileMask
   if ( stream->readFlag() ) 
   {
      stream->read( &mFilename );
   }

   // TransformMask
   if ( stream->readFlag() )  
   {
      mathRead(*stream, &mObjToWorld);
      mathRead(*stream, &mObjScale);

      setTransform( mObjToWorld );
   }
}

bool Prefab::protectedSetFile( void *object, const char *index, const char *data )
{
   Prefab *prefab = static_cast<Prefab*>(object);
   
   String file = String( Platform::makeRelativePathName(data, Platform::getMainDotCsDir()) );

   prefab->setFile( file );

   return false;
}

void Prefab::setFile( String file )
{  
   AssertFatal( isServerObject(), "Prefab-bad" );

   if ( !isProperlyAdded() )
   {
      mFilename = file;
      return;
   }
   
   // Client-side Prefab(s) do not create/update/reference children, everything
   // is handled on the server-side. In normal usage this will never actually
   // be called for the client-side prefab but maybe the user did so accidentally.
   if ( isClientObject() )
   {
      Con::errorf( "Prefab::setFile( %s ) - Should not be called on a client-side Prefab.", file.c_str() );
      return;
   }

   _closeFile( true );

   mFilename = file;

   if ( isProperlyAdded() )
      _loadFile( true );
}

void Prefab::addObject(SimObject* object)
{
	//we added an object to us, so integrate it into the prefab.

	//first, check if it's already in here
	Prefab* p = Prefab::getPrefabByChild(object);

	if(p == this)
		//it's already in here, I have no idea why this is happening. Just exit
		return;

	SceneObject* sc = dynamic_cast<SceneObject*>(object);
	if(!sc)
		return;

	mWorldBox.intersect(sc->getWorldBox());

	//Well, apparently it's not, so add it
	Parent::addObject(sc);
	mChildMap.insert( sc->getId(), Transform( sc->getTransform(), sc->getScale() ) );
	smChildToPrefabMap.insert( sc->getId(), getId() );
}

void Prefab::removeObject(SimObject* object)
{
	//Just make sure
	Prefab* p = Prefab::getPrefabByChild(object);

	if(p == this)
	{
		smChildToPrefabMap.erase( object->getId() );
		mChildMap.erase(object->getId());
	}
}

bool Prefab::save(const char *pcFileName, bool bOnlySelected, const char *preappend)
{
   static const char *beginMessage = "//--- OBJECT WRITE BEGIN ---";
   static const char *endMessage = "//--- OBJECT WRITE END ---";
   FileStream *stream;
   FileObject f;
   f.readMemory(pcFileName);

   // check for flags <selected, ...>
   U32 writeFlags = 0;
   if(bOnlySelected)
      writeFlags |= SimObject::SelectedOnly;

   if((stream = FileStream::createAndOpen( pcFileName, Torque::FS::File::Write )) == NULL)
      return false;

   char docRoot[256];
   char modRoot[256];

   dStrcpy(docRoot, pcFileName);
   char *p = dStrrchr(docRoot, '/');
   if (p) *++p = '\0';
   else  docRoot[0] = '\0';

   dStrcpy(modRoot, pcFileName);
   p = dStrchr(modRoot, '/');
   if (p) *++p = '\0';
   else  modRoot[0] = '\0';

   Con::setVariable("$DocRoot", docRoot);
   Con::setVariable("$ModRoot", modRoot);

   const char *buffer;
   while(!f.isEOF())
   {
      buffer = (const char *) f.readLine();
      if(!dStrcmp(buffer, beginMessage))
         break;
      stream->write(dStrlen(buffer), buffer);
      stream->write(2, "\r\n");
   }
   stream->write(dStrlen(beginMessage), beginMessage);
   stream->write(2, "\r\n");
   //if ( preappend != NULL )   
   //   stream->write(dStrlen(preappend),preappend);   
   //write(*stream, 0, writeFlags);
	S32 writtenObjects = 0;
	for(U32 i = 0; i < size(); i++)
	{
		SimObject* child = ( *this )[ i ];
		if( child->getCanSave() )
		{
			char prefabprepend[256];
			dSprintf(prefabprepend, sizeof(prefabprepend), "$PrefabElement%d = ", writtenObjects);

			stream->write(dStrlen(prefabprepend), prefabprepend);

			child->write(*stream, 0, writeFlags);

			writtenObjects++;
		}
	}
   stream->write(dStrlen(endMessage), endMessage);
   stream->write(2, "\r\n");
   while(!f.isEOF())
   {
      buffer = (const char *) f.readLine();
      if(!dStrcmp(buffer, endMessage))
         break;
   }
   while(!f.isEOF())
   {
      buffer = (const char *) f.readLine();
      stream->write(dStrlen(buffer), buffer);
      stream->write(2, "\r\n");
   }

   Con::setVariable("$DocRoot", NULL);
   Con::setVariable("$ModRoot", NULL);

   delete stream;

   return true;

}

SimGroup* Prefab::explode()
{
   SimGroup *missionGroup;

   if ( !Sim::findObject( "MissionGroup", missionGroup ) )
   {
      Con::errorf( "Prefab::explode, MissionGroup was not found." );
      return NULL;
   }

   if ( !mChildGroup )
      return NULL;

   SimGroup *group = mChildGroup;
   Vector<SceneObject*> foundObjects;

   group->findObjectByType( foundObjects );

   if ( foundObjects.empty() )
      return NULL;

   for ( S32 i = 0; i < foundObjects.size(); i++ )
   {
      SceneObject *child = foundObjects[i];
      _updateChildTransform( child );
      smChildToPrefabMap.erase( child->getId() );
   }
   
   missionGroup->addObject(group);
   mChildGroup = NULL;
   mChildMap.clear();

   return group;
}

void Prefab::_parseFile( bool addFileNotify )
{
	AssertFatal( isServerObject(), "Prefab-bad" );

   if ( mFilename.isEmpty() )
      return;

   if ( !Platform::isFile( mFilename ) )
   {
      Con::errorf( "Prefab::_loadFile() - file %s was not found.", mFilename.c_str() );
      return;
   }

   if ( sPrefabFileStack.contains(mFilename) )
   {
      Con::errorf( 
         "Prefab::_loadFile - failed loading prefab file (%s). \n"
         "File was referenced recursively by both a Parent and Child prefab.", mFilename.c_str() );
      return;
   }

   sPrefabFileStack.push_back(mFilename);

	static const char *beginMessage = "//--- OBJECT WRITE BEGIN ---";
   static const char *endMessage = "//--- OBJECT WRITE END ---";
   FileStream *stream;
   FileObject f;
   f.readMemory(mFilename);

   const char *buffer;
   while(!f.isEOF())
   {
      buffer = (const char *) f.readLine();
      if(!dStrcmp(buffer, beginMessage))
         break;
      stream->write(dStrlen(buffer), buffer);
      stream->write(2, "\r\n");
   }
   stream->write(dStrlen(beginMessage), beginMessage);

	sPrefabFileStack.pop_back();

   onLoad_callback( this );
}

void Prefab::_closeFile( bool removeFileNotify )
{
   AssertFatal( isServerObject(), "Prefab-bad" );

   mChildMap.clear();

	SimSet::iterator itr;
	for(itr = begin(); itr != end(); itr++)
	{
		SimObject *obj = *itr;
      
		SceneObject* scn = dynamic_cast<SceneObject*>(obj);
		if(scn)
		{
			smChildToPrefabMap.erase( scn->getId() );
		}
	}

	clear();

   /*if ( mChildGroup )
   {
      // Get a flat vector of all our children.
      Vector<SceneObject*> foundObjects;
      mChildGroup->findObjectByType( foundObjects );

      // Remove them all from the ChildToPrefabMap.
      for ( S32 i = 0; i < foundObjects.size(); i++ )
         smChildToPrefabMap.erase( foundObjects[i]->getId() );

      mChildGroup->deleteObject();
      mChildGroup = NULL;
   }*/

   if ( removeFileNotify )
      Torque::FS::RemoveChangeNotification( mFilename, this, &Prefab::_onFileChanged );

   // Back to a default bounding box size.
   mObjBox.set( Point3F( -0.5f, -0.5f, -0.5f ), Point3F(  0.5f,  0.5f,  0.5f ) );
   resetWorldBox();
}

void Prefab::_loadFile( bool addFileNotify )
{
   AssertFatal( isServerObject(), "Prefab-bad" );

   if ( mFilename.isEmpty() )
      return;

   if ( !Platform::isFile( mFilename ) )
   {
      Con::errorf( "Prefab::_loadFile() - file %s was not found.", mFilename.c_str() );
      return;
   }

   if ( sPrefabFileStack.contains(mFilename) )
   {
      Con::errorf( 
         "Prefab::_loadFile - failed loading prefab file (%s). \n"
         "File was referenced recursively by both a Parent and Child prefab.", mFilename.c_str() );
      return;
   }

	TSCodeParser tscp;

	tscp.loadFile(mFilename);

	String objName;
	
	//Roll through and iterate-up any specifically named objects
	S32 pos = tscp.findObjectName(0, objName); 
	while(pos != -1)
	{
		S32 itr = 0;
		bool changed = false;
			
		//char* newName;
		//dStrcpy(newName, objName.c_str());

		String newName = objName;

		while(Sim::findObject( newName.c_str() ) && itr < 100)
		{
			itr++;
			char* temp = (char*)newName.c_str();
			dSprintf(temp, 256, "%s%d", objName.c_str(), itr);
			changed = true;
		}

		if(changed)
			tscp.findAndReplace(objName, newName, 0);

		pos = tscp.findObjectName(pos, objName);
	}

	tscp.execute();

   SimGroup *group;
   if ( Sim::findObject( Con::getVariable( "$ThisPrefab" ), group ) )
   {
      //Con::errorf( "Prefab::_loadFile() - file %s did not create $ThisPrefab.", mFilename.c_str() );
      //return;

		Vector<SimObject*> objectList;

		SimSet::iterator itr;
		for(itr = group->begin(); itr != group->end(); itr++)
		{
			SimObject *obj = *itr;

			String name = obj->getName();

			//Don't hoover up already-parented sub-objects
			if(obj->getGroup() == group)
				objectList.push_back(obj);
		}

		for(U32 i=0; i < objectList.size(); i++)
		{
			SceneObject* scn = dynamic_cast<SceneObject*>(objectList[i]);
			if(scn)
			{
				Parent::addObject(objectList[i]);

				scn->setSelectionEnabled(false);

				/*Point3F diff = getWorldTransform().toEuler() - scn->getWorldTransform().toEuler();

				MatrixF temp, imat, xmat, ymat, zmat;

				xmat.set(EulerF(diff.x,0,0));
				ymat.set(EulerF(0.0f, diff.y, 0.0f));
				zmat.set(EulerF(0,0,diff.z));

				imat.mul(zmat, xmat);
				temp.mul(imat, ymat);

				temp.setColumn(3, scn->getPosition() - getPosition());*/

				//mountObject(scn, -1, temp);

				mChildMap.insert( scn->getId(), Transform( scn->getTransform(), scn->getScale() ) );
				smChildToPrefabMap.insert( scn->getId(), getId() );
			}
		}

		//Move the objects from the $ThisPrefab group to us
		//Because SceneObject inherits down from SimGroup, we can 
		//skip all this extra mChildGroup junk and just handle it natively
		/*SimSet::iterator itr;
		for(itr = group->begin(); itr != group->end(); itr++)
		{
			SimObject *obj = *itr;

			//Don't hoover up already-parented sub-objects
			if(obj->getGroup() != group)
				continue;

			SceneObject* scn = dynamic_cast<SceneObject*>(obj);
			/*if(scn)
			{
				Parent::addObject(obj);

				scn->setSelectionEnabled(false);

				Point3F diff = getWorldTransform().toEuler() - scn->getWorldTransform().toEuler();

				MatrixF temp, imat, xmat, ymat, zmat;

				xmat.set(EulerF(diff.x,0,0));
				ymat.set(EulerF(0.0f, diff.y, 0.0f));
				zmat.set(EulerF(0,0,diff.z));

				imat.mul(zmat, xmat);
				temp.mul(imat, ymat);

				temp.setColumn(3, scn->getPosition() - getPosition());

				mountObject(scn, -1, temp);

				mChildMap.insert( scn->getId(), Transform( scn->getTransform(), scn->getScale() ) );
				smChildToPrefabMap.insert( scn->getId(), getId() );
			}
		}*/
   }
	else
	{
		const char *element = "";
		for( int i = 0; dStrcmp( element = Con::getVariable( StringTable->insert( avar( "$PrefabElement%d", i ))), "" ) != 0; i++ )
		{
			S32 objID = dAtoi(element);
			SceneObject *obj;

			if ( Sim::findObject(objID, obj ) )
			{
				Parent::addObject(obj);

				obj->setSelectionEnabled(false);

				/*Point3F diff = getWorldTransform().toEuler() - obj->getWorldTransform().toEuler();

				MatrixF temp, imat, xmat, ymat, zmat;

				xmat.set(EulerF(diff.x,0,0));
				ymat.set(EulerF(0.0f, diff.y, 0.0f));
				zmat.set(EulerF(0,0,diff.z));

				imat.mul(zmat, xmat);
				temp.mul(imat, ymat);

				temp.setColumn(3, obj->getPosition() - getPosition());*/

				mChildMap.insert( obj->getId(), Transform( obj->getTransform(), obj->getScale() ) );
				smChildToPrefabMap.insert( obj->getId(), getId() );

				mWorldBox.intersect( obj->getWorldBox() );
			}
		}
	}

	resetObjectBox();
	
   if ( addFileNotify )
      Torque::FS::AddChangeNotification( mFilename, this, &Prefab::_onFileChanged );

   /*Vector<SceneObject*> foundObjects;
   mChildGroup->findObjectByType( foundObjects );

   if ( !foundObjects.empty() )
   {
      mWorldBox = Box3F::Invalid;

      for ( S32 i = 0; i < foundObjects.size(); i++ )
      {
         SceneObject *child = foundObjects[i];
         mChildMap.insert( child->getId(), Transform( child->getTransform(), child->getScale() ) );
         smChildToPrefabMap.insert( child->getId(), getId() );

         _updateChildTransform( child );

         mWorldBox.intersect( child->getWorldBox() );
      }

      resetObjectBox();
   }*/

  // sPrefabFileStack.pop_back();

   onLoad_callback( this );
}

void Prefab::reloadFromFile()
{
	mDirty = false;
	_closeFile(false);
	_loadFile(false);
}

void Prefab::_updateChildTransform( SceneObject* child )
{
   ChildToMatMap::Iterator itr = mChildMap.find(child->getId());
   AssertFatal( itr != mChildMap.end(), "Prefab, mChildMap out of synch with mChildGroup." );

	//Check if our offsets are out of date

   MatrixF mat( itr->value.mat );
   Point3F pos = mat.getPosition();
   pos.convolve( mObjScale );
   mat.setPosition( pos );
   mat.mulL( mObjToWorld );

   child->SceneObject::setTransform( mat );
   child->setScale( itr->value.scale * mObjScale );

   // Hack for PhysicsShape... need to store the "editor" position to return to
   // when a physics reset event occurs. Normally this would be where it is 
   // during onAdd, but in this case it is not because the prefab stores its
   // child objects in object space...

   PhysicsShape *childPS = dynamic_cast<PhysicsShape*>( child );
   if ( childPS )
      childPS->storeRestorePos();

}

void Prefab::childTransformUpdated(SceneObject* child, MatrixF newTransform)
{
	Box3F oldBounds = mWorldBox;

	Box3F bnds = child->getObjBox();
	bnds.minExtents.convolve(child->getScale());
   bnds.maxExtents.convolve(child->getScale());
   newTransform.mul(bnds);

	mWorldBox.intersect( bnds );

	//Now that it's been updated, check if our bounds have changed
	bool updateOffsets = false;
	if(oldBounds != mWorldBox)
	{
		//It changed, we need to flag ourselves as dirty, as well as adjust the children's offsets
		mDirty = true;
		updateOffsets = true;
	}

   SimSet::iterator itr;
	for(itr = begin(); itr != end(); itr++)
	{
		SimObject *obj = *itr;
      
		SceneObject* scn = dynamic_cast<SceneObject*>(obj);
		if(scn)
		{
			if(updateOffsets = true)
			{
				 ChildToMatMap::Iterator itr = mChildMap.find(scn->getId());
				 Point3F curOffset = itr->value.mat.getPosition() - mWorldBox.getCenter();
				 Point3F oldOffset = itr->value.mat.getPosition() - oldBounds.getCenter();
				 Point3F modPos = itr->value.mat.getPosition() + (curOffset - oldOffset);
				 itr->value.mat.setPosition(modPos); 
			}

			_updateChildTransform( scn );
			if ( scn->getClientObject() )
			{
				((SceneObject*)scn->getClientObject())->setTransform( scn->getTransform() );
				((SceneObject*)scn->getClientObject())->setScale( scn->getScale() );
			}
		}
	}
	return;

	if(size() == 1)
	{
		//if we only have the one child, just update the prefab's transform
		setMaskBits( TransformMask );
		Parent::setTransform(newTransform);
		//_updateChildTransform(child);
	}
	else if(size() > 1)
	{
		//now we have to work.
		//Update our bounds, and do an adjustment to relative offsets of the prefab children objects
		//First, recalculate the bounds
		Box3F oldBounds = mWorldBox;
		SimSet::iterator itr;
		for(itr = begin(); itr != end(); itr++)
		{
			SimObject *obj = *itr;
      
			SceneObject* scn = dynamic_cast<SceneObject*>(obj);
			if(scn)
			{
				mWorldBox.intersect( scn->getWorldBox() );
			}
		}

		//Now that it's been updated, check if our bounds have changed
		bool updateOffsets = false;
		if(oldBounds != mWorldBox)
		{
			//It changed, we need to flag ourselves as dirty, as well as adjust the children's offsets
			mDirty = true;
			updateOffsets = true;
		}

		for(itr = begin(); itr != end(); itr++)
		{
			SimObject *obj = *itr;
      
			SceneObject* scn = dynamic_cast<SceneObject*>(obj);
			if(scn)
			{
				_updateChildTransform( scn );
				if ( scn->getClientObject() )
				{
					((SceneObject*)scn->getClientObject())->setTransform( scn->getTransform() );
					((SceneObject*)scn->getClientObject())->setScale( scn->getScale() );
				}
			}
		}
	}
}

//
//
//
/*void Prefab::_updateChildTransform( SceneObject* child )
{
	lock();
   SimSet::iterator itr;
   for(itr = begin(); itr != end(); itr++)
   {
      SimObject *obj = *itr;
      bool isSet = dynamic_cast<SimSet *>(obj) != 0;
      const char *name = obj->getName();
      if(name)
         Con::printf("   %d,\"%s\": %s %s", obj->getId(), name,
         obj->getClassName(), isSet ? "(g)":"");
      else
         Con::printf("   %d: %s %s", obj->getId(), obj->getClassName(),
         isSet ? "(g)" : "");
   }
   unlock();
}*/
//
//
//

static void writeTabs(Stream &stream, U32 count)
{
   char tab[] = "   ";
   while(count--)
      stream.write(3, (void*)tab);
}

void Prefab::write( Stream &stream, U32 tabStop, U32 flags )
{
   // Do *not* call parent on this

	//first, check if our

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

   //Only write out our child objects if our prefab is marked as dirty
	if(mDirty)
	{
		stream.write(2, "\r\n");
		for(U32 i = 0; i < size(); i++)
		{
			SimObject* child = ( *this )[ i ];
			if( child->getCanSave() )
				child->write(stream, tabStop + 1, flags);
		}
	}

   writeTabs( stream, tabStop );
   stream.write( 4, "};\r\n" );
}

void Prefab::_updateChildren()
{
   //if ( !mChildGroup )
   //   return;

	SimSet::iterator itr;
	for(itr = begin(); itr != end(); itr++)
	{
		SimObject *obj = *itr;
      
		SceneObject* scn = dynamic_cast<SceneObject*>(obj);
		if(scn)
		{
			_updateChildTransform( scn );
			if ( scn->getClientObject() )
			{
				((SceneObject*)scn->getClientObject())->setTransform( scn->getTransform() );
				((SceneObject*)scn->getClientObject())->setScale( scn->getScale() );
			}
		}
	}

   /*Vector<SceneObject*> foundObjects;
   mChildGroup->findObjectByType( foundObjects );

   for ( S32 i = 0; i < foundObjects.size(); i++ )
   {
      SceneObject *child = foundObjects[i];

      _updateChildTransform( child );

      if ( child->getClientObject() )
      {
         ((SceneObject*)child->getClientObject())->setTransform( child->getTransform() );
         ((SceneObject*)child->getClientObject())->setScale( child->getScale() );
      }
   }*/
}

bool Prefab::checkDirty()
{
	/*for(U32 i = 0; i < size(); i++)
	{
		SimObject* child = ( *this )[ i ];

		//now, check the static/dynamic fields to see if we've changed at all
		child->getDataField(
	}*/
	return false;
}

void Prefab::_onFileChanged( const Torque::Path &path )
{
   AssertFatal( path == mFilename, "Prefab::_onFileChanged - path does not match filename." );

	if(!mDirty)
	{
		_closeFile(false);
		_loadFile(false);
	}
   setMaskBits(U32_MAX);
}

Prefab* Prefab::getPrefabByChild( SimObject *child )
{
   ChildToPrefabMap::Iterator itr = smChildToPrefabMap.find( child->getId() );
   if ( itr == smChildToPrefabMap.end() )
      return NULL;

   Prefab *prefab;
   if ( !Sim::findObject( itr->value, prefab ) )
   {
      Con::errorf( "Prefab::getPrefabByChild - child object mapped to a prefab that no longer exists." );
      return NULL;
   }

   return prefab;
}

bool Prefab::isValidChild( SimObject *simobj, bool logWarnings )
{
   if ( simobj->getName() && dStricmp(simobj->getName(),"MissionGroup") == 0 )
   {
      if ( logWarnings )
         Con::warnf( "MissionGroup is not valid within a Prefab." );
      return false;
   }

   if ( simobj->getClassRep()->isClass( AbstractClassRep::findClassRep("LevelInfo") ) )
   {
      if ( logWarnings )
         Con::warnf( "LevelInfo objects are not valid within a Prefab" );
      return false;
   }

   if ( simobj->getClassRep()->isClass( AbstractClassRep::findClassRep("TimeOfDay") ) )
   {
      if ( logWarnings )
         Con::warnf( "TimeOfDay objects are not valid within a Prefab" );
      return false;
   }

   SceneObject *sceneobj = dynamic_cast<SceneObject*>(simobj);

   if ( !sceneobj )
      return false;
   
   if ( sceneobj->isGlobalBounds() )
   {
      if ( logWarnings )
         Con::warnf( "SceneObject's with global bounds are not valid within a Prefab." );
      return false;
   }
   
   if ( sceneobj->getClassRep()->isClass( AbstractClassRep::findClassRep("TerrainBlock") ) )
   {
      if ( logWarnings )
         Con::warnf( "TerrainBlock objects are not valid within a Prefab" );
      return false;
   }

   if ( sceneobj->getClassRep()->isClass( AbstractClassRep::findClassRep("Player") ) )
   {
      if ( logWarnings )
         Con::warnf( "Player objects are not valid within a Prefab" );
      return false;
   }

   if ( sceneobj->getClassRep()->isClass( AbstractClassRep::findClassRep("DecalRoad") ) )
   {
      if ( logWarnings )
         Con::warnf( "DecalRoad objects are not valid within a Prefab" );
      return false;
   }

   return true;
}

ExplodePrefabUndoAction::ExplodePrefabUndoAction( Prefab *prefab )
: UndoAction( "Explode Prefab" )
{
   mPrefabId = prefab->getId();
   mGroup = NULL;

   // Do the action.
   redo();
}

void ExplodePrefabUndoAction::undo()
{
   if ( !mGroup )   
   {
      Con::errorf( "ExplodePrefabUndoAction::undo - NULL Group" );
      return;
   }

   mGroup->deleteObject();
   mGroup = NULL;   
}

void ExplodePrefabUndoAction::redo()
{
   Prefab *prefab;
   if ( !Sim::findObject( mPrefabId, prefab ) )
   {
      Con::errorf( "ExplodePrefabUndoAction::redo - Prefab (%i) not found.", mPrefabId );
      return;
   }

   mGroup = prefab->explode();

   String name;

   if ( prefab->getName() && prefab->getName()[0] != '\0' )   
      name = prefab->getName();   
   else
      name = "prefab";

   name += "_exploded";
   name = Sim::getUniqueName( name );
   mGroup->assignName( name );   
}

DefineEngineMethod( Prefab, reloadFromFile, void, (),,
   "@brief Mount objB to this object at the desired slot with optional transform.\n\n"

   "@param objB  Object to mount onto us\n"
   "@param slot  Mount slot ID\n"
   "@param txfm (optional) mount offset transform\n"
   "@return true if successful, false if failed (objB is not valid)" )
{
  object->reloadFromFile();
}