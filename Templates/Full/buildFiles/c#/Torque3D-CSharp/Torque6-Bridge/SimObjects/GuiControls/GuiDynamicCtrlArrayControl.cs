using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiDynamicCtrlArrayControl : GuiControl
   {
      
      public GuiDynamicCtrlArrayControl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiDynamicCtrlArrayControlCreateInstance());
      }

      public GuiDynamicCtrlArrayControl(uint pId) : base(pId)
      {
      }

      public GuiDynamicCtrlArrayControl(string pName) : base(pName)
      {
      }

      public GuiDynamicCtrlArrayControl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiDynamicCtrlArrayControl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiDynamicCtrlArrayControl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiDynamicCtrlArrayControlGetColCount(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiDynamicCtrlArrayControlSetColCount(IntPtr ctrl, int cols);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiDynamicCtrlArrayControlGetColSize(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiDynamicCtrlArrayControlSetColSize(IntPtr ctrl, int colSize);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiDynamicCtrlArrayControlGetRowSize(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiDynamicCtrlArrayControlSetRowSize(IntPtr ctrl, int size);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiDynamicCtrlArrayControlGetRowSpacing(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiDynamicCtrlArrayControlSetRowSpacing(IntPtr ctrl, int Spacing);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiDynamicCtrlArrayControlGetColSpacing(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiDynamicCtrlArrayControlSetColSpacing(IntPtr ctrl, int Spacing);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiDynamicCtrlArrayControlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiDynamicCtrlArrayControlRefresh(IntPtr ctrl);
      }
      
      #endregion

      #region Properties

      public int ColCount
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiDynamicCtrlArrayControlGetColCount(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiDynamicCtrlArrayControlSetColCount(ObjectPtr->ObjPtr, value);
         }
      }
      public int ColSize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiDynamicCtrlArrayControlGetColSize(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiDynamicCtrlArrayControlSetColSize(ObjectPtr->ObjPtr, value);
         }
      }
      public int RowSize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiDynamicCtrlArrayControlGetRowSize(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiDynamicCtrlArrayControlSetRowSize(ObjectPtr->ObjPtr, value);
         }
      }
      public int RowSpacing
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiDynamicCtrlArrayControlGetRowSpacing(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiDynamicCtrlArrayControlSetRowSpacing(ObjectPtr->ObjPtr, value);
         }
      }
      public int ColSpacing
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiDynamicCtrlArrayControlGetColSpacing(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiDynamicCtrlArrayControlSetColSpacing(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void Refresh()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiDynamicCtrlArrayControlRefresh(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}