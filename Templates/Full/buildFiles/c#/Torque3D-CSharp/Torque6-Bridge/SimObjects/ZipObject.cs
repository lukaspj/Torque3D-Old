using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class ZipObject : SimObject
   {
      
      public ZipObject()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.ZipObjectCreateInstance());
      }

      public ZipObject(uint pId) : base(pId)
      {
      }

      public ZipObject(string pName) : base(pName)
      {
      }

      public ZipObject(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public ZipObject(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public ZipObject(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ZipObjectCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ZipObjectOpenArchive(IntPtr zipObj, string fileName, int mode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ZipObjectCloseArchive(IntPtr zipObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ZipObjectOpenFileForRead(IntPtr zipObj, string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ZipObjectOpenFileForWrite(IntPtr zipObj, string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ZipObjectCloseFile(IntPtr zipObj, IntPtr stream);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ZipObjectAddFile(IntPtr zipObj, string fileName, string pathInZip, bool replace);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ZipObjectExtractFile(IntPtr zipObj, string fileName, string pathInZip);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ZipObjectDeleteFile(IntPtr zipObj, string pathInZip);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ZipObjectGetFileEntryCount(IntPtr zipObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ZipObjectGetFileEntry(IntPtr zipObj, int index);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public bool OpenArchive(string fileName, int mode = 0)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ZipObjectOpenArchive(ObjectPtr->ObjPtr, fileName, mode);
      }

      public void CloseArchive()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ZipObjectCloseArchive(ObjectPtr->ObjPtr);
      }

      public StreamObject OpenFileForRead(string fileName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new StreamObject(InternalUnsafeMethods.ZipObjectOpenFileForRead(ObjectPtr->ObjPtr, fileName));
      }

      public StreamObject OpenFileForWrite(string fileName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new StreamObject(InternalUnsafeMethods.ZipObjectOpenFileForWrite(ObjectPtr->ObjPtr, fileName));
      }

      public void CloseFile(StreamObject stream)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ZipObjectCloseFile(ObjectPtr->ObjPtr, stream.ObjectPtr->ObjPtr);
      }

      public bool AddFile(string fileName, string pathInZip, bool replace = true)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ZipObjectAddFile(ObjectPtr->ObjPtr, fileName, pathInZip, replace);
      }

      public bool ExtractFile(string fileName, string pathInZip)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ZipObjectExtractFile(ObjectPtr->ObjPtr, fileName, pathInZip);
      }

      public bool DeleteFile(string pathInZip)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ZipObjectDeleteFile(ObjectPtr->ObjPtr, pathInZip);
      }

      public int GetFileEntryCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ZipObjectGetFileEntryCount(ObjectPtr->ObjPtr);
      }

      public string GetFileEntry(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ZipObjectGetFileEntry(ObjectPtr->ObjPtr, index);
      }
      
      #endregion

      
   }
}