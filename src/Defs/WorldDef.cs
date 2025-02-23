using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// World definition used to create a simulation world.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct WorldDef
{
    /// <summary>
    /// Gravity vector. Box2D has no up-vector defined.
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Gravity;

    /// <summary>
    /// Restitution speed threshold, usually in m/s. Collisions above this
    /// speed have restitution applied (will bounce).
    /// </summary>
    [FieldOffset(8)]
    public float RestitutionThreshold;

    /// <summary>
    /// Threshold speed for hit events. Usually meters per second.
    /// </summary>
    [FieldOffset(12)]
    public float HitEventThreshold;

    /// <summary>
    /// Contact stiffness. Cycles per second. Increasing this increases the speed of overlap recovery, but can introduce jitter.
    /// </summary>
    [FieldOffset(16)]
    public float ContactHertz;

    /// <summary>
    /// Contact bounciness. Non-dimensional. You can speed up overlap recovery by decreasing this with
    /// the trade-off that overlap resolution becomes more energetic.
    /// </summary>
    [FieldOffset(20)]
    public float ContactDampingRatio;

    /// <summary>
    /// This parameter controls how fast overlap is resolved and usually has units of meters per second. This only
    /// puts a cap on the resolution speed. The resolution speed is increased by increasing the hertz and/or
    /// decreasing the damping ratio.
    /// </summary>
    [FieldOffset(24)]
    public float ContactPushMaxSpeed;

    /// <summary>
    /// Joint stiffness. Cycles per second.
    /// </summary>
    [FieldOffset(28)]
    public float JointHertz;

    /// <summary>
    /// Joint bounciness. Non-dimensional.
    /// </summary>
    [FieldOffset(32)]
    public float JointDampingRatio;

    /// <summary>
    /// Maximum linear speed. Usually meters per second.
    /// </summary>
    [FieldOffset(36)]
    public float MaximumLinearSpeed;

    [FieldOffset(40)]
    private nint frictionCallback;

    /// <summary>
    /// Optional mixing callback for friction. The default uses sqrt(frictionA * frictionB).
    /// </summary>
    public FrictionCallback FrictionCallback
    {
        get => Marshal.GetDelegateForFunctionPointer<FrictionCallback>(frictionCallback);
        set => frictionCallback = Marshal.GetFunctionPointerForDelegate(value);
    }

    [FieldOffset(48)]
    private nint restitutionCallback;
	
    /// <summary>
    /// Optional mixing callback for restitution. The default uses max(restitutionA, restitutionB).
    /// </summary>
    public RestitutionCallback RestitutionCallback
    {
        get => Marshal.GetDelegateForFunctionPointer<RestitutionCallback>(restitutionCallback);
        set => restitutionCallback = Marshal.GetFunctionPointerForDelegate(value);
    }

    /// <summary>
    /// Can bodies go to sleep to improve performance
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(56)]
    public bool EnableSleep;

    /// <summary>
    /// Enable continuous collision
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(57)]
    public bool EnableContinuous;

    /// <summary>
    /// Number of workers to use with the provided task system. Box2D performs best when using only
    /// performance cores and accessing a single L2 cache. Efficiency cores and hyper-threading provide
    /// little benefit and may even harm performance.<br/>
    /// <i>Note: Box2D does not create threads. This is the number of threads your applications has created
    /// that you are allocating to World.Step()</i><br/>
    /// <b>Warning: Do not modify the default value unless you are also providing a task system and providing
    /// task callbacks (enqueueTask and finishTask).</b>
    /// </summary>
    [FieldOffset(60)]
    public int WorkerCount;

    [FieldOffset(64)]
    private nint enqueueTask;
	
    /// <summary>
    /// Function to spawn tasks
    /// </summary>
    public EnqueueTaskCallback EnqueueTask
    {
        get => Marshal.GetDelegateForFunctionPointer<EnqueueTaskCallback>(enqueueTask);
        set => enqueueTask = Marshal.GetFunctionPointerForDelegate(value);
    }

    [FieldOffset(72)]
    private nint finishTask;
	
    /// <summary>
    /// Function to finish a task
    /// </summary>
    public FinishTaskCallback FinishTask
    {
        get => Marshal.GetDelegateForFunctionPointer<FinishTaskCallback>(finishTask);
        set => finishTask = Marshal.GetFunctionPointerForDelegate(value);
    }

    /// <summary>
    /// User context that is provided to enqueueTask and finishTask
    /// </summary>
    [FieldOffset(80)]
    public nint UserTaskContext;

    /// <summary>
    /// User data
    /// </summary>
    [FieldOffset(88)]
    public nint UserData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(96)]
    private readonly int internalValue = Box2D.B2_SECRET_COOKIE;
    
    public WorldDef()
    {
        Gravity = (0,-10);
        RestitutionThreshold = 1;
        HitEventThreshold = 1;
        ContactHertz = 30;
        ContactDampingRatio = 10;
        ContactPushMaxSpeed = 0;
        JointHertz = 60;
        JointDampingRatio = 2;
        MaximumLinearSpeed = 400;
        frictionCallback = 0;
        restitutionCallback = 0;
        EnableSleep = true;
        EnableContinuous = true;
        WorkerCount = 0;
        enqueueTask = 0;
        finishTask = 0;
        UserTaskContext = 0;
        UserData = 0;
    }
}