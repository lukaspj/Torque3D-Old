using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class DeclaredAssets : SimObject
   {
      
      public DeclaredAssets()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.DeclaredAssetsCreateInstance());
      }

      public DeclaredAssets(uint pId) : base(pId)
      {
      }

      public DeclaredAssets(string pName) : base(pName)
      {
      }

      public DeclaredAssets(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public DeclaredAssets(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public DeclaredAssets(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string DeclaredAssetsGetPath(IntPtr assets);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DeclaredAssetsSetPath(IntPtr assets, string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string DeclaredAssetsGetExtension(IntPtr assets);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DeclaredAssetsSetExtension(IntPtr assets, string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool DeclaredAssetsGetRecurse(IntPtr assets);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DeclaredAssetsSetRecurse(IntPtr assets, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr DeclaredAssetsCreateInstance();
      }
      
      #endregion

      #region Properties

      public string Path
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.DeclaredAssetsGetPath(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.DeclaredAssetsSetPath(ObjectPtr->ObjPtr, value);
         }
      }
      public string Extension
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.DeclaredAssetsGetExtension(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.DeclaredAssetsSetExtension(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Recurse
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.DeclaredAssetsGetRecurse(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.DeclaredAssetsSetRecurse(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}