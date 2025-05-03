using JetBrains.Annotations;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Low level shape cast input in generic form. This allows casting an arbitrary point
/// cloud wrap with a radius. For example, a circle is a single point with a non-zero radius.
/// A capsule is two points with a non-zero radius. A box is four points with a zero radius.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
[PublicAPI]
public struct ShapeCastInput
{
    /// <summary>
    /// A generic shape
    /// </summary>
    public ShapeProxy Proxy;
    
    /// <summary>
    /// The translation of the shape cast
    /// </summary>
    public Vec2 Translation;
    
    /// <summary>
    /// The maximum fraction of the translation to consider, typically 1
    /// </summary>
    public float MaxFraction;
    
    private byte canEncroach;
    
    /// <summary>
    /// Allow shape cast to encroach when initially touching. This only works if the radius is greater than zero.
    /// </summary>
    public bool CanEncroach
    {
        get => canEncroach != 0;
        set => canEncroach = value ? (byte)1 : (byte)0;
    }
}