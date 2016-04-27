using System;
using System.Linq;
using System.Runtime.InteropServices;
using Torque6_Bridge.Namespaces;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.SimObjects.Scene
{
   public unsafe class Vec3Node : BaseNode
   {
      
      public Vec3Node()
      {
         ObjectPtr = Sim.WrapObject(InternalUnsafeMethods.Vec3NodeCreateInstance());
      }

      public Vec3Node(uint pId) : base(pId)
      {
      }

      public Vec3Node(string pName) : base(pName)
      {
      }

      public Vec3Node(IntPtr pObjPtr) : base(pObjPtr)
      {
      }

      public Vec3Node(Sim.SimObjectPtr* pObjPtr) : base(pObjPtr)
      {
      }

      public Vec3Node(SimObject pObj) : base(pObj)
      {
      }
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Vec3NodeGetUniformName(IntPtr vec3Node);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Vec3NodeSetUniformName(IntPtr vec3Node, string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Vec3NodeGetValue(IntPtr vec3Node, out Point3F val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Vec3NodeSetValue(IntPtr vec3Node, Point3F val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr Vec3NodeCreateInstance();
      }
      
      #endregion

      #region Properties

      public string UniformName
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            return InternalUnsafeMethods.Vec3NodeGetUniformName(ObjectPtr->ObjPtr);
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.Vec3NodeSetUniformName(ObjectPtr->ObjPtr, value);
         }
      }
      public Point3F Value
      {
         get
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            Point3F outVal;
            InternalUnsafeMethods.Vec3NodeGetValue(ObjectPtr->ObjPtr, out outVal);
            return outVal;
         }
         set
         {
            if (IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            InternalUnsafeMethods.Vec3NodeSetValue(ObjectPtr->ObjPtr, value);
         }
      }
      
      #endregion
      
      #region Methods

      
      
      #endregion

      
   }
}