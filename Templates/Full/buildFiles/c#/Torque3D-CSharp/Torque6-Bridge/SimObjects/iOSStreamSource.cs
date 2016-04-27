using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class iOSStreamSource : SimObject
   {
      
      public iOSStreamSource()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.iOSStreamSourceCreateInstance());
      }

      public iOSStreamSource(uint pId) : base(pId)
      {
      }

      public iOSStreamSource(string pName) : base(pName)
      {
      }

      public iOSStreamSource(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public iOSStreamSource(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public iOSStreamSource(SimObject pObj) : base(pObj)
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