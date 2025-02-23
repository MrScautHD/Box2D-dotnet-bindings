using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Low level shape cast input in generic form. This allows casting an arbitrary point
/// cloud wrap with a radius. For example, a circle is a single point with a non-zero radius.
/// A capsule is two points with a non-zero radius. A box is four points with a zero radius.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct ShapeCastInput
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Box2D.B2_MAX_POLYGON_VERTICES)]
    public Vec2[] points;

    public int count;
    public float radius;
    public Vec2 translation;
    public float maxFraction;
}