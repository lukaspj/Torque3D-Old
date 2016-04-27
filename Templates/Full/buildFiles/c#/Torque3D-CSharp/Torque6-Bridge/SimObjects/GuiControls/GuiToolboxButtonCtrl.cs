using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiToolboxButtonCtrl : GuiButtonCtrl
   {
      
      public GuiToolboxButtonCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiToolboxButtonCtrlCreateInstance());
      }

      public GuiToolboxButtonCtrl(uint pId) : base(pId)
      {
      }

      public GuiToolboxButtonCtrl(string pName) : base(pName)
      {
      }

      public GuiToolboxButtonCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiToolboxButtonCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiToolboxButtonCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiToolboxButtonCtrlGetNormalBitmap(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiToolboxButtonCtrlSetNormalBitmap(IntPtr ctrl, string bitmap);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiToolboxButtonCtrlGetLoweredBitmap(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiToolboxButtonCtrlSetLoweredBitmap(IntPtr ctrl, string bitmap);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiToolboxButtonCtrlGetHoverBitmap(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiToolboxButtonCtrlSetHoverBitmap(IntPtr ctrl, string bitmap);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiToolboxButtonCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public string NormalBitmap
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiToolboxButtonCtrlGetNormalBitmap(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiToolboxButtonCtrlSetNormalBitmap(ObjectPtr->ObjPtr, value);
         }
      }
      public string LoweredBitmap
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiToolboxButtonCtrlGetLoweredBitmap(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiToolboxButtonCtrlSetLoweredBitmap(ObjectPtr->ObjPtr, value);
         }
      }
      public string HoverBitmap
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiToolboxButtonCtrlGetHoverBitmap(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiToolboxButtonCtrlSetHoverBitmap(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}