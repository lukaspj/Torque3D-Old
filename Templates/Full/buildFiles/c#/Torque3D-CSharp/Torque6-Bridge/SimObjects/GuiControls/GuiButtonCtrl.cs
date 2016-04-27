using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiButtonCtrl : GuiButtonBaseCtrl
   {
      
      public GuiButtonCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiButtonCtrlCreateInstance());
      }

      public GuiButtonCtrl(uint pId) : base(pId)
      {
      }

      public GuiButtonCtrl(string pName) : base(pName)
      {
      }

      public GuiButtonCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiButtonCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiButtonCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiButtonCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}