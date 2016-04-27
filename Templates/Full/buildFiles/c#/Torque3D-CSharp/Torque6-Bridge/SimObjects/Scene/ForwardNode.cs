using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class ForwardNode : RootNode
   {
      
      public ForwardNode()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.ForwardNodeCreateInstance());
      }

      public ForwardNode(uint pId) : base(pId)
      {
      }

      public ForwardNode(string pName) : base(pName)
      {
      }

      public ForwardNode(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public ForwardNode(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public ForwardNode(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ForwardNodeGetColorSrc(IntPtr forwardNode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ForwardNodeSetColorSrc(IntPtr forwardNode, string src);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ForwardNodeGetLit(IntPtr forwardNode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ForwardNodeSetLit(IntPtr forwardNode, bool isLit);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ForwardNodeCreateInstance();
      }
      
      #endregion

      #region Properties

      public string ColorSrc
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ForwardNodeGetColorSrc(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ForwardNodeSetColorSrc(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Lit
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ForwardNodeGetLit(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ForwardNodeSetLit(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}