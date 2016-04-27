using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Audio
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Audio_OpenALInitDriver();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_OpenALShutdownDriver();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Audio_AlGetString(string ALEnum);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Audio_AlxGetAudioLength(string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Audio_AlxCreateSource(string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_AlxSourceF(int handle, string ALEnum, float value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_AlxSource3F(int handle, string ALEnum, Point3F pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_AlxSourceI(int handle, string ALEnum, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float Audio_AlxGetSourceF(int handle, string ALEnum);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_AlxGetSource3F(int handle, string ALEnum, Point3F outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Audio_AlxGetSourceI(int handle, string ALEnum);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Audio_AlxPlay(string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Audio_AlxPause(uint handle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_AlxUnpause(uint handle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_AlxStop(uint handle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_AlxStopAll();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Audio_AlxIsPlaying(uint handle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_AlxListenerF(string ALEnum, float value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_AlListener3F(string ALEnum, Point3F pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float Audio_AlxGetListenerF(string ALEnum);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_AlGetListener3F(string ALEnum, Point3F outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Audio_AlGetListenerI(string ALEnum);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float Audio_AlxGetChannelVolume(uint channel);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Audio_AlxSetChannelVolume(uint channel, float volume);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float Audio_AlxGetStreamPosition(uint handle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float Audio_AlxGetStreamDuration(uint handle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Audio_StartiOSAudioStream(string assetId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_StopiOSAudioStream(int streamId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Audio_SetiOSAudioStreamVolume(int streamId, float volume);
      }

      #endregion
      
      #region Functions

      public static bool OpenALInitDriver()
      {
         return InternalUnsafeMethods.Audio_OpenALInitDriver();
      }

      public static void OpenALShutdownDriver()
      {
         InternalUnsafeMethods.Audio_OpenALShutdownDriver();
      }

      public static string AlGetString(string ALEnum)
      {
         return InternalUnsafeMethods.Audio_AlGetString(ALEnum);
      }

      public static int AlxGetAudioLength(string assetId)
      {
         return InternalUnsafeMethods.Audio_AlxGetAudioLength(assetId);
      }

      public static int AlxCreateSource(string assetId)
      {
         return InternalUnsafeMethods.Audio_AlxCreateSource(assetId);
      }

      public static void AlxSourceF(int handle, string ALEnum, float value)
      {
         InternalUnsafeMethods.Audio_AlxSourceF(handle, ALEnum, value);
      }

      public static void AlxSource3F(int handle, string ALEnum, Point3F pos)
      {
         InternalUnsafeMethods.Audio_AlxSource3F(handle, ALEnum, pos);
      }

      public static void AlxSourceI(int handle, string ALEnum, int value)
      {
         InternalUnsafeMethods.Audio_AlxSourceI(handle, ALEnum, value);
      }

      public static float AlxGetSourceF(int handle, string ALEnum)
      {
         return InternalUnsafeMethods.Audio_AlxGetSourceF(handle, ALEnum);
      }

      public static void AlxGetSource3F(int handle, string ALEnum, Point3F outPos)
      {
         InternalUnsafeMethods.Audio_AlxGetSource3F(handle, ALEnum, outPos);
      }

      public static int AlxGetSourceI(int handle, string ALEnum)
      {
         return InternalUnsafeMethods.Audio_AlxGetSourceI(handle, ALEnum);
      }

      public static int AlxPlay(string assetId)
      {
         return InternalUnsafeMethods.Audio_AlxPlay(assetId);
      }

      public static bool AlxPause(uint handle)
      {
         return InternalUnsafeMethods.Audio_AlxPause(handle);
      }

      public static void AlxUnpause(uint handle)
      {
         InternalUnsafeMethods.Audio_AlxUnpause(handle);
      }

      public static void AlxStop(uint handle)
      {
         InternalUnsafeMethods.Audio_AlxStop(handle);
      }

      public static void AlxStopAll()
      {
         InternalUnsafeMethods.Audio_AlxStopAll();
      }

      public static bool AlxIsPlaying(uint handle)
      {
         return InternalUnsafeMethods.Audio_AlxIsPlaying(handle);
      }

      public static void AlxListenerF(string ALEnum, float value)
      {
         InternalUnsafeMethods.Audio_AlxListenerF(ALEnum, value);
      }

      public static void AlListener3F(string ALEnum, Point3F pos)
      {
         InternalUnsafeMethods.Audio_AlListener3F(ALEnum, pos);
      }

      public static float AlxGetListenerF(string ALEnum)
      {
         return InternalUnsafeMethods.Audio_AlxGetListenerF(ALEnum);
      }

      public static void AlGetListener3F(string ALEnum, Point3F outPos)
      {
         InternalUnsafeMethods.Audio_AlGetListener3F(ALEnum, outPos);
      }

      public static int AlGetListenerI(string ALEnum)
      {
         return InternalUnsafeMethods.Audio_AlGetListenerI(ALEnum);
      }

      public static float AlxGetChannelVolume(uint channel)
      {
         return InternalUnsafeMethods.Audio_AlxGetChannelVolume(channel);
      }

      public static bool AlxSetChannelVolume(uint channel, float volume)
      {
         return InternalUnsafeMethods.Audio_AlxSetChannelVolume(channel, volume);
      }

      public static float AlxGetStreamPosition(uint handle)
      {
         return InternalUnsafeMethods.Audio_AlxGetStreamPosition(handle);
      }

      public static float AlxGetStreamDuration(uint handle)
      {
         return InternalUnsafeMethods.Audio_AlxGetStreamDuration(handle);
      }

      public static int StartiOSAudioStream(string assetId)
      {
         return InternalUnsafeMethods.Audio_StartiOSAudioStream(assetId);
      }

      public static void StopiOSAudioStream(int streamId)
      {
         InternalUnsafeMethods.Audio_StopiOSAudioStream(streamId);
      }

      public static void SetiOSAudioStreamVolume(int streamId, float volume)
      {
         InternalUnsafeMethods.Audio_SetiOSAudioStreamVolume(streamId, volume);
      }      

      #endregion
   }
}