using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class MeshAsset : AssetBase
   {
      
      public MeshAsset()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.MeshAssetCreateInstance());
      }

      public MeshAsset(uint pId) : base(pId)
      {
      }

      public MeshAsset(string pName) : base(pName)
      {
      }

      public MeshAsset(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public MeshAsset(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public MeshAsset(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string MeshAssetGetMeshFile(IntPtr meshAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void MeshAssetSetMeshFile(IntPtr meshAsset, string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr MeshAssetCreateInstance();
      }
      
      #endregion

      #region Properties

      public string MeshFile
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.MeshAssetGetMeshFile(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.MeshAssetSetMeshFile(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}