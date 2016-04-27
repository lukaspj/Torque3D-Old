using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class MessageForwarder : ScriptMsgListener
   {
      
      public MessageForwarder()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.MessageForwarderCreateInstance());
      }

      public MessageForwarder(uint pId) : base(pId)
      {
      }

      public MessageForwarder(string pName) : base(pName)
      {
      }

      public MessageForwarder(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public MessageForwarder(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public MessageForwarder(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string MessageForwarderGetToQueue(IntPtr forwarder);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void MessageForwarderSetToQueue(IntPtr forwarder, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr MessageForwarderCreateInstance();
      }
      
      #endregion

      #region Properties

      public string ToQueue
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.MessageForwarderGetToQueue(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.MessageForwarderSetToQueue(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}