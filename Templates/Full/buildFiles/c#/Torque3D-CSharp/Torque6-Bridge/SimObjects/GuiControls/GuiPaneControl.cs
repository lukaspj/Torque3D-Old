using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiPaneControl : GuiControl
   {
      
      public GuiPaneControl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiPaneControlCreateInstance());
      }

      public GuiPaneControl(uint pId) : base(pId)
      {
      }

      public GuiPaneControl(string pName) : base(pName)
      {
      }

      public GuiPaneControl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiPaneControl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiPaneControl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiPaneControlGetCaption(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPaneControlSetCaption(IntPtr ctrl, string caption);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiPaneControlGetCaptionID(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPaneControlSetCaptionID(IntPtr ctrl, string captionID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiPaneControlGetCollapsable(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPaneControlSetCollapsable(IntPtr ctrl, bool collapsable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiPaneControlGetBarBehindText(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPaneControlSetBarBehindText(IntPtr ctrl, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiPaneControlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPaneControlSetCollapsed(IntPtr ctrl, bool collapsed);
      }
      
      #endregion

      #region Properties

      public string Caption
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiPaneControlGetCaption(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiPaneControlSetCaption(ObjectPtr->ObjPtr, value);
         }
      }
      public string CaptionID
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiPaneControlGetCaptionID(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiPaneControlSetCaptionID(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Collapsable
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiPaneControlGetCollapsable(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiPaneControlSetCollapsable(ObjectPtr->ObjPtr, value);
         }
      }
      public bool BarBehindText
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiPaneControlGetBarBehindText(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiPaneControlSetBarBehindText(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void SetCollapsed(bool collapsed)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPaneControlSetCollapsed(ObjectPtr->ObjPtr, collapsed);
      }
      
      #endregion

      
   }
}