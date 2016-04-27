using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiTextCtrl : GuiControl
   {
      
      public GuiTextCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiTextCtrlCreateInstance());
      }

      public GuiTextCtrl(uint pId) : base(pId)
      {
      }

      public GuiTextCtrl(string pName) : base(pName)
      {
      }

      public GuiTextCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTextCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTextCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTextCtrlGetText(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextCtrlSetText(IntPtr ctrl, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTextCtrlGetTextID(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextCtrlSetTextID(IntPtr ctrl, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTextCtrlGetMaxLength(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextCtrlSetMaxLength(IntPtr ctrl, int length);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTextCtrlGetTruncate(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextCtrlSetTruncate(IntPtr ctrl, bool truncate);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiTextCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public string Text
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextCtrlGetText(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextCtrlSetText(ObjectPtr->ObjPtr, value);
         }
      }
      public string TextID
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextCtrlGetTextID(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextCtrlSetTextID(ObjectPtr->ObjPtr, value);
         }
      }
      public int MaxLength
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextCtrlGetMaxLength(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextCtrlSetMaxLength(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Truncate
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextCtrlGetTruncate(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextCtrlSetTruncate(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}