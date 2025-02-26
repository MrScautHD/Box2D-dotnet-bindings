using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A mouse joint is used to make a point on a body track a specified world point.<br/>
///
/// This a soft constraint and allows the constraint to stretch without
/// applying huge forces. This also applies rotation constraint heuristic to improve control.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct MouseJointDef
{
    /// <summary>
    /// The first attached body. This is assumed to be static.
    /// </summary>
    [FieldOffset(0)]
    public Body BodyA;
    
    /// <summary>
    /// The second attached body.
    /// </summary>
    [FieldOffset(8)]
    public Body BodyB;

    /// <summary>
    /// The initial target point in world space
    /// </summary>
    [FieldOffset(16)]
    public Vec2 Target;

    /// <summary>
    /// Stiffness in hertz
    /// </summary>
    [FieldOffset(24)]
    public float Hertz;

    /// <summary>
    /// Damping ratio, non-dimensional
    /// </summary>
    [FieldOffset(28)]
    public float DampingRatio;

    /// <summary>
    /// Maximum force, typically in newtons
    /// </summary>
    [FieldOffset(32)]
    public float MaxForce;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(36)]
    public bool CollideConnected;

    /// <summary>
    /// User data pointer
    /// </summary>
    [FieldOffset(40)]
    public nint UserData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(48)]
    private readonly int internalValue;
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultMouseJointDef")]
    public static extern MouseJointDef Default();
    
    public MouseJointDef()
    {
        this = Default();
    }
}