using System;
using System.Collections.Generic;
using System.Reflection;
using Torque6_Bridge.SimObjects;

namespace Torque3D_CSharp.Framework
{
   internal class EngineCallbacks
   {
      private static readonly Dictionary<string, Type> ClassTypeDictionary = new Dictionary<string, Type>();
      private static readonly Dictionary<string, MethodInfo> FunctionDictionary = new Dictionary<string, MethodInfo>();

      public static void RegisterType(string className, Type classType)
      {
         ClassTypeDictionary.Add(className, classType);
      }

      public static void RegisterFunction(string functionName, MethodInfo methodInfo)
      {
         FunctionDictionary.Add(functionName, methodInfo);
      }

      public static string CallScriptFunction(string pFunctionName, object[] args, out bool found)
      {
         if (!FunctionDictionary.ContainsKey(pFunctionName))
         {
            found = false;
            return null;
         }
         found = true;
         MethodInfo methodInfo = FunctionDictionary[pFunctionName];
         if (methodInfo.ReturnType == typeof (string))
            return (string) methodInfo.Invoke(null, args);
         methodInfo.Invoke(null, args);
         return null;
      }

      public static string CallScriptMethod(string className, SimObject objectWrapper, string methodName, object[] args,
         out bool found)
      {
         if (!ClassTypeDictionary.ContainsKey(className))
         {
            found = false;
            return null; // TODO throw exception            
         }
         Type type = ClassTypeDictionary[className];
         MethodInfo callbackMethod = type.GetMethod(methodName);
         if (callbackMethod != null)
         {
            found = true;
            object simObj = null;
            if (!callbackMethod.IsStatic)
               simObj = objectWrapper;
            if (callbackMethod.ReturnType == typeof (string))
               return (string) callbackMethod.Invoke(simObj, args);
            callbackMethod.Invoke(simObj, args);
            return null;
         }
         found = false;
         return null;
      }

      public static bool IsMethod(string className, string methodName)
      {
         if (!ClassTypeDictionary.ContainsKey(className))
            return false;
         return ClassTypeDictionary[className].GetMethod(methodName) != null;
      }
   }
}