using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Input parameters for TimeOfImpact
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct TOIInput
{
    /// <summary>
    /// The proxy for shape A
    /// </summary>
    [FieldOffset(0)]
    public ShapeProxy ProxyA;

    /// <summary>
    /// The proxy for shape B
    /// </summary>
    [FieldOffset(16)]
    public ShapeProxy ProxyB;

    /// <summary>
    /// The movement of shape A
    /// </summary>
    [FieldOffset(32)]
    public Sweep SweepA; // 40 bytes

    /// <summary>
    /// The movement of shape B
    /// </summary>
    [FieldOffset(72)]
    public Sweep SweepB;

    /// <summary>
    /// Defines the sweep interval [0, maxFraction]
    /// </summary>
    [FieldOffset(112)]
    public float MaxFraction;
}