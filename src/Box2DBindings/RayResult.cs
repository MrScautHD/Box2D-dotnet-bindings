using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Sequential)]
public struct RayResult
{
    public Shape Shape; // 8 bytes
    public Vec2 Point;
    public Vec2 Normal;
    public float Fraction;
    
    public int NodeVisits;
    public int LeafVisits;
    
    [MarshalAs(UnmanagedType.U1)]
    public bool Hit;
}