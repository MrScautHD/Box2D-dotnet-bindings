using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Weld joint definition<br/>
///
/// A weld joint connect to bodies together rigidly. This constraint provides springs to mimic
/// soft-body simulation.
/// <i>Note: The approximate solver in Box2D cannot hold many bodies together rigidly</i>.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct WeldJointDef
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
    /// The bodyB angle minus bodyA angle in the reference state (radians)
    /// </summary>
    public float ReferenceAngle;

    /// <summary>
    /// Linear stiffness expressed as Hertz (cycles per second). Use zero for maximum stiffness.
    /// </summary>
    public float LinearHertz;

    /// <summary>
    /// Angular stiffness as Hertz (cycles per second). Use zero for maximum stiffness.
    /// </summary>
    public float AngularHertz;

    /// <summary>
    /// Linear damping ratio, non-dimensional. Use 1 for critical damping.
    /// </summary>
    public float LinearDampingRatio;

    /// <summary>
    /// Linear damping ratio, non-dimensional. Use 1 for critical damping.
    /// </summary>
    public float AngularDampingRatio;

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
    
    public WeldJointDef()
    {
        BodyA = default;
        BodyB = default;
        LocalAnchorA = default;
        LocalAnchorB = default;
        ReferenceAngle = 0;
        LinearHertz = 0;
        AngularHertz = 0;
        LinearDampingRatio = 0;
        AngularDampingRatio = 0;
        CollideConnected = false;
        UserData = 0;
    }
}