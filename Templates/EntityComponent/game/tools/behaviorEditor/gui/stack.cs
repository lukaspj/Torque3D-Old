/*
Example:
%state = new GuiControl() {
   class = "VerticalStackControl";
   position = "0 0";
   extent = "285 50";
   horizSizing = "width";
   vertSizing = "height";
   isContainer = "1";
   padding = 4;
   expandParent = true;
}*/

function VerticalStackControl::addToStack(%this, %gui)
{
   %this.add(%gui);
   
   %this.updateStack();
}

function VerticalStackControl::updateStack(%this)
{
   %ypos = 0;
   %extent = 0;
   //resize the control and position it in the stack
   for(%i=0; %i < %this.getCount(); %i++)
   {
      %ctrl = %this.getObject(%i);
      
      if(%ctrl.getParent() == %this.getId())
      {      
         %ext = %ctrl.extent;
         
         %ctrl.position.x = 0; //keep it aligned to the side
         
         if(%i == 0)
            %ctrl.position.y = 0;
         else
         {
            %ctrl.position.y = %ypos + %this.padding;  
         }
         
         %ypos = %ctrl.position.y + %ctrl.extent.y;
                  
         %extent = %ypos;
      }
   }
   
   if(%extent != 0)
   {
      if(%this.expandParent)
      {
         %extentDif = %extent - %this.extent.y;
         %this.getParent().extent.y += %extentDif;
      }
      
      %this.extent.y = %extent;
   }
}