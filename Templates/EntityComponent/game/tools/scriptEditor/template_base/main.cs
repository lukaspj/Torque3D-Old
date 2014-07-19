//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

function initializeVisualScriptEditor()
{
   echo( " - Initializing Visual Torque Scripter Editor" );
   
   exec( "./VisualScriptEditor.cs" );
   exec( "./VisualScriptEditorGui.gui" );
   exec( "./VisualScriptEditorToolbar.gui");
   exec( "./VisualScriptEditorGui.cs" );
   
   //sub-editors
   exec( "./scriptEditor/main.cs" ); //Script editor
   
      
   // Add ourselves to EditorGui, where all the other tools reside
   VisualScriptEditorGui.setVisible( false ); 
   VisualScriptEditorToolbar.setVisible( false );
   VisualScriptEditorOptionsWindow.setVisible( false );
   VisualScriptEditorTreeWindow.setVisible( false );
   
   EditorGui.add( VisualScriptEditorGui );
   EditorGui.add( VisualScriptEditorToolbar );
   EditorGui.add( VisualScriptEditorOptionsWindow );
   EditorGui.add( VisualScriptEditorTreeWindow );
   
   new ScriptObject( VisualScriptEditorPlugin )
   {
      superClass = "EditorPlugin";
   };
   
   %map = new ActionMap();
   %map.bindCmd( keyboard, "backspace", "VisualScriptEditorGui.onDeleteKey();", "" );
   %map.bindCmd( keyboard, "delete", "VisualScriptEditorGui.onDeleteKey();", "" );  
   %map.bindCmd( keyboard, "1", "VisualScriptEditorPlugin.onActivated();", "" );  
   %map.bindCmd( keyboard, "2", "initializeScriptEditor();ScriptEditorPlugin.onActivated();", "" );  
   %map.bindCmd( keyboard, "4", "ToolsPaletteArray->VisualScriptEditorAction2Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "5", "ToolsPaletteArray->VisualScriptEditorAction3Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "-", "ToolsPaletteArray->VisualScriptEditorAction4Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "=", "ToolsPaletteArray->VisualScriptEditorAction5Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "z", "VisualScriptEditorShowThing1Btn.performClick();", "" );  
   %map.bindCmd( keyboard, "x", "VisualScriptEditorShowThing2Btn.performClick();", "" );  
   %map.bindCmd( keyboard, "c", "VisualScriptEditorShowThing3Btn.performClick();", "" ); 
   
    VisualScriptEditorPlugin.map = %map;
   
   VisualScriptEditorPlugin.initSettings();
}

function destroyVisualScriptEditor()
{
}

function VisualScriptEditorPlugin::onWorldEditorStartup( %this )
{  
   // Add ourselves to the window menu.
   %accel = EditorGui.addToEditorsMenu( "Visual Torque Script Editor", "", VisualScriptEditorPlugin );      
   
   // Add ourselves to the ToolsToolbar
   %tooltip = "Site Configuration (" @ %accel @ ")";   
   EditorGui.addToToolsToolbar( "VisualScriptEditorPlugin", "VisualScriptEditorPalette", expandFilename("tools/worldEditor/images/toolbar/road-path-editor"), %tooltip );
   
   //connect editor windows
   AttachWindows( VisualScriptEditorOptionsWindow, VisualScriptEditorTreeWindow);
   
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
   
   TemplateTreeView.open(ServerDecalRoadSet,true);
   
   %this.map.push();

   // Set the status bar here until all tool have been hooked up
   EditorGuiStatusBar.setInfo("Template editor.");
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
   //%terrainExists = parseMissionGroup( "TerrainBlock" );

   //if( %terrainExists == false )
   //   MessageBoxYesNoCancel("No Terrain","Would you like to create a New Terrain?", "Canvas.pushDialog(CreateNewTerrainGui);");
   
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