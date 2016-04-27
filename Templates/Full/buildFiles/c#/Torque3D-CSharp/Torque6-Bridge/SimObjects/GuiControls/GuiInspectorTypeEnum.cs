using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiInspectorTypeEnum : GuiInspectorField
   {
      
      public GuiInspectorTypeEnum()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiInspectorTypeEnumCreateInstance());
      }

      public GuiInspectorTypeEnum(uint pId) : base(pId)
      {
      }

      public GuiInspectorTypeEnum(string pName) : base(pName)
      {
      }

      public GuiInspectorTypeEnum(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspectorTypeEnum(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspectorTypeEnum(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiInspectorTypeEnumCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}