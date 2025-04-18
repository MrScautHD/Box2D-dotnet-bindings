using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Low level shape cast input in generic form. This allows casting an arbitrary point
/// cloud wrap with a radius. For example, a circle is a single point with a non-zero radius.
/// A capsule is two points with a non-zero radius. A box is four points with a zero radius.
/// </summary>
public class ShapeCastInput
{
    internal ShapeCastInputInternal _internal;
    
    public ShapeCastInput()
    {
        _internal = new ShapeCastInputInternal();
    }
    
    /// <summary>
    /// A generic shape
    /// </summary>
    public ShapeProxy Proxy
    {
        get => _internal.proxy;
        set => _internal.proxy = value;
    }
    
    /// <summary>
    /// The translation of the shape cast
    /// </summary>
    public Vec2 Translation
    {
        get => _internal.Translation;
        set => _internal.Translation = value;
    }
    
    /// <summary>
    /// The maximum fraction of the translation to consider, typically 1
    /// </summary>
    public float MaxFraction
    {
        get => _internal.MaxFraction;
        set => _internal.MaxFraction = value;
    }
 
    /// <summary>
    /// Allow shape cast to encroach when initially touching. This only works if the radius is greater than zero.
    /// </summary>
    public bool CanEncroach
    {
        get => _internal.CanEncroach;
        set => _internal.CanEncroach = value;
    }
    
}