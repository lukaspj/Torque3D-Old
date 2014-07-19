
function VisualScriptEditorGui::onWake( %this )
{   
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

function TemplateInspector::inspect( %this, %obj )
{
   %name = "";
   if ( isObject( %obj ) )
      %name = %obj.getName();   
   else
      TemplateFieldInfoControl.setText( "" );
   
   //InspectorNameEdit.setValue( %name );
   Parent::inspect( %this, %obj );  
}

function TemplateInspector::onInspectorFieldModified( %this, %object, %fieldName, %arrayIndex, %oldValue, %newValue )
{
   // Same work to do as for the regular WorldEditor Inspector.
   Inspector::onInspectorFieldModified( %this, %object, %fieldName, %arrayIndex, %oldValue, %newValue );   
}

function TemplateInspector::onFieldSelected( %this, %fieldName, %fieldTypeStr, %fieldDoc )
{
   TemplateFieldInfoControl.setText( "<font:ArialBold:14>" @ %fieldName @ "<font:ArialItalic:14> (" @ %fieldTypeStr @ ") " NL "<font:Arial:14>" @ %fieldDoc );
}

function TemplateTreeView::onInspect(%this, %obj)
{
   TemplateInspector.inspect(%obj);   
}

function TemplateTreeView::onSelect(%this, %obj)
{
}

function VisualScriptEditorGui::prepSelectionMode( %this )
{
   ToolsPaletteArray-->VisualScriptEditorAction0Mode.setStateOn(1);
}
//------------------------------------------------------------------------------
function TemplateDefaultWidthSliderCtrlContainer::onWake(%this)
{
   ////TemplateDefaultWidthSliderCtrlContainer-->slider.setValue(TemplateDefaultWidthTextEditContainer-->textEdit.getText());
}