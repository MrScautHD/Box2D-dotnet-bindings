using System.Runtime.InteropServices;

namespace Box2D.Character_Movement;

/// <summary>
/// Result returned by b2SolvePlanes.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct PlaneSolverResult
{
    /// <summary>
    /// The final position of the mover.
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Position;

    /// <summary>
    /// The number of iterations used by the plane solver. For diagnostics.
    /// </summary>
    [FieldOffset(8)]
    public int IterationCount;
}