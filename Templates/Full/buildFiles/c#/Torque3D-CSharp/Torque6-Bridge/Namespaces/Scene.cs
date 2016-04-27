using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.SimObjects.Scene;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Scene
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Scene_Clear();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Scene_Load();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Scene_Save();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Scene_Refresh();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Scene_AddEntity(IntPtr entity, string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Scene_RemoveEntity(IntPtr entity, string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr Scene_GetActiveCamera();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Scene_PushActiveCamera(string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Scene_PopActiveCamera();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr Scene_GetCamera(string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Scene_SetDirectionalLight(Point3F direction, Color color, Color ambient);
      }

      #endregion
      
      #region Functions

      public static void Clear()
      {
         InternalUnsafeMethods.Scene_Clear();
      }

      public static void Load()
      {
         InternalUnsafeMethods.Scene_Load();
      }

      public static void Save()
      {
         InternalUnsafeMethods.Scene_Save();
      }

      public static void Refresh()
      {
         InternalUnsafeMethods.Scene_Refresh();
      }

      public static void AddEntity(SceneEntity entity, string name)
      {
         InternalUnsafeMethods.Scene_AddEntity(entity.ObjectPtr->ObjPtr, name);
      }

      public static void RemoveEntity(SceneEntity entity, string name)
      {
         InternalUnsafeMethods.Scene_RemoveEntity(entity.ObjectPtr->ObjPtr, name);
      }

      public static SceneCamera GetActiveCamera()
      {
         return new SceneCamera(InternalUnsafeMethods.Scene_GetActiveCamera());
      }

      public static void PushActiveCamera(string name)
      {
         InternalUnsafeMethods.Scene_PushActiveCamera(name);
      }

      public static void PopActiveCamera()
      {
         InternalUnsafeMethods.Scene_PopActiveCamera();
      }

      public static SceneCamera GetCamera(string name)
      {
         return new SceneCamera(InternalUnsafeMethods.Scene_GetCamera(name));
      }

      public static void SetDirectionalLight(Point3F direction, Color color, Color ambient)
      {
         InternalUnsafeMethods.Scene_SetDirectionalLight(direction, color, ambient);
      }      

      #endregion
   }
}