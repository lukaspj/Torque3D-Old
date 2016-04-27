using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiControl : SimGroup
   {
      
      public GuiControl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiControlCreateInstance());
      }

      public GuiControl(uint pId) : base(pId)
      {
      }

      public GuiControl(string pName) : base(pName)
      {
      }

      public GuiControl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiControl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiControl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlGetIsContainer(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetIsContainer(IntPtr ctrl, bool container);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiControlGetProfile(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetProfile(IntPtr ctrl, IntPtr profile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlGetHorizSizing(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetHorizSizing(IntPtr ctrl, int sizing);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlGetVertSizing(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetVertSizing(IntPtr ctrl, int sizing);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlGetPosition(IntPtr ctrl, out Point2I outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetPosition(IntPtr ctrl, Point2I pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlGetExtent(IntPtr ctrl, out Point2I outExt);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetExtent(IntPtr ctrl, Point2I ext);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlGetMinExtent(IntPtr ctrl, out Point2I outExt);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetMinExtent(IntPtr ctrl, Point2I ext);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlGetCanSave(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetCanSave(IntPtr ctrl, bool canSave);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlGetVisible(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetVisible(IntPtr ctrl, bool isVisible);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiControlGetVariable(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetVariable(IntPtr ctrl, string variable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiControlGetCommand(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetCommand(IntPtr ctrl, string command);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiControlGetAltCommand(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetAltCommand(IntPtr ctrl, string command);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiControlGetAccelerator(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetAccelerator(IntPtr ctrl, string acceleratorKey);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlGetActive(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetActive(IntPtr ctrl, bool isActive);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiControlGetTooltipProfile(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetTooltipProfile(IntPtr ctrl, IntPtr profile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiControlGetTooltip(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetTooltip(IntPtr ctrl, string tooltip);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlGetTooltipWidth(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetTooltipWidth(IntPtr ctrl, int width);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlGetHoverTime(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetHoverTime(IntPtr ctrl, int time);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiControlGetLangTableMod(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetLangTableMod(IntPtr ctrl, string langTableName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiControlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlPointInControl(IntPtr ctrl, Point2I point);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlAddGuiControl(IntPtr ctrl, IntPtr guiCtrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlReorderChild(IntPtr ctrl, IntPtr child1, IntPtr child2);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiControlGetParent(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetValue(IntPtr ctrl, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiControlGetValue(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlIsActive(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlIsVisible(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlMakeFirstResponder(IntPtr ctrl, bool isFirst);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlIsAwake(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlResize(IntPtr ctrl, Point2I newPos, Point2I newExt);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlGetCenter(IntPtr ctrl, Point2I outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetCenter(IntPtr ctrl, Point2I newCenter);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlGetGlobalCenter(IntPtr ctrl, Point2I outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlGetGlobalPosition(IntPtr ctrl, Point2I outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetPositionGlobal(IntPtr ctrl, Point2I pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiControlFindHitControl(IntPtr ctrl, Point2I pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlSetFirstResponder(IntPtr ctrl);
      }
      
      #endregion

      #region Properties

      public bool IsContainer
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetIsContainer(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetIsContainer(ObjectPtr->ObjPtr, value);
         }
      }
      public GuiControlProfile Profile
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return new GuiControlProfile(InternalUnsafeMethods.GuiControlGetProfile(ObjectPtr->ObjPtr));
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetProfile(ObjectPtr->ObjPtr, value.ObjectPtr->ObjPtr);
         }
      }
      public int HorizSizing
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetHorizSizing(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetHorizSizing(ObjectPtr->ObjPtr, value);
         }
      }
      public int VertSizing
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetVertSizing(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetVertSizing(ObjectPtr->ObjPtr, value);
         }
      }
      public Point2I Position
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.GuiControlGetPosition(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetPosition(ObjectPtr->ObjPtr, value);
         }
      }
      public Point2I Extent
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.GuiControlGetExtent(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetExtent(ObjectPtr->ObjPtr, value);
         }
      }
      public Point2I MinExtent
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.GuiControlGetMinExtent(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetMinExtent(ObjectPtr->ObjPtr, value);
         }
      }
      public bool CanSave
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetCanSave(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetCanSave(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Visible
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetVisible(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetVisible(ObjectPtr->ObjPtr, value);
         }
      }
      public string Variable
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetVariable(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetVariable(ObjectPtr->ObjPtr, value);
         }
      }
      public string Command
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetCommand(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetCommand(ObjectPtr->ObjPtr, value);
         }
      }
      public string AltCommand
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetAltCommand(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetAltCommand(ObjectPtr->ObjPtr, value);
         }
      }
      public string Accelerator
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetAccelerator(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetAccelerator(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Active
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetActive(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetActive(ObjectPtr->ObjPtr, value);
         }
      }
      public GuiControlProfile Tooltipprofile
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return new GuiControlProfile(InternalUnsafeMethods.GuiControlGetTooltipProfile(ObjectPtr->ObjPtr));
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetTooltipProfile(ObjectPtr->ObjPtr, value.ObjectPtr->ObjPtr);
         }
      }
      public string Tooltip
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetTooltip(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetTooltip(ObjectPtr->ObjPtr, value);
         }
      }
      public int TooltipWidth
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetTooltipWidth(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetTooltipWidth(ObjectPtr->ObjPtr, value);
         }
      }
      public int Hovertime
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetHoverTime(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetHoverTime(ObjectPtr->ObjPtr, value);
         }
      }
      public string LangTableMod
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlGetLangTableMod(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlSetLangTableMod(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public bool PointInControl(Point2I point)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiControlPointInControl(ObjectPtr->ObjPtr, point);
      }

      public void AddGuiControl(GuiControl guiCtrl)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlAddGuiControl(ObjectPtr->ObjPtr, guiCtrl.ObjectPtr->ObjPtr);
      }

      public void ReorderChild(GuiControl child1, GuiControl child2)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlReorderChild(ObjectPtr->ObjPtr, child1.ObjectPtr->ObjPtr, child2.ObjectPtr->ObjPtr);
      }

      public GuiControl GetParent()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new GuiControl(InternalUnsafeMethods.GuiControlGetParent(ObjectPtr->ObjPtr));
      }

      public void SetValue(string value)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlSetValue(ObjectPtr->ObjPtr, value);
      }

      public string GetValue()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiControlGetValue(ObjectPtr->ObjPtr);
      }

      public bool IsActive()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiControlIsActive(ObjectPtr->ObjPtr);
      }

      public bool IsVisible()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiControlIsVisible(ObjectPtr->ObjPtr);
      }

      public void MakeFirstResponder(bool isFirst)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlMakeFirstResponder(ObjectPtr->ObjPtr, isFirst);
      }

      public bool IsAwake()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiControlIsAwake(ObjectPtr->ObjPtr);
      }

      public void Resize(Point2I newPos, Point2I newExt)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlResize(ObjectPtr->ObjPtr, newPos, newExt);
      }

      public void GetCenter(Point2I outPos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlGetCenter(ObjectPtr->ObjPtr, outPos);
      }

      public void SetCenter(Point2I newCenter)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlSetCenter(ObjectPtr->ObjPtr, newCenter);
      }

      public void GetGlobalCenter(Point2I outPos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlGetGlobalCenter(ObjectPtr->ObjPtr, outPos);
      }

      public void GetGlobalPosition(Point2I outPos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlGetGlobalPosition(ObjectPtr->ObjPtr, outPos);
      }

      public void SetPositionGlobal(Point2I pos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlSetPositionGlobal(ObjectPtr->ObjPtr, pos);
      }

      public GuiControl FindHitControl(Point2I pos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new GuiControl(InternalUnsafeMethods.GuiControlFindHitControl(ObjectPtr->ObjPtr, pos));
      }

      public void SetFirstResponder()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiControlSetFirstResponder(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}