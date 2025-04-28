using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// This holds the mass data computed for a shape.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct MassData
{
    /// <summary>
    /// The mass of the shape, usually in kilograms.
    /// </summary>
    public readonly float Mass;

    /// <summary>
    /// The position of the shape's centroid relative to the shape's origin.
    /// </summary>
    public readonly Vec2 Center;

    /// <summary>
    /// The rotational inertia of the shape about the local origin.
    /// </summary>
    public readonly float RotationalInertia;
    
    public override string ToString()
    {
        return $"MassData(Mass={Mass}, Center={Center}, RotationalInertia={RotationalInertia})";
    }
}