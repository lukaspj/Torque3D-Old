using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiFormCtrl : GuiControl
   {
      
      public GuiFormCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiFormCtrlCreateInstance());
      }

      public GuiFormCtrl(uint pId) : base(pId)
      {
      }

      public GuiFormCtrl(string pName) : base(pName)
      {
      }

      public GuiFormCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiFormCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiFormCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiFormCtrlGetCaption(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFormCtrlSetCaption(IntPtr ctrl, string caption);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiFormCtrlGetContentLibrary(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFormCtrlSetContentLibrary(IntPtr ctrl, string contentLibrary);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiFormCtrlGetContent(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFormCtrlSetContent(IntPtr ctrl, string content);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiFormCtrlGetMovable(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFormCtrlSetMovable(IntPtr ctrl, bool movable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiFormCtrlGetHasMenu(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiFormCtrlSetHasMenu(IntPtr ctrl, bool hasMenu);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiFormCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiFormCtrlGetMenuID(IntPtr ctrl);
      }
      
      #endregion

      #region Properties

      public string Caption
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiFormCtrlGetCaption(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFormCtrlSetCaption(ObjectPtr->ObjPtr, value);
         }
      }
      public string ContentLibrary
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiFormCtrlGetContentLibrary(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFormCtrlSetContentLibrary(ObjectPtr->ObjPtr, value);
         }
      }
      public string Content
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiFormCtrlGetContent(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFormCtrlSetContent(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Movable
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiFormCtrlGetMovable(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFormCtrlSetMovable(ObjectPtr->ObjPtr, value);
         }
      }
      public bool HasMenu
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiFormCtrlGetHasMenu(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiFormCtrlSetHasMenu(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public int GetMenuID()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiFormCtrlGetMenuID(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}