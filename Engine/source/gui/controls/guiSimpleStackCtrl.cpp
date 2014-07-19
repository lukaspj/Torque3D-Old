#include "gui/controls/guiSimpleStackCtrl.h"

IMPLEMENT_CONOBJECT(GuiSimpleStackCtrl);

GuiSimpleStackCtrl::GuiSimpleStackCtrl()
{
	mExtendParent = true;
	mPadding = 5;
}

void GuiSimpleStackCtrl::initPersistFields()
{
	Parent::initPersistFields();

	addField("extendParent", TypeBool, Offset(mExtendParent, GuiSimpleStackCtrl), "Controls if this control force the parent control to expand to match");
	addField("padding", TypeS32, Offset(mPadding, GuiSimpleStackCtrl), "Controls how much padding space is there between child elements");
}

void GuiSimpleStackCtrl::addObject(SimObject *obj)
{
	Parent::addObject(obj);
   
	updateStack();
}

void GuiSimpleStackCtrl::removeObject(SimObject *obj)
{
	Parent::removeObject(obj);
   
	updateStack();
}

void GuiSimpleStackCtrl::updateStack()
{
   S32 ypos = 0;
   S32 extent = 0;

   //resize the control and position it in the stack
   for(U32 i=0; i < size(); i++)
   {
      GuiControl *ctrl = dynamic_cast<GuiControl*>(at(i));
      
	  if(ctrl->getParent()->getId() == getId())
      {      
         Point2I ext = ctrl->getExtent();
         
		 //we want to keep it aligned to the side
		 //so keep x to 0
		 Point2I pos = Point2I(0,0);
         
         if(i == 0)
            pos.y = 0;
         else
         {
            pos.y = ypos + mPadding;  
         }

		 ctrl->setPosition(pos);
         
		 ypos = pos.y + ctrl->getExtent().y;
                  
         extent = ypos;
      }
   }
   
   if(extent != 0)
   {
      if(mExtendParent)
      {
         S32 extentDif = extent - getExtent().y;

		 Point2I curExt = getParent()->getExtent();
		 curExt.y += extentDif;

         getParent()->setExtent(curExt);
      }
      
	  Point2I curExt = getExtent();
	  curExt.y = extent;

	  setExtent(curExt);
   }
}

ConsoleMethod(GuiSimpleStackCtrl, updateStack, void, 2, 2, "() - Get the template name of this behavior\n"
																	 "@return (string name) The name of the template this behaivor was created from")
{
   object->updateStack();
}