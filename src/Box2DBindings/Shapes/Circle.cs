using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A solid circle
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Circle
{
    /// <summary>
    /// The local center
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Center;

    /// <summary>
    /// The radius
    /// </summary>
    [FieldOffset(8)]
    public float Radius;
}