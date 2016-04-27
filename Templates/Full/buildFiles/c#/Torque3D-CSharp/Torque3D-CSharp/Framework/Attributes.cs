using System;

namespace Torque3D_CSharp.Framework
{
   [AttributeUsage(AttributeTargets.Class)]
   class ConsoleClassAttribute : Attribute
   {
      public string ConsoleName { get; private set; }

      public ConsoleClassAttribute(string pConsoleName = null)
      {
         ConsoleName = pConsoleName;
      }
   }

   [AttributeUsage(AttributeTargets.Method)]
   class ConsoleFunctionAttribute : Attribute
   {
      public string FunctionName { get; private set; }

      public ConsoleFunctionAttribute(string pFunctionName = null)
      {
         FunctionName = pFunctionName;
      }
   }

   [AttributeUsage(AttributeTargets.Method)]
   class ScriptEntryPointAttribute : Attribute
   {
   }
}
