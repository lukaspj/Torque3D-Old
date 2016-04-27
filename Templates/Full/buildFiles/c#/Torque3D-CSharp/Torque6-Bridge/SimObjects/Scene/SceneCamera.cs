using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class SceneCamera : SimObject
   {
      
      public SceneCamera()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.SceneCameraCreateInstance());
      }

      public SceneCamera(uint pId) : base(pId)
      {
      }

      public SceneCamera(string pName) : base(pName)
      {
      }

      public SceneCamera(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public SceneCamera(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public SceneCamera(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneCameraGetPosition(IntPtr camera, out Point3F position);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneCameraSetPosition(IntPtr camera, Point3F position);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float SceneCameraGetHorizontalAngle(IntPtr camera);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneCameraSetHorizontalAngle(IntPtr camera, float angle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float SceneCameraGetVerticalAngle(IntPtr camera);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneCameraSetVerticalAngle(IntPtr camera, float angle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SceneCameraCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneCameraLookAt(IntPtr camera, Point3F look_at);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneCameraTranslate(IntPtr camera, Point3F translation);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneCameraPan(IntPtr camera, Point3F pan);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneCameraSetPanVelocity(IntPtr camera, Point3F panVel);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneCameraRotate(IntPtr camera, Point3F rotation);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SceneCameraBindMouse(IntPtr camera, bool value, bool left, bool right);
      }
      
      #endregion

      #region Properties

      public Point3F Position
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point3F outVal;
            InternalUnsafeMethods.SceneCameraGetPosition(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SceneCameraSetPosition(ObjectPtr->ObjPtr, value);
         }
      }
      public float HorizontalAngle
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.SceneCameraGetHorizontalAngle(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SceneCameraSetHorizontalAngle(ObjectPtr->ObjPtr, value);
         }
      }
      public float VerticalAngle
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.SceneCameraGetVerticalAngle(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SceneCameraSetVerticalAngle(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void LookAt(Point3F look_at)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SceneCameraLookAt(ObjectPtr->ObjPtr, look_at);
      }

      public void Translate(Point3F translation)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SceneCameraTranslate(ObjectPtr->ObjPtr, translation);
      }

      public void Pan(Point3F pan)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SceneCameraPan(ObjectPtr->ObjPtr, pan);
      }

      public void SetPanVelocity(Point3F panVel)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SceneCameraSetPanVelocity(ObjectPtr->ObjPtr, panVel);
      }

      public void Rotate(Point3F rotation)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SceneCameraRotate(ObjectPtr->ObjPtr, rotation);
      }

      public void BindMouse(bool value, bool left = false, bool right = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SceneCameraBindMouse(ObjectPtr->ObjPtr, value, left, right);
      }
      
      #endregion

      
   }
}