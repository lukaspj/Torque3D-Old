using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiBubbleTextCtrl : GuiTextCtrl
   {
      
      public GuiBubbleTextCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiBubbleTextCtrlCreateInstance());
      }

      public GuiBubbleTextCtrl(uint pId) : base(pId)
      {
      }

      public GuiBubbleTextCtrl(string pName) : base(pName)
      {
      }

      public GuiBubbleTextCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiBubbleTextCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiBubbleTextCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiBubbleTextCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}