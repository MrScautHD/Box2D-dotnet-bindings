using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
public struct TreeNode
{
    [FieldOffset(0)]
    public readonly AABB AABB; // 16 bytes

    [FieldOffset(16)]
    public readonly ulong CategoryBits; // 8 bytes

    // Union: userData OR children
    [FieldOffset(24)]
    public readonly ulong UserData;

    [FieldOffset(24)]
    public readonly TreeChildren Children;

    // Union: parent OR next
    [FieldOffset(32)]
    public readonly int Parent;

    [FieldOffset(32)]
    public readonly int Next;

    [FieldOffset(36)]
    public readonly ushort Height;

    [FieldOffset(38)]
    public readonly TreeNodeFlags Flags;
}

[StructLayout(LayoutKind.Sequential)]
public struct TreeChildren
{
    public readonly int Child1;
    public readonly int Child2;
}

public enum TreeNodeFlags : ushort
{
    AllocatedNode = 0x0001,
    EnlargedNode = 0x0002,
    LeafNode = 0x0004,
};