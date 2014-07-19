//BehaviorManager.cs

//! (string behaviorClass, string behaviorSuperclass)
//! Add a behavior to the list of available behaviors.  
//! @param behaviorClass The behavior name
//! @param behaviorSuperclass The behavior name
function registerBehavior( %behaviorClass, %behaviorSuperclass)
{
   error("crap register behavior?!!!");
   if (%behaviorClass $= "")
   {
      error ("registerBehavior - no behaviorClass provided.  Aborting registration.");
      return;
   }
   %templateName = %behaviorClass @ "_Template";
   if (isObject(%templateName))
   {
      error ("registerBehavior - "@%behaviorClass@" already exists.  Deleting old version and replacing.");
      %templateName.delete();
   }
   %behavior = new BehaviorTemplate(%templateName)
   {
      internalName = %behaviorClass;
      friendlyName = %behaviorClass;
      behaviorClass = %behaviorClass;
      behaviorSuperclass = %behaviorSuperClass;
   };
   
   return %behavior;
}

//! (simObject this, string behaviorList, bool doConfirmDialog)
//! Remove a list of behaviors from the list of available behaviors, then delete the behaviors from the simulation.
//! The behaviors will be automatically removed from all scene objects and the scenegraph.
//! Generally this function would be used by a resourceDatabase file.
//! @param this This BehaviorManager
//! @param behaviorList Space separated list of behaviors
//! @param doConfirmDialog If true, confirm that user wants the behavior information removed from all objects in the scene

function BehaviorManager::unRegisterBehaviors(%this, %behaviorList, %doConfirmDialog)
{
   %count = getWordCount(%behaviorList);
   for (%i = 0; %i < %count; %i++)
   {
      %behaviorText = %behaviorText @ getWord(%behaviorList, %i) @"\n";
   }   
   if (%doConfirmDialog) 
   {
      messageBoxOkCancelDetails(
         "Behaviors Removed", 
         "Behaviors are being removed from your project. Would you like to remove all associated behavior information from the objects in your scene? (recommended)",
         %behaviorText, 
         "BehaviorManager.unRegisterBehaviors(\""@%behaviorList@"\");",
         "BehaviorManager.deleteBehaviorObjects(\""@%behaviorList@"\");"
         );
      return;
   }
         
   for (%i = 0; %i < %count; %i++)
   {
      %behavior = getWord (%behaviorList, 0);
      %behaviorList = removeWord(%behaviorList, 0);
      
      //remove behavior from all objects
      %scenegraph = ToolManager.getLastWindow().getSceneGraph();
      if (isObject(%scenegraph))
      {
         %listItem = 0;
         %objectCount = %scenegraph.getSceneObjectCount();
         for (%l = 0; %l < %objectCount; %l++)
         {
            %object = %scenegraph.getSceneObject(%l);
            if (wordPos (%object.BehaviorList, %behavior) != -1)
               %this.removeBehavior( %object, %behavior);
         }
      }
      
      // remove behavior from the scenegraph
      if (wordPos (%sceneGraph.BehaviorList, %behavior) != -1) 
         %this.removeBehavior( %scenegraph, %behavior);      
   }
   // remove behaviors from simulation
   %this.deleteBehaviorObjects(%behaviorList);         
}

//! (simObject this, string behaviorList)
//! Delete behaviors from the simulation.  Basically a helper for /c unregisterBehaviors
//! @param this This BehaviorManager
//! @param behaviorList Space separated list of behaviors

function BehaviorManager::deleteBehaviorObjects(%this, %behaviorList)
{ 
   %count = getWordCount(%behaviorList);
   for (%i = 0; %i < %count; %i++)
   {
      %behavior = getWord (%behaviorList, 0);
      %behaviorList = removeWord(%behaviorList, 0);
      
      %behavior.delete();     
   }
   GuiFormManager::SendContentMessage( $LBQuickEdit, %this, "inspectUpdate" );   
}

//! (simobject this, simobject obj, string behavior)
//! Add behavior fields to an object, set to their default values
//! @param this This BehaviorManager
//! @param obj The object
//! @param behavior The behavior name
function BehaviorManager::addBehavior(%this, %obj, %behavior)
{  
   //make sure the behavior is appropriate, otherwise warning
   //we will not cancel the behavior add because this must have been called explicitly from script
   if (!%behavior.validateObjectClass(%obj)) 
   {
      error("WARNING: addBehavior(" @ %obj.getID() @ ", " @ %behavior @ ") Behavior is only designed for the following classes: " @ %behavior.validObjectClassList );
   }
   
   //add the behavior to the objects behaviorlist, if necessary
   if (wordPos(%obj.BehaviorList, %behavior) == -1) 
   {
      %obj.BehaviorList = setWord( %obj.BehaviorList, getWordCount( %obj.BehaviorList), %behavior);
   }
      
   //set dynamic fields on %obj to default values
   for(%i = 0; %behavior.field[%i] !$= ""; %i++)  
   {
      %newFieldData = %behavior.field[%i];
      %FieldName = getfield(%newFieldData,0);
      %FieldDefault = getfield(%newFieldData,1);
      %command = %obj@"."@%FieldName@" = "@%FieldDefault@";";
      if (%fieldDefault !$= "") 
         eval(%command);
   }
}

//! (simobject this, simobject obj, string behavior)
//! Remove behavior fields to an object by setting their values to empty string
//! @param this This BehaviorManager
//! @param obj The object
//! @param behavior The behavior name
function BehaviorManager::removeBehavior(%this, %obj,%behavior)
{      
   //set dynamic fields on %obj to ""
   for(%i = 0; %i < %behavior.fieldCount; %i++)  
   {
      %newFieldData = %behavior.field[%i];
      %FieldName = getfield(%newFieldData,0);
      %command = %obj@"."@%FieldName@" = \"\";";
      eval(%command);
   }
   
   //remove the behavior from the objects behaviorlist, if necessary
   if (wordPos(%obj.BehaviorList, %behavior) != -1)
      %obj.BehaviorList = removeWord( %obj.BehaviorList, wordPos(%obj.BehaviorList, %behavior));
}

//! (simobject this, simobject obj, string behavior, bool skipDependency Requirements)
//! Check to see if this behavior conflicts with other behaviors on an object.
//! This conflict can consist of 
//! \li class type (incorrect)
//! \li behavior fields (same names as other behaviors)
//! \li dependencies (unfulfilled requirements)
//! \li dependencies (conflicted with other behaviors)
//! \li prefix (same as other behaviors)
//! @param this This BehaviorTemplate
//! @param obj The object to check 
//! @param skipDependencyRequirements If true, unmet dependency requirements are ignored
//! @return If there is a conflict, a list of tab separated conflict strings.  These strings are in plain English, since the purpose of this function is to generate readable warnings.  If no warnings, returns empty string
function BehaviorTemplate::getConflictList (%this, %obj, %behavior, %skipDependencyRequirements)
{ 
   return ""; //IDS FOR NOW
   
   %conflictNum = 0;
   // loop through behaviorList
   %count = %obj.getBehaviorCount();   
   //check for object type conflict          
   if (!%behavior.validateObjectClass(%obj)) 
   {
      %conflictList = setField(%conflictList, %conflictNum, "Valid Class List: "@%behavior.validObjectClassList);
      %conflictNum++;        
   }     
   if (!%skipDependencyRequirements)
   {
      // get unmet dependency requirement list
      %unmetList = %this.checkForUnmetDependencies(%obj, %behavior);
      
      // loop through behavior dependencies to make sure requirements are met
      %unmetCount = getFieldCount(%unmetList);
      for (%j = 0; %j < %unmetCount; %j+=2)
      {
         %dependencyField = getField(%unmetList, %j);
         %dependencyValue = getField(%unmetList, %j+1);
         %conflictList = setField(%conflictList, %conflictNum, %dependencyField SPC "should be set to \"" @ %dependencyValue @"\"");
         %conflictNum++;
      }                  
   }
   for (%i = 0; %i < %count; %i++)
   {
      %checkBehavior = getWord(%behaviorList, %i);
      if (%checkBehavior $= %behavior) continue;  //let's not conflict with ourselves, at least
      // loop through behavior fields
      for (%j = 0; %j < %behavior.fieldCount; %j++)
      {
         %field = getField(%behavior.field[%j],0);
         // loop through behaviorList fields
         for (%k = 0; %k < %checkBehavior.fieldCount; %k++)
         {
            %checkField = getField(%checkBehavior.field[%k],0);
            if (%field $= %checkField)
            {
               %conflictList = setField(%conflictList, %conflictNum, %checkField SPC "also exists in" SPC %checkBehavior);
               %conflictNum++;
            }
         }
      }
      // loop through behavior dependencies
      for (%j = 0; %j < %behavior.dependencyCount; %j++)
      {
         %dependency = getField(%behavior.dependency[%j],0);
         %dependencyValue = getField(%behavior.dependency[%j],1);
         for (%k = 0; %k < %checkBehavior.dependencyCount; %k++)
         {
            %checkdependency = getField(%checkBehavior.dependency[%k],0);
            %checkDependencyValue = getField(%checkBehavior.dependency[%k],1);            
            if (%dependency $= %checkdependency && %dependencyValue !$= %checkDependencyValue)
            {
               //note: setField has nothing to do with %field or %checkField... it's just a tab delimiter
               %conflictList = setField(%conflictList, %conflictNum, %checkDependency SPC "requirement conflicts with" SPC %checkBehavior);
               %conflictNum++;
            }
         } 
      }
      //check for prefix conflict
      if (%checkBehavior.fieldPrefix $= %behavior.fieldPrefix && %checkBehavior.fieldPrefix !$= "") 
      {
         %conflictList = setField(%conflictList, %conflictNum, "fieldPrefix("@%checkBehavior.fieldPrefix@") same as in" SPC %checkBehavior);
         %conflictNum++;        
      }                  
   }
   return %conflictList;
}

//! (simobject this, simobject obj, string behavior)
//! Get a list of an object's unmet dependency requirements for a given behavior
//! @param this This BehaviorManager
//! @param obj The object to check
//! @param behavior The behavior to check
//! @return If there are unmet dependencies, return them in a list of field pairs of the form: "dependencyField TAB requiredValue"

function BehaviorManager::checkForUnmetDependencies(%behavior)
{
   // loop through behavior dependencies to make sure requirements are met
   %conflictNum = 0;
   %conflictList = "";
   %template = %behavior.getTemplateName();
   for (%j = 0; %j < %template.dependencyCount; %j++)
   {
      %dependency = %template.dependency[%j];
      %met = false;
      
      %bhvr = %behavior.owner.getBehavior(%dependency);
                  
      if(!isObject(%bhvr))
      //if (!%behavior.owner.getBehaviorByType(%dependency)) //check if we have a behavior of the type in question
      {
         %conflictList = %conflictList TAB %dependency;
         %conflictNum++;
      }
   }
   
   return %conflictList;
}

function BehaviorManager::checkForDependants(%behavior)
{
   // loop through behavior dependencies to see if any other behaviors are dependant
   //on the one we're checking against
   %conflictNum = 0;
   %conflictList = "";
   %template = %behavior.getTemplateName();
   for(%i = 0; %i < %behavior.owner.getBehaviorCount(); %i++)
   {
      %chkBhvrI = %behavior.owner.getBehaviorByIndex(%i);
      if(%chkBhvrI == %behavior)
         continue;
         
      %chkBhvr = %chkBhvrI.getTemplateName();
      for (%j = 0; %j < %chkBhvr.dependencyCount; %j++)
      {
         %dependency = %chkBhvr.dependency[%j];
          
         %bhvr = %behavior.owner.getBehavior(%dependency);
                     
         if(%bhvr == %behavior)
         {
            if(%conflictList !$= "")
               %conflictList = %conflictList TAB %chkBhvr;
            else
               %conflictList = %chkBhvr;
            %conflictNum++;
         }
      }
   }
   
   return %conflictList;
}

function BehaviorInstance::ghostToClient(%this, %client)
{
   if(%this.template.networked == true && %client !$= "")
   {
      //Ok, we do actually need to scope this to any connecting clients
      %this.scopeToClient(%client);
      //then, force an update to the behavior to get it to actually pass it's networked data(if any)
      %this.owner.setBehaviorsDirty();
   }
}

//! (simobject this, simobject obj, string behavior)
//! Automatically set an object's fields so that all behavior dependencies are met
//! @param this This BehaviorManager
//! @param obj The object to fix
//! @param behavior The behavior to check

function BehaviorManager::autoFixObjectDependencies(%this, %obj, %behavior)
{
   // loop through behavior dependencies and set them
   for (%j = 0; %j < %behavior.dependencyCount; %j++)
   {
      %behavior.setDependencyObjectValue( %j, %obj);
   }
}

//! (simobject this, string behavior, string field)
//! Checks to see if a field belongs to a given behavior
//! @param this This BehaviorManager
//! @param behavior The behavior to check in
//! @param field The field name
//! @return True indicates that the field is defined in the behavior
function BehaviorManager::isBehaviorField(%this, %behavior, %field)
{   
   if(isObject(%behavior))
   {
      //set dynamic fields on %obj to ""
      for(%i = 0; %i < %behavior.fieldCount; %i++)  
      {
         %newFieldData = %behavior.field[%i];
         %FieldName = getField(%newFieldData,0);
         if (%fieldName $= %field) return true;
      }
   }
   return false;
}

//! (simobject this)
//! Get a list of available behaviors
//! @param this This BehaviorManager
//! @return Space delimited list
function BehaviorManager::getAvailableBehaviors(%this)
{
   %count = %this.behaviorSet.getCount();
   for(%i = 0; %i < %count; %i++)
   {
      %obj = %this.behaviorSet.getObject(%i);
      %list = setWord(%list, %i, %obj.getName());
   }
   return %list;
   
}

//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// for future behavior object
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

//! @class BehaviorTemplate
//! This is the class of all behavior template objects.  These objects contain info about the 
//! behavior, such as fields, dependencies, etc.  See fields for a complete listing
//!
//! @field fieldPrefix The prefix used before all behavior fields (to prevent conflicts)
//! @field description A readable description of the behavior
//! @field validObjectClassCount The number of valid object classes that this behavior can be applied to
//! @field validObjectClassList Space separated list of valid object classes
//! @field fieldCount The number of fields registered for this behavior
//! @field field[] A tab delimited list of individual field information.
//! \li name
//! \li default value
//! \li data type
//! \li description (for tooltips and such)
//! See \c addfield for more information.
//! @field fieldExtra[] An additional piece of information used with the \c field[] field.  
//! See \c addfield for more information.
//! @field dependencyCount The number of dependencies the behavior has
//! @field dependency[] A tab delimited list of dependency information
//! \li name of field the behavior is dependent on
//! \li value \c field must be set to for the behavior to work properly

//----------------------------------------------------------------------------------------
//! (behavior this)
//! Instantiator.  Set counts to 0
//! @param this This behavior
//----------------------------------------------------------------------------------------
function BehaviorTemplate::onAdd( %this)
{
   %this.dependencyCount = 0;
   %this.requirementCount = 0;
   %this.defaultCount = 0;
}

//We initialize some important variables for all behavior instances later, like
//dependencies stuffs
function BehaviorInstance::onAdd( %this)
{
   %this.missingDependencies = "";
}

function BehaviorInstance::insantiateNamespace( %this, %templateName )
{
   %thurp = %this.isClientObject();
   %temp = ScriptObject(%templateName);
   %temp.delete();
}

function BehaviorTemplate::onBehaviorAdd( %this )
{
   
   for(%i = 0; %i < %this.owner.getBehaviorCount(); %i++)
   {
      %behavior = %this.owner.getBehaviorByIndex(%i);
      %behavior.missingDependencies = ""; //reset it
      %conflictList = BehaviorManager::checkForUnmetDependencies( %behavior );
      
      if(getFieldCount(%conflictList) > 0)
      {
         %behavior.enabled = false;
         for(%d = 0; %d < getFieldCount(%conflictList); %d++)
         {
            if(%behavior.missingDependencies $= "")
               %behavior.missingDependencies = getField(%conflictList, %d+1);
            else
               %behavior.missingDependencies = %behavior.missingDependencies SPC getField(%conflictList, %d+1);
         }
      }
   }
}

function BehaviorTemplate::onBehaviorRemove( %this )
{
   for(%i = 0; %i < %this.owner.getBehaviorCount(); %i++)
   {
      %behavior = %this.owner.getBehaviorByIndex(%i);
      %conflictList = BehaviorManager::checkForUnmetDependencies( %behavior );
      
      if(getFieldCount(%conflictList) > 0)
      {
         %behavior.enabled = false;
         for(%d = 0; %d < getFieldCount(%conflictList); %d++)
         {
            if(%behavior.missingDependencies $= "")
               %behavior.missingDependencies = getField(%conflictList, %d+1);
            else
               %behavior.missingDependencies = %behavior.missingDependencies SPC getField(%conflictList, %d+1);
         }
      }
   }
}

function BehaviorComponent::onBehaviorsLoaded( %this )
{
   for(%i = 0; %i < %this.getBehaviorCount(); %i++)
   {
      %behavior = %this.getBehaviorByIndex(%i);
      %conflictList = BehaviorManager::checkForUnmetDependencies( %behavior );
      
      if(getFieldCount(%conflictList) > 0)
      {
         %behavior.enabled = false;
         for(%d = 0; %d < getFieldCount(%conflictList); %d++)
         {
            if(%behavior.missingDependencies $= "")
               %behavior.missingDependencies = getField(%conflictList, %d+1);
            else
               %behavior.missingDependencies = %behavior.missingDependencies SPC getField(%conflictList, %d+1);
         }
      }
   }
}

//----------------------------------------------------------------------------------------
//! (behavior this, classname objectClass)
//! Adds objectclass to the behavior's objectClassList.  This defines what object classes
//! the behavior will be available for
//! @param this This behavior
//! @param objectClass The object class to be added
//----------------------------------------------------------------------------------------

function BehaviorTemplate::addValidObjectClass( %this, %objectClass)
{
   //if we have it already, skip out
   if (wordPos(%this.objectClassList, %newObjectClass) != -1) return; 
   
   //add it to list
   %this.validObjectClassList = setWord(%this.validObjectClassList, %this.validObjectClassCount, %objectClass);
   %this.validObjectClassCount++;
}   

//----------------------------------------------------------------------------------------
//! (behavior this, string prefix)
//! Sets the prefix string that will be removed from the behavior's field names
//! when they are displayed in the level editor
//! @param this This behavior
//! @param prefix The field prefix
//----------------------------------------------------------------------------------------

function BehaviorTemplate::setFieldPrefix( %this, %prefix)
{
   %this.fieldPrefix = %prefix;
}

//----------------------------------------------------------------------------------------
//! (behavior this, string description)
//! Sets the description for the behavior.  This string is displayed in the gui in MLText
//! fields, so Torque MLText tags are available.
//! @param this This behavior
//! @param description The description
//----------------------------------------------------------------------------------------

function BehaviorTemplate::setDescription( %this, %description)
{
   %this.description = %description;
}

//----------------------------------------------------------------------------------------
//! (behavior this, string fileName)
//! Sets the description for the behavior using the text in the file 'fileName'.  All 
//! This string is displayed in the gui in MLText fields, so Torque MLText tags are 
//! available.  NOTE: if using file wildcards (. or ~) use the expandFilename function 
//! prior to calling like this... 
//! @code 
//! yourBehavior.setDescriptionFile(expandFilename("./yourBehavior.txt");
//! @endcode
//! @param this This behavior
//! @param description The description
//----------------------------------------------------------------------------------------

function BehaviorTemplate::setDescriptionFile( %this, %descriptionFile)
{
   %this.description = loadFileText(%descriptionFile);
}

//----------------------------------------------------------------------------------------
//! (behavior this, string name, string default, string type, string description, string extraInfo)
//! Adds a field description for your behavior, and provides the behavior gui with info
//! about how to display and edit the field.
//! Currently available field types:
//! \li \c hidden Do not show field in gui (but use it for field conflict testing)
//! \li \c bool Checkbox
//! \li \c integer Text edit, no decimal places
//! \li \c float Text edit, 3 decimal places
//! \li \c text Text edit
//! \li \c list A popup list.  Provide a tab delimited list in the 'extraInfo' parameter.  "BLANK" in that list makes a blank option
//! \li \c editlist A popup list that also allows text editing.  Provide a tab delimited list in the 'extraInfo' parameter
//! \li \c file Text edit with a browse button
//! \li \c datablock A popup list of torque datablocks.  Provide a space delimited list of datablock types in the 'extraInfo' parameter.
//! \li \c sound A popup list of defined sounds (audioProfiles)
//! \li \c image A popup list of defined images (t2dImageDatablocks)
//! \li \c animation A popup list of defined animations (t2dAnimationDatablocks)
//! \li \c imageOrAnimation A popup list of defined images and animations (t2dImageDatablocks and t2dAnimationDatablocks)
//! \li \c sceneObject A popup editlist of named sceneObjects in the current level 
//! @param this This behavior
//! @param name The field name
//! @param default The default (starting value) of the field.  Applied automatically when a behavior is added using the /c addBehavior function
//! @param type The field display type (defaults to text)
//! @param description The field's info and tooltip description (optional)
//! @param extraInfo Extra gui information... different depending on the 'type' parameter (optional)
//----------------------------------------------------------------------------------------

function BehaviorTemplate::addFieldOld( %this, %name, %default, %type, %description, %extraInfo)
{
   //don't be confused... we're using TAB delimited text 'fields' to define behavior dynamic fields
   %fieldInfo = setField(%fieldInfo, 0, %name);
   %fieldInfo = setField(%fieldInfo, 1, %default);
   %fieldInfo = setField(%fieldInfo, 2, %type);
   %fieldInfo = setField(%fieldInfo, 3, %description);
   
   //add the field
   %this.field[%this.fieldCount] = %fieldInfo;
   %this.fieldExtra[%this.fieldCount] = %extraInfo; //separate because we need tab delimited lists
   %this.fieldCount++;
}

//----------------------------------------------------------------------------------------
//! (behavior this, string fieldName, string requiredValue)
//! Adds a dependency for the behavior.  In the level editor, when working with behavior dependencies,
//! the system will look for a accessors named set@fieldName and get@fieldName, and failing
//! that will use direct dot assignment.
//! @param this This behavior
//! @param fieldName The field that the behavior is dependent on
//! @param requiredValue The value that the field must be for the behavior to work
//----------------------------------------------------------------------------------------

function BehaviorTemplate::addDependency( %this, %behaviorName )
{
   %dependencyInfo = %behaviorName;
   
   //add the dependency
   %this.dependency[%this.dependencyCount] = %dependencyInfo;
   %this.dependencyCount++;
}

/*function BehaviorTemplate::addDependency( %this, %fieldName, %requiredValue)
{
   %dependencyInfo = setField(%dependencyInfo, 0, %fieldName);
   %dependencyInfo = setField(%dependencyInfo, 1, %requiredValue);
   
   //add the dependency
   %this.dependency[%this.dependencyCount] = %dependencyInfo;
   %this.dependencyCount++;
}*/

//----------------------------------------------------------------------------------------
//! (behavior this, string dependencyNum, simObject object)
//! Sets an object's current value to a dependency field requirement, using accessors if available
//! @param this behavior
//! @param dependencyNum The number of the dependency to set
//! @param obj The object to set the value in
//----------------------------------------------------------------------------------------

function BehaviorTemplate::setDependencyObjectValue( %this, %dependencyNum, %obj)
{
   %fieldName = getField(%this.dependency[%dependencyNum], 0);
   %fieldValue = getField(%this.dependency[%dependencyNum], 1);
   if (%fieldName $= "") echo ("BehaviorTemplate::setDependencyObjectValue Unable to find dependency number '"@%dependencyNum @"'");
   if (%obj.isMethod("set"@%fieldName))
   {
      %command = "%obj.set"@%fieldName@"("@%fieldValue@");";
      eval( %command);
   }
   else 
   {
      %command = "%obj."@%fieldName SPC "= \"" SPC %fieldValue @"\";";
      eval( %command); 
   }
}

//----------------------------------------------------------------------------------------
//! (behavior this, string dependencyNum, simObject object)
//! Gets an object's current value of a dependency field, using accessors if available
//! @param this behavior
//! @param dependencyNum The number of the dependency to check 
//! @param obj The object to get the value from 
//----------------------------------------------------------------------------------------

function BehaviorTemplate::getDependencyObjectValue( %this, %dependencyNum, %obj)
{
   %fieldName = getField(%this.dependency[%dependencyNum], 0);
   if (%fieldName $= "") echo ("BehaviorTemplate::getDependencyObjectValue Unable to find dependency number '"@%dependencyNum @"'");
   if (%obj.isMethod("get"@%fieldName))
   {
      %command = "%value = %obj.get"@%fieldName@"();";
      eval( %command);
   }
   else 
   {
      %command = "%value = %obj."@%fieldName@";";
      eval( %command);
   }
   return %value;
}

//----------------------------------------------------------------------------------------
//! (behavior this, string dependencyNum, simObject object)
//! Check whether a dependency requirement is met on a given object
//! @param dependencyNum The number of the dependency to check 
//! @param obj The object to get the value from 
//! @return True if the object's dependency requirement is met
//----------------------------------------------------------------------------------------

function BehaviorTemplate::validateDependencyObjectValue( %this, %dependencyNum, %obj)
{
   %requiredValue = getField(%this.dependency[%dependencyNum], 1);
   %value = %this.getDependencyObjectValue( %dependencyNum, %obj);
   if (%value == 0 && value !$= "0") //value is a string
   {
      return %value $= %requiredValue;
   }
   else //value is a number
   {
      return %value == %requiredValue;
   }
}

//----------------------------------------------------------------------------------------
//! (behavior this, simobject obj, bool skipDependencyRequirements)
//! Returns conflicts, the description and dependencies as one chunk of MLText (in that order)
//! @param this This behavior
//! @param obj The behavior this object is applied to.  Needed only for conflict checking.  If this is left out, conflict checking is simply skipped.
//! @param skipDependencyRequirements If this is true, conflict check ignores any field dependencies that are not currently met in obj.  It still checks for conflicts with other behaviors.
//----------------------------------------------------------------------------------------
function BehaviorTemplate::getFullDescription( %this, %obj, %skipDependencyRequirements)
{ 
   //description
   if (%fullDescription !$= "") %fullDescription = %fullDescription @ "\n\n";
   %fullDescription = %fullDescription @ %this.Description;
   
   //dependencies
   if (%this.dependencyCount > 0)
   {
   if (%fullDescription !$= "") %fullDescription = %fullDescription @ "\n\n";
      %fullDescription = %fullDescription @ %this.getName() @ " has the following dependencies:";
      for (%i = 0; %i < %this.dependencyCount; %i++)
      {
         %fullDescription = %fullDescription @ "\n" @ getField(%this.dependency[%i],0) @" = "@ getField(%this.dependency[%i],1);
      }
   }
   
   //conflicts
   if (%obj !$= "")
   {
      %conflictList = %this.getConflictList( %obj, %this, %skipDependencyRequirements);
      if (%conflictList !$= "")
      {
         if (%fullDescription !$= "") %fullDescription = %fullDescription @ "\n\n";
         %fullDescription = %fullDescription @ "WARNINGS:";
         %count = getFieldCount(%conflictList);
         for (%i = 0; %i < %count; %i++)
         {
            %conflict = getField(%conflictList, %i);
            %fullDescription = %fullDescription @ "\n" @ %conflict;
         }
      }
   }   
   return %fullDescription;
}

//----------------------------------------------------------------------------------------
//! (behavior this, simObject obj)
//! Tests to make sure obj is of the proper class for this behavior, as defined by addValidObjectClass calls.
//! @param this This behavior
//! @return true If object's class is acceptable
//----------------------------------------------------------------------------------------
function BehaviorTemplate::validateObjectClass(%this, %obj)
{
   for (%i = 0; %i < %this.validObjectClassCount; %i++)
   {
      %validClass = getWord(%this.validObjectClassList, %i);
      if (%obj.isMemberOfClass(%validClass)) return 1;
   }
   return 0;
}