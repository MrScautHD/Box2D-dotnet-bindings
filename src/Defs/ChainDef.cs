using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Used to create a chain of line segments. This is designed to eliminate ghost collisions with some limitations.
/// <ul>
/// <li>chains are one-sided</li>
/// <li>chains have no mass and should be used on static bodies</li>
/// <li>chains have a counter-clockwise winding order</li>
/// <li>chains are either a loop or open</li>
/// <li>a chain must have at least 4 points</li>
/// <li>the distance between any two points must be greater than B2_LINEAR_SLOP</li>
/// <li>a chain shape should not self intersect (this is not validated)</li>
/// <li>an open chain shape has NO COLLISION on the first and final edge</li>
/// <li>you may overlap two open chains on their first three and/or last three points to get smooth collision</li>
/// <li>a chain shape creates multiple line segment shapes on the body</li>
/// </ul>
/// https://en.wikipedia.org/wiki/Polygonal_chain<br/>
/// <b>Warning: Do not use chain shapes unless you understand the limitations. This is an advanced feature.</b>
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ChainDef
{
    /// <summary>
    /// Use this to store application specific shape data.
    /// </summary>
    [FieldOffset(0)]
    public nint UserData;

    [FieldOffset(8)]
    private nint points;
	
    /// <summary>
    /// An array of at least 4 points. These are cloned and may be temporary.
    /// </summary> 
    public ReadOnlySpan<Vec2> Points
    {
        get
        {
            unsafe
            {
                return new ReadOnlySpan<Vec2>((Vec2*)points, Count);
            }
        }
        set
        {
            if (value.Length < 4)
                throw new ArgumentOutOfRangeException(nameof(value), "Chain must have at least 4 points");
            unsafe
            {
                points = Marshal.AllocHGlobal(value.Length * sizeof(Vec2));
                Count = value.Length;
                for (int i = 0; i < value.Length; i++)
                {
                    ((Vec2*)points)[i] = value[i];
                }
            }
        }
    }

    /// <summary>
    /// The point count, must be 4 or more.
    /// </summary>
    [FieldOffset(16)]
    private int Count;

    [FieldOffset(20)]
    private nint materials;
	
    /// <summary>
    /// Surface materials for each segment. These are cloned.
    /// </summary>
    public SurfaceMaterial[] Materials
    {
        set
        {
            if (value.Length < 4)
                throw new ArgumentOutOfRangeException(nameof(value), "Chain must have at least 4 points");
            unsafe
            {
                materials = Marshal.AllocHGlobal(value.Length * sizeof(SurfaceMaterial));
                MaterialCount = value.Length;
                for (int i = 0; i < value.Length; i++)
                {
                    ((SurfaceMaterial*)materials)[i] = value[i];
                }
            }
        }
    }

    /// <summary>
    /// The material count. Must be 1 or count. This allows you to provide one
    /// material for all segments or a unique material per segment.
    /// </summary>
    [FieldOffset(28)]
    private int MaterialCount;

    /// <summary>
    /// Contact filtering data.
    /// </summary>
    [FieldOffset(32)]
    public Filter Filter; // 20 bytes

    /// <summary>
    /// Indicates a closed chain formed by connecting the first and last points
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(52)]
    public bool IsLoop;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(56)]
    private readonly int internalValue = Box2D.B2_SECRET_COOKIE;
    
    public ChainDef()
    {
        UserData = 0;
        points = 0;
        Count = 0;
        Materials = [new SurfaceMaterial()];
        MaterialCount = 0;
        Filter = default;
        IsLoop = false;
    }
}