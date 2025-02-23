using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A manifold point is a contact point belonging to a contact manifold.
/// It holds details related to the geometry and dynamics of the contact points.
/// Box2D uses speculative collision so some contact points may be separated.
/// You may use the maxNormalImpulse to determine if there was an interaction during
/// the time step.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ManifoldPoint
{
    /// <summary>
    /// Location of the contact point in world space. Subject to precision loss at large coordinates.
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Point;

    /// <summary>
    /// Location of the contact point relative to shapeA's origin in world space
    /// </summary>
    [FieldOffset(8)]
    public Vec2 AnchorA;

    /// <summary>
    /// Location of the contact point relative to shapeB's origin in world space
    /// </summary>
    [FieldOffset(16)]
    public Vec2 AnchorB;

    /// <summary>
    /// The separation of the contact point, negative if penetrating
    /// </summary>
    [FieldOffset(24)]
    public float Separation;

    /// <summary>
    /// The impulse along the manifold normal vector.
    /// </summary>
    [FieldOffset(28)]
    public float NormalImpulse;

    /// <summary>
    /// The friction impulse
    /// </summary>
    [FieldOffset(32)]
    public float TangentImpulse;

    /// <summary>
    /// The maximum normal impulse applied during sub-stepping. This is important
    /// to identify speculative contact points that had an interaction in the time step.
    /// </summary>
    [FieldOffset(36)]
    public float MaxNormalImpulse;

    /// <summary>
    /// Relative normal velocity pre-solve. Used for hit events. If the normal impulse is
    /// zero then there was no hit. Negative means shapes are approaching.
    /// </summary>
    [FieldOffset(40)]
    public float NormalVelocity;

    /// <summary>
    /// Uniquely identifies a contact point between two shapes
    /// </summary>
    [FieldOffset(44)]
    public ushort Id;

    /// <summary>
    /// Did this contact point exist the previous step?
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(46)]
    public bool Persisted;
}