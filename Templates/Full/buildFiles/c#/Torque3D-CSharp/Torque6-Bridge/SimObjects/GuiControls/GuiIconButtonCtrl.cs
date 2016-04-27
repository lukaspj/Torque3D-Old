using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiIconButtonCtrl : GuiButtonCtrl
   {
      
      public GuiIconButtonCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiIconButtonCtrlCreateInstance());
      }

      public GuiIconButtonCtrl(uint pId) : base(pId)
      {
      }

      public GuiIconButtonCtrl(string pName) : base(pName)
      {
      }

      public GuiIconButtonCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiIconButtonCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiIconButtonCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiIconButtonCtrlGetButtonMargin(IntPtr ctrl, out Point2I outMargin);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiIconButtonCtrlSetButtonMargin(IntPtr ctrl, Point2I margin);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiIconButtonCtrlGetIconBitmap(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiIconButtonCtrlSetIconBitmap(IntPtr ctrl, string bitmap);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiIconButtonCtrlGetIconLocation(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiIconButtonCtrlSetIconLocation(IntPtr ctrl, int location);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiIconButtonCtrlGetSizeIconToButton(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiIconButtonCtrlSetSizeIconToButton(IntPtr ctrl, bool sizeIconToButton);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiIconButtonCtrlGetTextLocation(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiIconButtonCtrlSetTextLocation(IntPtr ctrl, int location);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiIconButtonCtrlGetTextMargin(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiIconButtonCtrlSetTextMargin(IntPtr ctrl, int margin);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiIconButtonCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiIconButtonCtrlSetBitmap(IntPtr ctrl, string filePath);
      }
      
      #endregion

      #region Properties

      public Point2I ButtonMargin
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point2I outVal;
            InternalUnsafeMethods.GuiIconButtonCtrlGetButtonMargin(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiIconButtonCtrlSetButtonMargin(ObjectPtr->ObjPtr, value);
         }
      }
      public string IconBitmap
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiIconButtonCtrlGetIconBitmap(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiIconButtonCtrlSetIconBitmap(ObjectPtr->ObjPtr, value);
         }
      }
      public int IconLocation
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiIconButtonCtrlGetIconLocation(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiIconButtonCtrlSetIconLocation(ObjectPtr->ObjPtr, value);
         }
      }
      public bool SizeIconToButton
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiIconButtonCtrlGetSizeIconToButton(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiIconButtonCtrlSetSizeIconToButton(ObjectPtr->ObjPtr, value);
         }
      }
      public int TextLocation
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiIconButtonCtrlGetTextLocation(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiIconButtonCtrlSetTextLocation(ObjectPtr->ObjPtr, value);
         }
      }
      public int TextMargin
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiIconButtonCtrlGetTextMargin(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiIconButtonCtrlSetTextMargin(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void SetBitmap(string filePath)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiIconButtonCtrlSetBitmap(ObjectPtr->ObjPtr, filePath);
      }
      
      #endregion

      
   }
}