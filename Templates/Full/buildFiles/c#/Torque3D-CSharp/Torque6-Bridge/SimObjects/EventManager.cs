using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class EventManager : SimObject
   {
      
      public EventManager()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.EventManagerCreateInstance());
      }

      public EventManager(uint pId) : base(pId)
      {
      }

      public EventManager(string pName) : base(pName)
      {
      }

      public EventManager(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public EventManager(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public EventManager(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string EventManagerGetQueue(IntPtr eventManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void EventManagerSetQueue(IntPtr eventManager, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr EventManagerCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool EventManagerRegisterEvent(IntPtr eventManager, string eventName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void EventManagerUnregisterEvent(IntPtr eventManager, string eventName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool EventManagerIsRegisteredEvent(IntPtr eventManager, string eventName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool EventManagerPostEvent(IntPtr eventManager, string eventName, string data);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool EventManagerSubscribe(IntPtr eventManager, IntPtr listener, string eventName, string callback);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void EventManagerRemove(IntPtr eventManager, IntPtr listener, string eventName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void EventManagerDumpEvents(IntPtr eventManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void EventManagerDumpSubscribers(IntPtr eventManager, string eventName);
      }
      
      #endregion

      #region Properties

      public string Queue
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.EventManagerGetQueue(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.EventManagerSetQueue(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public bool RegisterEvent(string eventName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.EventManagerRegisterEvent(ObjectPtr->ObjPtr, eventName);
      }

      public void UnregisterEvent(string eventName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.EventManagerUnregisterEvent(ObjectPtr->ObjPtr, eventName);
      }

      public bool IsRegisteredEvent(string eventName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.EventManagerIsRegisteredEvent(ObjectPtr->ObjPtr, eventName);
      }

      public bool PostEvent(string eventName, string data = null)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.EventManagerPostEvent(ObjectPtr->ObjPtr, eventName, data);
      }

      public bool Subscribe(SimObject listener, string eventName, string callback = null)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.EventManagerSubscribe(ObjectPtr->ObjPtr, listener.ObjectPtr->ObjPtr, eventName, callback);
      }

      public void Remove(SimObject listener, string eventName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.EventManagerRemove(ObjectPtr->ObjPtr, listener.ObjectPtr->ObjPtr, eventName);
      }

      public void DumpEvents()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.EventManagerDumpEvents(ObjectPtr->ObjPtr);
      }

      public void DumpSubscribers(string eventName = null)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.EventManagerDumpSubscribers(ObjectPtr->ObjPtr, eventName);
      }
      
      #endregion

      
   }
}