//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

singleton BehaviorTemplate(ItemRotateBehavior)
{
   friendlyName = "Item Rotation";
   behaviorType = "Game";
   description  = "Rotates the entity around the z axis, like an item pickup";

   networked = true;
};

ItemRotateBehavior.addBehaviorField(rotationsPerMinute, "Number of rotations per minute", float, "5.0");
ItemRotateBehavior.addBehaviorField(forward, "Rotate forward or backwards", bool, "1");
ItemRotateBehavior.addBehaviorField(horizontal, "Rotate horizontal or verticle, true for horizontal", bool, "1");


function ItemRotateBehavior::Update(%this)
{
   if(%this.counter == "")
       %this.counter = 0;
	
   //if(%this.counter > 16)
   //{
	  %this.counter = 0;
	  //Rotations per second is calculated based on a standard update tick being 32ms. So we scale by the tick speed, then add that to our rotation to 
	  //get a nice rotation speed.
	  if(%this.horizontal)
	  {
	     if(%this.forward)
		   %this.owner.eulerRotation.z += ( ( 360 * %this.rotationsPerMinute ) / 60 ) * 0.032;
	     else
		   %this.owner.eulerRotation.z -= ( ( 360 * %this.rotationsPerMinute ) / 60 ) * 0.032;
		
		 if(%this.owner.eulerRotation.z > 360 || %this.owner.eulerRotation.z < -360)
		    %this.owner.eulerRotation.z = 0;
	  }
	  else
	  {
		 %this.owner.eulerRotation.x += ( ( 360 * %this.rotationsPerMinute ) / 60 ) * 0.032;
		
		 if(%this.owner.eulerRotation.x > 360 || %this.owner.eulerRotation.x < -360)
		    %this.owner.eulerRotation.x = 0;
	  }
   //}
   //else
      %this.counter++;
}