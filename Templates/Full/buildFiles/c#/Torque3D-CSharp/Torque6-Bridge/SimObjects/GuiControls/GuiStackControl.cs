using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiStackControl : GuiControl
   {
      
      public GuiStackControl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiStackControlCreateInstance());
      }

      public GuiStackControl(uint pId) : base(pId)
      {
      }

      public GuiStackControl(string pName) : base(pName)
      {
      }

      public GuiStackControl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiStackControl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiStackControl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiStackControlGetStackingType(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiStackControlSetStackingType(IntPtr ctrl, int type);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiStackControlGetHorizStacking(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiStackControlSetHorizStacking(IntPtr ctrl, int type);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiStackControlGetVertStacking(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiStackControlSetVertStacking(IntPtr ctrl, int type);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiStackControlGetPadding(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiStackControlSetPadding(IntPtr ctrl, int padding);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiStackControlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiStackControlUpdateStack(IntPtr ctrl);
      }
      
      #endregion

      #region Properties

      public int StackingType
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiStackControlGetStackingType(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiStackControlSetStackingType(ObjectPtr->ObjPtr, value);
         }
      }
      public int HorizStacking
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiStackControlGetHorizStacking(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiStackControlSetHorizStacking(ObjectPtr->ObjPtr, value);
         }
      }
      public int VertStacking
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiStackControlGetVertStacking(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiStackControlSetVertStacking(ObjectPtr->ObjPtr, value);
         }
      }
      public int Padding
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiStackControlGetPadding(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiStackControlSetPadding(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void UpdateStack()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiStackControlUpdateStack(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}