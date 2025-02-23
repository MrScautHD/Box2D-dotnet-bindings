using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A convex hull. Used to create convex polygons.
/// </summary>
/// <remarks>
/// <b>Warning: Do not modify these values directly, instead use ComputeHull()</b>
/// </remarks>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Hull
{
    /// <summary>
    /// The final points of the hull
    /// </summary>
    public Vec2 Points;

    /// <summary>
    /// The number of points
    /// </summary>
    public int Count;
}