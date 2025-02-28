using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
struct JointId
{
    [FieldOffset(0)]
    public int index1;
    [FieldOffset(4)]
    public ushort world;
    [FieldOffset(6)]
    public ushort generation;
}