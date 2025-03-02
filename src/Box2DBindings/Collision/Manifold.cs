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
    /// The manifold points, up to two are possible in 2D
    /// </summary>
    public ReadOnlySpan<ManifoldPoint> Points => new(_points, 2);
    
    /// <summary>
    /// The number of contacts points, will be 0, 1, or 2
    /// </summary>
    [FieldOffset(112)]
    public int PointCount;
}