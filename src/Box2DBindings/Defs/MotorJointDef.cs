using System;

namespace Box2D;

/// <summary>
/// A motor joint is used to control the relative motion between two bodies<br/>
///
/// A typical usage is to control the movement of a dynamic body with respect to the ground.
/// </summary>
public class MotorJointDef
{
    internal MotorJointDefInternal _internal;

    public MotorJointDef()
    {
        _internal = new MotorJointDefInternal();
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
    /// Position of bodyB minus the position of bodyA, in bodyA's frame
    /// </summary>
    public Vec2 LinearOffset
    {
        get => _internal.LinearOffset;
        set => _internal.LinearOffset = value;
    }

    /// <summary>
    /// The bodyB angle minus bodyA angle in radians
    /// </summary>
    public float AngularOffset
    {
        get => _internal.AngularOffset;
        set => _internal.AngularOffset = value;
    }

    /// <summary>
    /// The maximum motor force in newtons
    /// </summary>
    public float MaxForce
    {
        get => _internal.MaxForce;
        set => _internal.MaxForce = value;
    }

    /// <summary>
    /// The maximum motor torque in newton-meters
    /// </summary>
    public float MaxTorque
    {
        get => _internal.MaxTorque;
        set => _internal.MaxTorque = value;
    }

    /// <summary>
    /// Position correction factor in the range [0,1]
    /// </summary>
    public float CorrectionFactor
    {
        get => _internal.CorrectionFactor;
        set => _internal.CorrectionFactor = value;
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
    /// Use this to store application specific shape data.
    /// </summary>
    public object? UserData
    {
        get => Box2D.GetObjectAtPointer(_internal.UserData);
        set => Box2D.SetObjectAtPointer(ref _internal.UserData, value);
    }
}
