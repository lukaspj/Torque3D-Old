if (!isObject(BoxCollider))
{
   %template = new BoxColliderBehavior(BoxCollider);
   
   %template.friendlyName = "Box Collider";
   %template.behaviorType = "Collision";
   %template.description  = "Providers a collision body in a box shape.";
   %template.networked    = true;
   
   %template.addBehaviorField(collisionMask, "Types this collides with", selectiveList, "");
}

function BoxColliderBehavior::onCollision(%this, %colObject, %vector, %velocity)
{
   echo("We collided!");
}