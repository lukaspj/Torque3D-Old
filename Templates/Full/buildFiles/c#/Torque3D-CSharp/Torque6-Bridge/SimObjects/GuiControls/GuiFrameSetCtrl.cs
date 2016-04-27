using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiFrameSetCtrl : GuiControl
   {
      
      public GuiFrameSetCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiFrameSetCtrlCreateInstance());
      }

      public GuiFrameSetCtrl(uint pId) : base(pId)
      {
      }

      public GuiFrameSetCtrl(string pName) : base(pName)
      {
      }

      public GuiFrameSetCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiFrameSetCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiFrameSetCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiFrameSetCtrlGetBorderWidth(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlSetBorderWidth(IntPtr ctrl, int width);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlGetBorderColor(IntPtr ctrl, out Color outCol);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlSetBorderColor(IntPtr ctrl, Color color);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiFrameSetCtrlGetBorderEnable(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlSetBorderEnable(IntPtr ctrl, int enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiFrameSetCtrlGetBorderMovable(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlSetBorderMovable(IntPtr ctrl, int movable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiFrameSetCtrlGetAutoBalance(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlSetAutoBalance(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiFrameSetCtrlGetFudgeFactor(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlSetFudgeFactor(IntPtr ctrl, int fudgeFactor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiFrameSetCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlFrameBorder(IntPtr ctrl, int index, string state);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlFrameMovable(IntPtr ctrl, int index, string state);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlFrameMinExtent(IntPtr ctrl, int index, int width, int height);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlAddColumn(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlAddRow(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlRemoveColumn(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlRemoveRow(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiFrameSetCtrlGetColumnCount(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiFrameSetCtrlGetRowCount(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiFrameSetCtrlGetColumnOffset(IntPtr ctrl, int column);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiFrameSetCtrlGetRowOffset(IntPtr ctrl, int row);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlSetColumnOffset(IntPtr ctrl, int column, int offset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFrameSetCtrlSetRowOffset(IntPtr ctrl, int row, int offset);
      }
      
      #endregion

      #region Properties

      public int BorderWidth
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiFrameSetCtrlGetBorderWidth(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFrameSetCtrlSetBorderWidth(ObjectPtr->ObjPtr, value);
         }
      }
      public Color BorderColor
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiFrameSetCtrlGetBorderColor(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFrameSetCtrlSetBorderColor(ObjectPtr->ObjPtr, value);
         }
      }
      public int BorderEnable
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiFrameSetCtrlGetBorderEnable(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFrameSetCtrlSetBorderEnable(ObjectPtr->ObjPtr, value);
         }
      }
      public int BorderMovable
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiFrameSetCtrlGetBorderMovable(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFrameSetCtrlSetBorderMovable(ObjectPtr->ObjPtr, value);
         }
      }
      public bool AutoBalance
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiFrameSetCtrlGetAutoBalance(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFrameSetCtrlSetAutoBalance(ObjectPtr->ObjPtr, value);
         }
      }
      public int FudgeFactor
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiFrameSetCtrlGetFudgeFactor(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFrameSetCtrlSetFudgeFactor(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void FrameBorder(int index, string state)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiFrameSetCtrlFrameBorder(ObjectPtr->ObjPtr, index, state);
      }

      public void FrameMovable(int index, string state)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiFrameSetCtrlFrameMovable(ObjectPtr->ObjPtr, index, state);
      }

      public void FrameMinExtent(int index, int width, int height)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiFrameSetCtrlFrameMinExtent(ObjectPtr->ObjPtr, index, width, height);
      }

      public void AddColumn()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiFrameSetCtrlAddColumn(ObjectPtr->ObjPtr);
      }

      public void AddRow()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiFrameSetCtrlAddRow(ObjectPtr->ObjPtr);
      }

      public void RemoveColumn()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiFrameSetCtrlRemoveColumn(ObjectPtr->ObjPtr);
      }

      public void RemoveRow()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiFrameSetCtrlRemoveRow(ObjectPtr->ObjPtr);
      }

      public int GetColumnCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiFrameSetCtrlGetColumnCount(ObjectPtr->ObjPtr);
      }

      public int GetRowCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiFrameSetCtrlGetRowCount(ObjectPtr->ObjPtr);
      }

      public int GetColumnOffset(int column)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiFrameSetCtrlGetColumnOffset(ObjectPtr->ObjPtr, column);
      }

      public int GetRowOffset(int row)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiFrameSetCtrlGetRowOffset(ObjectPtr->ObjPtr, row);
      }

      public void SetColumnOffset(int column, int offset)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiFrameSetCtrlSetColumnOffset(ObjectPtr->ObjPtr, column, offset);
      }

      public void SetRowOffset(int row, int offset)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiFrameSetCtrlSetRowOffset(ObjectPtr->ObjPtr, row, offset);
      }
      
      #endregion

      
   }
}