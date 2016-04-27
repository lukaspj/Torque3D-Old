using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiInspectorTypeFileName : GuiInspectorField
   {
      
      public GuiInspectorTypeFileName()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiInspectorTypeFileNameCreateInstance());
      }

      public GuiInspectorTypeFileName(uint pId) : base(pId)
      {
      }

      public GuiInspectorTypeFileName(string pName) : base(pName)
      {
      }

      public GuiInspectorTypeFileName(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspectorTypeFileName(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspectorTypeFileName(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiInspectorTypeFileNameCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}