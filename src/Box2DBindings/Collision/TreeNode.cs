using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
public struct TreeNode
{
    [FieldOffset(0)]
    internal AABB AABB = new AABB();

    [FieldOffset(16)]
    internal ulong CategoryBits = DEFAULT_CATEGORY_BITS;

    [FieldOffset(24)]
    internal int Child1 = NULL_INDEX;

    [FieldOffset(28)]
    internal int Child2 = NULL_INDEX;

    [FieldOffset(32)]
    internal ulong UserData = 0;

    [FieldOffset(40)]
    internal int Parent = NULL_INDEX;

    [FieldOffset(44)]
    internal int Next = NULL_INDEX;

    [FieldOffset(48)]
    internal ushort Height = 0;

    [FieldOffset(50)]
    internal b2TreeNodeFlags Flags = b2TreeNodeFlags.b2_allocatedNode;
    public TreeNode()
    { }
    
    internal enum b2TreeNodeFlags : ushort
    {
        b2_allocatedNode = 0x0001,
        b2_enlargedNode = 0x0002,
        b2_leafNode = 0x0004,
    };
}