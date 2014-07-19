//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(MountedCamera))
{
   %template = new CameraBehavior(MountedCamera);
   
   %template.friendlyName = "Mounted Camera";
   %template.behaviorType = "Game";
   %template.description  = "Mounts the owner entity to another object to follow it, while acting as a camera.";

   %template.addBehaviorField(clientOwner, "The client that views this camera", "int", "1", "");
   
   %template.addBehaviorField(targetObject, "The name of the object the camera attaches to", "string", "", "");
   
   %template.addBehaviorField(positionOffset, "The positional offset of the target object", "Point3", "0 -10 0", "");
   
   %template.addBehaviorField(rotationOffset, "The rotational offset of the target object", "Point3", "0 0 0", "");
   
   %template.addBehaviorField(matchTargetRotation, "The rotational offset of the target object", "bool", "0", "");
}

function MountedCamera::onBehaviorAdd(%this) 
{
   Parent::onBehaviorAdd(%this);
   if(%this.clientOwnerID)
   {
      %this.scopeToClient(%this.clientOwnerID);
      %this.clientOwnerID.setCameraObject(%this.owner);
      %this.clientOwnerID.setControlCameraFov(%this.FOV);
   }
   else
      %this.clientOwnerID = 0;
      
   if(isObject(%this.targetObject))
   {
      %this.targetObject.mountObject(%this.owner, "eye"); 
      %this.owner.setMountOffset(%this.positionOffset);
      %this.owner.setMountRotation(%this.rotationOffset);
   }
}

function MountedCamera::onBehaviorsLoaded(%this) 
{
   if(isObject(%this.targetObjectName))
   {
      %this.targetObjectName.mountObject(%this.owner, "eye");  
   }
}

function MountedCamera::onBehaviorRemove(%this)
{
   if(%this.clientOwnerID)
      %this.clientOwnerID.clearCameraObject();
}

function MountedCamera::onInspectorUpdate(%this, %slot)
{
   if(%slot $= "clientOwner" && %this.clientOwner)
   {
      %this.clientOwner.setCameraObject(%this.owner);
   }
   else if(%slot $= "positionOffset" && isObject(%this.targetObject))
   {
      %this.owner.setMountOffset(%this.positionOffset);
   }
   else if(%slot $= "rotationOffset" && isObject(%this.targetObject))
   {
      %this.owner.setMountRotation(%this.rotationOffset);
   }
}

function MountedCamera::onClientConnect(%this, %client)
{
   %clientID = ClientGroup.getObject(%this.clientOwner-1);
   if(%clientID == %client)
   {
      %this.clientOwnerID = %client;
      %this.scopeToClient(%client);
      %client.setCameraObject(%this.owner);
      %client.setControlCameraFov(%this.FOV);
   }
}

function MountedCamera::onClientDisconnect(%this, %client)
{
   Parent::onClientDisconnect(%this, %client);
   
   %clientID = ClientGroup.getObject(%this.clientOwner-1);
   if(%clientID == %client){
      %this.clearScopeToClient(%this.clientOwnerID);
      %this.clientOwnerID = 0;
      %client.clearCameraObject();
   }
}