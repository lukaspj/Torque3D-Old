using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiWindowCtrl : GuiTextCtrl
   {
      
      public GuiWindowCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiWindowCtrlCreateInstance());
      }

      public GuiWindowCtrl(uint pId) : base(pId)
      {
      }

      public GuiWindowCtrl(string pName) : base(pName)
      {
      }

      public GuiWindowCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiWindowCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiWindowCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiWindowCtrlGetResizeWidth(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiWindowCtrlSetResizeWidth(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiWindowCtrlGetResizeHeight(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiWindowCtrlSetResizeHeight(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiWindowCtrlGetCanMove(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiWindowCtrlSetCanMove(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiWindowCtrlGetCanClose(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiWindowCtrlSetCanClose(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiWindowCtrlGetCanMinimize(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiWindowCtrlSetCanMinimize(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiWindowCtrlGetCanMaximize(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiWindowCtrlSetCanMaximize(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiWindowCtrlGetMinSize(IntPtr ctrl, out Point2I outSize);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiWindowCtrlSetMinSize(IntPtr ctrl, Point2I size);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiWindowCtrlGetCloseCommand(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiWindowCtrlSetCloseCommand(IntPtr ctrl, string command);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiWindowCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public bool ResizeWidth
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiWindowCtrlGetResizeWidth(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiWindowCtrlSetResizeWidth(ObjectPtr->ObjPtr, value);
         }
      }
      public bool ResizeHeight
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiWindowCtrlGetResizeHeight(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiWindowCtrlSetResizeHeight(ObjectPtr->ObjPtr, value);
         }
      }
      public bool CanMove
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiWindowCtrlGetCanMove(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiWindowCtrlSetCanMove(ObjectPtr->ObjPtr, value);
         }
      }
      public bool CanClose
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiWindowCtrlGetCanClose(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiWindowCtrlSetCanClose(ObjectPtr->ObjPtr, value);
         }
      }
      public bool CanMinimize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiWindowCtrlGetCanMinimize(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiWindowCtrlSetCanMinimize(ObjectPtr->ObjPtr, value);
         }
      }
      public bool CanMaximize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiWindowCtrlGetCanMaximize(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiWindowCtrlSetCanMaximize(ObjectPtr->ObjPtr, value);
         }
      }
      public Point2I MinSize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.GuiWindowCtrlGetMinSize(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiWindowCtrlSetMinSize(ObjectPtr->ObjPtr, value);
         }
      }
      public string CloseCommand
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiWindowCtrlGetCloseCommand(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiWindowCtrlSetCloseCommand(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}