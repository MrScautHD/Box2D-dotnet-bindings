using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Surface materials allow chain shapes to have per segment surface properties.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct SurfaceMaterial
{
    /// <summary>
    /// The Coulomb (dry) friction coefficient, usually in the range [0,1].
    /// </summary>
    [FieldOffset(0)]
    public float Friction;

    /// <summary>
    /// The coefficient of restitution (bounce) usually in the range [0,1].<br/>
    /// https://en.wikipedia.org/wiki/Coefficient_of_restitution
    /// </summary>
    [FieldOffset(4)]
    public float Restitution;

    /// <summary>
    /// The rolling resistance usually in the range [0,1].
    /// </summary>
    [FieldOffset(8)]
    public float RollingResistance;

    /// <summary>
    /// The tangent speed for conveyor belts
    /// </summary>
    [FieldOffset(12)]
    public float TangentSpeed;

    /// <summary>
    /// User material identifier. This is passed with query results and to friction and restitution
    /// combining functions. It is not used internally.
    /// </summary>
    [FieldOffset(16)]
    public int Material;

    /// <summary>
    /// Custom debug draw color.
    /// </summary>
    [FieldOffset(20)]
    public HexColor CustomColor;
    
    public SurfaceMaterial()
    {
        Friction = 0.6f;
    }
}