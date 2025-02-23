using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A hit touch event is generated when two shapes collide with a speed faster than the hit speed threshold.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ContactHitEvent
{
    /// <summary>
    /// The first shape
    /// </summary>
    [FieldOffset(0)]
    public Shape ShapeA;

    /// <summary>
    /// The second shape
    /// </summary>
    [FieldOffset(8)]
    public Shape ShapeB;

    /// <summary>
    /// Point where the shapes hit
    /// </summary>
    [FieldOffset(16)]
    public Vec2 Point;

    /// <summary>
    /// Normal vector pointing from shape A to shape B
    /// </summary>
    [FieldOffset(24)]
    public Vec2 Normal;

    /// <summary>
    /// The speed the shapes are approaching. Always positive. Typically in meters per second.
    /// </summary>
    [FieldOffset(32)]
    public float ApproachSpeed;
}