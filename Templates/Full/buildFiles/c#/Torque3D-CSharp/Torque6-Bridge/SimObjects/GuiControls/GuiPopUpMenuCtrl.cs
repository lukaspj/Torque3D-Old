using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiPopUpMenuCtrl : GuiTextCtrl
   {
      
      public GuiPopUpMenuCtrl()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiPopUpMenuCtrlCreateInstance());
      }

      public GuiPopUpMenuCtrl(uint pId) : base(pId)
      {
      }

      public GuiPopUpMenuCtrl(string pName) : base(pName)
      {
      }

      public GuiPopUpMenuCtrl(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiPopUpMenuCtrl(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiPopUpMenuCtrl(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiPopUpMenuCtrlCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlAdd(IntPtr ctrl, string entryText, int entryID, int entryScheme);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlAddScheme(IntPtr ctrl, int entryScheme, Color fontColor, Color fontColorHL, Color fontColorSEL);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlSetText(IntPtr ctrl, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiPopUpMenuCtrlGetText(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlClear(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlSort(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlSortID(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlForceOnAction(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlClosePopUp(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiPopUpMenuCtrlGetSelected(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlSetSelected(IntPtr ctrl, int id, bool scriptCallback);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlSetFirstSelected(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlSetNoneSelected(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiPopUpMenuCtrlGetTextById(IntPtr ctrl, int ID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlSetEnumContent(IntPtr ctrl, string contentClass, string contentEnum);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiPopUpMenuCtrlFindText(IntPtr ctrl, string text);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiPopUpMenuCtrlSize(IntPtr ctrl);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiPopUpMenuCtrlReplaceText(IntPtr ctrl, bool enable);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public void Add(string entryText, int entryID, int entryScheme)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlAdd(ObjectPtr->ObjPtr, entryText, entryID, entryScheme);
      }

      public void AddScheme(int entryScheme, Color fontColor, Color fontColorHL, Color fontColorSEL)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlAddScheme(ObjectPtr->ObjPtr, entryScheme, fontColor, fontColorHL, fontColorSEL);
      }

      public void SetText(string text)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlSetText(ObjectPtr->ObjPtr, text);
      }

      public string GetText()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiPopUpMenuCtrlGetText(ObjectPtr->ObjPtr);
      }

      public void Clear()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlClear(ObjectPtr->ObjPtr);
      }

      public void Sort()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlSort(ObjectPtr->ObjPtr);
      }

      public void SortID()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlSortID(ObjectPtr->ObjPtr);
      }

      public void ForceOnAction()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlForceOnAction(ObjectPtr->ObjPtr);
      }

      public void ClosePopUp()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlClosePopUp(ObjectPtr->ObjPtr);
      }

      public int GetSelected()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiPopUpMenuCtrlGetSelected(ObjectPtr->ObjPtr);
      }

      public void SetSelected(int id, bool scriptCallback)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlSetSelected(ObjectPtr->ObjPtr, id, scriptCallback);
      }

      public void SetFirstSelected()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlSetFirstSelected(ObjectPtr->ObjPtr);
      }

      public void SetNoneSelected()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlSetNoneSelected(ObjectPtr->ObjPtr);
      }

      public string GetTextById(int ID)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiPopUpMenuCtrlGetTextById(ObjectPtr->ObjPtr, ID);
      }

      public void SetEnumContent(string contentClass, string contentEnum)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlSetEnumContent(ObjectPtr->ObjPtr, contentClass, contentEnum);
      }

      public int FindText(string text)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiPopUpMenuCtrlFindText(ObjectPtr->ObjPtr, text);
      }

      public int Size()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiPopUpMenuCtrlSize(ObjectPtr->ObjPtr);
      }

      public void ReplaceText(bool enable)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         InternalUnsafeMethods.GuiPopUpMenuCtrlReplaceText(ObjectPtr->ObjPtr, enable);
      }
      
      #endregion

      
   }
}