using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class MaterialTemplate : SimGroup
   {
      
      public MaterialTemplate()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.MaterialTemplateCreateInstance());
      }

      public MaterialTemplate(uint pId) : base(pId)
      {
      }

      public MaterialTemplate(string pName) : base(pName)
      {
      }

      public MaterialTemplate(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public MaterialTemplate(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public MaterialTemplate(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr MaterialTemplateCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}