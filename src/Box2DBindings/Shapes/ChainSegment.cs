using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A line segment with one-sided collision. Only collides on the right side.
/// Several of these are generated for a chain shape.<br/>
/// ghost1 -> point1 -> point2 -> ghost2
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ChainSegment
{
    /// <summary>
    /// The tail ghost vertex
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Ghost1;

    /// <summary>
    /// The line segment
    /// </summary>
    [FieldOffset(8)]
    public Segment Segment; // 16 bytes

    /// <summary>
    /// The head ghost vertex
    /// </summary>
    [FieldOffset(24)]
    public Vec2 Ghost2;

    /// <summary>
    /// The owning chain shape index (internal usage only)
    /// </summary>
    [FieldOffset(32)]
    public int ChainId;
}