using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiDragAndDropControl : GuiControl
   {
      
      public GuiDragAndDropControl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiDragAndDropControlCreateInstance());
      }

      public GuiDragAndDropControl(uint pId) : base(pId)
      {
      }

      public GuiDragAndDropControl(string pName) : base(pName)
      {
      }

      public GuiDragAndDropControl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiDragAndDropControl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiDragAndDropControl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiDragAndDropControlGetDeleteOnMouseUp(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiDragAndDropControlSetDeleteOnMouseUp(IntPtr ctrl, bool deleteOnMouseUp);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiDragAndDropControlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiDragAndDropControlStartDragging(IntPtr ctrl, Point2I offset);
      }
      
      #endregion

      #region Properties

      public bool DeleteOnMouseUp
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiDragAndDropControlGetDeleteOnMouseUp(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiDragAndDropControlSetDeleteOnMouseUp(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void StartDragging(Point2I offset)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiDragAndDropControlStartDragging(ObjectPtr->ObjPtr, offset);
      }
      
      #endregion

      
   }
}