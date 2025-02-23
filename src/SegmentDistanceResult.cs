using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Result of computing the distance between two line segments
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct SegmentDistanceResult
{
    /// <summary>
    /// The closest point on the first segment
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Closest1;

    /// <summary>
    /// The closest point on the second segment
    /// </summary>
    [FieldOffset(8)]
    public Vec2 Closest2;

    /// <summary>
    /// The barycentric coordinate on the first segment
    /// </summary>
    [FieldOffset(16)]
    public float Fraction1;

    /// <summary>
    /// The barycentric coordinate on the second segment
    /// </summary>
    [FieldOffset(20)]
    public float Fraction2;

    /// <summary>
    /// The squared distance between the closest points
    /// </summary>
    [FieldOffset(24)]
    public float DistanceSquared;
}