using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Input parameters for TimeOfImpact
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct TOIInput
{
    /// <summary>
    /// The proxy for shape A
    /// </summary>
    public ShapeProxy ProxyA;

    /// <summary>
    /// The proxy for shape B
    /// </summary>
    public ShapeProxy ProxyB;

    /// <summary>
    /// The movement of shape A
    /// </summary>
    public Sweep SweepA;

    /// <summary>
    /// The movement of shape B
    /// </summary>
    public Sweep SweepB;

    /// <summary>
    /// Defines the sweep interval [0, maxFraction]
    /// </summary>
    public float MaxFraction;
}