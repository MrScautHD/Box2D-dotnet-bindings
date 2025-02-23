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
[StructLayout(LayoutKind.Explicit)]
public struct RevoluteJointDef
{
    [FieldOffset(0)]
    private BodyId bodyA;
    
    /// <summary>
    /// The first attached body
    /// </summary>
    public Body? BodyA => Body.GetBody(bodyA);

    [FieldOffset(8)]
    private BodyId bodyB;
    
    /// <summary>
    /// The second attached body
    /// </summary>
    public Body? BodyB => Body.GetBody(bodyB);

    /// <summary>
    /// The local anchor point relative to bodyA's origin
    /// </summary>
    [FieldOffset(16)]
    public Vec2 LocalAnchorA;

    /// <summary>
    /// The local anchor point relative to bodyB's origin
    /// </summary>
    [FieldOffset(24)]
    public Vec2 LocalAnchorB;

    /// <summary>
    /// The bodyB angle minus bodyA angle in the reference state (radians).
    /// This defines the zero angle for the joint limit.
    /// </summary>
    [FieldOffset(32)]
    public float ReferenceAngle;

    /// <summary>
    /// Enable a rotational spring on the revolute hinge axis
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(36)]
    public bool EnableSpring;

    /// <summary>
    /// The spring stiffness Hertz, cycles per second
    /// </summary>
    [FieldOffset(40)]
    public float Hertz;

    /// <summary>
    /// The spring damping ratio, non-dimensional
    /// </summary>
    [FieldOffset(44)]
    public float DampingRatio;

    /// <summary>
    /// A flag to enable joint limits
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(48)]
    public bool EnableLimit;

    /// <summary>
    /// The lower angle for the joint limit in radians
    /// </summary>
    [FieldOffset(52)]
    public float LowerAngle;

    /// <summary>
    /// The upper angle for the joint limit in radians
    /// </summary>
    [FieldOffset(56)]
    public float UpperAngle;

    /// <summary>
    /// A flag to enable the joint motor
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(60)]
    public bool RnableMotor;

    /// <summary>
    /// The maximum motor torque, typically in newton-meters
    /// </summary>
    [FieldOffset(64)]
    public float MaxMotorTorque;

    /// <summary>
    /// The desired motor speed in radians per second
    /// </summary>
    [FieldOffset(68)]
    public float MotorSpeed;

    /// <summary>
    /// Scale the debug draw
    /// </summary>
    [FieldOffset(72)]
    public float DrawSize;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(76)]
    public bool CollideConnected;

    /// <summary>
    /// User data pointer
    /// </summary>
    [FieldOffset(80)]
    public nint UserData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(88)]
    private readonly int internalValue = Box2D.B2_SECRET_COOKIE;
    
    public RevoluteJointDef()
    {
        bodyA = default;
        bodyB = default;
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