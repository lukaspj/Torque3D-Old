using System;

namespace Torque6_Bridge.Utility
{
   class Exceptions
   {
      public class SimObjectPointerInvalidException : Exception
      {
         public SimObjectPointerInvalidException()
            : base("The SimObject was invalid, this usually happens if you try to use an object after it has been deleted.")
         {
         }

         public SimObjectPointerInvalidException(string message)
            : base(message)
         {
         }

         public SimObjectPointerInvalidException(string message, Exception inner)
            : base(message, inner)
         {
         }
      }
   }
}
