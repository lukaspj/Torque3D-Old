using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Globals
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Globals_GetBool(string variable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Globals_SetBool(string variable, bool val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Globals_GetInt(string variable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Globals_SetInt(string variable, int val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float Globals_GetFloat(string variable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Globals_SetFloat(string variable, float val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Globals_GetString(string variable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Globals_SetString(string variable, string val);
      }

      #endregion
      
      #region Functions

      public static bool GetBool(string variable)
      {
         return InternalUnsafeMethods.Globals_GetBool(variable);
      }

      public static void SetBool(string variable, bool val)
      {
         InternalUnsafeMethods.Globals_SetBool(variable, val);
      }

      public static int GetInt(string variable)
      {
         return InternalUnsafeMethods.Globals_GetInt(variable);
      }

      public static void SetInt(string variable, int val)
      {
         InternalUnsafeMethods.Globals_SetInt(variable, val);
      }

      public static float GetFloat(string variable)
      {
         return InternalUnsafeMethods.Globals_GetFloat(variable);
      }

      public static void SetFloat(string variable, float val)
      {
         InternalUnsafeMethods.Globals_SetFloat(variable, val);
      }

      public static string GetString(string variable)
      {
         return InternalUnsafeMethods.Globals_GetString(variable);
      }

      public static void SetString(string variable, string val)
      {
         InternalUnsafeMethods.Globals_SetString(variable, val);
      }      

      #endregion
   }
}