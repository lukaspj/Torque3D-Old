using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiGraphCtrl : GuiControl
   {
      
      public GuiGraphCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiGraphCtrlCreateInstance());
      }

      public GuiGraphCtrl(uint pId) : base(pId)
      {
      }

      public GuiGraphCtrl(string pName) : base(pName)
      {
      }

      public GuiGraphCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiGraphCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiGraphCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiGraphCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiGraphCtrlAddDatum(IntPtr ctrl, int plotID, float v);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float GuiGraphCtrlGetDatum(IntPtr ctrl, int plotID, int samples);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiGraphCtrlAddAutoPlot(IntPtr ctrl, int plotID, string variable, int update);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiGraphCtrlRemoveAutoPlot(IntPtr ctrl, int plotID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiGraphCtrlSetGraphType(IntPtr ctrl, int plotID, string graphType);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiGraphCtrlMatchScale(IntPtr ctrl, int argc, int[] argv);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public void AddDatum(int plotID, float v)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiGraphCtrlAddDatum(ObjectPtr->ObjPtr, plotID, v);
      }

      public float GetDatum(int plotID, int samples)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiGraphCtrlGetDatum(ObjectPtr->ObjPtr, plotID, samples);
      }

      public void AddAutoPlot(int plotID, string variable, int update)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiGraphCtrlAddAutoPlot(ObjectPtr->ObjPtr, plotID, variable, update);
      }

      public void RemoveAutoPlot(int plotID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiGraphCtrlRemoveAutoPlot(ObjectPtr->ObjPtr, plotID);
      }

      public void SetGraphType(int plotID, string graphType)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiGraphCtrlSetGraphType(ObjectPtr->ObjPtr, plotID, graphType);
      }

      public void MatchScale(int argc, int[] argv)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiGraphCtrlMatchScale(ObjectPtr->ObjPtr, argc, argv);
      }
      
      #endregion

      
   }
}