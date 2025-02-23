using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct RayResult
{
    public Shape Shape;
    public Vec2 Point;
    public Vec2 Normal;
    public float Fraction;
    public int NodeVisits;
    public int LeafVisits;
    [MarshalAs(UnmanagedType.U1)]
    public bool Hit;
}