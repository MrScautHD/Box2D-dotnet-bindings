using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Output parameters for TimeOfImpact.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct TOIOutput
{
    /// <summary>
    /// The type of result
    /// </summary>
    public TOIState State;

    /// <summary>
    /// The sweep time of the collision
    /// </summary>
    public float Fraction;
}