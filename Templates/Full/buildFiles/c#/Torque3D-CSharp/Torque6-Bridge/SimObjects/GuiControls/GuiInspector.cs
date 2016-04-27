using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiInspector : GuiStackControl
   {
      
      public GuiInspector()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiInspectorCreateInstance());
      }

      public GuiInspector(uint pId) : base(pId)
      {
      }

      public GuiInspector(string pName) : base(pName)
      {
      }

      public GuiInspector(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspector(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiInspector(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiInspectorCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiInspectorGetInspectObject(IntPtr inspector);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiInspectorSetName(IntPtr inspector, string newObjectName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiInspectorInspect(IntPtr inspector, IntPtr obj);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public SimObject GetInspectObject()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new SimObject(InternalUnsafeMethods.GuiInspectorGetInspectObject(ObjectPtr->ObjPtr));
      }

      public void SetName(string newObjectName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiInspectorSetName(ObjectPtr->ObjPtr, newObjectName);
      }

      public void Inspect(SimObject obj)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiInspectorInspect(ObjectPtr->ObjPtr, obj.ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}