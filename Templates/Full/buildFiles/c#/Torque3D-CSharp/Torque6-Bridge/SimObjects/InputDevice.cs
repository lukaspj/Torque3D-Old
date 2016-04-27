using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class InputDevice : SimObject
   {
      
      public InputDevice()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.InputDeviceCreateInstance());
      }

      public InputDevice(uint pId) : base(pId)
      {
      }

      public InputDevice(string pName) : base(pName)
      {
      }

      public InputDevice(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public InputDevice(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public InputDevice(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr InputDeviceCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}