using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Profiling data. Times are in milliseconds.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Profile
{
    public float Step;
    public float Pairs;
    public float Collide;
    public float Solve;
    public float MergeIslands;
    public float PrepareStages;
    public float SolveConstraints;
    public float PrepareConstraints;
    public float UntegrateVelocities;
    public float WarmStart;
    public float SolveImpulses;
    public float IntegratePositions;
    public float RelaxImpulses;
    public float ApplyRestitution;
    public float StoreImpulses;
    public float SplitIslands;
    public float Transforms;
    public float HitEvents;
    public float Refit;
    public float Bullets;
    public float SleepIslands;
    public float Sensors;
}