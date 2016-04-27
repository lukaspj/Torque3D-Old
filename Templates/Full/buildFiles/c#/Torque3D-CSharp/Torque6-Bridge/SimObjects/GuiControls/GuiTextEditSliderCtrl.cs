using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiTextEditSliderCtrl : GuiTextEditCtrl
   {
      
      public GuiTextEditSliderCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiTextEditSliderCtrlCreateInstance());
      }

      public GuiTextEditSliderCtrl(uint pId) : base(pId)
      {
      }

      public GuiTextEditSliderCtrl(string pName) : base(pName)
      {
      }

      public GuiTextEditSliderCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTextEditSliderCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTextEditSliderCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTextEditSliderCtrlGetFormat(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditSliderCtrlSetFormat(IntPtr ctrl, string format);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditSliderCtrlGetRange(IntPtr ctrl, out Point2F outRange);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditSliderCtrlSetRange(IntPtr ctrl, Point2F range);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float GuiTextEditSliderCtrlGetIncrement(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditSliderCtrlSetIncrement(IntPtr ctrl, float incrementAmount);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiTextEditSliderCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public string Format
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextEditSliderCtrlGetFormat(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditSliderCtrlSetFormat(ObjectPtr->ObjPtr, value);
         }
      }
      public Point2F Range
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2F outVal;
            InternalUnsafeMethods.GuiTextEditSliderCtrlGetRange(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditSliderCtrlSetRange(ObjectPtr->ObjPtr, value);
         }
      }
      public float Increment
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextEditSliderCtrlGetIncrement(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditSliderCtrlSetIncrement(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}