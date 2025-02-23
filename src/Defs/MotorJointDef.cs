using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A motor joint is used to control the relative motion between two bodies<br/>
///
/// A typical usage is to control the movement of a dynamic body with respect to the ground.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct MotorJointDef
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
    /// Position of bodyB minus the position of bodyA, in bodyA's frame
    /// </summary>
    public Vec2 LinearOffset;

    /// <summary>
    /// The bodyB angle minus bodyA angle in radians
    /// </summary>
    public float AngularOffset;

    /// <summary>
    /// The maximum motor force in newtons
    /// </summary>
    public float MaxForce;

    /// <summary>
    /// The maximum motor torque in newton-meters
    /// </summary>
    public float MaxTorque;

    /// <summary>
    /// Position correction factor in the range [0,1]
    /// </summary>
    public float CorrectionFactor;

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
    
    public MotorJointDef()
    {
        BodyA = default;
        BodyB = default;
        LinearOffset = default;
        AngularOffset = 0;
        MaxForce = 0;
        MaxTorque = 0;
        CorrectionFactor = 0;
        CollideConnected = false;
        UserData = 0;
    }
}