using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
public struct RayResult
{
    [FieldOffset(0)]
    public Shape Shape; // 8 bytes
    [FieldOffset(8)]
    public Vec2 Point;
    [FieldOffset(16)]
    public Vec2 Normal;
    [FieldOffset(24)]
    public float Fraction;
    [FieldOffset(28)]
    public int NodeVisits;
    [FieldOffset(32)]
    public int LeafVisits;
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(36)]
    public bool Hit;
}