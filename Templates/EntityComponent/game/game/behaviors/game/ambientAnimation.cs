//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(AmbientAnimation))
{
   %template = new AnimationBehavior(AmbientAnimation);
   
   %template.friendlyName = "Ambient Animation";
   %template.behaviorType = "Animation";
   %template.description  = "Plays a specific animation on a loop";
   
   %template.networked = true;
   
   %template.addBehaviorField(animation, "What animation to play", "animationList", "");
}

function AmbientAnimation::onAdd(%this)
{
   %this.playThread(1, %this.animation);
}

function AmbientAnimation::onInspectorUpdate(%this, %field)
{
   %this.playThread(1, %this.animation);
}