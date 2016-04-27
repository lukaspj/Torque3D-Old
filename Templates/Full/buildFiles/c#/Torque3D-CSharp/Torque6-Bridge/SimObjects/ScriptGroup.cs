using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class ScriptGroup : SimGroup
   {
      
      public ScriptGroup()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.ScriptGroupCreateInstance());
      }

      public ScriptGroup(uint pId) : base(pId)
      {
      }

      public ScriptGroup(string pName) : base(pName)
      {
      }

      public ScriptGroup(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public ScriptGroup(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public ScriptGroup(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ScriptGroupCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}