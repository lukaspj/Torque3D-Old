using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Graphics
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Graphics_SetDefaultShaderPath(string path);
      }

      #endregion
      
      #region Functions

      public static void SetDefaultShaderPath(string path)
      {
         InternalUnsafeMethods.Graphics_SetDefaultShaderPath(path);
      }      

      #endregion
   }
}