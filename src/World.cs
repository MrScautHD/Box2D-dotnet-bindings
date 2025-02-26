using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWorld")]
    private static extern World b2CreateWorld(in WorldDef def);

    /// <summary>
    /// Create a world for rigid body simulation. A world contains bodies, shapes, and constraints. You make create up to 128 worlds. Each world is completely independent and may be simulated in parallel.
    /// </summary>
    /// <param name="def">The world definition</param>
    /// <returns>The world</returns>
    public static World CreateWorld(WorldDef def)
    {
        var world = b2CreateWorld(def);
        _bodies.Add(world.index1, new());
        return world;
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyWorld")]
    private static extern void b2DestroyWorld(World worldId);

    /// <summary>
    /// Destroy this world
    /// </summary>
    public void Destroy()
    {
        b2DestroyWorld(this);
        _bodies.Remove(index1);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsValid")]
    private static extern bool b2World_IsValid(World worldId);

    /// <summary>
    /// World id validation. Provides validation for up to 64K allocations.
    /// </summary>
    /// <returns>True if the world id is valid</returns>
    public bool IsValid() => b2World_IsValid(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Step")]
    private static extern void b2World_Step(World worldId, float timeStep, int subStepCount);

    /// <summary>
    /// Simulate a world for one time step. This performs collision detection, integration, and constraint solution.
    /// </summary>
    /// <param name="timeStep">The amount of time to simulate, this should be a fixed number. Usually 1/60.</param>
    /// <param name="subStepCount">The number of sub-steps, increasing the sub-step count can increase accuracy. Usually 4.</param>
    public void Step(float timeStep, int subStepCount) => b2World_Step(this, timeStep, subStepCount);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Draw")]
    private static extern void b2World_Draw(World worldId, in DebugDraw draw);

    /// <summary>
    /// Call this to draw shapes and other debug draw data
    /// </summary>
    /// <param name="draw">The debug draw implementation</param>
    public void Draw(in DebugDraw draw) => b2World_Draw(this, draw);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetBodyEvents")]
    private static extern BodyEvents b2World_GetBodyEvents(World worldId);

    /// <summary>
    /// Get the body events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    /// <returns>The body events</returns>
    public BodyEvents GetBodyEvents() => b2World_GetBodyEvents(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetSensorEvents")]
    private static extern SensorEvents b2World_GetSensorEvents(World worldId);

    /// <summary>
    /// Get sensor events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    /// <returns>The sensor events</returns>
    public SensorEvents GetSensorEvents() => b2World_GetSensorEvents(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetContactEvents")]
    private static extern ContactEvents b2World_GetContactEvents(World worldId);

    /// <summary>
    /// Get the contact events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    /// <returns>The contact events</returns>
    public ContactEvents GetContactEvents() => b2World_GetContactEvents(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapAABB")]
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

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapPoint")]
    private static extern TreeStats b2World_OverlapPoint(World worldId, Vec2 point, Transform transform, QueryFilter filter, OverlapResultCallback fcn, nint context);

    /// <summary>
    /// Overlap test for for all shapes that overlap the provided point.
    /// </summary>
    /// <param name="point">The point</param>
    /// <param name="transform">The transform</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">The context</param>
    /// <returns>The tree stats</returns>
    public TreeStats OverlapPoint(Vec2 point, Transform transform, QueryFilter filter, OverlapResultCallback fcn, nint context) =>
        b2World_OverlapPoint(this, point, transform, filter, fcn, context);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapCircle")]
    private static extern TreeStats b2World_OverlapCircle(World worldId, in Circle circle, Transform transform, QueryFilter filter, OverlapResultCallback fcn, nint context);

    /// <summary>
    /// Overlap test for for all shapes that overlap the provided circle. A zero radius may be used for a point query.
    /// </summary>
    /// <param name="circle">The circle</param>
    /// <param name="transform">The transform</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">The context</param>
    /// <returns>The tree stats</returns>
    public TreeStats OverlapCircle(in Circle circle, Transform transform, QueryFilter filter, OverlapResultCallback fcn, nint context) =>
        b2World_OverlapCircle(this, circle, transform, filter, fcn, context);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapCapsule")]
    private static extern TreeStats b2World_OverlapCapsule(World worldId, in Capsule capsule, Transform transform, QueryFilter filter, OverlapResultCallback fcn, nint context);

    /// <summary>
    /// Overlap test for all shapes that overlap the provided capsule
    /// </summary>
    /// <param name="capsule">The capsule</param>
    /// <param name="transform">The transform</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">The context</param>
    /// <returns>The tree stats</returns>
    public TreeStats OverlapCapsule(in Capsule capsule, Transform transform, QueryFilter filter, OverlapResultCallback fcn, nint context) =>
        b2World_OverlapCapsule(this, capsule, transform, filter, fcn, context);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapPolygon")]
    private static extern TreeStats b2World_OverlapPolygon(World worldId, in Polygon polygon, Transform transform, QueryFilter filter, OverlapResultCallback fcn, nint context);

    /// <summary>
    /// Overlap test for all shapes that overlap the provided polygon
    /// </summary>
    /// <param name="polygon">The polygon</param>
    /// <param name="transform">The transform</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">The context</param>
    /// <returns>The tree stats</returns>
    public TreeStats OverlapPolygon(in Polygon polygon, Transform transform, QueryFilter filter, OverlapResultCallback fcn, nint context) =>
        b2World_OverlapPolygon(this, polygon, transform, filter, fcn, context);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastRay")]
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

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastRayClosest")]
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

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastCircle")]
    private static extern TreeStats b2World_CastCircle(World worldId, in Circle circle, Transform originTransform, Vec2 translation, QueryFilter filter, CastResultCallback fcn, nint context);

    /// <summary>
    /// Cast a circle through the world. Similar to a cast ray except that a circle is cast instead of a point.
    /// </summary>
    /// <param name="circle">The circle</param>
    /// <param name="originTransform">The origin transform</param>
    /// <param name="translation">The translation</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">The context</param>
    /// <returns>The tree stats</returns>
    public TreeStats CastCircle(in Circle circle, Transform originTransform, Vec2 translation, QueryFilter filter, CastResultCallback fcn, nint context) =>
        b2World_CastCircle(this, circle, originTransform, translation, filter, fcn, context);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastCapsule")]
    private static extern TreeStats b2World_CastCapsule(World worldId, in Capsule capsule, Transform originTransform, Vec2 translation, QueryFilter filter, CastResultCallback fcn, nint context);

    /// <summary>
    /// Cast a capsule through the world. Similar to a cast ray except that a capsule is cast instead of a point.
    /// </summary>
    /// <param name="capsule">The capsule</param>
    /// <param name="originTransform">The origin transform</param>
    /// <param name="translation">The translation</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">The context</param>
    /// <returns>The tree stats</returns>
    public TreeStats CastCapsule(in Capsule capsule, Transform originTransform, Vec2 translation, QueryFilter filter, CastResultCallback fcn, nint context) =>
        b2World_CastCapsule(this, capsule, originTransform, translation, filter, fcn, context);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastPolygon")]
    private static extern TreeStats b2World_CastPolygon(World worldId, in Polygon polygon, Transform originTransform, Vec2 translation, QueryFilter filter, CastResultCallback fcn, nint context);

    /// <summary>
    /// Cast a polygon through the world. Similar to a cast ray except that a polygon is cast instead of a point.
    /// </summary>
    /// <param name="polygon">The polygon</param>
    /// <param name="originTransform">The origin transform</param>
    /// <param name="translation">The translation</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">The context</param>
    /// <returns>The tree stats</returns>
    public TreeStats CastPolygon(in Polygon polygon, Transform originTransform, Vec2 translation, QueryFilter filter, CastResultCallback fcn, nint context) =>
        b2World_CastPolygon(this, polygon, originTransform, translation, filter, fcn, context);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableSleeping")]
    private static extern void b2World_EnableSleeping(World worldId, bool flag);

    /// <summary>
    /// Enable/disable sleep. If your application does not need sleeping, you can gain some performance by disabling sleep completely at the world level.
    /// </summary>
    /// <param name="flag">True to enable sleep, false to disable sleep</param>
    public void EnableSleeping(bool flag) => b2World_EnableSleeping(this, flag);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsSleepingEnabled")]
    private static extern bool b2World_IsSleepingEnabled(World worldId);

    /// <summary>
    /// Is body sleeping enabled?
    /// </summary>
    /// <returns>True if body sleeping is enabled</returns>
    public bool IsSleepingEnabled() => b2World_IsSleepingEnabled(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableContinuous")]
    private static extern void b2World_EnableContinuous(World worldId, bool flag);

    /// <summary>
    /// Enable/disable continuous collision between dynamic and static bodies.
    /// </summary>
    /// <param name="flag">True to enable continuous collision, false to disable continuous collision</param>
    /// <remarks>Generally you should keep continuous collision enabled to prevent fast moving objects from going through static objects. The performance gain from disabling continuous collision is minor</remarks>
    public void EnableContinuous(bool flag) => b2World_EnableContinuous(this, flag);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsContinuousEnabled")]
    private static extern bool b2World_IsContinuousEnabled(World worldId);

    /// <summary>
    /// Is continuous collision enabled?
    /// </summary>
    /// <returns>True if continuous collision is enabled</returns>
    public bool IsContinuousEnabled() => b2World_IsContinuousEnabled(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetRestitutionThreshold")]
    private static extern void b2World_SetRestitutionThreshold(World worldId, float value);

    /// <summary>
    /// Adjust the restitution threshold.
    /// </summary>
    /// <param name="value">The restitution threshold, usually in meters per second</param>
    /// <remarks>It is recommended not to make this value very small because it will prevent bodies from sleeping</remarks>
    public void SetRestitutionThreshold(float value) => b2World_SetRestitutionThreshold(this, value);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetRestitutionThreshold")]
    private static extern float b2World_GetRestitutionThreshold(World worldId);

    /// <summary>
    /// Get the restitution speed threshold.
    /// </summary>
    /// <returns>The restitution speed threshold, usually in meters per second</returns>
    public float GetRestitutionThreshold() => b2World_GetRestitutionThreshold(this);

    public float RestitutionThreshold
    {
        get => GetRestitutionThreshold();
        set => SetRestitutionThreshold(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetHitEventThreshold")]
    private static extern void b2World_SetHitEventThreshold(World worldId, float value);

    /// <summary>
    /// Adjust the hit event threshold.
    /// </summary>
    /// <param name="value">The hit event threshold, usually in meters per second</param>
    /// <remarks>This controls the collision speed needed to generate a ContactHitEvent</remarks>
    public void SetHitEventThreshold(float value) => b2World_SetHitEventThreshold(this, value);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetHitEventThreshold")]
    private static extern float b2World_GetHitEventThreshold(World worldId);

    /// <summary>
    /// Get the hit event threshold.
    /// </summary>
    /// <returns>The hit event threshold, usually in meters per second</returns>
    public float GetHitEventThreshold() => b2World_GetHitEventThreshold(this);

    public float HitEventThreshold
    {
        get => GetHitEventThreshold();
        set => SetHitEventThreshold(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetCustomFilterCallback")]
    private static extern void b2World_SetCustomFilterCallback(World worldId, CustomFilterCallback fcn, nint context);

    /// <summary>
    /// Register the custom filter callback. This is optional.
    /// </summary>
    /// <param name="fcn">The custom filter callback function</param>
    /// <param name="context">The context</param>
    public void SetCustomFilterCallback(CustomFilterCallback fcn, nint context) =>
        b2World_SetCustomFilterCallback(this, fcn, context);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetPreSolveCallback")]
    private static extern void b2World_SetPreSolveCallback(World worldId, PreSolveCallback fcn, nint context);

    /// <summary>
    /// Register the pre-solve callback. This is optional.
    /// </summary>
    /// <param name="fcn">The pre-solve callback function</param>
    /// <param name="context">The context</param>
    public void SetPreSolveCallback(PreSolveCallback fcn, nint context) =>
        b2World_SetPreSolveCallback(this, fcn, context);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetGravity")]
    private static extern void b2World_SetGravity(World worldId, Vec2 gravity);

    /// <summary>
    /// Set the gravity vector for the entire world. Box2D has no concept of an up direction and this is left as a decision for the application.
    /// </summary>
    /// <param name="gravity">The gravity vector, usually in m/s²</param>
    public void SetGravity(Vec2 gravity) => b2World_SetGravity(this, gravity);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetGravity")]
    private static extern Vec2 b2World_GetGravity(World worldId);

    /// <summary>
    /// Get the gravity vector
    /// </summary>
    /// <returns>The gravity vector</returns>
    public Vec2 GetGravity() => b2World_GetGravity(this);

    public Vec2 Gravity
    {
        get => GetGravity();
        set => SetGravity(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Explode")]
    private static extern void b2World_Explode(World worldId, ref ExplosionDef explosionDef);

    /// <summary>
    /// Apply a radial explosion
    /// </summary>
    /// <param name="explosionDef">The explosion definition</param>
    /// <remarks>Explosions are modeled as a force, not as a collision event</remarks>
    public void Explode(ref ExplosionDef explosionDef) => b2World_Explode(this, ref explosionDef);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetContactTuning")]
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

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetJointTuning")]
    private static extern void b2World_SetJointTuning(World worldId, float hertz, float dampingRatio);

    /// <summary>
    /// Adjust joint tuning parameters
    /// </summary>
    /// <param name="hertz">The contact stiffness (cycles per second)</param>
    /// <param name="dampingRatio">The contact bounciness with 1 being critical damping (non-dimensional)</param>
    /// <remarks>Advanced feature</remarks>
    public void SetJointTuning(float hertz, float dampingRatio) => b2World_SetJointTuning(this, hertz, dampingRatio);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetMaximumLinearSpeed")]
    private static extern void b2World_SetMaximumLinearSpeed(World worldId, float maximumLinearSpeed);

    /// <summary>
    /// Set the maximum linear speed.
    /// </summary>
    /// <param name="maximumLinearSpeed">The maximum linear speed, usually in m/s</param>
    public void SetMaximumLinearSpeed(float maximumLinearSpeed) => b2World_SetMaximumLinearSpeed(this, maximumLinearSpeed);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetMaximumLinearSpeed")]
    private static extern float b2World_GetMaximumLinearSpeed(World worldId);

    /// <summary>
    /// Get the maximum linear speed.
    /// </summary>
    /// <returns>The maximum linear speed, usually in m/s</returns>
    public float GetMaximumLinearSpeed() => b2World_GetMaximumLinearSpeed(this);

    public float MaximumLinearSpeed
    {
        get => GetMaximumLinearSpeed();
        set => SetMaximumLinearSpeed(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableWarmStarting")]
    private static extern void b2World_EnableWarmStarting(World worldId, bool flag);

    /// <summary>
    /// Enable/disable constraint warm starting.
    /// </summary>
    /// <param name="flag">True to enable warm starting, false to disable warm starting</param>
    /// <remarks>Advanced feature for testing. Disabling sleeping greatly reduces stability and provides no performance gain</remarks>
    public void EnableWarmStarting(bool flag) => b2World_EnableWarmStarting(this, flag);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsWarmStartingEnabled")]
    private static extern bool b2World_IsWarmStartingEnabled(World worldId);

    /// <summary>
    /// Is constraint warm starting enabled?
    /// </summary>
    /// <returns>True if constraint warm starting is enabled</returns>
    /// <remarks>Advanced feature for testing. Disabling sleeping greatly reduces stability and provides no performance gain</remarks>
    public bool IsWarmStartingEnabled() => b2World_IsWarmStartingEnabled(this);

    public bool WarmStartingEnabled
    {
        get => IsWarmStartingEnabled();
        set => EnableWarmStarting(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetAwakeBodyCount")]
    private static extern int b2World_GetAwakeBodyCount(World worldId);

    /// <summary>
    /// Get the number of awake bodies.
    /// </summary>
    /// <returns>The number of awake bodies</returns>
    public int GetAwakeBodyCount() => b2World_GetAwakeBodyCount(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetProfile")]
    private static extern Profile b2World_GetProfile(World worldId);

    /// <summary>
    /// Get the current world performance profile
    /// </summary>
    /// <returns>The world performance profile</returns>
    public Profile GetProfile() => b2World_GetProfile(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetCounters")]
    private static extern Counters b2World_GetCounters(World worldId);

    /// <summary>
    /// Get world counters and sizes
    /// </summary>
    /// <returns>The world counters and sizes</returns>
    public Counters GetCounters() => b2World_GetCounters(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetUserData")]
    private static extern void b2World_SetUserData(World worldId, nint userData);

    /// <summary>
    /// Set the user data object.
    /// </summary>
    /// <param name="userData">The user data object</param>
    public void SetUserData<T>(T userData)
    {
        GCHandle handle = GCHandle.Alloc(userData);
        nint userDataPtr = GCHandle.ToIntPtr(handle);
        b2World_SetUserData(this, userDataPtr);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetUserData")]
    private static extern nint b2World_GetUserData(World worldId);

    /// <summary>
    /// Gets the user data object.
    /// </summary>
    /// <returns>The user data object</returns>
    public T? GetUserData<T>()
    {
        nint userDataPtr = b2World_GetUserData(this);
        if (userDataPtr == 0) return default;
        GCHandle handle = GCHandle.FromIntPtr(userDataPtr);
        if (!handle.IsAllocated) return default;
        T? userData = (T?)handle.Target;
        return userData;
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetFrictionCallback")]
    private static extern void b2World_SetFrictionCallback(World worldId, FrictionCallback callback);

    /// <summary>
    /// Sets the friction callback.
    /// </summary>
    /// <param name="callback">The friction callback</param>
    /// <remarks>Passing NULL resets to default</remarks>
    public void SetFrictionCallback(FrictionCallback callback) => b2World_SetFrictionCallback(this, callback);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetRestitutionCallback")]
    private static extern void b2World_SetRestitutionCallback(World worldId, RestitutionCallback callback);

    /// <summary>
    /// Sets the restitution callback.
    /// </summary>
    /// <param name="callback">The restitution callback</param>
    /// <remarks>Passing NULL resets to default</remarks>
    public void SetRestitutionCallback(RestitutionCallback callback) => b2World_SetRestitutionCallback(this, callback);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_DumpMemoryStats")]
    private static extern void b2World_DumpMemoryStats(World worldId);

    /// <summary>
    /// Dumps memory stats to box2d_memory.txt
    /// </summary>
    /// <remarks>Memory stats are dumped to box2d_memory.txt</remarks>
    public void DumpMemoryStats() => b2World_DumpMemoryStats(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateBody")]
    private static extern Body b2CreateBody(World worldId, in BodyDef def);

    /// <summary>
    /// Creates a rigid body given a definition.
    /// </summary>
    /// <param name="def">The body definition</param>
    /// <returns>The body</returns>
    public Body CreateBody(BodyDef def)
    {
        Body body = b2CreateBody(this, def);
        _bodies[index1].Add(body.index1, body);
        return body;
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateDistanceJoint")]
    private static extern JointId b2CreateDistanceJoint(World worldId, in DistanceJointDef def);

    /// <summary>
    /// Creates a distance joint
    /// </summary>
    /// <param name="def">The distance joint definition</param>
    /// <returns>The distance joint</returns>
    [Obsolete("Use CreateJoint(DistanceJointDef def) instead")]
    public DistanceJoint CreateDistanceJoint(DistanceJointDef def) => new(b2CreateDistanceJoint(this, def));

    /// <summary>
    /// Creates a distance joint
    /// </summary>
    /// <param name="def">The distance joint definition</param>
    /// <returns>The distance joint</returns>
    public DistanceJoint CreateJoint(DistanceJointDef def) => new(b2CreateDistanceJoint(this, def));
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateMotorJoint")]
    private static extern JointId b2CreateMotorJoint(World worldId, in MotorJointDef def);

    /// <summary>
    /// Creates a motor joint
    /// </summary>
    /// <param name="def">The motor joint definition</param>
    /// <returns>The motor joint</returns>
    [Obsolete("Use CreateJoint(MotorJointDef def) instead")]
    public MotorJoint CreateMotorJoint(MotorJointDef def) => new(b2CreateMotorJoint(this, def));

    /// <summary>
    /// Creates a motor joint
    /// </summary>
    /// <param name="def">The motor joint definition</param>
    /// <returns>The motor joint</returns>
    public MotorJoint CreateJoint(MotorJointDef def) => new(b2CreateMotorJoint(this, def));
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateMouseJoint")]
    private static extern JointId b2CreateMouseJoint(World worldId, in MouseJointDef def);

    /// <summary>
    /// Creates a mouse joint
    /// </summary>
    /// <param name="def">The mouse joint definition</param>
    /// <returns>The mouse joint</returns>
    [Obsolete("Use CreateJoint(MouseJointDef def) instead")]
    public MouseJoint CreateMouseJoint(MouseJointDef def) => new(b2CreateMouseJoint(this, def));

    /// <summary>
    /// Creates a mouse joint
    /// </summary>
    /// <param name="def">The mouse joint definition</param>
    /// <returns>The mouse joint</returns>
    public MouseJoint CreateJoint(MouseJointDef def) => new(b2CreateMouseJoint(this, def));
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateNullJoint")]
    private static extern JointId b2CreateNullJoint(World worldId, in NullJointDef def);

    /// <summary>
    /// Creates a null joint
    /// </summary>
    /// <param name="def">The null joint definition</param>
    /// <returns>The null joint</returns>
    [Obsolete("Use CreateJoint(NullJointDef def) instead")]
    public Joint CreateNullJoint(NullJointDef def) => new(b2CreateNullJoint(this, def));

    /// <summary>
    /// Creates a null joint
    /// </summary>
    /// <param name="def">The null joint definition</param>
    /// <returns>The null joint</returns>
    public Joint CreateJoint(NullJointDef def) => new(b2CreateNullJoint(this, def));
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreatePrismaticJoint")]
    private static extern JointId b2CreatePrismaticJoint(World worldId, in PrismaticJointDef def);

    /// <summary>
    /// Creates a prismatic (slider) joint
    /// </summary>
    /// <param name="def">The prismatic joint definition</param>
    /// <returns>The prismatic joint</returns>
    [Obsolete("Use CreateJoint(PrismaticJointDef def) instead")]
    public PrismaticJoint CreatePrismaticJoint(PrismaticJointDef def) => new(b2CreatePrismaticJoint(this, def));

    /// <summary>
    /// Creates a prismatic (slider) joint
    /// </summary>
    /// <param name="def">The prismatic joint definition</param>
    /// <returns>The prismatic joint</returns>
    public PrismaticJoint CreateJoint(PrismaticJointDef def) => new(b2CreatePrismaticJoint(this, def));
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateRevoluteJoint")]
    private static extern JointId b2CreateRevoluteJoint(World worldId, in RevoluteJointDef def);

    /// <summary>
    /// Creates a revolute joint
    /// </summary>
    /// <param name="def">The revolute joint definition</param>
    /// <returns>The revolute joint</returns>
    [Obsolete("Use CreateJoint(RevoluteJointDef def) instead")]
    public RevoluteJoint CreateRevoluteJoint(RevoluteJointDef def) => new(b2CreateRevoluteJoint(this, def));

    /// <summary>
    /// Creates a revolute joint
    /// </summary>
    /// <param name="def">The revolute joint definition</param>
    /// <returns>The revolute joint</returns>
    public RevoluteJoint CreateJoint(RevoluteJointDef def) => new(b2CreateRevoluteJoint(this, def));
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWeldJoint")]
    private static extern JointId b2CreateWeldJoint(World worldId, in WeldJointDef def);

    /// <summary>
    /// Creates a weld joint
    /// </summary>
    /// <param name="def">The weld joint definition</param>
    /// <returns>The weld joint</returns>
    [Obsolete("Use CreateJoint(WeldJointDef def) instead")]
    public WeldJoint CreateWeldJoint(WeldJointDef def) => new(b2CreateWeldJoint(this, def));

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWheelJoint")]
    private static extern JointId b2CreateWheelJoint(World worldId, in WheelJointDef def);

    /// <summary>
    /// Creates a wheel joint
    /// </summary>
    /// <param name="def">The wheel joint definition</param>
    /// <returns>The wheel joint</returns>
    [Obsolete("Use CreateJoint(WheelJointDef def) instead")]
    public WheelJoint CreateWheelJoint(WheelJointDef def) => new(b2CreateWheelJoint(this, def));

    /// <summary>
    /// Creates a wheel joint
    /// </summary>
    /// <param name="def">The wheel joint definition</param>
    /// <returns>The wheel joint</returns>
    public WheelJoint CreateJoint(WheelJointDef def) => new(b2CreateWheelJoint(this, def));
    
    public override string ToString() => $"World: {index1}:{generation}";

    /// <summary>
    /// Gets the bodies in this world
    /// </summary>
    public IEnumerable<Body> Bodies => _bodies[index1].Values;
}
