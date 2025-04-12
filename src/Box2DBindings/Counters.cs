using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Counters that give details of the simulation size.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Counters
{
    public int BodyCount;
    public int ShapeCount;
    public int ContactCount;
    public int JointCount;
    public int IslandCount;
    public int StackUsed;
    public int StaticTreeHeight;
    public int TreeHeight;
    public int ByteCount;
    public int TaskCount;
    public fixed int ColorCounts[12];
}