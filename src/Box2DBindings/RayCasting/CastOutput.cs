using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Low level ray cast or shape-cast output data
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct CastOutput
{
    /// <summary>
    /// The surface normal at the hit point
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Normal;

    /// <summary>
    /// The surface hit point
    /// </summary>
    [FieldOffset(8)]
    public Vec2 Point;

    /// <summary>
    /// The fraction of the input translation at collision
    /// </summary>
    [FieldOffset(16)]
    public float Fraction;

    /// <summary>
    /// The number of iterations used
    /// </summary>
    [FieldOffset(20)]
    public int Iterations;

    /// <summary>
    /// Did the cast hit?
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(24)]
    public bool Hit;
}