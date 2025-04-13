using System;
using System.Runtime.InteropServices;

using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("UnitTests")]


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
    /// Compute the distance between two line segments, clamping at the end points if needed.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SegmentDistance")]
    public static extern SegmentDistanceResult SegmentDistance(in Vec2 p1, in Vec2 q1, in Vec2 p2, in Vec2 q2);

    /// <summary>
    /// Compute the distance between two line segments, clamping at the end points if needed.
    /// </summary>
    public static SegmentDistanceResult SegmentDistance(in Segment segmentA, in Segment segmentB) =>
        SegmentDistance(segmentA.Point1, segmentA.Point2, segmentB.Point1, segmentB.Point2);

    /// <summary>
    /// Compute the closest points between two shapes represented as point clouds.
    /// SimplexCache cache is input/output. On the first call set SimplexCache.Count to zero.
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
    /// Compute the upper bound on time before two shapes penetrate. Time is represented as
    /// a fraction between [0,tMax]. This uses a swept separating axis and may miss some intermediate,
    /// non-tunneling collisions. If you change the time interval, you should call this function
    /// again.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2TimeOfImpact")]
    public static extern TOIOutput TimeOfImpact(in TOIInput input);


    /// <summary>
    /// Set LengthUnitsPerMeter. By default, 1.0 corresponds to 1 meter.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SetLengthUnitsPerMeter")]
    private static extern void SetLengthUnitsPerMeter(float lengthUnitsPerMeter);

    /// <summary>
    /// Get LengthUnitsPerMeter. By default, 1.0 corresponds to 1 meter.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetLengthUnitsPerMeter")]
    private static extern float GetLengthUnitsPerMeter();

    /// <summary>
    /// Length units per meter. By default 1.0 corresponds to 1 meter.
    /// </summary>
    public static float LengthUnitsPerMeter
    {
        get => GetLengthUnitsPerMeter();
        set => SetLengthUnitsPerMeter(value);
    }

    /// <summary>
    /// Set assert function
    /// </summary>
    /// <param name="assertFcn">Pointer to the assert function</param>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SetAssertFcn")]
    public static extern void SetAssertFunction(AssertFunction assertFcn);
    
    public delegate int AssertFunction(string condition, string fileName, int lineNumber);
    
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

    internal static void FreeHandle(ref nint ptr)
    {
        if (ptr != 0)
        {
            var hnd = GCHandle.FromIntPtr(ptr);
            if (hnd.IsAllocated)
                hnd.Free();
            ptr = 0;
        }
    }

    internal static object? GetObjectAtPointer<T>(Func<T, nint> getFunc, T param)
    {
        nint ptr = getFunc(param);
        return GetObjectAtPointer(ptr);
    }

    internal static void SetObjectAtPointer<T>(Func<T, nint> getFunc, Action<T, nint> setFunc, T param, object? value)
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