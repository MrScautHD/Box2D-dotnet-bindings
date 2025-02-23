using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A distance proxy is used by the GJK algorithm. It encapsulates any shape.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct ShapeProxy
{
    /// <summary>
    /// The point cloud
    /// </summary>
    public Vec2 Points;
    
    /// <summary>
    /// The number of points
    /// </summary>
    public int Count;
    
    /// <summary>
    /// The external radius of the point cloud
    /// </summary>
    public float Radius;
}