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

#include "gui/buttons/guiIconButtonCtrl.h"
#include "gui/editor/guiInspector.h"
#include "gui/editor/inspector/mountingGroup.h"
//#include "gui/editor/inspector/behaviorField.h"
#include "core/strings/stringUnit.h"
#include "T3D/Entity.h"
#include "component/behaviors/behaviorTemplate.h"

//Need this to get node lists
#include "Component/Behaviors/Render/renderInterfaces.h"

IMPLEMENT_CONOBJECT(GuiInspectorMountingGroup);

ConsoleDocClass( GuiInspectorMountingGroup,
   "@brief Used to inspect an object's FieldDictionary (dynamic fields) instead "
   "of regular persistent fields.\n\n"
   "Editor use only.\n\n"
   "@internal"
);

//-----------------------------------------------------------------------------
// GuiInspectorMountingGroup - add custom controls
//-----------------------------------------------------------------------------
GuiInspectorMountingGroup::GuiInspectorMountingGroup( StringTableEntry groupName, SimObjectPtr<GuiInspector> parent )
      : GuiInspectorGroup( groupName, parent) 
{ 
	/*mNeedScroll=false;*/
	mParentInspector = parent;

	targetMountCtrl = NULL;
	mountCtrl = NULL;
};

bool GuiInspectorMountingGroup::createContent()
{
   if(!Parent::createContent())
      return false;

   //give the necessary padding for the nested controls so it looks nice.
   setMargin(RectI(4,0,4,4));

   //Con::evaluatef( "%d.stack = %d;", this->getId(), mStack->getId() );

   //Con::executef( this, "createContent" );

   // encapsulate the button in a dummy control.
   /*GuiControl* shell = new GuiControl();
   shell->setDataField( StringTable->insert("profile"), NULL, "GuiTransparentProfile" );
   if( !shell->registerObject() )
   {
      delete shell;
      return false;
   }

   // add a button that lets us add new dynamic fields.
   GuiBitmapButtonCtrl* addBehaviorBtn = new GuiBitmapButtonCtrl();
   {
      SimObject* profilePtr = Sim::findObject("InspectorDynamicFieldButton");
      if( profilePtr != NULL )
         addBehaviorBtn->setControlProfile( dynamic_cast<GuiControlProfile*>(profilePtr) );
		
		// FIXME Hardcoded image
      addBehaviorBtn->setBitmap("tools/gui/images/iconAdd.png");

      //char commandBuf[64];
      //dSprintf(commandBuf, 64, "%d.addBehavior();", this->getId());
      //addBehaviorBtn->setField("command", commandBuf);
      addBehaviorBtn->setSizing(horizResizeRight,vertResizeCenter);
      //addFieldBtn->setField("buttonMargin", "2 2");
      addBehaviorBtn->resize(Point2I(0,2), Point2I(16, 16));
      addBehaviorBtn->registerObject("AddBehaviorButton");
   }

   mAddBhvrList = new GuiPopUpMenuCtrlEx();
   {
      SimObject* profilePtr = Sim::findObject("GuiPopUpMenuProfile");
      if( profilePtr != NULL )
         mAddBhvrList->setControlProfile( dynamic_cast<GuiControlProfile*>(profilePtr) );

	  // Configure it to update our value when the popup is closed
	  //char szBuffer[512];
	  //dSprintf( szBuffer, 512, "%d.apply( %d.getText() );", getId(), addBehaviorList->getId() );
	  //addBehaviorList->setField("Command", szBuffer );

	  //now add the entries, allow derived classes to override this
	  //_populateMenu( addBehaviorList );

	  // Select the active item, or just set the text field if that fails
	  //S32 id = addBehaviorList->findText(getData());
	  //if (id != -1)
	  //  addBehaviorList->setSelected(id, false);
	  //else
	  //  addBehaviorList->setField("text", getData());

	  mAddBhvrList->setSizing(horizResizeWidth,vertResizeCenter);
	  mAddBhvrList->resize(Point2I(addBehaviorBtn->getPosition().x + addBehaviorBtn->getExtent().x + 2 ,2), Point2I(getWidth() - 16, 16));
      mAddBhvrList->registerObject("eBehaviorList");
   }

   shell->resize(Point2I(0,0), Point2I(getWidth(), 28));
   shell->addObject(addBehaviorBtn);
   shell->addObject(mAddBhvrList);

   // save off the shell control, so we can push it to the bottom of the stack in inspectGroup()
   mAddCtrl = shell;
   mStack->addObject(shell);*/

	//Entity* target = dynamic_cast<Entity*>(mParent->getInspectObject(0));

	/*char cmdBuffer[512];

	S32 xExt = getExtent().x;

	//parentInspector.getObject()->getDivider

	GuiControl *perContainer = new GuiControl();
	perContainer->registerObject();

	persistText = new GuiTextCtrl();
	persistText->registerObject();
	S32 pext = getExtent().x * 0.4;
	persistText->setExtent(getExtent().x * 0.4, 25);
	persistText->setText("Persistant ID");

	S32 rext = getExtent().x * 0.6;
	reloadFile = new GuiButtonCtrl();
	reloadFile->registerObject();
	reloadFile->setPosition(getExtent().x * 0.4, 0);
	reloadFile->setExtent(getExtent().x * 0.6, 25);
	reloadFile->setText("Reload from file");
	reloadFile->setDataField( StringTable->insert("Profile"), NULL, "GuiInspectorButtonProfile" );

	perContainer->addObject(persistText);
	perContainer->addObject(reloadFile);

	//if(!targetDirty)
	//	reloadFile->setActive(false);
	
   dSprintf( cmdBuffer, 512, "%d.reloadFromFile();", target->getId() );

   reloadFile->setField( "Command", cmdBuffer );

	saveFile = new GuiButtonCtrl();
	saveFile->registerObject();
	saveFile->setExtent(getExtent().x, 25);
	saveFile->setText("Save to new prefab");
	saveFile->setDataField( StringTable->insert("Profile"), NULL, "GuiInspectorButtonProfile" );

	dSprintf( cmdBuffer, 512, "EditorMakeNewPrefab();" );

   saveFile->setField( "Command", cmdBuffer );

	overwriteFile = new GuiButtonCtrl();
	overwriteFile->registerObject();
	overwriteFile->setExtent(getExtent().x, 25);
	overwriteFile->setText("Overwrite prefab");
	overwriteFile->setDataField( StringTable->insert("Profile"), NULL, "GuiInspectorButtonProfile" );

	//if(!targetDirty)
	//	overwriteFile->setActive(false);

	dSprintf( cmdBuffer, 512, "EditorOverwritePrefab();" );

   overwriteFile->setField( "Command", cmdBuffer );

	//
	filePath = new GuiControl();
	filePath->registerObject();
	filePath->setExtent(getExtent().x, 25);

	GuiTextEditCtrl* retCtrl = new GuiTextEditCtrl();

   // If we couldn't construct the control, bail!
   if( retCtrl == NULL )
      return retCtrl;

   // Let's make it look pretty.
   retCtrl->setDataField( StringTable->insert("profile"), NULL, "GuiInspectorTextEditRightProfile" );
   retCtrl->setDataField( StringTable->insert("tooltipprofile"), NULL, "GuiToolTipProfile" );
   retCtrl->setDataField( StringTable->insert("hovertime"), NULL, "1000" );

   // Don't forget to register ourselves
	retCtrl->registerObject();
	filePath->addObject(retCtrl);

   char szBuffer[512];
   dSprintf( szBuffer, 512, "%d.filename = %d.getText();",target->getId(),retCtrl->getId() );
   retCtrl->setField("AltCommand", szBuffer );
   retCtrl->setField("Validate", szBuffer );
	retCtrl->setText(target->getFilename());

   mBrowseButton = new GuiButtonCtrl();

   if( mBrowseButton != NULL )
   {
      RectI browseRect( Point2I( ( filePath->getLeft() + filePath->getWidth()) - 26, filePath->getTop() + 2), Point2I(20, filePath->getHeight() - 4) );
      const char *fileSpec = "Prefab Files (*.prefab)|*.prefab|All Files (*.*)|*.*|";

      dSprintf( cmdBuffer, 512, "getLoadFilename(\"%s\", \"%d.apply\", %d.getData());", fileSpec, getId(), getId() );

      mBrowseButton->setField( "Command", cmdBuffer );
      mBrowseButton->setField( "text", "..." );
      mBrowseButton->setDataField( StringTable->insert("Profile"), NULL, "GuiInspectorButtonProfile" );
      mBrowseButton->registerObject();
      //addObject( mBrowseButton );
		filePath->addObject(mBrowseButton);

      // Position
      mBrowseButton->resize( browseRect.point, browseRect.extent );
   }

	//filePath->addObject(mBrowseButton);
	//filePath->addObject(retCtrl);
	//
	
   mStack->addObject(perContainer);
	mStack->addObject(saveFile);
	mStack->addObject(overwriteFile);	
	mStack->addObject(filePath);*/

   /*targetMountCtrl = new GuiControl();
   targetMountText = new GuiTextCtrl();
   targetMountNode = dynamic_cast<GuiPopUpMenuCtrl*>(buildMenuCtrl());

	mountCtrl = new GuiControl();
	mountText = new GuiTextCtrl();
	mountNode = dynamic_cast<GuiPopUpMenuCtrl*>(buildMenuCtrl());

	targetMountCtrl->registerObject();
	mountCtrl->registerObject();

	targetMountText->registerObject();
	mountText->registerObject();

	targetMountCtrl->addObject(targetMountText);
	targetMountCtrl->addObject(targetMountNode);

	mountCtrl->addObject(mountText);
	mountCtrl->addObject(mountNode);*/

   //now add the entries, allow derived classes to override this
   //_populateMenu( menu );

   // Select the active item, or just set the text field if that fails
   /*S32 id = menu->findText(GuiInspectorTypeMenuBase::getData());
   if (id != -1)
      menu->setSelected(id, false);
   else
      menu->setField("text", GuiInspectorTypeMenuBase::getData());

   return retCtrl;*/

   return true;
}

GuiControl* GuiInspectorMountingGroup::buildMenuCtrl()
{
	GuiControl* retCtrl = new GuiPopUpMenuCtrl();

   // If we couldn't construct the control, bail!
   if( retCtrl == NULL )
      return retCtrl;

   GuiPopUpMenuCtrl *menu = dynamic_cast<GuiPopUpMenuCtrl*>(retCtrl);

   // Let's make it look pretty.
   retCtrl->setDataField( StringTable->insert("profile"), NULL, "GuiPopUpMenuProfile" );
   //GuiInspectorTypeMenuBase::_registerEditControl( retCtrl );

	char szName[512];
   dSprintf( szName, 512, "IE_%s_%d_%s_Field", retCtrl->getClassName(), mParentInspector->getInspectObject()->getId(), mCaption);

   // Register the object
   retCtrl->registerObject( szName );

   // Configure it to update our value when the popup is closed
   char szBuffer[512];
   dSprintf( szBuffer, 512, "%d.apply( %d.getText() );", getId(), menu->getId() );
   menu->setField("Command", szBuffer );

	return menu;

   //now add the entries, allow derived classes to override this
   //_populateMenu( menu );

   // Select the active item, or just set the text field if that fails
   /*S32 id = menu->findText(GuiInspectorTypeMenuBase::getData());
   if (id != -1)
      menu->setSelected(id, false);
   else
      menu->setField("text", GuiInspectorTypeMenuBase::getData());

   return retCtrl;*/
}

bool GuiInspectorMountingGroup::buildList(Entity* ent, GuiPopUpMenuCtrl* menu)
{
	TSShapeInstanceInterface* tsI = ent->getInterface<TSShapeInstanceInterface>();

	if(tsI)
	{
		S32 nodeCount = tsI->getShapeInstance()->getShape()->nodes.size();

		for(U32 i=0; i < nodeCount; i++)
		{
			menu->addEntry(tsI->getShapeInstance()->getShape()->names[i], i);
		}

		return true;
	}

	return false;
}

//-----------------------------------------------------------------------------
// GuiInspectorMountingGroup - inspectGroup override
//-----------------------------------------------------------------------------
bool GuiInspectorMountingGroup::inspectGroup()
{
   // We can't inspect a group without a target!
   if( !mParent->getNumInspectObjects() )
      return false;

   // to prevent crazy resizing, we'll just freeze our stack for a sec..
   mStack->freeze(true);

   bool bNoGroup = false;

   // Un-grouped fields are all sorted into the 'general' group
   if ( dStricmp( mCaption, "General" ) == 0 )
      bNoGroup = true;
      
   // Just delete all fields and recreate them (like the dynamicGroup)
   // because that makes creating controls for array fields a lot easier
   clearFields();
   
   bool bNewItems = false;
   bool bMakingArray = false;
   GuiStackControl *pArrayStack = NULL;
   GuiRolloutCtrl *pArrayRollout = NULL;
   bool bGrabItems = false;

   AbstractClassRep* commonAncestorClass = findCommonAncestorClass();
   AbstractClassRep::FieldList& fieldList = commonAncestorClass->mFieldList;
   for( AbstractClassRep::FieldList::iterator itr = fieldList.begin();
        itr != fieldList.end(); ++ itr )
   {
      AbstractClassRep::Field* field = &( *itr );
      if( field->type == AbstractClassRep::StartGroupFieldType )
      {
         // If we're dealing with general fields, always set grabItems to true (to skip them)
         if( bNoGroup == true )
            bGrabItems = true;
         else if( dStricmp( field->pGroupname, mCaption ) == 0 )
            bGrabItems = true;
         continue;
      }
      else if ( field->type == AbstractClassRep::EndGroupFieldType )
      {
         // If we're dealing with general fields, always set grabItems to false (to grab them)
         if( bNoGroup == true )
            bGrabItems = false;
         else if( dStricmp( field->pGroupname, mCaption ) == 0 )
            bGrabItems = false;
         continue;
      }
      
      // Skip field if it has the HideInInspectors flag set.
      
      if( field->flag.test( AbstractClassRep::FIELD_HideInInspectors ) )
         continue;

      if( ( bGrabItems == true || ( bNoGroup == true && bGrabItems == false ) ) && itr->type != AbstractClassRep::DeprecatedFieldType )
      {
         if( bNoGroup == true && bGrabItems == true )
            continue;

         /*if ( field->type == AbstractClassRep::StartArrayFieldType )
         {
            #ifdef DEBUG_SPEW
            Platform::outputDebugString( "[GuiInspectorGroup] Beginning array '%s'",
               field->pFieldname );
            #endif
            
            // Starting an array...
            // Create a rollout for the Array, give it the array's name.
            GuiRolloutCtrl *arrayRollout = new GuiRolloutCtrl();            
            GuiControlProfile *arrayRolloutProfile = dynamic_cast<GuiControlProfile*>( Sim::findObject( "GuiInspectorRolloutProfile0" ) );
            
            arrayRollout->setControlProfile(arrayRolloutProfile);
            //arrayRollout->mCaption = StringTable->insert( String::ToString( "%s (%i)", field->pGroupname, field->elementCount ) );
            arrayRollout->setCaption( field->pGroupname );
            //arrayRollout->setMargin( 14, 0, 0, 0 );
            arrayRollout->registerObject();
            
            GuiStackControl *arrayStack = new GuiStackControl();
            arrayStack->registerObject();
            arrayStack->freeze(true);
            arrayRollout->addObject(arrayStack);
            
            // Allocate a rollout for each element-count in the array
            // Give it the element count name.
            for ( U32 i = 0; i < field->elementCount; i++ )
            {
               GuiRolloutCtrl *elementRollout = new GuiRolloutCtrl();            
               GuiControlProfile *elementRolloutProfile = dynamic_cast<GuiControlProfile*>( Sim::findObject( "GuiInspectorRolloutProfile0" ) );
               
               char buf[256];
               dSprintf( buf, 256, "  [%i]", i ); 
               
               elementRollout->setControlProfile(elementRolloutProfile);
               elementRollout->setCaption(buf);
               //elementRollout->setMargin( 14, 0, 0, 0 );
               elementRollout->registerObject();
               
               GuiStackControl *elementStack = new GuiStackControl();
               elementStack->registerObject();            
               elementRollout->addObject(elementStack);
               elementRollout->instantCollapse();
               
               arrayStack->addObject( elementRollout );
            }
            
            pArrayRollout = arrayRollout;
            pArrayStack = arrayStack;
            arrayStack->freeze(false);
            pArrayRollout->instantCollapse();
            mStack->addObject(arrayRollout);
            
            bMakingArray = true;
            continue;
         }      
         else if ( field->type == AbstractClassRep::EndArrayFieldType )
         {
            #ifdef DEBUG_SPEW
            Platform::outputDebugString( "[GuiInspectorGroup] Ending array '%s'",
               field->pFieldname );
            #endif

            bMakingArray = false;
            continue;
         }
         
         if ( bMakingArray )
         {
            // Add a GuiInspectorField for this field, 
            // for every element in the array...
            for ( U32 i = 0; i < pArrayStack->size(); i++ )
            {
               FrameTemp<char> intToStr( 64 );
               dSprintf( intToStr, 64, "%d", i );
               
               // The array stack should have a rollout for each element
               // as children...
               GuiRolloutCtrl *pRollout = dynamic_cast<GuiRolloutCtrl*>(pArrayStack->at(i));
               // And the each of those rollouts should have a stack for 
               // fields...
               GuiStackControl *pStack = dynamic_cast<GuiStackControl*>(pRollout->at(0));
               
               // And we add a new GuiInspectorField to each of those stacks...            
               GuiInspectorField *fieldGui = constructField( field->type );
               if ( fieldGui == NULL )                
                  fieldGui = new GuiInspectorField();
               
               fieldGui->init( mParent, this );
               StringTableEntry caption = field->pFieldname;
               fieldGui->setInspectorField( field, caption, intToStr );
               
               if( fieldGui->registerObject() )
               {
                  #ifdef DEBUG_SPEW
                  Platform::outputDebugString( "[GuiInspectorGroup] Adding array element '%s[%i]'",
                     field->pFieldname, i );
                  #endif

                  mChildren.push_back( fieldGui );
                  pStack->addObject( fieldGui );
               }
               else
                  delete fieldGui;
            }
            
            continue;
         }
         
         // This is weird, but it should work for now. - JDD
         // We are going to check to see if this item is an array
         // if so, we're going to construct a field for each array element
         if( field->elementCount > 1 )
         {
            // Make a rollout control for this array
            //
            GuiRolloutCtrl *rollout = new GuiRolloutCtrl();  
            rollout->setDataField( StringTable->insert("profile"), NULL, "GuiInspectorRolloutProfile0" );            
            rollout->setCaption(String::ToString( "%s (%i)", field->pFieldname, field->elementCount));
            rollout->setMargin( 14, 0, 0, 0 );
            rollout->registerObject();
            mArrayCtrls.push_back(rollout);
            
            // Put a stack control within the rollout
            //
            GuiStackControl *stack = new GuiStackControl();
            stack->setDataField( StringTable->insert("profile"), NULL, "GuiInspectorStackProfile" );
            stack->registerObject();
            stack->freeze(true);
            rollout->addObject(stack);
            
            mStack->addObject(rollout);
            
            // Create each field and add it to the stack.
            //
            for (S32 nI = 0; nI < field->elementCount; nI++)
            {
               FrameTemp<char> intToStr( 64 );
               dSprintf( intToStr, 64, "%d", nI );
               
               // Construct proper ValueName[nI] format which is "ValueName0" for index 0, etc.
               
               String fieldName = String::ToString( "%s%d", field->pFieldname, nI );
               
               // If the field already exists, just update it
               GuiInspectorField *fieldGui = findField( fieldName );
               if( fieldGui != NULL )
               {
                  fieldGui->updateValue();
                  continue;
               }
               
               bNewItems = true;
               
               fieldGui = constructField( field->type );
               if ( fieldGui == NULL )               
                  fieldGui = new GuiInspectorField();
               
               fieldGui->init( mParent, this );               
               StringTableEntry caption = StringTable->insert( String::ToString("   [%i]",nI) );
               fieldGui->setInspectorField( field, caption, intToStr );
               
               if ( fieldGui->registerObject() )
               {
                  mChildren.push_back( fieldGui );
                  stack->addObject( fieldGui );
               }
               else
                  delete fieldGui;
            }
            
            stack->freeze(false);
            stack->updatePanes();
            rollout->instantCollapse();
         }
         else
         {*/
            // If the field already exists, just update it
				GuiInspectorField *fieldGui = findField( field->pFieldname );
				if ( fieldGui != NULL )
				{
					fieldGui->updateValue();
					continue;
				}
            
				bNewItems = true;
            
				if(field->pFieldname == StringTable->insert("mountNode"))
				{
					fieldGui = new GuiInspectorNodeListField();

					Entity* e = dynamic_cast<Entity*>(mParent->getInspectObject(0));
					if(e)
						(dynamic_cast<GuiInspectorNodeListField*>(fieldGui))->setTargetEntity(e);
				}
				else
				{
					fieldGui = constructField( field->type );
					if ( fieldGui == NULL )
						fieldGui = new GuiInspectorField();
				}

				fieldGui->init( mParent, this );            
				fieldGui->setInspectorField( field );
                     
				if( fieldGui->registerObject() )
				{
					#ifdef DEBUG_SPEW
					Platform::outputDebugString( "[GuiInspectorGroup] Adding field '%s'",
						field->pFieldname );
					#endif

					mChildren.push_back( fieldGui );
					mStack->addObject( fieldGui );
				}
				else
				{
					SAFE_DELETE( fieldGui );
				}
         //}
      }
   }
   mStack->freeze(false);
   mStack->updatePanes();

   // If we've no new items, there's no need to resize anything!
   if( bNewItems == false && !mChildren.empty() )
      return true;

   sizeToContents();

   setUpdate();

   return true;
}

void GuiInspectorMountingGroup::updateAllFields()
{
   // We overload this to just reinspect the group.
   inspectGroup();
}

void GuiInspectorMountingGroup::onMouseMove(const GuiEvent &event)
{
	//mParent->mOverDivider = false;
	bool test = false;
}
ConsoleMethod(GuiInspectorMountingGroup, inspectGroup, bool, 2, 2, "Refreshes the dynamic fields in the inspector.")
{
   return object->inspectGroup();
}

void GuiInspectorMountingGroup::clearFields()
{
   // save mAddCtrl
   //Sim::getGuiGroup()->addObject(mAddCtrl);
   // delete everything else
   //mStack->clear();
   // clear the mChildren list.
   //mChildren.clear();
   // and restore.
   //mStack->addObject(mAddCtrl);
}

bool GuiInspectorMountingGroup::resize( const Point2I &newPosition, const Point2I &newExtent )
{
   if ( !Parent::resize( newPosition, newExtent ) )
      return false;

	//check if we're set up yet
	if(!targetMountCtrl || !mountCtrl)
		//no? bail
		return false;

	targetMountCtrl->setExtent(newExtent.x, 18);
	mountCtrl->setExtent(newExtent.x, 18);

	S32 dividerPos, dividerMargin;
   mParentInspector->getDivider( dividerPos, dividerMargin );   

   Point2I fieldExtent = Point2I(newExtent.x, 18);
   Point2I fieldPos = Point2I(newExtent.x, 18);

   S32 editWidth = dividerPos - dividerMargin;

	targetMountText->setPosition(0,0);
	targetMountText->setExtent(fieldExtent.x - dividerPos - dividerMargin, fieldExtent.y);

	targetMountNode->setPosition(fieldExtent.x - dividerPos + dividerMargin, 1);
	targetMountNode->setExtent(editWidth, fieldExtent.y - 1);

	mountText->setPosition(0,0);
	mountText->setExtent(fieldExtent.x - dividerPos - dividerMargin, fieldExtent.y);

	mountNode->setPosition(fieldExtent.x - dividerPos + dividerMargin, 1);
	mountNode->setExtent(editWidth, fieldExtent.y - 1);

   return true;
}

SimFieldDictionary::Entry* GuiInspectorMountingGroup::findDynamicFieldInDictionary( StringTableEntry fieldName )
{
   SimFieldDictionary * fieldDictionary = mParent->getInspectObject()->getFieldDictionary();

   for(SimFieldDictionaryIterator ditr(fieldDictionary); *ditr; ++ditr)
   {
      SimFieldDictionary::Entry * entry = (*ditr);

      if( entry->slotName == fieldName )
         return entry;
   }

   return NULL;
}

void GuiInspectorMountingGroup::addDynamicField()
{
   // We can't add a field without a target
   /*if( !mStack )
   {
      Con::warnf("GuiInspectorMountingGroup::addDynamicField - no target SimObject to add a dynamic field to.");
      return;
   }

   // find a field name that is not in use. 
   // But we wont try more than 100 times to find an available field.
   U32 uid = 1;
   char buf[64] = "dynamicField";
   SimFieldDictionary::Entry* entry = findDynamicFieldInDictionary(buf);
   while(entry != NULL && uid < 100)
   {
      dSprintf(buf, sizeof(buf), "dynamicField%03d", uid++);
      entry = findDynamicFieldInDictionary(buf);
   }
   
   const U32 numTargets = mParent->getNumInspectObjects();
   if( numTargets > 1 )
      Con::executef( mParent, "onBeginCompoundEdit" );

   for( U32 i = 0; i < numTargets; ++ i )
   {
      SimObject* target = mParent->getInspectObject( i );
      
      Con::evaluatef( "%d.dynamicField = \"defaultValue\";", target->getId(), buf );
 
      // Notify script.
   
      Con::executef( mParent, "onFieldAdded", target->getIdString(), buf );
   }
   
   if( numTargets > 1 )
      Con::executef( mParent, "onEndCompoundEdit" );

   // now we simply re-inspect the object, to see the new field.
   inspectGroup();
   instantExpand();*/
}

AbstractClassRep::Field* GuiInspectorMountingGroup::findObjectBehaviorField(BehaviorInstance* target, String fieldName)
{
   AbstractClassRep::FieldList& fieldList = target->getClassRep()->mFieldList;
   for( AbstractClassRep::FieldList::iterator itr = fieldList.begin();
		itr != fieldList.end(); ++ itr )
   {
	  AbstractClassRep::Field* field = &( *itr );
	  String fldNm(field->pFieldname);
	  if(fldNm == fieldName)
		  return field;
   }
   return NULL;
}
ConsoleMethod( GuiInspectorMountingGroup, addDynamicField, void, 2, 2, "obj.addDynamicField();" )
{
   object->addDynamicField();
}

ConsoleMethod( GuiInspectorMountingGroup, removeDynamicField, void, 3, 3, "" )
{
}

//
IMPLEMENT_CONOBJECT( GuiInspectorNodeListField );

ConsoleDocClass( GuiInspectorNodeListField,
   "@brief A control that allows to edit the custom properties (text) of one or more SimObjects.\n\n"
   "Editor use only.\n\n"
   "@internal"
);

GuiInspectorNodeListField::GuiInspectorNodeListField( GuiInspector *inspector,
                                                    GuiInspectorGroup* parent, 
                                                    SimFieldDictionary::Entry* field,
																	 SimObjectPtr<Entity> target )
{
   mInspector = inspector;
   mParent = parent;
   setBounds(0,0,100,20);   
	mTargetEntity = target;
}

GuiInspectorNodeListField::GuiInspectorNodeListField()
{
   mInspector = NULL;
   mParent = NULL;
}

void GuiInspectorNodeListField::setData( const char* data, bool callbacks )
{
   mCustomValue = data;

	//We aren't updating any mounting info if we're not mounted already
	if(mTargetEntity.getObject())
	{
		Entity* target = dynamic_cast<Entity*>(mTargetEntity->getObjectMount());
		if(target)
		{
			TSShapeInstanceInterface* tsI = target->getInterface<TSShapeInstanceInterface>();
			if(tsI)
			{
				if(tsI->getShapeInstance())
				{
					S32 nodeIdx = tsI->getShapeInstance()->getShape()->findNode(data);
				
					target->mountObject(mTargetEntity, nodeIdx, MatrixF::Identity);
					mTargetEntity->setMaskBits(Entity::MountedMask);
				}
			}
		}
	}

   // Force our edit to update
   updateValue();
}

const char* GuiInspectorNodeListField::getData( U32 inspectObjectIndex )
{
   return mCustomValue;
}

void GuiInspectorNodeListField::updateValue()
{
	mMenu->clear();
	//mMenu->addEntry("Origin");

	//if(mCustomValue.isEmpty())
	if(mTargetEntity.getObject())
	{
		Entity* target = dynamic_cast<Entity*>(mTargetEntity->getObjectMount());
		if(target)
		{
			mMenu->addEntry("Origin");
			mMenu->setActive(true);

			TSShapeInstanceInterface* tsI = target->getInterface<TSShapeInstanceInterface>();

			if(tsI)
			{
				S32 nodeCount = tsI->getShapeInstance()->getShape()->nodes.size();

				for(U32 i=0; i < nodeCount; i++)
				{
					mMenu->addEntry(tsI->getShapeInstance()->getShape()->names[i], i);
				}

				S32 targetNode = mTargetEntity->getMountNode();
				if(targetNode != -1)
				{
					String name = tsI->getShapeInstance()->getShape()->names[targetNode];
					mCustomValue = name;
				}
				else
				{
					mCustomValue = String("Origin");
				}

				setValue( mCustomValue );
				return;
			}
		}
	}

	//mMenu->clear();
	//mMenu->setText("Not Mounted");
	//mEdit->clear();
	setValue("Not Mounted");
	mMenu->setActive(false);
}

void GuiInspectorNodeListField::setDoc( const char* doc )
{
   mDoc = StringTable->insert( doc, true );
}

void GuiInspectorNodeListField::setToolTip( StringTableEntry data )
{
   static StringTableEntry sTooltipProfile = StringTable->insert( "tooltipProfile" );
   static StringTableEntry sHoverTime = StringTable->insert( "hovertime" );
   static StringTableEntry sTooltip = StringTable->insert( "tooltip" );
   
   mEdit->setDataField( sTooltipProfile, NULL, "GuiToolTipProfile" );
   mEdit->setDataField( sHoverTime, NULL, "1000" );
   mEdit->setDataField( sTooltip, NULL, data );
}

bool GuiInspectorNodeListField::onAdd()
{
   if( !Parent::onAdd() )
      return false;

   return true;
}

void GuiInspectorNodeListField::setInspectorField( AbstractClassRep::Field *field, 
                                                  StringTableEntry caption, 
                                                  const char*arrayIndex ) 
{
   // Override the base just to be sure it doesn't get called.
   // We don't use an AbstractClassRep::Field...

	mField = field;
	mCaption = field->pFieldname;
	mDoc = field->pFieldDocs;
//    mField = field; 
//    mCaption = StringTable->EmptyString();
//    mRenameCtrl->setText( getFieldName() );
}

GuiControl* GuiInspectorNodeListField::constructEditControl()
{
   GuiControl* retCtrl = new GuiPopUpMenuCtrl();

	mMenu = dynamic_cast<GuiPopUpMenuCtrl*>(retCtrl);

   static StringTableEntry sProfile = StringTable->insert( "profile" );
   retCtrl->setDataField( sProfile, NULL, "ToolsGuiPopUpMenuEditProfile" );

   // Register the object
   retCtrl->registerObject();

	char szBuffer[512];
	dSprintf( szBuffer, 512, "%d.apply( %d.getText() );", getId(), mMenu->getId() );
	mMenu->setField("Command", szBuffer );

   return retCtrl;
}

void GuiInspectorNodeListField::setValue( const char* newValue )
{
   GuiPopUpMenuCtrl *ctrl = dynamic_cast<GuiPopUpMenuCtrl*>( mEdit );
   if( ctrl != NULL )
      ctrl->setText( newValue );
}

void GuiInspectorNodeListField::_executeSelectedCallback()
{
   Con::executef( mInspector, "onFieldSelected", mCaption, ConsoleBaseType::getType(TypeCaseString)->getTypeName(), mDoc );
}

void GuiInspectorNodeListField::setTargetEntity(SimObjectPtr<Entity> target)
{
	mTargetEntity = target;
}