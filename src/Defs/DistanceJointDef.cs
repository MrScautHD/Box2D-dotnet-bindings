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
[StructLayout(LayoutKind.Explicit)]
public struct DistanceJointDef
{
    /// <summary>
    /// The first attached body
    /// </summary>
    [FieldOffset(0)]
    public Body BodyA;

    /// <summary>
    /// The second attached body
    /// </summary>
    [FieldOffset(8)]
    public Body BodyB;

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
    /// The rest length of this joint. Clamped to a stable minimum value.
    /// </summary>
    [FieldOffset(32)]
    public float Length;

    /// <summary>
    /// Enable the distance constraint to behave like a spring. If false
    /// then the distance joint will be rigid, overriding the limit and motor.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(36)]
    public bool EnableSpring;

    /// <summary>
    /// The spring linear stiffness Hertz, cycles per second
    /// </summary>
    [FieldOffset(40)]
    public float Hertz;

    /// <summary>
    /// The spring linear damping ratio, non-dimensional
    /// </summary>
    [FieldOffset(44)]
    public float DampingRatio;

    /// <summary>
    /// Enable/disable the joint limit
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(48)]
    public bool EnableLimit;

    /// <summary>
    /// Minimum length. Clamped to a stable minimum value.
    /// </summary>
    [FieldOffset(52)]
    public float MinLength;

    /// <summary>
    /// Maximum length. Must be greater than or equal to the minimum length.
    /// </summary>
    [FieldOffset(56)]
    public float MaxLength;

    /// <summary>
    /// Enable/disable the joint motor
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(60)]
    public bool EnableMotor;

    /// <summary>
    /// The maximum motor force, usually in newtons
    /// </summary>
    [FieldOffset(64)]
    public float MaxMotorForce;

    /// <summary>
    /// The desired motor speed, usually in meters per second
    /// </summary>
    [FieldOffset(68)]
    public float MotorSpeed;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(72)]
    public bool CollideConnected;

    /// <summary>
    /// User data pointer
    /// </summary>
    [FieldOffset(76)]
    public nint userData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(80)]
    private readonly int internalValue;
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultDistanceJointDef")]
    public static extern DistanceJointDef Default();
    
    public DistanceJointDef()
    {
        this = Default();
    }
}