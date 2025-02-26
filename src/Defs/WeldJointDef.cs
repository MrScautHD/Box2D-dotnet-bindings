using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Weld joint definition<br/>
///
/// A weld joint connect to bodies together rigidly. This constraint provides springs to mimic
/// soft-body simulation.
/// <i>Note: The approximate solver in Box2D cannot hold many bodies together rigidly</i>.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct WeldJointDef
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
    /// The bodyB angle minus bodyA angle in the reference state (radians)
    /// </summary>
    [FieldOffset(32)]
    public float ReferenceAngle;

    /// <summary>
    /// Linear stiffness expressed as Hertz (cycles per second). Use zero for maximum stiffness.
    /// </summary>
    [FieldOffset(36)]
    public float LinearHertz;

    /// <summary>
    /// Angular stiffness as Hertz (cycles per second). Use zero for maximum stiffness.
    /// </summary>
    [FieldOffset(40)]
    public float AngularHertz;

    /// <summary>
    /// Linear damping ratio, non-dimensional. Use 1 for critical damping.
    /// </summary>
    [FieldOffset(44)]
    public float LinearDampingRatio;

    /// <summary>
    /// Linear damping ratio, non-dimensional. Use 1 for critical damping.
    /// </summary>
    [FieldOffset(48)]
    public float AngularDampingRatio;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(52)]
    public bool CollideConnected;

    /// <summary>
    /// User data pointer
    /// </summary>
    [FieldOffset(56)]
    public nint UserData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(64)]
    private readonly int internalValue;
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultWeldJointDef")]
    private static extern WeldJointDef GetDefault();
    
    /// <summary>
    /// The default weld joint definition.
    /// </summary>
    public static WeldJointDef Default => GetDefault();
    
    public WeldJointDef()
    {
        this = Default;
    }
}