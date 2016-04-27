using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiAutoScrollCtrl : GuiTickCtrl
   {
      
      public GuiAutoScrollCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiAutoScrollCtrlCreateInstance());
      }

      public GuiAutoScrollCtrl(uint pId) : base(pId)
      {
      }

      public GuiAutoScrollCtrl(string pName) : base(pName)
      {
      }

      public GuiAutoScrollCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiAutoScrollCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiAutoScrollCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float GuiAutoScrollCtrlGetStartDelay(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiAutoScrollCtrlSetStartDelay(IntPtr ctrl, float delay);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float GuiAutoScrollCtrlGetResetDelay(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiAutoScrollCtrlSetResetDelay(IntPtr ctrl, float delay);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiAutoScrollCtrlGetChildBorder(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiAutoScrollCtrlSetChildBorder(IntPtr ctrl, int border);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float GuiAutoScrollCtrlGetScrollSpeed(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiAutoScrollCtrlSetScrollSpeed(IntPtr ctrl, float speed);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiAutoScrollCtrlGetTickCallback(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiAutoScrollCtrlSetTickCallback(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiAutoScrollCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public float StartDelay
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiAutoScrollCtrlGetStartDelay(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiAutoScrollCtrlSetStartDelay(ObjectPtr->ObjPtr, value);
         }
      }
      public float ResetDelay
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiAutoScrollCtrlGetResetDelay(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiAutoScrollCtrlSetResetDelay(ObjectPtr->ObjPtr, value);
         }
      }
      public int ChildBorder
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiAutoScrollCtrlGetChildBorder(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiAutoScrollCtrlSetChildBorder(ObjectPtr->ObjPtr, value);
         }
      }
      public float ScrollSpeed
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiAutoScrollCtrlGetScrollSpeed(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiAutoScrollCtrlSetScrollSpeed(ObjectPtr->ObjPtr, value);
         }
      }
      public bool TickCallback
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiAutoScrollCtrlGetTickCallback(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiAutoScrollCtrlSetTickCallback(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}