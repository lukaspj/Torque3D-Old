using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiCheckBoxCtrl : GuiButtonBaseCtrl
   {
      
      public GuiCheckBoxCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiCheckBoxCtrlCreateInstance());
      }

      public GuiCheckBoxCtrl(uint pId) : base(pId)
      {
      }

      public GuiCheckBoxCtrl(string pName) : base(pName)
      {
      }

      public GuiCheckBoxCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiCheckBoxCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiCheckBoxCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiCheckBoxCtrlGetUseInactiveState(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCheckBoxCtrlSetUseInactiveState(IntPtr ctrl, bool useInactiveState);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiCheckBoxCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCheckBoxCtrlSetStateOn(IntPtr ctrl, int state);
      }
      
      #endregion

      #region Properties

      public bool UseInactiveState
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiCheckBoxCtrlGetUseInactiveState(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiCheckBoxCtrlSetUseInactiveState(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void SetStateOn(int state)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCheckBoxCtrlSetStateOn(ObjectPtr->ObjPtr, state);
      }
      
      #endregion

      
   }
}