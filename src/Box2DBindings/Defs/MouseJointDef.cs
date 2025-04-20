using JetBrains.Annotations;
using System;

namespace Box2D;

/// <summary>
/// A mouse joint is used to make a point on a body track a specified world point.<br/>
///
/// This a soft constraint and allows the constraint to stretch without
/// applying huge forces. This also applies rotation constraint heuristic to improve control.
/// </summary>
public class MouseJointDef
{
    internal MouseJointDefInternal _internal;

    [PublicAPI]
    public MouseJointDef()
    {
        _internal = MouseJointDefInternal.Default;
    }

    /// <summary>
    /// The first attached body. This is assumed to be static.
    /// </summary>
    [PublicAPI]
    public ref Body BodyA => ref _internal.BodyA;

    /// <summary>
    /// The second attached body.
    /// </summary>
    [PublicAPI]
    public ref Body BodyB => ref _internal.BodyB;

    /// <summary>
    /// The initial target point in world space
    /// </summary>
    [PublicAPI]
    public ref Vec2 Target => ref _internal.Target;

    /// <summary>
    /// Stiffness in hertz
    /// </summary>
    [PublicAPI]
    public ref float Hertz => ref _internal.Hertz;

    /// <summary>
    /// Damping ratio, non-dimensional
    /// </summary>
    [PublicAPI]
    public ref float DampingRatio => ref _internal.DampingRatio;

    /// <summary>
    /// Maximum force, typically in newtons
    /// </summary>
    [PublicAPI]
    public ref float MaxForce => ref _internal.MaxForce;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide.
    /// </summary>
    [PublicAPI]
    public ref bool CollideConnected => ref _internal.CollideConnected;

    /// <summary>
    /// User data pointer
    /// </summary>
    [PublicAPI]
    public object? UserData
    {
        get => GetObjectAtPointer(_internal.UserData);
        set => SetObjectAtPointer(ref _internal.UserData, value);
    }
}