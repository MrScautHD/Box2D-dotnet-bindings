using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Sequential)]
internal struct JointId
{
    public int index1;
    public ushort world;
    public ushort generation;
}