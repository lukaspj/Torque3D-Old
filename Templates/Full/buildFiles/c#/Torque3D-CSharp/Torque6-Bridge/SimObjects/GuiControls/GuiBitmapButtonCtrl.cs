using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiBitmapButtonCtrl : GuiButtonCtrl
   {
      
      public GuiBitmapButtonCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiBitmapButtonCtrlCreateInstance());
      }

      public GuiBitmapButtonCtrl(uint pId) : base(pId)
      {
      }

      public GuiBitmapButtonCtrl(string pName) : base(pName)
      {
      }

      public GuiBitmapButtonCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiBitmapButtonCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiBitmapButtonCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiBitmapButtonCtrlGetIsLegacyVersion(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapButtonCtrlSetIsLegacyVersion(IntPtr ctrl, bool isLegacy);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiBitmapButtonCtrlGetBitmap(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapButtonCtrlSetBitmap(IntPtr ctrl, string bitmap);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiBitmapButtonCtrlGetBitmapNormal(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapButtonCtrlSetBitmapNormal(IntPtr ctrl, string bitmap);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiBitmapButtonCtrlGetBitmapHilight(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapButtonCtrlSetBitmapHilight(IntPtr ctrl, string bitmap);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiBitmapButtonCtrlGetBitmapDepressed(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapButtonCtrlSetBitmapDepressed(IntPtr ctrl, string bitmap);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiBitmapButtonCtrlGetBitmapInactive(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiBitmapButtonCtrlSetBitmapInactive(IntPtr ctrl, string bitmap);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiBitmapButtonCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public bool IsLegacyVersion
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiBitmapButtonCtrlGetIsLegacyVersion(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiBitmapButtonCtrlSetIsLegacyVersion(ObjectPtr->ObjPtr, value);
         }
      }
      public string Bitmap
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiBitmapButtonCtrlGetBitmap(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiBitmapButtonCtrlSetBitmap(ObjectPtr->ObjPtr, value);
         }
      }
      public string BitmapNormal
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiBitmapButtonCtrlGetBitmapNormal(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiBitmapButtonCtrlSetBitmapNormal(ObjectPtr->ObjPtr, value);
         }
      }
      public string BitmapHilight
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiBitmapButtonCtrlGetBitmapHilight(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiBitmapButtonCtrlSetBitmapHilight(ObjectPtr->ObjPtr, value);
         }
      }
      public string BitmapDepressed
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiBitmapButtonCtrlGetBitmapDepressed(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiBitmapButtonCtrlSetBitmapDepressed(ObjectPtr->ObjPtr, value);
         }
      }
      public string BitmapInactive
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiBitmapButtonCtrlGetBitmapInactive(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiBitmapButtonCtrlSetBitmapInactive(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}