using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Surface materials allow chain shapes to have per segment surface properties.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct SurfaceMaterial
{
    /// <summary>
    /// The Coulomb (dry) friction coefficient, usually in the range [0,1].
    /// </summary>
    public float Friction;

    /// <summary>
    /// The coefficient of restitution (bounce) usually in the range [0,1].<br/>
    /// https://en.wikipedia.org/wiki/Coefficient_of_restitution
    /// </summary>
    public float Restitution;

    /// <summary>
    /// The rolling resistance usually in the range [0,1].
    /// </summary>
    public float RollingResistance;

    /// <summary>
    /// The tangent speed for conveyor belts
    /// </summary>
    public float TangentSpeed;

    /// <summary>
    /// User material identifier. This is passed with query results and to friction and restitution
    /// combining functions. It is not used internally.
    /// </summary>
    public int Material;

    /// <summary>
    /// Custom debug draw color.
    /// </summary>
    public HexColor CustomColor;
    public SurfaceMaterial()
    {
        Friction = 0.6f;
    }
}