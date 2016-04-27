using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class ActionMap : SimObject
   {
      
      public ActionMap()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.ActionMapCreateInstance());
      }

      public ActionMap(uint pId) : base(pId)
      {
      }

      public ActionMap(string pName) : base(pName)
      {
      }

      public ActionMap(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public ActionMap(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public ActionMap(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ActionMapCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ActionMapBind(IntPtr map, int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ActionMapBindObj(IntPtr map, int argc, string[] argv, IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ActionMapBindCmd(IntPtr map, string device, string action, string makeCmd, string breakCmd);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ActionMapUnbind(IntPtr map, string device, string action);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ActionMapUnbindObj(IntPtr map, string device, string action, IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ActionMapSave(IntPtr map, string fileName, bool append);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ActionMapPush(IntPtr map);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ActionMapPop(IntPtr map);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ActionMapGetBinding(IntPtr map, string command);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ActionMapGetCommand(IntPtr map, string device, string action);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ActionMapIsInverted(IntPtr map, string device, string action);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float ActionMapGetScale(IntPtr map, string device, string action);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ActionMapGetDeadZone(IntPtr map, string device, string action);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public void Bind(int argc, string[] argv)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ActionMapBind(ObjectPtr->ObjPtr, argc, argv);
      }

      public void BindObj(int argc, string[] argv, SimObject obj)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ActionMapBindObj(ObjectPtr->ObjPtr, argc, argv, obj.ObjectPtr->ObjPtr);
      }

      public void BindCmd(string device, string action, string makeCmd, string breakCmd)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ActionMapBindCmd(ObjectPtr->ObjPtr, device, action, makeCmd, breakCmd);
      }

      public void Unbind(string device, string action)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ActionMapUnbind(ObjectPtr->ObjPtr, device, action);
      }

      public void UnbindObj(string device, string action, SimObject obj)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ActionMapUnbindObj(ObjectPtr->ObjPtr, device, action, obj.ObjectPtr->ObjPtr);
      }

      public void Save(string fileName = null, bool append = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ActionMapSave(ObjectPtr->ObjPtr, fileName, append);
      }

      public void Push()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ActionMapPush(ObjectPtr->ObjPtr);
      }

      public void Pop()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ActionMapPop(ObjectPtr->ObjPtr);
      }

      public string GetBinding(string command)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ActionMapGetBinding(ObjectPtr->ObjPtr, command);
      }

      public string GetCommand(string device, string action)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ActionMapGetCommand(ObjectPtr->ObjPtr, device, action);
      }

      public bool IsInverted(string device, string action)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ActionMapIsInverted(ObjectPtr->ObjPtr, device, action);
      }

      public float GetScale(string device, string action)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ActionMapGetScale(ObjectPtr->ObjPtr, device, action);
      }

      public string GetDeadZone(string device, string action)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ActionMapGetDeadZone(ObjectPtr->ObjPtr, device, action);
      }
      
      #endregion

      
   }
}