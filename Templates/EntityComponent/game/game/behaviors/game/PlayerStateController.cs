//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(PlayerStateController))
{
   %template = new BehaviorTemplate(PlayerStateController);
   
   %template.friendlyName = "Player State Controller";
   %template.behaviorType = "Game";
   %template.description  = "Sets up a player state machine.";
   
   %template.networked = true;
   
   %template.addBehaviorField(playerStates, "States of the player controller", "stateMachine", "");
   
   //_behavior01_01 = "state stateName fieldname0 value fieldname1 value fieldname3 value"
}

function PlayerStateController::onBehaviorAdd(%this)
{
   %animBhv = %this.owner.getBehavior( AnimationController );
   if(!%animBhv)
   {
      %instance = ("AnimationController").createInstance();
      %animBhv = %this.owner.addBehavior(%instance);
   }
   %this.animator = %animBhv;
   
   //we set all the acceptable field and transition options here
   %this.transitions = "transitionOnTimeout transitionOnAnimEnd transitionOnAnimTrigger transitionOnTrigger transitionOnMotion";
   
   %this.dataFields = "animation soundFile particleEffect";
   
   %this.valueFields = "timeout functionName";
   
   %this.addStateField("TestState", "animationEnd", "Pants");
   //%this.state["testState", "timeout"] = "";
}

function PlayerStateController::Update(%this)
{
   %this.stateTime += 32; //tick rate
   
   %tim = %this.state[%this.currentState, "Timeout"];
   if(%this.state[%this.currentState, "Timeout"] !$= "" 
         && %this.state[%this.currentState, "TransitionOnTimeout"] !$= ""
         && %this.stateTime > %this.state[%this.currentState, "Timeout"])
   {
      %this.onEvent("Timeout", "_");
   
      //do other things.
      return; //only handle 1 state transition a tick
   }
}

/*function PlayerStateController::addStateField(%this, %stateName, %field, %value)
{
   %this.addStateField(%stateName, %field, %value);
}*/

function PlayerStateController::addStateField(%this, %stateName, %fieldName, %fieldValue, %noDelete)
{
   if(!isObject(%this.stateMachine))
         %this.stateMachine = new ArrayObject();      
   
   %this.stateMachine.add(%stateName, (%fieldName SPC %fieldValue));  
   %this.addBehaviorField(%stateName, (%fieldName SPC %fieldValue)); 
}

function PlayerStateController::onEvent(%this, %event, %trigger)
{
   if(isObject(%this.stateMachine))
   {
      for(%i = 0; %i < %this.stateMachine.count(); %i++)
      {
         if(%this.stateMachine.getValue(%i) $= %event)
         {
            if(getWord(%this.stateMachine.getKey(%i),1) $= %trigger || %trigger $= "_")
            {
               %this.setState(getWord(%this.stateMachine.getKey(%i),0));
               %this.stateMachine.erase(%i);
            }
         }
      }
   }
}

function PlayerStateController::setState(%this, %stateName)
{
   eval(%this@"."@%stateName@"();"); //fire it off!  
}