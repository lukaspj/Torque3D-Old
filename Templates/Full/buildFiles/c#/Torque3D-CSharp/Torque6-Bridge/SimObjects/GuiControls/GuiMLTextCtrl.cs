using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiMLTextCtrl : GuiControl
   {
      
      public GuiMLTextCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiMLTextCtrlCreateInstance());
      }

      public GuiMLTextCtrl(uint pId) : base(pId)
      {
      }

      public GuiMLTextCtrl(string pName) : base(pName)
      {
      }

      public GuiMLTextCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMLTextCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMLTextCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiMLTextCtrlGetLineSpacing(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlSetLineSpacing(IntPtr ctrl, int spacing);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiMLTextCtrlGetAllowColorChars(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlSetAllowColorChars(IntPtr ctrl, bool allow);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiMLTextCtrlGetMaxChars(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlSetMaxChars(IntPtr ctrl, int count);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiMLTextCtrlGetDeniedSound(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlSetDeniedSound(IntPtr ctrl, IntPtr sound);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiMLTextCtrlGetText(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlSetText(IntPtr ctrl, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiMLTextCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlSetCurrentText(IntPtr ctrl, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiMLTextCtrlGetCurrentText(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlAddText(IntPtr ctrl, string text, bool reformat);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiMLTextCtrlSetCursorPosition(IntPtr ctrl, int newPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlScrollToTag(IntPtr ctrl, int tagID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlScrollToBottom(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlScrollToTop(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlForceReflow(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMLTextCtrlSetAlpha(IntPtr ctrl, float alpha);
      }
      
      #endregion

      #region Properties

      public int LineSpacing
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiMLTextCtrlGetLineSpacing(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMLTextCtrlSetLineSpacing(ObjectPtr->ObjPtr, value);
         }
      }
      public bool AllowColorChars
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiMLTextCtrlGetAllowColorChars(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMLTextCtrlSetAllowColorChars(ObjectPtr->ObjPtr, value);
         }
      }
      public int MaxChars
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiMLTextCtrlGetMaxChars(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMLTextCtrlSetMaxChars(ObjectPtr->ObjPtr, value);
         }
      }
      public AudioAsset DeniedSound
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return new AudioAsset(InternalUnsafeMethods.GuiMLTextCtrlGetDeniedSound(ObjectPtr->ObjPtr));
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMLTextCtrlSetDeniedSound(ObjectPtr->ObjPtr, value.ObjectPtr->ObjPtr);
         }
      }
      public string Text
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiMLTextCtrlGetText(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMLTextCtrlSetText(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void SetCurrentText(string text)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMLTextCtrlSetCurrentText(ObjectPtr->ObjPtr, text);
      }

      public string GetCurrentText()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiMLTextCtrlGetCurrentText(ObjectPtr->ObjPtr);
      }

      public void AddText(string text, bool reformat)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMLTextCtrlAddText(ObjectPtr->ObjPtr, text, reformat);
      }

      public bool SetCursorPosition(int newPos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiMLTextCtrlSetCursorPosition(ObjectPtr->ObjPtr, newPos);
      }

      public void ScrollToTag(int tagID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMLTextCtrlScrollToTag(ObjectPtr->ObjPtr, tagID);
      }

      public void ScrollToBottom()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMLTextCtrlScrollToBottom(ObjectPtr->ObjPtr);
      }

      public void ScrollToTop()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMLTextCtrlScrollToTop(ObjectPtr->ObjPtr);
      }

      public void ForceReflow()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMLTextCtrlForceReflow(ObjectPtr->ObjPtr);
      }

      public void SetAlpha(float alpha)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMLTextCtrlSetAlpha(ObjectPtr->ObjPtr, alpha);
      }
      
      #endregion

      
   }
}