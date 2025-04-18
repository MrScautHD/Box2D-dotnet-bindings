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
    
    /// <summary>
    /// Validate ray cast input data (NaN, etc)
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2IsValidRay")]
    private static extern bool IsValidRay(in RayCastInput input);
    
    /// <summary>
    /// Validate this ray cast input data (NaN, etc)
    /// </summary>
    public bool IsValid => IsValidRay(this);

}