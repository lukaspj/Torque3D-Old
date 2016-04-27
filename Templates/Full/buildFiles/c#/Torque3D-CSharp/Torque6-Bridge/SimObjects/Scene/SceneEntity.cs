using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class SceneEntity : NetObject
   {
      
      public SceneEntity()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.SceneEntityCreateInstance());
      }

      public SceneEntity(uint pId) : base(pId)
      {
      }

      public SceneEntity(string pName) : base(pName)
      {
      }

      public SceneEntity(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public SceneEntity(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public SceneEntity(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SceneEntityGetTemplate(IntPtr sceneEntity);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneEntitySetTemplate(IntPtr sceneEntity, string templatePath);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneEntityGetPosition(IntPtr sceneEntity, out Point3F outPoint);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneEntitySetPosition(IntPtr sceneEntity, Point3F position);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneEntityGetRotation(IntPtr sceneEntity, out Point3F outRotation);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneEntitySetRotation(IntPtr sceneEntity, Point3F rotation);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneEntityGetScale(IntPtr sceneEntity, out Point3F outScale);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneEntitySetScale(IntPtr sceneEntity, Point3F scale);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SceneEntityCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SceneEntityFindComponent(IntPtr sceneEntity, string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SceneEntityFindComponentByType(IntPtr sceneEntity, string name);
      }
      
      #endregion

      #region Properties

      public string Template
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.SceneEntityGetTemplate(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SceneEntitySetTemplate(ObjectPtr->ObjPtr, value);
         }
      }
      public Point3F Position
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point3F outVal;
            InternalUnsafeMethods.SceneEntityGetPosition(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SceneEntitySetPosition(ObjectPtr->ObjPtr, value);
         }
      }
      public Point3F Rotation
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point3F outVal;
            InternalUnsafeMethods.SceneEntityGetRotation(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SceneEntitySetRotation(ObjectPtr->ObjPtr, value);
         }
      }
      public Point3F Scale
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point3F outVal;
            InternalUnsafeMethods.SceneEntityGetScale(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SceneEntitySetScale(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public SimObject FindComponent(string name)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimObject(InternalUnsafeMethods.SceneEntityFindComponent(ObjectPtr->ObjPtr, name));
      }

      public SimObject FindComponentByType(string name)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimObject(InternalUnsafeMethods.SceneEntityFindComponentByType(ObjectPtr->ObjPtr, name));
      }
      
      #endregion

      
   }
}