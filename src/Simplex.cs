using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Simplex from the GJK algorithm
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Simplex
{
    /// <summary>
    /// Vertices
    /// </summary>
    [FieldOffset(0)]
    public SimplexVertex V1, V2, V3; // 40 bytes each

    /// <summary>
    /// Number of valid vertices
    /// </summary>
    [FieldOffset(120)]
    public int Count;
}