using JetBrains.Annotations;
using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A convex hull. Used to create convex polygons.
/// </summary>
/// <remarks>
/// <b>Warning: Do not modify these values directly, instead use <see cref="Hull.Compute(Span{Vec2})"/></b>
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
[PublicAPI]
public partial struct Hull
{
    private unsafe fixed float points[B2_MAX_POLYGON_VERTICES * 2];

    private int count;
    
    /// <summary>
    /// The final points of the hull
    /// </summary>
    public unsafe ReadOnlySpan<Vec2> Points
    {
        get
        {
            fixed (float* ptr = points)
            {
                if (count > B2_MAX_POLYGON_VERTICES)
                    throw new ArgumentOutOfRangeException(nameof(count), $"Count cannot be greater than {B2_MAX_POLYGON_VERTICES}");
                
                return new ReadOnlySpan<Vec2>(ptr, count);
            }
        }
    }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeHull")]
    private static extern unsafe Hull Compute(Vec2* points, int count);

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
    public static unsafe Hull Compute(Span<Vec2> points)
    {
        if (points.Length > B2_MAX_POLYGON_VERTICES)
            throw new ArgumentException($"Hull can only contain up to {B2_MAX_POLYGON_VERTICES} points");
        
        fixed (Vec2* pointsPtr = points)
            return Compute(pointsPtr, points.Length);
    }
    
    /// <summary>
    /// This determines if a hull is valid. Checks for:
    /// <ul>
    /// <li>convexity</li>
    /// <li>collinear points</li>
    /// </ul>
    /// This is expensive and should not be called at runtime.
    /// </summary>
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ValidateHull")]
    private static extern bool Validate(in Hull hull);
    
    /// <summary>
    /// Determines if this hull is valid. Checks for:
    /// <ul>
    /// <li>convexity</li>
    /// <li>collinear points</li>
    /// </ul>
    /// This is expensive and should not be called at runtime.
    /// </summary>
    public bool Valid => Validate(in this);
}