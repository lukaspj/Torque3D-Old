using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Game
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Game_SaveJournal(string namedFile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Game_PlayJournal(string filePath, bool doBreak);
      }

      #endregion
      
      #region Functions

      public static void SaveJournal(string namedFile)
      {
         InternalUnsafeMethods.Game_SaveJournal(namedFile);
      }

      public static void PlayJournal(string filePath, bool doBreak)
      {
         InternalUnsafeMethods.Game_PlayJournal(filePath, doBreak);
      }      

      #endregion
   }
}