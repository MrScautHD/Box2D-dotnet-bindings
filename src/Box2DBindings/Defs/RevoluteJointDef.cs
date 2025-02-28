using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Revolute joint definition<br/>
///
/// This requires defining an anchor point where the bodies are joined.
/// The definition uses local anchor points so that the
/// initial configuration can violate the constraint slightly. You also need to
/// specify the initial relative angle for joint limits. This helps when saving
/// and loading a game.
/// The local anchor points are measured from the body's origin
/// rather than the center of mass because:
/// 1. you might not know where the center of mass will be
/// 2. if you add/remove shapes from a body and recompute the mass, the joints will be broken
/// </summary>
public class RevoluteJointDef
{
    internal RevoluteJointDefInternal _internal;
    
    public RevoluteJointDef()
    {
        _internal = new RevoluteJointDefInternal();
    }
    
    ~RevoluteJointDef()
    {
        Box2D.FreeHandle(_internal.UserData);
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
    /// The bodyB angle minus bodyA angle in the reference state (radians).
    /// This defines the zero angle for the joint limit.
    /// </summary>
    public float ReferenceAngle
    {
        get => _internal.ReferenceAngle;
        set => _internal.ReferenceAngle = value;
    }

    /// <summary>
    /// Enable a rotational spring on the revolute hinge axis
    /// </summary>
    public bool EnableSpring
    {
        get => _internal.EnableSpring;
        set => _internal.EnableSpring = value;
    }

    /// <summary>
    /// The spring stiffness Hertz, cycles per second
    /// </summary>
    public float Hertz
    {
        get => _internal.Hertz;
        set => _internal.Hertz = value;
    }

    /// <summary>
    /// The spring damping ratio, non-dimensional
    /// </summary>
    public float DampingRatio
    {
        get => _internal.DampingRatio;
        set => _internal.DampingRatio = value;
    }

    /// <summary>
    /// A flag to enable joint limits
    /// </summary>
    public bool EnableLimit
    {
        get => _internal.EnableLimit;
        set => _internal.EnableLimit = value;
    }

    /// <summary>
    /// The lower angle for the joint limit in radians
    /// </summary>
    public float LowerAngle
    {
        get => _internal.LowerAngle;
        set => _internal.LowerAngle = value;
    }

    /// <summary>
    /// The upper angle for the joint limit in radians
    /// </summary>
    public float UpperAngle
    {
        get => _internal.UpperAngle;
        set => _internal.UpperAngle = value;
    }

    /// <summary>
    /// A flag to enable the joint motor
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
    /// Scale the debug draw
    /// </summary>
    public float DrawSize
    {
        get => _internal.DrawSize;
        set => _internal.DrawSize = value;
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
    /// User data
    /// </summary>
    public object? UserData
    {
        get => Box2D.GetObjectAtPointer(_internal.UserData);
        set => Box2D.SetObjectAtPointer(ref _internal.UserData, value);
    }
}