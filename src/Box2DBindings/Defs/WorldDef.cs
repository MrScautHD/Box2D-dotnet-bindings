using JetBrains.Annotations;
using System;

namespace Box2D;

/// <summary>
/// World definition used to create a simulation world.
/// </summary>
public class WorldDef
{
    internal WorldDefInternal _internal;
    
    [PublicAPI]
    public WorldDef()
    {
        _internal = new WorldDefInternal();
    }
    
    [PublicAPI]
    public static WorldDef Default => new ();
    
    /// <summary>
    /// Gravity vector. Box2D has no up-vector defined.
    /// </summary>
    [PublicAPI]
    public ref Vec2 Gravity => ref _internal.Gravity;

    /// <summary>
    /// Restitution speed threshold, usually in m/s. Collisions above this
    /// speed have restitution applied (will bounce).
    /// </summary>
    [PublicAPI]
    public ref float RestitutionThreshold => ref _internal.RestitutionThreshold;

    /// <summary>
    /// Threshold speed for hit events. Usually meters per second.
    /// </summary>
    [PublicAPI]
    public ref float HitEventThreshold => ref _internal.HitEventThreshold;

    /// <summary>
    /// Contact stiffness. Cycles per second. Increasing this increases the speed of overlap recovery, but can introduce jitter.
    /// </summary>
    [PublicAPI]
    public ref float ContactHertz => ref _internal.ContactHertz;

    /// <summary>
    /// Contact bounciness. Non-dimensional. You can speed up overlap recovery by decreasing this with
    /// the trade-off that overlap resolution becomes more energetic.
    /// </summary>
    [PublicAPI]
    public ref float ContactDampingRatio => ref _internal.ContactDampingRatio;

    /// <summary>
    /// This parameter controls how fast overlap is resolved and usually has units of meters per second. This only
    /// puts a cap on the resolution speed. The resolution speed is increased by increasing the hertz and/or
    /// decreasing the damping ratio.
    /// </summary>
    [PublicAPI]
    public ref float MaxContactPushSpeed => ref _internal.MaxContactPushSpeed;

    /// <summary>
    /// Joint stiffness. Cycles per second.
    /// </summary>
    [PublicAPI]
    public ref float JointHertz => ref _internal.JointHertz;

    /// <summary>
    /// Joint bounciness. Non-dimensional.
    /// </summary>
    [PublicAPI]
    public ref float JointDampingRatio => ref _internal.JointDampingRatio;

    /// <summary>
    /// Maximum linear speed. Usually meters per second.
    /// </summary>
    [PublicAPI]
    public ref float MaximumLinearSpeed => ref _internal.MaximumLinearSpeed;

    /// <summary>
    /// Optional mixing callback for friction. The default uses sqrt(frictionA * frictionB).
    /// </summary>
    [PublicAPI]
    public ref FrictionCallback FrictionCallback => ref _internal.FrictionCallback;

    /// <summary>
    /// Optional mixing callback for restitution. The default uses max(restitutionA, restitutionB).
    /// </summary>
    [PublicAPI]
    public ref RestitutionCallback RestitutionCallback => ref _internal.RestitutionCallback;

    /// <summary>
    /// Can bodies go to sleep to improve performance
    /// </summary>
    [PublicAPI]
    public ref bool EnableSleep => ref _internal.EnableSleep;

    /// <summary>
    /// Enable continuous collision
    /// </summary>
    [PublicAPI]
    public ref bool EnableContinuous => ref _internal.EnableContinuous;

    /// <summary>
    /// Number of workers to use with the provided task system. Box2D performs best when using only
    /// performance cores and accessing a single L2 cache. Efficiency cores and hyper-threading provide
    /// little benefit and may even harm performance.<br/>
    /// <i>Note: Box2D does not create threads. This is the number of threads your applications has created
    /// that you are allocating to World.Step()</i><br/>
    /// <b>Warning: Do not modify the default value unless you are also providing a task system and providing
    /// task callbacks (enqueueTask and finishTask).</b>
    /// </summary>
    [PublicAPI]
    public ref int WorkerCount => ref _internal.WorkerCount;

    /// <summary>
    /// Callback function to spawn tasks
    /// </summary>
    [PublicAPI]
    public ref EnqueueTaskCallback EnqueueTask => ref _internal.EnqueueTask;

    /// <summary>
    /// Callback function to finish a task
    /// </summary>
    [PublicAPI]
    public ref FinishTaskCallback FinishTask => ref _internal.FinishTask;

    /// <summary>
    /// User data pointer
    /// </summary>
    [PublicAPI]
    public object? UserData
    {
        get => GetObjectAtPointer(_internal.UserData);
        set => SetObjectAtPointer(ref _internal.UserData, value);
    }
    
    /// <summary>
    /// User context that is provided to enqueueTask and finishTask
    /// </summary>
    [PublicAPI]
    public object? UserTaskContext
    {
        get => GetObjectAtPointer(_internal.UserTaskContext);
        set => SetObjectAtPointer(ref _internal.UserTaskContext, value);
    }
}