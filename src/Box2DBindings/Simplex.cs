using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Simplex from the GJK algorithm
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Simplex
{
    /// <summary>
    /// Vertices
    /// </summary>
    public readonly SimplexVertex V1, V2, V3; // 40 bytes each

    /// <summary>
    /// Number of valid vertices
    /// </summary>
    public readonly int Count;
}