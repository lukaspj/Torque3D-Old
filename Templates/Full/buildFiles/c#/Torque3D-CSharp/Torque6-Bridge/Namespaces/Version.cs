using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Version
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Version_IsDebugBuild();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Version_GetVersionNumber();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Version_GetVersionString();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Version_GetCompileTimeString();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Version_GetBuildString();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Version_GetEngineVersion();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Version_GetiPhoneToolsVersion();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Version_SetCompanyAndProduct(string company, string product);
      }

      #endregion
      
      #region Functions

      public static bool IsDebugBuild()
      {
         return InternalUnsafeMethods.Version_IsDebugBuild();
      }

      public static int GetVersionNumber()
      {
         return InternalUnsafeMethods.Version_GetVersionNumber();
      }

      public static string GetVersionString()
      {
         return InternalUnsafeMethods.Version_GetVersionString();
      }

      public static string GetCompileTimeString()
      {
         return InternalUnsafeMethods.Version_GetCompileTimeString();
      }

      public static string GetBuildString()
      {
         return InternalUnsafeMethods.Version_GetBuildString();
      }

      public static string GetEngineVersion()
      {
         return InternalUnsafeMethods.Version_GetEngineVersion();
      }

      public static string GetiPhoneToolsVersion()
      {
         return InternalUnsafeMethods.Version_GetiPhoneToolsVersion();
      }

      public static void SetCompanyAndProduct(string company, string product)
      {
         InternalUnsafeMethods.Version_SetCompanyAndProduct(company, product);
      }      

      #endregion
   }
}