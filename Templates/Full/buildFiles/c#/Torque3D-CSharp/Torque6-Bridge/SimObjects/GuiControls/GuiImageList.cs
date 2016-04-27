using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiImageList : SimObject
   {
      
      public GuiImageList()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiImageListCreateInstance());
      }

      public GuiImageList(uint pId) : base(pId)
      {
      }

      public GuiImageList(string pName) : base(pName)
      {
      }

      public GuiImageList(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiImageList(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiImageList(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiImageListCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiImageListGetImage(IntPtr list, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiImageListClear(IntPtr list);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiImageListCount(IntPtr list);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiImageListRemove(IntPtr list, int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiImageListGetIndex(IntPtr list, string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiImageListInsert(IntPtr list, string path);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public string GetImage(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiImageListGetImage(ObjectPtr->ObjPtr, index);
      }

      public bool Clear()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiImageListClear(ObjectPtr->ObjPtr);
      }

      public int Count()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiImageListCount(ObjectPtr->ObjPtr);
      }

      public bool Remove(int index)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiImageListRemove(ObjectPtr->ObjPtr, index);
      }

      public int GetIndex(string path)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiImageListGetIndex(ObjectPtr->ObjPtr, path);
      }

      public int Insert(string path)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.GuiImageListInsert(ObjectPtr->ObjPtr, path);
      }
      
      #endregion

      
   }
}