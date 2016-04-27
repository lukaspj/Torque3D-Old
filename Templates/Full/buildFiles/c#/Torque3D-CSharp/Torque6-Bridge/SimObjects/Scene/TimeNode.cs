using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class TimeNode : BaseNode
   {
      
      public TimeNode()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.TimeNodeCreateInstance());
      }

      public TimeNode(uint pId) : base(pId)
      {
      }

      public TimeNode(string pName) : base(pName)
      {
      }

      public TimeNode(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public TimeNode(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public TimeNode(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float TimeNodeGetMultiplier(IntPtr timeNode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void TimeNodeSetMultiplier(IntPtr timeNode, float slot);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr TimeNodeCreateInstance();
      }
      
      #endregion

      #region Properties

      public float Multiplier
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.TimeNodeGetMultiplier(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.TimeNodeSetMultiplier(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}