using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiTabBookCtrl : GuiControl
   {
      
      public GuiTabBookCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiTabBookCtrlCreateInstance());
      }

      public GuiTabBookCtrl(uint pId) : base(pId)
      {
      }

      public GuiTabBookCtrl(string pName) : base(pName)
      {
      }

      public GuiTabBookCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTabBookCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTabBookCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTabBookCtrlGetTabPosition(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTabBookCtrlSetTabPosition(IntPtr ctrl, int tabPosition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTabBookCtrlGetTabHeight(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTabBookCtrlSetTabHeight(IntPtr ctrl, int height);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTabBookCtrlGetTabMargin(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTabBookCtrlSetTabMargin(IntPtr ctrl, int margin);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTabBookCtrlGetMinTabWidth(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTabBookCtrlSetMinTabWidth(IntPtr ctrl, int width);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiTabBookCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTabBookCtrlAddPage(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTabBookCtrlSelectPage(IntPtr ctrl, int pageIndex);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTabBookCtrlSelectPageName(IntPtr ctrl, string pageName);
      }
      
      #endregion

      #region Properties

      public int TabPosition
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTabBookCtrlGetTabPosition(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTabBookCtrlSetTabPosition(ObjectPtr->ObjPtr, value);
         }
      }
      public int TabHeight
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTabBookCtrlGetTabHeight(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTabBookCtrlSetTabHeight(ObjectPtr->ObjPtr, value);
         }
      }
      public int TabMargin
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTabBookCtrlGetTabMargin(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTabBookCtrlSetTabMargin(ObjectPtr->ObjPtr, value);
         }
      }
      public int MinTabWidth
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTabBookCtrlGetMinTabWidth(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTabBookCtrlSetMinTabWidth(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void AddPage()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTabBookCtrlAddPage(ObjectPtr->ObjPtr);
      }

      public void SelectPage(int pageIndex)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTabBookCtrlSelectPage(ObjectPtr->ObjPtr, pageIndex);
      }

      public void SelectPageName(string pageName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTabBookCtrlSelectPageName(ObjectPtr->ObjPtr, pageName);
      }
      
      #endregion

      
   }
}