using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class PopupMenu : SimObject
   {
      
      public PopupMenu()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.PopupMenuCreateInstance());
      }

      public PopupMenu(uint pId) : base(pId)
      {
      }

      public PopupMenu(string pName) : base(pName)
      {
      }

      public PopupMenu(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public PopupMenu(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public PopupMenu(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool PopupMenuGetIsPopup(IntPtr popupMenu);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PopupMenuSetIsPopup(IntPtr popupMenu, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr PopupMenuCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int PopupMenuInsertItem(IntPtr popupMenu, int pos, string title, string accelerator);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PopupMenuRemoveItem(IntPtr popupMenu, int pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int PopupMenuInsertSubMenu(IntPtr popupMenu, int pos, string title, IntPtr submenu);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PopupMenuEnableItem(IntPtr popupMenu, int pos, bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PopupMenuCheckItem(IntPtr popupMenu, int pos, bool checkedValue);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PopupMenuCheckRadioItem(IntPtr popupMenu, int firstPos, int lastPos, int checkPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool PopupMenuIsItemChecked(IntPtr popupMenu, int pos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PopupMenuAttachToMenuBar(IntPtr popupMenu, int pos, string title);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PopupMenuRemoveFromMenuBar(IntPtr popupMenu);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void PopupMenuShowPopup(IntPtr popupMenu, int x, int y);
      }
      
      #endregion

      #region Properties

      public bool IsPopup
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.PopupMenuGetIsPopup(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.PopupMenuSetIsPopup(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public int InsertItem(int pos, string title = null, string accelerator = "")
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.PopupMenuInsertItem(ObjectPtr->ObjPtr, pos, title, accelerator);
      }

      public void RemoveItem(int pos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.PopupMenuRemoveItem(ObjectPtr->ObjPtr, pos);
      }

      public int InsertSubMenu(int pos, string title, PopupMenu submenu)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.PopupMenuInsertSubMenu(ObjectPtr->ObjPtr, pos, title, submenu.ObjectPtr->ObjPtr);
      }

      public void EnableItem(int pos, bool enable)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.PopupMenuEnableItem(ObjectPtr->ObjPtr, pos, enable);
      }

      public void CheckItem(int pos, bool checkedValue)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.PopupMenuCheckItem(ObjectPtr->ObjPtr, pos, checkedValue);
      }

      public void CheckRadioItem(int firstPos, int lastPos, int checkPos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.PopupMenuCheckRadioItem(ObjectPtr->ObjPtr, firstPos, lastPos, checkPos);
      }

      public bool IsItemChecked(int pos)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.PopupMenuIsItemChecked(ObjectPtr->ObjPtr, pos);
      }

      public void AttachToMenuBar(int pos, string title)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.PopupMenuAttachToMenuBar(ObjectPtr->ObjPtr, pos, title);
      }

      public void RemoveFromMenuBar()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.PopupMenuRemoveFromMenuBar(ObjectPtr->ObjPtr);
      }

      public void ShowPopup(int x = -1, int y = -1)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.PopupMenuShowPopup(ObjectPtr->ObjPtr, x, y);
      }
      
      #endregion

      
   }
}