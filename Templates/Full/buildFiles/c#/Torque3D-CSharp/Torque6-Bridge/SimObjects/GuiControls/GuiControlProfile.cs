using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.GuiControls
{
   public unsafe class GuiControlProfile : SimObject
   {
      
      public GuiControlProfile()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.GuiControlProfileCreateInstance());
      }

      public GuiControlProfile(uint pId) : base(pId)
      {
      }

      public GuiControlProfile(string pName) : base(pName)
      {
      }

      public GuiControlProfile(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public GuiControlProfile(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public GuiControlProfile(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlProfileGetTab(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetTab(IntPtr controlProfile, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlProfileGetCanKeyFocus(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetCanKeyFocus(IntPtr controlProfile, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlProfileGetMouseOverSelected(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetMouseOverSelected(IntPtr controlProfile, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlProfileGetModal(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetModal(IntPtr controlProfile, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlProfileGetOpaque(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetOpaque(IntPtr controlProfile, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetFillColor(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFillColor(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetFillColorHL(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFillColorHL(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetFillColorNA(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFillColorNA(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlProfileGetBorder(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetBorder(IntPtr controlProfile, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlProfileGetBorderThickness(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetBorderThickness(IntPtr controlProfile, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetBorderColor(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetBorderColor(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetBorderColorHL(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetBorderColorHL(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetBorderColorNA(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetBorderColorNA(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetBevelColorHL(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetBevelColorHL(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetBevelColorLL(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetBevelColorLL(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiControlProfileGetFontType(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFontType(IntPtr controlProfile, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlProfileGetFontSize(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFontSize(IntPtr controlProfile, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlProfileGetFontCharset(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFontCharset(IntPtr controlProfile, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetFontColors(IntPtr controlProfile, int index, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFontColors(IntPtr controlProfile, int index, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetFontColor(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFontColor(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetFontColorHL(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFontColorHL(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetFontColorNA(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFontColorNA(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetFontColorSEL(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFontColorSEL(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetFontColorLink(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFontColorLink(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetFontColorLinkHL(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetFontColorLinkHL(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int GuiControlProfileGetJustify(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetJustify(IntPtr controlProfile, int value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern Point2I GuiControlProfileGetTextOffset(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetTextOffset(IntPtr controlProfile, Point2I value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlProfileGetAutoSizeWidth(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetAutoSizeWidth(IntPtr controlProfile, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlProfileGetAutoSizeHeight(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetAutoSizeHeight(IntPtr controlProfile, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlProfileGetReturnTab(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetReturnTab(IntPtr controlProfile, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool GuiControlProfileGetNumbersOnly(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetNumbersOnly(IntPtr controlProfile, bool value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileGetCursorColor(IntPtr controlProfile, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetCursorColor(IntPtr controlProfile, Color value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string GuiControlProfileGetBitmap(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetBitmap(IntPtr controlProfile, string value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiControlProfileGetSoundButtonDown(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetSoundButtonDown(IntPtr controlProfile, IntPtr value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiControlProfileGetSoundButtonOver(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetSoundButtonOver(IntPtr controlProfile, IntPtr value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiControlProfileGetProfileForChildren(IntPtr controlProfile);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void GuiControlProfileSetProfileForChildren(IntPtr controlProfile, IntPtr value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr GuiControlProfileCreateInstance();
      }
      
      #endregion

      #region Properties

      public bool Tab
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetTab(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetTab(ObjectPtr->ObjPtr, value);
         }
      }
      public bool CanKeyFocus
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetCanKeyFocus(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetCanKeyFocus(ObjectPtr->ObjPtr, value);
         }
      }
      public bool MouseOverSelected
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetMouseOverSelected(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetMouseOverSelected(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Modal
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetModal(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetModal(ObjectPtr->ObjPtr, value);
         }
      }
      public bool Opaque
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetOpaque(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetOpaque(ObjectPtr->ObjPtr, value);
         }
      }
      public Color FillColor
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetFillColor(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFillColor(ObjectPtr->ObjPtr, value);
         }
      }
      public Color FillColorHL
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetFillColorHL(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFillColorHL(ObjectPtr->ObjPtr, value);
         }
      }
      public Color FillColorNA
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetFillColorNA(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFillColorNA(ObjectPtr->ObjPtr, value);
         }
      }
      public int Border
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetBorder(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetBorder(ObjectPtr->ObjPtr, value);
         }
      }
      public int BorderThickness
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetBorderThickness(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetBorderThickness(ObjectPtr->ObjPtr, value);
         }
      }
      public Color BorderColor
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetBorderColor(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetBorderColor(ObjectPtr->ObjPtr, value);
         }
      }
      public Color BorderColorHL
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetBorderColorHL(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetBorderColorHL(ObjectPtr->ObjPtr, value);
         }
      }
      public Color BorderColorNA
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetBorderColorNA(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetBorderColorNA(ObjectPtr->ObjPtr, value);
         }
      }
      public Color BevelColorHL
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetBevelColorHL(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetBevelColorHL(ObjectPtr->ObjPtr, value);
         }
      }
      public Color BevelColorLL
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetBevelColorLL(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetBevelColorLL(ObjectPtr->ObjPtr, value);
         }
      }
      public string FontType
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetFontType(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFontType(ObjectPtr->ObjPtr, value);
         }
      }
      public int FontSize
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetFontSize(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFontSize(ObjectPtr->ObjPtr, value);
         }
      }
      public int FontCharset
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetFontCharset(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFontCharset(ObjectPtr->ObjPtr, value);
         }
      }

      public FieldVector<Color> FontColors
      {
         get
         {
            return new FieldVector<Color>(this, 10, InternalUnsafeMethods.GuiControlProfileGetFontColors,
               InternalUnsafeMethods.GuiControlProfileSetFontColors);
         }
      }
      public Color FontColor
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetFontColor(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFontColor(ObjectPtr->ObjPtr, value);
         }
      }
      public Color FontColorHL
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetFontColorHL(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFontColorHL(ObjectPtr->ObjPtr, value);
         }
      }
      public Color FontColorNA
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetFontColorNA(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFontColorNA(ObjectPtr->ObjPtr, value);
         }
      }
      public Color FontColorSEL
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetFontColorSEL(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFontColorSEL(ObjectPtr->ObjPtr, value);
         }
      }
      public Color FontColorLink
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetFontColorLink(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFontColorLink(ObjectPtr->ObjPtr, value);
         }
      }
      public Color FontColorLinkHL
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetFontColorLinkHL(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetFontColorLinkHL(ObjectPtr->ObjPtr, value);
         }
      }
      public int Justify
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetJustify(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetJustify(ObjectPtr->ObjPtr, value);
         }
      }
      public Point2I TextOffset
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetTextOffset(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetTextOffset(ObjectPtr->ObjPtr, value);
         }
      }
      public bool AutoSizeWidth
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetAutoSizeWidth(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetAutoSizeWidth(ObjectPtr->ObjPtr, value);
         }
      }
      public bool AutoSizeHeight
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetAutoSizeHeight(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetAutoSizeHeight(ObjectPtr->ObjPtr, value);
         }
      }
      public bool ReturnTab
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetReturnTab(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetReturnTab(ObjectPtr->ObjPtr, value);
         }
      }
      public bool NumbersOnly
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetNumbersOnly(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetNumbersOnly(ObjectPtr->ObjPtr, value);
         }
      }
      public Color CursorColor
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.GuiControlProfileGetCursorColor(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetCursorColor(ObjectPtr->ObjPtr, value);
         }
      }
      public string Bitmap
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.GuiControlProfileGetBitmap(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetBitmap(ObjectPtr->ObjPtr, value);
         }
      }
      public AudioAsset SoundButtonDown
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return new AudioAsset(InternalUnsafeMethods.GuiControlProfileGetSoundButtonDown(ObjectPtr->ObjPtr));
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetSoundButtonDown(ObjectPtr->ObjPtr, value.ObjectPtr->ObjPtr);
         }
      }
      public AudioAsset SoundButtonOver
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return new AudioAsset(InternalUnsafeMethods.GuiControlProfileGetSoundButtonOver(ObjectPtr->ObjPtr));
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetSoundButtonOver(ObjectPtr->ObjPtr, value.ObjectPtr->ObjPtr);
         }
      }
      public GuiControlProfile ProfileForChildren
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return new GuiControlProfile(InternalUnsafeMethods.GuiControlProfileGetProfileForChildren(ObjectPtr->ObjPtr));
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.GuiControlProfileSetProfileForChildren(ObjectPtr->ObjPtr, value.ObjectPtr->ObjPtr);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}