using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Shape
{
    private int index1;
    private ushort world0;
    private ushort generation;
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyShape")]
    private static extern void b2DestroyShape(Shape shapeId, bool updateBodyMass);
    
    /// <summary>
    /// Destroys this shape
    /// </summary>
    /// <param name="updateBodyMass">Option to defer the body mass update</param>
    /// <remarks>You may defer the body mass update which can improve performance if several shapes on a body are destroyed at once</remarks>
    public void Destroy(bool updateBodyMass) => b2DestroyShape(this, updateBodyMass);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_IsValid")]
    private static extern bool b2Shape_IsValid(Shape shapeId);
    
    /// <summary>
    /// Checks if this shape is valid
    /// </summary>
    /// <returns>true if this shape is valid</returns>
    /// <remarks>Provides validation for up to 64K allocations</remarks>
    public bool IsValid() => b2Shape_IsValid(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetType")]
    private static extern ShapeType b2Shape_GetType(Shape shapeId);
    
    /// <summary>
    /// Gets the type of this shape
    /// </summary>
    /// <returns>The type of this shape</returns>
    public ShapeType GetType() => b2Shape_GetType(this);

    public ShapeType Type => GetType();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetBody")]
    private static extern Body b2Shape_GetBody(Shape shapeId);
    
    /// <summary>
    /// Gets the body that this shape is attached to
    /// </summary>
    /// <returns>The body that this shape is attached to</returns>
    public Body GetBody() => b2Shape_GetBody(this);

    public Body Body => GetBody();
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetWorld")]
    private static extern World b2Shape_GetWorld(Shape shapeId);
    
    /// <summary>
    /// Gets the world that owns this shape
    /// </summary>
    /// <returns>The world that owns this shape</returns>
    public World GetWorld() => b2Shape_GetWorld(this);

    public World World => GetWorld();
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_IsSensor")]
    private static extern bool b2Shape_IsSensor(Shape shapeId);
    
    /// <summary>
    /// Checks if this shape is a sensor
    /// </summary>
    /// <returns>true if this shape is a sensor</returns>
    public bool IsSensor() => b2Shape_IsSensor(this);

    public bool Sensor => IsSensor();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetUserData")]
    private static extern void b2Shape_SetUserData(Shape shapeId, nint userData);
    
    /// <summary>
    /// Sets the user data for this shape
    /// </summary>
    /// <param name="userData">The user data</param>
    /// <typeparam name="T">The user data type</typeparam>
    public void SetUserData<T>(ref T userData)
    {
        GCHandle handle = GCHandle.Alloc(userData);
        nint userDataPtr = GCHandle.ToIntPtr(handle);
        b2Shape_SetUserData(this, userDataPtr);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetUserData")]
    private static extern nint b2Shape_GetUserData(Shape shapeId);
    
    /// <summary>
    /// Gets the user data for this shape
    /// </summary>
    /// <returns>The user data for this shape</returns>
    /// <remarks>This is useful when you get a shape id from an event or query</remarks>
    /// <typeparam name="T">The user data type</typeparam>
    public T? GetUserData<T>()
    {
        nint userDataPtr = b2Shape_GetUserData(this);
        if (userDataPtr == 0) return default;
        GCHandle handle = GCHandle.FromIntPtr(userDataPtr);
        if (!handle.IsAllocated) return default;
        T? userData = (T?)handle.Target;
        return userData;
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetDensity")]
    private static extern void b2Shape_SetDensity(Shape shapeId, float density, bool updateBodyMass);
    
    /// <summary>
    /// Sets the mass density of this shape
    /// </summary>
    /// <param name="density">The mass density</param>
    /// <param name="updateBodyMass">Option to update the mass properties on the parent body</param>
    /// <remarks>This will optionally update the mass properties on the parent body</remarks>
    public void SetDensity(float density, bool updateBodyMass) => b2Shape_SetDensity(this, density, updateBodyMass);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetDensity")]
    private static extern float b2Shape_GetDensity(Shape shapeId);
    
    /// <summary>
    /// Gets the mass density of this shape
    /// </summary>
    /// <returns>The mass density of this shape</returns>
    public float GetDensity() => b2Shape_GetDensity(this);

    public float Density
    {
        get => GetDensity();
        set => SetDensity(value, true);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetFriction")]
    private static extern void b2Shape_SetFriction(Shape shapeId, float friction);
    
    /// <summary>
    /// Sets the friction on this shape
    /// </summary>
    /// <param name="friction">The friction</param>
    public void SetFriction(float friction) => b2Shape_SetFriction(this, friction);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetFriction")]
    private static extern float b2Shape_GetFriction(Shape shapeId);
    
    /// <summary>
    /// Gets the friction on this shape
    /// </summary>
    /// <returns>The friction on this shape</returns>
    public float GetFriction() => b2Shape_GetFriction(this);

    public float Friction
    {
        get => GetFriction();
        set => SetFriction(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetRestitution")]
    private static extern void b2Shape_SetRestitution(Shape shapeId, float restitution);
    
    /// <summary>
    /// Sets the shape restitution (bounciness)
    /// </summary>
    /// <param name="restitution">The restitution</param>
    public void SetRestitution(float restitution) => b2Shape_SetRestitution(this, restitution);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetRestitution")]
    private static extern float b2Shape_GetRestitution(Shape shapeId);
    
    /// <summary>
    /// Gets the shape restitution (bounciness)
    /// </summary>
    /// <returns>The restitution</returns>
    public float GetRestitution() => b2Shape_GetRestitution(this);

    public float Restitution
    {
        get => GetRestitution();
        set => SetRestitution(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetMaterial")]
    private static extern void b2Shape_SetMaterial(Shape shapeId, int material);
    
    /// <summary>
    /// Sets the shape material identifier
    /// </summary>
    /// <param name="material">The material identifier</param>
    public void SetMaterial(int material) => b2Shape_SetMaterial(this, material);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetMaterial")]
    private static extern int b2Shape_GetMaterial(Shape shapeId);
    
    /// <summary>
    /// Gets the shape material identifier
    /// </summary>
    /// <returns>The material identifier</returns>
    public int GetMaterial() => b2Shape_GetMaterial(this);

    public int Material
    {
        get => GetMaterial();
        set => SetMaterial(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetFilter")]
    private static extern Filter b2Shape_GetFilter(Shape shapeId);
    
    /// <summary>
    /// Gets the shape filter
    /// </summary>
    /// <returns>The filter</returns>
    public Filter GetFilter() => b2Shape_GetFilter(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetFilter")]
    private static extern void b2Shape_SetFilter(Shape shapeId, Filter filter);
    
    /// <summary>
    /// Sets the current filter
    /// </summary>
    /// <param name="filter">The filter</param>
    /// <remarks>This is almost as expensive as recreating the shape. This may cause contacts to be immediately destroyed. However contacts are not created until the next world step. Sensor overlap state is also not updated until the next world step</remarks>
    public void SetFilter(Filter filter) => b2Shape_SetFilter(this, filter);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnableContactEvents")]
    private static extern void b2Shape_EnableContactEvents(Shape shapeId, bool flag);
    
    /// <summary>
    /// Enable contact events for this shape
    /// </summary>
    /// <param name="flag">Option to enable contact events for this shape</param>
    /// <remarks>Only applies to kinematic and dynamic bodies. Ignored for sensors.
    /// <br/><br/><b>Warning: Changing this at run-time may lead to lost begin/end events</b></remarks>
    public void EnableContactEvents(bool flag) => b2Shape_EnableContactEvents(this, flag);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_AreContactEventsEnabled")]
    private static extern bool b2Shape_AreContactEventsEnabled(Shape shapeId);
    
    /// <summary>
    /// Checks if contact events are enabled for this shape
    /// </summary>
    /// <returns>true if contact events are enabled for this shape</returns>
    public bool AreContactEventsEnabled() => b2Shape_AreContactEventsEnabled(this);

    public bool ContactEventsEnabled => AreContactEventsEnabled();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnablePreSolveEvents")]
    private static extern void b2Shape_EnablePreSolveEvents(Shape shapeId, bool flag);
    
    /// <summary>
    /// Enables pre-solve contact events for this shape
    /// </summary>
    /// <param name="flag">Option to enable pre-solve contact events for this shape</param>
    /// <remarks>Only applies to dynamic bodies. <br/><br/><b>Waring: These are expensive and must be carefully handled due to multithreading.</b><br/><br/>Ignored for sensors</remarks>
    public void EnablePreSolveEvents(bool flag) => b2Shape_EnablePreSolveEvents(this, flag);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_ArePreSolveEventsEnabled")]
    private static extern bool b2Shape_ArePreSolveEventsEnabled(Shape shapeId);
    
    /// <summary>
    /// Checks if pre-solve events are enabled for this shape
    /// </summary>
    /// <returns>true if pre-solve events are enabled for this shape</returns>
    public bool ArePreSolveEventsEnabled() => b2Shape_ArePreSolveEventsEnabled(this);

    public bool PreSolveEventsEnabled => ArePreSolveEventsEnabled();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnableHitEvents")]
    private static extern void b2Shape_EnableHitEvents(Shape shapeId, bool flag);
    
    /// <summary>
    /// Enable contact hit events for this shape
    /// </summary>
    /// <param name="flag">Option to enable contact hit events for this shape</param>
    /// <remarks>Ignored for sensors.</remarks>
    public void EnableHitEvents(bool flag) => b2Shape_EnableHitEvents(this, flag);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_AreHitEventsEnabled")]
    private static extern bool b2Shape_AreHitEventsEnabled(Shape shapeId);
    
    /// <summary>
    /// Checks if hit events are enabled for this shape
    /// </summary>
    /// <returns>true if hit events are enabled for this shape</returns>
    public bool AreHitEventsEnabled() => b2Shape_AreHitEventsEnabled(this);

    public bool HitEventsEnabled
    {
        get => AreHitEventsEnabled();
        set => EnableHitEvents(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_TestPoint")]
    private static extern bool b2Shape_TestPoint(Shape shapeId, Vec2 point);
    
    /// <summary>
    /// Tests a point for overlap with this shape
    /// </summary>
    /// <param name="point">The point</param>
    /// <returns>true if the point overlaps with this shape</returns>
    public bool TestPoint(Vec2 point) => b2Shape_TestPoint(this, point);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_RayCast")]
    private static extern CastOutput b2Shape_RayCast(Shape shapeId, in RayCastInput input);
    
    /// <summary>
    /// Ray casts this shape directly
    /// </summary>
    /// <param name="input">The ray cast input</param>
    /// <returns>The ray cast output</returns>
    public CastOutput RayCast(ref RayCastInput input) => b2Shape_RayCast(this, input);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetCircle")]
    private static extern Circle b2Shape_GetCircle(Shape shapeId);
    
    /// <summary>
    /// Gets a copy of the shape's circle
    /// </summary>
    /// <returns>The circle</returns>
    /// <remarks>Asserts the type is correct</remarks>
    public Circle GetCircle() => b2Shape_GetCircle(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetSegment")]
    private static extern Segment b2Shape_GetSegment(Shape shapeId);
    
    /// <summary>
    /// Gets a copy of the shape's line segment
    /// </summary>
    /// <returns>The segment</returns>
    /// <remarks>Asserts the type is correct</remarks>
    public Segment GetSegment() => b2Shape_GetSegment(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetChainSegment")]
    private static extern ChainSegment b2Shape_GetChainSegment(Shape shapeId);
    
    /// <summary>
    /// Gets a copy of the shape's chain segment
    /// </summary>
    /// <returns>The chain segment</returns>
    /// <remarks>These come from chain shapes. Asserts the type is correct</remarks>
    public ChainSegment GetChainSegment() => b2Shape_GetChainSegment(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetCapsule")]
    private static extern Capsule b2Shape_GetCapsule(Shape shapeId);
    
    /// <summary>
    /// Gets a copy of the shape's capsule
    /// </summary>
    /// <returns>The capsule</returns>
    /// <remarks>Asserts the type is correct</remarks>
    public Capsule GetCapsule() => b2Shape_GetCapsule(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetPolygon")]
    private static extern Polygon b2Shape_GetPolygon(Shape shapeId);
    
    /// <summary>
    /// Gets a copy of the shape's convex polygon
    /// </summary>
    /// <returns>The polygon</returns>
    /// <remarks>Asserts the type is correct</remarks>
    public Polygon GetPolygon() => b2Shape_GetPolygon(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetCircle")]
    private static extern void b2Shape_SetCircle(Shape shapeId, in Circle circle);
    
    /// <summary>
    /// Allows you to change this shape to be a circle or update the current circle
    /// </summary>
    /// <param name="circle">The circle</param>
    /// <remarks>This does not modify the mass properties</remarks>
    public void SetCircle(ref Circle circle) => b2Shape_SetCircle(this, circle);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetCapsule")]
    private static extern void b2Shape_SetCapsule(Shape shapeId, in Capsule capsule);
    
    /// <summary>
    /// Allows you to change this shape to be a capsule or update the current capsule
    /// </summary>
    /// <param name="capsule">The capsule</param>
    /// <remarks>This does not modify the mass properties</remarks>
    public void SetCapsule(ref Capsule capsule) => b2Shape_SetCapsule(this, capsule);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetSegment")]
    private static extern void b2Shape_SetSegment(Shape shapeId, in Segment segment);
    
    /// <summary>
    /// Allows you to change this shape to be a segment or update the current segment
    /// </summary>
    /// <param name="segment">The segment</param>
    public void SetSegment(ref Segment segment) => b2Shape_SetSegment(this, segment);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetPolygon")]
    private static extern void b2Shape_SetPolygon(Shape shapeId, in Polygon polygon);
    
    /// <summary>
    /// Allows you to change this shape to be a polygon or update the current polygon
    /// </summary>
    /// <param name="polygon">The polygon</param>
    /// <remarks>This does not modify the mass properties</remarks>
    public void SetPolygon(ref Polygon polygon) => b2Shape_SetPolygon(this, polygon);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetParentChain")]
    private static extern ChainShape b2Shape_GetParentChain(Shape shapeId);
    
    /// <summary>
    /// Gets the parent chain id if the shape type is a chain segment
    /// </summary>
    /// <returns>The parent chain id if the shape type is a chain segment, otherwise returns 0</returns>
    public ChainShape GetParentChain() => b2Shape_GetParentChain(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetContactCapacity")]
    private static extern int b2Shape_GetContactCapacity(Shape shapeId);
    
    /// <summary>
    /// Gets the maximum capacity required for retrieving all the touching contacts on this shape
    /// </summary>
    /// <returns>The maximum capacity required for retrieving all the touching contacts on this shape</returns>
    /// <remarks>This is the maximum number of contacts that can be retrieved for this shape</remarks>
    public int GetContactCapacity() => b2Shape_GetContactCapacity(this);

    public int ContactCapacity => GetContactCapacity();
 
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetContactData")]
    private static extern int b2Shape_GetContactData(Shape shapeId, nint contactData, int capacity);
    
    /// <summary>
    /// Gets the touching contact data for this shape, up to the provided capacity
    /// </summary>
    /// <param name="contactData">The contact data array</param>
    /// <returns>The number of elements filled in the provided array</returns>
    /// <remarks>The provided shapeId will be either shapeIdA or shapeIdB on the contact data.<br/><br/>
    /// <i>Note: Box2D uses speculative collision so some contact points may be separated.</i><br/>
    /// <b>Warning: Do not ignore the return value, it specifies the valid number of elements</b></remarks>
    public int GetContactData(ContactData[] contactData)
    {
        GCHandle handle = GCHandle.Alloc(contactData, GCHandleType.Pinned);
        nint contactDataPtr = handle.AddrOfPinnedObject();
        int capacity = contactData.Length;
        int count = b2Shape_GetContactData(this, contactDataPtr, capacity);
        handle.Free();
        return count;
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetSensorCapacity")]
    private static extern int b2Shape_GetSensorCapacity(Shape shapeId);
    
    /// <summary>
    /// Gets the maximum capacity required for retrieving all the overlapped shapes on a sensor shape
    /// </summary>
    /// <returns>The required capacity to get all the overlaps in <see cref="GetSensorOverlaps"/></returns>
    public int GetSensorCapacity() => b2Shape_GetSensorCapacity(this);

    public int SensorCapacity => GetSensorCapacity();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetSensorOverlaps")]
    private static extern int b2Shape_GetSensorOverlaps(Shape shapeId, nint overlaps, int capacity);
    
    /// <summary>
    /// Gets the overlapped shapes for this sensor shape, up to the provided capacity
    /// </summary>
    /// <param name="overlaps">The overlapped shapes array</param>
    /// <returns>The number of elements filled in the provided array</returns>
    /// <remarks>
    /// Overlaps may contain destroyed shapes so use <see cref="IsValid"/> to confirm each overlap.<br/><br/>
    /// <b>Warning: Do not ignore the return value, it specifies the valid number of elements</b><br/>
    /// <b>Warning: Do not call this method during the contact callbacks</b>
    /// </remarks>
    public int GetSensorOverlaps(Shape[] overlaps)
    {
        GCHandle handle = GCHandle.Alloc(overlaps, GCHandleType.Pinned);
        nint overlapsPtr = handle.AddrOfPinnedObject();
        int capacity = overlaps.Length;
        int count = b2Shape_GetSensorOverlaps(this, overlapsPtr, capacity);
        handle.Free();
        return count;
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetAABB")]
    private static extern AABB b2Shape_GetAABB(Shape shapeId);
    
    /// <summary>
    /// Gets the current world AABB
    /// </summary>
    /// <returns>The current world AABB</returns>
    /// <remarks>This is the axis-aligned bounding box in world coordinates</remarks>
    public AABB GetAABB() => b2Shape_GetAABB(this);

    public AABB AABB => GetAABB();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetMassData")]
    private static extern MassData b2Shape_GetMassData(Shape shapeId);
    
    /// <summary>
    /// Gets the mass data for this shape
    /// </summary>
    /// <returns>The mass data for this shape</returns>
    public MassData GetMassData() => b2Shape_GetMassData(this);

    public MassData MassData => GetMassData();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetClosestPoint")]
    private static extern Vec2 b2Shape_GetClosestPoint(Shape shapeId, Vec2 target);
    
    /// <summary>
    /// Gets the closest point on this shape to a target point
    /// </summary>
    /// <param name="target">The target point</param>
    /// <returns>The closest point on this shape to the target point</returns>
    /// <remarks>Target and result are in world space</remarks>
    public Vec2 GetClosestPoint(Vec2 target)
    {
        return b2Shape_GetClosestPoint(this, target);
    }
}