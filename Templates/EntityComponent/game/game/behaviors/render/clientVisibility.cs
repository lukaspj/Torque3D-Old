//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

if (!isObject(ClientVisibilityBehavior))
{
   %template = new BehaviorTemplate(ClientVisibilityBehavior);
   
   %template.friendlyName = "Client Visibility";
   %template.behaviorType = "Render";
   %template.description  = "Causes the object to render a 3d shape using the file provided.";
   %template.networked    = true;

   %template.addBehaviorField(clientOwner, "The shape to use for rendering", "int", "LocalClientConnection", "");
}

function ClientVisibilityBehavior::onBehaviorAdd(%this)
{
   if(isObject(%this.clientOwner))
   {
      commandToClient(%this.clientOwner, 'HideClientRenderShape', %this.clientOwner.getGhostID(%this.owner.getBehaviorByType("RenderShapeBehavior")));
   }
}

function ClientVisibilityBehavior::onClientConnect(%this, %client)
{
   if(isObject(%this.clientOwner) && %client == %this.clientOwner.getId())
   {
      commandToClient(%client, 'HideClientRenderShape', %client.getGhostID(%this.owner.getBehaviorByType("RenderShapeBehavior")));
   }
}

function ClientVisibilityBehavior::onInspectorUpdate(%this, %slot)
{
   if(%slot $= "clientOwner")
   {
      if(isObject(%this.clientOwner))
      {
         commandToClient(%this.clientOwner, 'HideClientRenderShape', %this.clientOwner.getGhostID(%this.owner.getBehaviorByType("RenderShapeBehavior")));
      }
   }
}

//
function clientCmdHideClientRenderShape(%id)
{
   %localID = ServerConnection.resolveGhostID(%id); 
   %localID.enabled = !%localID.enabled;
}

function serverToClientObject( %serverObject )
{
   assert( isObject( LocalClientConnection ), "serverToClientObject() - No local client connection found!" );
   assert( isObject( ServerConnection ), "serverToClientObject() - No server connection found!" );      
         
   %ghostId = LocalClientConnection.getGhostId( %serverObject );
   if ( %ghostId == -1 )
      return 0;
                
   return ServerConnection.resolveGhostID( %ghostId );   
}