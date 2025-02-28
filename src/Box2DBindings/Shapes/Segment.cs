using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A line segment with two-sided collision.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Segment
{
    /// <summary>
    /// The first point
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Point1;

    /// <summary>
    /// The second point
    /// </summary>
    [FieldOffset(8)]
    public Vec2 Point2;
}