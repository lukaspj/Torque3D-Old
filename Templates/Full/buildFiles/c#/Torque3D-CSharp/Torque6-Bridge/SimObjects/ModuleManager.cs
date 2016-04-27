using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class ModuleManager : SimObject
   {
      
      public ModuleManager()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.ModuleManagerCreateInstance());
      }

      public ModuleManager(uint pId) : base(pId)
      {
      }

      public ModuleManager(string pName) : base(pName)
      {
      }

      public ModuleManager(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public ModuleManager(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public ModuleManager(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerGetEnforceDependencies(IntPtr moduleManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleManagerSetEnforceDependencies(IntPtr moduleManager, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerGetEchoInfo(IntPtr moduleManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleManagerSetEchoInfo(IntPtr moduleManager, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ModuleManagerCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerSetModuleExtension(IntPtr moduleManager, string moduleExtension);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerScanModules(IntPtr moduleManager, string rootPath, bool rootOnly);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerUnregisterModule(IntPtr moduleManager, string moduleId, uint versionId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerLoadGroup(IntPtr moduleManager, string moduleGroup);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerUnloadGroup(IntPtr moduleManager, string moduleGroup);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerLoadExplicit(IntPtr moduleManager, string moduleId, uint versionId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerUnloadExplicit(IntPtr moduleManager, string moduleId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ModuleManagerFindModule(IntPtr moduleManager, string moduleId, uint versionId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr[] ModuleManagerFindModules(IntPtr moduleManager, bool loadedOnly);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr[] ModuleManagerFindModuleTypes(IntPtr moduleManager, string moduleType, bool loadedOnly);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ModuleManagerCopyModule(IntPtr moduleManager, IntPtr sourceModuleDefinition, string targetModuleId, string targetPath, bool useVersionPathing);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerSynchronizeDependencies(IntPtr moduleManager, IntPtr rootModuleDefinition, string targetDependencyFolder);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerIsModuleMergeAvailable(IntPtr moduleManager);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerCanMergeModules(IntPtr moduleManager, string mergeSourcePath);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ModuleManagerMergeModules(IntPtr moduleManager, string mergeTargetPath, bool removeMergeDefinition, bool registerNewModules);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleManagerAddListener(IntPtr moduleManager, IntPtr listenerObject);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ModuleManagerRemoveListener(IntPtr moduleManager, IntPtr listenerObject);
      }
      
      #endregion

      #region Properties

      public bool EnforceDependencies
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleManagerGetEnforceDependencies(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleManagerSetEnforceDependencies(ObjectPtr->ObjPtr, value);
         }
      }
      public bool EchoInfo
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ModuleManagerGetEchoInfo(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ModuleManagerSetEchoInfo(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public bool SetModuleExtension(string moduleExtension)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerSetModuleExtension(ObjectPtr->ObjPtr, moduleExtension);
      }

      public bool ScanModules(string rootPath, bool rootOnly = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerScanModules(ObjectPtr->ObjPtr, rootPath, rootOnly);
      }

      public bool UnregisterModule(string moduleId, uint versionId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerUnregisterModule(ObjectPtr->ObjPtr, moduleId, versionId);
      }

      public bool LoadGroup(string moduleGroup)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerLoadGroup(ObjectPtr->ObjPtr, moduleGroup);
      }

      public bool UnloadGroup(string moduleGroup)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerUnloadGroup(ObjectPtr->ObjPtr, moduleGroup);
      }

      public bool LoadExplicit(string moduleId, uint versionId = 0)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerLoadExplicit(ObjectPtr->ObjPtr, moduleId, versionId);
      }

      public bool UnloadExplicit(string moduleId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerUnloadExplicit(ObjectPtr->ObjPtr, moduleId);
      }

      public ModuleDefinition FindModule(string moduleId, uint versionId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return new ModuleDefinition(InternalUnsafeMethods.ModuleManagerFindModule(ObjectPtr->ObjPtr, moduleId, versionId));
      }

      public SimObject[] FindModules(bool loadedOnly)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerFindModules(ObjectPtr->ObjPtr, loadedOnly).Select(x => new SimObject(x)).ToArray();
      }

      public SimObject[] FindModuleTypes(string moduleType, bool loadedOnly)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerFindModuleTypes(ObjectPtr->ObjPtr, moduleType, loadedOnly).Select(x => new SimObject(x)).ToArray();
      }

      public string CopyModule(ModuleDefinition sourceModuleDefinition, string targetModuleId, string targetPath, bool useVersionPathing)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerCopyModule(ObjectPtr->ObjPtr, sourceModuleDefinition.ObjectPtr->ObjPtr, targetModuleId, targetPath, useVersionPathing);
      }

      public bool SynchronizeDependencies(ModuleDefinition rootModuleDefinition, string targetDependencyFolder)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerSynchronizeDependencies(ObjectPtr->ObjPtr, rootModuleDefinition.ObjectPtr->ObjPtr, targetDependencyFolder);
      }

      public bool IsModuleMergeAvailable()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerIsModuleMergeAvailable(ObjectPtr->ObjPtr);
      }

      public bool CanMergeModules(string mergeSourcePath)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerCanMergeModules(ObjectPtr->ObjPtr, mergeSourcePath);
      }

      public bool MergeModules(string mergeTargetPath, bool removeMergeDefinition, bool registerNewModules)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ModuleManagerMergeModules(ObjectPtr->ObjPtr, mergeTargetPath, removeMergeDefinition, registerNewModules);
      }

      public void AddListener(SimObject listenerObject)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ModuleManagerAddListener(ObjectPtr->ObjPtr, listenerObject.ObjectPtr->ObjPtr);
      }

      public void RemoveListener(SimObject listenerObject)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.ModuleManagerRemoveListener(ObjectPtr->ObjPtr, listenerObject.ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}