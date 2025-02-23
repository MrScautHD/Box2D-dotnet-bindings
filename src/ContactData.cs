using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// The contact data for two shapes. By convention the manifold normal points
/// from shape A to shape B.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct ContactData
{
    public Shape ShapeA;
    public Shape ShapeB;
    public Manifold manifold;
}