using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiCurveCtrl : GuiControl
   {
      
      public GuiCurveCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiCurveCtrlCreateInstance());
      }

      public GuiCurveCtrl(uint pId) : base(pId)
      {
      }

      public GuiCurveCtrl(string pName) : base(pName)
      {
      }

      public GuiCurveCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiCurveCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiCurveCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlGetStart(IntPtr ctrl, out Point2I outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlSetStart(IntPtr ctrl, Point2I pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlGetEnd(IntPtr ctrl, out Point2I outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlSetEnd(IntPtr ctrl, Point2I pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlGetControlA(IntPtr ctrl, out Point2I outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlSetControlA(IntPtr ctrl, Point2I pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlGetControlB(IntPtr ctrl, out Point2I outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlSetControlB(IntPtr ctrl, Point2I pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlGetColor(IntPtr ctrl, out Color outCol);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlSetColor(IntPtr ctrl, Color color);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float GuiCurveCtrlGetThickness(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiCurveCtrlSetThickness(IntPtr ctrl, float thickness);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiCurveCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public Point2I Start
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.GuiCurveCtrlGetStart(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiCurveCtrlSetStart(ObjectPtr->ObjPtr, value);
         }
      }
      public Point2I End
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.GuiCurveCtrlGetEnd(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiCurveCtrlSetEnd(ObjectPtr->ObjPtr, value);
         }
      }
      public Point2I ControlA
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.GuiCurveCtrlGetControlA(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiCurveCtrlSetControlA(ObjectPtr->ObjPtr, value);
         }
      }
      public Point2I ControlB
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.GuiCurveCtrlGetControlB(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiCurveCtrlSetControlB(ObjectPtr->ObjPtr, value);
         }
      }
      public Color Color
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiCurveCtrlGetColor(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiCurveCtrlSetColor(ObjectPtr->ObjPtr, value);
         }
      }
      public float Thickness
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiCurveCtrlGetThickness(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiCurveCtrlSetThickness(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}