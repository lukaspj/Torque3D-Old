if (!isObject(SimplePhysicsBehav))
{
   %template = new SimplePhysicsBehavior(SimplePhysicsBehav);
   
   %template.friendlyName = "Simple Physics";
   %template.behaviorType = "Physics";
   %template.description  = "Allows a moving, dynamic object to collide or interact.";

   //%template.addBehaviorField(shapeName, "The shape to use for rendering", file, "", shapeFile);
}