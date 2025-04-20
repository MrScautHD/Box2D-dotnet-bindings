using JetBrains.Annotations;
using System;

namespace Box2D;

/// <summary>
/// Weld joint definition<br/>
///
/// A weld joint connect to bodies together rigidly. This constraint provides springs to mimic
/// soft-body simulation.
/// <i>Note: The approximate solver in Box2D cannot hold many bodies together rigidly</i>.
/// </summary>
public class WeldJointDef
{
    internal WeldJointDefInternal _internal;
    
    public WeldJointDef()
    {
        _internal = new WeldJointDefInternal();
    }
    
    /// <summary>
    /// The first attached body
    /// </summary>
    [PublicAPI]
    public ref Body BodyA => ref _internal.BodyA;

    /// <summary>
    /// The second attached body
    /// </summary>
    [PublicAPI]
    public ref Body BodyB => ref _internal.BodyB;

    /// <summary>
    /// The local anchor point relative to bodyA's origin
    /// </summary>
    [PublicAPI]
    public ref Vec2 LocalAnchorA => ref _internal.LocalAnchorA;

    /// <summary>
    /// The local anchor point relative to bodyB's origin
    /// </summary>
    [PublicAPI]
    public ref Vec2 LocalAnchorB => ref _internal.LocalAnchorB;

    /// <summary>
    /// The bodyB angle minus bodyA angle in the reference state (radians)
    /// </summary>
    [PublicAPI]
    public ref float ReferenceAngle => ref _internal.ReferenceAngle;

    /// <summary>
    /// Linear stiffness expressed as Hertz (cycles per second). Use zero for maximum stiffness.
    /// </summary>
    [PublicAPI]
    public ref float LinearHertz => ref _internal.LinearHertz;

    /// <summary>
    /// Angular stiffness as Hertz (cycles per second). Use zero for maximum stiffness.
    /// </summary>
    [PublicAPI]
    public ref float AngularHertz => ref _internal.AngularHertz;

    /// <summary>
    /// Linear damping ratio, non-dimensional. Use 1 for critical damping.
    /// </summary>
    [PublicAPI]
    public ref float LinearDampingRatio => ref _internal.LinearDampingRatio;

    /// <summary>
    /// Linear damping ratio, non-dimensional. Use 1 for critical damping.
    /// </summary>
    [PublicAPI]
    public ref float AngularDampingRatio => ref _internal.AngularDampingRatio;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide
    /// </summary>
    [PublicAPI]
    public ref bool CollideConnected => ref _internal.CollideConnected;

    /// <summary>
    /// User data
    /// </summary>
    [PublicAPI]
    public object? UserData
    {
        get => GetObjectAtPointer(_internal.UserData);
        set => SetObjectAtPointer(ref _internal.UserData, value);
    }
}