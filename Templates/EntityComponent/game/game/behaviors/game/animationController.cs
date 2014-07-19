//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(AnimationController))
{
   //%template = new StateMachineBehavior(AnimationController);
   %template = new AnimationBehavior(AnimationController);

   %template.networked = true;
   
   %template.friendlyName = "Animation Controller";
   %template.behaviorType = "Animation";
   %template.description  = "Manages animations for an entity";
}

function AnimationController::onBehaviorAdd(%this)
{
   		
}

function AnimationController::onStateChange(%this)
{
		
}

function AnimationController::onAnimationEnd(%this, %animation)
{
   //if(%this.owner.isMethod("onEvent"))
   //   %this.owner.onEvent("animationEnd", %animation);
}

function AnimationController::onAnimationTrigger(%this, %animation)
{
  // if(%this.owner.isMethod("onEvent"))
  //    %this.owner.onEvent("animationTrigger", %animation);
}