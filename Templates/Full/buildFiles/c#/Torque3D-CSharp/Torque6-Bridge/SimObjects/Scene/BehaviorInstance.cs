using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class BehaviorInstance : SimObject
   {
      
      public BehaviorInstance()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.BehaviorInstanceCreateInstance());
      }

      public BehaviorInstance(uint pId) : base(pId)
      {
      }

      public BehaviorInstance(string pName) : base(pName)
      {
      }

      public BehaviorInstance(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public BehaviorInstance(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public BehaviorInstance(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr BehaviorInstanceGetTemplate(IntPtr instance);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BehaviorInstanceSetTemplate(IntPtr instance, IntPtr temp);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr BehaviorInstanceGetOwner(IntPtr instance);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BehaviorInstanceSetOwner(IntPtr instance, IntPtr val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr BehaviorInstanceCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string BehaviorInstanceGetTemplateName(IntPtr instance);
      }
      
      #endregion

      #region Properties

      public BehaviorTemplate Template
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return new BehaviorTemplate(InternalUnsafeMethods.BehaviorInstanceGetTemplate(ObjectPtr->ObjPtr));
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.BehaviorInstanceSetTemplate(ObjectPtr->ObjPtr, value.ObjectPtr->ObjPtr);
         }
      }
      public BehaviorComponent Owner
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return new BehaviorComponent(InternalUnsafeMethods.BehaviorInstanceGetOwner(ObjectPtr->ObjPtr));
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.BehaviorInstanceSetOwner(ObjectPtr->ObjPtr, value.ObjectPtr->ObjPtr);
         }
      }
      
      #endregion
      
      #region Methods

      public string GetTemplateName()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.BehaviorInstanceGetTemplateName(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}