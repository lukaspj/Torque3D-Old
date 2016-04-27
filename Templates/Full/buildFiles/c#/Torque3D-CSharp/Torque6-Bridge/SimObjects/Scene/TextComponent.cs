using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class TextComponent : BaseComponent
   {
      
      public TextComponent()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.TextComponentCreateInstance());
      }

      public TextComponent(uint pId) : base(pId)
      {
      }

      public TextComponent(string pName) : base(pName)
      {
      }

      public TextComponent(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public TextComponent(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public TextComponent(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr TextComponentCreateInstance();
      }
      
      #endregion

      #region Properties

      
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}