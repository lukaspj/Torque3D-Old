using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiBitmapCtrl : GuiControl
   {
      
      public GuiBitmapCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiBitmapCtrlCreateInstance());
      }

      public GuiBitmapCtrl(uint pId) : base(pId)
      {
      }

      public GuiBitmapCtrl(string pName) : base(pName)
      {
      }

      public GuiBitmapCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiBitmapCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiBitmapCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiBitmapCtrlGetBitmap(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapCtrlSetBitmap(IntPtr ctrl, string bitmapFile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiBitmapCtrlGetWrap(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapCtrlSetWrap(IntPtr ctrl, bool wrap);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiBitmapCtrlGetUseSourceRect(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapCtrlSetUseSourceRect(IntPtr ctrl, bool use);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapCtrlGetSourceRect(IntPtr ctrl, out RectI outRect);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapCtrlSetSourceRect(IntPtr ctrl, RectI rect);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiBitmapCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapCtrlSetValue(IntPtr ctrl, int x, int y);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiBitmapCtrlGetTextureWidth(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiBitmapCtrlGetTextureHeight(IntPtr ctrl);
      }
      
      #endregion

      #region Properties

      public string Bitmap
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiBitmapCtrlGetBitmap(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiBitmapCtrlSetBitmap(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Wrap
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiBitmapCtrlGetWrap(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiBitmapCtrlSetWrap(ObjectPtr->ObjPtr, value);
         }
      }
      public bool UseSourceRect
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiBitmapCtrlGetUseSourceRect(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiBitmapCtrlSetUseSourceRect(ObjectPtr->ObjPtr, value);
         }
      }
      public RectI SourceRect
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            RectI outVal;
            InternalUnsafeMethods.GuiBitmapCtrlGetSourceRect(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiBitmapCtrlSetSourceRect(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void SetValue(int x, int y)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiBitmapCtrlSetValue(ObjectPtr->ObjPtr, x, y);
      }

      public int GetTextureWidth()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiBitmapCtrlGetTextureWidth(ObjectPtr->ObjPtr);
      }

      public int GetTextureHeight()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiBitmapCtrlGetTextureHeight(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}