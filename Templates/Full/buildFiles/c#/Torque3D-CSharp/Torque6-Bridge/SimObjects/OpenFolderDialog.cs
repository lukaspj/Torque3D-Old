using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class OpenFolderDialog : OpenFileDialog
   {
      
      public OpenFolderDialog()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.OpenFolderDialogCreateInstance());
      }

      public OpenFolderDialog(uint pId) : base(pId)
      {
      }

      public OpenFolderDialog(string pName) : base(pName)
      {
      }

      public OpenFolderDialog(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public OpenFolderDialog(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public OpenFolderDialog(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string OpenFolderDialogGetFileMustExist(IntPtr openFolderDialog);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void OpenFolderDialogSetFileMustExist(IntPtr openFolderDialog, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr OpenFolderDialogCreateInstance();
      }
      
      #endregion

      #region Properties

      public string FileMustExist
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.OpenFolderDialogGetFileMustExist(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.OpenFolderDialogSetFileMustExist(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}