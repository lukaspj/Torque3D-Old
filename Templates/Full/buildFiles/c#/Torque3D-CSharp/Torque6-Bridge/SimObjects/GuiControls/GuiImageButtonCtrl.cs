using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiImageButtonCtrl : GuiButtonCtrl
   {
      
      public GuiImageButtonCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiImageButtonCtrlCreateInstance());
      }

      public GuiImageButtonCtrl(uint pId) : base(pId)
      {
      }

      public GuiImageButtonCtrl(string pName) : base(pName)
      {
      }

      public GuiImageButtonCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiImageButtonCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiImageButtonCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiImageButtonCtrlGetNormalImage(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiImageButtonCtrlSetNormalImage(IntPtr ctrl, string imageAssetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiImageButtonCtrlGetHoverImage(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiImageButtonCtrlSetHoverImage(IntPtr ctrl, string imageAssetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiImageButtonCtrlGetDownImage(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiImageButtonCtrlSetDownImage(IntPtr ctrl, string imageAssetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiImageButtonCtrlGetInactiveImage(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiImageButtonCtrlSetInactiveImage(IntPtr ctrl, string imageAssetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiImageButtonCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiImageButtonCtrlSetActive(IntPtr ctrl, bool active);
      }
      
      #endregion

      #region Properties

      public string NormalImage
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiImageButtonCtrlGetNormalImage(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiImageButtonCtrlSetNormalImage(ObjectPtr->ObjPtr, value);
         }
      }
      public string HoverImage
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiImageButtonCtrlGetHoverImage(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiImageButtonCtrlSetHoverImage(ObjectPtr->ObjPtr, value);
         }
      }
      public string DownImage
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiImageButtonCtrlGetDownImage(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiImageButtonCtrlSetDownImage(ObjectPtr->ObjPtr, value);
         }
      }
      public string InactiveImage
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiImageButtonCtrlGetInactiveImage(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiImageButtonCtrlSetInactiveImage(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void SetActive(bool active)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiImageButtonCtrlSetActive(ObjectPtr->ObjPtr, active);
      }
      
      #endregion

      
   }
}