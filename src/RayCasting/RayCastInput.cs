using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Low level ray cast input data
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct RayCastInput
{
    /// <summary>
    /// Start point of the ray cast
    /// </summary>
    public Vec2 Origin;

    /// <summary>
    /// Translation of the ray cast
    /// </summary>
    public Vec2 Translation;

    /// <summary>
    /// The maximum fraction of the translation to consider, typically 1
    /// </summary>
    public float MaxFraction;
}