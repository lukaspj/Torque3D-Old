using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class ReferencedAssets : SimObject
   {
      
      public ReferencedAssets()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.ReferencedAssetsCreateInstance());
      }

      public ReferencedAssets(uint pId) : base(pId)
      {
      }

      public ReferencedAssets(string pName) : base(pName)
      {
      }

      public ReferencedAssets(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public ReferencedAssets(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public ReferencedAssets(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ReferencedAssetsGetPath(IntPtr assets);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ReferencedAssetsSetPath(IntPtr assets, string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ReferencedAssetsGetExtension(IntPtr assets);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ReferencedAssetsSetExtension(IntPtr assets, string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ReferencedAssetsGetRecurse(IntPtr assets);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ReferencedAssetsSetRecurse(IntPtr assets, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ReferencedAssetsCreateInstance();
      }
      
      #endregion

      #region Properties

      public string Path
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ReferencedAssetsGetPath(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ReferencedAssetsSetPath(ObjectPtr->ObjPtr, value);
         }
      }
      public string Extension
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ReferencedAssetsGetExtension(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ReferencedAssetsSetExtension(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Recurse
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ReferencedAssetsGetRecurse(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ReferencedAssetsSetRecurse(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}