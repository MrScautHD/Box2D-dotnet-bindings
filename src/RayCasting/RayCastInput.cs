using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Low level ray cast input data
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct RayCastInput
{
    /// <summary>
    /// Start point of the ray cast
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Origin;

    /// <summary>
    /// Translation of the ray cast
    /// </summary>
    [FieldOffset(8)]
    public Vec2 Translation;

    /// <summary>
    /// The maximum fraction of the translation to consider, typically 1
    /// </summary>
    [FieldOffset(16)]
    public float MaxFraction;
}