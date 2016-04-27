using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class LangTable : SimObject
   {
      
      public LangTable()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.LangTableCreateInstance());
      }

      public LangTable(uint pId) : base(pId)
      {
      }

      public LangTable(string pName) : base(pName)
      {
      }

      public LangTable(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public LangTable(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public LangTable(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr LangTableCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int LangTableAddLanguage(IntPtr langTable, string filename, string languageName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string LangTableGetString(IntPtr langTable, int langString);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void LangTableSetDefaultLanguage(IntPtr langTable, int language);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void LangTableSetCurrentLanguage(IntPtr langTable, int language);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int LangTableGetCurrentLanguage(IntPtr langTable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string LangTableGetLangName(IntPtr langTable, int language);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int LangTableGetNumLang(IntPtr langTable);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public int AddLanguage(string filename, string languageName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.LangTableAddLanguage(ObjectPtr->ObjPtr, filename, languageName);
      }

      public string GetString(int langString)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.LangTableGetString(ObjectPtr->ObjPtr, langString);
      }

      public void SetDefaultLanguage(int language)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.LangTableSetDefaultLanguage(ObjectPtr->ObjPtr, language);
      }

      public void SetCurrentLanguage(int language)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.LangTableSetCurrentLanguage(ObjectPtr->ObjPtr, language);
      }

      public int GetCurrentLanguage()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.LangTableGetCurrentLanguage(ObjectPtr->ObjPtr);
      }

      public string GetLangName(int language)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.LangTableGetLangName(ObjectPtr->ObjPtr, language);
      }

      public int GetNumLang()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.LangTableGetNumLang(ObjectPtr->ObjPtr);
      }
      
      #endregion

      
   }
}