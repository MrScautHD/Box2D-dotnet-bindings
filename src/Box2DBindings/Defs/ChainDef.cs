using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Used to create a chain of line segments. This is designed to eliminate ghost collisions with some limitations.
/// <ul>
/// <li>chains are one-sided</li>
/// <li>chains have no mass and should be used on static bodies</li>
/// <li>chains have a counter-clockwise winding order</li>
/// <li>chains are either a loop or open</li>
/// <li>a chain must have at least 4 points</li>
/// <li>the distance between any two points must be greater than B2_LINEAR_SLOP</li>
/// <li>a chain shape should not self intersect (this is not validated)</li>
/// <li>an open chain shape has NO COLLISION on the first and final edge</li>
/// <li>you may overlap two open chains on their first three and/or last three points to get smooth collision</li>
/// <li>a chain shape creates multiple line segment shapes on the body</li>
/// </ul>
/// https://en.wikipedia.org/wiki/Polygonal_chain<br/>
/// <b>Warning: Do not use chain shapes unless you understand the limitations. This is an advanced feature.</b>
/// </summary>
public class ChainDef
{
    internal ChainDefInternal _internal;

    /// <summary>
    /// Creates a chain definition with the default values.
    /// </summary>
    public ChainDef()
    {
        _internal = new ChainDefInternal();
    }

    unsafe ~ChainDef()
    {
        if (_internal.Points != 0)
        {
            Marshal.FreeHGlobal(_internal.Points);
            _internal.Points = 0;
        }
        if (_internal.Materials != 0 && materialsAllocated)
        {
            Marshal.FreeHGlobal(_internal.Materials);
            _internal.Materials = 0;
        }
    }

    /// <summary>
    /// Use this to store application specific shape data.
    /// </summary>
    public object? UserData
    {
        get => Core.GetObjectAtPointer(_internal.UserData);
        set => Core.SetObjectAtPointer(ref _internal.UserData, value);
    }

    /// <summary>
    /// An array of at least 4 points. These are cloned and may be temporary.
    /// </summary> 
    public unsafe Vec2[] Points
    {
        set {
            if (_internal.Points != 0)
            {
                Marshal.FreeHGlobal(_internal.Points);
                _internal.Points = 0;
                _internal.Count = 0;
            }
            if (value.Length > 0)
            {
                _internal.Points = Marshal.AllocHGlobal(value.Length * sizeof(Vec2));
                for (int i = 0; i < value.Length; i++)
                    ((Vec2*)_internal.Points)[i] = value[i];
                _internal.Count = value.Length;
            }
        }
    }

    private bool materialsAllocated = false;
    
    /// <summary>
    /// Surface materials for each segment. These are cloned.
    /// </summary>
    public unsafe SurfaceMaterial[] Materials
    {
        set {
            if (_internal.Materials != 0 && materialsAllocated)
            {
                Marshal.FreeHGlobal(_internal.Materials);
                _internal.Materials = 0;
                _internal.MaterialCount = 0;
            }
            if (value.Length > 0)
            {
                _internal.Materials = Marshal.AllocHGlobal(value.Length * sizeof(SurfaceMaterial));
                for (int i = 0; i < value.Length; i++)
                    ((SurfaceMaterial*)_internal.Materials)[i] = value[i];
                _internal.MaterialCount = value.Length;
                materialsAllocated = true;
            }
        }
    }
    
    /// <summary>
    /// Contact filtering data.
    /// </summary>
    public Filter Filter
    {
        get => _internal.Filter;
        set => _internal.Filter = value;
    }

    /// <summary>
    /// Indicates a closed chain formed by connecting the first and last points
    /// </summary>
    public bool IsLoop
    {
        get => _internal.IsLoop;
        set => _internal.IsLoop = value;
    }

    /// <summary>
    /// Enable sensors to detect this chain. False by default.
    /// </summary>
    public bool EnableSensorEvents
    {
        get => _internal.EnableSensorEvents;
        set => _internal.EnableSensorEvents = value;
    }
    
}