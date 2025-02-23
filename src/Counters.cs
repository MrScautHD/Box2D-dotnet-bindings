using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Counters that give details of the simulation size.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Counters
{
    [FieldOffset(0)]
    public int BodyCount;
    [FieldOffset(4)]
    public int ShapeCount;
    [FieldOffset(8)]
    public int ContactCount;
    [FieldOffset(12)]
    public int JointCount;
    [FieldOffset(16)]
    public int IslandCount;
    [FieldOffset(20)]
    public int StackUsed;
    [FieldOffset(24)]
    public int StaticTreeHeight;
    [FieldOffset(28)]
    public int TreeHeight;
    [FieldOffset(32)]
    public int ByteCount;
    [FieldOffset(36)]
    public int TaskCount;
    [FieldOffset(40)]
    public fixed int ColorCounts[12];
}