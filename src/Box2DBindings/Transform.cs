using System;
using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
public struct Transform : IEquatable<Transform>
{
    [FieldOffset(0)]
    public Vec2 Position;
    [FieldOffset(8)]
    public Rotation Rotation;
    
    public static readonly Transform Identity = new()
        {
            Position = Vec2.Zero,
            Rotation = Rotation.Identity
        };
        
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