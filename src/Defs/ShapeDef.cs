using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Used to create a shape.
/// This is a temporary object used to bundle shape creation parameters. You may use
/// the same shape definition to create multiple shapes.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ShapeDef
{
    /// <summary>
    /// Use this to store application specific shape data.
    /// </summary>
    [FieldOffset(0)]
    public nint UserData;
	
    /// <summary>
    /// The Coulomb (dry) friction coefficient, usually in the range [0,1].
    /// </summary>
    [FieldOffset(8)]
    public float Friction;

    /// <summary>
    /// The coefficient of restitution (bounce) usually in the range [0,1].<br/>
    /// https://en.wikipedia.org/wiki/Coefficient_of_restitution
    /// </summary>
    [FieldOffset(12)]
    public float Restitution;

    /// <summary>
    /// The rolling resistance usually in the range [0,1].
    /// </summary>
    [FieldOffset(16)]
    public float RollingResistance;

    /// <summary>
    /// The tangent speed for conveyor belts
    /// </summary>
    [FieldOffset(20)]
    public float TangentSpeed;

    /// <summary>
    /// User material identifier. This is passed with query results and to friction and restitution
    /// combining functions. It is not used internally.
    /// </summary>
    [FieldOffset(24)]
    public int Material;

    /// <summary>
    /// The density, usually in kg/m².
    /// </summary>
    [FieldOffset(28)]
    public float Density;

    /// <summary>
    /// Collision filtering data.
    /// </summary>
    [FieldOffset(32)]
    public Filter Filter; // 24 bytes

    /// <summary>
    /// Custom debug draw color.
    /// </summary>
    [FieldOffset(56)]
    public HexColor CustomColor;

    /// <summary>
    /// A sensor shape generates overlap events but never generates a collision response.
    /// Sensors do not collide with other sensors and do not have continuous collision.
    /// Instead, use a ray or shape cast for those scenarios.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(60)]
    public bool IsSensor;

    /// <summary>
    /// Enable contact events for this shape. Only applies to kinematic and dynamic bodies. Ignored for sensors.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(61)]
    public bool EnableContactEvents;

    /// <summary>
    /// Enable hit events for this shape. Only applies to kinematic and dynamic bodies. Ignored for sensors.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(62)]
    public bool EnableHitEvents;

    /// <summary>
    /// Enable pre-solve contact events for this shape. Only applies to dynamic bodies. These are expensive
    /// and must be carefully handled due to threading. Ignored for sensors.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(63)]
    public bool EnablePreSolveEvents;

    /// <summary>
    /// Normally shapes on static bodies don't invoke contact creation when they are added to the world. This overrides
    /// that behavior and causes contact creation. This significantly slows down static body creation which can be important
    /// when there are many static shapes.
    /// This is implicitly always true for sensors, dynamic bodies, and kinematic bodies.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(64)]
    public bool InvokeContactCreation;

    /// <summary>
    /// Should the body update the mass properties when this shape is created. Default is true.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(65)]
    public bool UpdateBodyMass;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(68)]
    private readonly int InternalValue;
    
    /// <summary>
    /// The default shape definition.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultShapeDef")]
    public static extern ShapeDef Default();
    
    public ShapeDef()
    {
        this = Default();
    }
}