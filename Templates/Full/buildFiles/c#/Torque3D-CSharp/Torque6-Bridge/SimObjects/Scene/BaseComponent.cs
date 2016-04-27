using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class BaseComponent : SimObject
   {
      
      public BaseComponent()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.BaseComponentCreateInstance());
      }

      public BaseComponent(uint pId) : base(pId)
      {
      }

      public BaseComponent(string pName) : base(pName)
      {
      }

      public BaseComponent(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public BaseComponent(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public BaseComponent(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BaseComponentGetPosition(IntPtr baseComponent, out Point3F outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BaseComponentSetPosition(IntPtr baseComponent, Point3F pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BaseComponentGetRotation(IntPtr baseComponent, out Point3F outRotation);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BaseComponentSetRotation(IntPtr baseComponent, Point3F rotation);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BaseComponentGetScale(IntPtr baseComponent, out Point3F outScale);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BaseComponentSetScale(IntPtr baseComponent, Point3F scale);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr BaseComponentCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void BaseComponentSetUniformVec4(IntPtr baseComponent, string name, Point4F value);
      }
      
      #endregion

      #region Properties

      public Point3F Position
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point3F outVal;
            InternalUnsafeMethods.BaseComponentGetPosition(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.BaseComponentSetPosition(ObjectPtr->ObjPtr, value);
         }
      }
      public Point3F Rotation
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point3F outVal;
            InternalUnsafeMethods.BaseComponentGetRotation(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.BaseComponentSetRotation(ObjectPtr->ObjPtr, value);
         }
      }
      public Point3F Scale
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point3F outVal;
            InternalUnsafeMethods.BaseComponentGetScale(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.BaseComponentSetScale(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void SetUniformVec4(string name, Point4F value)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.BaseComponentSetUniformVec4(ObjectPtr->ObjPtr, name, value);
      }
      
      #endregion

      
   }
}