using System.Runtime.InteropServices;

namespace Box2D.Character_Movement;

/// <summary>
/// Result returned by b2SolvePlanes.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct PlaneSolverResult
{
    /// <summary>
    /// The final position of the mover.
    /// </summary>
    public Vec2 Position;

    /// <summary>
    /// The number of iterations used by the plane solver. For diagnostics.
    /// </summary>
    public int IterationCount;
}