using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiRolloutCtrl : GuiTickCtrl
   {
      
      public GuiRolloutCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiRolloutCtrlCreateInstance());
      }

      public GuiRolloutCtrl(uint pId) : base(pId)
      {
      }

      public GuiRolloutCtrl(string pName) : base(pName)
      {
      }

      public GuiRolloutCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiRolloutCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiRolloutCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiRolloutCtrlGetCaption(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlSetCaption(IntPtr ctrl, string caption);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlGetMargin(IntPtr ctrl, out Point2I outMargin);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlSetMargin(IntPtr ctrl, Point2I margin);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiRolloutCtrlGetDefaultHeight(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlSetDefaultHeight(IntPtr ctrl, int height);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiRolloutCtrlGetCollapsed(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlSetCollapsed(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiRolloutCtrlGetClickCollapse(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlSetClickCollapse(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiRolloutCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiRolloutCtrlIsExpanded(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlCollapse(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlExpand(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlInstantCollapse(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlInstantExpand(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiRolloutCtrlSizeToContents(IntPtr ctrl);
      }
      
      #endregion

      #region Properties

      public string Caption
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiRolloutCtrlGetCaption(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiRolloutCtrlSetCaption(ObjectPtr->ObjPtr, value);
         }
      }
      public Point2I Margin
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.GuiRolloutCtrlGetMargin(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiRolloutCtrlSetMargin(ObjectPtr->ObjPtr, value);
         }
      }
      public int DefaultHeight
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiRolloutCtrlGetDefaultHeight(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiRolloutCtrlSetDefaultHeight(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Collapsed
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiRolloutCtrlGetCollapsed(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiRolloutCtrlSetCollapsed(ObjectPtr->ObjPtr, value);
         }
      }
      public bool ClickCollapse
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiRolloutCtrlGetClickCollapse(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiRolloutCtrlSetClickCollapse(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public bool IsExpanded()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiRolloutCtrlIsExpanded(ObjectPtr->ObjPtr);
      }

      public void Collapse()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiRolloutCtrlCollapse(ObjectPtr->ObjPtr);
      }

      public void Expand()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiRolloutCtrlExpand(ObjectPtr->ObjPtr);
      }

      public void InstantCollapse()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiRolloutCtrlInstantCollapse(ObjectPtr->ObjPtr);
      }

      public void InstantExpand()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiRolloutCtrlInstantExpand(ObjectPtr->ObjPtr);
      }

      public void SizeToContents()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiRolloutCtrlSizeToContents(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}