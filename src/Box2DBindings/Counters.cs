using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Counters that give details of the simulation size.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Counters
{
    public readonly int BodyCount;
    public readonly int ShapeCount;
    public readonly int ContactCount;
    public readonly int JointCount;
    public readonly int IslandCount;
    public readonly int StackUsed;
    public readonly int StaticTreeHeight;
    public readonly int TreeHeight;
    public readonly int ByteCount;
    public readonly int TaskCount;
    public fixed int ColorCounts[12];
}