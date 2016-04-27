using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiControlArrayControl : GuiControl
   {
      
      public GuiControlArrayControl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiControlArrayControlCreateInstance());
      }

      public GuiControlArrayControl(uint pId) : base(pId)
      {
      }

      public GuiControlArrayControl(string pName) : base(pName)
      {
      }

      public GuiControlArrayControl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiControlArrayControl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiControlArrayControl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlArrayControlGetColCount(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlArrayControlSetColCount(IntPtr ctrl, int cols);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlArrayControlGetRowSize(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlArrayControlSetRowSize(IntPtr ctrl, int size);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlArrayControlGetRowSpacing(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlArrayControlSetRowSpacing(IntPtr ctrl, int spacing);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlArrayControlGetColSpacing(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlArrayControlSetColSpacing(IntPtr ctrl, int spacing);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiControlArrayControlCreateInstance();
      }
      
      #endregion

      #region Properties

      public int ColCount
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlArrayControlGetColCount(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlArrayControlSetColCount(ObjectPtr->ObjPtr, value);
         }
      }
      public int RowSize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlArrayControlGetRowSize(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlArrayControlSetRowSize(ObjectPtr->ObjPtr, value);
         }
      }
      public int RowSpacing
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlArrayControlGetRowSpacing(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlArrayControlSetRowSpacing(ObjectPtr->ObjPtr, value);
         }
      }
      public int ColSpacing
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlArrayControlGetColSpacing(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlArrayControlSetColSpacing(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}