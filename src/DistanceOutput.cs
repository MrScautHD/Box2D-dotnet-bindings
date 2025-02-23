using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Output for ShapeDistance
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct DistanceOutput
{
    /// <summary>
    /// Closest point on shape A
    /// </summary>
    public Vec2 PointA;

    /// <summary>
    /// Closest point on shape B
    /// </summary>
    public Vec2 PointB;

    /// <summary>
    /// The final distance, zero if overlapped
    /// </summary>
    public float Distance;

    /// <summary>
    /// Number of GJK iterations used
    /// </summary>
    public int Iterations;

    /// <summary>
    /// The number of simplexes stored in the simplex array
    /// </summary>
    public int SimplexCount;
}