using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class AssetManager : SimObject
   {
      
      public AssetManager()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.AssetManagerCreateInstance());
      }

      public AssetManager(uint pId) : base(pId)
      {
      }

      public AssetManager(string pName) : base(pName)
      {
      }

      public AssetManager(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public AssetManager(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public AssetManager(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerGetEchoInfo(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AssetManagerSetEchoInfo(IntPtr assetManager, bool val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerGetIgnoreAutoUnload(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AssetManagerSetIgnoreAutoUnload(IntPtr assetManager, bool val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr AssetManagerCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerCompileReferencedAssets(IntPtr assetManager, IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerAddModuleDeclaredAssets(IntPtr assetManager, IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerAddDeclaredAsset(IntPtr assetManager, IntPtr moduleDefinition, string assetFilePath);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string AssetManagerAddPrivateAsset(IntPtr assetManager, IntPtr assetObject);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerRemoveDeclaredAssets(IntPtr assetManager, IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerRemoveDeclaredAsset(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string AssetManagerGetAssetName(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string AssetManagerGetAssetDescription(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string AssetManagerGetAssetCategory(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string AssetManagerGetAssetType(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string AssetManagerGetAssetFilePath(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string AssetManagerGetAssetPath(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr AssetManagerGetAssetModule(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerIsAssetInternal(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerIsAssetPrivate(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerIsAssetAutoUnload(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerIsAssetLoaded(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerIsDeclaredAsset(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerIsReferencedAsset(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerRenameDeclaredAsset(IntPtr assetManager, string assetIdFrom, string assetIdTo);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerRenameReferencedAsset(IntPtr assetManager, string assetIdFrom, string assetIdTo);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string AssetManagerAcquireAsset(IntPtr assetManager, string assetId, bool asPrivate);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerReleaseAsset(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AssetManagerPurgeAssets(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerDeleteAsset(IntPtr assetManager, string assetId, bool deleteLooseFiles, bool deleteDependencies);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AssetManagerRefreshAsset(IntPtr assetManager, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AssetManagerRefreshAllAssets(IntPtr assetManager, bool includeUnloaded);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerSaveAssetTags(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerRestoreAssetTags(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr AssetManagerGetAssetTags(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindAllAssets(IntPtr assetManager, IntPtr assetQuery, bool ignoreInternal, bool ignorePrivate);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindAssetName(IntPtr assetManager, IntPtr assetQuery, string assetName, bool partialName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindAssetCategory(IntPtr assetManager, IntPtr assetQuery, string assetName, bool assetQueryAsSource);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindAssetAutoUnload(IntPtr assetManager, IntPtr assetQuery, bool assetAutoUnload, bool assetQueryAsSource);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindAssetInternal(IntPtr assetManager, IntPtr assetQuery, bool assetInternal, bool assetQueryAsSource);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindAssetPrivate(IntPtr assetManager, IntPtr assetQuery, bool assetPrivate, bool assetQueryAsSource);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindAssetType(IntPtr assetManager, IntPtr assetQuery, string assetType, bool assetQueryAsSource);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindAssetDependsOn(IntPtr assetManager, IntPtr assetQuery, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindAssetIsDependedOn(IntPtr assetManager, IntPtr assetQuery, string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindInvalidAssetReferences(IntPtr assetManager, IntPtr assetQuery);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindTaggedAssets(IntPtr assetManager, IntPtr assetQuery, string assetTagNames, bool assetQueryAsSource);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AssetManagerFindAssetLooseFile(IntPtr assetManager, IntPtr assetQuery, string assetLooseFile, bool assetQueryAsSource);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerGetDeclaredAssetCount(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerGetReferencedAssetCount(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerGetLoadedInternalAssetCount(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerGetMaxLoadedInternalAssetCount(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerGetLoadedExternalAssetCount(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AssetManagerGetMaxLoadedExternalAssetCount(IntPtr assetManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AssetManagerDumpDeclaredAssets(IntPtr assetManager);
      }
      
      #endregion

      #region Properties

      public bool EchoInfo
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AssetManagerGetEchoInfo(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AssetManagerSetEchoInfo(ObjectPtr->ObjPtr, value);
         }
      }
      public bool IgnoreAutoUnload
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AssetManagerGetIgnoreAutoUnload(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AssetManagerSetIgnoreAutoUnload(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public bool CompileReferencedAssets(ModuleDefinition moduleDefinition)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerCompileReferencedAssets(ObjectPtr->ObjPtr, moduleDefinition.ObjectPtr->ObjPtr);
      }

      public bool AddModuleDeclaredAssets(ModuleDefinition moduleDefinition)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerAddModuleDeclaredAssets(ObjectPtr->ObjPtr, moduleDefinition.ObjectPtr->ObjPtr);
      }

      public bool AddDeclaredAsset(ModuleDefinition moduleDefinition, string assetFilePath)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerAddDeclaredAsset(ObjectPtr->ObjPtr, moduleDefinition.ObjectPtr->ObjPtr, assetFilePath);
      }

      public string AddPrivateAsset(AssetBase assetObject)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerAddPrivateAsset(ObjectPtr->ObjPtr, assetObject.ObjectPtr->ObjPtr);
      }

      public bool RemoveDeclaredAssets(ModuleDefinition moduleDefinition)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerRemoveDeclaredAssets(ObjectPtr->ObjPtr, moduleDefinition.ObjectPtr->ObjPtr);
      }

      public bool RemoveDeclaredAsset(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerRemoveDeclaredAsset(ObjectPtr->ObjPtr, assetId);
      }

      public string GetAssetName(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetAssetName(ObjectPtr->ObjPtr, assetId);
      }

      public string GetAssetDescription(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetAssetDescription(ObjectPtr->ObjPtr, assetId);
      }

      public string GetAssetCategory(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetAssetCategory(ObjectPtr->ObjPtr, assetId);
      }

      public string GetAssetType(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetAssetType(ObjectPtr->ObjPtr, assetId);
      }

      public string GetAssetFilePath(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetAssetFilePath(ObjectPtr->ObjPtr, assetId);
      }

      public string GetAssetPath(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetAssetPath(ObjectPtr->ObjPtr, assetId);
      }

      public ModuleDefinition GetAssetModule(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new ModuleDefinition(InternalUnsafeMethods.AssetManagerGetAssetModule(ObjectPtr->ObjPtr, assetId));
      }

      public bool IsAssetInternal(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerIsAssetInternal(ObjectPtr->ObjPtr, assetId);
      }

      public bool IsAssetPrivate(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerIsAssetPrivate(ObjectPtr->ObjPtr, assetId);
      }

      public bool IsAssetAutoUnload(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerIsAssetAutoUnload(ObjectPtr->ObjPtr, assetId);
      }

      public bool IsAssetLoaded(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerIsAssetLoaded(ObjectPtr->ObjPtr, assetId);
      }

      public bool IsDeclaredAsset(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerIsDeclaredAsset(ObjectPtr->ObjPtr, assetId);
      }

      public bool IsReferencedAsset(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerIsReferencedAsset(ObjectPtr->ObjPtr, assetId);
      }

      public bool RenameDeclaredAsset(string assetIdFrom, string assetIdTo)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerRenameDeclaredAsset(ObjectPtr->ObjPtr, assetIdFrom, assetIdTo);
      }

      public bool RenameReferencedAsset(string assetIdFrom, string assetIdTo)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerRenameReferencedAsset(ObjectPtr->ObjPtr, assetIdFrom, assetIdTo);
      }

      public string AcquireAsset(string assetId, bool asPrivate = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerAcquireAsset(ObjectPtr->ObjPtr, assetId, asPrivate);
      }

      public bool ReleaseAsset(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerReleaseAsset(ObjectPtr->ObjPtr, assetId);
      }

      public void PurgeAssets()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.AssetManagerPurgeAssets(ObjectPtr->ObjPtr);
      }

      public bool DeleteAsset(string assetId, bool deleteLooseFiles, bool deleteDependencies)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerDeleteAsset(ObjectPtr->ObjPtr, assetId, deleteLooseFiles, deleteDependencies);
      }

      public void RefreshAsset(string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.AssetManagerRefreshAsset(ObjectPtr->ObjPtr, assetId);
      }

      public void RefreshAllAssets(bool includeUnloaded = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.AssetManagerRefreshAllAssets(ObjectPtr->ObjPtr, includeUnloaded);
      }

      public bool SaveAssetTags()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerSaveAssetTags(ObjectPtr->ObjPtr);
      }

      public bool RestoreAssetTags()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerRestoreAssetTags(ObjectPtr->ObjPtr);
      }

      public AssetTagsManifest GetAssetTags()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new AssetTagsManifest(InternalUnsafeMethods.AssetManagerGetAssetTags(ObjectPtr->ObjPtr));
      }

      public int FindAllAssets(AssetQuery assetQuery, bool ignoreInternal = true, bool ignorePrivate = true)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindAllAssets(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, ignoreInternal, ignorePrivate);
      }

      public int FindAssetName(AssetQuery assetQuery, string assetName, bool partialName = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindAssetName(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, assetName, partialName);
      }

      public int FindAssetCategory(AssetQuery assetQuery, string assetName, bool assetQueryAsSource = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindAssetCategory(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, assetName, assetQueryAsSource);
      }

      public int FindAssetAutoUnload(AssetQuery assetQuery, bool assetAutoUnload, bool assetQueryAsSource = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindAssetAutoUnload(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, assetAutoUnload, assetQueryAsSource);
      }

      public int FindAssetInternal(AssetQuery assetQuery, bool assetInternal, bool assetQueryAsSource = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindAssetInternal(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, assetInternal, assetQueryAsSource);
      }

      public int FindAssetPrivate(AssetQuery assetQuery, bool assetPrivate, bool assetQueryAsSource = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindAssetPrivate(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, assetPrivate, assetQueryAsSource);
      }

      public int FindAssetType(AssetQuery assetQuery, string assetType, bool assetQueryAsSource = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindAssetType(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, assetType, assetQueryAsSource);
      }

      public int FindAssetDependsOn(AssetQuery assetQuery, string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindAssetDependsOn(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, assetId);
      }

      public int FindAssetIsDependedOn(AssetQuery assetQuery, string assetId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindAssetIsDependedOn(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, assetId);
      }

      public int FindInvalidAssetReferences(AssetQuery assetQuery)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindInvalidAssetReferences(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr);
      }

      public int FindTaggedAssets(AssetQuery assetQuery, string assetTagNames, bool assetQueryAsSource = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindTaggedAssets(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, assetTagNames, assetQueryAsSource);
      }

      public int FindAssetLooseFile(AssetQuery assetQuery, string assetLooseFile, bool assetQueryAsSource = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerFindAssetLooseFile(ObjectPtr->ObjPtr, assetQuery.ObjectPtr->ObjPtr, assetLooseFile, assetQueryAsSource);
      }

      public bool GetDeclaredAssetCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetDeclaredAssetCount(ObjectPtr->ObjPtr);
      }

      public bool GetReferencedAssetCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetReferencedAssetCount(ObjectPtr->ObjPtr);
      }

      public bool GetLoadedInternalAssetCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetLoadedInternalAssetCount(ObjectPtr->ObjPtr);
      }

      public bool GetMaxLoadedInternalAssetCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetMaxLoadedInternalAssetCount(ObjectPtr->ObjPtr);
      }

      public bool GetLoadedExternalAssetCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetLoadedExternalAssetCount(ObjectPtr->ObjPtr);
      }

      public bool GetMaxLoadedExternalAssetCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.AssetManagerGetMaxLoadedExternalAssetCount(ObjectPtr->ObjPtr);
      }

      public void DumpDeclaredAssets()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.AssetManagerDumpDeclaredAssets(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}