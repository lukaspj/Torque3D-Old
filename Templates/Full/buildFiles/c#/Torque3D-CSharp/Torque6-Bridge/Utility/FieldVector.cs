using System;
using Torque6_Bridge.SimObjects;

namespace Torque6_Bridge.Utility
{
   public class FieldVector<T> where T : new()
   {
      public delegate T GetterFunction(IntPtr objectPtr, int index);

      public delegate void OutGetterFunction(IntPtr objectPtr, int index, out T outVal);

      public delegate void SetterFunction(IntPtr objectPtr, int index, T val);

      private readonly GetterFunction _GetterFunction;
      private readonly OutGetterFunction _OutGetterFunction;
      private readonly SimObject _OwnerObject;
      private readonly SetterFunction _SetterFunction;
      private int _Count;

      public FieldVector(SimObject pSimObject, int pCount, GetterFunction pGetterFunction,
         SetterFunction pSetterFunction)
      {
         _OwnerObject = pSimObject;
         _Count = pCount;
         _GetterFunction = pGetterFunction;
         _OutGetterFunction = null;
         _SetterFunction = pSetterFunction;
      }

      public FieldVector(SimObject pSimObject, int pCount, OutGetterFunction pOutGetterFunction,
         SetterFunction pSetterFunction)
      {
         _OwnerObject = pSimObject;
         _Count = pCount;
         _GetterFunction = null;
         _OutGetterFunction = pOutGetterFunction;
         _SetterFunction = pSetterFunction;
      }

      public unsafe T this[int index]
      {
         get
         {
            if (_OwnerObject.IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            if (index >= _Count)
               throw new IndexOutOfRangeException();
            if (_GetterFunction != null)
               return _GetterFunction(_OwnerObject.ObjectPtr->ObjPtr, index);
            T col = new T();
            _OutGetterFunction(_OwnerObject.ObjectPtr->ObjPtr, index, out col);
            return col;
         }
         set
         {
            if (_OwnerObject.IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            if (index >= _Count)
               throw new IndexOutOfRangeException();
            _SetterFunction(_OwnerObject.ObjectPtr->ObjPtr, index, value);
         }
      }
   }

   public class PrimitiveFieldVector<T>
   {
      public delegate T GetterFunction(IntPtr objectPtr, int index);

      public delegate void OutGetterFunction(IntPtr objectPtr, int index, out T outVal);

      public delegate void SetterFunction(IntPtr objectPtr, int index, T val);

      private readonly GetterFunction _GetterFunction;
      private readonly OutGetterFunction _OutGetterFunction;
      private readonly SimObject _OwnerObject;
      private readonly SetterFunction _SetterFunction;
      private int _Count;

      public PrimitiveFieldVector(SimObject pSimObject, int pCount, GetterFunction pGetterFunction,
         SetterFunction pSetterFunction)
      {
         _OwnerObject = pSimObject;
         _Count = pCount;
         _GetterFunction = pGetterFunction;
         _OutGetterFunction = null;
         _SetterFunction = pSetterFunction;
      }

      public PrimitiveFieldVector(SimObject pSimObject, int pCount, OutGetterFunction pOutGetterFunction,
         SetterFunction pSetterFunction)
      {
         _OwnerObject = pSimObject;
         _Count = pCount;
         _GetterFunction = null;
         _OutGetterFunction = pOutGetterFunction;
         _SetterFunction = pSetterFunction;
      }

      public unsafe T this[int index]
      {
         get
         {
            if (_OwnerObject.IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            if (index >= _Count)
               throw new IndexOutOfRangeException();
            if (_GetterFunction != null)
               return _GetterFunction(_OwnerObject.ObjectPtr->ObjPtr, index);
            T col;
            _OutGetterFunction(_OwnerObject.ObjectPtr->ObjPtr, index, out col);
            return col;
         }
         set
         {
            if (_OwnerObject.IsDead()) throw new Exceptions.SimObjectPointerInvalidException();
            if (index >= _Count)
               throw new IndexOutOfRangeException();
            _SetterFunction(_OwnerObject.ObjectPtr->ObjPtr, index, value);
         }
      }
   }
}