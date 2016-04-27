using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiMenuTextListCtrl : GuiTextListCtrl
   {
      
      public GuiMenuTextListCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiMenuTextListCtrlCreateInstance());
      }

      public GuiMenuTextListCtrl(uint pId) : base(pId)
      {
      }

      public GuiMenuTextListCtrl(string pName) : base(pName)
      {
      }

      public GuiMenuTextListCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMenuTextListCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMenuTextListCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}