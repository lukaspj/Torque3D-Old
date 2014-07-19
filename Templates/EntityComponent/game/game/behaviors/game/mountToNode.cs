singleton BehaviorTemplate(mountToNodeBehavior)
{
   friendlyName = "Friendly Name";
   behaviorType = "Game";
   description  = "This is a template to copy for new behaviors";

   networked = true;
};

mountToNodeBehavior.addBehaviorField(targetNode, "The node in question on the mountee's model", string, "10.0");

function mountToNodeBehavior::onAdd(%this) 
{
   Parent::onAdd(%this);
   
   %mount = %this.owner.getObjectMount();
   
   if(%mount.getClassName() $= "Entity" && %mount.getBehavior( RenderShapeBehavior ))
      %mount.mountObject(%this.owner, targetNode);
}

function mountToNodeBehavior::onRemove(%this)
{
   Parent::onRemove(%this);
   
   
}