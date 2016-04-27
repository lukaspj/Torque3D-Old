using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class LightComponent : BaseComponent
   {
      
      public LightComponent()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.LightComponentCreateInstance());
      }

      public LightComponent(uint pId) : base(pId)
      {
      }

      public LightComponent(string pName) : base(pName)
      {
      }

      public LightComponent(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public LightComponent(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public LightComponent(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float LightComponentGetRadius(IntPtr LightComponent);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void LightComponentSetRadius(IntPtr LightComponent, float radius);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void LightComponentGetColor(IntPtr LightComponent, out Color outColor);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void LightComponentSetColor(IntPtr LightComponent, Color Color);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern float LightComponentGetAttenuation(IntPtr LightComponent);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void LightComponentSetAttenuation(IntPtr LightComponent, float Attenuation);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr LightComponentCreateInstance();
      }
      
      #endregion

      #region Properties

      public float Radius
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.LightComponentGetRadius(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.LightComponentSetRadius(ObjectPtr->ObjPtr, value);
         }
      }
      public Color Color
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Color outVal;
            InternalUnsafeMethods.LightComponentGetColor(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.LightComponentSetColor(ObjectPtr->ObjPtr, value);
         }
      }
      public float Attenuation
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.LightComponentGetAttenuation(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.LightComponentSetAttenuation(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}