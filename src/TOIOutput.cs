using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Output parameters for TimeOfImpact.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct TOIOutput
{
    /// <summary>
    /// The type of result
    /// </summary>
    [FieldOffset(0)]
    public TOIState State;

    /// <summary>
    /// The sweep time of the collision
    /// </summary>
    [FieldOffset(4)]
    public float Fraction;
}