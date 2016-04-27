using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiTreeViewCtrl : GuiArrayCtrl
   {
      
      public GuiTreeViewCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiTreeViewCtrlCreateInstance());
      }

      public GuiTreeViewCtrl(uint pId) : base(pId)
      {
      }

      public GuiTreeViewCtrl(string pName) : base(pName)
      {
      }

      public GuiTreeViewCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTreeViewCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTreeViewCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetTabSize(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlSetTabSize(IntPtr ctrl, int size);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetTextOffset(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlSetTextOffset(IntPtr ctrl, int offset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlGetFullRowSelect(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlSetFullRowSelect(IntPtr ctrl, bool fullRowSelect);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetItemHeight(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlSetItemHeight(IntPtr ctrl, int height);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlGetDestroyTreeOnSleep(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlSetDestroyTreeOnSleep(IntPtr ctrl, bool destroyOnSleep);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlGetMouseDragging(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlSetMouseDragging(IntPtr ctrl, bool allowDragging);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlGetMultipleSelections(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlSetMultipleSelections(IntPtr ctrl, bool multipleSelections);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlGetDeleteObjectAllowed(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlSetDeleteObjectAllowed(IntPtr ctrl, bool allowDelete);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlGetDragToItemAllowed(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlSetDragToItemAllowed(IntPtr ctrl, bool allowDrag);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiTreeViewCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlFindItemByName(IntPtr ctrl, string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlInsertItem(IntPtr ctrl, int parent, string name, string value, string icon, int norm, int expand);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlLockSelection(IntPtr ctrl, bool locked);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlClearSelection(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlDeleteSelection(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlAddSelection(IntPtr ctrl, int ID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlAddChildSelectionByValue(IntPtr ctrl, int parent, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlRemoveSelection(IntPtr ctrl, int ID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlRemoveChildSelectionByValue(IntPtr ctrl, int parent, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlSelectItem(IntPtr ctrl, int item, bool select);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlExpandItem(IntPtr ctrl, int item, bool expand);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlScrollVisible(IntPtr ctrl, int item);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlBuildIconTable(IntPtr ctrl, string icons);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlOpen(IntPtr ctrl, IntPtr target, bool okToEdit);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTreeViewCtrlGetItemText(IntPtr ctrl, int item);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTreeViewCtrlGetItemValue(IntPtr ctrl, int item);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlEditItem(IntPtr ctrl, int item, string newText, string newValue);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTreeViewCtrlRemoveItem(IntPtr ctrl, int item);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlRemoveAllChildren(IntPtr ctrl, int parent);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlClear(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetFirstRootItem(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetChild(IntPtr ctrl, int item);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlBuildVisibleTree(IntPtr ctrl, bool forceFullUpdate);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetParent(IntPtr ctrl, int item);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetNextSibling(IntPtr ctrl, int item);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetPrevSibling(IntPtr ctrl, int item);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetItemCount(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetSelectedItem(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiTreeViewCtrlGetSelectedObject(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlMoveItemUp(IntPtr ctrl, int item);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTreeViewCtrlMoveItemDown(IntPtr ctrl, int item);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlGetSelectedItemsCount(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTreeViewCtrlGetTextToRoot(IntPtr ctrl, int item, string delimiter);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTreeViewCtrlGetSelectedItemList(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlFindItemByObject(IntPtr ctrl, IntPtr obj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTreeViewCtrlScrollVisibleByObject(IntPtr ctrl, IntPtr obj);
      }
      
      #endregion

      #region Properties

      public int TabSize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTreeViewCtrlGetTabSize(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTreeViewCtrlSetTabSize(ObjectPtr->ObjPtr, value);
         }
      }
      public int TextOffset
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTreeViewCtrlGetTextOffset(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTreeViewCtrlSetTextOffset(ObjectPtr->ObjPtr, value);
         }
      }
      public bool FullRowSelect
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTreeViewCtrlGetFullRowSelect(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTreeViewCtrlSetFullRowSelect(ObjectPtr->ObjPtr, value);
         }
      }
      public int ItemHeight
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTreeViewCtrlGetItemHeight(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTreeViewCtrlSetItemHeight(ObjectPtr->ObjPtr, value);
         }
      }
      public bool DestroyTreeOnSleep
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTreeViewCtrlGetDestroyTreeOnSleep(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTreeViewCtrlSetDestroyTreeOnSleep(ObjectPtr->ObjPtr, value);
         }
      }
      public bool MouseDragging
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTreeViewCtrlGetMouseDragging(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTreeViewCtrlSetMouseDragging(ObjectPtr->ObjPtr, value);
         }
      }
      public bool MultipleSelections
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTreeViewCtrlGetMultipleSelections(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTreeViewCtrlSetMultipleSelections(ObjectPtr->ObjPtr, value);
         }
      }
      public bool DeleteObjectAllowed
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTreeViewCtrlGetDeleteObjectAllowed(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTreeViewCtrlSetDeleteObjectAllowed(ObjectPtr->ObjPtr, value);
         }
      }
      public bool DragToItemAllowed
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTreeViewCtrlGetDragToItemAllowed(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTreeViewCtrlSetDragToItemAllowed(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public int FindItemByName(string name)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlFindItemByName(ObjectPtr->ObjPtr, name);
      }

      public int InsertItem(int parent, string name, string value, string icon, int norm, int expand)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlInsertItem(ObjectPtr->ObjPtr, parent, name, value, icon, norm, expand);
      }

      public void LockSelection(bool locked)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlLockSelection(ObjectPtr->ObjPtr, locked);
      }

      public void ClearSelection()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlClearSelection(ObjectPtr->ObjPtr);
      }

      public void DeleteSelection()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlDeleteSelection(ObjectPtr->ObjPtr);
      }

      public void AddSelection(int ID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlAddSelection(ObjectPtr->ObjPtr, ID);
      }

      public void AddChildSelectionByValue(int parent, string value)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlAddChildSelectionByValue(ObjectPtr->ObjPtr, parent, value);
      }

      public void RemoveSelection(int ID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlRemoveSelection(ObjectPtr->ObjPtr, ID);
      }

      public void RemoveChildSelectionByValue(int parent, string value)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlRemoveChildSelectionByValue(ObjectPtr->ObjPtr, parent, value);
      }

      public bool SelectItem(int item, bool select)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlSelectItem(ObjectPtr->ObjPtr, item, select);
      }

      public bool ExpandItem(int item, bool expand)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlExpandItem(ObjectPtr->ObjPtr, item, expand);
      }

      public void ScrollVisible(int item)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlScrollVisible(ObjectPtr->ObjPtr, item);
      }

      public bool BuildIconTable(string icons)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlBuildIconTable(ObjectPtr->ObjPtr, icons);
      }

      public bool Open(SimSet target, bool okToEdit)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlOpen(ObjectPtr->ObjPtr, target.ObjectPtr->ObjPtr, okToEdit);
      }

      public string GetItemText(int item)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetItemText(ObjectPtr->ObjPtr, item);
      }

      public string GetItemValue(int item)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetItemValue(ObjectPtr->ObjPtr, item);
      }

      public bool EditItem(int item, string newText, string newValue)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlEditItem(ObjectPtr->ObjPtr, item, newText, newValue);
      }

      public bool RemoveItem(int item)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlRemoveItem(ObjectPtr->ObjPtr, item);
      }

      public void RemoveAllChildren(int parent)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlRemoveAllChildren(ObjectPtr->ObjPtr, parent);
      }

      public void Clear()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlClear(ObjectPtr->ObjPtr);
      }

      public int GetFirstRootItem()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetFirstRootItem(ObjectPtr->ObjPtr);
      }

      public int GetChild(int item)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetChild(ObjectPtr->ObjPtr, item);
      }

      public void BuildVisibleTree(bool forceFullUpdate)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlBuildVisibleTree(ObjectPtr->ObjPtr, forceFullUpdate);
      }

      public int GetParent(int item)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetParent(ObjectPtr->ObjPtr, item);
      }

      public int GetNextSibling(int item)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetNextSibling(ObjectPtr->ObjPtr, item);
      }

      public int GetPrevSibling(int item)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetPrevSibling(ObjectPtr->ObjPtr, item);
      }

      public int GetItemCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetItemCount(ObjectPtr->ObjPtr);
      }

      public int GetSelectedItem()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetSelectedItem(ObjectPtr->ObjPtr);
      }

      public SimObject GetSelectedObject()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimObject(InternalUnsafeMethods.GuiTreeViewCtrlGetSelectedObject(ObjectPtr->ObjPtr));
      }

      public void MoveItemUp(int item)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlMoveItemUp(ObjectPtr->ObjPtr, item);
      }

      public void MoveItemDown(int item)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTreeViewCtrlMoveItemDown(ObjectPtr->ObjPtr, item);
      }

      public int GetSelectedItemsCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetSelectedItemsCount(ObjectPtr->ObjPtr);
      }

      public string GetTextToRoot(int item, string delimiter)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetTextToRoot(ObjectPtr->ObjPtr, item, delimiter);
      }

      public string GetSelectedItemList()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlGetSelectedItemList(ObjectPtr->ObjPtr);
      }

      public int FindItemByObject(SimObject obj)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlFindItemByObject(ObjectPtr->ObjPtr, obj.ObjectPtr->ObjPtr);
      }

      public int ScrollVisibleByObject(SimObject obj)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTreeViewCtrlScrollVisibleByObject(ObjectPtr->ObjPtr, obj.ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}