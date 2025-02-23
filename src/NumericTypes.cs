using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Vec2
{
    public float X;
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

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Rot
{
    public float Cos = 1;
    public float Sin = 0;
    public Rot()
    { }
    
    public static implicit operator Rot((float Cos, float Sin) tuple) => new() { Cos = tuple.Cos, Sin = tuple.Sin };
    public static implicit operator (float, float)(Rot rot) => (rot.Cos, rot.Sin);
    
    public static implicit operator Rot(float radians)
    {
        var cos = System.MathF.Cos(radians);
        var sin = System.MathF.Sin(radians);
        return new Rot { Cos = cos, Sin = sin };
    }
    
    public static implicit operator float(Rot rot) => System.MathF.Atan2(rot.Sin, rot.Cos);
    
    public static implicit operator Rot(System.Numerics.Quaternion quaternion)
    {
        var (x, y, z, w) = (quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
        var sin = 2 * (w * z - x * y);
        var cos = 1 - 2 * (y * y + z * z);
        return new Rot { Cos = cos, Sin = sin };
    }
    
    public static implicit operator System.Numerics.Quaternion(Rot rot)
    {
        var (cos, sin) = (rot.Cos, rot.Sin);
        var halfAngle = System.MathF.Atan2(sin, cos) / 2;
        var w = System.MathF.Cos(halfAngle);
        var z = System.MathF.Sin(halfAngle);
        return new System.Numerics.Quaternion(0, 0, z, w);
    }
    
    public static Rot operator *(Rot a, Rot b)
    {
        var cos = a.Cos * b.Cos - a.Sin * b.Sin;
        var sin = a.Cos * b.Sin + a.Sin * b.Cos;
        return new Rot { Cos = cos, Sin = sin };
    }
    
    public static Rot operator +(Rot a, Rot b)
    {
        var cos = a.Cos * b.Cos - a.Sin * b.Sin;
        var sin = a.Cos * b.Sin + a.Sin * b.Cos;
        return new Rot { Cos = cos, Sin = sin };
    }
    
    public static Rot operator -(Rot a, Rot b)
    {
        var cos = a.Cos * b.Cos + a.Sin * b.Sin;
        var sin = a.Cos * b.Sin - a.Sin * b.Cos;
        return new Rot { Cos = cos, Sin = sin };
    }
    
    public static Rot operator -(Rot a)
    {
        return new Rot { Cos = a.Cos, Sin = -a.Sin };
    }
    
    public static Rot operator *(Rot a, float b)
    {
        return new Rot { Cos = a.Cos * b, Sin = a.Sin * b };
    }
    
    public static Rot operator /(Rot a, float b)
    {
        return new Rot { Cos = a.Cos / b, Sin = a.Sin / b };
    }
    
    public static bool operator ==(Rot a, Rot b)
    {
        return a.Cos == b.Cos && a.Sin == b.Sin;
    }
    
    public static bool operator !=(Rot a, Rot b)
    {
        return a.Cos != b.Cos || a.Sin != b.Sin;
    }
    
    public override bool Equals(object obj)
    {
        return obj is Rot rot && this == rot;
    }
    
    public override int GetHashCode()
    {
        return Cos.GetHashCode() ^ Sin.GetHashCode();
    }
    
    public override string ToString()
    {
        return $"Rot(Cos: {Cos}, Sin: {Sin}, Rad: {GetAngle()}, Deg: {GetAngle() * 180 / MathF.PI})";
    }
    
    public float GetAngle()
    {
        return MathF.Atan2(Sin, Cos);
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Transform
{
    public Vec2 Position;
    public Rot Rotation;
}

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct AABB
{
    public Vec2 LowerBound;
    public Vec2 UpperBound;
}
