using JetBrains.Annotations;
using System;

namespace Box2D;

/// <summary>
/// Prismatic joint definition<br/>
///
/// This requires defining a line of motion using an axis and an anchor point.
/// The definition uses local anchor points and a local axis so that the initial
/// configuration can violate the constraint slightly. The joint translation is zero
/// when the local anchor points coincide in world space.
/// </summary>
public class PrismaticJointDef
{
    internal PrismaticJointDefInternal _internal;

    [PublicAPI]
    public PrismaticJointDef()
    {
        _internal = new PrismaticJointDefInternal();
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
    /// The local translation unit axis in bodyA
    /// </summary>
    [PublicAPI]
    public ref Vec2 LocalAxisA => ref _internal.LocalAxisA;

    /// <summary>
    /// The constrained angle between the bodies: bodyB_angle - bodyA_angle
    /// </summary>
    [PublicAPI]
    public ref float ReferenceAngle => ref _internal.ReferenceAngle;

    /// <summary>
    /// Enable a linear spring along the prismatic joint axis
    /// </summary>
    [PublicAPI]
    public ref bool EnableSpring => ref _internal.EnableSpring;

    /// <summary>
    /// The spring stiffness Hertz, cycles per second
    /// </summary>
    [PublicAPI]
    public ref float Hertz => ref _internal.Hertz;

    /// <summary>
    /// The spring damping ratio, non-dimensional
    /// </summary>
    [PublicAPI]
    public ref float DampingRatio => ref _internal.DampingRatio;

    /// <summary>
    /// Enable/disable the joint limit
    /// </summary>
    [PublicAPI]
    public ref bool EnableLimit => ref _internal.EnableLimit;

    /// <summary>
    /// The lower translation limit
    /// </summary>
    [PublicAPI]
    public ref float LowerTranslation => ref _internal.LowerTranslation;

    /// <summary>
    /// The upper translation limit
    /// </summary>
    [PublicAPI]
    public ref float UpperTranslation => ref _internal.UpperTranslation;

    /// <summary>
    /// Enable/disable the joint motor
    /// </summary>
    [PublicAPI]
    public ref bool EnableMotor => ref _internal.EnableMotor;

    /// <summary>
    /// The maximum motor force, typically in newtons
    /// </summary>
    [PublicAPI]
    public ref float MaxMotorForce => ref _internal.MaxMotorForce;

    /// <summary>
    /// The desired motor speed, typically in meters per second
    /// </summary>
    [PublicAPI]
    public ref float MotorSpeed => ref _internal.MotorSpeed;

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