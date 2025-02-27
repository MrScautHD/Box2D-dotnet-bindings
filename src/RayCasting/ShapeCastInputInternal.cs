using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Low level shape cast input in generic form. This allows casting an arbitrary point
/// cloud wrap with a radius. For example, a circle is a single point with a non-zero radius.
/// A capsule is two points with a non-zero radius. A box is four points with a zero radius.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
unsafe struct ShapeCastInputInternal
{
    [FieldOffset(0)]
    internal nint Points;
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8)]
    internal int Count;
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8 + 4)]
    internal float Radius;
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8 + 8)]
    internal Vec2 Translation;
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8 + 16)]
    internal float MaxFraction;
}