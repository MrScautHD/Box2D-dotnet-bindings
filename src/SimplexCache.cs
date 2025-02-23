using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Used to warm start the GJK simplex. If you call this function multiple times with nearby
/// transforms this might improve performance. Otherwise you can zero initialize this.
/// The distance cache must be initialized to zero on the first call.
/// Users should generally just zero initialize this structure for each call.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public unsafe struct SimplexCache
{
    /// <summary>
    /// The number of stored simplex points
    /// </summary>
    [FieldOffset(0)]
    public ushort Count;

    /// <summary>
    /// The cached simplex indices on shape A
    /// </summary>
    [FieldOffset(2)]
    public fixed byte IndexA[3];

    /// <summary>
    /// The cached simplex indices on shape B
    /// </summary>
    [FieldOffset(5)]
    public fixed byte IndexB[3];
}