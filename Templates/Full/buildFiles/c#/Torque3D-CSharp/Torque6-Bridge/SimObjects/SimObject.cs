using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class SimObject
   {
      public SimObject()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.SimObjectCreateInstance());
      }

      public SimObject(uint pId)
      {
         ObjectPtr = Sim.FindObjectWrapperById(pId);
      }

      public SimObject(string pName)
      {
         ObjectPtr = Sim.FindObjectWrapperByName(pName);
      }

      public SimObject(IntPtr pObjPtr)
      {
         ObjectPtr = Sim.WrapObject(pObjPtr);
      }

      public SimObject(Sim.SimObjectPtr* pObjPtr)
      {
         ObjectPtr = pObjPtr;
      }

      public SimObject(SimObject pObj)
      {
         ObjectPtr = pObj.ObjectPtr;
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimObjectGetCanSaveDynamicFields(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectSetCanSaveDynamicFields(IntPtr obj, bool val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SimObjectGetInternalName(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectSetInternalName(IntPtr obj, string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SimObjectGetParentGroup(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectSetParentGroup(IntPtr obj, IntPtr parent);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SimObjectGetSuperClass(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectSetSuperClass(IntPtr obj, string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SimObjectGetClass(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectSetClass(IntPtr obj, string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SimObjectCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimObjectRegisterObject(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SimObjectGetName(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectSetName(IntPtr obj, string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern uint SimObjectGetID(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimObjectIsMethod(IntPtr obj, string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimObjectCall(IntPtr obj, int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectDumpClassHierarchy(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectDump(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimObjectIsMemberOfClass(IntPtr obj, string className);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SimObjectGetClassName(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SimObjectGetFieldValue(IntPtr obj, string fieldName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectSetFieldValue(IntPtr obj, string fieldName, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SimObjectGetDynamicFieldCount(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SimObjectGetDynamicField(IntPtr obj, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SimObjectGetFieldCount(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SimObjectGetField(IntPtr obj, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SimObjectGetProgenitorFile(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectSetProgenitorFile(IntPtr obj, string file);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SimObjectGetType(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SimObjectGetFieldType(IntPtr obj, string fieldName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimObjectIsChildOfGroup(IntPtr obj, IntPtr group);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SimObjectGetGroup(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectDelete(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SimObjectClone(IntPtr obj, bool copyDynamicFields);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimObjectStartTimer(IntPtr obj, string callbackFunction, float timePeriod, int repeat);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectStopTimer(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimObjectIsTimerActive(IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SimObjectSchedule(IntPtr obj, int time, int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimObjectSave(IntPtr obj, string filename, bool selectedOnly);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectAddFieldFilter(IntPtr obj, string fieldName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimObjectRemoveFieldFilter(IntPtr obj, string fieldName);
      }
      
      #endregion

      #region Properties

      public bool CanSaveDynamicFields
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.SimObjectGetCanSaveDynamicFields(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SimObjectSetCanSaveDynamicFields(ObjectPtr->ObjPtr, value);
         }
      }
      public string InternalName
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.SimObjectGetInternalName(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SimObjectSetInternalName(ObjectPtr->ObjPtr, value);
         }
      }
      public SimGroup ParentGroup
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return new SimGroup(InternalUnsafeMethods.SimObjectGetParentGroup(ObjectPtr->ObjPtr));
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SimObjectSetParentGroup(ObjectPtr->ObjPtr, value.ObjectPtr->ObjPtr);
         }
      }
      public string Superclass
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.SimObjectGetSuperClass(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SimObjectSetSuperClass(ObjectPtr->ObjPtr, value);
         }
      }
      public string Class
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.SimObjectGetClass(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SimObjectSetClass(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public bool RegisterObject()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectRegisterObject(ObjectPtr->ObjPtr);
      }

      public string GetName()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetName(ObjectPtr->ObjPtr);
      }

      public void SetName(string val)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimObjectSetName(ObjectPtr->ObjPtr, val);
      }

      public uint GetID()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetID(ObjectPtr->ObjPtr);
      }

      public bool IsMethod(string val)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectIsMethod(ObjectPtr->ObjPtr, val);
      }

      public bool Call(int argc, string[] argv)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectCall(ObjectPtr->ObjPtr, argc, argv);
      }

      public void DumpClassHierarchy()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimObjectDumpClassHierarchy(ObjectPtr->ObjPtr);
      }

      public void Dump()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimObjectDump(ObjectPtr->ObjPtr);
      }

      public bool IsMemberOfClass(string className)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectIsMemberOfClass(ObjectPtr->ObjPtr, className);
      }

      public string GetClassName()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetClassName(ObjectPtr->ObjPtr);
      }

      public string GetFieldValue(string fieldName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetFieldValue(ObjectPtr->ObjPtr, fieldName);
      }

      public void SetFieldValue(string fieldName, string value)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimObjectSetFieldValue(ObjectPtr->ObjPtr, fieldName, value);
      }

      public int GetDynamicFieldCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetDynamicFieldCount(ObjectPtr->ObjPtr);
      }

      public string GetDynamicField(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetDynamicField(ObjectPtr->ObjPtr, index);
      }

      public int GetFieldCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetFieldCount(ObjectPtr->ObjPtr);
      }

      public string GetField(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetField(ObjectPtr->ObjPtr, index);
      }

      public string GetProgenitorFile()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetProgenitorFile(ObjectPtr->ObjPtr);
      }

      public void SetProgenitorFile(string file)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimObjectSetProgenitorFile(ObjectPtr->ObjPtr, file);
      }

      public int GetType()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetType(ObjectPtr->ObjPtr);
      }

      public string GetFieldType(string fieldName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectGetFieldType(ObjectPtr->ObjPtr, fieldName);
      }

      public bool IsChildOfGroup(SimGroup group)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectIsChildOfGroup(ObjectPtr->ObjPtr, group.ObjectPtr->ObjPtr);
      }

      public SimGroup GetGroup()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimGroup(InternalUnsafeMethods.SimObjectGetGroup(ObjectPtr->ObjPtr));
      }

      public void Delete()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimObjectDelete(ObjectPtr->ObjPtr);
      }

      public SimObject Clone(bool copyDynamicFields = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimObject(InternalUnsafeMethods.SimObjectClone(ObjectPtr->ObjPtr, copyDynamicFields));
      }

      public bool StartTimer(string callbackFunction, float timePeriod, int repeat = 0)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectStartTimer(ObjectPtr->ObjPtr, callbackFunction, timePeriod, repeat);
      }

      public void StopTimer()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimObjectStopTimer(ObjectPtr->ObjPtr);
      }

      public bool IsTimerActive()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectIsTimerActive(ObjectPtr->ObjPtr);
      }

      public int Schedule(int time, int argc, string[] argv)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectSchedule(ObjectPtr->ObjPtr, time, argc, argv);
      }

      public bool Save(string filename, bool selectedOnly = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimObjectSave(ObjectPtr->ObjPtr, filename, selectedOnly);
      }

      public void AddFieldFilter(string fieldName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimObjectAddFieldFilter(ObjectPtr->ObjPtr, fieldName);
      }

      public void RemoveFieldFilter(string fieldName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimObjectRemoveFieldFilter(ObjectPtr->ObjPtr, fieldName);
      }
      
      #endregion

      #region SimObject specifics

      public T As<T>() where T : new()
      {
         return (T)Activator.CreateInstance(typeof (T), this);
      }

      public Sim.SimObjectPtr* ObjectPtr { get; protected set; }

      public bool IsDead()
      {
         return ObjectPtr->ObjPtr == IntPtr.Zero;
      }

      #region IDisposable

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      protected virtual void Dispose(bool pDisposing)
      {
         //if (ObjectPtr->ObjPtr != IntPtr.Zero)
         //{
            //Marshal.FreeHGlobal((IntPtr) ObjectPtr);
         //}
      }

      ~SimObject()
      {
         Dispose(false);
      }

      #endregion

            #endregion
   }
}