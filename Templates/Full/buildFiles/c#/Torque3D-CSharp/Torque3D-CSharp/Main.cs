using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Torque3D_CSharp.Framework;

namespace Torque3D_CSharp
{
   internal class Main
   {
      [DllImport("Full_DEBUG DLL", CallingConvention = CallingConvention.Cdecl)]
      internal static extern void _fnlogimpl(string msg);

      [DllImport("Full_DEBUG DLL", CallingConvention = CallingConvention.Cdecl)]
      internal static extern void _fnsetMainDotCsDirimpl(string path);

      [DllImport("Full_DEBUG DLL", CallingConvention = CallingConvention.Cdecl)]
      internal static extern bool _fnsetCurrentDirectoryimpl(string path);

      [DllImport("Full_DEBUG DLL", CallingConvention = CallingConvention.Cdecl)]
      internal static extern bool _fnsetLogModeimpl(int mode);

      [ScriptEntryPoint]
      public static void EntryPoint()
      {
         string CSDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
         _fnsetCurrentDirectoryimpl(CSDir);
         _fnsetMainDotCsDirimpl(CSDir);
         _fnsetLogModeimpl(2);

         Console.WriteLine("Script-entry!");
         _fnlogimpl("Such c++ interop");
      }
   }
}
