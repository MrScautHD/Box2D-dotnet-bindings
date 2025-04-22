using JetBrains.Annotations;
using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A line segment with two-sided collision.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Segment : IEquatable<Segment>
{
    /// <summary>
    /// The first point
    /// </summary>
    public Vec2 Point1;

    /// <summary>
    /// The second point
    /// </summary>
    public Vec2 Point2;

    [PublicAPI]
    public Segment(Vec2 point1, Vec2 point2)
    {
        Point1 = point1;
        Point2 = point2;
    }
    
    public static implicit operator Vec2[](Segment segment) => [segment.Point1, segment.Point2];
    
    /// <summary>
    /// Compute the bounding box of a transformed line segment
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeSegmentAABB")]
    private static extern AABB ComputeSegmentAABB(in Segment shape, Transform transform);
    
    /// <summary>
    /// Compute the bounding box of this transformed line segment
    /// </summary>
    [PublicAPI]
    public AABB ComputeAABB(in Transform transform) => ComputeSegmentAABB(in this, transform);

    /// <summary>
    /// Ray cast versus segment shape in local space. Optionally treat the segment as one-sided with hits from
    /// the left side being treated as a miss.
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastSegment")]
    private static extern CastOutput RayCastSegment(in RayCastInput input, in Segment shape, bool oneSided);
    
    /// <summary>
    /// Ray cast versus this segment shape in local space. Optionally treat the segment as one-sided with hits from
    /// the left side being treated as a miss.
    /// </summary>
    [PublicAPI]
    public CastOutput RayCast(in RayCastInput input, bool oneSided) => RayCastSegment(in input, in this, oneSided);

    /// <summary>
    /// Shape cast versus a line segment. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastSegment")]
    private static extern CastOutput ShapeCastSegment(in ShapeCastInput input, in Segment shape);

    /// <summary>
    /// Shape cast versus this line segment. Initial overlap is treated as a miss.
    /// </summary>
    [PublicAPI]
    public CastOutput ShapeCast(in ShapeCastInput input) => ShapeCastSegment(in input, in this);
 
    /// <summary>
    /// Compute the distance between two line segments, clamping at the end points if needed.
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SegmentDistance")]
    private static extern SegmentDistanceResult SegmentDistance(Vec2 p1, Vec2 q1, Vec2 p2, Vec2 q2);

    /// <summary>
    /// Compute the distance between this line segment and another line segment, clamping at the end points if needed.
    /// </summary>
    [PublicAPI]
    public SegmentDistanceResult SegmentDistance(in Segment segmentB) =>
        SegmentDistance(Point1, Point2, segmentB.Point1, segmentB.Point2);
    
    public bool Equals(Segment other) =>
        Point1.Equals(other.Point1) && Point2.Equals(other.Point2);
    
    public override bool Equals(object? obj) =>
        obj is Segment other && Equals(other);
    
    public override int GetHashCode() =>
        HashCode.Combine(Point1, Point2);
}