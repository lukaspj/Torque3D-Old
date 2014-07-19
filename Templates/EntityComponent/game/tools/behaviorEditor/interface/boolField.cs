function BehaviorFieldStack::createCheckBox(%this, %accessor, %label, %tooltip, %spatial, %useInactive, %addUndo)
{
   %container = new GuiControl() {
      canSaveDynamicFields = "0";
      Profile = "EditorContainerProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "300 20";
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
      Position = "16 3";
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
   
   %checkBox = new GuiCheckBoxCtrl() {
      canSaveDynamicFields = "0";
      class = BehaviorEdCheckBxField;
      internalName = %accessor @ "CheckBox";
      Profile = "ToolsGuiCheckBoxProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "120 1";
      Extent = "323 18";
      MinExtent = "8 2";
      canSave = "0";
      Visible = "1";
      hovertime = "100";
      tooltip = %tooltip;
      tooltipProfile = "EditorToolTipProfile";
      text = "";
      groupNum = "-1";
      buttonType = "ToggleButton";
      accessor = %accessor;
      precision = "TEXT"; //Allows a value of "" for false
      object = %this.object;
   };
  
   %container.add(%checkBox);
   %container.add(%labelControl);
   
   %checkBox.setStateOn(%this.object.getFieldValue(%accessor));

   return %container;
}

function BehaviorEdCheckBxField::onClick(%this)
{
   EWorldEditor.isDirty = true;
   %state = %this.isStateOn();
   %this.object.setFieldValue(%this.accessor, %state);
   %this.object.inspectorApply();
   
   //if the behavior does extra stuff when updated, do it now
   if(%this.object.isMethod("onBehaviorFieldUpdate"))
      %this.object.onBehaviorFieldUpdate(%this.accessor);
}