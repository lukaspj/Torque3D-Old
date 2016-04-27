using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class PhysicsComponent : BaseComponent
   {
      
      public PhysicsComponent()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.PhysicsComponentCreateInstance());
      }

      public PhysicsComponent(uint pId) : base(pId)
      {
      }

      public PhysicsComponent(string pName) : base(pName)
      {
      }

      public PhysicsComponent(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public PhysicsComponent(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public PhysicsComponent(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string PhysicsComponentGetOnCollideFunction(IntPtr PhysicsComponent);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PhysicsComponentSetOnCollideFunction(IntPtr PhysicsComponent, string function);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string PhysicsComponentGetCollisionType(IntPtr PhysicsComponent);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PhysicsComponentSetCollisionType(IntPtr PhysicsComponent, string type);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool PhysicsComponentGetStatic(IntPtr PhysicsComponent);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PhysicsComponentSetStatic(IntPtr PhysicsComponent, bool isStatic);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr PhysicsComponentCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PhysicsComponentSetLinearVelocity(IntPtr PhysicsComponent, Point3F vel);
      }
      
      #endregion

      #region Properties

      public string OnCollideFunction
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.PhysicsComponentGetOnCollideFunction(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.PhysicsComponentSetOnCollideFunction(ObjectPtr->ObjPtr, value);
         }
      }
      public string CollisionType
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.PhysicsComponentGetCollisionType(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.PhysicsComponentSetCollisionType(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Static
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.PhysicsComponentGetStatic(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.PhysicsComponentSetStatic(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void SetLinearVelocity(Point3F vel)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.PhysicsComponentSetLinearVelocity(ObjectPtr->ObjPtr, vel);
      }
      
      #endregion

      
   }
}