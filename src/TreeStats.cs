using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// These are performance results returned by dynamic tree queries.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct TreeStats
{
    /// <summary>
    /// Number of internal nodes visited during the query
    /// </summary>
    [FieldOffset(0)]
    public int NodeVisits;

    /// <summary>
    /// Number of leaf nodes visited during the query
    /// </summary>
    [FieldOffset(4)]
    public int LeafVisits;
}