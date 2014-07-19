//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(ServerGuiTestBehavior))
{
   %template = new BehaviorTemplate(ServerGuiTestBehavior);
   
   %template.friendlyName = "Server GUI Test";
   %template.behaviorType = "GUI";
   %template.description  = "Provides an example of a behavior that creates Server-controlled GUI elements";
   
   %template.addBehaviorField(Position, "Position of the GUI element", Vector, "100 100");
   %template.addBehaviorField(Extent, "Extent of the GUI element", Vector, "100 100");
   %template.addBehaviorField(image, "Image for the bitmap to display", "file", "art/gui/background");
   
   %template.GUIName = "TestServerGUIElement";
}

function ServerGuiTestBehavior::onBehaviorAdd(%this)
{
   Parent::onBehaviorAdd(%this);
   %this.GUIName = %this.template.GUIName;
    
   if(!%this.owner.initialLoad)
   {
      %this.getOwner();
      %this.createGUI();
   }
}

function ServerGuiTestBehavior::onBehaviorRemove(%this)
{
   if(%this.client $= "")
      return;
      
   commandToClient(%this.client, 'UpdateClientGUI', %this.GUIName, "delete");
}

function ServerGuiTestBehavior::onClientConnect(%this)
{
   %this.getOwner();
   %this.createGUI();
}

function ServerGuiTestBehavior::getOwner(%this)
{
   %control = %this.owner.getBehavior( ControlObjectBehavior );
   if( %control != 0)
      %this.client = %control.clientOwner;
}

function ServerGuiTestBehavior::createGUI(%this)
{
   if(%this.client $= "")
      return;
      
   //create  a new GUI
   commandToClient(%this.client, 'UpdateClientGUI', GUIBitmapCtrl, "new", %this.GUIName);
   //next set the parameters
   commandToClient(%this.client, 'UpdateClientGUI', %this.GUIName, "position", %this.position);
   commandToClient(%this.client, 'UpdateClientGUI', %this.GUIName, "extent", %this.extent);
   commandToClient(%this.client, 'UpdateClientGUI', %this.GUIName, "bitmap", %this.image);
   commandToClient(%this.client, 'UpdateClientGUI', PlayGUI, "add", %this.GUIName);
}

function ServerGuiTestBehavior::onBehaviorFieldUpdate(%this, %field)
{
   if(%this.client $= "")
      return;
      
   if(%field $= "Position")
      commandToClient(%this.client, 'UpdateClientGUI', %this.GUIName, "position", %this.position);
      
   if(%field $= "Extent")
      commandToClient(%this.client, 'UpdateClientGUI', %this.GUIName, "Extent", %this.extent);
      
   if(%field $= "image")
      commandToClient(%this.client, 'UpdateClientGUI', %this.GUIName, "Bitmap", %this.image);

}

function clientCmdUpdateClientGui(%gui, %func, %val)
{
    if (!isObject(%gui) && %func !$= "new")  
        return;  
 
    switch$ (%func)  
    {
       case "hidden": %gui.hidden = %val;
       case "position": %gui.position = %val;
       case "extent": %gui.extent = %val;
       case "add": %gui.add(%val);
       case "delete": %gui.delete();
       case "bitmap": %gui.bitmap = %val;
       case "new": eval("new "@%gui@"("@%val@");");
    }
}