using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Input
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Input_DeactivateDirectInput();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Input_ActivateDirectInput();
      }

      #endregion
      
      #region Functions

      public static void DeactivateDirectInput()
      {
         InternalUnsafeMethods.Input_DeactivateDirectInput();
      }

      public static void ActivateDirectInput()
      {
         InternalUnsafeMethods.Input_ActivateDirectInput();
      }      

      #endregion
   }
}