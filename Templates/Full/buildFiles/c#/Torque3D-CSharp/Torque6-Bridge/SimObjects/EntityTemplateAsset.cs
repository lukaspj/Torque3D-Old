using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class EntityTemplateAsset : AssetBase
   {
      
      public EntityTemplateAsset()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.EntityTemplateAssetCreateInstance());
      }

      public EntityTemplateAsset(uint pId) : base(pId)
      {
      }

      public EntityTemplateAsset(string pName) : base(pName)
      {
      }

      public EntityTemplateAsset(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public EntityTemplateAsset(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public EntityTemplateAsset(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string EntityTemplateAssetGetTemplateFile(IntPtr entityTemplateAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void EntityTemplateAssetSetTemplateFile(IntPtr entityTemplateAsset, string file);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr EntityTemplateAssetCreateInstance();
      }
      
      #endregion

      #region Properties

      public string TemplateFile
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.EntityTemplateAssetGetTemplateFile(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.EntityTemplateAssetSetTemplateFile(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}