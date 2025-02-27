using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A body definition holds all the data needed to construct a rigid body.
/// You can safely re-use body definitions. Shapes are added to a body after construction.
/// Body definitions are temporary objects used to bundle creation parameters.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
struct BodyDefInternal
{
    /// <summary>
    /// The body type: static, kinematic, or dynamic.
    /// </summary>
    [FieldOffset(0)]
    internal BodyType Type;

    /// <summary>
    /// The initial world position of the body. Bodies should be created with the desired position.
    /// <i>Note: Creating bodies at the origin and then moving them nearly doubles the cost of body creation, especially
    /// if the body is moved after shapes have been added.</i>
    /// </summary>
    [FieldOffset(4)]
    public Vec2 Position;

    /// <summary>
    /// The initial world rotation of the body.
    /// </summary>
    [FieldOffset(12)]
    public Rotation Rotation;

    /// <summary>
    /// The initial linear velocity of the body's origin. Usually in meters per second.
    /// </summary>
    [FieldOffset(20)]
    public Vec2 LinearVelocity;

    /// <summary>
    /// The initial angular velocity of the body. Radians per second.
    /// </summary>
    [FieldOffset(28)]
    public float AngularVelocity;

    /// <summary>
    /// Linear damping is used to reduce the linear velocity. The damping parameter
    /// can be larger than 1 but the damping effect becomes sensitive to the
    /// time step when the damping parameter is large.
    /// Generally linear damping is undesirable because it makes objects move slowly
    /// as if they are floating.
    /// </summary>
    [FieldOffset(32)]
    public float LinearDamping;

    /// <summary>
    /// Angular damping is used to reduce the angular velocity. The damping parameter
    /// can be larger than 1.0f but the damping effect becomes sensitive to the
    /// time step when the damping parameter is large.
    /// Angular damping can be use slow down rotating bodies.
    /// </summary>
    [FieldOffset(36)]
    public float AngularDamping;

    /// <summary>
    /// Scale the gravity applied to this body. Non-dimensional.
    /// </summary>
    [FieldOffset(40)]
    public float GravityScale;

    /// <summary>
    /// Sleep speed threshold, default is 0.05 meters per second
    /// </summary>
    [FieldOffset(44)]
    public float SleepThreshold;

    [FieldOffset(48)]
    internal nint Name;
	
    /// <summary>
    /// Use this to store application specific body data.
    /// </summary>
    [FieldOffset(56)]
    public nint UserData;

    /// <summary>
    /// Set this flag to false if this body should never fall asleep.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(64)]
    public bool EnableSleep;

    /// <summary>
    /// Is this body initially awake or sleeping?
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(65)]
    public bool IsAwake;

    /// <summary>
    /// Should this body be prevented from rotating? Useful for characters.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(66)]
    public bool FixedRotation;

    /// <summary>
    /// Treat this body as high speed object that performs continuous collision detection
    /// against dynamic and kinematic bodies, but not other bullet bodies.
    /// <b>Warning: Bullets should be used sparingly. They are not a solution for general dynamic-versus-dynamic</b>
    /// continuous collision. They may interfere with joint constraints.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(67)]
    public bool IsBullet;

    /// <summary>
    /// Used to disable a body. A disabled body does not move or collide.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(68)]
    public bool IsEnabled;

    /// <summary>
    /// This allows this body to bypass rotational speed limits. Should only be used
    /// for circular objects, like wheels.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(69)]
    public bool AllowFastRotation;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(72)]
    private readonly int internalValue;
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultBodyDef")]
    private static extern BodyDefInternal GetDefault();
    
    /// <summary>
    /// Default body definition.
    /// </summary>
    public static BodyDefInternal Default => GetDefault();

    /// <summary>
    /// Creates a body definition with the default values.
    /// </summary>
    public BodyDefInternal()
    {
        this = Default;
    }
}