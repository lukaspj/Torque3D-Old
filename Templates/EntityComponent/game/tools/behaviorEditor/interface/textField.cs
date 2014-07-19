function BehaviorFieldStack::createTextEditProperty(%this, %accessor, %precision, %label, %tooltip, %data)
{
   %extent = 64;
   if (%precision $= "TEXT")
      %extent = 200;
      
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
      tooltip = %tooltip;
      tooltipProfile = "EditorToolTipProfile";
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
   
   %editControl = new GuiTextEditCtrl() {
      class = "BehaviorEdTextField";
      internalName = %accessor @ "TextEdit";
      canSaveDynamicFields = "0";
      Profile = "EditorTextEdit";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "100 1";
      Extent = %extent SPC "22";
      MinExtent = "8 2";
      canSave = "0";
      Visible = "1";
      hovertime = "100";
      tooltip = %tooltip;
      tooltipProfile = "EditorToolTipProfile";
      maxLength = "1024";
      historySize = "0";
      password = "0";
      
      tabComplete = "0";
      sinkAllKeyEvents = "0";
      password = "0";
      passwordMask = "*";
      precision = %precision;
      accessor = %accessor;
      isProperty = true;
      undoLabel = %label;
      object = %this.object;
      useWords = false;
   };

   %container.add(%labelControl);
   %container.add(%editControl);
   
   %editControl.setText(%this.object.getFieldValue(%accessor));
   
   return %container;
}

function BehaviorEdTextField::onReturn(%this)
{
   EWorldEditor.isDirty = true;
   %text = %this.getText();
   %this.object.setFieldValue(%this.accessor, %text);
   %this.object.inspectorApply();
   
   //if the behavior does extra stuff when updated, do it now
   if(%this.object.isMethod("onBehaviorFieldUpdate"))
      %this.object.onBehaviorFieldUpdate(%this.accessor);
}