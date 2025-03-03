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
    
    /// <summary>
    /// Make a convex polygon from a convex hull. This will assert if the hull is not valid.
    /// </summary>
    /// <remarks>
    /// <b>Warning: Do not manually fill in the hull data, it must come directly from b2ComputeHull</b>
    /// </remarks>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakePolygon")]
    public static extern Polygon MakePolygon(in Hull hull, float radius);
    
#if BOX2D_300

    /*
     * 
       /// Make an offset convex polygon from a convex hull. This will assert if the hull is not valid.
       /// @warning Do not manually fill in the hull data, it must come directly from b2ComputeHull
       B2_API b2Polygon b2MakeOffsetPolygon( const b2Hull* hull, float radius, b2Transform transform );
       
     */
    
    /// <summary>
    /// Make an offset convex polygon from a convex hull. This will assert if the hull is not valid.
    /// </summary>
    /// <remarks>
    /// <b>Warning: Do not manually fill in the hull data, it must come directly from b2ComputeHull</b>
    /// </remarks>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeOffsetPolygon")]
    public static extern Polygon MakeOffsetPolygon(in Hull hull, float radius, in Transform transform);
    
#else
    
    /// <summary>
    /// Make an offset convex polygon from a convex hull. This will assert if the hull is not valid.
    /// </summary>
    /// <remarks>
    /// <b>Warning: Do not manually fill in the hull data, it must come directly from b2ComputeHull</b>
    /// </remarks>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeOffsetPolygon")]
    public static extern Polygon MakeOffsetPolygon(in Hull hull, in Vec2 position, in Rotation rotation);
    
    /// <summary>
    /// Make an offset convex polygon from a convex hull. This will assert if the hull is not valid.
    /// </summary>
    /// <remarks>
    /// <b>Warning: Do not manually fill in the hull data, it must come directly from b2ComputeHull</b>
    /// </remarks>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeOffsetRoundedPolygon")]
    public static extern Polygon MakeOffsetRoundedPolygon(in Hull hull, in Vec2 position, in Rotation rotation, float radius);
#endif
    /// <summary>
    /// Make a square polygon, bypassing the need for a convex hull.
    /// </summary>
    /// <param name="halfWidth">the half-width</param>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeSquare")]
    public static extern Polygon MakeSquare(float halfWidth);

    /// <summary>
    /// Make a box (rectangle) polygon, bypassing the need for a convex hull.
    /// </summary>
    /// <param name="halfWidth">the half-width (x-axis)</param>
    /// <param name="halfHeight">the half-height (y-axis)</param>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeBox")]
    public static extern Polygon MakeBox(float halfWidth, float halfHeight);

    /// <summary>
    /// Make a rounded box, bypassing the need for a convex hull.
    /// </summary>
    /// <param name="halfWidth">the half-width (x-axis)</param>
    /// <param name="halfHeight">the half-height (y-axis)</param>
    /// <param name="radius">the radius of the rounded extension</param>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeRoundedBox")]
    public static extern Polygon MakeRoundedBox(float halfWidth, float halfHeight, float radius);

#if BOX2D_300
    
    /// <summary>
    /// Make an offset box, bypassing the need for a convex hull.
    /// </summary>
    /// <param name="halfWidth">the half-width (x-axis)</param>
    /// <param name="halfHeight">the half-height (y-axis)</param>
    /// <param name="center">the local center of the box</param>
    /// <param name="angle">the local rotation of the box</param>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeOffsetBox")]
    public static extern Polygon MakeOffsetBox(float halfWidth, float halfHeight, in Vec2 center, in float angle);
    
#else
    /// <summary>
    /// Make an offset box, bypassing the need for a convex hull.
    /// </summary>
    /// <param name="halfWidth">the half-width (x-axis)</param>
    /// <param name="halfHeight">the half-height (y-axis)</param>
    /// <param name="center">the local center of the box</param>
    /// <param name="rotation">the local rotation of the box</param>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeOffsetBox")]
    public static extern Polygon MakeOffsetBox(float halfWidth, float halfHeight, in Vec2 center, in Rotation rotation);

    /// <summary>
    /// Make an offset rounded box, bypassing the need for a convex hull.
    /// </summary>
    /// <param name="halfWidth">the half-width (x-axis)</param>
    /// <param name="halfHeight">the half-height (y-axis)</param>
    /// <param name="center">the local center of the box</param>
    /// <param name="rotation">the local rotation of the box</param>
    /// <param name="radius">the radius of the rounded extension</param>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeOffsetRoundedBox")]
    public static extern Polygon MakeOffsetRoundedBox(float halfWidth, float halfHeight, in Vec2 center, in Rotation rotation, float radius);
#endif
    /// <summary>
    /// Transform a polygon. This is useful for transferring a shape from one body to another.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2TransformPolygon")]
    public static extern Polygon TransformPolygon(in Transform transform, in Polygon polygon);
    
    /// <summary>
    /// Compute mass properties of a polygon
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputePolygonMass")]
    private static extern MassData ComputePolygonMass(in Polygon shape, float density);
    
    /// <summary>
    /// Compute mass properties of this polygon
    /// </summary>
    public MassData ComputeMass(float density) => ComputePolygonMass(this, density);

    /// <summary>
    /// Compute the bounding box of a transformed polygon
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputePolygonAABB")]
    private static extern AABB ComputePolygonAABB(in Polygon shape, in Transform transform);
    
    /// <summary>
    /// Compute the bounding box of this transformed polygon
    /// </summary>
    public AABB ComputeAABB(in Transform transform) => ComputePolygonAABB(this, transform);
    
    /// <summary>
    /// Test a point for overlap with a convex polygon in local space
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInPolygon")]
    private static extern bool PointInPolygon(in Vec2 point, in Polygon shape);

    /// <summary>
    /// Test this point for overlap with a convex polygon in local space
    /// </summary>
    public bool TestPoint(in Vec2 point) => PointInPolygon(point, this);
    
    /// <summary>
    /// Ray cast versus polygon shape in local space. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastPolygon")]
    private static extern CastOutput RayCastPolygon(in RayCastInput input, in Polygon shape);
    
    /// <summary>
    /// Ray cast versus this polygon shape in local space. Initial overlap is treated as a miss.
    /// </summary>
    public CastOutput RayCast(in RayCastInput input) => RayCastPolygon(input, this);

    /// <summary>
    /// Shape cast versus a convex polygon. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastPolygon")]
    private static extern CastOutput ShapeCastPolygon(in ShapeCastInputInternal input, in Polygon shape);

    /// <summary>
    /// Shape cast versus this convex polygon. Initial overlap is treated as a miss.
    /// </summary>
    public CastOutput ShapeCast(in ShapeCastInput input) => ShapeCastPolygon(input._internal, this);
    
    

}