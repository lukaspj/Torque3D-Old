using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiMLTextEditCtrl : GuiMLTextCtrl
   {
      
      public GuiMLTextEditCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiMLTextEditCtrlCreateInstance());
      }

      public GuiMLTextEditCtrl(uint pId) : base(pId)
      {
      }

      public GuiMLTextEditCtrl(string pName) : base(pName)
      {
      }

      public GuiMLTextEditCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMLTextEditCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMLTextEditCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiMLTextEditCtrlGetEscapeCommand(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextEditCtrlSetEscapeCommand(IntPtr ctrl, string command);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiMLTextEditCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public string EscapeCommand
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiMLTextEditCtrlGetEscapeCommand(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMLTextEditCtrlSetEscapeCommand(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}