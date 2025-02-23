using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A solid capsule can be viewed as two semicircles connected
/// by a rectangle.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Capsule
{
    /// <summary>
    /// Local center of the first semicircle
    /// </summary>
    public Vec2 Center1;

    /// <summary>
    /// Local center of the second semicircle
    /// </summary>
    public Vec2 Center2;

    /// <summary>
    /// The radius of the semicircles
    /// </summary>
    public float Radius;
}