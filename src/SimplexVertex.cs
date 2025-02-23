using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Simplex vertex for debugging the GJK algorithm
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct SimplexVertex
{
    /// <summary>
    /// Support point in proxyA
    /// </summary>
    [FieldOffset(0)]
    public Vec2 WA;

    /// <summary>
    /// Support point in proxyB
    /// </summary>
    [FieldOffset(8)]
    public Vec2 WB;

    /// <summary>
    /// wB - wA
    /// </summary>
    [FieldOffset(16)]
    public Vec2 W;

    /// <summary>
    /// Barycentric coordinate for closest point
    /// </summary>
    [FieldOffset(24)]
    public float A;

    /// <summary>
    /// wA index
    /// </summary>
    [FieldOffset(28)]
    public int IndexA;

    /// <summary>
    /// wB index
    /// </summary>
    [FieldOffset(32)]
    public int IndexB;
}