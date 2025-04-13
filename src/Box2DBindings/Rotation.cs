using System;
using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
public struct Rotation : IEquatable<Rotation>
{
    [FieldOffset(0)]
    public float Cos = 1;
    [FieldOffset(4)]
    public float Sin = 0;
    public Rotation()
    { }
    
    public static implicit operator Rotation((float Cos, float Sin) tuple) => new() { Cos = tuple.Cos, Sin = tuple.Sin };
    public static implicit operator (float, float)(Rotation rotation) => (rotation.Cos, rotation.Sin);
    
    public static implicit operator Rotation(float radians)
    {
        var cos = MathF.Cos(radians);
        var sin = MathF.Sin(radians);
        return new Rotation { Cos = cos, Sin = sin };
    }
    
    public static implicit operator float(Rotation rotation) => MathF.Atan2(rotation.Sin, rotation.Cos);
    
    public override string ToString()
    {
        return $"Rot(Cos: {Cos}, Sin: {Sin}, Rad: {GetAngle()}, Deg: {GetAngle() * 180 / MathF.PI})";
    }
    
    public float GetAngle()
    {
        return MathF.Atan2(Sin, Cos);
    }
    public bool Equals(Rotation other) =>
        Cos.Equals(other.Cos) && Sin.Equals(other.Sin);
    public override bool Equals(object? obj) =>
        obj is Rotation other && Equals(other);
    public override int GetHashCode() =>
        HashCode.Combine(Cos, Sin);
}