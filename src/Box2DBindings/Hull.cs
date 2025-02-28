using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A convex hull. Used to create convex polygons.
/// </summary>
/// <remarks>
/// <b>Warning: Do not modify these values directly, instead use ComputeHull()</b>
/// </remarks>
[StructLayout(LayoutKind.Explicit)]
public struct Hull
{
    /// <summary>
    /// The final points of the hull
    /// </summary>
    [FieldOffset(0)]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Box2D.B2_MAX_POLYGON_VERTICES)]
    public Vec2[] Points;

    /// <summary>
    /// The number of points
    /// </summary>
    [FieldOffset(8)]
    public int Count;
    
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
    public static extern Hull Compute(in Vec2 points, int count);
    
    /// <summary>
    /// This determines if a hull is valid. Checks for:
    /// <ul>
    /// <li>convexity</li>
    /// <li>collinear points</li>
    /// </ul>
    /// This is expensive and should not be called at runtime.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ValidateHull")]
    public static extern bool Validate(in Hull hull);
    
    /// <summary>
    /// Determines if this hull is valid. Checks for:
    /// <ul>
    /// <li>convexity</li>
    /// <li>collinear points</li>
    /// </ul>
    /// This is expensive and should not be called at runtime.
    /// </summary>
    public bool Validate() => Validate(in this);
}