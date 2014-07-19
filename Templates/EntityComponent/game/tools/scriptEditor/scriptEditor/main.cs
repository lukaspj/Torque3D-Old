function initializeScriptEditor()
{
   echo(" % - Initializing Script Editor");
   
   exec( "tools/scriptEditor/coreFunctions/profiles.cs");
   
   exec( "./scriptEditor.cs" );
   exec( "./scriptTextEditGui.gui" );
   exec( "./scriptEditorGui.gui" );
   
   exec( "tools/scriptEditor/coreFunctions/arrayObject.cs");
   exec( "tools/scriptEditor/coreFunctions/fields.cs");
   exec( "tools/scriptEditor/coreFunctions/file.cs");
   exec( "tools/scriptEditor/coreFunctions/gui.cs");
   exec( "tools/scriptEditor/coreFunctions/math.cs");
   exec( "tools/scriptEditor/coreFunctions/records.cs");
   exec( "tools/scriptEditor/coreFunctions/strings.cs");
   exec( "tools/scriptEditor/coreFunctions/words.cs");
   
   ScriptEditorGui.setVisible( false ); 
   EditorGui.add( ScriptEditorGui );
   EditorGui.add(EWScriptTreeWindow);
   
   new ScriptObject( ScriptEditorPlugin )
   {
      superClass = "EditorPlugin";
      editorGui = ScriptEditorGui;
      
      localVars = "<color:00A080>";
      globalVars = "<color:C45C00>";
      reservedWords = "<color:0000FF>";
      strings = "<color:A020F0>";
      comments = "<color:006400>";
      operators = "<color:AA8E23>";
      plainText = "<color:000000>";
   };
   
   ScriptEditorGui.plugin = ScriptEditorPlugin;
   
   new SimSet( UnlistedScripts );
   
   /*%map = new ActionMap();
   %map.bindCmd( keyboard, "backspace", "ScriptEditorGui.deleteNode();", "" );
   %map.bindCmd( keyboard, "1", "ScriptEditorGui.prepSelectionMode();", "" );  
   %map.bindCmd( keyboard, "2", "ToolsPaletteArray->ScriptEditorMoveMode.performClick();", "" );  
   %map.bindCmd( keyboard, "3", "ToolsPaletteArray->ScriptEditorRotateMode.performClick();", "" );  
   %map.bindCmd( keyboard, "4", "ToolsPaletteArray->ScriptEditorScaleMode.performClick();", "" );  
   %map.bindCmd( keyboard, "5", "ToolsPaletteArray->ScriptEditorAddRiverMode.performClick();", "" );  
   %map.bindCmd( keyboard, "-", "ToolsPaletteArray->ScriptEditorInsertPointMode.performClick();", "" );  
   %map.bindCmd( keyboard, "=", "ToolsPaletteArray->ScriptEditorRemovePointMode.performClick();", "" );  
   %map.bindCmd( keyboard, "z", "ScriptEditorShowSplineBtn.performClick();", "" );  
   %map.bindCmd( keyboard, "x", "ScriptEditorWireframeBtn.performClick();", "" );  
   %map.bindCmd( keyboard, "v", "ScriptEditorShowRoadBtn.performClick();", "" );   
   ScriptEditorPlugin.map = %map;*/
   
   //set up the initial, defualt coloration settings here

   ScriptEditorPlugin.initSettings();
   ScriptEditorPlugin.readSettings(); // Lame hack, should not be necessary
}

function destroyScriptEditor()
{
}

function ScriptEditorPlugin::onWorldEditorStartup( %this )
{  
   // Add ourselves to the window menu.
   %accel = EditorGui.addToEditorsMenu( "Script Editor", "", ScriptEditorPlugin );
   
   // Add ourselves to the ToolsToolbar
   %tooltip = "Script Editor (" @ %accel @ ")";   
   EditorGui.addToToolsToolbar( "ScriptEditorPlugin", "ScriptEditorPalette", expandFilename("tools/worldEditor/images/toolbar/script-editor"), %tooltip );
   
   //connect editor windows
   //GuiWindowCtrl::attach( EWScriptTreeWindow );
   
   // Add ourselves to the Editor Settings window
   exec( "./scriptEditorSettingsTab.gui" );
   ESettingsWindow.addTabPage( EScriptEditorSettingsPage );
}

function ScriptEditorPlugin::onActivated( %this )
{
   if( !isObject( EditorGui-->ScriptTreeWindow ) )  
   {  
      // Load Creator/Inspector GUI  
      exec("./scriptEditorGui.gui");  
      if( isObject( EWScriptTreeWindow ) )  
      {  
         EditorGui.add( EWScriptTreeWindow );  
         EWScriptTreeWindow-->EditorTree.selectPage( 0 );  
         EWScriptTreeWindow.setVisible( false );  
      }  
   }  
   
   EditorGui-->WorldEditorToolbar.setVisible( false );
   EditorGui-->ScriptTreeWindow.setVisible( true );
   EditorGui.bringToFront(ScriptEditorPlugin);
   ScriptEditorGui.setVisible( true );
   
   // Lame hack, don't know why i need it
   EWorldEditor.setVisible( true );
   
   // Set the status bar here until all tool have been hooked up
   EditorGuiStatusBar.setInfo("Script editor.");
   EditorGuiStatusBar.setSelection("");
   
   EWBrowserWindow.init();
   //%this.map.push();
   
   Parent::onActivated(%this);
}

function ScriptEditorPlugin::onDeactivated( %this )
{
   
   EditorGui-->ScriptTreeWindow.setVisible( false );
   ScriptEditorGui.setVisible( false) ;
   //%this.map.pop();
   
   Parent::onDeactivated(%this);
}

//-----------------------------------------------------------------------------
// Settings
//-----------------------------------------------------------------------------

function ScriptEditorPlugin::initSettings( %this )
{
   EditorSettings.beginGroup( "ScriptEditor", true );
   
   EditorSettings.setDefaultValue( "FileFilter", "*.cs *.gui" );
   
   EditorSettings.endGroup();
}

function ScriptEditorPlugin::readSettings( %this )
{
   EditorSettings.beginGroup( "ScriptEditor", true );
   
   ScriptEditorGui.FileFilter = EditorSettings.value( "FileFilter" );  
   
   EditorSettings.endGroup();  
}

function ScriptEditorPlugin::writeSettings( %this )
{
   EditorSettings.beginGroup( "ScriptEditor", true );
   
   EditorSettings.setValue( "FileFilter", ScriptEditorGui.FileFilter );
   
   EditorSettings.endGroup();
}