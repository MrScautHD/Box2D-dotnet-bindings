using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A distance proxy is used by the GJK algorithm. It encapsulates any shape.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ShapeProxy
{
    /// <summary>
    /// The point cloud
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Points;
    
    /// <summary>
    /// The number of points
    /// </summary>
    [FieldOffset(8)]
    public int Count;
    
    /// <summary>
    /// The external radius of the point cloud
    /// </summary>
    [FieldOffset(12)]
    public float Radius;
}