using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A manifold point is a contact point belonging to a contact manifold.
/// It holds details related to the geometry and dynamics of the contact points.
/// Box2D uses speculative collision so some contact points may be separated.
/// You may use the maxNormalImpulse to determine if there was an interaction during
/// the time step.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct ManifoldPoint
{
    /// <summary>
    /// Location of the contact point in world space. Subject to precision loss at large coordinates.
    /// </summary>
    public Vec2 Point;

    /// <summary>
    /// Location of the contact point relative to shapeA's origin in world space
    /// </summary>
    public Vec2 AnchorA;

    /// <summary>
    /// Location of the contact point relative to shapeB's origin in world space
    /// </summary>
    public Vec2 AnchorB;

    /// <summary>
    /// The separation of the contact point, negative if penetrating
    /// </summary>
    public float Separation;

    /// <summary>
    /// The impulse along the manifold normal vector.
    /// </summary>
    public float NormalImpulse;

    /// <summary>
    /// The friction impulse
    /// </summary>
    public float TangentImpulse;

    /// <summary>
    /// The maximum normal impulse applied during sub-stepping. This is important
    /// to identify speculative contact points that had an interaction in the time step.
    /// </summary>
    public float MaxNormalImpulse;

    /// <summary>
    /// Relative normal velocity pre-solve. Used for hit events. If the normal impulse is
    /// zero then there was no hit. Negative means shapes are approaching.
    /// </summary>
    public float NormalVelocity;

    /// <summary>
    /// Uniquely identifies a contact point between two shapes
    /// </summary>
    public ushort Id;

    /// <summary>
    /// Did this contact point exist the previous step?
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool Persisted;
}