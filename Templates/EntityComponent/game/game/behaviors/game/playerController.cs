//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

singleton BehaviorTemplate(PlayerController)
{ 
   friendlyName = "Player Controller";
   behaviorType = "Player";
   description  = "First Person Shooter-type player controller";
   
   networked = true;
};

PlayerController.beginGroup("Keys");
	PlayerController.addBehaviorField(forwardKey, "Key to bind to vertical thrust", keybind, "keyboard w");
	PlayerController.addBehaviorField(backKey, "Key to bind to vertical thrust", keybind, "keyboard s");
	PlayerController.addBehaviorField(leftKey, "Key to bind to horizontal thrust", keybind, "keyboard a");
	PlayerController.addBehaviorField(rightKey, "Key to bind to horizontal thrust", keybind, "keyboard d");
	
	PlayerController.addBehaviorField(jump, "Key to bind to horizontal thrust", keybind, "keyboard space");
PlayerController.endGroup();

PlayerController.beginGroup("Mouse");
	PlayerController.addBehaviorField(pitchAxis, "Key to bind to horizontal thrust", keybind, "mouse yaxis");
	PlayerController.addBehaviorField(yawAxis, "Key to bind to horizontal thrust", keybind, "mouse xaxis");
PlayerController.endGroup();

PlayerController.beginGroup("Movement");
	PlayerController.addBehaviorField(moveSpeed, "Horizontal thrust force", float, 20.0);
	PlayerController.addBehaviorField(jumpStrength, "Vertical thrust force", float, 3.0);
PlayerController.endGroup();

PlayerController.beginGroup("Animation");
    PlayerController.addBehaviorField(rootAnim, "The root, idle animation", animationList, "");
	PlayerController.addBehaviorField(runFAnim, "The forward running animation", animationList, "");
	PlayerController.addBehaviorField(runBAnim, "The back running animation", animationList, "");
	PlayerController.addBehaviorField(runLAnim, "The left running animation", animationList, "");
	PlayerController.addBehaviorField(runRAnim, "The right running animation", animationList, "");
	
	PlayerController.addBehaviorField(lookAnim, "The look animation", animationList, "");
	
	PlayerController.addBehaviorField(lookAngle, "The angle the look animation is set at", float, 0);
PlayerController.endGroup();


function PlayerController::onAdd(%this)
{
   Parent::onBehaviorAdd(%this);
   
   %this.Physics = %this.owner.getBehavior( SimplePhysics );
   %this.Animation = %this.owner.getBehavior( AnimationController );
   %this.Collision = %this.owner.getBehavior( BoxCollider );

   %this.moveAnimThread = 0;
   %this.lookAnimThread = 1;

   %this.Animation.playThread(%this.moveAnimThread, %this.rootAnim, false);
   %this.Animation.setThreadAnimation(%this.lookAnimThread, %this.lookAnim);
   %this.Animation.setThreadPosition(%this.lookAnimThread,0.5);
}

function PlayerController::onRemove(%this)
{
   Parent::onBehaviorRemove(%this);
   
   commandToClient(%control.clientOwnerID, 'removeInput', %this.forwardKey);
   commandToClient(%control.clientOwnerID, 'removeInput', %this.backKey);
   commandToClient(%control.clientOwnerID, 'removeInput', %this.leftKey);
   commandToClient(%control.clientOwnerID, 'removeInput', %this.rightKey);
   
   commandToClient(%control.clientOwnerID, 'removeInput', %this.pitchAxis);
   commandToClient(%control.clientOwnerID, 'removeInput', %this.yawAxis);
}

function PlayerController::onInspectorUpdate(%this, %field)
{
   %controller = %this.owner.getBehavior( ControlObjectBehavior );
   commandToClient(%controller.clientOwnerID, 'updateInput', %this.getFieldValue(%field), %field);

   if(%field $= "lookAnim")
      %this.Animation.setThreadAnimation(%this.lookAnimThread, %this.getFieldValue(%field));
	
   if(%field $= "lookAngle")
	  echo("WE CHANGED OUR LOOK ANGLE");
}

function PlayerController::onClientConnect(%this, %client)
{
   %control = %this.owner.getBehavior( ControlObjectBehavior );
   if( %control.getClientID() != %client)
      return;
      
   %commandName = "PlayerControls";
   
   SetInput(%client, %this.forwardKey.x,  %this.forwardKey.y,  %commandName@"_forwardKey");
   SetInput(%client, %this.backKey.x,     %this.backKey.y,     %commandName@"_backKey");
   SetInput(%client, %this.leftKey.x,     %this.leftKey.y,     %commandName@"_leftKey");
   SetInput(%client, %this.rightKey.x,    %this.rightKey.y,    %commandName@"_rightKey");
   
   SetInput(%client, %this.jump.x,        %this.jump.y,        %commandName@"_jump");
      
   SetInput(%client, %this.pitchAxis.x,   %this.pitchAxis.y,   %commandName@"_pitchAxis");
   SetInput(%client, %this.yawAxis.x,     %this.yawAxis.y,     %commandName@"_yawAxis");
   
   %this.owner.eulerRotation.y = 0;
}

function PlayerController::onMoveTrigger(%this, %triggerID)
{
   //check if our jump trigger was pressed, but only if we're contacting a valid surface
   if(%triggerID == 2 && %this.Collision.hasContact())
   {
      %this.owner.applyImpulse("0 0 0", "0 0 " @ %this.jumpStrength);
   }
}

function PlayerController::Update(%this, %moveVector, %moveRotation)
{
   if(%moveVector.x)
   {
      %fv = VectorNormalize(%this.owner.getRightVector());
      
      %forMove = VectorScale(%fv, (%moveVector.x * (%this.moveSpeed * 0.032)));
      
      %this.Physics.velocity = VectorAdd(%this.Physics.velocity, %forMove);
	
	  if(%moveVector.x > 0)
	     %this.Animation.playThread(%this.moveAnimThread, %this.runRAnim);
	  else if(%moveVector.x < 0)
	  {
		 if(%this.runLAnim == %this.runRAnim)
		     %this.Animation.setThreadDir(%this.moveAnimThread, false);
		 else
		     %this.Animation.setThreadDir(%this.moveAnimThread, true);
	     %this.Animation.playThread(%this.moveAnimThread, %this.runLAnim);
	  }
   }
   
   if(%moveVector.y)
   {
      %fv = VectorNormalize(%this.owner.getForwardVector());
      
      %forMove = VectorScale(%fv, (%moveVector.y * (%this.moveSpeed * 0.032)));
      
      %this.Physics.velocity = VectorAdd(%this.Physics.velocity, %forMove);
	
	  if(%moveVector.y > 0)
	     %this.Animation.playThread(%this.moveAnimThread, %this.runFAnim);
	  else if(%moveVector.y < 0)
	     %this.Animation.playThread(%this.moveAnimThread, %this.runBAnim);
   }

   if(%moveVector.x == 0 && %moveVector.y == 0)
   {
	  %this.Animation.playThread(%this.moveAnimThread, %this.rootAnim);
	  if(%this.Physics.velocity.x != 0)
	  {
		 %this.Physics.velocity.x *= 0.7;
      }
	  if(%this.Physics.velocity.y != 0)
	  {
		 %this.Physics.velocity.y *= 0.7;	
      }
   }
   
   /*if(%moveVector.z)
   {
      %fv = VectorNormalize(%this.owner.getUpVector());
      
      %forMove = VectorScale(%fv, (%moveVector.z * (%this.moveSpeed * 0.032)));
      
      %this.Physics.velocity = VectorAdd(%this.Physics.velocity, %forMove);
   }*/
   
   //eulerRotation is managed in degrees for human-readability. 
   /*if(%moveRotation.x)
   {
	  %deg = mRadToDeg(%moveRotation.x);
	  %this.lookAngle += %deg;
	
	  if(%this.lookAngle > 90)
		 %this.lookAngle = 90;
	  else if(%this.lookAngle < -90)
		 %this.lookAngle = -90;
		
      %tp = (%this.lookAngle - -90) / 180;
	  if(%tp > 1)
		 %tp = 1;
	  else if(%tp < 0)
		 %tp = 0;
		
	  %this.Animation.setThreadPosition(%this.lookAnimThread,%tp);
   }*/

   if(%moveRotation.z != 0)
      %this.owner.eulerRotation.z += mRadToDeg(%moveRotation.z);

   if(%moveRotation.x != 0)
   {
	  %adj = mRadToDeg(%moveRotation.x);
      PlayerCam.eulerRotation.x += %adj;
   }
      
   //this setup doesn't use roll, so we ignore the y axis!

   if(%this.camera.eulerRotation.y != 0)
	  %this.camera.eulerRotation.y = 0;	
   
}

//
function PlayerControls_forwardKey(%val){
   $mvForwardAction = %val;
}

function PlayerControls_backKey(%val){
   $mvBackwardAction = %val;
}

function PlayerControls_leftKey(%val){
   $mvLeftAction = %val;
}

function PlayerControls_rightKey(%val){
   $mvRightAction = %val;
}

function PlayerControls_yawAxis(%val){
   %deg = getMouseAdjustAmount(%val);
   $mvYaw += getMouseAdjustAmount(%val);
}

function PlayerControls_pitchAxis(%val){
   %deg = getMouseAdjustAmount(%val);
   $mvPitch += getMouseAdjustAmount(%val);
}

function PlayerControls_jump(%val){
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