using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class MessageVector : SimObject
   {
      
      public MessageVector()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.MessageVectorCreateInstance());
      }

      public MessageVector(uint pId) : base(pId)
      {
      }

      public MessageVector(string pName) : base(pName)
      {
      }

      public MessageVector(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public MessageVector(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public MessageVector(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr MessageVectorCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void MessageVectorClear(IntPtr messageVector);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void MessageVectorPushBackLine(IntPtr messageVector, string msg, int tag);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool MessageVectorPopBackLine(IntPtr messageVector);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void MessageVectorPushFrontLine(IntPtr messageVector, string msg, int tag);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool MessageVectorPopFrontLine(IntPtr messageVector);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool MessageVectorInsertLine(IntPtr messageVector, int pos, string msg, int tag);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool MessageVectorDeleteLine(IntPtr messageVector, uint lineIndex);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void MessageVectorDump(IntPtr messageVector, string filename, string header);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int MessageVectorGetNumLines(IntPtr messageVector);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string MessageVectorGetLineTextByTag(IntPtr messageVector, int tag);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int MessageVectorGetLineIndexByTag(IntPtr messageVector, int tag);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string MessageVectorGetLineText(IntPtr messageVector, uint index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int MessageVectorGetLineTag(IntPtr messageVector, uint index);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public void Clear()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.MessageVectorClear(ObjectPtr->ObjPtr);
      }

      public void PushBackLine(string msg, int tag)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.MessageVectorPushBackLine(ObjectPtr->ObjPtr, msg, tag);
      }

      public bool PopBackLine()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.MessageVectorPopBackLine(ObjectPtr->ObjPtr);
      }

      public void PushFrontLine(string msg, int tag)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.MessageVectorPushFrontLine(ObjectPtr->ObjPtr, msg, tag);
      }

      public bool PopFrontLine()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.MessageVectorPopFrontLine(ObjectPtr->ObjPtr);
      }

      public bool InsertLine(int pos, string msg, int tag)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.MessageVectorInsertLine(ObjectPtr->ObjPtr, pos, msg, tag);
      }

      public bool DeleteLine(uint lineIndex)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.MessageVectorDeleteLine(ObjectPtr->ObjPtr, lineIndex);
      }

      public void Dump(string filename, string header)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.MessageVectorDump(ObjectPtr->ObjPtr, filename, header);
      }

      public int GetNumLines()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.MessageVectorGetNumLines(ObjectPtr->ObjPtr);
      }

      public string GetLineTextByTag(int tag)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.MessageVectorGetLineTextByTag(ObjectPtr->ObjPtr, tag);
      }

      public int GetLineIndexByTag(int tag)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.MessageVectorGetLineIndexByTag(ObjectPtr->ObjPtr, tag);
      }

      public string GetLineText(uint index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.MessageVectorGetLineText(ObjectPtr->ObjPtr, index);
      }

      public int GetLineTag(uint index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.MessageVectorGetLineTag(ObjectPtr->ObjPtr, index);
      }
      
      #endregion

      
   }
}