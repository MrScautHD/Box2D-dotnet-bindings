using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A motor joint is used to control the relative motion between two bodies<br/>
///
/// A typical usage is to control the movement of a dynamic body with respect to the ground.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct MotorJointDef
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
    /// Position of bodyB minus the position of bodyA, in bodyA's frame
    /// </summary>
    [FieldOffset(16)]
    public Vec2 LinearOffset;

    /// <summary>
    /// The bodyB angle minus bodyA angle in radians
    /// </summary>
    [FieldOffset(24)]
    public float AngularOffset;

    /// <summary>
    /// The maximum motor force in newtons
    /// </summary>
    [FieldOffset(28)]
    public float MaxForce;

    /// <summary>
    /// The maximum motor torque in newton-meters
    /// </summary>
    [FieldOffset(32)]
    public float MaxTorque;

    /// <summary>
    /// Position correction factor in the range [0,1]
    /// </summary>
    [FieldOffset(36)]
    public float CorrectionFactor;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(40)]
    public bool CollideConnected;

    /// <summary>
    /// User data pointer
    /// </summary>
    [FieldOffset(44)]
    private nint userData;

    /// <summary>
    /// User data pointer
    /// </summary>
    public object? UserData
    {
        get => GCHandle.FromIntPtr(userData).Target;
        set => userData = GCHandle.ToIntPtr(GCHandle.Alloc(value));
    }

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(52)]
    private readonly int internalValue;
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultMotorJointDef")]
    private static extern MotorJointDef GetDefault();
    
    /// <summary>
    /// The default motor joint definition.
    /// </summary>
    public static MotorJointDef Default => GetDefault();
    
    /// <summary>
    /// Creates a motor joint definition with the default values.
    /// </summary>
    public MotorJointDef()
    {
        this = Default;
    }
}