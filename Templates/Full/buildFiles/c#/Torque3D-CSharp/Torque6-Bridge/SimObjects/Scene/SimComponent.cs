using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class SimComponent : SimObject
   {
      
      public SimComponent()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.SimComponentCreateInstance());
      }

      public SimComponent(uint pId) : base(pId)
      {
      }

      public SimComponent(string pName) : base(pName)
      {
      }

      public SimComponent(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public SimComponent(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public SimComponent(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimComponentGetEnabled(IntPtr component);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SimComponentSetEnabled(IntPtr component, bool isEnabled);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SimComponentCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimComponentAddComponents(IntPtr component, int argc, IntPtr[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SimComponentRemoveComponents(IntPtr component, int argc, IntPtr[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SimComponentGetComponentCount(IntPtr component);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SimComponentGetComponent(IntPtr component, int index);
      }
      
      #endregion

      #region Properties

      public bool Enabled
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.SimComponentGetEnabled(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SimComponentSetEnabled(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public bool AddComponents(int argc, SimObject[] argv)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimComponentAddComponents(ObjectPtr->ObjPtr, argc, argv.Select(x => x.ObjectPtr->ObjPtr).ToArray());
      }

      public bool RemoveComponents(int argc, SimObject[] argv)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimComponentRemoveComponents(ObjectPtr->ObjPtr, argc, argv.Select(x => x.ObjectPtr->ObjPtr).ToArray());
      }

      public int GetComponentCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.SimComponentGetComponentCount(ObjectPtr->ObjPtr);
      }

      public SimComponent GetComponent(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimComponent(InternalUnsafeMethods.SimComponentGetComponent(ObjectPtr->ObjPtr, index));
      }
      
      #endregion

      
   }
}