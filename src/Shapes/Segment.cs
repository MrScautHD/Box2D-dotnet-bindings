using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A line segment with two-sided collision.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Segment
{
    /// <summary>
    /// The first point
    /// </summary>
    public Vec2 Point1;

    /// <summary>
    /// The second point
    /// </summary>
    public Vec2 Point2;
}