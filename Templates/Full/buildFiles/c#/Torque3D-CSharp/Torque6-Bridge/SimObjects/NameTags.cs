using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class NameTags : SimSet
   {
      
      public NameTags()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.NameTagsCreateInstance());
      }

      public NameTags(uint pId) : base(pId)
      {
      }

      public NameTags(string pName) : base(pName)
      {
      }

      public NameTags(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public NameTags(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public NameTags(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr NameTagsCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int NameTagsCreateTag(IntPtr nameTags, string newTagName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int NameTagsRenameTag(IntPtr nameTags, int tagId, string newTagName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int NameTagsDeleteTag(IntPtr nameTags, int tagId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int NameTagsGetTagCount(IntPtr nameTags);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string NameTagsGetTagName(IntPtr nameTags, int tagId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int NameTagsGetTagId(IntPtr nameTags, string tagName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string NameTagsGetAllTags(IntPtr nameTags);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool NameTagsTag(IntPtr nameTags, int objectId, int tagIdsC, int[] tagIdsV);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool NameTagsUntag(IntPtr nameTags, int objectId, int tagIdsC, int[] tagIdsV);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool NameTagsHasTag(IntPtr nameTags, int objectId, int tagIdsC, int[] tagIdsV);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string NameTagsQueryTags(IntPtr nameTags, int tagIdsC, int[] tagIdsV, bool excluded);
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      public int CreateTag(string newTagName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsCreateTag(ObjectPtr->ObjPtr, newTagName);
      }

      public int RenameTag(int tagId, string newTagName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsRenameTag(ObjectPtr->ObjPtr, tagId, newTagName);
      }

      public int DeleteTag(int tagId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsDeleteTag(ObjectPtr->ObjPtr, tagId);
      }

      public int GetTagCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsGetTagCount(ObjectPtr->ObjPtr);
      }

      public string GetTagName(int tagId)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsGetTagName(ObjectPtr->ObjPtr, tagId);
      }

      public int GetTagId(string tagName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsGetTagId(ObjectPtr->ObjPtr, tagName);
      }

      public string GetAllTags()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsGetAllTags(ObjectPtr->ObjPtr);
      }

      public bool Tag(int objectId, int tagIdsC, int[] tagIdsV)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsTag(ObjectPtr->ObjPtr, objectId, tagIdsC, tagIdsV);
      }

      public bool Untag(int objectId, int tagIdsC, int[] tagIdsV)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsUntag(ObjectPtr->ObjPtr, objectId, tagIdsC, tagIdsV);
      }

      public bool HasTag(int objectId, int tagIdsC, int[] tagIdsV)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsHasTag(ObjectPtr->ObjPtr, objectId, tagIdsC, tagIdsV);
      }

      public string QueryTags(int tagIdsC, int[] tagIdsV, bool excluded = false)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.NameTagsQueryTags(ObjectPtr->ObjPtr, tagIdsC, tagIdsV, excluded);
      }
      
      #endregion

      
   }
}