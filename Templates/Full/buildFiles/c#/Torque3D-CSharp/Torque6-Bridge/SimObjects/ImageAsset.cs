using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects
{
   public unsafe class ImageAsset : AssetBase
   {
      
      public ImageAsset()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.ImageAssetCreateInstance());
      }

      public ImageAsset(uint pId) : base(pId)
      {
      }

      public ImageAsset(string pName) : base(pName)
      {
      }

      public ImageAsset(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public ImageAsset(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public ImageAsset(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ImageAssetGetImageFile(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetImageFile(IntPtr imageAsset, string imageFile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ImageAssetGetForce16Bit(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetForce16Bit(IntPtr imageAsset, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ImageAssetGetFilterMode(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetFilterMode(IntPtr imageAsset, string filterMode);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ImageAssetGetExplicitMode(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetExplicitMode(IntPtr imageAsset, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ImageAssetGetCellRowOrder(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetCellRowOrder(IntPtr imageAsset, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetCellOffsetX(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetCellOffsetX(IntPtr imageAsset, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetCellOffsetY(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetCellOffsetY(IntPtr imageAsset, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetCellStrideX(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetCellStrideX(IntPtr imageAsset, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetCellStrideY(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetCellStrideY(IntPtr imageAsset, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetCellCountX(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetCellCountX(IntPtr imageAsset, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetCellCountY(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetCellCountY(IntPtr imageAsset, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetCellWidth(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetCellWidth(IntPtr imageAsset, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetCellHeight(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void ImageAssetSetCellHeight(IntPtr imageAsset, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr ImageAssetCreateInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetImageWidth(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetImageHeight(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ImageAssetGetImageSize(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ImageAssetGetIsImagePOT(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetFrameCount(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ImageAssetGetFrameSize(IntPtr imageAsset, int frame);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ImageAssetClearExplicitCells(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ImageAssetAddExplicitCell(IntPtr imageAsset, int cellOffsetX, int cellOffsetY, int cellWidth, int cellHeight, string cellName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ImageAssetInsertExplicitCell(IntPtr imageAsset, int cellIndex, int cellOffsetX, int cellOffsetY, int cellWidth, int cellHeight, string cellName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ImageAssetRemoveExplicitCell(IntPtr imageAsset, int cellIdx);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool ImageAssetSetExplicitCell(IntPtr imageAsset, int cellIndex, int cellOffsetX, int cellOffsetY, int cellWidth, int cellHeight, string cellName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetExplicitCellCount(IntPtr imageAsset);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ImageAssetGetExplicitCellOffset(IntPtr imageAsset, int cellIdx);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ImageAssetGetExplicitCellOffsetByName(IntPtr imageAsset, string cellName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetExplicitCellWidth(IntPtr imageAsset, int cellIdx);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetExplicitCellWidthByName(IntPtr imageAsset, string cellName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetExplicitCellHeight(IntPtr imageAsset, int cellIdx);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetExplicitCellHeightByName(IntPtr imageAsset, string cellName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string ImageAssetGetExplicitCellName(IntPtr imageAsset, int cellIdx);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int ImageAssetGetExplicitCellIndex(IntPtr imageAsset, string cellName);
      }
      
      #endregion

      #region Properties

      public string ImageFile
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetImageFile(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetImageFile(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Force16bit
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetForce16Bit(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetForce16Bit(ObjectPtr->ObjPtr, value);
         }
      }
      public string FilterMode
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetFilterMode(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetFilterMode(ObjectPtr->ObjPtr, value);
         }
      }
      public bool ExplicitMode
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetExplicitMode(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetExplicitMode(ObjectPtr->ObjPtr, value);
         }
      }
      public bool CellRowOrder
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetCellRowOrder(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetCellRowOrder(ObjectPtr->ObjPtr, value);
         }
      }
      public int CellOffsetX
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetCellOffsetX(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetCellOffsetX(ObjectPtr->ObjPtr, value);
         }
      }
      public int CellOffsetY
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetCellOffsetY(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetCellOffsetY(ObjectPtr->ObjPtr, value);
         }
      }
      public int CellStrideX
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetCellStrideX(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetCellStrideX(ObjectPtr->ObjPtr, value);
         }
      }
      public int CellStrideY
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetCellStrideY(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetCellStrideY(ObjectPtr->ObjPtr, value);
         }
      }
      public int CellCountX
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetCellCountX(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetCellCountX(ObjectPtr->ObjPtr, value);
         }
      }
      public int CellCountY
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetCellCountY(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetCellCountY(ObjectPtr->ObjPtr, value);
         }
      }
      public int CellWidth
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetCellWidth(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetCellWidth(ObjectPtr->ObjPtr, value);
         }
      }
      public int CellHeight
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.ImageAssetGetCellHeight(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.ImageAssetSetCellHeight(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      public int GetImageWidth()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetImageWidth(ObjectPtr->ObjPtr);
      }

      public int GetImageHeight()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetImageHeight(ObjectPtr->ObjPtr);
      }

      public string GetImageSize()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetImageSize(ObjectPtr->ObjPtr);
      }

      public bool GetIsImagePOT()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetIsImagePOT(ObjectPtr->ObjPtr);
      }

      public int GetFrameCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetFrameCount(ObjectPtr->ObjPtr);
      }

      public string GetFrameSize(int frame)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetFrameSize(ObjectPtr->ObjPtr, frame);
      }

      public bool ClearExplicitCells()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetClearExplicitCells(ObjectPtr->ObjPtr);
      }

      public bool AddExplicitCell(int cellOffsetX, int cellOffsetY, int cellWidth, int cellHeight, string cellName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetAddExplicitCell(ObjectPtr->ObjPtr, cellOffsetX, cellOffsetY, cellWidth, cellHeight, cellName);
      }

      public bool InsertExplicitCell(int cellIndex, int cellOffsetX, int cellOffsetY, int cellWidth, int cellHeight, string cellName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetInsertExplicitCell(ObjectPtr->ObjPtr, cellIndex, cellOffsetX, cellOffsetY, cellWidth, cellHeight, cellName);
      }

      public bool RemoveExplicitCell(int cellIdx)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetRemoveExplicitCell(ObjectPtr->ObjPtr, cellIdx);
      }

      public bool SetExplicitCell(int cellIndex, int cellOffsetX, int cellOffsetY, int cellWidth, int cellHeight, string cellName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetSetExplicitCell(ObjectPtr->ObjPtr, cellIndex, cellOffsetX, cellOffsetY, cellWidth, cellHeight, cellName);
      }

      public int GetExplicitCellCount()
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetExplicitCellCount(ObjectPtr->ObjPtr);
      }

      public string GetExplicitCellOffset(int cellIdx)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetExplicitCellOffset(ObjectPtr->ObjPtr, cellIdx);
      }

      public string GetExplicitCellOffsetByName(string cellName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetExplicitCellOffsetByName(ObjectPtr->ObjPtr, cellName);
      }

      public int GetExplicitCellWidth(int cellIdx)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetExplicitCellWidth(ObjectPtr->ObjPtr, cellIdx);
      }

      public int GetExplicitCellWidthByName(string cellName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetExplicitCellWidthByName(ObjectPtr->ObjPtr, cellName);
      }

      public int GetExplicitCellHeight(int cellIdx)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetExplicitCellHeight(ObjectPtr->ObjPtr, cellIdx);
      }

      public int GetExplicitCellHeightByName(string cellName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetExplicitCellHeightByName(ObjectPtr->ObjPtr, cellName);
      }

      public string GetExplicitCellName(int cellIdx)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetExplicitCellName(ObjectPtr->ObjPtr, cellIdx);
      }

      public int GetExplicitCellIndex(string cellName)
      {
         if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
         return InternalUnsafeMethods.ImageAssetGetExplicitCellIndex(ObjectPtr->ObjPtr, cellName);
      }
      
      #endregion

      
   }
}