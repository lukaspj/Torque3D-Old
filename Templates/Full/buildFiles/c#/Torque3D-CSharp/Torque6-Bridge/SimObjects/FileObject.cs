using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class FileObject : SimObject
   {
      
      public FileObject()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.FileObjectCreateInstance());
      }

      public FileObject(uint pId) : base(pId)
      {
      }

      public FileObject(string pName) : base(pName)
      {
      }

      public FileObject(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public FileObject(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public FileObject(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr FileObjectCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool FileObjectOpenForRead(IntPtr fileObj, string filename);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool FileObjectOpenForWrite(IntPtr fileObj, string filename);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool FileObjectOpenForAppend(IntPtr fileObj, string filename);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool FileObjectIsEOF(IntPtr fileObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string FileObjectReadLine(IntPtr fileObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string FileObjectPeekLine(IntPtr fileObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void FileObjectWriteLine(IntPtr fileObj, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void FileObjectClose(IntPtr fileObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void FileObjectWriteObject(IntPtr fileObj, IntPtr simObj, string text);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public bool OpenForRead(string filename)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.FileObjectOpenForRead(ObjectPtr->ObjPtr, filename);
      }

      public bool OpenForWrite(string filename)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.FileObjectOpenForWrite(ObjectPtr->ObjPtr, filename);
      }

      public bool OpenForAppend(string filename)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.FileObjectOpenForAppend(ObjectPtr->ObjPtr, filename);
      }

      public bool IsEOF()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.FileObjectIsEOF(ObjectPtr->ObjPtr);
      }

      public string ReadLine()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.FileObjectReadLine(ObjectPtr->ObjPtr);
      }

      public string PeekLine()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.FileObjectPeekLine(ObjectPtr->ObjPtr);
      }

      public void WriteLine(string text)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.FileObjectWriteLine(ObjectPtr->ObjPtr, text);
      }

      public void Close()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.FileObjectClose(ObjectPtr->ObjPtr);
      }

      public void WriteObject(SimObject simObj, string text = null)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.FileObjectWriteObject(ObjectPtr->ObjPtr, simObj.ObjectPtr->ObjPtr, text);
      }
      
      #endregion

      
   }
}