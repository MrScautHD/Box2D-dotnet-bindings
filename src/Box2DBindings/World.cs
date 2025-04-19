using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
public struct World
{
    [FieldOffset(0)]
    private ushort index1;
    [FieldOffset(2)]
    private ushort generation;

    internal static readonly Dictionary<int, Dictionary<int, Body>> _bodies = new();

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWorld")]
    private static extern World b2CreateWorld(in WorldDefInternal def);

    /// <summary>
    /// Create a world for rigid body simulation. A world contains bodies, shapes, and constraints. You make create up to 128 worlds. Each world is completely independent and may be simulated in parallel.
    /// </summary>
    /// <param name="def">The world definition</param>
    /// <returns>The world</returns>
    public static World CreateWorld(WorldDef def)
    {
        var world = b2CreateWorld(def._internal);
        _bodies.Add(world.index1, new());
        return world;
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyWorld")]
    private static extern void b2DestroyWorld(World worldId);

    /// <summary>
    /// Destroy this world
    /// </summary>
    public void Destroy()
    {
        // dealloc user data
        foreach (var body in _bodies[index1].Values)
            body.Destroy();

        nint userDataPtr = b2World_GetUserData(this);
        Core.FreeHandle(ref userDataPtr);
        b2World_SetUserData(this, 0);
        
        b2DestroyWorld(this);
        _bodies.Remove(index1);
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsValid")]
    private static extern bool b2World_IsValid(World worldId);

    /// <summary>
    /// World id validation. Provides validation for up to 64K allocations.
    /// </summary>
    /// <returns>True if the world id is valid</returns>
    public bool Valid => b2World_IsValid(this);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Step")]
    private static extern void b2World_Step(World worldId, float timeStep, int subStepCount);

    /// <summary>
    /// Simulate a world for one time step. This performs collision detection, integration, and constraint solution.
    /// </summary>
    /// <param name="timeStep">The amount of time to simulate, this should be a fixed number. Usually 1/60.</param>
    /// <param name="subStepCount">The number of sub-steps, increasing the sub-step count can increase accuracy. Usually 4.</param>
    public void Step(float timeStep, int subStepCount) => b2World_Step(this, timeStep, subStepCount);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Draw")]
    private static extern void b2World_Draw(World worldId, in DebugDraw draw);

    /// <summary>
    /// Call this to draw shapes and other debug draw data
    /// </summary>
    /// <param name="draw">The debug draw implementation</param>
    public void Draw(in DebugDraw draw) => b2World_Draw(this, draw);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetBodyEvents")]
    private static extern BodyEvents b2World_GetBodyEvents(World worldId);

    /// <summary>
    /// Get the body events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    /// <returns>The body events</returns>
    public BodyEvents BodyEvents => b2World_GetBodyEvents(this);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetSensorEvents")]
    private static extern SensorEvents b2World_GetSensorEvents(World worldId);

    /// <summary>
    /// Get sensor events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    /// <returns>The sensor events</returns>
    public SensorEvents SensorEvents => b2World_GetSensorEvents(this);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetContactEvents")]
    private static extern ContactEvents b2World_GetContactEvents(World worldId);

    /// <summary>
    /// Get the contact events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    /// <returns>The contact events</returns>
    public ContactEvents ContactEvents => b2World_GetContactEvents(this);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapAABB")]
    private static extern TreeStats b2World_OverlapAABB(World worldId, AABB aabb, QueryFilter filter, OverlapResultCallback fcn, nint context);

    /// <summary>
    /// Overlap test for all shapes that *potentially* overlap the provided AABB
    /// </summary>
    /// <param name="aabb">The AABB</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">The context</param>
    /// <returns>The tree stats</returns>
    public TreeStats OverlapAABB(AABB aabb, QueryFilter filter, OverlapResultCallback fcn, nint context) =>
        b2World_OverlapAABB(this, aabb, filter, fcn, context);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapShape")]
    private static extern TreeStats b2World_OverlapShape(World worldId, in ShapeProxy proxy, QueryFilter filter, OverlapResultCallback fcn, nint context);

    /// <summary>
    /// Overlap test for all shapes that overlap the provided shape proxy
    /// </summary>
    /// <param name="proxy">The shape proxy</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">The context</param>
    public TreeStats OverlapShape(in ShapeProxy proxy, QueryFilter filter, OverlapResultCallback fcn, nint context) =>
        b2World_OverlapShape(this, in proxy, filter, fcn, context);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastRay")]
    private static extern TreeStats b2World_CastRay(World worldId, Vec2 origin, Vec2 translation, QueryFilter filter, CastResultCallback fcn, nint context);

    /// <summary>
    /// Cast a ray into the world to collect shapes in the path of the ray.
    /// </summary>
    /// <param name="origin">The start point of the ray</param>
    /// <param name="translation">The translation of the ray from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">A user context that is passed along to the callback function</param>
    /// <returns>Traversal performance counters</returns>
    /// <remarks>Your callback function controls whether you get the closest point, any point, or n-points. The ray-cast ignores shapes that contain the starting point. The callback function may receive shapes in any order</remarks>
    public TreeStats CastRay(Vec2 origin, Vec2 translation, QueryFilter filter, CastResultCallback fcn, nint context) =>
        b2World_CastRay(this, origin, translation, filter, fcn, context);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastRayClosest")]
    private static extern RayResult b2World_CastRayClosest(World worldId, Vec2 origin, Vec2 translation, QueryFilter filter);

    /// <summary>
    /// Cast a ray into the world to collect the closest hit. This is a convenience function.
    /// </summary>
    /// <param name="origin">The start point of the ray</param>
    /// <param name="translation">The translation of the ray from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <returns>The ray result</returns>
    /// <remarks>This is less general than b2World_CastRay() and does not allow for custom filtering</remarks>
    public RayResult CastRayClosest(Vec2 origin, Vec2 translation, QueryFilter filter) =>
        b2World_CastRayClosest(this, origin, translation, filter);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastMover")]
    private static extern float b2World_CastMover(World worldId, in Capsule mover, Vec2 translation, QueryFilter filter);
    
    /// <summary>
    /// Cast a capsule mover through the world. This is a special shape cast that handles sliding along other shapes while reducing clipping.
    /// </summary>
    /// <param name="mover">The capsule mover</param>
    /// <param name="translation">The translation of the capsule from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <returns>The fraction of the translation that was completed before a collision occurred</returns>
    public float CastMover(in Capsule mover, Vec2 translation, QueryFilter filter) =>
        b2World_CastMover(this, in mover, translation, filter);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CollideMover")]
    private static extern void b2World_CollideMover(World worldId, in Capsule mover, QueryFilter filter, PlaneResultCallback fcn, nint context);
    
    /// <summary>
    /// Collide a capsule mover with the world, gathering collision planes that can be fed to b2SolvePlanes. Useful for kinematic character movement.
    /// </summary>
    /// <param name="mover">The capsule mover</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">A user context that is passed along to the callback function</param>
    public void CollideMover(in Capsule mover, QueryFilter filter, PlaneResultCallback fcn, nint context) =>
        b2World_CollideMover(this, in mover, filter, fcn, context);
    
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastShape")]
    private static extern TreeStats b2World_CastShape(World worldId, in ShapeProxy proxy, Vec2 translation, QueryFilter filter, CastResultCallback fcn, nint context);
    
    /// <summary>
    /// Cast a shape through the world. Similar to a cast ray except that a shape is cast instead of a point.
    /// </summary>
    /// <param name="worldId">The world id</param>
    /// <param name="proxy">The shape proxy</param>
    /// <param name="translation">The translation of the shape from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">A user context that is passed along to the callback function</param>
    public TreeStats CastShape(in ShapeProxy proxy, Vec2 translation, QueryFilter filter, CastResultCallback fcn, nint context) =>
        b2World_CastShape(this, in proxy, translation, filter, fcn, context);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableSleeping")]
    private static extern void b2World_EnableSleeping(World worldId, bool flag);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsSleepingEnabled")]
    private static extern bool b2World_IsSleepingEnabled(World worldId);
    
    /// <summary>
    /// Gets or sets the sleeping enabled status of the world. If your application does not need sleeping, you can gain some performance by disabling sleep completely at the world level.
    /// </summary>
    public bool SleepingEnabled
    {
        get => b2World_IsSleepingEnabled(this);
        set => b2World_EnableSleeping(this, value);
    }
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableContinuous")]
    private static extern void b2World_EnableContinuous(World worldId, bool flag);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsContinuousEnabled")]
    private static extern bool b2World_IsContinuousEnabled(World worldId);
    
    /// <summary>
    /// Gets or sets the continuous collision enabled state of the world.
    /// </summary>
    /// <remarks>Generally you should keep continuous collision enabled to prevent fast moving objects from going through static objects. The performance gain from disabling continuous collision is minor</remarks>
    public bool ContinuousEnabled
    {
        get => b2World_IsContinuousEnabled(this);
        set => b2World_EnableContinuous(this, value);
    }
    
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetRestitutionThreshold")]
    private static extern void b2World_SetRestitutionThreshold(World worldId, float value);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetRestitutionThreshold")]
    private static extern float b2World_GetRestitutionThreshold(World worldId);

    /// <summary>
    /// The restitution speed threshold.
    /// </summary>
    public float RestitutionThreshold
    {
        get => b2World_GetRestitutionThreshold(this);
        set => b2World_SetRestitutionThreshold(this, value);
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetHitEventThreshold")]
    private static extern void b2World_SetHitEventThreshold(World worldId, float value);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetHitEventThreshold")]
    private static extern float b2World_GetHitEventThreshold(World worldId);

    /// <summary>
    /// The hit event threshold in meters per second.
    /// </summary>
    public float HitEventThreshold
    {
        get => b2World_GetHitEventThreshold(this);
        set => b2World_SetHitEventThreshold(this, value);
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetCustomFilterCallback")]
    private static extern void b2World_SetCustomFilterCallback(World worldId, CustomFilterCallback fcn, nint context);

    /// <summary>
    /// Register the custom filter callback. This is optional.
    /// </summary>
    /// <param name="fcn">The custom filter callback function</param>
    /// <param name="context">The context</param>
    public void SetCustomFilterCallback(CustomFilterCallback fcn, nint context) =>
        b2World_SetCustomFilterCallback(this, fcn, context);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetPreSolveCallback")]
    private static extern void b2World_SetPreSolveCallback(World worldId, PreSolveCallback fcn, nint context);

    /// <summary>
    /// Register the pre-solve callback. This is optional.
    /// </summary>
    /// <param name="fcn">The pre-solve callback function</param>
    /// <param name="context">The context</param>
    public void SetPreSolveCallback(PreSolveCallback fcn, nint context) =>
        b2World_SetPreSolveCallback(this, fcn, context);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetGravity")]
    private static extern void b2World_SetGravity(World worldId, Vec2 gravity);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetGravity")]
    private static extern Vec2 b2World_GetGravity(World worldId);

    /// <summary>
    /// The gravity vector
    /// </summary>
    public Vec2 Gravity
    {
        get => b2World_GetGravity(this);
        set => b2World_SetGravity(this, value);
    }
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Explode")]
    private static extern void b2World_Explode(World worldId, in ExplosionDef explosionDef);
    
    /// <summary>
    /// Apply a radial explosion
    /// </summary>
    /// <param name="explosionDef">The explosion definition</param>
    /// <remarks>Explosions are modeled as a force, not as a collision event</remarks>
    public void Explode(in ExplosionDef explosionDef) => b2World_Explode(this, explosionDef);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetContactTuning")]
    private static extern void b2World_SetContactTuning(World worldId, float hertz, float dampingRatio, float pushSpeed);
    
    /// <summary>
    /// Adjust contact tuning parameters
    /// </summary>
    /// <param name="hertz">The contact stiffness (cycles per second)</param>
    /// <param name="dampingRatio">The contact bounciness with 1 being critical damping (non-dimensional)</param>
    /// <param name="pushSpeed">The maximum contact constraint push out speed (meters per second)</param>
    /// <remarks><i>Note: Advanced feature</i></remarks>
    public void SetContactTuning(float hertz, float dampingRatio, float pushSpeed) =>
        b2World_SetContactTuning(this, hertz, dampingRatio, pushSpeed);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetJointTuning")]
    private static extern void b2World_SetJointTuning(World worldId, float hertz, float dampingRatio);

    /// <summary>
    /// Adjust joint tuning parameters
    /// </summary>
    /// <param name="hertz">The contact stiffness (cycles per second)</param>
    /// <param name="dampingRatio">The contact bounciness with 1 being critical damping (non-dimensional)</param>
    /// <remarks>Advanced feature</remarks>
    public void SetJointTuning(float hertz, float dampingRatio) => b2World_SetJointTuning(this, hertz, dampingRatio);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetMaximumLinearSpeed")]
    private static extern void b2World_SetMaximumLinearSpeed(World worldId, float maximumLinearSpeed);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetMaximumLinearSpeed")]
    private static extern float b2World_GetMaximumLinearSpeed(World worldId);

    /// <summary>
    /// The maximum linear speed.
    /// </summary>
    public float MaximumLinearSpeed
    {
        get => b2World_GetMaximumLinearSpeed(this);
        set => b2World_SetMaximumLinearSpeed(this, value);
    }

    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableWarmStarting")]
    private static extern void b2World_EnableWarmStarting(World worldId, bool flag);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsWarmStartingEnabled")]
    private static extern bool b2World_IsWarmStartingEnabled(World worldId);

    /// <summary>
    /// Enable/disable constraint warm starting. Advanced feature for testing. Disabling warm starting greatly reduces stability and provides no performance gain.
    /// </summary>
    public bool WarmStartingEnabled
    {
        get => b2World_IsWarmStartingEnabled(this);
        set => b2World_EnableWarmStarting(this, value);
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetAwakeBodyCount")]
    private static extern int b2World_GetAwakeBodyCount(World worldId);

    /// <summary>
    /// Get the number of awake bodies.
    /// </summary>
    /// <returns>The number of awake bodies</returns>
    public int GetAwakeBodyCount() => b2World_GetAwakeBodyCount(this);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetProfile")]
    private static extern Profile b2World_GetProfile(World worldId);

    /// <summary>
    /// Get the current world performance profile
    /// </summary>
    /// <returns>The world performance profile</returns>
    public Profile Profile => b2World_GetProfile(this);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetCounters")]
    private static extern Counters b2World_GetCounters(World worldId);

    /// <summary>
    /// Get world counters and sizes
    /// </summary>
    /// <returns>The world counters and sizes</returns>
    public Counters Counters => b2World_GetCounters(this);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetUserData")]
    private static extern void b2World_SetUserData(World worldId, nint userData);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetUserData")]
    private static extern nint b2World_GetUserData(World worldId);

    /// <summary>
    /// The user data object for this world.
    /// </summary>
    public object? UserData
    {
        get => Core.GetObjectAtPointer(b2World_GetUserData, this);
        set => Core.SetObjectAtPointer(b2World_GetUserData, b2World_SetUserData, this, value);
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetFrictionCallback")]
    private static extern void b2World_SetFrictionCallback(World worldId, FrictionCallback callback);

    /// <summary>
    /// Sets the friction callback.
    /// </summary>
    /// <param name="callback">The friction callback</param>
    /// <remarks>Passing NULL resets to default</remarks>
    public void SetFrictionCallback(FrictionCallback callback) => b2World_SetFrictionCallback(this, callback);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetRestitutionCallback")]
    private static extern void b2World_SetRestitutionCallback(World worldId, RestitutionCallback callback);

    /// <summary>
    /// Sets the restitution callback.
    /// </summary>
    /// <param name="callback">The restitution callback</param>
    /// <remarks>Passing NULL resets to default</remarks>
    public void SetRestitutionCallback(RestitutionCallback callback) => b2World_SetRestitutionCallback(this, callback);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_DumpMemoryStats")]
    private static extern void b2World_DumpMemoryStats(World worldId);

    /// <summary>
    /// Dumps memory stats to box2d_memory.txt
    /// </summary>
    /// <remarks>Memory stats are dumped to box2d_memory.txt</remarks>
    public void DumpMemoryStats() => b2World_DumpMemoryStats(this);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateBody")]
    private static extern Body b2CreateBody(World worldId, in BodyDefInternal def);

    /// <summary>
    /// Creates a rigid body given a definition.
    /// </summary>
    /// <param name="def">The body definition</param>
    /// <returns>The body</returns>
    public Body CreateBody(BodyDef def)
    {
        Body body = b2CreateBody(this, def._internal);
        _bodies[index1].Add(body.index1, body);
        return body;
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateDistanceJoint")]
    private static extern JointId b2CreateDistanceJoint(World worldId, in DistanceJointDefInternal def);

    /// <summary>
    /// Creates a distance joint
    /// </summary>
    /// <param name="def">The distance joint definition</param>
    /// <returns>The distance joint</returns>
    public DistanceJoint CreateJoint(DistanceJointDef def) => new(b2CreateDistanceJoint(this, def._internal));

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateMotorJoint")]
    private static extern JointId b2CreateMotorJoint(World worldId, in MotorJointDefInternal def);

    /// <summary>
    /// Creates a motor joint
    /// </summary>
    /// <param name="def">The motor joint definition</param>
    /// <returns>The motor joint</returns>
    public MotorJoint CreateJoint(MotorJointDef def) => new(b2CreateMotorJoint(this, def._internal));
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateMouseJoint")]
    private static extern JointId b2CreateMouseJoint(World worldId, in MouseJointDefInternal def);

    /// <summary>
    /// Creates a mouse joint
    /// </summary>
    /// <param name="def">The mouse joint definition</param>
    /// <returns>The mouse joint</returns>
    public MouseJoint CreateJoint(MouseJointDef def) => new(b2CreateMouseJoint(this, def._internal));
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateFilterJoint")]
    private static extern JointId b2CreateFilterJoint(World worldId, in FilterJointDefInternal def);

    /// <summary>
    /// Creates a filter joint. See <see cref="FilterJointDef"/> for details.
    /// </summary>
    /// <param name="def">The filter joint definition</param>
    /// <returns>The filter joint</returns>
    /// <remarks>The filter joint is used to disable collision between two bodies. As a side effect of being a joint, it also keeps the two bodies in the same simulation island.</remarks>
    public Joint CreateJoint(FilterJointDef def) => new(b2CreateFilterJoint(this, def._internal));
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreatePrismaticJoint")]
    private static extern JointId b2CreatePrismaticJoint(World worldId, in PrismaticJointDefInternal def);

    /// <summary>
    /// Creates a prismatic (slider) joint
    /// </summary>
    /// <param name="def">The prismatic joint definition</param>
    /// <returns>The prismatic joint</returns>
    public PrismaticJoint CreateJoint(PrismaticJointDef def) => new(b2CreatePrismaticJoint(this, def._internal));
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateRevoluteJoint")]
    private static extern JointId b2CreateRevoluteJoint(World worldId, in RevoluteJointDefInternal def);

    /// <summary>
    /// Creates a revolute joint
    /// </summary>
    /// <param name="def">The <see cref="RevoluteJointDef"/></param>
    /// <returns>The revolute joint</returns>
    public RevoluteJoint CreateJoint(RevoluteJointDef def) => new(b2CreateRevoluteJoint(this, def._internal));
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWeldJoint")]
    private static extern JointId b2CreateWeldJoint(World worldId, in WeldJointDefInternal def);

    /// <summary>
    /// Creates a weld joint
    /// </summary>
    /// <param name="def">The <see cref="WeldJointDef"/></param>
    /// <returns>The weld joint</returns>
    public WeldJoint CreateJoint(WeldJointDef def) => new(b2CreateWeldJoint(this, def._internal));
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWheelJoint")]
    private static extern JointId b2CreateWheelJoint(World worldId, in WheelJointDefInternal def);

    /// <summary>
    /// Creates a wheel joint
    /// </summary>
    /// <param name="def">The wheel joint definition</param>
    /// <returns>The wheel joint</returns>
    public WheelJoint CreateJoint(WheelJointDef def) => new(b2CreateWheelJoint(this, def._internal));
    
    public override string ToString() => $"World: {index1}:{generation}";

    /// <summary>
    /// Gets the bodies in this world
    /// </summary>
    public IEnumerable<Body> Bodies => _bodies[index1].Values;
    
    
}
