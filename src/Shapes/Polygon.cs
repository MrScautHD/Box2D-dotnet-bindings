using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A solid convex polygon. It is assumed that the interior of the polygon is to
/// the left of each edge.
/// Polygons have a maximum number of vertices equal to B2_MAX_POLYGON_VERTICES.
/// In most cases you should not need many vertices for a convex polygon.
/// <b>Warning: DO NOT fill this out manually, instead use a helper function like
/// MakePolygon or MakeBox.</b>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Polygon
{
    /// <summary>
    /// The polygon vertices
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Box2D.B2_MAX_POLYGON_VERTICES)]
    public Vec2[] Vertices;

    /// <summary>
    /// The outward normal vectors of the polygon sides
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Box2D.B2_MAX_POLYGON_VERTICES)]
    public Vec2[] Normals;

    /// <summary>
    /// The centroid of the polygon
    /// </summary>
    public Vec2 Centroid;

    /// <summary>
    /// The external radius for rounded polygons
    /// </summary>
    public float Radius;

    /// <summary>
    /// The number of polygon vertices
    /// </summary>
    public int Count;
}