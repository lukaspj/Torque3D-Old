using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiSeparatorCtrl : GuiControl
   {
      
      public GuiSeparatorCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiSeparatorCtrlCreateInstance());
      }

      public GuiSeparatorCtrl(uint pId) : base(pId)
      {
      }

      public GuiSeparatorCtrl(string pName) : base(pName)
      {
      }

      public GuiSeparatorCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiSeparatorCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiSeparatorCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiSeparatorCtrlGetCaption(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSeparatorCtrlSetCaption(IntPtr ctrl, string caption);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiSeparatorCtrlGetType(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSeparatorCtrlSetType(IntPtr ctrl, int type);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiSeparatorCtrlGetBorderMargin(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSeparatorCtrlSetBorderMargin(IntPtr ctrl, int margin);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiSeparatorCtrlGetInvisible(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSeparatorCtrlSetInvisible(IntPtr ctrl, bool invisible);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiSeparatorCtrlGetLeftMargin(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSeparatorCtrlSetLeftMargin(IntPtr ctrl, int leftMargin);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiSeparatorCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public string Caption
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSeparatorCtrlGetCaption(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSeparatorCtrlSetCaption(ObjectPtr->ObjPtr, value);
         }
      }
      public int Type
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSeparatorCtrlGetType(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSeparatorCtrlSetType(ObjectPtr->ObjPtr, value);
         }
      }
      public int BorderMargin
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSeparatorCtrlGetBorderMargin(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSeparatorCtrlSetBorderMargin(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Invisible
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSeparatorCtrlGetInvisible(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSeparatorCtrlSetInvisible(ObjectPtr->ObjPtr, value);
         }
      }
      public int LeftMargin
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSeparatorCtrlGetLeftMargin(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSeparatorCtrlSetLeftMargin(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}