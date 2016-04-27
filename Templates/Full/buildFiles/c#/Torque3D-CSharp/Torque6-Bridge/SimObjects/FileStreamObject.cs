using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class FileStreamObject : StreamObject
   {
      
      public FileStreamObject()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.FileStreamObjectCreateInstance());
      }

      public FileStreamObject(uint pId) : base(pId)
      {
      }

      public FileStreamObject(string pName) : base(pName)
      {
      }

      public FileStreamObject(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public FileStreamObject(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public FileStreamObject(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr FileStreamObjectCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool FileStreamObjectOpen(IntPtr fileStream, string fileName, int mode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void FileStreamObjectClose(IntPtr fileStream);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public bool Open(string fileName, int mode)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.FileStreamObjectOpen(ObjectPtr->ObjPtr, fileName, mode);
      }

      public void Close()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.FileStreamObjectClose(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}