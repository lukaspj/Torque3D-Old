using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class UndoManager : SimObject
   {
      
      public UndoManager()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.UndoManagerCreateInstance());
      }

      public UndoManager(uint pId) : base(pId)
      {
      }

      public UndoManager(string pName) : base(pName)
      {
      }

      public UndoManager(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public UndoManager(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public UndoManager(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int UndoManagerGetNumLevels(IntPtr undoAction);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void UndoManagerSetNumLevels(IntPtr undoAction, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr UndoManagerCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int UndoManagerGetRedoCount(IntPtr undoManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void UndoManagerClearAll(IntPtr undoManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int UndoManagerGetUndoCount(IntPtr undoManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string UndoManagerGetUndoName(IntPtr undoManager, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string UndoManagerGetRedoName(IntPtr undoManager, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void UndoManagerUndo(IntPtr undoManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void UndoManagerRedo(IntPtr undoManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string UndoManagerGetNextUndoName(IntPtr undoManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string UndoManagerGetNextRedoName(IntPtr undoManager);
      }
      
      #endregion

      #region Properties

      public int NumLevels
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.UndoManagerGetNumLevels(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.UndoManagerSetNumLevels(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public int GetRedoCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.UndoManagerGetRedoCount(ObjectPtr->ObjPtr);
      }

      public void ClearAll()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.UndoManagerClearAll(ObjectPtr->ObjPtr);
      }

      public int GetUndoCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.UndoManagerGetUndoCount(ObjectPtr->ObjPtr);
      }

      public string GetUndoName(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.UndoManagerGetUndoName(ObjectPtr->ObjPtr, index);
      }

      public string GetRedoName(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.UndoManagerGetRedoName(ObjectPtr->ObjPtr, index);
      }

      public void Undo()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.UndoManagerUndo(ObjectPtr->ObjPtr);
      }

      public void Redo()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.UndoManagerRedo(ObjectPtr->ObjPtr);
      }

      public string GetNextUndoName()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.UndoManagerGetNextUndoName(ObjectPtr->ObjPtr);
      }

      public string GetNextRedoName()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.UndoManagerGetNextRedoName(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}