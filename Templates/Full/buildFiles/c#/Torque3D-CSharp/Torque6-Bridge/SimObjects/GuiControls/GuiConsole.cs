using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiConsole : GuiArrayCtrl
   {
      
      public GuiConsole()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiConsoleCreateInstance());
      }

      public GuiConsole(uint pId) : base(pId)
      {
      }

      public GuiConsole(string pName) : base(pName)
      {
      }

      public GuiConsole(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiConsole(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiConsole(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiConsoleCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}