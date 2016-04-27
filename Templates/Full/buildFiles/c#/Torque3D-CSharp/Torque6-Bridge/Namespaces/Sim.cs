using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Sim
   {
      [StructLayout(LayoutKind.Explicit, Size = 4)]
      public partial struct SimObjectPtr
      {
         [FieldOffset(0)] public IntPtr ObjPtr;
      }

      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr Sim_FindObjectById(uint id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr Sim_FindObjectWrapperById(uint id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr Sim_FindObjectByName(string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr Sim_FindObjectWrapperByName(string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr Sim_WrapObject(IntPtr obj);
      }

      #endregion
      
      #region Functions

      public static SimObject FindObjectById(uint id)
      {
         return new SimObject(InternalUnsafeMethods.Sim_FindObjectById(id));
      }

      public static SimObjectPtr* FindObjectWrapperById(uint id)
      {
         return (SimObjectPtr*) InternalUnsafeMethods.Sim_FindObjectWrapperById(id);
      }

      public static SimObject FindObjectByName(string name)
      {
         return new SimObject(InternalUnsafeMethods.Sim_FindObjectByName(name));
      }

      public static SimObjectPtr* FindObjectWrapperByName(string name)
      {
         return (SimObjectPtr*)InternalUnsafeMethods.Sim_FindObjectWrapperByName(name);
      }

      public static SimObjectPtr* WrapObject(IntPtr obj)
      {
         return (SimObjectPtr*)InternalUnsafeMethods.Sim_WrapObject(obj);
      }      

      #endregion
   }
}