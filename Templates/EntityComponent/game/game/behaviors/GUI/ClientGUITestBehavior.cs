//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(ClientGuiTestBehavior))
{
   %template = new ClientScriptBehavior(ClientGuiTestBehavior);
   
   %template.friendlyName = "Client GUI Test";
   %template.behaviorType = "GUI";
   %template.description  = "Provides an example of a behavior that creates client-side GUI elements";
   
   %template.addBehaviorField(Position, "Position of the GUI element", Vector, "100 300");
   %template.addBehaviorField(Extent, "Extent of the GUI element", Vector, "200 200");
   %template.addBehaviorField(image, "Image for the bitmap to display", "file", "art/gui/background");
   
   %template.GUIName = "TestClientGUIElement";
}

function ClientGuiTestBehavior::onBehaviorAdd(%this)
{
   Parent::onBehaviorAdd(%this);
   %this.GUIName = %this.template.GUIName;
    
   %this.createGUI();
}

function ClientGuiTestBehavior::onBehaviorRemove(%this)
{
   %this.GUIName.delete();
}

function ClientGuiTestBehavior::onClientConnect(%this)
{
   %this.createGUI();
}

function ClientGuiTestBehavior::createGUI(%this)
{
   //create  a new GUI
   if(!isObject(%this.GUIName))
   {
      %gui = new GUIBitmapCtrl(%this.GUIName)
      {
         position = %this.position;
         extent = %this.extent;
         bitmap = %this.bitmap;
      };
      PlayGui.add(%gui);
   }
}

function ClientGuiTestBehavior::onBehaviorFieldUpdate(%this, %field)
{
   if(%this.client $= "")
      return;
      
   if(%field == "Position")
      %this.GUIName.position = %this.position;
      
   if(%field == "Extent")
      %this.GUIName.extent = %this.extent;
      
   if(%field == "image")
      %this.GUIName.bitmap = %this.image;

}