using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class AudioSampleEnvironment : SimDataBlock
   {
      
      public AudioSampleEnvironment()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.AudioSampleEnvironmentCreateInstance());
      }

      public AudioSampleEnvironment(uint pId) : base(pId)
      {
      }

      public AudioSampleEnvironment(string pName) : base(pName)
      {
      }

      public AudioSampleEnvironment(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public AudioSampleEnvironment(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public AudioSampleEnvironment(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioSampleEnvironmentGetDirect(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetDirect(IntPtr audioEnvironment, int direct);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioSampleEnvironmentGetDirectHF(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetDirectHF(IntPtr audioEnvironment, int directHF);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioSampleEnvironmentGetRoom(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetRoom(IntPtr audioEnvironment, int room);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioSampleEnvironmentGetObstruction(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetObstruction(IntPtr audioEnvironment, float obstruction);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioSampleEnvironmentGetObstructionLFRatio(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetObstructionLFRatio(IntPtr audioEnvironment, float ratio);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioSampleEnvironmentGetOcclusion(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetOcclusion(IntPtr audioEnvironment, float occlusion);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioSampleEnvironmentGetOcclusionLFRatio(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetOcclusionLFRatio(IntPtr audioEnvironment, float ratio);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioSampleEnvironmentGetOcclusionRoomRatio(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetOcclusionRoomRatio(IntPtr audioEnvironment, float ratio);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioSampleEnvironmentGetRoomRolloff(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetRoomRolloff(IntPtr audioEnvironment, float rolloff);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float AudioSampleEnvironmentGetAirAbsorption(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetAirAbsorption(IntPtr audioEnvironment, float absorption);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioSampleEnvironmentGetOutsideVolumeHF(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetOutsideVolumeHF(IntPtr audioEnvironment, int volume);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int AudioSampleEnvironmentGetFlags(IntPtr audioEnvironment);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void AudioSampleEnvironmentSetFlags(IntPtr audioEnvironment, int flags);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr AudioSampleEnvironmentCreateInstance();
      }
      
      #endregion

      #region Properties

      public int Direct
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetDirect(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetDirect(ObjectPtr->ObjPtr, value);
         }
      }
      public int DirectHF
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetDirectHF(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetDirectHF(ObjectPtr->ObjPtr, value);
         }
      }
      public int Room
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetRoom(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetRoom(ObjectPtr->ObjPtr, value);
         }
      }
      public float Obstruction
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetObstruction(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetObstruction(ObjectPtr->ObjPtr, value);
         }
      }
      public float ObstructionLFRatio
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetObstructionLFRatio(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetObstructionLFRatio(ObjectPtr->ObjPtr, value);
         }
      }
      public float Occlusion
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetOcclusion(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetOcclusion(ObjectPtr->ObjPtr, value);
         }
      }
      public float OcclusionLFRatio
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetOcclusionLFRatio(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetOcclusionLFRatio(ObjectPtr->ObjPtr, value);
         }
      }
      public float OcclusionRoomRatio
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetOcclusionRoomRatio(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetOcclusionRoomRatio(ObjectPtr->ObjPtr, value);
         }
      }
      public float RoomRolloff
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetRoomRolloff(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetRoomRolloff(ObjectPtr->ObjPtr, value);
         }
      }
      public float AirAbsorption
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetAirAbsorption(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetAirAbsorption(ObjectPtr->ObjPtr, value);
         }
      }
      public int OutsideVolumeHF
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetOutsideVolumeHF(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetOutsideVolumeHF(ObjectPtr->ObjPtr, value);
         }
      }
      public int Flags
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.AudioSampleEnvironmentGetFlags(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.AudioSampleEnvironmentSetFlags(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}