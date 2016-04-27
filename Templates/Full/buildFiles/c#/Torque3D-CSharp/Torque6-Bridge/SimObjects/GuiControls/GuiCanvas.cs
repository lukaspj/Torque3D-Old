using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiCanvas : GuiControl
   {
      
      public GuiCanvas()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiCanvasCreateInstance());
      }

      public GuiCanvas(uint pId) : base(pId)
      {
      }

      public GuiCanvas(string pName) : base(pName)
      {
      }

      public GuiCanvas(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiCanvas(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiCanvas(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiCanvasGetUseBackgroundColor(IntPtr canvas);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasSetUseBackgroundColor(IntPtr canvas, bool use);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasGetBackgroundColor(IntPtr canvas, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasSetBackgroundColor(IntPtr canvas, Color color);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiCanvasCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiCanvasGetContent(IntPtr canvas);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasSetContent(IntPtr canvas, IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasPushDialog(IntPtr canvas, IntPtr ctrl, int layer);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasPopDialog(IntPtr canvas, IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasPopLayer(IntPtr canvas, int layer);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasCursorOn(IntPtr canvas);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasCursorOff(IntPtr canvas);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasSetCursor(IntPtr canvas, IntPtr cursor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasRenderFront(IntPtr canvas, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasShowCursor(IntPtr canvas);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasHideCursor(IntPtr canvas);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiCanvasIsCursorOn(IntPtr canvas);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasSetDoubleClickDelay(IntPtr canvas, int delay);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasSetDoubleClickMoveBuffer(IntPtr canvas, int width, int height);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasRepaint(IntPtr canvas);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasReset(IntPtr canvas);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasGetCursorPos(IntPtr canvas, Point2I outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCanvasSetCursorPos(IntPtr canvas, Point2I pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiCanvasGetMouseControl(IntPtr canvas);
      }
      
      #endregion

      #region Properties

      public bool UseBackgroundColor
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiCanvasGetUseBackgroundColor(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiCanvasSetUseBackgroundColor(ObjectPtr->ObjPtr, value);
         }
      }
      public Color BackgroundColor
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiCanvasGetBackgroundColor(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiCanvasSetBackgroundColor(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public GuiControl GetContent()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new GuiControl(InternalUnsafeMethods.GuiCanvasGetContent(ObjectPtr->ObjPtr));
      }

      public void SetContent(GuiControl ctrl)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasSetContent(ObjectPtr->ObjPtr, ctrl.ObjectPtr->ObjPtr);
      }

      public void PushDialog(GuiControl ctrl, int layer)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasPushDialog(ObjectPtr->ObjPtr, ctrl.ObjectPtr->ObjPtr, layer);
      }

      public void PopDialog(GuiControl ctrl)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasPopDialog(ObjectPtr->ObjPtr, ctrl.ObjectPtr->ObjPtr);
      }

      public void PopLayer(int layer)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasPopLayer(ObjectPtr->ObjPtr, layer);
      }

      public void CursorOn()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasCursorOn(ObjectPtr->ObjPtr);
      }

      public void CursorOff()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasCursorOff(ObjectPtr->ObjPtr);
      }

      public void SetCursor(GuiCursor cursor)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasSetCursor(ObjectPtr->ObjPtr, cursor.ObjectPtr->ObjPtr);
      }

      public void RenderFront(bool enable)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasRenderFront(ObjectPtr->ObjPtr, enable);
      }

      public void ShowCursor()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasShowCursor(ObjectPtr->ObjPtr);
      }

      public void HideCursor()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasHideCursor(ObjectPtr->ObjPtr);
      }

      public bool IsCursorOn()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiCanvasIsCursorOn(ObjectPtr->ObjPtr);
      }

      public void SetDoubleClickDelay(int delay)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasSetDoubleClickDelay(ObjectPtr->ObjPtr, delay);
      }

      public void SetDoubleClickMoveBuffer(int width, int height)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasSetDoubleClickMoveBuffer(ObjectPtr->ObjPtr, width, height);
      }

      public void Repaint()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasRepaint(ObjectPtr->ObjPtr);
      }

      public void Reset()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasReset(ObjectPtr->ObjPtr);
      }

      public void GetCursorPos(Point2I outPos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasGetCursorPos(ObjectPtr->ObjPtr, outPos);
      }

      public void SetCursorPos(Point2I pos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiCanvasSetCursorPos(ObjectPtr->ObjPtr, pos);
      }

      public GuiControl GetMouseControl()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new GuiControl(InternalUnsafeMethods.GuiCanvasGetMouseControl(ObjectPtr->ObjPtr));
      }
      
      #endregion

      
   }
}