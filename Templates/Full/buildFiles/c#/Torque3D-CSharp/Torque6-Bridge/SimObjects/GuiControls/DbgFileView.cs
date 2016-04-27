using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class DbgFileView : GuiArrayCtrl
   {
      
      public DbgFileView()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.DbgFileViewCreateInstance());
      }

      public DbgFileView(uint pId) : base(pId)
      {
      }

      public DbgFileView(string pName) : base(pName)
      {
      }

      public DbgFileView(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public DbgFileView(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public DbgFileView(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr DbgFileViewCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DbgFileViewSetCurrentLine(IntPtr view, int line, bool selected);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string DbgFileViewGetCurrentLine(IntPtr view, int line, bool selected);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool DbgFileViewOpen(IntPtr view, string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DbgFileViewClearBreakPositions(IntPtr view);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DbgFileViewSetBreakPosition(IntPtr view, int line);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DbgFileViewSetBreak(IntPtr view, int line);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void DbgFileViewRemoveBreak(IntPtr view, int line);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool DbgFileViewFindString(IntPtr view, string findThis);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public void SetCurrentLine(int line, bool selected)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.DbgFileViewSetCurrentLine(ObjectPtr->ObjPtr, line, selected);
      }

      public string GetCurrentLine(int line, bool selected)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.DbgFileViewGetCurrentLine(ObjectPtr->ObjPtr, line, selected);
      }

      public bool Open(string fileName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.DbgFileViewOpen(ObjectPtr->ObjPtr, fileName);
      }

      public void ClearBreakPositions()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.DbgFileViewClearBreakPositions(ObjectPtr->ObjPtr);
      }

      public void SetBreakPosition(int line)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.DbgFileViewSetBreakPosition(ObjectPtr->ObjPtr, line);
      }

      public void SetBreak(int line)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.DbgFileViewSetBreak(ObjectPtr->ObjPtr, line);
      }

      public void RemoveBreak(int line)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.DbgFileViewRemoveBreak(ObjectPtr->ObjPtr, line);
      }

      public bool FindString(string findThis)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.DbgFileViewFindString(ObjectPtr->ObjPtr, findThis);
      }
      
      #endregion

      
   }
}