using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiInspectorTypeGuiProfile : GuiInspectorTypeEnum
   {
      
      public GuiInspectorTypeGuiProfile()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiInspectorTypeGuiProfileCreateInstance());
      }

      public GuiInspectorTypeGuiProfile(uint pId) : base(pId)
      {
      }

      public GuiInspectorTypeGuiProfile(string pName) : base(pName)
      {
      }

      public GuiInspectorTypeGuiProfile(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspectorTypeGuiProfile(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspectorTypeGuiProfile(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiInspectorTypeGuiProfileCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}