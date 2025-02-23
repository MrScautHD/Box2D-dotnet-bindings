using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A mouse joint is used to make a point on a body track a specified world point.<br/>
///
/// This a soft constraint and allows the constraint to stretch without
/// applying huge forces. This also applies rotation constraint heuristic to improve control.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct MouseJointDef
{
    /// <summary>
    /// The first attached body. This is assumed to be static.
    /// </summary>
    public Body BodyA;

    /// <summary>
    /// The second attached body.
    /// </summary>
    public Body BodyB;

    /// <summary>
    /// The initial target point in world space
    /// </summary>
    public Vec2 Target;

    /// <summary>
    /// Stiffness in hertz
    /// </summary>
    public float Hertz;

    /// <summary>
    /// Damping ratio, non-dimensional
    /// </summary>
    public float DampingRatio;

    /// <summary>
    /// Maximum force, typically in newtons
    /// </summary>
    public float MaxForce;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide.
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
    
    public MouseJointDef()
    {
        BodyA = default;
        BodyB = default;
        Target = default;
        Hertz = 0;
        DampingRatio = 0;
        MaxForce = 0;
        CollideConnected = false;
        UserData = 0;
    }
}