using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class OpenFileDialog : FileDialog
   {
      
      public OpenFileDialog()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.OpenFileDialogCreateInstance());
      }

      public OpenFileDialog(uint pId) : base(pId)
      {
      }

      public OpenFileDialog(string pName) : base(pName)
      {
      }

      public OpenFileDialog(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public OpenFileDialog(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public OpenFileDialog(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool OpenFileDialogGetMustExist(IntPtr openFileDialog);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void OpenFileDialogSetMustExist(IntPtr openFileDialog, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool OpenFileDialogGetMultipleFiles(IntPtr openFileDialog);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void OpenFileDialogSetMultipleFiles(IntPtr openFileDialog, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr OpenFileDialogCreateInstance();
      }
      
      #endregion

      #region Properties

      public bool MustExist
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.OpenFileDialogGetMustExist(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.OpenFileDialogSetMustExist(ObjectPtr->ObjPtr, value);
         }
      }
      public bool MultipleFiles
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.OpenFileDialogGetMultipleFiles(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.OpenFileDialogSetMultipleFiles(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}