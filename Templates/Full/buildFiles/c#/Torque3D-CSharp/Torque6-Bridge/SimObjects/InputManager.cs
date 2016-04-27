using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class InputManager : SimGroup
   {
      
      public InputManager()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.InputManagerCreateInstance());
      }

      public InputManager(uint pId) : base(pId)
      {
      }

      public InputManager(string pName) : base(pName)
      {
      }

      public InputManager(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public InputManager(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public InputManager(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr InputManagerCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}