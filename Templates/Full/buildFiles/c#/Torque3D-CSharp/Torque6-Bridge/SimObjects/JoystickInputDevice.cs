using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class JoystickInputDevice : InputDevice
   {
      
      public JoystickInputDevice()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.JoystickInputDeviceCreateInstance());
      }

      public JoystickInputDevice(uint pId) : base(pId)
      {
      }

      public JoystickInputDevice(string pName) : base(pName)
      {
      }

      public JoystickInputDevice(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public JoystickInputDevice(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public JoystickInputDevice(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}