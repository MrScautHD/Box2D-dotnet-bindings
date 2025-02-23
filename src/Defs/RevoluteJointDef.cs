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
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct RevoluteJointDef
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
    /// The bodyB angle minus bodyA angle in the reference state (radians).
    /// This defines the zero angle for the joint limit.
    /// </summary>
    public float ReferenceAngle;

    /// <summary>
    /// Enable a rotational spring on the revolute hinge axis
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableSpring;

    /// <summary>
    /// The spring stiffness Hertz, cycles per second
    /// </summary>
    public float Hertz;

    /// <summary>
    /// The spring damping ratio, non-dimensional
    /// </summary>
    public float DampingRatio;

    /// <summary>
    /// A flag to enable joint limits
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableLimit;

    /// <summary>
    /// The lower angle for the joint limit in radians
    /// </summary>
    public float LowerAngle;

    /// <summary>
    /// The upper angle for the joint limit in radians
    /// </summary>
    public float UpperAngle;

    /// <summary>
    /// A flag to enable the joint motor
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool RnableMotor;

    /// <summary>
    /// The maximum motor torque, typically in newton-meters
    /// </summary>
    public float MaxMotorTorque;

    /// <summary>
    /// The desired motor speed in radians per second
    /// </summary>
    public float MotorSpeed;

    /// <summary>
    /// Scale the debug draw
    /// </summary>
    public float DrawSize;

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
    
    public RevoluteJointDef()
    {
        BodyA = default;
        BodyB = default;
        LocalAnchorA = default;
        LocalAnchorB = default;
        ReferenceAngle = 0;
        EnableSpring = false;
        Hertz = 0;
        DampingRatio = 0;
        EnableLimit = false;
        LowerAngle = 0;
        UpperAngle = 0;
        RnableMotor = false;
        MaxMotorTorque = 0;
        MotorSpeed = 0;
        DrawSize = 0;
        CollideConnected = false;
        UserData = 0;
    }
}