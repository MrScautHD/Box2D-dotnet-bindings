using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A solid capsule can be viewed as two semicircles connected
/// by a rectangle.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Capsule
{
    /// <summary>
    /// Local center of the first semicircle
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Center1;

    /// <summary>
    /// Local center of the second semicircle
    /// </summary>
    [FieldOffset(8)]
    public Vec2 Center2;

    /// <summary>
    /// The radius of the semicircles
    /// </summary>
    [FieldOffset(16)]
    public float Radius;
}