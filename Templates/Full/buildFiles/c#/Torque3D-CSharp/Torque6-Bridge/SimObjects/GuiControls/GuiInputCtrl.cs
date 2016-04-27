using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiInputCtrl : GuiControl
   {
      
      public GuiInputCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiInputCtrlCreateInstance());
      }

      public GuiInputCtrl(uint pId) : base(pId)
      {
      }

      public GuiInputCtrl(string pName) : base(pName)
      {
      }

      public GuiInputCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInputCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInputCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiInputCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}