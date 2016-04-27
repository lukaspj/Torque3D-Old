using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiInspectorDatablockField : GuiInspectorField
   {
      
      public GuiInspectorDatablockField()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiInspectorDatablockFieldCreateInstance());
      }

      public GuiInspectorDatablockField(uint pId) : base(pId)
      {
      }

      public GuiInspectorDatablockField(string pName) : base(pName)
      {
      }

      public GuiInspectorDatablockField(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspectorDatablockField(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspectorDatablockField(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiInspectorDatablockFieldCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}