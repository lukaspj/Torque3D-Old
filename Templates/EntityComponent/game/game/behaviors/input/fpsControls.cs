//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(FPSControls))
{
   %template = new BehaviorTemplate(FPSControls);
   
   %template.friendlyName = "FPS Controls";
   %template.behaviorType = "Input";
   %template.description  = "First Person Shooter-type controls";
   
   %template.networked = true;
   
   %template.beginGroup("Keys");
      %template.addBehaviorField(forwardKey, "Key to bind to vertical thrust", keybind, "keyboard w");
      %template.addBehaviorField(backKey, "Key to bind to vertical thrust", keybind, "keyboard s");
      %template.addBehaviorField(leftKey, "Key to bind to horizontal thrust", keybind, "keyboard a");
      %template.addBehaviorField(rightKey, "Key to bind to horizontal thrust", keybind, "keyboard d");
      
      %template.addBehaviorField(jump, "Key to bind to horizontal thrust", keybind, "keyboard space");
   %template.endGroup();
   
   %template.beginGroup("Mouse");
      %template.addBehaviorField(pitchAxis, "Key to bind to horizontal thrust", keybind, "mouse yaxis");
      %template.addBehaviorField(yawAxis, "Key to bind to horizontal thrust", keybind, "mouse xaxis");
   %template.endGroup();
   
   %template.addBehaviorField(moveSpeed, "Horizontal thrust force", float, 20.0);
   %template.addBehaviorField(jumpStrength, "Vertical thrust force", float, 3.0);
   
   //%template.addDependency("SimplePhysicsBehavior");
}

function FPSControls::onBehaviorAdd(%this)
{
   Parent::onBehaviorAdd(%this);
   
   %this.Physics = %this.owner.getBehavior( PhysicsBehavior );
}

function FPSControls::onBehaviorRemove(%this)
{
   Parent::onBehaviorRemove(%this);
   
   commandToClient(%control.clientOwnerID, 'removeInput', %this.forwardKey);
   commandToClient(%control.clientOwnerID, 'removeInput', %this.backKey);
   commandToClient(%control.clientOwnerID, 'removeInput', %this.leftKey);
   commandToClient(%control.clientOwnerID, 'removeInput', %this.rightKey);
   
   commandToClient(%control.clientOwnerID, 'removeInput', %this.pitchAxis);
   commandToClient(%control.clientOwnerID, 'removeInput', %this.yawAxis);
}

function FPSControls::onBehaviorFieldUpdate(%this, %field)
{
   %controller = %this.owner.getBehavior( ControlObjectBehavior );
   commandToClient(%controller.clientOwnerID, 'updateInput', %this.getFieldValue(%field), %field);
}

function FPSControls::onClientConnect(%this, %client)
{
   %control = %this.owner.getBehavior( ControlObjectBehavior );
   if( %control.clientOwnerID != %client)
      return;
      
   %commandName = "FPSControls";
   
   SetInput(%client, %this.forwardKey.x,  %this.forwardKey.y,  %commandName@"_forwardKey");
   SetInput(%client, %this.backKey.x,     %this.backKey.y,     %commandName@"_backKey");
   SetInput(%client, %this.leftKey.x,     %this.leftKey.y,     %commandName@"_leftKey");
   SetInput(%client, %this.rightKey.x,    %this.rightKey.y,    %commandName@"_rightKey");
   
   SetInput(%client, %this.jump.x,        %this.jump.y,        %commandName@"_jump");
      
   SetInput(%client, %this.pitchAxis.x,   %this.pitchAxis.y,   %commandName@"_pitchAxis");
   SetInput(%client, %this.yawAxis.x,     %this.yawAxis.y,     %commandName@"_yawAxis");
   
   %this.owner.eulerRotation.y = 0;
}

function FPSControls::onMoveTrigger(%this, %triggerID)
{
   //check if our jump trigger was pressed!
   if(%triggerID == 2)
   {
      %this.owner.applyImpulse("0 0 0", "0 0 " @ %this.jumpStrength);
   }
}

function FPSControls::Update(%this, %moveVector, %moveRotation)
{
   if(%moveVector.x)
   {
      %fv = VectorNormalize(%this.owner.getRightVector());
      
      %forMove = VectorScale(%fv, (%moveVector.x * (%this.moveSpeed * 0.032)));
      
      %this.Physics.velocity = VectorAdd(%this.Physics.velocity, %forMove);
   }
   
   if(%moveVector.y)
   {
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
   if(%moveRotation.x != 0)
      %this.owner.eulerRotation.x += mRadToDeg(%moveRotation.x);
      
   //this setup doesn't use roll, so we ignore the y axis!
   
   if(%moveRotation.z != 0)
      %this.owner.eulerRotation.z += mRadToDeg(%moveRotation.z);
   
}

//
function FPSControls_forwardKey(%val){
   $mvForwardAction = %val;
}

function FPSControls_backKey(%val){
   $mvBackwardAction = %val;
}

function FPSControls_leftKey(%val){
   $mvLeftAction = %val;
}

function FPSControls_rightKey(%val){
   $mvRightAction = %val;
}

function FPSControls_yawAxis(%val){
   %deg = getMouseAdjustAmount(%val);
   $mvYaw += getMouseAdjustAmount(%val);
}

function FPSControls_pitchAxis(%val){
   %deg = getMouseAdjustAmount(%val);
   $mvPitch += getMouseAdjustAmount(%val);
}

function FPSControls_jump(%val){
   $mvTriggerCount2++;
}

/*function clientCmdSetInput(%key, %command)
{
   if (!isObject(moveMap))
      return;
      
   moveMap.bind(getWord(%key, 0), getWord(%key, 1), "FPSControls_"@%command);
}

function clientCmdUpdateInput(%key, %command)
{
   if (!isObject(moveMap))
      return;
      
   %oldBind = moveMap.getBinding(%command);
   moveMap.unbind(getField(%oldBind, 0), getField(%oldBind, 1));
   moveMap.bind(getWord(%key, 0), getWord(%key, 1), "FPSControls_"@%command);
}

function clientCmdRemoveInput(%key, %behavior)
{
   if (!isObject(moveMap))
      return;
      
   moveMap.unbind(getWord(%key, 0), getWord(%key, 1));
}*/