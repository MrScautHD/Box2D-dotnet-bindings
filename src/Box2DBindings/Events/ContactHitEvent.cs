using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A hit touch event is generated when two shapes collide with a speed faster than the hit speed threshold.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ContactHitEvent
{
    /// <summary>
    /// The first shape
    /// </summary>
    public Shape ShapeA;

    /// <summary>
    /// The second shape
    /// </summary>
    public Shape ShapeB;

    /// <summary>
    /// Point where the shapes hit
    /// </summary>
    public Vec2 Point;

    /// <summary>
    /// Normal vector pointing from shape A to shape B
    /// </summary>
    public Vec2 Normal;

    /// <summary>
    /// The speed the shapes are approaching. Always positive. Typically in meters per second.
    /// </summary>
    public float ApproachSpeed;
}