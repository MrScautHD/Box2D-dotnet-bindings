using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
public struct TreeNode
{
    [FieldOffset(0)]
    public AABB AABB; // 16 bytes

    [FieldOffset(16)]
    public ulong CategoryBits; // 8 bytes

    // Union: userData OR children
    [FieldOffset(24)]
    public ulong UserData;

    [FieldOffset(24)]
    public TreeChildren Children;

    // Union: parent OR next
    [FieldOffset(32)]
    public int Parent;

    [FieldOffset(32)]
    public int Next;

    [FieldOffset(36)]
    public ushort Height;

    [FieldOffset(38)]
    public TreeNodeFlags Flags;
}

[StructLayout(LayoutKind.Sequential)]
public struct TreeChildren
{
    public int Child1;
    public int Child2;
}

public enum TreeNodeFlags : ushort
{
    AllocatedNode = 0x0001,
    EnlargedNode = 0x0002,
    LeafNode = 0x0004,
};