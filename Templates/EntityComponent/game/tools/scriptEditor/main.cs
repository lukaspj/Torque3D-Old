//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

//exec("tools/ScriptEditor/scriptEditor/main.cs");

//initializeScriptEditor();
/*function initializeVisualScriptEditor()
{
   echo( " - Initializing VisualScript Editor" );
   
   exec( "./coreFunctions/profiles.cs");
   exec( "./VisualScriptEditor.cs" );
   exec( "./VisualScriptEditorGui.gui" );
   exec( "./VisualScriptEditorToolbar.gui");
   exec( "./VisualScriptEditorGui.cs" );
   
   //Sub-editors
   exec("./scriptEditor/main.cs");
   
   //script/file functions
   exec( "./coreFunctions/arrayObject.cs");
   exec( "./coreFunctions/fields.cs");
   exec( "./coreFunctions/file.cs");
   exec( "./coreFunctions/gui.cs");
   exec( "./coreFunctions/math.cs");
   exec( "./coreFunctions/records.cs");
   exec( "./coreFunctions/strings.cs");
   exec( "./coreFunctions/words.cs");
   
   // Add ourselves to EditorGui, where all the other tools reside
   VisualScriptEditorGui.setVisible( false ); 
   VisualScriptEditorToolbar.setVisible( false );
   VisualScriptEditorOptionsWindow.setVisible( false );
   VisualScriptEditorTreeWindow.setVisible( false );
   
   VisualScriptEditorMainWindow.setVisible( false );
  // VisualScriptEditorGameViewWindow.setVisible( false );
   
   EditorGui.add( VisualScriptEditorGui );
   EditorGui.add( VisualScriptEditorToolbar );
   //EditorGui.add( VisualScriptEditorOptionsWindow );
   //EditorGui.add( VisualScriptEditorTreeWindow );
   
   //EditorGui.add( VisualScriptEditorGameViewWindow );
   //EditorGui.add( VisualScriptEditorMainWindow );
   
   /*EditorGui.PushToBack(VisualScriptEditorMainWindow);
   EditorGui.bringToFront(VisualScriptEditorOptionsWindow); 
   EditorGui.bringToFront(VisualScriptEditorTreeWindow);
   EditorGui.bringToFront(VisualScriptEditorToolbar);
   EditorGui.bringToFront(EWToolsToolbar);
   EditorGui.bringToFront(EWToolsPaletteWindow);
   EditorGui.bringToFront(EditorGuiStatusBar);*/
   
   /*new ScriptObject( VisualScriptEditorPlugin )
   {
      superClass = "EditorPlugin";
   };
   
   %map = new ActionMap();
   %map.bindCmd( keyboard, "backspace", "VisualScriptEditorGui.onDeleteKey();", "" );
   %map.bindCmd( keyboard, "delete", "VisualScriptEditorGui.onDeleteKey();", "" );  
   %map.bindCmd( keyboard, "1", "VisualScriptEditorGui.prepSelectionMode();", "" );  
   %map.bindCmd( keyboard, "2", "ToolsPaletteArray->VisualScriptEditorAction1Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "4", "ToolsPaletteArray->VisualScriptEditorAction2Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "5", "ToolsPaletteArray->VisualScriptEditorAction3Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "-", "ToolsPaletteArray->VisualScriptEditorAction4Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "=", "ToolsPaletteArray->VisualScriptEditorAction5Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "z", "VisualScriptEditorShowThing1Btn.performClick();", "" );  
   %map.bindCmd( keyboard, "x", "VisualScriptEditorShowThing2Btn.performClick();", "" );  
   %map.bindCmd( keyboard, "c", "VisualScriptEditorShowThing3Btn.performClick();", "" ); 
   
    VisualScriptEditorPlugin.map = %map;
   
   VisualScriptEditorPlugin.initSettings();
}*/

function destroyVisualScriptEditor()
{
}

function VisualScriptEditorPlugin::onWorldEditorStartup( %this )
{  
   // Add ourselves to the window menu.
   %accel = EditorGui.addToEditorsMenu( "VisualScript Editor", "", VisualScriptEditorPlugin );      
   
   // Add ourselves to the ToolsToolbar
   %tooltip = "Site Configuration (" @ %accel @ ")";   
   EditorGui.addToToolsToolbar( "VisualScriptEditorPlugin", "VisualScriptEditorPalette", expandFilename("tools/worldEditor/images/toolbar/road-path-editor"), %tooltip );
   
   if ( !isObject( ScriptEditorFileSet ) )
      new SimSet( ScriptEditorFileSet );
   
   //connect editor windows
   //AttachWindows( VisualScriptEditorOptionsWindow, VisualScriptEditorTreeWindow);
   
   // Add ourselves to the Editor Settings window
   exec( "./VisualScriptEditorSettingsTab.gui" );
   ESettingsWindow.addTabPage( EVisualScriptEditorSettingsPage );
    
}

function VisualScriptEditorPlugin::onActivated( %this )
{
   %this.readSettings();
   
   ToolsPaletteArray->VisualScriptEditorAction3Mode.performClick(); 
   EditorGui.bringToFront( VisualScriptEditorGui );
   
   VisualScriptEditorGui.setVisible( true );
   VisualScriptEditorGui.makeFirstResponder( true );
   VisualScriptEditorToolbar.setVisible( true );   
   
   VisualScriptEditorOptionsWindow.setVisible( true );
   VisualScriptEditorTreeWindow.setVisible( true );
   
   VisualScriptEditorMainWindow.setVisible( true );
   //VisualScriptEditorGameViewWindow.setVisible( true );
   
   //VisualScriptEditorGui.bringToFront( VisualScriptEditorMainWindow );
   //VisualScriptEditorGui.bringToFront( VisualScriptEditorTreeWindow );
   //VisualScriptEditorGui.bringToFront( VisualScriptEditorOptionsWindow );
   //EditorGui.bringToFront(EWToolsToolbar);
   //EditorGui.bringToFront(EWToolsPaletteWindow);
   //EditorGui.bringToFront(EditorGuiStatusBar);
   //EditorGui.pushToBack( VisualScriptEditorGui );
  
   //VisualScriptTreeView.open(ServerDecalRoadSet,true);
   //TODO: edit this to load our nodes list and script files
   
   %this.map.push();

   // Set the status bar here until all tool have been hooked up
   EditorGuiStatusBar.setInfo("VisualScript editor.");
   EditorGuiStatusBar.setSelection("");
   
   Parent::onActivated(%this);
}

function VisualScriptEditorPlugin::onDeactivated( %this )
{
   %this.writeSettings();
   
   VisualScriptEditorGui.setVisible( false );
   VisualScriptEditorToolbar.setVisible( false );   
   VisualScriptEditorOptionsWindow.setVisible( false );
   VisualScriptEditorTreeWindow.setVisible( false );
   
   VisualScriptEditorMainWindow.setVisible( false );
   //VisualScriptEditorGameViewWindow.setVisible( false );
   %this.map.pop();
   
   Parent::onDeactivated(%this);
}

function VisualScriptEditorPlugin::handleEscape( %this )
{
   return VisualScriptEditorGui.onEscapePressed();  
}

function ESiteConfditorPlugin::isDirty( %this )
{
   return VisualScriptEditorGui.isDirty;
}

function VisualScriptEditorPlugin::onSaveMission( %this, %missionFile )
{
   if( VisualScriptEditorGui.isDirty )
   {
      $Game::MissionGroup.save( %missionFile );
      VisualScriptEditorGui.isDirty = false;
   }
}

function VisualScriptEditorPlugin::setEditorFunction( %this )
{
   return true;
}

//-----------------------------------------------------------------------------
// Settings
//-----------------------------------------------------------------------------

function VisualScriptEditorPlugin::initSettings( %this )
{
   EditorSettings.beginGroup( "VisualScriptEditor", true );
   
   EditorSettings.setDefaultValue(  "Value1",         "Some Value 1" );
   EditorSettings.setDefaultValue(  "Value2",     "Some Value 2" );
   EditorSettings.setDefaultValue(  "Value3",  "Some Value 3" );

   EditorSettings.endGroup();
  }

function VisualScriptEditorPlugin::readSettings( %this )
{
   EditorSettings.beginGroup( "VisualScriptEditor", true );
   
   VisualScriptEditorGui.Value1         = EditorSettings.value("Value1");
   VisualScriptEditorGui.Value2     = EditorSettings.value("Value2");
   VisualScriptEditorGui.Value3  = EditorSettings.value("Value3");

   EditorSettings.endGroup();  
}

function VisualScriptEditorPlugin::writeSettings( %this )
{
   EditorSettings.beginGroup( "VisualScriptEditor", true );
   
   EditorSettings.setValue( "Value1",           VisualScriptEditorGui.Value1 );
   EditorSettings.setValue( "Value2",       VisualScriptEditorGui.Value2 );
   EditorSettings.setValue( "Value3",    VisualScriptEditorGui.Value3 );

   EditorSettings.endGroup();
}

function openVisEditor(%editor)
{
   switch$(%editor)
   {
      case "VisualScript":
         EditorGui.add(VisualScriptEditorGui);
         Editor.remove(ScriptEditorGui);
      case "TextScript":
         EditorGui.add(ScriptEditorGui);
         Editor.remove(VisualScriptEditorGui); 
   }
}