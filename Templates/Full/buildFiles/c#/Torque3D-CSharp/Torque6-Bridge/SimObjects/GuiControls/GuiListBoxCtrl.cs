using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiListBoxCtrl : GuiControl
   {
      
      public GuiListBoxCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiListBoxCtrlCreateInstance());
      }

      public GuiListBoxCtrl(uint pId) : base(pId)
      {
      }

      public GuiListBoxCtrl(string pName) : base(pName)
      {
      }

      public GuiListBoxCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiListBoxCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiListBoxCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiListBoxCtrlGetAllowMultipleSelections(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlSetAllowMultipleSelections(IntPtr ctrl, bool allow);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiListBoxCtrlGetFitParentWidth(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlSetFitParentWidth(IntPtr ctrl, bool fit);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiListBoxCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlSetMultipleSelection(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlClearItems(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlClearSelection(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlSetSelected(IntPtr ctrl, int index, bool setting);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiListBoxCtrlGetItemCount(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiListBoxCtrlGetSelCount(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiListBoxCtrlGetSelectedItem(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int[] GuiListBoxCtrlGetSelectedItems(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiListBoxCtrlFindItemText(IntPtr ctrl, string itemText, bool caseSensitive);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlSetCurSel(IntPtr ctrl, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlSetCurSelRange(IntPtr ctrl, int start, int stop);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlAddItem(IntPtr ctrl, string text, Color color);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlSetItemColor(IntPtr ctrl, int index, Color color);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlClearItemColor(IntPtr ctrl, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlInsertItem(IntPtr ctrl, string text, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlDeleteItem(IntPtr ctrl, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiListBoxCtrlSetItemtext(IntPtr ctrl, int index, string newText);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiListBoxCtrlGetItemtext(IntPtr ctrl, int index);
      }
      
      #endregion

      #region Properties

      public bool AllowMultipleSelections
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiListBoxCtrlGetAllowMultipleSelections(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiListBoxCtrlSetAllowMultipleSelections(ObjectPtr->ObjPtr, value);
         }
      }
      public bool FitParentWidth
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiListBoxCtrlGetFitParentWidth(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiListBoxCtrlSetFitParentWidth(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void SetMultipleSelection(bool enable)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlSetMultipleSelection(ObjectPtr->ObjPtr, enable);
      }

      public void ClearItems()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlClearItems(ObjectPtr->ObjPtr);
      }

      public void ClearSelection()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlClearSelection(ObjectPtr->ObjPtr);
      }

      public void SetSelected(int index, bool setting)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlSetSelected(ObjectPtr->ObjPtr, index, setting);
      }

      public int GetItemCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiListBoxCtrlGetItemCount(ObjectPtr->ObjPtr);
      }

      public int GetSelCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiListBoxCtrlGetSelCount(ObjectPtr->ObjPtr);
      }

      public int GetSelectedItem()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiListBoxCtrlGetSelectedItem(ObjectPtr->ObjPtr);
      }

      public int[] GetSelectedItems()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiListBoxCtrlGetSelectedItems(ObjectPtr->ObjPtr);
      }

      public int FindItemText(string itemText, bool caseSensitive)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiListBoxCtrlFindItemText(ObjectPtr->ObjPtr, itemText, caseSensitive);
      }

      public void SetCurSel(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlSetCurSel(ObjectPtr->ObjPtr, index);
      }

      public void SetCurSelRange(int start, int stop)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlSetCurSelRange(ObjectPtr->ObjPtr, start, stop);
      }

      public void AddItem(string text, Color color)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlAddItem(ObjectPtr->ObjPtr, text, color);
      }

      public void SetItemColor(int index, Color color)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlSetItemColor(ObjectPtr->ObjPtr, index, color);
      }

      public void ClearItemColor(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlClearItemColor(ObjectPtr->ObjPtr, index);
      }

      public void InsertItem(string text, int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlInsertItem(ObjectPtr->ObjPtr, text, index);
      }

      public void DeleteItem(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlDeleteItem(ObjectPtr->ObjPtr, index);
      }

      public void SetItemtext(int index, string newText)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiListBoxCtrlSetItemtext(ObjectPtr->ObjPtr, index, newText);
      }

      public string GetItemtext(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiListBoxCtrlGetItemtext(ObjectPtr->ObjPtr, index);
      }
      
      #endregion

      
   }
}