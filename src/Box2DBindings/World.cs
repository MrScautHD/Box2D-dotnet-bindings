using Box2D.Character_Movement;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
struct WorldId
{
    [FieldOffset(0)]
    internal ushort index1;
    [FieldOffset(2)]
    internal ushort generation;
}

public sealed class World
{
    private WorldId id;

    internal readonly Dictionary<int, Body> bodies = new();

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWorld")]
    private static extern WorldId b2CreateWorld(in WorldDefInternal def);

    /// <summary>
    /// Create a world for rigid body simulation. A world contains bodies, shapes, and constraints. You make create up to 128 worlds. Each world is completely independent and may be simulated in parallel.
    /// </summary>
    /// <param name="def">The world definition</param>
    /// <returns>The world</returns>
    public static World CreateWorld(WorldDef def)
    {
        var world = b2CreateWorld(def._internal);
        return GetWorld(world);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyWorld")]
    private static extern void b2DestroyWorld(WorldId worldId);

    /// <summary>
    /// Destroy this world
    /// </summary>
    public void Destroy()
    {
        foreach (var body in bodies.Values)
            body.Destroy();

        // dealloc user data
        nint userDataPtr = b2World_GetUserData(id);
        if (userDataPtr != 0)
            FreeHandle(ref userDataPtr);
        b2World_SetUserData(id, 0);
        
        b2DestroyWorld(id);
        bodies.Remove(id.index1);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsValid")]
    private static extern bool b2World_IsValid(WorldId worldId);

    /// <summary>
    /// World id validation. Provides validation for up to 64K allocations.
    /// </summary>
    /// <returns>True if the world id is valid</returns>
    public bool Valid => b2World_IsValid(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Step")]
    private static extern void b2World_Step(WorldId worldId, float timeStep, int subStepCount);

    /// <summary>
    /// Simulate a world for one time step. This performs collision detection, integration, and constraint solution.
    /// </summary>
    /// <param name="timeStep">The amount of time to simulate, this should be a fixed number. Usually 1/60.</param>
    /// <param name="subStepCount">The number of sub-steps, increasing the sub-step count can increase accuracy. Usually 4.</param>
    public void Step(float timeStep, int subStepCount) => b2World_Step(id, timeStep, subStepCount);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Draw")]
    private static extern void b2World_Draw(WorldId worldId, ref DebugDrawInternal draw);

    /// <summary>
    /// Call this to draw shapes and other debug draw data
    /// </summary>
    /// <param name="draw">The debug draw implementation</param>
    public void Draw(in DebugDraw draw) => b2World_Draw(id, ref draw._internal);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetBodyEvents")]
    private static extern BodyEvents b2World_GetBodyEvents(WorldId worldId);

    /// <summary>
    /// Get the body events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    /// <returns>The body events</returns>
    public BodyEvents BodyEvents => b2World_GetBodyEvents(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetSensorEvents")]
    private static extern SensorEvents b2World_GetSensorEvents(WorldId worldId);

    /// <summary>
    /// Get sensor events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    /// <returns>The sensor events</returns>
    public SensorEvents SensorEvents => b2World_GetSensorEvents(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetContactEvents")]
    private static extern ContactEvents b2World_GetContactEvents(WorldId worldId);

    /// <summary>
    /// Get the contact events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    /// <returns>The contact events</returns>
    public ContactEvents ContactEvents => b2World_GetContactEvents(id);


    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastRayClosest")]
    private static extern RayResult b2World_CastRayClosest(WorldId worldId, Vec2 origin, Vec2 translation, QueryFilter filter);

    /// <summary>
    /// Cast a ray into the world to collect the closest hit. This is a convenience function.
    /// </summary>
    /// <param name="origin">The start point of the ray</param>
    /// <param name="translation">The translation of the ray from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <returns>The ray result</returns>
    /// <remarks>This is less general than b2World_CastRay() and does not allow for custom filtering</remarks>
    public RayResult CastRayClosest(Vec2 origin, Vec2 translation, QueryFilter filter) =>
        b2World_CastRayClosest(id, origin, translation, filter);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastMover")]
    private static extern float b2World_CastMover(WorldId worldId, in Capsule mover, Vec2 translation, QueryFilter filter);

    /// <summary>
    /// Cast a capsule mover through the world. This is a special shape cast that handles sliding along other shapes while reducing clipping.
    /// </summary>
    /// <param name="mover">The capsule mover</param>
    /// <param name="translation">The translation of the capsule from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <returns>The fraction of the translation that was completed before a collision occurred</returns>
    public float CastMover(in Capsule mover, Vec2 translation, QueryFilter filter) =>
        b2World_CastMover(id, in mover, translation, filter);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastShape")]
    private static extern TreeStats b2World_CastShape(WorldId worldId, in ShapeProxy proxy, Vec2 translation, QueryFilter filter, CastResultNintCallback fcn, nint context);
    
    /// <summary>
    /// Cast a shape through the world. Similar to a cast ray except that a shape is cast instead of a point.
    /// </summary>
    /// <param name="proxy">The shape proxy</param>
    /// <param name="translation">The translation of the shape from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    /// <param name="context">A user context that is passed along to the callback function</param>
    public TreeStats CastShape<TContext>(in ShapeProxy proxy, Vec2 translation, QueryFilter filter, CastResultCallback<TContext> callback, TContext context) where TContext : class
    {
        float CastResultCallbackPrivate(Shape shape, Vec2 point, Vec2 normal, float fraction, nint _) => callback(shape, point, normal, fraction, context);
        return b2World_CastShape(id, in proxy, translation, filter, CastResultCallbackPrivate, 0);
    }

    /// <summary>
    /// Cast a shape through the world. Similar to a cast ray except that a shape is cast instead of a point.
    /// </summary>
    /// <param name="proxy">The shape proxy</param>
    /// <param name="translation">The translation of the shape from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    public TreeStats CastShape(in ShapeProxy proxy, Vec2 translation, QueryFilter filter, CastResultCallback callback)
    {
        float CastResultCallbackPrivate(Shape shape, Vec2 point, Vec2 normal, float fraction, nint _) => callback(shape, point, normal, fraction);
        return b2World_CastShape(id, in proxy, translation, filter, CastResultCallbackPrivate, 0);
    }
    
    /// <summary>
    /// Cast a shape through the world. Similar to a cast ray except that a shape is cast instead of a point.
    /// </summary>
    /// <param name="proxy">The shape proxy</param>
    /// <param name="translation">The translation of the shape from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    /// <param name="context">A user context that is passed along to the callback function</param>
    public TreeStats CastShape(in ShapeProxy proxy, Vec2 translation, QueryFilter filter, CastResultNintCallback callback, nint context)
    {
        return b2World_CastShape(id, in proxy, translation, filter, callback, context);
    }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastRay")]
    private static extern TreeStats b2World_CastRay(WorldId worldId, Vec2 origin, Vec2 translation, QueryFilter filter, CastResultNintCallback fcn, nint context);

    /// <summary>
    /// Cast a ray into the world to collect shapes in the path of the ray.
    /// </summary>
    /// <param name="origin">The start point of the ray</param>
    /// <param name="translation">The translation of the ray from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    /// <param name="context">A user context that is passed along to the callback function</param>
    /// <returns>Traversal performance counters</returns>
    /// <remarks>Your callback function controls whether you get the closest point, any point, or n-points. The ray-cast ignores shapes that contain the starting point. The callback function may receive shapes in any order</remarks>
    public TreeStats CastRay<TContext>(Vec2 origin, Vec2 translation, QueryFilter filter, CastResultCallback<TContext> callback, TContext context) where TContext : class
    {
        float CastResultCallbackPrivate(Shape shape, Vec2 point, Vec2 normal, float fraction, nint _) => callback(shape, point, normal, fraction, context);
        return b2World_CastRay(id, origin, translation, filter, CastResultCallbackPrivate, 0);
    }

    /// <summary>
    /// Cast a ray into the world to collect shapes in the path of the ray.
    /// </summary>
    /// <param name="origin">The start point of the ray</param>
    /// <param name="translation">The translation of the ray from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    /// <returns>Traversal performance counters</returns>
    /// <remarks>Your callback function controls whether you get the closest point, any point, or n-points. The ray-cast ignores shapes that contain the starting point. The callback function may receive shapes in any order</remarks>
    public TreeStats CastRay(Vec2 origin, Vec2 translation, QueryFilter filter, CastResultCallback callback)
    {
        float CastResultCallbackPrivate(Shape shape, Vec2 point, Vec2 normal, float fraction, nint _) => callback(shape, point, normal, fraction);
        return b2World_CastRay(id, origin, translation, filter, CastResultCallbackPrivate, 0);
    }

    /// <summary>
    /// Cast a ray into the world to collect shapes in the path of the ray.
    /// </summary>
    /// <param name="origin">The start point of the ray</param>
    /// <param name="translation">The translation of the ray from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    /// /// <param name="context">A user context that is passed along to the callback function</param>
    /// <returns>Traversal performance counters</returns>
    /// <remarks>Your callback function controls whether you get the closest point, any point, or n-points. The ray-cast ignores shapes that contain the starting point. The callback function may receive shapes in any order</remarks>
    public TreeStats CastRay(Vec2 origin, Vec2 translation, QueryFilter filter, CastResultNintCallback callback, nint context)
    {
        return b2World_CastRay(id, origin, translation, filter, callback, context);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CollideMover")]
    private static extern void b2World_CollideMover(WorldId worldId, in Capsule mover, QueryFilter filter, PlaneResultNintCallback fcn, nint context);

    /// <summary>
    /// Collide a capsule mover with the world, gathering collision planes that can be fed to b2SolvePlanes. Useful for kinematic character movement.
    /// </summary>
    /// <param name="mover">The capsule mover</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    /// <param name="context">A user context that is passed along to the callback function</param>
    public void CollideMover<TContext>(in Capsule mover, QueryFilter filter, PlaneResultCallback<TContext> callback, TContext context)
    {
        bool PlaneResultCallbackPrivate(Shape shapeId, in PlaneResult plane, nint _) => callback(shapeId, plane, context);
        b2World_CollideMover(id, in mover, filter, PlaneResultCallbackPrivate, 0);
    }

    /// <summary>
    /// Collide a capsule mover with the world, gathering collision planes that can be fed to b2SolvePlanes. Useful for kinematic character movement.
    /// </summary>
    /// <param name="mover">The capsule mover</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    public void CollideMover(in Capsule mover, QueryFilter filter, PlaneResultCallback callback)
    {
        bool PlaneResultCallbackPrivate(Shape shapeId, in PlaneResult plane, nint _) => callback(shapeId, plane);
        b2World_CollideMover(id, in mover, filter, PlaneResultCallbackPrivate, 0);
    }

    /// <summary>
    /// Collide a capsule mover with the world, gathering collision planes that can be fed to b2SolvePlanes. Useful for kinematic character movement.
    /// </summary>
    /// <param name="mover">The capsule mover</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    /// <param name="context">A user context that is passed along to the callback function</param>
    public void CollideMover(in Capsule mover, QueryFilter filter, PlaneResultNintCallback callback, nint context)
    {
        b2World_CollideMover(id, in mover, filter, callback, context);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableSleeping")]
    private static extern void b2World_EnableSleeping(WorldId worldId, bool flag);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsSleepingEnabled")]
    private static extern bool b2World_IsSleepingEnabled(WorldId worldId);

    /// <summary>
    /// Gets or sets the sleeping enabled status of the world. If your application does not need sleeping, you can gain some performance by disabling sleep completely at the world level.
    /// </summary>
    public bool SleepingEnabled
    {
        get => b2World_IsSleepingEnabled(id);
        set => b2World_EnableSleeping(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableContinuous")]
    private static extern void b2World_EnableContinuous(WorldId worldId, bool flag);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsContinuousEnabled")]
    private static extern bool b2World_IsContinuousEnabled(WorldId worldId);

    /// <summary>
    /// Gets or sets the continuous collision enabled state of the world.
    /// </summary>
    /// <remarks>Generally you should keep continuous collision enabled to prevent fast moving objects from going through static objects. The performance gain from disabling continuous collision is minor</remarks>
    public bool ContinuousEnabled
    {
        get => b2World_IsContinuousEnabled(id);
        set => b2World_EnableContinuous(id, value);
    }


    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetRestitutionThreshold")]
    private static extern void b2World_SetRestitutionThreshold(WorldId worldId, float value);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetRestitutionThreshold")]
    private static extern float b2World_GetRestitutionThreshold(WorldId worldId);

    /// <summary>
    /// The restitution speed threshold.
    /// </summary>
    public float RestitutionThreshold
    {
        get => b2World_GetRestitutionThreshold(id);
        set => b2World_SetRestitutionThreshold(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetHitEventThreshold")]
    private static extern void b2World_SetHitEventThreshold(WorldId worldId, float value);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetHitEventThreshold")]
    private static extern float b2World_GetHitEventThreshold(WorldId worldId);

    /// <summary>
    /// The hit event threshold in meters per second.
    /// </summary>
    public float HitEventThreshold
    {
        get => b2World_GetHitEventThreshold(id);
        set => b2World_SetHitEventThreshold(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetCustomFilterCallback")]
    private static extern void b2World_SetCustomFilterCallback(WorldId worldId, CustomFilterNintCallback fcn, nint context);

    private static Dictionary<int, World> worlds = new();

    internal static World GetWorld(WorldId world)
    {
        if (!worlds.TryGetValue(world.index1, out var w))
            worlds.Add(world.index1, w = new World { id = world });
        return w;
    }

    /// <summary>
    /// Register the custom filter callback. This is optional.
    /// </summary>
    /// <param name="callback">The custom filter callback function</param>
    /// <param name="context">The context</param>
    [PublicAPI]
    public void SetCustomFilterCallback<TContext>(CustomFilterCallback<TContext> callback, TContext context)
    {
        bool Callback(Shape shapeA, Shape shapeB, nint _) => callback(shapeA, shapeB, context);
        b2World_SetCustomFilterCallback(id, Callback, 0);
    }

    /// <summary>
    /// Register the custom filter callback. This is optional.
    /// </summary>
    /// <param name="callback">The custom filter callback function</param>
    public void SetCustomFilterCallback(CustomFilterNintCallback callback, nint context)
    {
        b2World_SetCustomFilterCallback(id, callback, context);
    }

    /// <summary>
    /// Register the custom filter callback. This is optional.
    /// </summary>
    /// <param name="nintCallback">The custom filter callback function</param>
    public void SetCustomFilterCallback(CustomFilterCallback nintCallback)
    {
        bool Callback(Shape shapeA, Shape shapeB, nint _) => nintCallback(shapeA, shapeB);
        b2World_SetCustomFilterCallback(id, Callback, 0);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapAABB")]
    private static extern TreeStats b2World_OverlapAABB(WorldId worldId, AABB aabb, QueryFilter filter, OverlapResultNintCallback fcn, nint context);

    /// <summary>
    /// Overlap test for all shapes that *potentially* overlap the provided AABB
    /// </summary>
    /// <param name="aabb">The AABB</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    /// <param name="context">The context</param>
    public TreeStats OverlapAABB<TContext>(AABB aabb, QueryFilter filter, OverlapResultCallback<TContext> callback, TContext context) where TContext : new()
    {
        bool OverlapResultCallbackPrivate(Shape shapeId, nint _) => callback(shapeId, context);
        return b2World_OverlapAABB(id, aabb, filter, OverlapResultCallbackPrivate, 0);
    }

    /// <summary>
    /// Overlap test for all shapes that *potentially* overlap the provided AABB
    /// </summary>
    /// <param name="aabb">The AABB</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    public TreeStats OverlapAABB(AABB aabb, QueryFilter filter, OverlapResultCallback callback)
    {
        bool OverlapResultCallbackPrivate(Shape shapeId, nint _) => callback(shapeId);
        return b2World_OverlapAABB(id, aabb, filter, OverlapResultCallbackPrivate, 0);
    }

        /// <summary>
    /// Overlap test for all shapes that *potentially* overlap the provided AABB
    /// </summary>
    /// <param name="aabb">The AABB</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    public TreeStats OverlapAABB(AABB aabb, QueryFilter filter, OverlapResultNintCallback callback, nint context)
    {
        return b2World_OverlapAABB(id, aabb, filter, callback, context);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapShape")]
    private static extern TreeStats b2World_OverlapShape(WorldId worldId, in ShapeProxy proxy, QueryFilter filter, OverlapResultNintCallback fcn, nint context);

    /// <summary>
    /// Overlap test for all shapes that overlap the provided shape proxy
    /// </summary>
    /// <param name="proxy">The shape proxy</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    /// <param name="context">The context</param>
    public TreeStats OverlapShape<TContext>(in ShapeProxy proxy, QueryFilter filter, OverlapResultCallback<TContext> callback, TContext context) where TContext : new()
    {
        bool OverlapResultCallbackPrivate(Shape shapeId, nint _) => callback(shapeId, context);
        return b2World_OverlapShape(id, in proxy, filter, OverlapResultCallbackPrivate, 0);
    }

    /// <summary>
    /// Overlap test for all shapes that overlap the provided shape proxy
    /// </summary>
    /// <param name="proxy">The shape proxy</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    /// <param name="context">The context</param>
    public TreeStats OverlapShape<TContext>(in ShapeProxy proxy, QueryFilter filter, OverlapResultNintCallback callback, nint context)
    {
        return b2World_OverlapShape(id, in proxy, filter, callback, context);
    }

    /// <summary>
    /// Overlap test for all shapes that overlap the provided shape proxy
    /// </summary>
    /// <param name="proxy">The shape proxy</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="callback">A user implemented callback function</param>
    public TreeStats OverlapShape(in ShapeProxy proxy, QueryFilter filter, OverlapResultCallback callback)
    {
        bool OverlapResultCallbackPrivate(Shape shapeId, nint _) => callback(shapeId);
        return b2World_OverlapShape(id, in proxy, filter, OverlapResultCallbackPrivate, 0);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetPreSolveCallback")]
    private static extern void b2World_SetPreSolveCallback(WorldId worldId, PreSolveNintCallback fcn, nint context);

    /// <summary>
    /// Register the pre-solve callback. This is optional.
    /// </summary>
    /// <param name="callback">The pre-solve callback function</param>
    /// <param name="context">The context</param>
    public void SetPreSolveCallback<TContext>(PreSolveCallback<TContext> callback, TContext context)
    {
        unsafe bool Callback(Shape shapeA, Shape shapeB, nint manifold, nint _) => callback(shapeA, shapeB, *(Manifold*)manifold, context);
        b2World_SetPreSolveCallback(id, Callback, 0);
    }

    /// <summary>
    /// Register the pre-solve callback. This is optional.
    /// </summary>
    /// <param name="callback">The pre-solve callback function</param>
    public void SetPreSolveCallback(PreSolveCallback callback)
    {
        unsafe bool Callback(Shape shapeA, Shape shapeB, nint manifold, nint _) => callback(shapeA, shapeB, *(Manifold*)manifold);
        b2World_SetPreSolveCallback(id, Callback, 0);
    }

    /// <summary>
    /// Register the pre-solve callback. This is optional.
    /// </summary>
    /// <param name="callback">The pre-solve callback function</param>
    /// <param name="context">The context</param>
    public void SetPreSolveCallback(PreSolveNintCallback callback, nint context)
    {
        b2World_SetPreSolveCallback(id, callback, context);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetGravity")]
    private static extern void b2World_SetGravity(WorldId worldId, Vec2 gravity);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetGravity")]
    private static extern Vec2 b2World_GetGravity(WorldId worldId);

    /// <summary>
    /// The gravity vector
    /// </summary>
    public Vec2 Gravity
    {
        get => b2World_GetGravity(id);
        set => b2World_SetGravity(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Explode")]
    private static extern void b2World_Explode(WorldId worldId, in ExplosionDef explosionDef);

    /// <summary>
    /// Apply a radial explosion
    /// </summary>
    /// <param name="explosionDef">The explosion definition</param>
    /// <remarks>Explosions are modeled as a force, not as a collision event</remarks>
    public void Explode(in ExplosionDef explosionDef) => b2World_Explode(id, explosionDef);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetContactTuning")]
    private static extern void b2World_SetContactTuning(WorldId worldId, float hertz, float dampingRatio, float pushSpeed);

    /// <summary>
    /// Adjust contact tuning parameters
    /// </summary>
    /// <param name="hertz">The contact stiffness (cycles per second)</param>
    /// <param name="dampingRatio">The contact bounciness with 1 being critical damping (non-dimensional)</param>
    /// <param name="pushSpeed">The maximum contact constraint push out speed (meters per second)</param>
    /// <remarks><i>Note: Advanced feature</i></remarks>
    public void SetContactTuning(float hertz, float dampingRatio, float pushSpeed) =>
        b2World_SetContactTuning(id, hertz, dampingRatio, pushSpeed);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetJointTuning")]
    private static extern void b2World_SetJointTuning(WorldId worldId, float hertz, float dampingRatio);

    /// <summary>
    /// Adjust joint tuning parameters
    /// </summary>
    /// <param name="hertz">The contact stiffness (cycles per second)</param>
    /// <param name="dampingRatio">The contact bounciness with 1 being critical damping (non-dimensional)</param>
    /// <remarks>Advanced feature</remarks>
    public void SetJointTuning(float hertz, float dampingRatio) => b2World_SetJointTuning(id, hertz, dampingRatio);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetMaximumLinearSpeed")]
    private static extern void b2World_SetMaximumLinearSpeed(WorldId worldId, float maximumLinearSpeed);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetMaximumLinearSpeed")]
    private static extern float b2World_GetMaximumLinearSpeed(WorldId worldId);

    /// <summary>
    /// The maximum linear speed.
    /// </summary>
    public float MaximumLinearSpeed
    {
        get => b2World_GetMaximumLinearSpeed(id);
        set => b2World_SetMaximumLinearSpeed(id, value);
    }


    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableWarmStarting")]
    private static extern void b2World_EnableWarmStarting(WorldId worldId, bool flag);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsWarmStartingEnabled")]
    private static extern bool b2World_IsWarmStartingEnabled(WorldId worldId);

    /// <summary>
    /// Enable/disable constraint warm starting. Advanced feature for testing. Disabling warm starting greatly reduces stability and provides no performance gain.
    /// </summary>
    public bool WarmStartingEnabled
    {
        get => b2World_IsWarmStartingEnabled(id);
        set => b2World_EnableWarmStarting(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetAwakeBodyCount")]
    private static extern int b2World_GetAwakeBodyCount(WorldId worldId);

    /// <summary>
    /// Get the number of awake bodies.
    /// </summary>
    /// <returns>The number of awake bodies</returns>
    public int GetAwakeBodyCount() => b2World_GetAwakeBodyCount(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetProfile")]
    private static extern Profile b2World_GetProfile(WorldId worldId);

    /// <summary>
    /// Get the current world performance profile
    /// </summary>
    /// <returns>The world performance profile</returns>
    public Profile Profile => b2World_GetProfile(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetCounters")]
    private static extern Counters b2World_GetCounters(WorldId worldId);

    /// <summary>
    /// Get world counters and sizes
    /// </summary>
    /// <returns>The world counters and sizes</returns>
    public Counters Counters => b2World_GetCounters(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetUserData")]
    private static extern void b2World_SetUserData(WorldId worldId, nint userData);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetUserData")]
    private static extern nint b2World_GetUserData(WorldId worldId);

    /// <summary>
    /// The user data object for this world.
    /// </summary>
    public object? UserData
    {
        get => GetObjectAtPointer(b2World_GetUserData, id);
        set => SetObjectAtPointer(b2World_GetUserData, b2World_SetUserData, id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetFrictionCallback")]
    private static extern void b2World_SetFrictionCallback(WorldId worldId, FrictionCallback callback);

    /// <summary>
    /// Sets the friction callback.
    /// </summary>
    /// <param name="callback">The friction callback</param>
    /// <remarks>Passing NULL resets to default</remarks>
    public void SetFrictionCallback(FrictionCallback callback) => b2World_SetFrictionCallback(id, callback);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetRestitutionCallback")]
    private static extern void b2World_SetRestitutionCallback(WorldId worldId, RestitutionCallback callback);

    /// <summary>
    /// Sets the restitution callback.
    /// </summary>
    /// <param name="callback">The restitution callback</param>
    /// <remarks>Passing NULL resets to default</remarks>
    public void SetRestitutionCallback(RestitutionCallback callback) => b2World_SetRestitutionCallback(id, callback);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_DumpMemoryStats")]
    private static extern void b2World_DumpMemoryStats(WorldId worldId);

    /// <summary>
    /// Dumps memory stats to box2d_memory.txt
    /// </summary>
    /// <remarks>Memory stats are dumped to box2d_memory.txt</remarks>
    public void DumpMemoryStats() => b2World_DumpMemoryStats(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateBody")]
    private static extern Body b2CreateBody(WorldId worldId, in BodyDefInternal def);

    /// <summary>
    /// Creates a rigid body given a definition.
    /// </summary>
    /// <param name="def">The body definition</param>
    /// <returns>The body</returns>
    public Body CreateBody(BodyDef def)
    {
        Body body = b2CreateBody(id, def._internal);
        bodies.Add(body.index1, body);
        return body;
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateDistanceJoint")]
    private static extern JointId b2CreateDistanceJoint(WorldId worldId, in DistanceJointDefInternal def);

    /// <summary>
    /// Creates a distance joint
    /// </summary>
    /// <param name="def">The distance joint definition</param>
    /// <returns>The distance joint</returns>
    public DistanceJoint CreateJoint(DistanceJointDef def) => new(b2CreateDistanceJoint(id, def._internal));

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateMotorJoint")]
    private static extern JointId b2CreateMotorJoint(WorldId worldId, in MotorJointDefInternal def);

    /// <summary>
    /// Creates a motor joint
    /// </summary>
    /// <param name="def">The motor joint definition</param>
    /// <returns>The motor joint</returns>
    public MotorJoint CreateJoint(MotorJointDef def) => new(b2CreateMotorJoint(id, def._internal));

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateMouseJoint")]
    private static extern JointId b2CreateMouseJoint(WorldId worldId, in MouseJointDefInternal def);

    /// <summary>
    /// Creates a mouse joint
    /// </summary>
    /// <param name="def">The mouse joint definition</param>
    /// <returns>The mouse joint</returns>
    public MouseJoint CreateJoint(MouseJointDef def) => new(b2CreateMouseJoint(id, def._internal));

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateFilterJoint")]
    private static extern JointId b2CreateFilterJoint(WorldId worldId, in FilterJointDefInternal def);

    /// <summary>
    /// Creates a filter joint. See <see cref="FilterJointDef"/> for details.
    /// </summary>
    /// <param name="def">The filter joint definition</param>
    /// <returns>The filter joint</returns>
    /// <remarks>The filter joint is used to disable collision between two bodies. As a side effect of being a joint, it also keeps the two bodies in the same simulation island.</remarks>
    public Joint CreateJoint(FilterJointDef def) => new(b2CreateFilterJoint(id, def._internal));

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreatePrismaticJoint")]
    private static extern JointId b2CreatePrismaticJoint(WorldId worldId, in PrismaticJointDefInternal def);

    /// <summary>
    /// Creates a prismatic (slider) joint
    /// </summary>
    /// <param name="def">The prismatic joint definition</param>
    /// <returns>The prismatic joint</returns>
    public PrismaticJoint CreateJoint(PrismaticJointDef def) => new(b2CreatePrismaticJoint(id, def._internal));

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateRevoluteJoint")]
    private static extern JointId b2CreateRevoluteJoint(WorldId worldId, in RevoluteJointDefInternal def);

    /// <summary>
    /// Creates a revolute joint
    /// </summary>
    /// <param name="def">The <see cref="RevoluteJointDef"/></param>
    /// <returns>The revolute joint</returns>
    public RevoluteJoint CreateJoint(RevoluteJointDef def) => new(b2CreateRevoluteJoint(id, def._internal));

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWeldJoint")]
    private static extern JointId b2CreateWeldJoint(WorldId worldId, in WeldJointDefInternal def);

    /// <summary>
    /// Creates a weld joint
    /// </summary>
    /// <param name="def">The <see cref="WeldJointDef"/></param>
    /// <returns>The weld joint</returns>
    public WeldJoint CreateJoint(WeldJointDef def) => new(b2CreateWeldJoint(id, def._internal));

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWheelJoint")]
    private static extern JointId b2CreateWheelJoint(WorldId worldId, in WheelJointDefInternal def);

    /// <summary>
    /// Creates a wheel joint
    /// </summary>
    /// <param name="def">The wheel joint definition</param>
    /// <returns>The wheel joint</returns>
    public WheelJoint CreateJoint(WheelJointDef def) => new(b2CreateWheelJoint(id, def._internal));

    public override string ToString() => $"World: {id.index1}:{id.generation}";

    /// <summary>
    /// Gets the bodies in this world
    /// </summary>
    public IEnumerable<Body> Bodies => bodies.Values;
}
