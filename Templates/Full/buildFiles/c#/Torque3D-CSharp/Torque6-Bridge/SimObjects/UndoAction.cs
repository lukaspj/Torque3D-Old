using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class UndoAction : SimObject
   {
      
      public UndoAction()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.UndoActionCreateInstance());
      }

      public UndoAction(uint pId) : base(pId)
      {
      }

      public UndoAction(string pName) : base(pName)
      {
      }

      public UndoAction(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public UndoAction(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public UndoAction(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string UndoActionGetActionName(IntPtr undoAction);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void UndoActionSetActionName(IntPtr undoAction, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr UndoActionCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void UndoActionAddToManager(IntPtr undoAction, IntPtr undoManager);
      }
      
      #endregion

      #region Properties

      public string ActionName
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.UndoActionGetActionName(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.UndoActionSetActionName(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void AddToManager(UndoManager undoManager = null)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.UndoActionAddToManager(ObjectPtr->ObjPtr, undoManager.ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}