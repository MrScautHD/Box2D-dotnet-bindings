using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// The contact data for two shapes. By convention the manifold normal points
/// from shape A to shape B.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ContactData
{
    [FieldOffset(0)]
    public Shape ShapeA;
    [FieldOffset(8)]
    public Shape ShapeB;
    [FieldOffset(16)]
    public Manifold Manifold;
}