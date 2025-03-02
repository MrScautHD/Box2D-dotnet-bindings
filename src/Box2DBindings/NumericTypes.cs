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

[StructLayout(LayoutKind.Explicit)]
public struct Transform : IEquatable<Transform>
{
    [FieldOffset(0)]
    public Vec2 Position;
    [FieldOffset(8)]
    public Rotation Rotation;
    
    public override string ToString()
    {
        return $"Transform(Position: {Position}, Rotation: {Rotation})";
    }
    public bool Equals(Transform other) =>
        Position.Equals(other.Position) && Rotation.Equals(other.Rotation);
    public override bool Equals(object? obj) =>
        obj is Transform other && Equals(other);
    public override int GetHashCode() =>
        HashCode.Combine(Position, Rotation);
}

[StructLayout(LayoutKind.Explicit)]
public struct AABB : IEquatable<AABB>
{
    [FieldOffset(0)]
    public Vec2 LowerBound;
    [FieldOffset(8)]
    public Vec2 UpperBound;
    
    public float Width => UpperBound.X - LowerBound.X;
    public float Height => UpperBound.Y - LowerBound.Y;
    
    public override string ToString()
    {
        return $"AABB(Lower: {LowerBound}, Upper: {UpperBound}, Width: {Width}, Height: {Height})";
    }
    public bool Equals(AABB other) =>
        LowerBound.Equals(other.LowerBound) && UpperBound.Equals(other.UpperBound);
    public override bool Equals(object? obj) =>
        obj is AABB other && Equals(other);
    public override int GetHashCode() =>
        HashCode.Combine(LowerBound, UpperBound);
}
