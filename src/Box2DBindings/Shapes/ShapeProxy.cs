using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A distance proxy is used by the GJK algorithm. It encapsulates any shape.
/// You can provide between 1 and <see cref="Constants.MAX_POLYGON_VERTICES" /> and a radius.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ShapeProxy : IDisposable
{
    [FieldOffset(0)]
    private nint points;
    
    /// <summary>
    /// The point cloud
    /// </summary>
    public unsafe ReadOnlySpan<Vec2> Points
    {
        get => new((void*)points, count);
        set
        {
            if (points != 0)
                Marshal.FreeHGlobal(points);
            points = Marshal.AllocHGlobal(value.Length * sizeof(Vec2));
            var span = new Span<Vec2>((void*)points, count);
            for (int i = 0; i < value.Length; i++)
                span[i] = value[i];
            count = value.Length;
        }
    }
    
    /// <summary>
    /// The number of points
    /// </summary>
    [FieldOffset(8)]
    private int count;
    
    /// <summary>
    /// The external radius of the point cloud
    /// </summary>
    [FieldOffset(12)]
    public float Radius;
    
    public void Dispose()
    {
        if (points != 0)
        {
            Marshal.FreeHGlobal(points);
            points = 0;
        }
    }
}