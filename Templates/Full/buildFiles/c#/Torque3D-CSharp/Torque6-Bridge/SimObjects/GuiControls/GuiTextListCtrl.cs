using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiTextListCtrl : GuiArrayCtrl
   {
      
      public GuiTextListCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiTextListCtrlCreateInstance());
      }

      public GuiTextListCtrl(uint pId) : base(pId)
      {
      }

      public GuiTextListCtrl(string pName) : base(pName)
      {
      }

      public GuiTextListCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTextListCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTextListCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTextListCtrlGetEnumerate(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlSetEnumerate(IntPtr ctrl, bool enumerate);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTextListCtrlGetResizeCell(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlSetResizeCell(IntPtr ctrl, bool resize);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTextListCtrlGetFitParentWidth(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlSetFitParentWidth(IntPtr ctrl, bool fitParentWidth);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTextListCtrlGetClipColumnText(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlSetClipColumnText(IntPtr ctrl, bool clip);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiTextListCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern uint GuiTextListCtrlGetSelectedId(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlSetSelectedById(IntPtr ctrl, uint ID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlSetSelectedRow(IntPtr ctrl, uint rowNum);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern uint GuiTextListCtrlGetSelectedRow(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlClearSelection(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTextListCtrlAddRow(IntPtr ctrl, uint ID, string text, int row);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlSetRowById(IntPtr ctrl, uint ID, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlSort(IntPtr ctrl, uint columnID, bool ascending);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlSortNumerical(IntPtr ctrl, uint columnID, bool ascending);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlClear(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern uint GuiTextListCtrlRowCount(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern uint GuiTextListCtrlGetRowId(IntPtr ctrl, uint row);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTextListCtrlGetRowTextById(IntPtr ctrl, uint ID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTextListCtrlGetRowNumById(IntPtr ctrl, uint ID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTextListCtrlGetRowText(IntPtr ctrl, uint row);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlRemoveRowById(IntPtr ctrl, uint ID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlRemoveRow(IntPtr ctrl, int row);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlScrollVisible(IntPtr ctrl, uint row);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTextListCtrlFindTextIndex(IntPtr ctrl, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextListCtrlSetRowActive(IntPtr ctrl, uint row, bool active);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTextListCtrlIsRowActive(IntPtr ctrl, uint row);
      }
      
      #endregion

      #region Properties

      public bool Enumerate
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextListCtrlGetEnumerate(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextListCtrlSetEnumerate(ObjectPtr->ObjPtr, value);
         }
      }
      public bool ResizeCell
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextListCtrlGetResizeCell(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextListCtrlSetResizeCell(ObjectPtr->ObjPtr, value);
         }
      }
      public bool FitParentWidth
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextListCtrlGetFitParentWidth(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextListCtrlSetFitParentWidth(ObjectPtr->ObjPtr, value);
         }
      }
      public bool ClipColumnText
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextListCtrlGetClipColumnText(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextListCtrlSetClipColumnText(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public uint GetSelectedId()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextListCtrlGetSelectedId(ObjectPtr->ObjPtr);
      }

      public void SetSelectedById(uint ID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlSetSelectedById(ObjectPtr->ObjPtr, ID);
      }

      public void SetSelectedRow(uint rowNum)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlSetSelectedRow(ObjectPtr->ObjPtr, rowNum);
      }

      public uint GetSelectedRow()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextListCtrlGetSelectedRow(ObjectPtr->ObjPtr);
      }

      public void ClearSelection()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlClearSelection(ObjectPtr->ObjPtr);
      }

      public int AddRow(uint ID, string text, int row)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextListCtrlAddRow(ObjectPtr->ObjPtr, ID, text, row);
      }

      public void SetRowById(uint ID, string text)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlSetRowById(ObjectPtr->ObjPtr, ID, text);
      }

      public void Sort(uint columnID, bool ascending)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlSort(ObjectPtr->ObjPtr, columnID, ascending);
      }

      public void SortNumerical(uint columnID, bool ascending)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlSortNumerical(ObjectPtr->ObjPtr, columnID, ascending);
      }

      public void Clear()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlClear(ObjectPtr->ObjPtr);
      }

      public uint RowCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextListCtrlRowCount(ObjectPtr->ObjPtr);
      }

      public uint GetRowId(uint row)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextListCtrlGetRowId(ObjectPtr->ObjPtr, row);
      }

      public string GetRowTextById(uint ID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextListCtrlGetRowTextById(ObjectPtr->ObjPtr, ID);
      }

      public int GetRowNumById(uint ID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextListCtrlGetRowNumById(ObjectPtr->ObjPtr, ID);
      }

      public string GetRowText(uint row)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextListCtrlGetRowText(ObjectPtr->ObjPtr, row);
      }

      public void RemoveRowById(uint ID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlRemoveRowById(ObjectPtr->ObjPtr, ID);
      }

      public void RemoveRow(int row)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlRemoveRow(ObjectPtr->ObjPtr, row);
      }

      public void ScrollVisible(uint row)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlScrollVisible(ObjectPtr->ObjPtr, row);
      }

      public int FindTextIndex(string text)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextListCtrlFindTextIndex(ObjectPtr->ObjPtr, text);
      }

      public void SetRowActive(uint row, bool active)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextListCtrlSetRowActive(ObjectPtr->ObjPtr, row, active);
      }

      public bool IsRowActive(uint row)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextListCtrlIsRowActive(ObjectPtr->ObjPtr, row);
      }
      
      #endregion

      
   }
}