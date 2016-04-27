using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Plugins
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Plugins_Load(string path);
      }

      #endregion
      
      #region Functions

      public static void Load(string path)
      {
         InternalUnsafeMethods.Plugins_Load(path);
      }      

      #endregion
   }
}