using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class AudioAsset : AssetBase
   {
      
      public AudioAsset()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.AudioAssetCreateInstance());
      }

      public AudioAsset(uint pId) : base(pId)
      {
      }

      public AudioAsset(string pName) : base(pName)
      {
      }

      public AudioAsset(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public AudioAsset(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public AudioAsset(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string AudioAssetGetAudioFile(IntPtr audioAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioAssetSetAudioFile(IntPtr audioAsset, string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioAssetGetVolume(IntPtr audioAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioAssetSetVolume(IntPtr audioAsset, float val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioAssetGetVolumeChannel(IntPtr audioAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioAssetSetVolumeChannel(IntPtr audioAsset, int val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AudioAssetGetLooping(IntPtr audioAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioAssetSetLooping(IntPtr audioAsset, bool val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AudioAssetGetStreaming(IntPtr audioAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioAssetSetStreaming(IntPtr audioAsset, bool val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr AudioAssetCreateInstance();
      }
      
      #endregion

      #region Properties

      public string AudioFile
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioAssetGetAudioFile(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioAssetSetAudioFile(ObjectPtr->ObjPtr, value);
         }
      }
      public float Volume
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioAssetGetVolume(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioAssetSetVolume(ObjectPtr->ObjPtr, value);
         }
      }
      public int VolumeChannel
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioAssetGetVolumeChannel(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioAssetSetVolumeChannel(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Looping
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioAssetGetLooping(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioAssetSetLooping(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Streaming
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioAssetGetStreaming(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioAssetSetStreaming(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}