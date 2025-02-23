using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Simplex from the GJK algorithm
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Simplex
{
    /// <summary>
    /// Vertices
    /// </summary>
    public SimplexVertex V1, V2, V3;

    /// <summary>
    /// Number of valid vertices
    /// </summary>
    public int Count;
}