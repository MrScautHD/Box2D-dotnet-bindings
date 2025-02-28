using System;
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
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Polygon
{
    /// <summary>
    /// The polygon vertices
    /// </summary>
    [FieldOffset(0)]
    private nint* vertices;

    /// <summary>
    /// The outward normal vectors of the polygon sides
    /// </summary>
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8)]
    private nint* normals;

    /// <summary>
    /// The centroid of the polygon
    /// </summary>
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8 * 2)]
    public Vec2 Centroid;

    /// <summary>
    /// The external radius for rounded polygons
    /// </summary>
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8 * 2 + 8)] 
    public float Radius;

    /// <summary>
    /// The number of polygon vertices
    /// </summary>
    [FieldOffset(Box2D.B2_MAX_POLYGON_VERTICES * 8 * 2 + 12)]
    private int count;
    
    public ReadOnlySpan<Vec2> Vertices => new(vertices, count);
    public ReadOnlySpan<Vec2> Normals => new(normals, count);
}