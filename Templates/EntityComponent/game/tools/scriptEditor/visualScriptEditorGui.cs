
//Editor things!
function VisualScriptEditorMainWindow::onWake(%this)
{
   //build our background
   if(!isObject(VSEditorBG))
   {
      %bg = new GuiBitmapCtrl(VSEditorBG) {
         bitmap = "core/art/gui/images/transp_grid.png";
         wrap = "1";
         position = "0 0";
         extent = getWord(VisualScriptEditorMainWindow.extent,0) SPC getWord(VisualScriptEditorMainWindow.extent,1);
         minExtent = "8 2";
         horizSizing = "right";
         vertSizing = "bottom";
         useBoundsLocking = "0";
         profile = "GuiDefaultProfile";
         visible = "1";
         active = "1";
         tooltipProfile = "GuiToolTipProfile";
         hovertime = "1000";
         isContainer = "0";
         alpha = "1";
         color = "255 255 255 255";
         unitClip = "0 0 1 1";
         canSave = "1";
         canSaveDynamicFields = "0";
      };
      %this.add(%bg);
   }
   if(!isObject(VSEditorNodePane))
   {
      %nodeSpace = new GuiControl(VSEditorNodePane) {
         canSaveDynamicFields = "0";
         internalName = "VisualScriptEditorNodePane";
         Enabled = "1";
         isContainer = "1";
         Profile = "GuiDefaultProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "306 0";
         Extent = "800 32";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "0";
         hovertime = "1000";
      };
      %this.add(%nodeSpace);
   }
   //now build our mouse interaction
   if(!isObject(VSEditorMainWinMouseEvent))
   {
      %interact = new GuiMouseEventCtrl(VSEditorMainWinMouseEvent) {
         lockMouse = "0";
         position = "0 0";
         extent = getWord(VisualScriptEditorMainWindow.extent,0) SPC getWord(VisualScriptEditorMainWindow.extent,1);
         minExtent = "8 2";
         horizSizing = "right";
         vertSizing = "bottom";
         profile = "GuiDefaultProfile";
         visible = "1";
         active = "1";
         tooltipProfile = "GuiToolTipProfile";
         hovertime = "1000";
         isContainer = "0";
         canSave = "1";
         canSaveDynamicFields = "0";
         firstResponder = "1";
      };
      %this.add(%interact); 
      /*VisualScriptEditorGui.bringToFront(VSEditorMainWinMouseEvent);  
      VisualScriptEditorGui.pushToBack(VSEditorNodePane);
      VisualScriptEditorGui.pushToBack(VSEditorBG);*/
   }
}

function VisualScriptEditorMainWindow::onSleep(%this)
{
   //Clear this out
   if(isObject(VSEditorBG))
      VSEditorBG.delete();

   if(isObject(VSEditorNodePane))
      VSEditorNodePane.delete();

   if(isObject(VSEditorMainWinMouseEvent)) 
      VSEditorMainWinMouseEvent.delete();
}

function VSEditorMainWinMouseEvent::onMouseDown(%this)
{
   %test = 0;  
}

function VSEditorMainWinMouseEvent::onRightMouseDown(%this)
{
   %test = 0;  
}

function VSEditorMainWinMouseEvent::onMiddleMouseDown(%this)
{
   %test = 0;
}

function VisualScriptEditorGui::onWake( %this )
{   
   EWToolsPaletteWindow.setVisible(false); //unneeded here!
}

function VisualScriptEditorGui::onSleep( %this )
{
}

function VisualScriptEditorGui::paletteSync( %this, %mode )
{
   %evalShortcut = "ToolsPaletteArray-->" @ %mode @ ".setStateOn(1);";
   eval(%evalShortcut);
}  

function VisualScriptEditorGui::onDeleteKey( %this )
{
   echo( "On Delete Key Pressed" );
}

function VisualScriptEditorGui::onEscapePressed( %this )
{
   echo( "On Escape Key Pressed" );
}

function VisualScriptEditorGui::onBrowseClicked( %this )
{
   //%filename = RETextureFileCtrl.getText();
         
   %dlg = new OpenFileDialog()
   {
      Filters        = "All Files (*.*)|*.*|";
      DefaultPath    = VisualScriptEditorGui.lastPath;
      DefaultFile    = %filename;
      ChangePath     = false;
      MustExist      = true;
   };
         
   %ret = %dlg.Execute();
   if(%ret)
   {
      VisualScriptEditorGui.lastPath = filePath( %dlg.FileName );
      %filename = %dlg.FileName;
      VisualScriptEditorGui.setTextureFile( %filename );
      RETextureFileCtrl.setText( %filename );
   }
   
   %dlg.delete();
}

function VisualScriptInspector::inspect( %this, %obj )
{
   %name = "";
   if ( isObject( %obj ) )
      %name = %obj.getName();   
   else
      VisualScriptFieldInfoControl.setText( "" );
   
   //InspectorNameEdit.setValue( %name );
   Parent::inspect( %this, %obj );  
}

function VisualScriptInspector::onInspectorFieldModified( %this, %object, %fieldName, %arrayIndex, %oldValue, %newValue )
{
   // Same work to do as for the regular WorldEditor Inspector.
   Inspector::onInspectorFieldModified( %this, %object, %fieldName, %arrayIndex, %oldValue, %newValue );   
}

function VisualScriptInspector::onFieldSelected( %this, %fieldName, %fieldTypeStr, %fieldDoc )
{
   VisualScriptFieldInfoControl.setText( "<font:ArialBold:14>" @ %fieldName @ "<font:ArialItalic:14> (" @ %fieldTypeStr @ ") " NL "<font:Arial:14>" @ %fieldDoc );
}

function VisualScriptTreeView::onInspect(%this, %obj)
{
   VisualScriptInspector.inspect(%obj);   
}

function VisualScriptTreeView::onSelect(%this, %obj)
{
}

function VisualScriptEditorGui::prepSelectionMode( %this )
{
   ToolsPaletteArray-->VisualScriptEditorAction0Mode.setStateOn(1);
}
//------------------------------------------------------------------------------
function VisualScriptDefaultWidthSliderCtrlContainer::onWake(%this)
{
   ////VisualScriptDefaultWidthSliderCtrlContainer-->slider.setValue(VisualScriptDefaultWidthTextEditContainer-->textEdit.getText());
}