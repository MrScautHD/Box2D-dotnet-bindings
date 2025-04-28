using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Simplex vertex for debugging the GJK algorithm
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct SimplexVertex
{
    /// <summary>
    /// Support point in proxyA
    /// </summary>
    public readonly Vec2 WA;

    /// <summary>
    /// Support point in proxyB
    /// </summary>
    public readonly Vec2 WB;

    /// <summary>
    /// wB - wA
    /// </summary>
    public readonly Vec2 W;

    /// <summary>
    /// Barycentric coordinate for closest point
    /// </summary>
    public readonly float A;

    /// <summary>
    /// wA index
    /// </summary>
    public readonly int IndexA;

    /// <summary>
    /// wB index
    /// </summary>
    public readonly int IndexB;
}