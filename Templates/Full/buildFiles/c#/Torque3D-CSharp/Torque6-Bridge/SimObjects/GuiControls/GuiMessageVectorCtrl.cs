using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiMessageVectorCtrl : GuiControl
   {
      
      public GuiMessageVectorCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiMessageVectorCtrlCreateInstance());
      }

      public GuiMessageVectorCtrl(uint pId) : base(pId)
      {
      }

      public GuiMessageVectorCtrl(string pName) : base(pName)
      {
      }

      public GuiMessageVectorCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMessageVectorCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMessageVectorCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiMessageVectorCtrlGetLineSpacing(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMessageVectorCtrlSetLineSpacing(IntPtr ctrl, int spacing);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiMessageVectorCtrlGetLineContinuedIndex(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMessageVectorCtrlSetLineContinuedIndex(IntPtr ctrl, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiMessageVectorCtrlGetAllowedMatches(IntPtr ctrl, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMessageVectorCtrlSetAllowedMatches(IntPtr ctrl, int index, string match);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMessageVectorCtrlGetMatchColor(IntPtr ctrl, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMessageVectorCtrlSetMatchColor(IntPtr ctrl, Color color);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiMessageVectorCtrlGetMaxColorIndex(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMessageVectorCtrlSetMaxColorIndex(IntPtr ctrl, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiMessageVectorCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiMessageVectorCtrlAttach(IntPtr ctrl, IntPtr MV);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMessageVectorCtrlDetach(IntPtr ctrl);
      }
      
      #endregion

      #region Properties

      public int LineSpacing
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiMessageVectorCtrlGetLineSpacing(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMessageVectorCtrlSetLineSpacing(ObjectPtr->ObjPtr, value);
         }
      }
      public int LineContinuedIndex
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiMessageVectorCtrlGetLineContinuedIndex(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMessageVectorCtrlSetLineContinuedIndex(ObjectPtr->ObjPtr, value);
         }
      }

      public PrimitiveFieldVector<string> AllowedMatches
      {
         get
         {
            return new PrimitiveFieldVector<string>(this, 16, InternalUnsafeMethods.GuiMessageVectorCtrlGetAllowedMatches,
               InternalUnsafeMethods.GuiMessageVectorCtrlSetAllowedMatches);
         }
      }
      public Color MatchColor
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiMessageVectorCtrlGetMatchColor(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMessageVectorCtrlSetMatchColor(ObjectPtr->ObjPtr, value);
         }
      }
      public int MaxColorIndex
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiMessageVectorCtrlGetMaxColorIndex(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMessageVectorCtrlSetMaxColorIndex(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public bool Attach(MessageVector MV)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiMessageVectorCtrlAttach(ObjectPtr->ObjPtr, MV.ObjectPtr->ObjPtr);
      }

      public void Detach()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMessageVectorCtrlDetach(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}