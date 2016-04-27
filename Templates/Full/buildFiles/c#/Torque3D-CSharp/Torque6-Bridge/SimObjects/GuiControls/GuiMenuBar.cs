using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiMenuBar : GuiTickCtrl
   {
      
      public GuiMenuBar()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiMenuBarCreateInstance());
      }

      public GuiMenuBar(uint pId) : base(pId)
      {
      }

      public GuiMenuBar(string pName) : base(pName)
      {
      }

      public GuiMenuBar(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMenuBar(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiMenuBar(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiMenuBarGetPadding(IntPtr menuBar);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetPadding(IntPtr menuBar, int padding);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiMenuBarCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarClearMenus(IntPtr menuBar);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetMenuMargins(IntPtr menuBar, int horizontalMargin, int verticalMargin, int bitmapToTextSpacing);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarAddMenu(IntPtr menuBar, string menuName, int menuID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarAddMenuItem(IntPtr menuBar, string menuName, string menuItemName, int menuItemID, string accelerator, int checkGroup);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetMenuItemEnable(IntPtr menuBar, string menuName, string menuItemName, bool enabled);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetCheckmarkBitmapIndex(IntPtr menuBar, int bitmapIndex);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetMenuItemChecked(IntPtr menuBar, string menuName, string menuItemName, bool check);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetMenuText(IntPtr menuBar, string menuName, string newMenuText);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetMenuBitmapIndex(IntPtr menuBar, string menuName, int bitmapIndex, bool bitmapOnly, bool drawBorder);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetMenuVisible(IntPtr menuBar, string menuName, bool visible);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetMenuItemText(IntPtr menuBar, string menuName, string menuItemName, string newMenuItemText);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetMenuItemVisible(IntPtr menuBar, string menuName, string menuItemName, bool visible);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetMenuItemBitmap(IntPtr menuBar, string menuName, string menuItemName, int bitmapIndex);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarRemoveMenuItem(IntPtr menuBar, string menuName, string menuItemName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarClearMenuItems(IntPtr menuBar, string menuName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarRemoveMenu(IntPtr menuBar, string menuName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetMenuItemSubmenuState(IntPtr menuBar, string menuName, string menuItemName, bool inSubmenu);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarAddSubmenuItem(IntPtr menuBar, string menuName, string menuItemName, string submenuItemText, int submenuItemId, string accelerator, int checkGroup);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarClearSubmenuItems(IntPtr menuBar, string menuName, string menuItemName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiMenuBarSetSubmenuItemChecked(IntPtr menuBar, string menuName, string menuItemName, string submenuItemText, bool check);
      }
      
      #endregion

      #region Properties

      public int Padding
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiMenuBarGetPadding(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiMenuBarSetPadding(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public void ClearMenus()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarClearMenus(ObjectPtr->ObjPtr);
      }

      public void SetMenuMargins(int horizontalMargin, int verticalMargin, int bitmapToTextSpacing)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetMenuMargins(ObjectPtr->ObjPtr, horizontalMargin, verticalMargin, bitmapToTextSpacing);
      }

      public void AddMenu(string menuName, int menuID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarAddMenu(ObjectPtr->ObjPtr, menuName, menuID);
      }

      public void AddMenuItem(string menuName, string menuItemName, int menuItemID, string accelerator, int checkGroup)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarAddMenuItem(ObjectPtr->ObjPtr, menuName, menuItemName, menuItemID, accelerator, checkGroup);
      }

      public void SetMenuItemEnable(string menuName, string menuItemName, bool enabled)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetMenuItemEnable(ObjectPtr->ObjPtr, menuName, menuItemName, enabled);
      }

      public void SetCheckmarkBitmapIndex(int bitmapIndex)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetCheckmarkBitmapIndex(ObjectPtr->ObjPtr, bitmapIndex);
      }

      public void SetMenuItemChecked(string menuName, string menuItemName, bool check)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetMenuItemChecked(ObjectPtr->ObjPtr, menuName, menuItemName, check);
      }

      public void SetMenuText(string menuName, string newMenuText)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetMenuText(ObjectPtr->ObjPtr, menuName, newMenuText);
      }

      public void SetMenuBitmapIndex(string menuName, int bitmapIndex, bool bitmapOnly, bool drawBorder)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetMenuBitmapIndex(ObjectPtr->ObjPtr, menuName, bitmapIndex, bitmapOnly, drawBorder);
      }

      public void SetMenuVisible(string menuName, bool visible)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetMenuVisible(ObjectPtr->ObjPtr, menuName, visible);
      }

      public void SetMenuItemText(string menuName, string menuItemName, string newMenuItemText)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetMenuItemText(ObjectPtr->ObjPtr, menuName, menuItemName, newMenuItemText);
      }

      public void SetMenuItemVisible(string menuName, string menuItemName, bool visible)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetMenuItemVisible(ObjectPtr->ObjPtr, menuName, menuItemName, visible);
      }

      public void SetMenuItemBitmap(string menuName, string menuItemName, int bitmapIndex)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetMenuItemBitmap(ObjectPtr->ObjPtr, menuName, menuItemName, bitmapIndex);
      }

      public void RemoveMenuItem(string menuName, string menuItemName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarRemoveMenuItem(ObjectPtr->ObjPtr, menuName, menuItemName);
      }

      public void ClearMenuItems(string menuName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarClearMenuItems(ObjectPtr->ObjPtr, menuName);
      }

      public void RemoveMenu(string menuName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarRemoveMenu(ObjectPtr->ObjPtr, menuName);
      }

      public void SetMenuItemSubmenuState(string menuName, string menuItemName, bool inSubmenu)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetMenuItemSubmenuState(ObjectPtr->ObjPtr, menuName, menuItemName, inSubmenu);
      }

      public void AddSubmenuItem(string menuName, string menuItemName, string submenuItemText, int submenuItemId, string accelerator, int checkGroup)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarAddSubmenuItem(ObjectPtr->ObjPtr, menuName, menuItemName, submenuItemText, submenuItemId, accelerator, checkGroup);
      }

      public void ClearSubmenuItems(string menuName, string menuItemName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarClearSubmenuItems(ObjectPtr->ObjPtr, menuName, menuItemName);
      }

      public void SetSubmenuItemChecked(string menuName, string menuItemName, string submenuItemText, bool check)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiMenuBarSetSubmenuItemChecked(ObjectPtr->ObjPtr, menuName, menuItemName, submenuItemText, check);
      }
      
      #endregion

      
   }
}