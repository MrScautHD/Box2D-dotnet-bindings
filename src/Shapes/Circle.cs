using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A solid circle
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Circle
{
    /// <summary>
    /// The local center
    /// </summary>
    public Vec2 Center;

    /// <summary>
    /// The radius
    /// </summary>
    public float Radius;
}