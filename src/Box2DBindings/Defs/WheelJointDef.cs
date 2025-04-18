using System;

namespace Box2D;

/// <summary>
/// Wheel joint definition
///
/// This requires defining a line of motion using an axis and an anchor point.
/// The definition uses local  anchor points and a local axis so that the initial
/// configuration can violate the constraint slightly. The joint translation is zero
/// when the local anchor points coincide in world space.
/// </summary>
public class WheelJointDef
{
    internal WheelJointDefInternal _internal;
    
    public WheelJointDef()
    {
        _internal = new WheelJointDefInternal();
    }

    /// <summary>
    /// The first attached body
    /// </summary>
    public Body BodyA
    {
        get => _internal.BodyA;
        set => _internal.BodyA = value;
    }

    /// <summary>
    /// The second attached body
    /// </summary>
    public Body BodyB
    {
        get => _internal.BodyB;
        set => _internal.BodyB = value;
    }

    /// <summary>
    /// The local anchor point relative to bodyA's origin
    /// </summary>
    public Vec2 LocalAnchorA
    {
        get => _internal.LocalAnchorA;
        set => _internal.LocalAnchorA = value;
    }

    /// <summary>
    /// The local anchor point relative to bodyB's origin
    /// </summary>
    public Vec2 LocalAnchorB
    {
        get => _internal.LocalAnchorB;
        set => _internal.LocalAnchorB = value;
    }

    /// <summary>
    /// The local translation unit axis in bodyA
    /// </summary>
    public Vec2 LocalAxisA
    {
        get => _internal.LocalAxisA;
        set => _internal.LocalAxisA = value;
    }

    /// <summary>
    /// Enable a linear spring along the local axis
    /// </summary>
    public bool EnableSpring
    {
        get => _internal.EnableSpring;
        set => _internal.EnableSpring = value;
    }

    /// <summary>
    /// Spring stiffness in Hertz
    /// </summary>
    public float Hertz
    {
        get => _internal.Hertz;
        set => _internal.Hertz = value;
    }

    /// <summary>
    /// Spring damping ratio, non-dimensional
    /// </summary>
    public float DampingRatio
    {
        get => _internal.DampingRatio;
        set => _internal.DampingRatio = value;
    }

    /// <summary>
    /// Enable/disable the joint linear limit
    /// </summary>
    public bool EnableLimit
    {
        get => _internal.EnableLimit;
        set => _internal.EnableLimit = value;
    }

    /// <summary>
    /// The lower translation limit
    /// </summary>
    public float LowerTranslation
    {
        get => _internal.LowerTranslation;
        set => _internal.LowerTranslation = value;
    }

    /// <summary>
    /// The upper translation limit
    /// </summary>
    public float UpperTranslation
    {
        get => _internal.UpperTranslation;
        set => _internal.UpperTranslation = value;
    }
    
    /// <summary>
    /// Enable/disable the joint rotational motor
    /// </summary>
    public bool EnableMotor
    {
        get => _internal.EnableMotor;
        set => _internal.EnableMotor = value;
    }

    /// <summary>
    /// The maximum motor torque, typically in newton-meters
    /// </summary>
    public float MaxMotorTorque
    {
        get => _internal.MaxMotorTorque;
        set => _internal.MaxMotorTorque = value;
    }

    /// <summary>
    /// The desired motor speed in radians per second
    /// </summary>
    public float MotorSpeed
    {
        get => _internal.MotorSpeed;
        set => _internal.MotorSpeed = value;
    }

    /// <summary>
    /// Set this flag to true if the attached bodies should collide
    /// </summary>
    public bool CollideConnected
    {
        get => _internal.CollideConnected;
        set => _internal.CollideConnected = value;
    }

    /// <summary>
    /// User data pointer
    /// </summary>
    public object? UserData
    {
        get => Core.GetObjectAtPointer(_internal.UserData);
        set => Core.SetObjectAtPointer(ref _internal.UserData, value);
    }


}