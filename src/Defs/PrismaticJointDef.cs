using System.Runtime.InteropServices;

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

    public PrismaticJointDef()
    {
        _internal = new PrismaticJointDefInternal();
    }

    ~PrismaticJointDef()
    {
        if (_internal.UserData != 0)
            GCHandle.FromIntPtr(_internal.UserData).Free();
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
    /// The constrained angle between the bodies: bodyB_angle - bodyA_angle
    /// </summary>
    public float ReferenceAngle
    {
        get => _internal.ReferenceAngle;
        set => _internal.ReferenceAngle = value;
    }

    /// <summary>
    /// Enable a linear spring along the prismatic joint axis
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
    /// Enable/disable the joint limit
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
    /// Enable/disable the joint motor
    /// </summary>
    public bool EnableMotor
    {
        get => _internal.EnableMotor;
        set => _internal.EnableMotor = value;
    }

    /// <summary>
    /// The maximum motor force, typically in newtons
    /// </summary>
    public float MaxMotorForce
    {
        get => _internal.MaxMotorForce;
        set => _internal.MaxMotorForce = value;
    }

    /// <summary>
    /// The desired motor speed, typically in meters per second
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
    /// User data
    /// </summary>
    public object? UserData
    {
        get => GCHandle.FromIntPtr(_internal.UserData).Target;
        set => _internal.UserData = GCHandle.ToIntPtr(GCHandle.Alloc(value, GCHandleType.Normal));
    }

}