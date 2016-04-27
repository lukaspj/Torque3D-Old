using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class DeferredNode : RootNode
   {
      
      public DeferredNode()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.DeferredNodeCreateInstance());
      }

      public DeferredNode(uint pId) : base(pId)
      {
      }

      public DeferredNode(string pName) : base(pName)
      {
      }

      public DeferredNode(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public DeferredNode(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public DeferredNode(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string DeferredNodeGetColorSrc(IntPtr DeferredNode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DeferredNodeSetColorSrc(IntPtr DeferredNode, string src);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string DeferredNodeGetNormalSrc(IntPtr DeferredNode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DeferredNodeSetNormalSrc(IntPtr DeferredNode, string src);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string DeferredNodeGetMetallicSrc(IntPtr DeferredNode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DeferredNodeSetMetallicSrc(IntPtr DeferredNode, string src);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string DeferredNodeGetRoughnessSrc(IntPtr DeferredNode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DeferredNodeSetRoughnessSrc(IntPtr DeferredNode, string src);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string DeferredNodeGetWorldPosOffsetSrc(IntPtr DeferredNode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DeferredNodeSetWorldPosOffsetSrc(IntPtr DeferredNode, string src);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr DeferredNodeCreateInstance();
      }
      
      #endregion

      #region Properties

      public string ColorSrc
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.DeferredNodeGetColorSrc(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.DeferredNodeSetColorSrc(ObjectPtr->ObjPtr, value);
         }
      }
      public string NormalSrc
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.DeferredNodeGetNormalSrc(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.DeferredNodeSetNormalSrc(ObjectPtr->ObjPtr, value);
         }
      }
      public string MetallicSrc
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.DeferredNodeGetMetallicSrc(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.DeferredNodeSetMetallicSrc(ObjectPtr->ObjPtr, value);
         }
      }
      public string RoughnessSrc
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.DeferredNodeGetRoughnessSrc(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.DeferredNodeSetRoughnessSrc(ObjectPtr->ObjPtr, value);
         }
      }
      public string WorldPosOffsetSrc
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.DeferredNodeGetWorldPosOffsetSrc(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.DeferredNodeSetWorldPosOffsetSrc(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}