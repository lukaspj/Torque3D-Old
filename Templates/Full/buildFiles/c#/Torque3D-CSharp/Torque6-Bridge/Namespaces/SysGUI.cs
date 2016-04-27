using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class SysGUI
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SysGUI_SetEnabled(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_BeginScrollArea(string title, uint x, uint y, uint width, uint height);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_EndScrollArea();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_BeginCollapse(string label, string text, bool open);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_EndCollapse();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_ColorWheel(string label, Color col);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_Separator();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_Vector3(string label, Point3F vec3);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_Label(string label);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_TextInput(string label, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_Button(string label, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_CheckBox(string label, bool isChecked);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_Slider(string label, int value, int min, int max);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SysGUI_GetLabelValue(int id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SysGUI_SetLabelValue(int id, string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SysGUI_GetTextValue(int id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SysGUI_SetTextValue(int id, string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_GetIntValue(int id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool SysGUI_GetBoolValue(int id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SysGUI_AlignLeft(int id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SysGUI_AlignRight(int id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SysGUI_AlignTop(int id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SysGUI_AlignBottom(int id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_List();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SysGUI_AddListValue(int id, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string SysGUI_GetListValue(int id, int idx);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int SysGUI_GetListSelected(int id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SysGUI_ClearList(int id);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void SysGUI_SetElementHidden(int id, bool hidden);
      }

      #endregion
      
      #region Functions

      public static void SetEnabled(bool enable)
      {
         InternalUnsafeMethods.SysGUI_SetEnabled(enable);
      }

      public static int BeginScrollArea(string title, uint x, uint y, uint width, uint height)
      {
         return InternalUnsafeMethods.SysGUI_BeginScrollArea(title, x, y, width, height);
      }

      public static int EndScrollArea()
      {
         return InternalUnsafeMethods.SysGUI_EndScrollArea();
      }

      public static int BeginCollapse(string label, string text, bool open)
      {
         return InternalUnsafeMethods.SysGUI_BeginCollapse(label, text, open);
      }

      public static int EndCollapse()
      {
         return InternalUnsafeMethods.SysGUI_EndCollapse();
      }

      public static int ColorWheel(string label, Color col)
      {
         return InternalUnsafeMethods.SysGUI_ColorWheel(label, col);
      }

      public static int Separator()
      {
         return InternalUnsafeMethods.SysGUI_Separator();
      }

      public static int Vector3(string label, Point3F vec3)
      {
         return InternalUnsafeMethods.SysGUI_Vector3(label, vec3);
      }

      public static int Label(string label)
      {
         return InternalUnsafeMethods.SysGUI_Label(label);
      }

      public static int TextInput(string label, string text)
      {
         return InternalUnsafeMethods.SysGUI_TextInput(label, text);
      }

      public static int Button(string label, string text)
      {
         return InternalUnsafeMethods.SysGUI_Button(label, text);
      }

      public static int CheckBox(string label, bool isChecked)
      {
         return InternalUnsafeMethods.SysGUI_CheckBox(label, isChecked);
      }

      public static int Slider(string label, int value, int min, int max)
      {
         return InternalUnsafeMethods.SysGUI_Slider(label, value, min, max);
      }

      public static string GetLabelValue(int id)
      {
         return InternalUnsafeMethods.SysGUI_GetLabelValue(id);
      }

      public static void SetLabelValue(int id, string val)
      {
         InternalUnsafeMethods.SysGUI_SetLabelValue(id, val);
      }

      public static string GetTextValue(int id)
      {
         return InternalUnsafeMethods.SysGUI_GetTextValue(id);
      }

      public static void SetTextValue(int id, string val)
      {
         InternalUnsafeMethods.SysGUI_SetTextValue(id, val);
      }

      public static int GetIntValue(int id)
      {
         return InternalUnsafeMethods.SysGUI_GetIntValue(id);
      }

      public static bool GetBoolValue(int id)
      {
         return InternalUnsafeMethods.SysGUI_GetBoolValue(id);
      }

      public static void AlignLeft(int id)
      {
         InternalUnsafeMethods.SysGUI_AlignLeft(id);
      }

      public static void AlignRight(int id)
      {
         InternalUnsafeMethods.SysGUI_AlignRight(id);
      }

      public static void AlignTop(int id)
      {
         InternalUnsafeMethods.SysGUI_AlignTop(id);
      }

      public static void AlignBottom(int id)
      {
         InternalUnsafeMethods.SysGUI_AlignBottom(id);
      }

      public static int List()
      {
         return InternalUnsafeMethods.SysGUI_List();
      }

      public static void AddListValue(int id, string value)
      {
         InternalUnsafeMethods.SysGUI_AddListValue(id, value);
      }

      public static string GetListValue(int id, int idx)
      {
         return InternalUnsafeMethods.SysGUI_GetListValue(id, idx);
      }

      public static int GetListSelected(int id)
      {
         return InternalUnsafeMethods.SysGUI_GetListSelected(id);
      }

      public static void ClearList(int id)
      {
         InternalUnsafeMethods.SysGUI_ClearList(id);
      }

      public static void SetElementHidden(int id, bool hidden)
      {
         InternalUnsafeMethods.SysGUI_SetElementHidden(id, hidden);
      }      

      #endregion
   }
}