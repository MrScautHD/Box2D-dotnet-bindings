using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A distance proxy is used by the GJK algorithm. It encapsulates any shape.
/// You can provide between 1 and <see cref="Constants.MAX_POLYGON_VERTICES" /> and a radius.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ShapeProxy
{
    public fixed float points[B2_MAX_POLYGON_VERTICES*2];
    public int count;
    public float radius;

    public ReadOnlySpan<Vec2> Points
    {
        get
        {
            fixed (float* ptr = points)
                return new ReadOnlySpan<Vec2>(ptr, count);
        }
    }
}
