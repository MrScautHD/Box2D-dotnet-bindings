using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Low level shape cast input in generic form. This allows casting an arbitrary point
/// cloud wrap with a radius. For example, a circle is a single point with a non-zero radius.
/// A capsule is two points with a non-zero radius. A box is four points with a zero radius.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ShapeCastInput
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Box2D.B2_MAX_POLYGON_VERTICES)]
    [FieldOffset(0)]
    public Vec2[] points;

    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8)]
    public int count;
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8 + 4)]
    public float radius;
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8 + 8)]
    public Vec2 translation;
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8 + 16)]
    public float maxFraction;
}