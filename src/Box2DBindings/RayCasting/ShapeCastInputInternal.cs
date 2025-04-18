using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Low level shape cast input in generic form. This allows casting an arbitrary point
/// cloud wrap with a radius. For example, a circle is a single point with a non-zero radius.
/// A capsule is two points with a non-zero radius. A box is four points with a zero radius.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
unsafe struct ShapeCastInputInternal
{
    [FieldOffset(0)]
    internal ShapeProxy proxy;
    
    [FieldOffset(16)]
    internal Vec2 Translation;
    
    [FieldOffset(32)]
    internal float MaxFraction;

    [FieldOffset(36)]
    [MarshalAs(UnmanagedType.I1)]
    internal bool CanEncroach;
}