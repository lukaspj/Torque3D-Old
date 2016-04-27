using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class PluginAsset : AssetBase
   {
      
      public PluginAsset()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.PluginAssetCreateInstance());
      }

      public PluginAsset(uint pId) : base(pId)
      {
      }

      public PluginAsset(string pName) : base(pName)
      {
      }

      public PluginAsset(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public PluginAsset(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public PluginAsset(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string PluginAssetGetPluginFile(IntPtr pluginAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PluginAssetSetPluginFile(IntPtr pluginAsset, string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr PluginAssetCreateInstance();
      }
      
      #endregion

      #region Properties

      public string PluginFile
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.PluginAssetGetPluginFile(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.PluginAssetSetPluginFile(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}