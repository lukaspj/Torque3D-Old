function SetInput(%client, %device, %key, %command, %bindMap, %behav)
{
   commandToClient(%client, 'SetInput', %device, %key, %command, %bindMap, %behav);  
}

function RemoveInput(%client, %device, %key, %command, %bindMap)
{
   commandToClient(%client, 'removeInput', %device, %key, %command, %bindMap);  
}

function clientCmdSetInput(%device, %key, %command, %bindMap, %behav)
{
   //if we're requesting a custom bind map, set that up
   if(%bindMap $= "")
      %bindMap = moveMap;
   
   if (!isObject(%bindMap)){
      new ActionMap(moveMap);
      moveMap.push();
   }
      
   //get our local
   //%localID = ServerConnection.resolveGhostID(%behav); 
   
   //%tmpl = %localID.getTemplate();
   //%tmpl.insantiateNamespace(%tmpl.getName());
      
   //first, check if we have an existing command
   %oldBind = %bindMap.getBinding(%command);
   if(%oldBind !$= "")
      %bindMap.unbind(getField(%oldBind, 0), getField(%oldBind, 1));
    
   //now, set the requested bind   
   %bindMap.bind(%device, %key, %command);
}

function clientCmdRemoveSpecCtrlInput(%device, %key, %bindMap)
{
   //if we're requesting a custom bind map, set that up
   if(%bindMap $= "")
      %bindMap = moveMap;
   
   if (!isObject(%bindMap))
      return;
      
   %bindMap.unbind(%device, %key);
}

function clientCmdSetupClientBehavior(%bhvrGstID)
{
   %localID = ServerConnection.resolveGhostID(%bhvrGstID); 
   %tmpl = %localID.getTemplate();
   %tmpl.insantiateNamespace(%tmpl.getName());
}

function getMouseAdjustAmount(%val)
{
   // based on a default camera FOV of 90'
   return(%val * ($cameraFov / 90) * 0.01) * $pref::Input::LinkMouseSensitivity;
}