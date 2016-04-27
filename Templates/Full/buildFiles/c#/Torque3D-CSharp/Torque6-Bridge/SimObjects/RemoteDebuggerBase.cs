using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class RemoteDebuggerBase : SimObject
   {
      
      public RemoteDebuggerBase()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.RemoteDebuggerBaseCreateInstance());
      }

      public RemoteDebuggerBase(uint pId) : base(pId)
      {
      }

      public RemoteDebuggerBase(string pName) : base(pName)
      {
      }

      public RemoteDebuggerBase(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public RemoteDebuggerBase(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public RemoteDebuggerBase(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr RemoteDebuggerBaseCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}