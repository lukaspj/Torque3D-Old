using Torque3D_CSharp.Framework;

namespace Torque3D_CSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Torque6Main.Libraries libraries = new Torque6Main.Libraries
            {
                Windows32bit = "Full_DEBUG DLL.dll",
                Windows64bit = "Full_DEBUG DLL.dll",
                Linux32bit = "Full_DEBUG DLL.so",
                Linux64bit = "Full_DEBUG DLL.so"
            };
            Torque6Main.InitializeTorque6(args, libraries);
        }
    }
}
