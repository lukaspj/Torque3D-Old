using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class UInputManager : InputManager
   {
      
      public UInputManager()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.UInputManagerCreateInstance());
      }

      public UInputManager(uint pId) : base(pId)
      {
      }

      public UInputManager(string pName) : base(pName)
      {
      }

      public UInputManager(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public UInputManager(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public UInputManager(SimObject pObj) : base(pObj)
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