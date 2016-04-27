using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class TCPObject : SimObject
   {
      
      public TCPObject()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.TCPObjectCreateInstance());
      }

      public TCPObject(uint pId) : base(pId)
      {
      }

      public TCPObject(string pName) : base(pName)
      {
      }

      public TCPObject(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public TCPObject(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public TCPObject(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr TCPObjectCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void TCPObjectSend(IntPtr tcpObj, int argsC, string[] argsV);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void TCPObjectListen(IntPtr tcpObj, int port);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void TCPObjectConnect(IntPtr tcpObj, string address);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void TCPObjectOpenAndConnect(IntPtr tcpObj, string address);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void TCPObjectDisconnect(IntPtr tcpObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string TCPObjectURLEncodeString(IntPtr tcpObj, string data);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public void Send(int argsC, string[] argsV)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.TCPObjectSend(ObjectPtr->ObjPtr, argsC, argsV);
      }

      public void Listen(int port)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.TCPObjectListen(ObjectPtr->ObjPtr, port);
      }

      public void Connect(string address)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.TCPObjectConnect(ObjectPtr->ObjPtr, address);
      }

      public void OpenAndConnect(string address)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.TCPObjectOpenAndConnect(ObjectPtr->ObjPtr, address);
      }

      public void Disconnect()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.TCPObjectDisconnect(ObjectPtr->ObjPtr);
      }

      public string URLEncodeString(string data)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.TCPObjectURLEncodeString(ObjectPtr->ObjPtr, data);
      }
      
      #endregion

      
   }
}