using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Mac
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Mac_SetFSAA(int samples);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Mac_IncreaseFSAA();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Mac_DecreaseFSAA();
      }

      #endregion
      
      #region Functions

      public static void SetFSAA(int samples)
      {
         InternalUnsafeMethods.Mac_SetFSAA(samples);
      }

      public static void IncreaseFSAA()
      {
         InternalUnsafeMethods.Mac_IncreaseFSAA();
      }

      public static void DecreaseFSAA()
      {
         InternalUnsafeMethods.Mac_DecreaseFSAA();
      }      

      #endregion
   }
}