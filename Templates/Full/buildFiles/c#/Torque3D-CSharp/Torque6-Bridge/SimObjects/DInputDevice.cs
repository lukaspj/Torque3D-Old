using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class DInputDevice : InputDevice
   {
      
      public DInputDevice()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.DInputDeviceCreateInstance());
      }

      public DInputDevice(uint pId) : base(pId)
      {
      }

      public DInputDevice(string pName) : base(pName)
      {
      }

      public DInputDevice(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public DInputDevice(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public DInputDevice(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr DInputDeviceCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}