using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class RemoteDebugger1 : RemoteDebuggerBase
   {
      
      public RemoteDebugger1()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.RemoteDebugger1CreateInstance());
      }

      public RemoteDebugger1(uint pId) : base(pId)
      {
      }

      public RemoteDebugger1(string pName) : base(pName)
      {
      }

      public RemoteDebugger1(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public RemoteDebugger1(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public RemoteDebugger1(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr RemoteDebugger1CreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string RemoteDebugger1GetCodeFiles(IntPtr debugger1);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void RemoteDebugger1SetNextStatementBreak(IntPtr debugger1, bool enabled);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public string GetCodeFiles()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.RemoteDebugger1GetCodeFiles(ObjectPtr->ObjPtr);
      }

      public void SetNextStatementBreak(bool enabled)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.RemoteDebugger1SetNextStatementBreak(ObjectPtr->ObjPtr, enabled);
      }
      
      #endregion

      
   }
}