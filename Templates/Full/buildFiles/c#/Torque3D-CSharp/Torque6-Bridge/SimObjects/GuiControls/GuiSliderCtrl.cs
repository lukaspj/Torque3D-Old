using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiSliderCtrl : GuiControl
   {
      
      public GuiSliderCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiSliderCtrlCreateInstance());
      }

      public GuiSliderCtrl(uint pId) : base(pId)
      {
      }

      public GuiSliderCtrl(string pName) : base(pName)
      {
      }

      public GuiSliderCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiSliderCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiSliderCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSliderCtrlGetRange(IntPtr ctrl, out Point2F outRange);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSliderCtrlSetRange(IntPtr ctrl, Point2F range);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiSliderCtrlGetTicks(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSliderCtrlSetTicks(IntPtr ctrl, int ticks);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float GuiSliderCtrlGetValue(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSliderCtrlSetValue(IntPtr ctrl, float value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiSliderCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public Point2F Range
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2F outVal;
            InternalUnsafeMethods.GuiSliderCtrlGetRange(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSliderCtrlSetRange(ObjectPtr->ObjPtr, value);
         }
      }
      public int Ticks
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSliderCtrlGetTicks(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSliderCtrlSetTicks(ObjectPtr->ObjPtr, value);
         }
      }
      public float Value
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSliderCtrlGetValue(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSliderCtrlSetValue(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}