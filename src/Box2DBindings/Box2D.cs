using System;
using System.Runtime.InteropServices;

namespace Box2D;

public static class Box2D
{
    public const int B2_MAX_POLYGON_VERTICES = 8;

    internal const string libraryName = "box2d";

    /// <summary>
    /// Get the current version of Box2D
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetVersion")]
    public static extern Box2DVersion GetVersion();

    /// <summary>
    /// Get the absolute number of system ticks. The value is platform specific.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetTicks")]
    public static extern ulong GetTicks();

    /// <summary>
    /// Get the milliseconds passed from an initial tick value.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetMilliseconds")]
    public static extern float GetMilliseconds(ulong ticks);

    /// <summary>
    /// Get the milliseconds passed from an initial tick value.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetMillisecondsAndReset")]
    public static extern float GetMillisecondsAndReset(ref ulong ticks);

    /// <summary>
    /// Yield to be used in a busy loop.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Yield")]
    public static extern void Yield();

    /// <summary>
    /// Simple djb2 hash function for determinism testing
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Hash")]
    public static extern uint Hash(uint hash, byte[] data, int count);

    /// <summary>
    /// Validate ray cast input data (NaN, etc)
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2IsValidRay")]
    public static extern bool IsValidRay(in RayCastInput input);

    /// <summary>
    /// Make a convex polygon from a convex hull. This will assert if the hull is not valid.
    /// </summary>
    /// <remarks>
    /// <b>Warning: Do not manually fill in the hull data, it must come directly from b2ComputeHull</b>
    /// </remarks>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakePolygon")]
    public static extern Polygon MakePolygon(in Hull hull, float radius);

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

    /// <summary>
    /// Transform a polygon. This is useful for transferring a shape from one body to another.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2TransformPolygon")]
    public static extern Polygon TransformPolygon(in Transform transform, in Polygon polygon);

    /// <summary>
    /// Compute mass properties of a circle
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeCircleMass")]
    public static extern MassData ComputeCircleMass(in Circle shape, float density);

    /// <summary>
    /// Compute mass properties of a capsule
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeCapsuleMass")]
    public static extern MassData ComputeCapsuleMass(in Capsule shape, float density);

    /// <summary>
    /// Compute mass properties of a polygon
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputePolygonMass")]
    public static extern MassData ComputePolygonMass(in Polygon shape, float density);

    /// <summary>
    /// Compute the bounding box of a transformed circle
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeCircleAABB")]
    public static extern AABB ComputeCircleAABB(in Circle shape, in Transform transform);

    /// <summary>
    /// Compute the bounding box of a transformed capsule
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeCapsuleAABB")]
    public static extern AABB ComputeCapsuleAABB(in Capsule shape, in Transform transform);

    /// <summary>
    /// Compute the bounding box of a transformed polygon
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputePolygonAABB")]
    public static extern AABB ComputePolygonAABB(in Polygon shape, in Transform transform);

    /// <summary>
    /// Compute the bounding box of a transformed line segment
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeSegmentAABB")]
    public static extern AABB ComputeSegmentAABB(in Segment shape, in Transform transform);

    /// <summary>
    /// Test a point for overlap with a circle in local space
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInCircle")]
    public static extern bool PointInCircle(in Vec2 point, in Circle shape);

    /// <summary>
    /// Test a point for overlap with a capsule in local space
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInCapsule")]
    public static extern bool PointInCapsule(in Vec2 point, in Capsule shape);

    /// <summary>
    /// Test a point for overlap with a convex polygon in local space
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInPolygon")]
    public static extern bool PointInPolygon(in Vec2 point, in Polygon shape);

    /// <summary>
    /// Ray cast versus circle shape in local space. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastCircle")]
    public static extern CastOutput RayCastCircle(in RayCastInput input, in Circle shape);

    /// <summary>
    /// Ray cast versus capsule shape in local space. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastCapsule")]
    public static extern CastOutput RayCastCapsule(in RayCastInput input, in Capsule shape);

    /// the left side being treated as a miss.
    /// <summary>
    /// Ray cast versus segment shape in local space. Optionally treat the segment as one-sided with hits from
    /// the left side being treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastSegment")]
    public static extern CastOutput RayCastSegment(in RayCastInput input, in Segment shape, bool oneSided);

    /// <summary>
    /// Ray cast versus polygon shape in local space. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastPolygon")]
    public static extern CastOutput RayCastPolygon(in RayCastInput input, in Polygon shape);

    /// <summary>
    /// Shape cast versus a circle. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastCircle")]
    private static extern CastOutput ShapeCastCircle(in ShapeCastInputInternal input, in Circle shape);
    
    public static CastOutput ShapeCastCicle(ShapeCastInput input, in Circle shape) =>
        ShapeCastCircle(input._internal, shape);

    /// <summary>
    /// Shape cast versus a capsule. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastCapsule")]
    private static extern CastOutput ShapeCastCapsule(in ShapeCastInputInternal input, in Capsule shape);
    
    public static CastOutput ShapeCastCapsule(ShapeCastInput input, in Capsule shape) =>
        ShapeCastCapsule(input._internal, shape);

    /// <summary>
    /// Shape cast versus a line segment. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastSegment")]
    private static extern CastOutput ShapeCastSegment(in ShapeCastInputInternal input, in Segment shape);
    
    public static CastOutput ShapeCastSegment(ShapeCastInput input, in Segment shape) =>
        ShapeCastSegment(input._internal, shape);

    /// <summary>
    /// Shape cast versus a convex polygon. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastPolygon")]
    private static extern CastOutput ShapeCastPolygon(in ShapeCastInputInternal input, in Polygon shape);
    
    public static CastOutput ShapeCastPolygon(ShapeCastInput input, in Polygon shape) =>
        ShapeCastPolygon(input._internal, shape);

    /// <summary>
    /// Compute the convex hull of a set of points. Returns an empty hull if it fails.
    /// Some failure cases:
    /// <ul>
    /// <li>all points very close together</li>
    /// <li>all points on a line</li>
    /// <li>less than 3 points</li>
    /// <li>more than B2_MAX_POLYGON_VERTICES points</li>
    /// </ul>
    /// This welds close points and removes collinear points.
    /// </summary>
    /// <remarks>
    /// <b>Warning: Do not modify a hull once it has been computed</b>
    /// </remarks>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeHull")]
    public static extern Hull ComputeHull(in Vec2 points, int count);

    /// <summary>
    /// This determines if a hull is valid. Checks for:
    /// <ul>
    /// <li>convexity</li>
    /// <li>collinear points</li>
    /// </ul>
    /// This is expensive and should not be called at runtime.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ValidateHull")]
    public static extern bool ValidateHull(in Hull hull);

    /// <summary>
    /// Compute the distance between two line segments, clamping at the end points if needed.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SegmentDistance")]
    public static extern SegmentDistanceResult SegmentDistance(in Vec2 p1, in Vec2 q1, in Vec2 p2, in Vec2 q2);

    /// <summary>
    /// Compute the closest points between two shapes represented as point clouds.
    /// b2SimplexCache cache is input/output. On the first call set b2SimplexCache.count to zero.
    /// The underlying GJK algorithm may be debugged by passing in debug simplexes and capacity. You may pass in NULL and 0 for these.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeDistance")]
    public static extern DistanceOutput ShapeDistance(ref SimplexCache cache, in DistanceInput input, in Simplex simplexes, int simplexCapacity);

    /// <summary>
    /// Perform a linear shape cast of shape B moving and shape A fixed. Determines the hit point, normal, and translation fraction.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCast")]
    public static extern CastOutput ShapeCast(in ShapeCastPairInput input);

    /// <summary>
    /// Make a proxy for use in GJK and related functions.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeProxy")]
    public static extern ShapeProxy MakeProxy(in Vec2 vertices, int count, float radius);

    /// <summary>
    /// Evaluate the transform sweep at a specific time.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetSweepTransform")]
    public static extern Transform GetSweepTransform(in Sweep sweep, float time);

    /// <summary>
    /// Compute the upper bound on time before two shapes penetrate. Time is represented as
    /// a fraction between [0,tMax]. This uses a swept separating axis and may miss some intermediate,
    /// non-tunneling collisions. If you change the time interval, you should call this function
    /// again.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2TimeOfImpact")]
    public static extern TOIOutput TimeOfImpact(in TOIInput input);

    /// <summary>
    /// Compute the contact manifold between two circles
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCircles")]
    public static extern Manifold CollideCircles(in Circle circleA, in Transform xfA, in Circle circleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a capsule and circle
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCapsuleAndCircle")]
    public static extern Manifold CollideCapsuleAndCircle(in Capsule capsuleA, in Transform xfA, in Circle circleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between an segment and a circle
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndCircle")]
    public static extern Manifold CollideSegmentAndCircle(in Segment segmentA, in Transform xfA, in Circle circleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a polygon and a circle
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygonAndCircle")]
    public static extern Manifold CollidePolygonAndCircle(in Polygon polygonA, in Transform xfA, in Circle circleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a capsule and circle
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCapsules")]
    public static extern Manifold CollideCapsules(in Capsule capsuleA, in Transform xfA, in Capsule capsuleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between an segment and a capsule
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndCapsule")]
    public static extern Manifold CollideSegmentAndCapsule(in Segment segmentA, in Transform xfA, in Capsule capsuleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a polygon and capsule
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygonAndCapsule")]
    public static extern Manifold CollidePolygonAndCapsule(in Polygon polygonA, in Transform xfA, in Capsule capsuleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between two polygons
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygons")]
    public static extern Manifold CollidePolygons(in Polygon polygonA, in Transform xfA, in Polygon polygonB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a segment and a polygon
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndPolygon")]
    public static extern Manifold CollideSegmentAndPolygon(in Segment segmentA, in Transform xfA, in Polygon polygonB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a chain segment and a circle
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideChainSegmentAndCircle")]
    public static extern Manifold CollideChainSegmentAndCircle(in ChainSegment segmentA, in Transform xfA, in Circle circleB, in Transform xfB);

    /// <summary>
    /// Compute the contact manifold between a chain segment and a capsule
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideChainSegmentAndCapsule")]
    public static extern Manifold CollideChainSegmentAndCapsule(in ChainSegment segmentA, in Transform xfA, in Capsule capsuleB, in Transform xfB, ref SimplexCache cache);

    /// <summary>
    /// Compute the contact manifold between a chain segment and a rounded polygon
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideChainSegmentAndPolygon")]
    public static extern Manifold CollideChainSegmentAndPolygon(in ChainSegment segmentA, in Transform xfA, in Polygon polygonB, in Transform xfB, ref SimplexCache cache);

    /// <summary>
    /// Set LengthUnitsPerMeter. By default, 1.0 corresponds to 1 meter.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SetLengthUnitsPerMeter")]
    public static extern void SetLengthUnitsPerMeter(float lengthUnitsPerMeter);
    
    /// <summary>
    /// Get LengthUnitsPerMeter. By default, 1.0 corresponds to 1 meter.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetLengthUnitsPerMeter")]
    public static extern float GetLengthUnitsPerMeter();
    
    /// <summary>
    /// Length units per meter. By default 1.0 corresponds to 1 meter.
    /// </summary>
    public static float LengthUnitsPerMeter
    {
        get => GetLengthUnitsPerMeter();
        set => SetLengthUnitsPerMeter(value);
    }
    
    internal static object? GetObjectAtPointer(nint ptr)
    {
        if (ptr == 0) return null;
        GCHandle handle = GCHandle.FromIntPtr(ptr);
        if (!handle.IsAllocated) return null;
        object? userData = handle.Target;
        return userData;
    }
    
    internal static void SetObjectAtPointer(ref nint ptr, object? value)
    {
        if (ptr != 0)
        {
            GCHandle handle = GCHandle.FromIntPtr(ptr);
            if (handle.IsAllocated) handle.Free();
        }
        if (value == null) return;
        GCHandle newHandle = GCHandle.Alloc(value);
        ptr = GCHandle.ToIntPtr(newHandle);
    }

    internal static void FreeHandle(nint ptr)
    {
        if (ptr != 0)
        {
            var hnd = GCHandle.FromIntPtr(ptr);
            if (hnd.IsAllocated)
                hnd.Free();
        }
    }
 
    internal static object? GetObjectAtPointer<T>(Func<T,nint> getFunc, T param)
    {
        nint ptr = getFunc(param);
        return GetObjectAtPointer(ptr);
    }

    internal static void SetObjectAtPointer<T>(Func<T,nint> getFunc, Action<T, nint> setFunc, T param, object? value)
    {
        // dealloc previous user data
        nint userDataPtr = getFunc(param);
        GCHandle handle;
        if (userDataPtr != 0)
        {
            handle = GCHandle.FromIntPtr(userDataPtr);
            if (handle.IsAllocated) handle.Free();
        }
        if (value == null)
        {
            setFunc(param, 0);
            return;
        }
        handle = GCHandle.Alloc(value);
        userDataPtr = GCHandle.ToIntPtr(handle);
        setFunc(param, userDataPtr);
    }
}
