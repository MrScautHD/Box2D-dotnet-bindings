using System.Runtime.InteropServices;

namespace Box2D;

public static class Collision
{
    /// <summary>
    /// Compute the contact manifold between two circles
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCircles")]
    public static extern Manifold Collide(in Circle circleA, in Transform xfA, in Circle circleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a capsule and circle
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCapsuleAndCircle")]
    public static extern Manifold Collide(in Capsule capsuleA, in Transform xfA, in Circle circleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between an segment and a circle
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndCircle")]
    public static extern Manifold Collide(in Segment segmentA, in Transform xfA, in Circle circleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a polygon and a circle
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygonAndCircle")]
    public static extern Manifold Collide(in Polygon polygonA, in Transform xfA, in Circle circleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a capsule and circle
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCapsules")]
    public static extern Manifold Collide(in Capsule capsuleA, in Transform xfA, in Capsule capsuleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between an segment and a capsule
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndCapsule")]
    public static extern Manifold Collide(in Segment segmentA, in Transform xfA, in Capsule capsuleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a polygon and capsule
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygonAndCapsule")]
    public static extern Manifold Collide(in Polygon polygonA, in Transform xfA, in Capsule capsuleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between two polygons
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygons")]
    public static extern Manifold Collide(in Polygon polygonA, in Transform xfA, in Polygon polygonB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a segment and a polygon
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndPolygon")]
    public static extern Manifold Collide(in Segment segmentA, in Transform xfA, in Polygon polygonB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a chain segment and a circle
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideChainSegmentAndCircle")]
    public static extern Manifold Collide(in ChainSegment segmentA, in Transform xfA, in Circle circleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a chain segment and a capsule
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideChainSegmentAndCapsule")]
    public static extern Manifold Collide(in ChainSegment segmentA, in Transform xfA, in Capsule capsuleB, in Transform xfB, ref SimplexCache cache);

    /// <summary>
    /// Compute the contact manifold between a chain segment and a rounded polygon
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideChainSegmentAndPolygon")]
    public static extern Manifold Collide(in ChainSegment segmentA, in Transform xfA, in Polygon polygonB, in Transform xfB, ref SimplexCache cache);
    
}
