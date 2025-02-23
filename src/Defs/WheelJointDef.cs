using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Wheel joint definition
///
/// This requires defining a line of motion using an axis and an anchor point.
/// The definition uses local  anchor points and a local axis so that the initial
/// configuration can violate the constraint slightly. The joint translation is zero
/// when the local anchor points coincide in world space.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct WheelJointDef
{
    /// <summary>
    /// The first attached body
    /// </summary>
    public Body BodyA;

    /// <summary>
    /// The second attached body
    /// </summary>
    public Body BodyB;

    /// <summary>
    /// The local anchor point relative to bodyA's origin
    /// </summary>
    public Vec2 LocalAnchorA;

    /// <summary>
    /// The local anchor point relative to bodyB's origin
    /// </summary>
    public Vec2 LocalAnchorB;

    /// <summary>
    /// The local translation unit axis in bodyA
    /// </summary>
    public Vec2 LocalAxisA;

    /// <summary>
    /// Enable a linear spring along the local axis
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableSpring;

    /// <summary>
    /// Spring stiffness in Hertz
    /// </summary>
    public float Hertz;

    /// <summary>
    /// Spring damping ratio, non-dimensional
    /// </summary>
    public float DampingRatio;

    /// <summary>
    /// Enable/disable the joint linear limit
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableLimit;

    /// <summary>
    /// The lower translation limit
    /// </summary>
    public float LowerTranslation;

    /// <summary>
    /// The upper translation limit
    /// </summary>
    public float UpperTranslation;

    /// <summary>
    /// Enable/disable the joint rotational motor
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableMotor;

    /// <summary>
    /// The maximum motor torque, typically in newton-meters
    /// </summary>
    public float MaxMotorTorque;

    /// <summary>
    /// The desired motor speed in radians per second
    /// </summary>
    public float MotorSpeed;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool CollideConnected;

    /// <summary>
    /// User data pointer
    /// </summary>
    public nint UserData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    private readonly int InternalValue = Box2D.B2_SECRET_COOKIE;
    
    public WheelJointDef()
    {
        BodyA = default;
        BodyB = default;
        LocalAnchorA = default;
        LocalAnchorB = default;
        LocalAxisA = default;
        EnableSpring = false;
        Hertz = 0;
        DampingRatio = 0;
        EnableLimit = false;
        LowerTranslation = 0;
        UpperTranslation = 0;
        EnableMotor = false;
        MaxMotorTorque = 0;
        MotorSpeed = 0;
        CollideConnected = false;
        UserData = 0;
    }
}