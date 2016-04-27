using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class SimDataBlock : SimObject
   {
      
      public SimDataBlock()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.SimDataBlockCreateInstance());
      }

      public SimDataBlock(uint pId) : base(pId)
      {
      }

      public SimDataBlock(string pName) : base(pName)
      {
      }

      public SimDataBlock(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public SimDataBlock(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public SimDataBlock(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SimDataBlockCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}