using System;
using System.Runtime.InteropServices;

namespace Torque3D_CSharp.Framework
{
   class CustomMarshalling
   {
      public static string[] IntPtrToStringArray(IntPtr ptr, int count)
      {
         //convert the received pointer into a pointer array
         IntPtr[] stringPointers = new IntPtr[count];
         Marshal.Copy(ptr, stringPointers, 0, count);
         //convert the pointer array into a string array
         string[] strings = new string[count];
         for (int i = 0; i < count; i++)
            strings[i] = Marshal.PtrToStringAnsi(stringPointers[i]);
         return strings;
      }
   }
}
