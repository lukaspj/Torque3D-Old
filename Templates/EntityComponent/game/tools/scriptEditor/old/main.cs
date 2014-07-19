//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

function initializevisualNodeEditor()
{
   echo( " - Initializing visualNode Editor" );
   
   exec( "./visualNodeEditor.cs" );
   exec( "./visualNodeEditorGui.gui" );
   exec( "./visualNodeEditorToolbar.gui");
   exec( "./visualNodeEditorGui.cs" );
   
   // Add ourselves to EditorGui, where all the other tools reside
   visualNodeEditorGui.setVisible( false ); 
   visualNodeEditorToolbar.setVisible( false );
   visualNodeEditorOptionsWindow.setVisible( false );
   visualNodeEditorTreeWindow.setVisible( false );
   
   EditorGui.add( visualNodeEditorGui );
   EditorGui.add( visualNodeEditorToolbar );
   EditorGui.add( visualNodeEditorOptionsWindow );
   EditorGui.add( visualNodeEditorTreeWindow );
   
   new ScriptObject( visualNodeEditorPlugin )
   {
      superClass = "EditorPlugin";
   };
   
   %map = new ActionMap();
   %map.bindCmd( keyboard, "backspace", "visualNodeEditorGui.onDeleteKey();", "" );
   %map.bindCmd( keyboard, "delete", "visualNodeEditorGui.onDeleteKey();", "" );  
   %map.bindCmd( keyboard, "1", "visualNodeEditorGui.prepSelectionMode();", "" );  
   %map.bindCmd( keyboard, "2", "ToolsPaletteArray->visualNodeEditorAction1Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "4", "ToolsPaletteArray->visualNodeEditorAction2Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "5", "ToolsPaletteArray->visualNodeEditorAction3Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "-", "ToolsPaletteArray->visualNodeEditorAction4Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "=", "ToolsPaletteArray->visualNodeEditorAction5Mode.performClick();", "" );  
   %map.bindCmd( keyboard, "z", "visualNodeEditorShowThing1Btn.performClick();", "" );  
   %map.bindCmd( keyboard, "x", "visualNodeEditorShowThing2Btn.performClick();", "" );  
   %map.bindCmd( keyboard, "c", "visualNodeEditorShowThing3Btn.performClick();", "" ); 
   
    visualNodeEditorPlugin.map = %map;
   
   visualNodeEditorPlugin.initSettings();
}

function destroyvisualNodeEditor()
{
}

function visualNodeEditorPlugin::onWorldEditorStartup( %this )
{  
   // Add ourselves to the window menu.
   %accel = EditorGui.addToEditorsMenu( "visualNode Editor", "", visualNodeEditorPlugin );      
   
   // Add ourselves to the ToolsToolbar
   %tooltip = "Site Configuration (" @ %accel @ ")";   
   EditorGui.addToToolsToolbar( "visualNodeEditorPlugin", "visualNodeEditorPalette", expandFilename("tools/worldEditor/images/toolbar/road-path-editor"), %tooltip );
   
   //connect editor windows
   AttachWindows( visualNodeEditorOptionsWindow, visualNodeEditorTreeWindow);
   
   // Add ourselves to the Editor Settings window
   exec( "./visualNodeEditorSettingsTab.gui" );
   ESettingsWindow.addTabPage( EvisualNodeEditorSettingsPage );
    
}

function visualNodeEditorPlugin::onActivated( %this )
{
   %this.readSettings();
   
   ToolsPaletteArray->visualNodeEditorAction3Mode.performClick(); 
   EditorGui.bringToFront( visualNodeEditorGui );
   
   visualNodeEditorGui.setVisible( true );
   visualNodeEditorGui.makeFirstResponder( true );
   visualNodeEditorToolbar.setVisible( true );   
   
   visualNodeEditorOptionsWindow.setVisible( true );
   visualNodeEditorTreeWindow.setVisible( true );
   
   visualNodeTreeView.open(ServerDecalRoadSet,true);
   
   %this.map.push();

   // Set the status bar here until all tool have been hooked up
   EditorGuiStatusBar.setInfo("visualNode editor.");
   EditorGuiStatusBar.setSelection("");
   
   Parent::onActivated(%this);
}

function visualNodeEditorPlugin::onDeactivated( %this )
{
   %this.writeSettings();
   
   visualNodeEditorGui.setVisible( false );
   visualNodeEditorToolbar.setVisible( false );   
   visualNodeEditorOptionsWindow.setVisible( false );
   visualNodeEditorTreeWindow.setVisible( false );
   %this.map.pop();
   
   Parent::onDeactivated(%this);
}

function visualNodeEditorPlugin::handleEscape( %this )
{
   return visualNodeEditorGui.onEscapePressed();  
}

function ESiteConfditorPlugin::isDirty( %this )
{
   return visualNodeEditorGui.isDirty;
}

function visualNodeEditorPlugin::onSaveMission( %this, %missionFile )
{
   if( visualNodeEditorGui.isDirty )
   {
      $Game::MissionGroup.save( %missionFile );
      visualNodeEditorGui.isDirty = false;
   }
}

function visualNodeEditorPlugin::setEditorFunction( %this )
{
   //%terrainExists = parseMissionGroup( "TerrainBlock" );

   //if( %terrainExists == false )
   //   MessageBoxYesNoCancel("No Terrain","Would you like to create a New Terrain?", "Canvas.pushDialog(CreateNewTerrainGui);");
   
   return true;
}

//-----------------------------------------------------------------------------
// Settings
//-----------------------------------------------------------------------------

function visualNodeEditorPlugin::initSettings( %this )
{
   EditorSettings.beginGroup( "visualNodeEditor", true );
   
   EditorSettings.setDefaultValue(  "Value1",         "Some Value 1" );
   EditorSettings.setDefaultValue(  "Value2",     "Some Value 2" );
   EditorSettings.setDefaultValue(  "Value3",  "Some Value 3" );

   EditorSettings.endGroup();
  }

function visualNodeEditorPlugin::readSettings( %this )
{
   EditorSettings.beginGroup( "visualNodeEditor", true );
   
   visualNodeEditorGui.Value1         = EditorSettings.value("Value1");
   visualNodeEditorGui.Value2     = EditorSettings.value("Value2");
   visualNodeEditorGui.Value3  = EditorSettings.value("Value3");

   EditorSettings.endGroup();  
}

function visualNodeEditorPlugin::writeSettings( %this )
{
   EditorSettings.beginGroup( "visualNodeEditor", true );
   
   EditorSettings.setValue( "Value1",           visualNodeEditorGui.Value1 );
   EditorSettings.setValue( "Value2",       visualNodeEditorGui.Value2 );
   EditorSettings.setValue( "Value3",    visualNodeEditorGui.Value3 );

   EditorSettings.endGroup();
}