using JetBrains.Annotations;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// The explosion definition is used to configure options for explosions. Explosions
/// consider shape geometry when computing the impulse.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
[PublicAPI]
public struct ExplosionDef
{
    /// <summary>
    /// Mask bits to filter shapes
    /// </summary>
    public ulong MaskBits;

    /// <summary>
    /// The center of the explosion in world space
    /// </summary>
    public Vec2 Position;

    /// <summary>
    /// The radius of the explosion
    /// </summary>
    public float Radius;

    /// <summary>
    /// The falloff distance beyond the radius. Impulse is reduced to zero at this distance.
    /// </summary>
    public float Falloff;

    /// <summary>
    /// Impulse per unit length. This applies an impulse according to the shape perimeter that
    /// is facing the explosion. Explosions only apply to circles, capsules, and polygons. This
    /// may be negative for implosions.
    /// </summary>
    public float ImpulsePerLength;
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultExplosionDef")]
    private static extern ExplosionDef GetDefault();
    
    /// <summary>
    /// The default explosion definition.
    /// </summary>
    [PublicAPI]
    public static ExplosionDef Default => GetDefault();
    
    /// <summary>
    /// Creates a new explosion definition with the default values.
    /// </summary>
    [PublicAPI]
    public ExplosionDef()
    {
        this = Default;
    }
}