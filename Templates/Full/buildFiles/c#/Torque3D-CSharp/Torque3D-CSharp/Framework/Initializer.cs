using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Torque3D_CSharp.Framework
{
   class Initializer
   {

      private static MethodInfo mScriptEntryPointMethodInfo = null;

      public static MethodInfo GetScriptEntry()
      {
         return mScriptEntryPointMethodInfo;
      }

      public static void InitializeTypeDictionaries()
      {
         var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes());
         foreach (Type type in types)
         {
            IEnumerable<ConsoleClassAttribute> attributes =
                  type.GetCustomAttributes<ConsoleClassAttribute>(false);
            if (attributes.Any())
            {
               EngineCallbacks.RegisterType(attributes.First().ConsoleName ?? type.Name, type);
            }
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
               IEnumerable<ConsoleFunctionAttribute> functionAttributes =
                     methodInfo.GetCustomAttributes<ConsoleFunctionAttribute>(false);
               if (functionAttributes.Any())
                  EngineCallbacks.RegisterFunction(functionAttributes.First().FunctionName ?? methodInfo.Name, methodInfo);

               IEnumerable<ScriptEntryPointAttribute> entryAttribute =
                     methodInfo.GetCustomAttributes<ScriptEntryPointAttribute>(false);
               if (entryAttribute.Any())
               {
                  if (methodInfo.IsStatic && !methodInfo.GetParameters().Any() && methodInfo.ReturnType == typeof (void))
                  {
                     mScriptEntryPointMethodInfo = methodInfo;
                  }
                  else
                  {
                     Console.WriteLine("ScriptEntry method: " + methodInfo.Name + " did not match the necessary signature.");
                  }
               }
            }
         }
      }
   }
}
