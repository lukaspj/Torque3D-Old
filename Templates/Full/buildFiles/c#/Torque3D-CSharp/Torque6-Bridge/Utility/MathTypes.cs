using System.Runtime.InteropServices;

namespace Torque6_Bridge.Types
{
   [StructLayout(LayoutKind.Sequential)]
   public struct Color
   {
      public int R;
      public int G;
      public int B;
      public int A;

      public Color(int pR, int pG, int pB)
      {
         R = pR;
         G = pG;
         B = pB;
         A = 255;
      }

      public Color(float pR, float pG, float pB)
      {
         R = (int) (255*pR);
         G = (int) (255*pG);
         B = (int) (255*pB);
         A = 255;
      }
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct Point2I
   {
      public int x;
      public int y;
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct Point2F
   {
      public float x;
      public float y;
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct Point3I
   {
      public int x;
      public int y;
      public int z;
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct Point3F
   {
      public float x;
      public float y;
      public float z;

      public Point3F(float pX, float pY, float pZ)
      {
         x = pX;
         y = pY;
         z = pZ;
      }

      public static Point3F Zero()
      {
         return new Point3F(0, 0, 0);
      }
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct Point4F
   {
      public Point4F(float pX, float pY, float pZ, float pW)
      {
         x = pX;
         y = pY;
         z = pZ;
         w = pW;
      }

      public float x;
      public float y;
      public float z;
      public float w;
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct Box3F
   {
      public Box3F(Point3F pMinExtents, Point3F pMaxExtents)
      {
         minExtents = pMinExtents;
         maxExtents = pMaxExtents;
      }

      public Point3F minExtents;
      public Point3F maxExtents;
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct RectI
   {
      public RectI(Point2I pPosition, Point2I pExtents)
      {
         position  = pPosition;
         extents = pExtents;
      }

      public Point2I position;
      public Point2I extents;
   }
}