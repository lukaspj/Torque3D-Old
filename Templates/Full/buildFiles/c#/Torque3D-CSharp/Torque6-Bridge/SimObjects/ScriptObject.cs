using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.SimObjects.Scene;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class ScriptObject : BehaviorComponent
   {
      
      public ScriptObject()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.ScriptObjectCreateInstance());
      }

      public ScriptObject(uint pId) : base(pId)
      {
      }

      public ScriptObject(string pName) : base(pName)
      {
      }

      public ScriptObject(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public ScriptObject(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public ScriptObject(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ScriptObjectCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}