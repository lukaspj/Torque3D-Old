//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(SideScrollControls))
{
   %template = new BehaviorTemplate(SideScrollControls);
   
   %template.friendlyName = "Side Scroll Controls";
   %template.behaviorType = "Input";
   %template.description  = "Side Scroller-type controls";
   
   %template.networked = true;
   
   %template.beginGroup("Keys");
      %template.addBehaviorField(forwardKey, "Key to bind to vertical thrust", keybind, "keyboard d");
      %template.addBehaviorField(backKey, "Key to bind to vertical thrust", keybind, "keyboard a");
      //%template.addBehaviorField(leftKey, "Key to bind to horizontal thrust", keybind, "keyboard a");
      //%template.addBehaviorField(rightKey, "Key to bind to horizontal thrust", keybind, "keyboard d");
      
      %template.addBehaviorField(jump, "Key to bind to horizontal thrust", keybind, "keyboard space");
   %template.endGroup();
   
   %template.addBehaviorField(moveSpeed, "Horizontal thrust force", float, 20.0);
   %template.addBehaviorField(jumpStrength, "Vertical thrust force", float, 3.0);
   
   //%template.addDependency("SimplePhysicsBehavior");
}

function SideScrollControls::onBehaviorAdd(%this)
{
   Parent::onBehaviorAdd(%this);
   
   %this.Physics = %this.owner.getBehavior( PhysicsBehavior );
}

function SideScrollControls::onBehaviorRemove(%this)
{
   Parent::onBehaviorRemove(%this);
   
   commandToClient(%control.clientOwnerID, 'removeInput', %this.forwardKey);
   commandToClient(%control.clientOwnerID, 'removeInput', %this.backKey);
   //commandToClient(%control.clientOwnerID, 'removeInput', %this.leftKey);
   //commandToClient(%control.clientOwnerID, 'removeInput', %this.rightKey);
   
   //commandToClient(%control.clientOwnerID, 'removeInput', %this.pitchAxis);
   //commandToClient(%control.clientOwnerID, 'removeInput', %this.yawAxis);
}

function SideScrollControls::onBehaviorFieldUpdate(%this, %field)
{
   %controller = %this.owner.getBehavior( ControlObjectBehavior );
   commandToClient(%controller.clientOwnerID, 'updateInput', %this.getFieldValue(%field), %field);
}

function SideScrollControls::onClientConnect(%this, %client)
{
   %control = %this.owner.getBehavior("ControlObjectBehavior");
   if( %control.clientOwnerID != %client)
      return;
      
   //pass the keybind setup to our client
   commandToClient(%client, 'SetInput', %this.forwardKey,   "forwardKey");
   commandToClient(%client, 'SetInput', %this.backKey,      "backKey");
   //commandToClient(%client, 'SetInput', %this.leftKey,      "leftKey");
   //commandToClient(%client, 'SetInput', %this.rightKey,     "rightKey");
   
   commandToClient(%client, 'SetInput', %this.jump,         "jump");
   
   //commandToClient(%client, 'SetInput', %this.pitchAxis,    "pitchAxis");
   //commandToClient(%client, 'SetInput', %this.yawAxis,      "yawAxis");
   
   %this.owner.eulerRotation.y = 0;
}

function SideScrollControls::onMoveTrigger(%this, %triggerID)
{
   //check if our jump trigger was pressed!
   if(%triggerID == 2)
   {
      %this.owner.applyImpulse("0 0 0", "0 0 " @ %this.jumpStrength);
   }
}

function SideScrollControls::Update(%this, %moveVector, %moveRotation)
{
   /*if(%moveVector.x)
   {
      %fv = VectorNormalize(%this.owner.getRightVector());
      
      %forMove = VectorScale(%fv, (%moveVector.x * (%this.moveSpeed * 0.032)));
      
      %this.Physics.velocity = VectorAdd(%this.Physics.velocity, %forMove);
   }*/
   
   //Depending on if we press forward or back, we rotate the object to face
   if(%moveVector.y)
   {
      %this.owner.eulerRotation = "0 0 0";
      
      %fv = VectorNormalize(%this.owner.getForwardVector());
      
      %forMove = VectorScale(%fv, (%moveVector.y * (%this.moveSpeed * 0.032)));
      
      %this.Physics.velocity = VectorAdd(%this.Physics.velocity, %forMove);
   }
   else if(%moveVector.y < 0)
   {
      %this.owner.eulerRotation = "0 0 180";
      
      %fv = VectorNormalize(%this.owner.getForwardVector());
      
      %forMove = VectorScale(%fv, (%moveVector.y * (%this.moveSpeed * 0.032)));
      
      %this.Physics.velocity = VectorAdd(%this.Physics.velocity, %forMove);
   }
   
   /*if(%moveVector.z)
   {
      %fv = VectorNormalize(%this.owner.getUpVector());
      
      %forMove = VectorScale(%fv, (%moveVector.z * (%this.moveSpeed * 0.032)));
      
      %this.Physics.velocity = VectorAdd(%this.Physics.velocity, %forMove);
   }*/
   
   //eulerRotation is managed in degrees for human-readability. 
   //if(%moveRotation.x != 0)
   //   %this.owner.eulerRotation.x += mRadToDeg(%moveRotation.x);
      
   //this setup doesn't use roll, so we ignore the y axis!
   
  // if(%moveRotation.z != 0)
   //   %this.owner.eulerRotation.z += mRadToDeg(%moveRotation.z);
   
}

//
function SideScrollControls_forwardKey(%val){
   $mvForwardAction = %val;
}

function SideScrollControls_backKey(%val){
   $mvBackwardAction = %val;
}

function SideScrollControls_jump(%val){
   $mvTriggerCount2++;
}

/*function clientCmdSetInput(%key, %command)
{
   if (!isObject(moveMap))
      return;
      
   moveMap.bind(getWord(%key, 0), getWord(%key, 1), "SideScrollControls_"@%command);
}

function clientCmdUpdateInput(%key, %command)
{
   if (!isObject(moveMap))
      return;
      
   %oldBind = moveMap.getBinding(%command);
   moveMap.unbind(getField(%oldBind, 0), getField(%oldBind, 1));
   moveMap.bind(getWord(%key, 0), getWord(%key, 1), "SideScrollControls_"@%command);

}

function clientCmdRemoveInput(%key, %behavior)
{
   if (!isObject(moveMap))
      return;
      
   moveMap.unbind(getWord(%key, 0), getWord(%key, 1));
}*/