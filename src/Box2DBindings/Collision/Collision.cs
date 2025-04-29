using JetBrains.Annotations;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Functions for computing contact manifolds.
/// </summary>
public static class Collision
{
    /// <summary>
    /// Compute the contact manifold between two circles
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCircles")]
    [PublicAPI]
    public static extern Manifold Collide(in Circle circleA, Transform xfA, in Circle circleB, Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a capsule and circle
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCapsuleAndCircle")]
    [PublicAPI]
    public static extern Manifold Collide(in Capsule capsuleA, Transform xfA, in Circle circleB, Transform xfB);

    /// <summary>
    /// Compute the contact manifold between an segment and a circle
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndCircle")]
    [PublicAPI]
    public static extern Manifold Collide(in Segment segmentA, Transform xfA, in Circle circleB, Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a polygon and a circle
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygonAndCircle")]
    [PublicAPI]
    public static extern Manifold Collide(in Polygon polygonA, Transform xfA, in Circle circleB, Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a capsule and circle
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCapsules")]
    [PublicAPI]
    public static extern Manifold Collide(in Capsule capsuleA, Transform xfA, in Capsule capsuleB, Transform xfB);

    /// <summary>
    /// Compute the contact manifold between an segment and a capsule
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndCapsule")]
    [PublicAPI]
    public static extern Manifold Collide(in Segment segmentA, Transform xfA, in Capsule capsuleB, Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a polygon and capsule
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygonAndCapsule")]
    [PublicAPI]
    public static extern Manifold Collide(in Polygon polygonA, Transform xfA, in Capsule capsuleB, Transform xfB);

    /// <summary>
    /// Compute the contact manifold between two polygons
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygons")]
    [PublicAPI]
    public static extern Manifold Collide(in Polygon polygonA, Transform xfA, in Polygon polygonB, Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a segment and a polygon
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndPolygon")]
    [PublicAPI]
    public static extern Manifold Collide(in Segment segmentA, Transform xfA, in Polygon polygonB, Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a chain segment and a circle
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideChainSegmentAndCircle")]
    [PublicAPI]
    public static extern Manifold Collide(in ChainSegment segmentA, Transform xfA, in Circle circleB, Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a chain segment and a capsule
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideChainSegmentAndCapsule")]
    [PublicAPI]
    public static extern Manifold Collide(in ChainSegment segmentA, Transform xfA, in Capsule capsuleB, Transform xfB, ref SimplexCache cache);

    /// <summary>
    /// Compute the contact manifold between a chain segment and a rounded polygon
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideChainSegmentAndPolygon")]
    [PublicAPI]
    public static extern Manifold Collide(in ChainSegment segmentA, in Transform xfA, in Polygon polygonB, in Transform xfB, ref SimplexCache cache);
}
