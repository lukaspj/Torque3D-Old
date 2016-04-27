using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiBitmapButtonTextCtrl : GuiBitmapButtonCtrl
   {
      
      public GuiBitmapButtonTextCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiBitmapButtonTextCtrlCreateInstance());
      }

      public GuiBitmapButtonTextCtrl(uint pId) : base(pId)
      {
      }

      public GuiBitmapButtonTextCtrl(string pName) : base(pName)
      {
      }

      public GuiBitmapButtonTextCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiBitmapButtonTextCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiBitmapButtonTextCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiBitmapButtonTextCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}