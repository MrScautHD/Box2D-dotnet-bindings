using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Profiling data. Times are in milliseconds.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Profile
{
    public readonly float Step;
    public readonly float Pairs;
    public readonly float Collide;
    public readonly float Solve;
    public readonly float MergeIslands;
    public readonly float PrepareStages;
    public readonly float SolveConstraints;
    public readonly float PrepareConstraints;
    public readonly float UntegrateVelocities;
    public readonly float WarmStart;
    public readonly float SolveImpulses;
    public readonly float IntegratePositions;
    public readonly float RelaxImpulses;
    public readonly float ApplyRestitution;
    public readonly float StoreImpulses;
    public readonly float SplitIslands;
    public readonly float Transforms;
    public readonly float HitEvents;
    public readonly float Refit;
    public readonly float Bullets;
    public readonly float SleepIslands;
    public readonly float Sensors;
}