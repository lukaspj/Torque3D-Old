using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiInspectorTypeColor : GuiInspectorField
   {
      
      public GuiInspectorTypeColor()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiInspectorTypeColorCreateInstance());
      }

      public GuiInspectorTypeColor(uint pId) : base(pId)
      {
      }

      public GuiInspectorTypeColor(string pName) : base(pName)
      {
      }

      public GuiInspectorTypeColor(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspectorTypeColor(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspectorTypeColor(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiInspectorTypeColorCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}