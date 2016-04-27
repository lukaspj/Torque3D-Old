using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiEditCtrl : GuiControl
   {
      
      public GuiEditCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiEditCtrlCreateInstance());
      }

      public GuiEditCtrl(uint pId) : base(pId)
      {
      }

      public GuiEditCtrl(string pName) : base(pName)
      {
      }

      public GuiEditCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiEditCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiEditCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiEditCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlSetRoot(IntPtr ctrl, IntPtr root);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlAddNewCtrl(IntPtr ctrl, IntPtr root);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlAddSelection(IntPtr ctrl, int ctrlID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlRemoveSelection(IntPtr ctrl, int ctrlID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlClearSelection(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlSelect(IntPtr ctrl, IntPtr selCtrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlSetCurrentAddSet(IntPtr ctrl, IntPtr selCtrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiEditCtrlGetCurrentAddSet(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlToggle(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlJustify(IntPtr ctrl, int mode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlBringToFront(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlPushToBack(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlDeleteSelection(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlMoveSelection(IntPtr ctrl, int deltaX, int deltaY);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlSaveSelection(IntPtr ctrl, string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlLoadSelection(IntPtr ctrl, string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlSelectAll(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiEditCtrlGetSelected(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiEditCtrlGetTrash(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiEditCtrlGetUndoManager(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiEditCtrlSetSnapToGrid(IntPtr ctrl, uint gridSize);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public void SetRoot(GuiControl root)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlSetRoot(ObjectPtr->ObjPtr, root.ObjectPtr->ObjPtr);
      }

      public void AddNewCtrl(GuiControl root)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlAddNewCtrl(ObjectPtr->ObjPtr, root.ObjectPtr->ObjPtr);
      }

      public void AddSelection(int ctrlID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlAddSelection(ObjectPtr->ObjPtr, ctrlID);
      }

      public void RemoveSelection(int ctrlID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlRemoveSelection(ObjectPtr->ObjPtr, ctrlID);
      }

      public void ClearSelection()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlClearSelection(ObjectPtr->ObjPtr);
      }

      public void Select(GuiControl  selCtrl)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlSelect(ObjectPtr->ObjPtr, selCtrl.ObjectPtr->ObjPtr);
      }

      public void SetCurrentAddSet(GuiControl  selCtrl)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlSetCurrentAddSet(ObjectPtr->ObjPtr, selCtrl.ObjectPtr->ObjPtr);
      }

      public GuiControl GetCurrentAddSet()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new GuiControl(InternalUnsafeMethods.GuiEditCtrlGetCurrentAddSet(ObjectPtr->ObjPtr));
      }

      public void Toggle()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlToggle(ObjectPtr->ObjPtr);
      }

      public void Justify(int mode)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlJustify(ObjectPtr->ObjPtr, mode);
      }

      public void BringToFront()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlBringToFront(ObjectPtr->ObjPtr);
      }

      public void PushToBack()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlPushToBack(ObjectPtr->ObjPtr);
      }

      public void DeleteSelection()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlDeleteSelection(ObjectPtr->ObjPtr);
      }

      public void MoveSelection(int deltaX, int deltaY)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlMoveSelection(ObjectPtr->ObjPtr, deltaX, deltaY);
      }

      public void SaveSelection(string fileName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlSaveSelection(ObjectPtr->ObjPtr, fileName);
      }

      public void LoadSelection(string fileName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlLoadSelection(ObjectPtr->ObjPtr, fileName);
      }

      public void SelectAll()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlSelectAll(ObjectPtr->ObjPtr);
      }

      public SimSet GetSelected()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimSet(InternalUnsafeMethods.GuiEditCtrlGetSelected(ObjectPtr->ObjPtr));
      }

      public SimGroup GetTrash()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimGroup(InternalUnsafeMethods.GuiEditCtrlGetTrash(ObjectPtr->ObjPtr));
      }

      public UndoManager GetUndoManager()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new UndoManager(InternalUnsafeMethods.GuiEditCtrlGetUndoManager(ObjectPtr->ObjPtr));
      }

      public void SetSnapToGrid(uint gridSize)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiEditCtrlSetSnapToGrid(ObjectPtr->ObjPtr, gridSize);
      }
      
      #endregion

      
   }
}