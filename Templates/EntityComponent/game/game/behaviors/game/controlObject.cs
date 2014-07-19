//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(ControlObjectBehavior))
{
   %template = new BehaviorTemplate(ControlObjectBehavior);
   
   %template.friendlyName = "Control Object";
   %template.behaviorType = "Game";
   %template.description  = "Causes the object to render a 3d shape using the file provided.";
   
   %template.networked = true;

   %template.addBehaviorField(clientOwner, "The shape to use for rendering", "int", "1", "");
}

function ControlObjectBehavior::onAdd(%this)
{
   Parent::onBehaviorAdd(%this);

   %clientID = %this.getClientID();

   if(%clientID && !isObject(%clientID.getControlObject()))
      %clientID.setControlObject(%this.owner);
}

function ControlObjectBehavior::onRemove(%this)
{
   %clientID = %this.getClientID();
	
   if(%clientID)
      %clientID.setControlObject(0);
}

function ControlObjectBehavior::onClientConnect(%this, %client)
{
   if(%this.isControlClient(%client) && !isObject(%client.getControlObject()))
      %client.setControlObject(%this.owner);
}

function ControlObjectBehavior::onClientDisconnect(%this, %client)
{
   if(%this.isControlClient(%client))
      %client.setControlObject(0);
}

function ControlObjectBehavior::getClientID(%this)
{
	return ClientGroup.getObject(%this.clientOwner-1);
}

function ControlObjectBehavior::isControlClient(%this, %client)
{
	%clientID = ClientGroup.getObject(%this.clientOwner-1);
	
	if(%client.getID() == %clientID)
		return true;
	else
	    return false;
}

function ControlObjectBehavior::onInspectorUpdate(%this, %field)
{
   %clientID = %this.getClientID();
	
   if(%clientID && !isObject(%clientID.getControlObject()))
      %clientID.setControlObject(%this.owner);
}

function switchControlObject(%client, %newControlEntity)
{
	if(!isObject(%client) || !isObject(%newControlEntity))
		return error("SwitchControlObject: No client or target controller!");
		
	%control = %newControlEntity.getBehavior("ControlObjectBehavior");
		
	if(!isObject(%control))
		return error("SwitchControlObject: Target controller has no conrol object behavior!");
		
    %client.setControlObject(%newControlEntity);
}