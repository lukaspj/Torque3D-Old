using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class NetObject : SimObject
   {
      
      public NetObject()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.NetObjectCreateInstance());
      }

      public NetObject(uint pId) : base(pId)
      {
      }

      public NetObject(string pName) : base(pName)
      {
      }

      public NetObject(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public NetObject(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public NetObject(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr NetObjectCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void NetObjectScopeToClient(IntPtr netObj, IntPtr client);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void NetObjectClearScopeToClient(IntPtr netObj, IntPtr client);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void NetObjectSetScopeAlways(IntPtr netObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int NetObjectGetGhostID(IntPtr netObj);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public void ScopeToClient(NetConnection client)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.NetObjectScopeToClient(ObjectPtr->ObjPtr, client.ObjectPtr->ObjPtr);
      }

      public void ClearScopeToClient(NetConnection client)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.NetObjectClearScopeToClient(ObjectPtr->ObjPtr, client.ObjectPtr->ObjPtr);
      }

      public void SetScopeAlways()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.NetObjectSetScopeAlways(ObjectPtr->ObjPtr);
      }

      public int GetGhostID()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NetObjectGetGhostID(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}