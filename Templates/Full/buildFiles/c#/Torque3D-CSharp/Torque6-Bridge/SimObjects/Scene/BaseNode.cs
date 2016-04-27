using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class BaseNode : SimObject
   {
      
      public BaseNode()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.BaseNodeCreateInstance());
      }

      public BaseNode(uint pId) : base(pId)
      {
      }

      public BaseNode(string pName) : base(pName)
      {
      }

      public BaseNode(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public BaseNode(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public BaseNode(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BaseNodeGetPosition(IntPtr materialAsset, out Point2I pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BaseNodeSetPosition(IntPtr materialAsset, Point2I pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr BaseNodeCreateInstance();
      }
      
      #endregion

      #region Properties

      public Point2I Position
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.BaseNodeGetPosition(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.BaseNodeSetPosition(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}