using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class SimSet : SimObject
   {
      
      public SimSet()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.SimSetCreateInstance());
      }

      public SimSet(uint pId) : base(pId)
      {
      }

      public SimSet(string pName) : base(pName)
      {
      }

      public SimSet(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public SimSet(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public SimSet(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SimSetCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimSetListObjects(IntPtr set);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimSetAdd(IntPtr set, IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimSetRemove(IntPtr set, IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimSetDeleteObjects(IntPtr set);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimSetClear(IntPtr set);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimSetCallOnChildren(IntPtr set, string method, int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimSetReorderChild(IntPtr set, IntPtr obj1, IntPtr obj2);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SimSetGetCount(IntPtr set);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SimSetGetObject(IntPtr set, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimSetIsMember(IntPtr set, IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SimSetFindObjectByInternalName(IntPtr set, string name, bool searchChildren);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimSetBringToFront(IntPtr set, IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimSetPushToBack(IntPtr set, IntPtr obj);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public void ListObjects()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimSetListObjects(ObjectPtr->ObjPtr);
      }

      public void Add(SimObject obj)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimSetAdd(ObjectPtr->ObjPtr, obj.ObjectPtr->ObjPtr);
      }

      public void Remove(SimObject obj)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimSetRemove(ObjectPtr->ObjPtr, obj.ObjectPtr->ObjPtr);
      }

      public void DeleteObjects()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimSetDeleteObjects(ObjectPtr->ObjPtr);
      }

      public void Clear()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimSetClear(ObjectPtr->ObjPtr);
      }

      public void CallOnChildren(string method, int argc, string[] argv)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimSetCallOnChildren(ObjectPtr->ObjPtr, method, argc, argv);
      }

      public void ReorderChild(SimObject obj1, SimObject obj2)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimSetReorderChild(ObjectPtr->ObjPtr, obj1.ObjectPtr->ObjPtr, obj2.ObjectPtr->ObjPtr);
      }

      public int GetCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimSetGetCount(ObjectPtr->ObjPtr);
      }

      public SimObject GetObject(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimObject(InternalUnsafeMethods.SimSetGetObject(ObjectPtr->ObjPtr, index));
      }

      public bool IsMember(SimObject obj)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimSetIsMember(ObjectPtr->ObjPtr, obj.ObjectPtr->ObjPtr);
      }

      public SimObject FindObjectByInternalName(string name, bool searchChildren = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimObject(InternalUnsafeMethods.SimSetFindObjectByInternalName(ObjectPtr->ObjPtr, name, searchChildren));
      }

      public void BringToFront(SimObject obj)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimSetBringToFront(ObjectPtr->ObjPtr, obj.ObjectPtr->ObjPtr);
      }

      public void PushToBack(SimObject obj)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.SimSetPushToBack(ObjectPtr->ObjPtr, obj.ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}