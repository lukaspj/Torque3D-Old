using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiScriptNotifyCtrl : GuiControl
   {
      
      public GuiScriptNotifyCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiScriptNotifyCtrlCreateInstance());
      }

      public GuiScriptNotifyCtrl(uint pId) : base(pId)
      {
      }

      public GuiScriptNotifyCtrl(string pName) : base(pName)
      {
      }

      public GuiScriptNotifyCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiScriptNotifyCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiScriptNotifyCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiScriptNotifyCtrlGetOnChildAdded(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiScriptNotifyCtrlSetOnChildAdded(IntPtr ctrl, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiScriptNotifyCtrlGetOnChildRemoved(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiScriptNotifyCtrlSetOnChildRemoved(IntPtr ctrl, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiScriptNotifyCtrlGetOnChildResized(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiScriptNotifyCtrlSetOnChildResized(IntPtr ctrl, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiScriptNotifyCtrlGetOnParentResized(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiScriptNotifyCtrlSetOnParentResized(IntPtr ctrl, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiScriptNotifyCtrlGetOnResize(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiScriptNotifyCtrlSetOnResize(IntPtr ctrl, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiScriptNotifyCtrlGetOnLoseFirstResponder(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiScriptNotifyCtrlSetOnLoseFirstResponder(IntPtr ctrl, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiScriptNotifyCtrlGetOnGainFirstResponder(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiScriptNotifyCtrlSetOnGainFirstResponder(IntPtr ctrl, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiScriptNotifyCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public bool OnChildAdded
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiScriptNotifyCtrlGetOnChildAdded(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiScriptNotifyCtrlSetOnChildAdded(ObjectPtr->ObjPtr, value);
         }
      }
      public bool OnChildRemoved
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiScriptNotifyCtrlGetOnChildRemoved(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiScriptNotifyCtrlSetOnChildRemoved(ObjectPtr->ObjPtr, value);
         }
      }
      public bool OnChildResized
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiScriptNotifyCtrlGetOnChildResized(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiScriptNotifyCtrlSetOnChildResized(ObjectPtr->ObjPtr, value);
         }
      }
      public bool OnParentResized
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiScriptNotifyCtrlGetOnParentResized(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiScriptNotifyCtrlSetOnParentResized(ObjectPtr->ObjPtr, value);
         }
      }
      public bool OnResize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiScriptNotifyCtrlGetOnResize(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiScriptNotifyCtrlSetOnResize(ObjectPtr->ObjPtr, value);
         }
      }
      public bool OnLoseFirstResponder
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiScriptNotifyCtrlGetOnLoseFirstResponder(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiScriptNotifyCtrlSetOnLoseFirstResponder(ObjectPtr->ObjPtr, value);
         }
      }
      public bool OnGainFirstResponder
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiScriptNotifyCtrlGetOnGainFirstResponder(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiScriptNotifyCtrlSetOnGainFirstResponder(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}