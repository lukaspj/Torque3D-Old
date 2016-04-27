using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;

namespace Torque3D_CSharp.Framework
{
   public static class Torque6Main
   {
      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate string CallFunction(
         IntPtr name, IntPtr argv, int argc, [MarshalAs(UnmanagedType.I1)] out bool result);

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate string CallMethod(IntPtr className
         , uint obj
         , IntPtr name
         , IntPtr argv
         , int argc
         , [MarshalAs(UnmanagedType.I1)] out bool result);

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate bool IsMethod(IntPtr className, IntPtr methodName);

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate void MainEntryPoint();

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate bool torque_engineinit(int argc, string[] argv);

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate int torque_enginetick();

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate int torque_getreturnstatus();

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate bool torque_engineshutdown();

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate int T6Main(int pArgc, string[] pArgv, IntPtr pHInstance);

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate void T6SetCallFunction(
         IntPtr pFunctionPtr, IntPtr pMethodPtr, IntPtr pIsMethodPtr, IntPtr pMainPtr);

      public static int InitializeTorque6(string[] args, Libraries libraryNames)
      {
         IDllLoadUtils dllLoadUtils = Platform.IsLinux()
            ? (IDllLoadUtils) new DllLoadUtilsLinux()
            : new DllLoadUtilsWindows();
         string libraryName;

         if (Platform.IsLinux())
         {
            libraryName = IntPtr.Size == 8 ? libraryNames.Linux64bit : libraryNames.Linux32bit;
         }
         else
         {
            libraryName = IntPtr.Size == 8 ? libraryNames.Windows64bit : libraryNames.Windows32bit;
         }

          string mainHandleName = "torque_winmain";

         var dllHandle = dllLoadUtils.LoadLibrary(libraryName);
         //var mainHandle = dllLoadUtils.GetProcAddress(dllHandle, mainHandleName);
         var setCallbacksHandle = dllLoadUtils.GetProcAddress(dllHandle, "SetCallbacks");
         var engineInitHandle = dllLoadUtils.GetProcAddress(dllHandle, "torque_engineinit");
         var engineTickHandle = dllLoadUtils.GetProcAddress(dllHandle, "torque_enginetick");
         var getReturnStatusHandle = dllLoadUtils.GetProcAddress(dllHandle, "torque_getreturnstatus");
         var engineShutdownHandle = dllLoadUtils.GetProcAddress(dllHandle, "torque_engineshutdown");

         var setCallbacks = (T6SetCallFunction) Marshal.GetDelegateForFunctionPointer(
            setCallbacksHandle, typeof (T6SetCallFunction));

         //var main = (T6Main) Marshal.GetDelegateForFunctionPointer(
         //   mainHandle, typeof (T6Main));

         var engineInit = (torque_engineinit)Marshal.GetDelegateForFunctionPointer(
            engineInitHandle, typeof(torque_engineinit));

         var engineTick = (torque_enginetick)Marshal.GetDelegateForFunctionPointer(
            engineTickHandle, typeof(torque_enginetick));

         //var engineGetReturnStatus = (torque_getreturnstatus)Marshal.GetDelegateForFunctionPointer(
         //   getReturnStatusHandle, typeof(torque_getreturnstatus));

         var engineShutdown = (torque_engineshutdown)Marshal.GetDelegateForFunctionPointer(
            engineShutdownHandle, typeof(torque_engineshutdown));


         Initializer.InitializeTypeDictionaries();

         CallFunction callDelegate = CallFunctionDelegate;
         CallMethod methodDelegate = CallMethodDelegate;
         IsMethod isMethodDelegate = IsMethodDelegate;
         IntPtr mainEntryPointPtr = IntPtr.Zero;
         if (Initializer.GetScriptEntry() != null)
            mainEntryPointPtr =
               Marshal.GetFunctionPointerForDelegate(
                  (MainEntryPoint) Initializer.GetScriptEntry().CreateDelegate(typeof (MainEntryPoint)));

         setCallbacks(Marshal.GetFunctionPointerForDelegate(callDelegate)
            , Marshal.GetFunctionPointerForDelegate(methodDelegate)
            , Marshal.GetFunctionPointerForDelegate(isMethodDelegate)
            , mainEntryPointPtr);

         if (!engineInit(args.Length, args)) return 1;

         while (engineTick() > 0)
         {
            
         }

         engineShutdown();
         return 0;
         // return engineGetReturnStatus();
      }

      public static string CallFunctionDelegate(IntPtr name, IntPtr argv, int argc, out bool result)
      {
         string _name = Marshal.PtrToStringAnsi(name);
         string[] strings = null;
         if (argv != IntPtr.Zero)
            strings = CustomMarshalling.IntPtrToStringArray(argv, argc);
         return EngineCallbacks.CallScriptFunction(_name, strings, out result);
      }

      public static string CallMethodDelegate(IntPtr className, uint obj, IntPtr name, IntPtr argv, int argc,
         out bool result)
      {
         result = false;
         return null;
         string _className = Marshal.PtrToStringAnsi(className);
         string _name = Marshal.PtrToStringAnsi(name);

         SimObject objectWrapper = new SimObject(obj);
         string[] strings = null;
         if (argv != IntPtr.Zero)
            strings = CustomMarshalling.IntPtrToStringArray(argv, argc);
         string strRes = EngineCallbacks.CallScriptMethod(objectWrapper.GetName(), objectWrapper, _name, strings, out result);
         if (!result)
            strRes = EngineCallbacks.CallScriptMethod(_className, objectWrapper, _name, strings, out result);
         return strRes;
      }

      public static bool IsMethodDelegate(IntPtr className, IntPtr methodName)
      {
         string _className = Marshal.PtrToStringAnsi(className);
         string _methodName = Marshal.PtrToStringAnsi(methodName);
         return EngineCallbacks.IsMethod(_className, _methodName);
      }

      public struct Libraries
      {
         public string Linux32bit;
         public string Linux64bit;
         public string Windows32bit;
         public string Windows64bit;
      }
   }
}