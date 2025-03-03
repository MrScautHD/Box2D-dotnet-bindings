using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A contact manifold describes the contact points between colliding shapes.
/// </summary>
/// <remarks>Box2D uses speculative collision so some contact points may be separated.</remarks>
[StructLayout(LayoutKind.Explicit, Size = 116)]
public unsafe struct Manifold
{
#if BOX2D_300
    [FieldOffset(0)]
    private nint* _points;
        
    /// <summary>
    /// The unit normal vector in world space, points from shape A to bodyB
    /// </summary>
    [FieldOffset(100)]
    public Vec2 Normal;
    
    /// <summary>
    /// The number of contacts points, will be 0, 1, or 2
    /// </summary>
    [FieldOffset(108)]
    public int PointCount;
    
#else
    /// <summary>
    /// The unit normal vector in world space, points from shape A to bodyB
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Normal;

    /// <summary>
    /// Angular impulse applied for rolling resistance. N * m * s = kg * m² / s
    /// </summary>
    [FieldOffset(8)]
    public float RollingImpulse;

    [FieldOffset(12)]
    private nint* _points;

    /// <summary>
    /// The number of contacts points, will be 0, 1, or 2
    /// </summary>
    [FieldOffset(112)]
    public int PointCount;
#endif
    
    /// <summary>
    /// The manifold points, up to two are possible in 2D
    /// </summary>
    public ReadOnlySpan<ManifoldPoint> Points => new(_points, 2);
}