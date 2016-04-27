using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class RootNode : BaseNode
   {
      
      public RootNode()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.RootNodeCreateInstance());
      }

      public RootNode(uint pId) : base(pId)
      {
      }

      public RootNode(string pName) : base(pName)
      {
      }

      public RootNode(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public RootNode(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public RootNode(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr RootNodeCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}