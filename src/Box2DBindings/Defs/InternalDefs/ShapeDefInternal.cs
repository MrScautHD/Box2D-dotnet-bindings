using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Used to create a shape.
/// This is a temporary object used to bundle shape creation parameters. You may use
/// the same shape definition to create multiple shapes.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
struct ShapeDefInternal
{
    /// <summary>
    /// Use this to store application specific shape data.
    /// </summary>
    [FieldOffset(0)]
    internal nint UserData;
    
    /// <summary>
    /// The Coulomb (dry) friction coefficient, usually in the range [0,1].
    /// </summary>
    [FieldOffset(8)]
    internal float Friction;

    /// <summary>
    /// The coefficient of restitution (bounce) usually in the range [0,1].<br/>
    /// https://en.wikipedia.org/wiki/Coefficient_of_restitution
    /// </summary>
    [FieldOffset(12)]
    internal float Restitution;

    /// <summary>
    /// The rolling resistance usually in the range [0,1].
    /// </summary>
    [FieldOffset(16)]
    internal float RollingResistance;

    /// <summary>
    /// The tangent speed for conveyor belts
    /// </summary>
    [FieldOffset(20)]
    internal float TangentSpeed;

    /// <summary>
    /// User material identifier. This is passed with query results and to friction and restitution
    /// combining functions. It is not used internally.
    /// </summary>
    [FieldOffset(24)]
    internal int Material;

    /// <summary>
    /// The density, usually in kg/m².
    /// </summary>
    [FieldOffset(28)]
    internal float Density;

    /// <summary>
    /// Collision filtering data.
    /// </summary>
    [FieldOffset(32)]
    internal Filter Filter; // 24 bytes

    /// <summary>
    /// Custom debug draw color.
    /// </summary>
    [FieldOffset(56)]
    internal HexColor CustomColor;

    /// <summary>
    /// A sensor shape generates overlap events but never generates a collision response.
    /// Sensors do not collide with other sensors and do not have continuous collision.
    /// Instead, use a ray or shape cast for those scenarios.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(60)]
    internal bool IsSensor;

    /// <summary>
    /// Enable contact events for this shape. Only applies to kinematic and dynamic bodies. Ignored for sensors.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(61)]
    internal bool EnableContactEvents;

    /// <summary>
    /// Enable hit events for this shape. Only applies to kinematic and dynamic bodies. Ignored for sensors.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(62)]
    internal bool EnableHitEvents;

    /// <summary>
    /// Enable pre-solve contact events for this shape. Only applies to dynamic bodies. These are expensive
    /// and must be carefully handled due to threading. Ignored for sensors.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(63)]
    internal bool EnablePreSolveEvents;

    /// <summary>
    /// Normally shapes on static bodies don't invoke contact creation when they are added to the world. This overrides
    /// that behavior and causes contact creation. This significantly slows down static body creation which can be important
    /// when there are many static shapes.
    /// This is implicitly always true for sensors, dynamic bodies, and kinematic bodies.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(64)]
    internal bool InvokeContactCreation;

    /// <summary>
    /// Should the body update the mass properties when this shape is created. Default is true.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(65)]
    internal bool UpdateBodyMass;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(68)]
    private readonly int internalValue;
    
    /// <summary>
    /// The default shape definition.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultShapeDef")]
    private static extern ShapeDefInternal GetDefault();
    
    /// <summary>
    /// The default shape definition.
    /// </summary>
    public static ShapeDefInternal Default => GetDefault();
    
    public ShapeDefInternal()
    {
        this = Default;
    }
}