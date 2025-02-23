using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Output for ShapeDistance
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct DistanceOutput
{
    /// <summary>
    /// Closest point on shape A
    /// </summary>
    [FieldOffset(0)]
    public Vec2 PointA;

    /// <summary>
    /// Closest point on shape B
    /// </summary>
    [FieldOffset(8)]
    public Vec2 PointB;

    /// <summary>
    /// The final distance, zero if overlapped
    /// </summary>
    [FieldOffset(16)]
    public float Distance;

    /// <summary>
    /// Number of GJK iterations used
    /// </summary>
    [FieldOffset(20)]
    public int Iterations;

    /// <summary>
    /// The number of simplexes stored in the simplex array
    /// </summary>
    [FieldOffset(24)]
    public int SimplexCount;
}