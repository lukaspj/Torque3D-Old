//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(RenderShapeBehav))
{
   %template = new RenderShapeBehavior(RenderShapeBehav);
   
   %template.friendlyName = "Render Shape";
   %template.behaviorType = "Render";
   %template.description  = "Causes the object to render a 3d shape using the file provided.";
   
   %template.networked = true;
   
   %template.category = "Behaviors";
}

function RenderShapeBehav::onAdd(%this)
{
   %this.shapeName = %this.shapeName;
}

function RenderShapeBehav::onRender(%this)
{
   if(%this.doRender)
      %this.doRender = false;
}