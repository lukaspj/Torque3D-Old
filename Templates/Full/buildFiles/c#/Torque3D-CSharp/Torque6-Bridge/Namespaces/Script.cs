using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Script
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Script_DumpConsoleClasses(bool dumpScript, bool dumpEngine);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Script_DumpConsoleFunctions(bool dumpScript, bool dumpEngine);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Script_Backtrace();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Script_IsPackage(string packageName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Script_ActivatePackage(string packageName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Script_DeactivatePackage(string packageName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Script_Call(string funcName, int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Script_GetDSOPath(string scriptFileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Script_Compile(string scriptFileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Script_CompilePath(string path, Point2I outRes);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Script_SetScriptExecEcho(bool echo);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Script_Exec(string fileName, bool noCalls, bool journalScript);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Script_Eval(string script);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Script_GetVariable(string varName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Script_IsFunction(string funcName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Script_IsMethod(string nameSpace, string method);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Script_GetModNameFromPath(string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Script_GetPrefsPath(string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Script_ExecPrefs(string fileName, bool nocalls, bool journalScript);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Script_Export(string wildCard, string fileName, bool append);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Script_DeleteVariables(string wildCard);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Script_Trace(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Script_EnumerateConsoleClasses(string baseClass);
      }

      #endregion
      
      #region Functions

      public static void DumpConsoleClasses(bool dumpScript, bool dumpEngine)
      {
         InternalUnsafeMethods.Script_DumpConsoleClasses(dumpScript, dumpEngine);
      }

      public static void DumpConsoleFunctions(bool dumpScript, bool dumpEngine)
      {
         InternalUnsafeMethods.Script_DumpConsoleFunctions(dumpScript, dumpEngine);
      }

      public static void Backtrace()
      {
         InternalUnsafeMethods.Script_Backtrace();
      }

      public static bool IsPackage(string packageName)
      {
         return InternalUnsafeMethods.Script_IsPackage(packageName);
      }

      public static void ActivatePackage(string packageName)
      {
         InternalUnsafeMethods.Script_ActivatePackage(packageName);
      }

      public static void DeactivatePackage(string packageName)
      {
         InternalUnsafeMethods.Script_DeactivatePackage(packageName);
      }

      public static string Call(string funcName, int argc, string[] argv)
      {
         return InternalUnsafeMethods.Script_Call(funcName, argc, argv);
      }

      public static string GetDSOPath(string scriptFileName)
      {
         return InternalUnsafeMethods.Script_GetDSOPath(scriptFileName);
      }

      public static bool Compile(string scriptFileName)
      {
         return InternalUnsafeMethods.Script_Compile(scriptFileName);
      }

      public static void CompilePath(string path, Point2I outRes)
      {
         InternalUnsafeMethods.Script_CompilePath(path, outRes);
      }

      public static void SetScriptExecEcho(bool echo)
      {
         InternalUnsafeMethods.Script_SetScriptExecEcho(echo);
      }

      public static bool Exec(string fileName, bool noCalls, bool journalScript)
      {
         return InternalUnsafeMethods.Script_Exec(fileName, noCalls, journalScript);
      }

      public static string Eval(string script)
      {
         return InternalUnsafeMethods.Script_Eval(script);
      }

      public static string GetVariable(string varName)
      {
         return InternalUnsafeMethods.Script_GetVariable(varName);
      }

      public static bool IsFunction(string funcName)
      {
         return InternalUnsafeMethods.Script_IsFunction(funcName);
      }

      public static bool IsMethod(string nameSpace, string method)
      {
         return InternalUnsafeMethods.Script_IsMethod(nameSpace, method);
      }

      public static string GetModNameFromPath(string path)
      {
         return InternalUnsafeMethods.Script_GetModNameFromPath(path);
      }

      public static string GetPrefsPath(string fileName)
      {
         return InternalUnsafeMethods.Script_GetPrefsPath(fileName);
      }

      public static bool ExecPrefs(string fileName, bool nocalls, bool journalScript)
      {
         return InternalUnsafeMethods.Script_ExecPrefs(fileName, nocalls, journalScript);
      }

      public static void Export(string wildCard, string fileName, bool append)
      {
         InternalUnsafeMethods.Script_Export(wildCard, fileName, append);
      }

      public static void DeleteVariables(string wildCard)
      {
         InternalUnsafeMethods.Script_DeleteVariables(wildCard);
      }

      public static void Trace(bool enable)
      {
         InternalUnsafeMethods.Script_Trace(enable);
      }

      public static string EnumerateConsoleClasses(string baseClass)
      {
         return InternalUnsafeMethods.Script_EnumerateConsoleClasses(baseClass);
      }      

      #endregion
   }
}