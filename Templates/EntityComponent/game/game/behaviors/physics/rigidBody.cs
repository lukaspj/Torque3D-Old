if (!isObject(RigidBodyBehavior))
{
   %template = new RigidBodyBehavior(RigidBodyBehavior);
   
   %template.friendlyName = "Rigid Body";
   %template.behaviorType = "Physics";
   %template.description  = "Allows a moving, dynamic object to collide or interact.";

   //%template.addBehaviorField(shapeName, "The shape to use for rendering", file, "", shapeFile);
}

function MoveCollisionBehavior::onBehaviorAdd(%this)
{
   echo("THIS BEHAVIOR IS ADDED");
}