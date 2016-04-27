using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiTextEditCtrl : GuiTextCtrl
   {
      
      public GuiTextEditCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiTextEditCtrlCreateInstance());
      }

      public GuiTextEditCtrl(uint pId) : base(pId)
      {
      }

      public GuiTextEditCtrl(string pName) : base(pName)
      {
      }

      public GuiTextEditCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTextEditCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiTextEditCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTextEditCtrlGetValidate(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlSetValidate(IntPtr ctrl, string validateCommand);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTextEditCtrlGetEscapeCommand(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlSetEscapeCommand(IntPtr ctrl, string EscapeCommand);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTextEditCtrlGetHistorySize(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlSetHistorySize(IntPtr ctrl, int size);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTextEditCtrlGetTabComplete(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlSetTabComplete(IntPtr ctrl, bool tabComplete);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiTextEditCtrlGetDeniedSound(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlSetDeniedSound(IntPtr ctrl, IntPtr sound);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTextEditCtrlGetSinkAllKeyEvents(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlSetSinkAllKeyEvents(IntPtr ctrl, bool sinkAllKeyEvents);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiTextEditCtrlGetPassword(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlSetPassword(IntPtr ctrl, bool isPasswordText);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTextEditCtrlGetPasswordMask(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlSetPasswordMask(IntPtr ctrl, string PasswordMaskCommand);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiTextEditCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiTextEditCtrlGetText(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiTextEditCtrlGetCursorPos(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlSetCursorPos(IntPtr ctrl, int newPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlSelectAllText(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiTextEditCtrlForceValidateText(IntPtr ctrl);
      }
      
      #endregion

      #region Properties

      public string Validate
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextEditCtrlGetValidate(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditCtrlSetValidate(ObjectPtr->ObjPtr, value);
         }
      }
      public string EscapeCommand
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextEditCtrlGetEscapeCommand(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditCtrlSetEscapeCommand(ObjectPtr->ObjPtr, value);
         }
      }
      public int HistorySize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextEditCtrlGetHistorySize(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditCtrlSetHistorySize(ObjectPtr->ObjPtr, value);
         }
      }
      public bool TabComplete
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextEditCtrlGetTabComplete(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditCtrlSetTabComplete(ObjectPtr->ObjPtr, value);
         }
      }
      public AudioAsset DeniedSound
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return new AudioAsset(InternalUnsafeMethods.GuiTextEditCtrlGetDeniedSound(ObjectPtr->ObjPtr));
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditCtrlSetDeniedSound(ObjectPtr->ObjPtr, value.ObjectPtr->ObjPtr);
         }
      }
      public bool SinkAllKeyEvents
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextEditCtrlGetSinkAllKeyEvents(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditCtrlSetSinkAllKeyEvents(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Password
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextEditCtrlGetPassword(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditCtrlSetPassword(ObjectPtr->ObjPtr, value);
         }
      }
      public string PasswordMask
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiTextEditCtrlGetPasswordMask(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiTextEditCtrlSetPasswordMask(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public string GetText()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextEditCtrlGetText(ObjectPtr->ObjPtr);
      }

      public int GetCursorPos()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiTextEditCtrlGetCursorPos(ObjectPtr->ObjPtr);
      }

      public void SetCursorPos(int newPos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextEditCtrlSetCursorPos(ObjectPtr->ObjPtr, newPos);
      }

      public void SelectAllText()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextEditCtrlSelectAllText(ObjectPtr->ObjPtr);
      }

      public void ForceValidateText()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiTextEditCtrlForceValidateText(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}