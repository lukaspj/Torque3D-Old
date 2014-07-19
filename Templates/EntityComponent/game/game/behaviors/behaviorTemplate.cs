singleton BehaviorTemplate(BehaviorName)
{
   friendlyName = "Friendly Name";
   behaviorType = "Game";
   description  = "This is a template to copy for new behaviors";

   networked = true;
};

BehaviorName.addBehaviorField(BehaviorField, "A test behavior field", float, "10.0");

function BehaviorName::onAdd(%this) 
{
   Parent::onAdd(%this);
}

function BehaviorName::onRemove(%this)
{
   Parent::onRemove(%this);
}