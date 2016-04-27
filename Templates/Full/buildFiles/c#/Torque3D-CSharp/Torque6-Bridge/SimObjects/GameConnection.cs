using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class GameConnection : NetConnection
   {
      
      public GameConnection()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GameConnectionCreateInstance());
      }

      public GameConnection(uint pId) : base(pId)
      {
      }

      public GameConnection(string pName) : base(pName)
      {
      }

      public GameConnection(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GameConnection(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GameConnection(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GameConnectionCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GameConnectionSetJoinPassword(IntPtr connection, string password);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GameConnectionSetConnectArgs(IntPtr connection, int argC, string[] argV);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GameConnectionActivateGhosting(IntPtr connection);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GameConnectionResetGhosting(IntPtr connection);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GameConnectionDelete(IntPtr connection, string reason);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GameConnectionGetServerConnection(IntPtr connection);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public void SetJoinPassword(string password)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GameConnectionSetJoinPassword(ObjectPtr->ObjPtr, password);
      }

      public void SetConnectArgs(int argC, string[] argV)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GameConnectionSetConnectArgs(ObjectPtr->ObjPtr, argC, argV);
      }

      public void ActivateGhosting()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GameConnectionActivateGhosting(ObjectPtr->ObjPtr);
      }

      public void ResetGhosting()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GameConnectionResetGhosting(ObjectPtr->ObjPtr);
      }

      public void Delete(string reason = null)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GameConnectionDelete(ObjectPtr->ObjPtr, reason);
      }

      public NetConnection GetServerConnection()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new NetConnection(InternalUnsafeMethods.GameConnectionGetServerConnection(ObjectPtr->ObjPtr));
      }
      
      #endregion

      
   }
}