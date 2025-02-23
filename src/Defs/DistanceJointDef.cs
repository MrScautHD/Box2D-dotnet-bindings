using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Distance joint definition<br/>
///
/// This requires defining an anchor point on both
/// bodies and the non-zero distance of the distance joint. The definition uses
/// local anchor points so that the initial configuration can violate the
/// constraint slightly. This helps when saving and loading a game.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct DistanceJointDef
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
    /// The rest length of this joint. Clamped to a stable minimum value.
    /// </summary>
    public float Length;

    /// <summary>
    /// Enable the distance constraint to behave like a spring. If false
    /// then the distance joint will be rigid, overriding the limit and motor.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableSpring;

    /// <summary>
    /// The spring linear stiffness Hertz, cycles per second
    /// </summary>
    public float Hertz;

    /// <summary>
    /// The spring linear damping ratio, non-dimensional
    /// </summary>
    public float DampingRatio;

    /// <summary>
    /// Enable/disable the joint limit
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableLimit;

    /// <summary>
    /// Minimum length. Clamped to a stable minimum value.
    /// </summary>
    public float MinLength;

    /// <summary>
    /// Maximum length. Must be greater than or equal to the minimum length.
    /// </summary>
    public float MaxLength;

    /// <summary>
    /// Enable/disable the joint motor
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableMotor;

    /// <summary>
    /// The maximum motor force, usually in newtons
    /// </summary>
    public float MaxMotorForce;

    /// <summary>
    /// The desired motor speed, usually in meters per second
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
    public nint userData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    private readonly int InternalValue = Box2D.B2_SECRET_COOKIE;
    
    public DistanceJointDef()
    {
        BodyA = default;
        BodyB = default;
        LocalAnchorA = default;
        LocalAnchorB = default;
        Length = 0;
        EnableSpring = false;
        Hertz = 0;
        DampingRatio = 0;
        EnableLimit = false;
        MinLength = 0;
        MaxLength = 0;
        EnableMotor = false;
        MaxMotorForce = 0;
        MotorSpeed = 0;
        CollideConnected = false;
        userData = 0;
    }
}