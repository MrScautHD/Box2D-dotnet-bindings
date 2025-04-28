using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Sequential)]
public struct Transform : IEquatable<Transform>
{
    public Vec2 Position;
    public Rotation Rotation;
    
    public static readonly Transform Identity = new()
        {
            Position = Vec2.Zero,
            Rotation = Rotation.Identity
        };

    public Transform(Vec2 position, Rotation rotation)
    {
        Position = position;
        Rotation = rotation;
    }
    
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
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string DebuggerDisplay => $"Transform(Position: {Position}, Rotation: {Rotation})";
}