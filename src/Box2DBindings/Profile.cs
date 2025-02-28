using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Profiling data. Times are in milliseconds.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Profile
{
    [FieldOffset(0)]
    public float Step;
    [FieldOffset(4)]
    public float Pairs;
    [FieldOffset(8)]
    public float Collide;
    [FieldOffset(12)]
    public float Solve;
    [FieldOffset(16)]
    public float MergeIslands;
    [FieldOffset(20)]
    public float PrepareStages;
    [FieldOffset(24)]
    public float SolveConstraints;
    [FieldOffset(28)]
    public float PrepareConstraints;
    [FieldOffset(32)]
    public float UntegrateVelocities;
    [FieldOffset(36)]
    public float WarmStart;
    [FieldOffset(40)]
    public float SolveImpulses;
    [FieldOffset(44)]
    public float IntegratePositions;
    [FieldOffset(48)]
    public float RelaxImpulses;
    [FieldOffset(52)]
    public float ApplyRestitution;
    [FieldOffset(56)]
    public float StoreImpulses;
    [FieldOffset(60)]
    public float SplitIslands;
    [FieldOffset(64)]
    public float Transforms;
    [FieldOffset(68)]
    public float HitEvents;
    [FieldOffset(72)]
    public float Refit;
    [FieldOffset(76)]
    public float Bullets;
    [FieldOffset(80)]
    public float SleepIslands;
    [FieldOffset(84)]
    public float Sensors;
}