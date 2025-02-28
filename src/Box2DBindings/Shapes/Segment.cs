using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A line segment with two-sided collision.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Segment
{
    /// <summary>
    /// The first point
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Point1;

    /// <summary>
    /// The second point
    /// </summary>
    [FieldOffset(8)]
    public Vec2 Point2;
    
    /// <summary>
    /// Compute the bounding box of a transformed line segment
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeSegmentAABB")]
    private static extern AABB ComputeSegmentAABB(in Segment shape, in Transform transform);
    
    /// <summary>
    /// Compute the bounding box of this transformed line segment
    /// </summary>
    public AABB ComputeAABB(in Transform transform) => ComputeSegmentAABB(this, transform);

    /// <summary>
    /// Ray cast versus segment shape in local space. Optionally treat the segment as one-sided with hits from
    /// the left side being treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastSegment")]
    private static extern CastOutput RayCastSegment(in RayCastInput input, in Segment shape, bool oneSided);
    
    /// <summary>
    /// Ray cast versus this segment shape in local space. Optionally treat the segment as one-sided with hits from
    /// the left side being treated as a miss.
    /// </summary>
    public CastOutput RayCast(in RayCastInput input, bool oneSided) => RayCastSegment(input, this, oneSided);

    /// <summary>
    /// Shape cast versus a line segment. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastSegment")]
    private static extern CastOutput ShapeCastSegment(in ShapeCastInputInternal input, in Segment shape);

    /// <summary>
    /// Shape cast versus this line segment. Initial overlap is treated as a miss.
    /// </summary>
    public CastOutput ShapeCast(in ShapeCastInput input) => ShapeCastSegment(input._internal, this);
 
    /// <summary>
    /// Compute the distance between two line segments, clamping at the end points if needed.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SegmentDistance")]
    private static extern SegmentDistanceResult SegmentDistance(in Vec2 p1, in Vec2 q1, in Vec2 p2, in Vec2 q2);

    /// <summary>
    /// Compute the distance between this line segment and another line segment, clamping at the end points if needed.
    /// </summary>
    public SegmentDistanceResult SegmentDistance(in Segment segmentB) =>
        SegmentDistance(Point1, Point2, segmentB.Point1, segmentB.Point2);

    
}