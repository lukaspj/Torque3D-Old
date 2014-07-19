$KeyBindMenu::keyList = "A" TAB "B" TAB "C" TAB "D" TAB "E" TAB "F" TAB "G" TAB
                        "H" TAB "I" TAB "J" TAB "K" TAB "L" TAB "M" TAB "N" TAB
                        "O" TAB "P" TAB "Q" TAB "R" TAB "S" TAB "T" TAB "U" TAB
                        "V" TAB "W" TAB "X" TAB "Y" TAB "Z" TAB "backspace" TAB
                        "tab" TAB "enter" TAB "pause" TAB "escape" TAB
                        "space" TAB "pagedown" TAB "pageup" TAB "end" TAB
                        "home" TAB "left" TAB "right" TAB "up" TAB "down" TAB
                        "print" TAB "insert" TAB "delete" TAB "numpad0" TAB
                        "numpad1" TAB "numpad2" TAB "numpad3" TAB "numpad4" TAB
                        "numpad5" TAB "numpad6" TAB "numpad7" TAB "numpad8" TAB
                        "numpad9" TAB "numpadmult" TAB "numpadadd" TAB
                        "numpadsep" TAB "numpadminus" TAB "numpaddecimal" TAB
                        "numpaddivide" TAB "numpadenter" TAB "f1" TAB "f2" TAB
                        "f3" TAB "f4" TAB "f5" TAB "f6" TAB "f7" TAB "f8" TAB
                        "f9" TAB "f10" TAB "f11" TAB "f12" TAB "minus" TAB
                        "equals" TAB "lbracket" TAB "rbracket" TAB
                        "backslash" TAB "semicolon" TAB "apostrophe" TAB
                        "comma" TAB "period" TAB "slash";

$KeyBindMenu::joystickList = "button0" TAB "button1" TAB "button2" TAB
                             "button3" TAB "button4" TAB "button5" TAB
                             "button6" TAB "button7" TAB "Button8" TAB
                             "Button9" TAB "Button10" TAB "Button11" TAB
                             "Button12" TAB "upov" TAB "dpov" TAB "rpov" TAB
                             "lpov" TAB "xaxis" TAB "yaxis" TAB "zaxis" TAB
                             "rxaxis" TAB "ryaxis" TAB "rzaxis";

function BehaviorFieldStack::createKeyBindList(%this, %accessor, %label, %tooltip, %addUndo, %isProperty)
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
      Class = "BehaviorEdPopMenuField";
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
   
   KeybindField::refresh(%popupCtrl);
   
   %popupCtrl.text = getWord(%this.object.getFieldValue(%accessor), 1);

   return %container;
}

function KeybindField::refresh(%this)
{
   %this.clear();
   
   %keyCount = getFieldCount($KeyBindMenu::keyList);
   %this.addCategory("Keyboard");
   for (%i = 0; %i < %keyCount; %i++)
   {
      %key = getField($KeyBindMenu::keyList, %i);
      %this.add(%key, %i);
   }
   
   %this.keyCount = %keyCount;
   
   %mouseCount = 0;
   for (%i = 0; %i < %mouseCount; %i++)
   {
      %key = getField($KeyBindMenu::mouseList, %i);
      %this.add(%key, %i + %keyCount);
   }
   
   %this.mouseCount = %mouseCount;
   
   %joystickCount = getFieldCount($KeyBindMenu::joystickList);
   %this.addCategory("Joystick");
   for (%i = 0; %i < %joystickCount; %i++)
   {
      %key = getField($KeyBindMenu::joystickList, %i);
      %this.add(%key, %i + %keyCount + %mouseCount);
   }
   
   %this.joystickCount = %joystickCount;
}

function BehaviorEdPopMenuField::onUpdate(%this)
{
   EWorldEditor.isDirty = true;
   %text = %this.text;
   %oldBind = %this.object.getFieldValue(%this.accessor);
   %this.object.setFieldValue(%this.accessor, getWord(%oldBind,0) SPC %text);
   
   //if the behavior does extra stuff when updated, do it now
   if(%this.object.isMethod("onBehaviorFieldUpdate"))
      %this.object.onBehaviorFieldUpdate(%this.accessor);
}