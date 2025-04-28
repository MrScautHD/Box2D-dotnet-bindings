using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Sequential)]
public struct RayResult
{
    public readonly Shape Shape; // 8 bytes
    public readonly Vec2 Point;
    public readonly Vec2 Normal;
    public readonly float Fraction;
    
    public readonly int NodeVisits;
    public readonly int LeafVisits;
    
    [MarshalAs(UnmanagedType.U1)]
    public readonly bool Hit;
}