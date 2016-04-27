using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiSpriteCtrl : GuiControl
   {
      
      public GuiSpriteCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiSpriteCtrlCreateInstance());
      }

      public GuiSpriteCtrl(uint pId) : base(pId)
      {
      }

      public GuiSpriteCtrl(string pName) : base(pName)
      {
      }

      public GuiSpriteCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiSpriteCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiSpriteCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiSpriteCtrlGetImage(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSpriteCtrlSetImage(IntPtr ctrl, string imageAssetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiSpriteCtrlGetFrame(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSpriteCtrlSetFrame(IntPtr ctrl, int frame);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiSpriteCtrlGetNamedFrame(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSpriteCtrlSetNamedFrame(IntPtr ctrl, string frame);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiSpriteCtrlGetAnimation(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiSpriteCtrlSetAnimation(IntPtr ctrl, string animationAssetid);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiSpriteCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiSpriteCtrlIsStaticFrameProvider(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiSpriteCtrlIsUsingNamedImageFrame(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiSpriteCtrlSetImageFrame(IntPtr ctrl, int imageFrame);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiSpriteCtrlGetImageFrame(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiSpriteCtrlSetNamedImageFrame(IntPtr ctrl, string frame);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiSpriteCtrlGetNamedImageFrame(IntPtr ctrl);
      }
      
      #endregion

      #region Properties

      public string Image
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSpriteCtrlGetImage(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSpriteCtrlSetImage(ObjectPtr->ObjPtr, value);
         }
      }
      public int Frame
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSpriteCtrlGetFrame(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSpriteCtrlSetFrame(ObjectPtr->ObjPtr, value);
         }
      }
      public string NamedFrame
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSpriteCtrlGetNamedFrame(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSpriteCtrlSetNamedFrame(ObjectPtr->ObjPtr, value);
         }
      }
      public string Animation
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiSpriteCtrlGetAnimation(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiSpriteCtrlSetAnimation(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public bool IsStaticFrameProvider()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiSpriteCtrlIsStaticFrameProvider(ObjectPtr->ObjPtr);
      }

      public bool IsUsingNamedImageFrame()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiSpriteCtrlIsUsingNamedImageFrame(ObjectPtr->ObjPtr);
      }

      public bool SetImageFrame(int imageFrame)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiSpriteCtrlSetImageFrame(ObjectPtr->ObjPtr, imageFrame);
      }

      public int GetImageFrame()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiSpriteCtrlGetImageFrame(ObjectPtr->ObjPtr);
      }

      public bool SetNamedImageFrame(string frame)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiSpriteCtrlSetNamedImageFrame(ObjectPtr->ObjPtr, frame);
      }

      public string GetNamedImageFrame()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiSpriteCtrlGetNamedImageFrame(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}