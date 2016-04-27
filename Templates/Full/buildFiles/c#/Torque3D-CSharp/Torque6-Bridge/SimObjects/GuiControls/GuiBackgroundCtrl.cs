using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiBackgroundCtrl : GuiControl
   {
      
      public GuiBackgroundCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiBackgroundCtrlCreateInstance());
      }

      public GuiBackgroundCtrl(uint pId) : base(pId)
      {
      }

      public GuiBackgroundCtrl(string pName) : base(pName)
      {
      }

      public GuiBackgroundCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiBackgroundCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiBackgroundCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiBackgroundCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}