
function VisualNodeEditorGui::onWake( %this )
{   
}

function VisualNodeEditorGui::onSleep( %this )
{
}

function VisualNodeEditorGui::paletteSync( %this, %mode )
{
   %evalShortcut = "ToolsPaletteArray-->" @ %mode @ ".setStateOn(1);";
   eval(%evalShortcut);
}  

function VisualNodeEditorGui::onDeleteKey( %this )
{
   echo( "On Delete Key Pressed" );
}

function VisualNodeEditorGui::onEscapePressed( %this )
{
   echo( "On Escape Key Pressed" );
}

function VisualNodeEditorGui::onBrowseClicked( %this )
{
   //%filename = RETextureFileCtrl.getText();
         
   %dlg = new OpenFileDialog()
   {
      Filters        = "All Files (*.*)|*.*|";
      DefaultPath    = VisualNodeEditorGui.lastPath;
      DefaultFile    = %filename;
      ChangePath     = false;
      MustExist      = true;
   };
         
   %ret = %dlg.Execute();
   if(%ret)
   {
      VisualNodeEditorGui.lastPath = filePath( %dlg.FileName );
      %filename = %dlg.FileName;
      VisualNodeEditorGui.setTextureFile( %filename );
      RETextureFileCtrl.setText( %filename );
   }
   
   %dlg.delete();
}

function VisualNodeInspector::inspect( %this, %obj )
{
   %name = "";
   if ( isObject( %obj ) )
      %name = %obj.getName();   
   else
      VisualNodeFieldInfoControl.setText( "" );
   
   //InspectorNameEdit.setValue( %name );
   Parent::inspect( %this, %obj );  
}

function VisualNodeInspector::onInspectorFieldModified( %this, %object, %fieldName, %arrayIndex, %oldValue, %newValue )
{
   // Same work to do as for the regular WorldEditor Inspector.
   Inspector::onInspectorFieldModified( %this, %object, %fieldName, %arrayIndex, %oldValue, %newValue );   
}

function VisualNodeInspector::onFieldSelected( %this, %fieldName, %fieldTypeStr, %fieldDoc )
{
   VisualNodeFieldInfoControl.setText( "<font:ArialBold:14>" @ %fieldName @ "<font:ArialItalic:14> (" @ %fieldTypeStr @ ") " NL "<font:Arial:14>" @ %fieldDoc );
}

function VisualNodeTreeView::onInspect(%this, %obj)
{
   VisualNodeInspector.inspect(%obj);   
}

function VisualNodeTreeView::onSelect(%this, %obj)
{
}

function VisualNodeEditorGui::prepSelectionMode( %this )
{
   ToolsPaletteArray-->VisualNodeEditorAction0Mode.setStateOn(1);
}
//------------------------------------------------------------------------------
function VisualNodeDefaultWidthSliderCtrlContainer::onWake(%this)
{
   ////VisualNodeDefaultWidthSliderCtrlContainer-->slider.setValue(VisualNodeDefaultWidthTextEditContainer-->textEdit.getText());
}