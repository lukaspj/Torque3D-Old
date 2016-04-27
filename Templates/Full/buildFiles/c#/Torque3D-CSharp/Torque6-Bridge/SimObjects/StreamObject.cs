using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class StreamObject : SimObject
   {
      
      public StreamObject()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.StreamObjectCreateInstance());
      }

      public StreamObject(uint pId) : base(pId)
      {
      }

      public StreamObject(string pName) : base(pName)
      {
      }

      public StreamObject(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public StreamObject(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public StreamObject(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr StreamObjectCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string StreamObjectGetStatus(IntPtr streamObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool StreamObjectIsEOS(IntPtr streamObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool StreamObjectIsEOF(IntPtr streamObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int StreamObjectGetPosition(IntPtr streamObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool StreamObjectSetPosition(IntPtr streamObj, int newPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int StreamObjectGetStreamSize(IntPtr streamObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string StreamObjectReadLine(IntPtr streamObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void StreamObjectWriteLine(IntPtr streamObj, string line);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string StreamObjectReadSTString(IntPtr streamObj, bool caseSensitive);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string StreamObjectReadString(IntPtr streamObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string StreamObjectReadLongString(IntPtr streamObj, int maxLength);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void StreamObjectWriteLongString(IntPtr streamObj, int maxLength, string longString);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void StreamObjectWriteString(IntPtr streamObj, string longString, int maxLength);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool StreamObjectCopyFrom(IntPtr streamObj, IntPtr other);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public string GetStatus()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectGetStatus(ObjectPtr->ObjPtr);
      }

      public bool IsEOS()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectIsEOS(ObjectPtr->ObjPtr);
      }

      public bool IsEOF()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectIsEOF(ObjectPtr->ObjPtr);
      }

      public int GetPosition()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectGetPosition(ObjectPtr->ObjPtr);
      }

      public bool SetPosition(int newPos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectSetPosition(ObjectPtr->ObjPtr, newPos);
      }

      public int GetStreamSize()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectGetStreamSize(ObjectPtr->ObjPtr);
      }

      public string ReadLine()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectReadLine(ObjectPtr->ObjPtr);
      }

      public void WriteLine(string line)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.StreamObjectWriteLine(ObjectPtr->ObjPtr, line);
      }

      public string ReadSTString(bool caseSensitive = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectReadSTString(ObjectPtr->ObjPtr, caseSensitive);
      }

      public string ReadString()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectReadString(ObjectPtr->ObjPtr);
      }

      public string ReadLongString(int maxLength)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectReadLongString(ObjectPtr->ObjPtr, maxLength);
      }

      public void WriteLongString(int maxLength, string longString)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.StreamObjectWriteLongString(ObjectPtr->ObjPtr, maxLength, longString);
      }

      public void WriteString(string longString, int maxLength = 255)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.StreamObjectWriteString(ObjectPtr->ObjPtr, longString, maxLength);
      }

      public bool CopyFrom(StreamObject other)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.StreamObjectCopyFrom(ObjectPtr->ObjPtr, other.ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}