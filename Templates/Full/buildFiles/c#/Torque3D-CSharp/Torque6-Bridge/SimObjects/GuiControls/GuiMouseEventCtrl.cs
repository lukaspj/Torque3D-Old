using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiMouseEventCtrl : GuiControl
   {
      
      public GuiMouseEventCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiMouseEventCtrlCreateInstance());
      }

      public GuiMouseEventCtrl(uint pId) : base(pId)
      {
      }

      public GuiMouseEventCtrl(string pName) : base(pName)
      {
      }

      public GuiMouseEventCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMouseEventCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMouseEventCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiMouseEventCtrlGetLockMouse(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMouseEventCtrlSetLockMouse(IntPtr ctrl, bool enableLock);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiMouseEventCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public bool LockMouse
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiMouseEventCtrlGetLockMouse(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMouseEventCtrlSetLockMouse(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}