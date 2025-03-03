using System;
using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
public struct Shape : IEquatable<Shape>
{
    [FieldOffset(0)]
    private int index1;
    [FieldOffset(4)]
    private ushort world0;
    [FieldOffset(6)]
    private ushort generation;
    
    public bool Equals(Shape other) => index1 == other.index1 && world0 == other.world0 && generation == other.generation;
    public override bool Equals(object? obj) => obj is Shape other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(index1, world0, generation);
    
    
#if BOX2D_300    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyShape")]
    private static extern void b2DestroyShape(Shape shapeId);
    
    /// <summary>
    /// Destroys this shape
    /// </summary>
    /// <param name="updateBodyMass">Option to defer the body mass update</param>
    /// <remarks>You may defer the body mass update which can improve performance if several shapes on a body are destroyed at once</remarks>
    public void Destroy()
    {
        // dealloc user data
        nint userDataPtr = b2Shape_GetUserData(this);
        Box2D.FreeHandle(userDataPtr);
        
        b2DestroyShape(this);
    }
#else
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyShape")]
    private static extern void b2DestroyShape(Shape shapeId, bool updateBodyMass);

    /// <summary>
    /// Destroys this shape
    /// </summary>
    /// <param name="updateBodyMass">Option to defer the body mass update</param>
    /// <remarks>You may defer the body mass update which can improve performance if several shapes on a body are destroyed at once</remarks>
    public void Destroy(bool updateBodyMass)
    {
        // dealloc user data
        nint userDataPtr = b2Shape_GetUserData(this);
        Box2D.FreeHandle(userDataPtr);
        
        b2DestroyShape(this, updateBodyMass);
    }
    
#endif

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
    public ShapeType GetShapeType() => b2Shape_GetType(this);

    public ShapeType Type => GetShapeType();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetBody")]
    private static extern Body b2Shape_GetBody(Shape shapeId);
    
    /// <summary>
    /// Gets the body that this shape is attached to
    /// </summary>
    /// <returns>The body that this shape is attached to</returns>
    public Body GetBody() => b2Shape_GetBody(this);

    public Body Body => GetBody();
    
#if !BOX2D_300
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetWorld")]
    private static extern World b2Shape_GetWorld(Shape shapeId);
    
    public World World => b2Shape_GetWorld(this);

#endif
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_IsSensor")]
    private static extern bool b2Shape_IsSensor(Shape shapeId);
    
    /// <summary>
    /// Checks if this shape is a sensor
    /// </summary>
    /// <returns>true if this shape is a sensor</returns>
    public bool IsSensor() => b2Shape_IsSensor(this);

    public bool Sensor => IsSensor();
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnableSensorEvents")]
    private static extern void b2Shape_EnableSensorEvents(Shape shapeId, bool flag);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_AreSensorEventsEnabled")]
    private static extern bool b2Shape_AreSensorEventsEnabled(Shape shapeId);
    
    /// <summary>
    /// Sensor enabled state for this shape
    /// </summary>
    private bool SensorEventsEnabled
    {
        get => b2Shape_AreSensorEventsEnabled(this);
        set => b2Shape_EnableSensorEvents(this, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetUserData")]
    private static extern void b2Shape_SetUserData(Shape shapeId, nint userData);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetUserData")]
    private static extern nint b2Shape_GetUserData(Shape shapeId);
    
    /// <summary>
    /// The user data object for this shape.
    /// </summary>
    public object? UserData
    {
        get => Box2D.GetObjectAtPointer(b2Shape_GetUserData,this);
        set => Box2D.SetObjectAtPointer(b2Shape_GetUserData, b2Shape_SetUserData, this, value);
    }
    
#if BOX2D_300

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetDensity")]
    private static extern void b2Shape_SetDensity(Shape shapeId, float density);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetDensity")]
    private static extern float b2Shape_GetDensity(Shape shapeId);
    
    /// <summary>
    /// The mass density of this shape
    /// </summary>
    public float Density
    {
        get => b2Shape_GetDensity(this);
        set => b2Shape_SetDensity(this, value);
    }
#else
    
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
    /// The mass density of this shape
    /// </summary>
    /// <remarks>This will update the mass properties on the parent body. To avoid this, use <see cref="SetDensity(float,bool)"/></remarks>
    public float Density
    {
        get => b2Shape_GetDensity(this);
        set => b2Shape_SetDensity(this, value, true);
    }

#endif
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetFriction")]
    private static extern void b2Shape_SetFriction(Shape shapeId, float friction);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetFriction")]
    private static extern float b2Shape_GetFriction(Shape shapeId);
    
    /// <summary>
    /// The friction on this shape
    /// </summary>
    public float Friction
    {
        get => b2Shape_GetFriction(this);
        set => b2Shape_SetFriction(this, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetRestitution")]
    private static extern void b2Shape_SetRestitution(Shape shapeId, float restitution);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetRestitution")]
    private static extern float b2Shape_GetRestitution(Shape shapeId);
    
    public float Restitution
    {
        get => b2Shape_GetRestitution(this);
        set => b2Shape_SetRestitution(this, value);
    }
    
#if !BOX2D_300
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetMaterial")]
    private static extern void b2Shape_SetMaterial(Shape shapeId, int material);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetMaterial")]
    private static extern int b2Shape_GetMaterial(Shape shapeId);
    
/// <summary>
/// The material for this shape
/// </summary>
    public int Material
    {
        get =>  b2Shape_GetMaterial(this);
        set => b2Shape_SetMaterial(this, value);
    }

#endif

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetFilter")]
    private static extern Filter b2Shape_GetFilter(Shape shapeId);
    
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetFilter")]
    private static extern void b2Shape_SetFilter(Shape shapeId, Filter filter);
    
    /// <summary>
    /// The filter for this shape
    /// </summary>
    /// <remarks>Setting this is almost as expensive as recreating the shape. This may cause contacts to be immediately destroyed. However contacts are not created until the next world step. Sensor overlap state is also not updated until the next world step</remarks>
    public Filter Filter
    {
        get => b2Shape_GetFilter(this);
        set => b2Shape_SetFilter(this, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnableContactEvents")]
    private static extern void b2Shape_EnableContactEvents(Shape shapeId, bool flag);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_AreContactEventsEnabled")]
    private static extern bool b2Shape_AreContactEventsEnabled(Shape shapeId);
    
    /// <summary>
    /// Contact enabled state for this shape
    /// </summary>
    public bool ContactEventsEnabled
    {
        get => b2Shape_AreContactEventsEnabled(this);
        set => b2Shape_EnableContactEvents(this, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnablePreSolveEvents")]
    private static extern void b2Shape_EnablePreSolveEvents(Shape shapeId, bool flag);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_ArePreSolveEventsEnabled")]
    private static extern bool b2Shape_ArePreSolveEventsEnabled(Shape shapeId);

    /// <summary>
    /// The pre-solve contact enabled state for this shape
    /// </summary>
    /// <remarks>Only applies to dynamic bodies. <br/><br/><b>Warning: These are expensive and must be carefully handled due to multithreading.</b><br/><br/>Ignored for sensors</remarks>
    public bool PreSolveEventsEnabled
    {
        get => b2Shape_ArePreSolveEventsEnabled(this);
        set => b2Shape_EnablePreSolveEvents(this, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnableHitEvents")]
    private static extern void b2Shape_EnableHitEvents(Shape shapeId, bool flag);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_AreHitEventsEnabled")]
    private static extern bool b2Shape_AreHitEventsEnabled(Shape shapeId);
    
    /// <summary>
    /// Hit events enabled state for this shape
    /// </summary>
    public bool HitEventsEnabled
    {
        get => b2Shape_AreHitEventsEnabled(this);
        set => b2Shape_EnableHitEvents(this, value);
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
    public CastOutput RayCast(in RayCastInput input) => b2Shape_RayCast(this, input);

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
    public void SetCircle(in Circle circle) => b2Shape_SetCircle(this, circle);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetCapsule")]
    private static extern void b2Shape_SetCapsule(Shape shapeId, in Capsule capsule);
    
    /// <summary>
    /// Allows you to change this shape to be a capsule or update the current capsule
    /// </summary>
    /// <param name="capsule">The capsule</param>
    /// <remarks>This does not modify the mass properties</remarks>
    public void SetCapsule(in Capsule capsule) => b2Shape_SetCapsule(this, capsule);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetSegment")]
    private static extern void b2Shape_SetSegment(Shape shapeId, in Segment segment);
    
    /// <summary>
    /// Allows you to change this shape to be a segment or update the current segment
    /// </summary>
    /// <param name="segment">The segment</param>
    public void SetSegment(in Segment segment) => b2Shape_SetSegment(this, segment);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetPolygon")]
    private static extern void b2Shape_SetPolygon(Shape shapeId, in Polygon polygon);
    
    /// <summary>
    /// Allows you to change this shape to be a polygon or update the current polygon
    /// </summary>
    /// <param name="polygon">The polygon</param>
    /// <remarks>This does not modify the mass properties</remarks>
    public void SetPolygon(in Polygon polygon) => b2Shape_SetPolygon(this, polygon);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetParentChain")]
    private static extern ChainShape b2Shape_GetParentChain(Shape shapeId);
    
    /// <summary>
    /// Gets the parent chain id if the shape type is a chain segment
    /// </summary>
    /// <returns>The parent chain id if the shape type is a chain segment, otherwise returns 0</returns>
    public ChainShape GetParentChain() => b2Shape_GetParentChain(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetContactCapacity")]
    private static extern int b2Shape_GetContactCapacity(Shape shapeId);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetContactData")]
    private static extern int b2Shape_GetContactData(Shape shapeId, nint contactData, int capacity);

    public ContactData[] ContactData
    {
        get
        {
            int capacity = b2Shape_GetContactCapacity(this);
            ContactData[] contactData = new ContactData[capacity];
            GCHandle handle = GCHandle.Alloc(contactData, GCHandleType.Pinned);
            nint contactDataPtr = handle.AddrOfPinnedObject();
            int count = b2Shape_GetContactData(this, contactDataPtr, capacity);
            handle.Free();
            Array.Resize(ref contactData, count);
            return contactData;
        }
    }
    
    
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetSensorCapacity")]
    private static extern int b2Shape_GetSensorCapacity(Shape shapeId);
    
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetSensorOverlaps")]
    private static extern int b2Shape_GetSensorOverlaps(Shape shapeId, nint overlaps, int capacity);

#if BOX2D_300
    
#else
    /// <summary>
    /// Gets the overlapped shapes for this sensor shape, up to the provided capacity
    /// </summary>
    /// <returns>The number of elements filled in the provided array</returns>
    /// <remarks>
    /// Overlaps may contain destroyed shapes so use <see cref="IsValid"/> to confirm each overlap.<br/><br/>
    /// <b>Warning: Do not fetch this property during the contact callbacks</b>
    /// </remarks>
    public Shape[] SensorOverlaps
    {
        get
        {
            int capacity = b2Shape_GetSensorCapacity(this);
            Shape[] overlaps = new Shape[capacity];
            GCHandle handle = GCHandle.Alloc(overlaps, GCHandleType.Pinned);
            nint overlapsPtr = handle.AddrOfPinnedObject();
            int count = b2Shape_GetSensorOverlaps(this, overlapsPtr, capacity);
            handle.Free();
            return overlaps;
        }
    }
#endif
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetAABB")]
    private static extern AABB b2Shape_GetAABB(Shape shapeId);
    
    /// <summary>
    /// Gets the current world AABB
    /// </summary>
    /// <returns>The current world AABB</returns>
    /// <remarks>This is the axis-aligned bounding box in world coordinates</remarks>
    public AABB GetAABB() => b2Shape_GetAABB(this);

    public AABB AABB => GetAABB();

#if !BOX2D_300
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetMassData")]
    private static extern MassData b2Shape_GetMassData(Shape shapeId);
    
    public MassData MassData => b2Shape_GetMassData(this);

#endif

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

    /// <summary>
    /// Gets the local vertices of this shape
    /// </summary>
    public Vec2[] LocalVertices
    {
        get
        {
            {
                switch (Type)
                {
                    case ShapeType.Circle:
                        return [GetCircle().Center];
                    case ShapeType.Segment:
                        var segment = GetSegment();
                        return [segment.Point1, segment.Point2];
                    case ShapeType.Polygon:
                        return GetPolygon().Vertices.ToArray();
                    case ShapeType.Capsule:
                        var capsule = GetCapsule();
                        return [capsule.Center1, capsule.Center2];
                    case ShapeType.ChainSegment:
                        var chainSegment = GetChainSegment();
                        return [chainSegment.Segment.Point1, chainSegment.Segment.Point2];
                    default:
                        return [];
                }
            }
        }
    }

    /// <summary>
    /// Gets the world vertices of this shape
    /// </summary>
    public Vec2[] WorldVertices
    {
        get
        {
            Vec2[] localVertices = LocalVertices;
        
            Vec2[] worldVertices = new Vec2[localVertices.Length];
        
            var body = Body;
        
            for (int i = 0; i < localVertices.Length; i++)
                worldVertices[i] = body.GetWorldPoint(localVertices[i]);
        
            return worldVertices;
        }
    }
}