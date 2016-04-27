using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Debugger
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Debugger_SetParameters(int port, string password, bool waitForClient);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Debugger_IsConnected();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Debugger_Disconnect();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Debugger_OpenRemoteDebugger(int debuggerVersion, int port, string password);
      }

      #endregion
      
      #region Functions

      public static void SetParameters(int port, string password, bool waitForClient)
      {
         InternalUnsafeMethods.Debugger_SetParameters(port, password, waitForClient);
      }

      public static bool IsConnected()
      {
         return InternalUnsafeMethods.Debugger_IsConnected();
      }

      public static void Disconnect()
      {
         InternalUnsafeMethods.Debugger_Disconnect();
      }

      public static bool OpenRemoteDebugger(int debuggerVersion, int port, string password)
      {
         return InternalUnsafeMethods.Debugger_OpenRemoteDebugger(debuggerVersion, port, password);
      }      

      #endregion
   }
}