using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiConsoleEditCtrl : GuiTextEditCtrl
   {
      
      public GuiConsoleEditCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiConsoleEditCtrlCreateInstance());
      }

      public GuiConsoleEditCtrl(uint pId) : base(pId)
      {
      }

      public GuiConsoleEditCtrl(string pName) : base(pName)
      {
      }

      public GuiConsoleEditCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiConsoleEditCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiConsoleEditCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiConsoleEditCtrlGetUseSiblingScroller(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiConsoleEditCtrlSetUseSiblingScroller(IntPtr ctrl, bool use);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiConsoleEditCtrlCreateInstance();
      }
      
      #endregion

      #region Properties

      public bool UseSiblingScroller
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiConsoleEditCtrlGetUseSiblingScroller(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiConsoleEditCtrlSetUseSiblingScroller(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}