using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class ConsoleLogger : SimObject
   {
      
      public ConsoleLogger()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.ConsoleLoggerCreateInstance());
      }

      public ConsoleLogger(uint pId) : base(pId)
      {
      }

      public ConsoleLogger(string pName) : base(pName)
      {
      }

      public ConsoleLogger(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public ConsoleLogger(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public ConsoleLogger(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ConsoleLoggerGetLevel(IntPtr logger);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ConsoleLoggerSetLevel(IntPtr logger, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ConsoleLoggerCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ConsoleLoggerAttach(IntPtr logger);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ConsoleLoggerDetach(IntPtr logger);
      }
      
      #endregion

      #region Properties

      public int Level
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ConsoleLoggerGetLevel(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ConsoleLoggerSetLevel(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public bool Attach()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ConsoleLoggerAttach(ObjectPtr->ObjPtr);
      }

      public bool Detach()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ConsoleLoggerDetach(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}