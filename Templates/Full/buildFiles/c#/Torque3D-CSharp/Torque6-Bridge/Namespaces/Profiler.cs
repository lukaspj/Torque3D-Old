using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Profiler
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Profiler_MarkerEnable(string markerName, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Profiler_Enable(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Profiler_Dump();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Profiler_DumpToFile(string file);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Profiler_Reset();
      }

      #endregion
      
      #region Functions

      public static void MarkerEnable(string markerName, bool enable)
      {
         InternalUnsafeMethods.Profiler_MarkerEnable(markerName, enable);
      }

      public static void Enable(bool enable)
      {
         InternalUnsafeMethods.Profiler_Enable(enable);
      }

      public static void Dump()
      {
         InternalUnsafeMethods.Profiler_Dump();
      }

      public static void DumpToFile(string file)
      {
         InternalUnsafeMethods.Profiler_DumpToFile(file);
      }

      public static void Reset()
      {
         InternalUnsafeMethods.Profiler_Reset();
      }      

      #endregion
   }
}