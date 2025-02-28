using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
public struct Vec2
{
    [FieldOffset(0)]
    public float X;
    [FieldOffset(4)]
    public float Y;
    
    public static implicit operator Vec2((float X, float Y) tuple) => new() { X = tuple.X, Y = tuple.Y };
    public static implicit operator (float, float)(Vec2 vec2) => (vec2.X, vec2.Y);
    public static implicit operator Vec2(System.Numerics.Vector2 vector2) => new() { X = vector2.X, Y = vector2.Y };
    public static implicit operator System.Numerics.Vector2(Vec2 vec2) => new(vec2.X, vec2.Y);
    
    public override string ToString()
    {
        return $"Vec2(X: {X}, Y: {Y}, Mag: {Magnitude}, Rad: {Angle}, Deg: {Angle * 180 / MathF.PI})";
    }
    
    public float Magnitude => MathF.Sqrt(X * X + Y * Y);

    public float Angle => MathF.Atan2(Y, X);
}

[StructLayout(LayoutKind.Explicit)]
public struct Rotation
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
        var cos = System.MathF.Cos(radians);
        var sin = System.MathF.Sin(radians);
        return new Rotation { Cos = cos, Sin = sin };
    }
    
    public static implicit operator float(Rotation rotation) => System.MathF.Atan2(rotation.Sin, rotation.Cos);
    
    public override string ToString()
    {
        return $"Rot(Cos: {Cos}, Sin: {Sin}, Rad: {GetAngle()}, Deg: {GetAngle() * 180 / MathF.PI})";
    }
    
    public float GetAngle()
    {
        return MathF.Atan2(Sin, Cos);
    }
}

[StructLayout(LayoutKind.Explicit)]
public struct Transform
{
    [FieldOffset(0)]
    public Vec2 Position;
    [FieldOffset(8)]
    public Rotation Rotation;
    
    public override string ToString()
    {
        return $"Transform(Position: {Position}, Rotation: {Rotation})";
    }
}

[StructLayout(LayoutKind.Explicit)]
public struct AABB
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
}
