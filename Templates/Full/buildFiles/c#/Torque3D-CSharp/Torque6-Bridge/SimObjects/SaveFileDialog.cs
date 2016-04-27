using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class SaveFileDialog : FileDialog
   {
      
      public SaveFileDialog()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.SaveFileDialogCreateInstance());
      }

      public SaveFileDialog(uint pId) : base(pId)
      {
      }

      public SaveFileDialog(string pName) : base(pName)
      {
      }

      public SaveFileDialog(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public SaveFileDialog(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public SaveFileDialog(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SaveFileDialogGetOverwritePrompt(IntPtr saveFileDialog);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SaveFileDialogSetOverwritePrompt(IntPtr saveFileDialog, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr SaveFileDialogCreateInstance();
      }
      
      #endregion

      #region Properties

      public bool OverwritePrompt
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.SaveFileDialogGetOverwritePrompt(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.SaveFileDialogSetOverwritePrompt(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}