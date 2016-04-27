using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class Message : SimObject
   {
      
      public Message()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.MessageCreateInstance());
      }

      public Message(uint pId) : base(pId)
      {
      }

      public Message(string pName) : base(pName)
      {
      }

      public Message(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public Message(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public Message(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr MessageCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string MessageGetType(IntPtr message);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void MessageAddReference(IntPtr message);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void MessageFreeReference(IntPtr message);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public string GetType()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.MessageGetType(ObjectPtr->ObjPtr);
      }

      public void AddReference()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.MessageAddReference(ObjectPtr->ObjPtr);
      }

      public void FreeReference()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.MessageFreeReference(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}