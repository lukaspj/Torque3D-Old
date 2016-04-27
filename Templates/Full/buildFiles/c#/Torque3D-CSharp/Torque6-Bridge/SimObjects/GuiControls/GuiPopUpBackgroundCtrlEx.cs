using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiPopUpBackgroundCtrlEx : GuiControl
   {
      
      public GuiPopUpBackgroundCtrlEx()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiPopUpBackgroundCtrlExCreateInstance());
      }

      public GuiPopUpBackgroundCtrlEx(uint pId) : base(pId)
      {
      }

      public GuiPopUpBackgroundCtrlEx(string pName) : base(pName)
      {
      }

      public GuiPopUpBackgroundCtrlEx(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiPopUpBackgroundCtrlEx(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiPopUpBackgroundCtrlEx(SimObject pObj) : base(pObj)
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