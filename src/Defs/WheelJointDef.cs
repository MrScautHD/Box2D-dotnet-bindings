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
[StructLayout(LayoutKind.Explicit)]
public struct WheelJointDef
{
    /// <summary>
    /// The first attached body
    /// </summary>
    [FieldOffset(0)]
    private Body BodyA;
    
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
    /// The local translation unit axis in bodyA
    /// </summary>
    [FieldOffset(32)]
    public Vec2 LocalAxisA;

    /// <summary>
    /// Enable a linear spring along the local axis
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(40)]
    public bool EnableSpring;

    /// <summary>
    /// Spring stiffness in Hertz
    /// </summary>
    [FieldOffset(44)]
    public float Hertz;

    /// <summary>
    /// Spring damping ratio, non-dimensional
    /// </summary>
    [FieldOffset(48)]
    public float DampingRatio;

    /// <summary>
    /// Enable/disable the joint linear limit
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(52)]
    public bool EnableLimit;

    /// <summary>
    /// The lower translation limit
    /// </summary>
    [FieldOffset(56)]
    public float LowerTranslation;

    /// <summary>
    /// The upper translation limit
    /// </summary>
    [FieldOffset(60)]
    public float UpperTranslation;

    /// <summary>
    /// Enable/disable the joint rotational motor
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(64)]
    public bool EnableMotor;

    /// <summary>
    /// The maximum motor torque, typically in newton-meters
    /// </summary>
    [FieldOffset(68)]
    public float MaxMotorTorque;

    /// <summary>
    /// The desired motor speed in radians per second
    /// </summary>
    [FieldOffset(72)]
    public float MotorSpeed;

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
    private readonly int internalValue;
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultWheelJointDef")]
    public static extern WheelJointDef Default();
    
    public WheelJointDef()
    {
        this = Default();
    }
}