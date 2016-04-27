using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class AudioEnvironment : SimDataBlock
   {
      
      public AudioEnvironment()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.AudioEnvironmentCreateInstance());
      }

      public AudioEnvironment(uint pId) : base(pId)
      {
      }

      public AudioEnvironment(string pName) : base(pName)
      {
      }

      public AudioEnvironment(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public AudioEnvironment(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public AudioEnvironment(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool AudioEnvironmentGetUseRoom(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetUseRoom(IntPtr audioEnvironment, bool useRoom);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioEnvironmentGetRoom(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetRoom(IntPtr audioEnvironment, int room);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioEnvironmentGetRoomHF(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetRoomHF(IntPtr audioEnvironment, int room);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioEnvironmentGetReflections(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetReflections(IntPtr audioEnvironment, int reflections);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioEnvironmentGetReverb(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetReverb(IntPtr audioEnvironment, int reverb);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioEnvironmentGetRoomRolloffFactor(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetRoomRolloffFactor(IntPtr audioEnvironment, float factor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioEnvironmentGetDecayTime(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetDecayTime(IntPtr audioEnvironment, float time);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioEnvironmentGetDecayHFRatio(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetDecayHFRatio(IntPtr audioEnvironment, float ratio);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioEnvironmentGetReflectionsDelay(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetReflectionsDelay(IntPtr audioEnvironment, float delay);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioEnvironmentGetReverbDelay(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetReverbDelay(IntPtr audioEnvironment, float delay);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioEnvironmentGetRoomVolume(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetRoomVolume(IntPtr audioEnvironment, float volume);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioEnvironmentGetEffectVolume(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetEffectVolume(IntPtr audioEnvironment, float volume);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioEnvironmentGetDamping(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetDamping(IntPtr audioEnvironment, float damping);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioEnvironmentGetEnvironmentSize(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetEnvironmentSize(IntPtr audioEnvironment, float size);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioEnvironmentGetEnvironmentDiffusion(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetEnvironmentDiffusion(IntPtr audioEnvironment, float diffusion);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioEnvironmentGetAirAbsorption(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetAirAbsorption(IntPtr audioEnvironment, float absorption);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioEnvironmentGetFlags(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioEnvironmentSetFlags(IntPtr audioEnvironment, int flags);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr AudioEnvironmentCreateInstance();
      }
      
      #endregion

      #region Properties

      public bool UseRoom
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetUseRoom(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetUseRoom(ObjectPtr->ObjPtr, value);
         }
      }
      public int Room
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetRoom(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetRoom(ObjectPtr->ObjPtr, value);
         }
      }
      public int RoomHF
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetRoomHF(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetRoomHF(ObjectPtr->ObjPtr, value);
         }
      }
      public int Reflections
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetReflections(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetReflections(ObjectPtr->ObjPtr, value);
         }
      }
      public int Reverb
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetReverb(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetReverb(ObjectPtr->ObjPtr, value);
         }
      }
      public float RoomRolloffFactor
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetRoomRolloffFactor(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetRoomRolloffFactor(ObjectPtr->ObjPtr, value);
         }
      }
      public float DecayTime
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetDecayTime(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetDecayTime(ObjectPtr->ObjPtr, value);
         }
      }
      public float DecayHFRatio
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetDecayHFRatio(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetDecayHFRatio(ObjectPtr->ObjPtr, value);
         }
      }
      public float ReflectionsDelay
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetReflectionsDelay(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetReflectionsDelay(ObjectPtr->ObjPtr, value);
         }
      }
      public float ReverbDelay
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetReverbDelay(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetReverbDelay(ObjectPtr->ObjPtr, value);
         }
      }
      public float RoomVolume
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetRoomVolume(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetRoomVolume(ObjectPtr->ObjPtr, value);
         }
      }
      public float EffectVolume
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetEffectVolume(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetEffectVolume(ObjectPtr->ObjPtr, value);
         }
      }
      public float Damping
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetDamping(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetDamping(ObjectPtr->ObjPtr, value);
         }
      }
      public float EnvironmentSize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetEnvironmentSize(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetEnvironmentSize(ObjectPtr->ObjPtr, value);
         }
      }
      public float EnvironmentDiffusion
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetEnvironmentDiffusion(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetEnvironmentDiffusion(ObjectPtr->ObjPtr, value);
         }
      }
      public float AirAbsorption
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetAirAbsorption(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetAirAbsorption(ObjectPtr->ObjPtr, value);
         }
      }
      public int Flags
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioEnvironmentGetFlags(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioEnvironmentSetFlags(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}