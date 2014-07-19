function GuiInspectorBehaviorGroup::createAddBehaviorList(%this)
{
   %extent = %this.getExtent();
   
   %container = new GuiControl()
   {
      Profile = "EditorContainerProfile";
      HorizSizing = "width";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = %extent.x SPC "25";
   };

   %behaviorList = new GuiPopUpMenuCtrlEx(QuickEditBehaviorList) 
   {
      Profile = "GuiPopupMenuProfile";
      HorizSizing = "width";
      VertSizing = "bottom";
      position = "28 4";
      Extent = (%extent.x - 28) SPC "18";
      hovertime = "100";
      tooltip = "The behavior to add to the object";
      tooltipProfile = "EditorToolTipProfile";
   };

   %addButton = new GuiIconButtonCtrl() {
      class = AddBehaviorQuickEditButton;
      Profile = "EditorButton";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "2 0";
      Extent = "24 24";
      buttonMargin = "4 4";
      iconLocation = "Left";
      sizeIconToButton = "0";
      iconBitmap = "tools/gui/images/iconAdd.png";
      hovertime = "100";
      tooltip = "Add the selected behavior to the object";
      tooltipProfile = "EditorToolTipProfile";
      behaviorList = %behaviorList;
   };
   
   %behaviorList.refresh();
   
   %container.add(%behaviorList);
   %container.add(%addButton);
   
   if(!isObject("behaviortooltiptheme"))
   {
      %theme = createsupertooltiptheme("behaviortooltiptheme");
      %theme.addstyle("headerstyle", "<just:left><font:arial bold:16><color:000000>");
      %theme.addstyle("headertwostyle", "<font:arial bold:14><color:000000>");
      %theme.addstyle("basictextstyle", "<font:arial:14><color:000000>");
      %theme.setdefaultstyle("title", "headerstyle");
      %theme.setdefaultstyle("paramtitle", "headertwostyle");
      %theme.setdefaultstyle("param", "basictextstyle");
      %theme.setspacing(3, 0);
   }
   
   return %container;
}

function QuickEditBehaviorList::refresh(%this)
{
   %this.clear();
   
   // Find all the types.
   %count = BehaviorSet.getCount();
   %categories = "";
   for (%i = 0; %i < %count; %i++)
   {
      %item = BehaviorSet.getObject(%i);
      if (!isInList(%item.behaviorType, %categories))
         %categories = %categories TAB %item.behaviorType;
   }
   
   %categories = trim(%categories);
   
   %index = 0;
   %categoryCount = getFieldCount(%categories);
   for (%i = 0; %i < %categoryCount; %i++)
   {
      %category = getField(%categories, %i);
      %this.addCategory(%category);
      for (%j = 0; %j < %count; %j++)
      {
         %item = BehaviorSet.getObject(%j);
         if (%item.behaviorType $= %category)
         {
            //TODO: Haven't worked out getting categories to look distinct
            //from entries in the drop-down so for now just indent them for the visual distinction
            %spacedName = "    "@%item.friendlyName;
            %this.add(%spacedName, %index);
            %this.behavior[%index] = %item;
            %index++;
         }
      }
   }
}

function QuickEditBehaviorList::onHotTrackItem( %this, %itemID )
{
   %behaviorObj = %this.behavior[%itemID];
   if( isObject( %behaviorObj ) && %this.behaviorDesc != %behaviorObj )
   {
      SuperTooltipDlg.init("BehaviorTooltipTheme");
      SuperTooltipDlg.setTitle(%behaviorObj.friendlyName);
      SuperTooltipDlg.addParam("", %behaviorObj.description @ "\n");
      
      %fieldCount = %behaviorObj.getBehaviorFieldCount();
      for (%i = 0; %i < %fieldCount; %i++)
      {
         %name = getField(%behaviorObj.getBehaviorField(%i), 0);
         %description = %behaviorObj.getBehaviorFieldDescription(%i);
         SuperTooltipDlg.addParam(%name, %description @ "\n");
      }
      %position = %this.getGlobalPosition();
      SuperTooltipDlg.processTooltip( %position,0,1 );
      %this.opened = true;    
      %this.behaviorDesc = %behaviorObj;
   }
   else if( !isObject( %behaviorObj ) )
   {
      if( %this.opened == true )
         SuperTooltipDlg.hide();
      %this.behaviorDesc = "";
   }      
}

function QuickEditBehaviorList::setProperty(%this, %object)
{
   %this.objectToAdd = %object;
}

function QuickEditBehaviorList::onSelect(%this)
{
   if( %this.opened == true )
      SuperTooltipDlg.hide();
   
   %this.behaviorToAdd = %this.behavior[%this.getSelected()];
}

function QuickEditBehaviorList::onCancel( %this )
{
   if( %this.opened == true )
      SuperTooltipDlg.hide();
}

function AddBehaviorQuickEditButton::onClick(%this)
{
   %behavior = %this.behaviorList.behaviorToAdd;
   if (!isObject(%behavior))
      return;
   
   %instance = %behavior.createInstance();
   %undo = new UndoScriptAction()
   {
      actionName = "Added Behavior";
      class = UndoAddBehavior;
      object = %this.behaviorList.objectToAdd;
      behavior = %instance;
   };
   //%this.behaviorList.objectToAdd.addBehavior(%instance);
   //schedule(0, 0, updateQuickEdit);
   %undo.addToManager(LevelBuilderUndoManager);
   
   %instance.owner = Inspector.getInspectObject(0);//%this.behaviorList.objectToAdd;
   //schedule( 50, 0, "addBehavior", %instance.owner, %instance);
   %instance.owner.add(%instance);
   
   Inspector.schedule( 50, "refresh" );
   EWorldEditor.isDirty = true;
   
   //%this.behaviorList.objectToAdd.addBehavior(%instance);
   //schedule(0, 0, updateQuickEdit);
   /*Inspector.schedule( 50, "refresh" );
   //%undo.addToManager(LevelBuilderUndoManager);
   EWorldEditor.isDirty = true;*/
}

function addBehavior(%obj, %instance)
{
   echo("adding the behavior!");
   %obj.addBehavior(%instance);
   Inspector.schedule( 50, "refresh" );
   EWorldEditor.isDirty = true;
}
