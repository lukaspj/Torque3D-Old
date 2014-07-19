//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(BasicStateMachine))
{
   %template = new StateMachineBehavior(BasicStateMachine);
   
   %template.friendlyName = "Basic State Machine";
   %template.behaviorType = "Game";
   %template.description  = "A Basic State Machine";
   
   %template.addBehaviorField(SMEdit, "States of the SM", stateMachine, "");
   %template.addBehaviorField(startingState, "The initial state for the machine", stateMachineState, "");
}

