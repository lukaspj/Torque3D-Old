function BehaviorFieldStack::createDropDownList(%this, %accessor, %label, %tooltip, %addUndo, %isProperty)
{
   if (%isProperty $= "")
      %isProperty = false;
   
   if (%addUndo $= "")
      %addUndo = true;
      
   %container = new GuiControl() {
      canSaveDynamicFields = "0";
      Profile = "EditorContainerProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "300 24";
      MinExtent = "8 2";
      canSave = "0";
      Visible = "1";
      hovertime = "100";
   };

   %labelControl = new GuiTextCtrl() {
      canSaveDynamicFields = "0";
      Profile = "EditorFontHLBold";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "16 8";
      Extent = "100 18";
      MinExtent = "8 2";
      canSave = "0";
      Visible = "1";
      hovertime = "100";
      tooltip = %tooltip;
      tooltipProfile = "EditorToolTipProfile";
      text = %label;
      maxLength = "1024";
   };
   %popupCtrl = new GuiPopUpMenuCtrlEx() 
   {
      canSaveDynamicFields = "0";
      DatablockFilter = %filter;
      Profile = "GuiPopupMenuProfile";
      Class = "BehaviorEdDropDownListField";
      internalName = %accessor @ "DropDown";
      HorizSizing = "left";
      VertSizing = "bottom";
      position = "128 7";
      Extent = "152 20";
      MinExtent = "40 20";
      canSave = "0";
      Visible = "1";
      hovertime = "100";
      tooltip = %tooltip;
      tooltipProfile = "EditorToolTipProfile";
      accessor = %accessor;
      undoLabel = %label;
      object = %this.object;
      watchSet = %set;
      additionalItems = %additionalItems;
      addUndo = %addUndo;
      isProperty = %isProperty;
   };
   %popupCtrl.command = %popupCtrl @ ".onUpdate();";
   
   %container.add(%labelControl);
   %container.add(%popupCtrl);
   
   %popupCtrl.text = %this.object.getFieldValue(%accessor);

   return %container;
}

function BehaviorEdDropDownListField::onUpdate(%this)
{
   EWorldEditor.isDirty = true;
   %text = %this.text;
   %this.object.setFieldValue(%this.accessor, %text);
   
   //if the behavior does extra stuff when updated, do it now
   if(%this.object.isMethod("onBehaviorFieldUpdate"))
      %this.object.onBehaviorFieldUpdate(%this.accessor);
}