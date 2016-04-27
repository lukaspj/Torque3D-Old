using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class ModuleDefinition : SimSet
   {
      
      public ModuleDefinition()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.ModuleDefinitionCreateInstance());
      }

      public ModuleDefinition(uint pId) : base(pId)
      {
      }

      public ModuleDefinition(string pName) : base(pName)
      {
      }

      public ModuleDefinition(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public ModuleDefinition(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public ModuleDefinition(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetModuleId(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetModuleId(IntPtr moduleDefinition, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ModuleDefinitionGetVersionId(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetVersionId(IntPtr moduleDefinition, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ModuleDefinitionGetBuildId(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetBuildId(IntPtr moduleDefinition, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleDefinitionGetEnabled(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetEnabled(IntPtr moduleDefinition, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleDefinitionGetSynchronized(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetSynchronized(IntPtr moduleDefinition, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleDefinitionGetDeprecated(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetDeprecated(IntPtr moduleDefinition, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleDefinitionGetCriticalMerge(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetCriticalMerge(IntPtr moduleDefinition, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetDescription(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetDescription(IntPtr moduleDefinition, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetAuthor(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetAuthor(IntPtr moduleDefinition, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetGroup(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetGroup(IntPtr moduleDefinition, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetType(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetType(IntPtr moduleDefinition, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetDependencies(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetDependencies(IntPtr moduleDefinition, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetScriptFile(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetScriptFile(IntPtr moduleDefinition, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetCreateFunction(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetCreateFunction(IntPtr moduleDefinition, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetDestroyFunction(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetDestroyFunction(IntPtr moduleDefinition, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetAssetTagsManifest(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleDefinitionSetAssetTagsManifest(IntPtr moduleDefinition, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ModuleDefinitionGetScopeSet(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetModulePath(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetModuleFile(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetModuleFilePath(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetModuleScriptFilePath(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ModuleDefinitionCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetSignature(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleDefinitionSave(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ModuleDefinitionGetModuleManager(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ModuleDefinitionGetDependencyCount(IntPtr moduleDefinition);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleDefinitionGetDependency(IntPtr moduleDefinition, int dependencyIndex);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleDefinitionAddDependency(IntPtr moduleDefinition, string moduleId, int versionId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleDefinitionRemoveDependency(IntPtr moduleDefinition, string moduleId);
      }
      
      #endregion

      #region Properties

      public string ModuleId
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetModuleId(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetModuleId(ObjectPtr->ObjPtr, value);
         }
      }
      public int VersionId
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetVersionId(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetVersionId(ObjectPtr->ObjPtr, value);
         }
      }
      public int BuildId
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetBuildId(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetBuildId(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Enabled
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetEnabled(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetEnabled(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Synchronized
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetSynchronized(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetSynchronized(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Deprecated
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetDeprecated(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetDeprecated(ObjectPtr->ObjPtr, value);
         }
      }
      public bool CriticalMerge
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetCriticalMerge(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetCriticalMerge(ObjectPtr->ObjPtr, value);
         }
      }
      public string Description
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetDescription(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetDescription(ObjectPtr->ObjPtr, value);
         }
      }
      public string Author
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetAuthor(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetAuthor(ObjectPtr->ObjPtr, value);
         }
      }
      public string Group
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetGroup(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetGroup(ObjectPtr->ObjPtr, value);
         }
      }
      public string Type
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetType(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetType(ObjectPtr->ObjPtr, value);
         }
      }
      public string Dependencies
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetDependencies(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetDependencies(ObjectPtr->ObjPtr, value);
         }
      }
      public string ScriptFile
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetScriptFile(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetScriptFile(ObjectPtr->ObjPtr, value);
         }
      }
      public string CreateFunction
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetCreateFunction(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetCreateFunction(ObjectPtr->ObjPtr, value);
         }
      }
      public string DestroyFunction
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetDestroyFunction(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetDestroyFunction(ObjectPtr->ObjPtr, value);
         }
      }
      public string AssetTagsManifest
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetAssetTagsManifest(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleDefinitionSetAssetTagsManifest(ObjectPtr->ObjPtr, value);
         }
      }
      public int ScopeSet
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetScopeSet(ObjectPtr->ObjPtr);
         }

      }
      public string ModulePath
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetModulePath(ObjectPtr->ObjPtr);
         }

      }
      public string ModuleFile
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetModuleFile(ObjectPtr->ObjPtr);
         }

      }
      public string ModuleFilePath
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetModuleFilePath(ObjectPtr->ObjPtr);
         }

      }
      public string ModuleScriptFilePath
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleDefinitionGetModuleScriptFilePath(ObjectPtr->ObjPtr);
         }

      }
      
      #endregion
      
      #region Methods

      public string GetSignature()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleDefinitionGetSignature(ObjectPtr->ObjPtr);
      }

      public bool Save()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleDefinitionSave(ObjectPtr->ObjPtr);
      }

      public ModuleManager GetModuleManager()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new ModuleManager(InternalUnsafeMethods.ModuleDefinitionGetModuleManager(ObjectPtr->ObjPtr));
      }

      public int GetDependencyCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleDefinitionGetDependencyCount(ObjectPtr->ObjPtr);
      }

      public string GetDependency(int dependencyIndex)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleDefinitionGetDependency(ObjectPtr->ObjPtr, dependencyIndex);
      }

      public bool AddDependency(string moduleId, int versionId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleDefinitionAddDependency(ObjectPtr->ObjPtr, moduleId, versionId);
      }

      public bool RemoveDependency(string moduleId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleDefinitionRemoveDependency(ObjectPtr->ObjPtr, moduleId);
      }
      
      #endregion

      
   }
}