using System;
using System.Runtime.InteropServices;

namespace Box2D;

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
    
    /// <summary>
    /// Test a point for overlap with a circle in local space
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInCircle")]
    private static extern bool PointInCircle(in Vec2 point, in Circle shape);

    /// <summary>
    /// Test this point for overlap with a circle in local space
    /// </summary>
    public bool TestPoint(in Circle shape) => PointInCircle(this, shape);
    
    /// <summary>
    /// Test a point for overlap with a capsule in local space
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInCapsule")]
    private static extern bool PointInCapsule(in Vec2 point, in Capsule shape);
    
    /// <summary>
    /// Test this point for overlap with a capsule in local space
    /// </summary>
    public bool TestPoint(in Capsule shape) => PointInCapsule(this, shape);
    
    /// <summary>
    /// Test a point for overlap with a convex polygon in local space
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInPolygon")]
    private static extern bool PointInPolygon(in Vec2 point, in Polygon shape);
    
    /// <summary>
    /// Test this point for overlap with a convex polygon in local space
    /// </summary>
    public bool TestPoint(in Polygon shape) => PointInPolygon(this, shape);

    
}
