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
    
    ~ShapeCastInput()
    {
        if (_internal.Points != 0)
            Marshal.FreeHGlobal(_internal.Points);
    }

    public unsafe Vec2[] Points
    {
        set
        {
            if (_internal.Points != 0)
                Marshal.FreeHGlobal(_internal.Points);
            _internal.Points = Marshal.AllocHGlobal(value.Length * sizeof(Vec2));
            for (int i = 0; i < value.Length; i++)
                ((Vec2*)_internal.Points)[i] = value[i];
            _internal.Count = value.Length;
        }
    }

    public float Radius
    {
        get => _internal.Radius;
        set => _internal.Radius = value;
    }
    
    public Vec2 Translation
    {
        get => _internal.Translation;
        set => _internal.Translation = value;
    }
    
    public float MaxFraction
    {
        get => _internal.MaxFraction;
        set => _internal.MaxFraction = value;
    }
    
}