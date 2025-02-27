using System;
using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
public struct Body
{
    [FieldOffset(0)]
    internal int index1;
    [FieldOffset(4)]
    internal ushort world0;
    [FieldOffset(6)]
    internal ushort generation;
        
    public bool Equals(Body other) => index1 == other.index1 && world0 == other.world0 && generation == other.generation;
    public override bool Equals(object? obj) => obj is Body other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(index1, world0, generation);
    
    // equality operator
    public static bool operator ==(Body left, Body right) => left.Equals(right);
    public static bool operator !=(Body left, Body right) => !(left == right);
    public bool ReferenceEquals(Body other) => this == other;

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyBody")]
    private static extern void b2DestroyBody(Body bodyId);
    
    /// <summary>
    /// Destroy this body.
    /// </summary>
    /// <remarks>This destroys all shapes and joints attached to the body. Do not keep references to the associated shapes and joints</remarks>
    public void Destroy()
    {
        World._bodies[world0+1].Remove(index1);
        b2DestroyBody(this);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsValid")]
    private static extern bool b2Body_IsValid(Body bodyId);
    
    /// <summary>
    /// Body identifier validation.
    /// </summary>
    /// <returns>True if the body id is valid</returns>
    /// <remarks>Can be used to detect orphaned ids. Provides validation for up to 64K allocations</remarks>
    public bool IsValid() => b2Body_IsValid(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetType")]
    private static extern BodyType b2Body_GetType(Body bodyId);
    
    /// <summary>
    /// Get the body type: static, kinematic, or dynamic
    /// </summary>
    /// <returns>The body type</returns>
    [Obsolete("Use the Type property instead")]
    public BodyType GetBodyType() => b2Body_GetType(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetType")]
    private static extern void b2Body_SetType(Body bodyId, BodyType type);

    /// <summary>
    /// Change the body type.
    /// </summary>
    /// <param name="type">The body type</param>
    /// <remarks>This is an expensive operation. This automatically updates the mass properties regardless of the automatic mass setting</remarks>
    [Obsolete("Use the Type property instead")]
    public void SetType(BodyType type) => b2Body_SetType(this, type);

    /// <summary>
    /// The body type: static, kinematic, or dynamic.
    /// </summary>
    public BodyType Type
    {
        get => b2Body_GetType(this);
        set => b2Body_SetType(this, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetName")]
    private static extern void b2Body_SetName(Body bodyId, string name);
    
    /// <summary>
    /// Set the body name.
    /// </summary>
    /// <param name="name">The body name</param>
    /// <remarks>Up to 31 characters</remarks>
    [Obsolete("Use the Name property instead")]
    public void SetName(string name) => b2Body_SetName(this, name);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetName")]
    private static extern string b2Body_GetName(Body bodyId);
    
    /// <summary>
    /// Get the body name.
    /// </summary>
    /// <returns>The body name</returns>
    /// <remarks>May be null</remarks>
    [Obsolete("Use the Name property instead")]
    public string GetName() => b2Body_GetName(this);
    
    /// <summary>
    /// The body name.
    /// </summary>
    public string Name
    {
        get => b2Body_GetName(this);
        set => b2Body_SetName(this, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetUserData")]
    private static extern void b2Body_SetUserData(Body bodyId, nint userData);
    
    /// <summary>
    /// Set the user data object for a body
    /// </summary>
    /// <param name="userData">The user data object</param>
    [Obsolete("Use the UserData property instead")]
    public void SetUserData<T>(ref T userData)
    {
        UserData = userData;
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetUserData")]
    private static extern nint b2Body_GetUserData(Body bodyId);
    
    /// <summary>
    /// Get the user data object for a body
    /// </summary>
    /// <returns>The user data object</returns>
    [Obsolete("Use the UserData property instead")]
    public T? GetUserData<T>()
    {
        return (T?)UserData;
    }
    
    /// <summary>
    /// The user data object for a body.
    /// </summary>
    public object? UserData
    {
        get
        {
            nint userDataPtr = b2Body_GetUserData(this);
            if (userDataPtr == 0) return null;
            GCHandle handle = GCHandle.FromIntPtr(userDataPtr);
            if (!handle.IsAllocated) return null;
            object? userData = handle.Target;
            return userData;
        }
        set
        {
            if (value == null)
            {
                b2Body_SetUserData(this, 0);
                return;
            }
            GCHandle handle = GCHandle.Alloc(value);
            nint userDataPtr = GCHandle.ToIntPtr(handle);
            b2Body_SetUserData(this, userDataPtr);
        }
    }
    
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetPosition")]
    private static extern Vec2 b2Body_GetPosition(Body bodyId);
    
    /// <summary>
    /// Get the world position of a body.
    /// </summary>
    /// <returns>The world position of the body</returns>
    /// <remarks>This is the location of the body origin</remarks>
    [Obsolete("Use the Position property instead")]
    public Vec2 GetPosition() => b2Body_GetPosition(this);

    /// <summary>
    /// The world position of the body.
    /// </summary>
    /// <remarks>This is the location of the body origin</remarks>
    public Vec2 Position => b2Body_GetPosition(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetRotation")]
    private static extern Rotation b2Body_GetRotation(Body bodyId);
    
    /// <summary>
    /// Get the world rotation of a body as a cosine/sine pair (complex number)
    /// </summary>
    /// <returns>The world rotation of the body as a cosine/sine pair (complex number)</returns>
    [Obsolete("Use the Rotation property instead")]
    public Rotation GetRotation() => b2Body_GetRotation(this);

    /// <summary>
    /// The world rotation of this body as a cosine/sine pair (complex number).
    /// </summary>
    public Rotation Rotation => b2Body_GetRotation(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetTransform")]
    private static extern Transform b2Body_GetTransform(Body bodyId);
    
    /// <summary>
    /// Get the world transform of a body.
    /// </summary>
    /// <returns>The world transform of the body</returns>
    [Obsolete("Use the Transform property instead")]
    public Transform GetTransform() => b2Body_GetTransform(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetTransform")]
    private static extern void b2Body_SetTransform(Body bodyId, Vec2 position, Rotation rotation);
    
    /// <summary>
    /// Set the world transform of a body.
    /// </summary>
    /// <param name="position">The position</param>
    /// <param name="rotation">The rotation</param>
    /// <remarks>This acts as a teleport and is fairly expensive.<br/>
    /// <i>Note: Generally you should create a body with the intended transform.</i></remarks>
    [Obsolete("Use the Transform property instead")]
    public void SetTransform(Vec2 position, Rotation rotation) => b2Body_SetTransform(this, position, rotation);
    
    /// <summary>
    /// The world transform of this body.
    /// </summary>
    /// <remarks>Setting this acts as a teleport and is fairly expensive.<br/>
    /// <i>Note: Generally you should create a body with the intended transform.</i></remarks>
    public Transform Transform 
    {
        get => b2Body_GetTransform(this);
        set => b2Body_SetTransform(this, value.Position, value.Rotation);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLocalPoint")]
    private static extern Vec2 b2Body_GetLocalPoint(Body bodyId, Vec2 worldPoint);

    /// <summary>
    /// Get a local point on a body given a world point
    /// </summary>
    /// <param name="worldPoint">The world point</param>
    /// <returns>The local point on the body</returns>
    public Vec2 GetLocalPoint(Vec2 worldPoint) => b2Body_GetLocalPoint(this, worldPoint);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetWorldPoint")]
    private static extern Vec2 b2Body_GetWorldPoint(Body bodyId, Vec2 localPoint);

    /// <summary>
    /// Get a world point on a body given a local point
    /// </summary>
    /// <param name="localPoint">The local point</param>
    /// <returns>The world point on the body</returns>
    public Vec2 GetWorldPoint(Vec2 localPoint) => b2Body_GetWorldPoint(this, localPoint);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLocalVector")]
    private static extern Vec2 b2Body_GetLocalVector(Body bodyId, Vec2 worldVector);
    
    /// <summary>
    /// Get a local vector on a body given a world vector
    /// </summary>
    /// <param name="worldVector">The world vector</param>
    /// <returns>The local vector on the body</returns>
    public Vec2 GetLocalVector(Vec2 worldVector) => b2Body_GetLocalVector(this, worldVector);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetWorldVector")]
    private static extern Vec2 b2Body_GetWorldVector(Body bodyId, Vec2 localVector);
    
    /// <summary>
    /// Get a world vector on a body given a local vector
    /// </summary>
    /// <param name="localVector">The local vector</param>
    /// <returns>The world vector on the body</returns>
    public Vec2 GetWorldVector(Vec2 localVector) => b2Body_GetWorldVector(this, localVector);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetLinearVelocity")]
    private static extern void b2Body_SetLinearVelocity(Body bodyId, Vec2 linearVelocity);
    
    /// <summary>
    /// Set the linear velocity of a body
    /// </summary>
    /// <param name="linearVelocity">The linear velocity, usually in meters per second</param>
    /// <remarks>Usually in meters per second</remarks>
    public void SetLinearVelocity(Vec2 linearVelocity) => b2Body_SetLinearVelocity(this, linearVelocity);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLinearVelocity")]
    private static extern Vec2 b2Body_GetLinearVelocity(Body bodyId);
    
    /// <summary>
    /// Get the linear velocity of a body's center of mass
    /// </summary>
    /// <returns>The linear velocity of the body's center of mass, usually in meters per second</returns>
    /// <remarks>Usually in meters per second</remarks>
    [Obsolete("Use the LinearVelocity property instead")]
    public Vec2 GetLinearVelocity() => b2Body_GetLinearVelocity(this);

    /// <summary>
    /// The linear velocity of the body's center of mass.
    /// </summary>
    /// <remarks>Usually in meters per second</remarks>
    public Vec2 LinearVelocity
    {
        get => b2Body_GetLinearVelocity(this);
        set => b2Body_SetLinearVelocity(this, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetAngularVelocity")]
    private static extern float b2Body_GetAngularVelocity(Body bodyId);
    
    /// <summary>
    /// Get the angular velocity of a body in radians per second
    /// </summary>
    /// <returns>The angular velocity of the body in radians per second</returns>
    [Obsolete("Use the AngularVelocity property instead")]
    public float GetAngularVelocity() => b2Body_GetAngularVelocity(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetAngularVelocity")]
    private static extern void b2Body_SetAngularVelocity(Body bodyId, float angularVelocity);
    
    /// <summary>
    /// Set the angular velocity of a body in radians per second
    /// </summary>
    /// <param name="angularVelocity">The angular velocity in radians per second</param>
    /// <remarks>Usually in meters per second</remarks>
    [Obsolete("Use the AngularVelocity property instead")]
    public void SetAngularVelocity(float angularVelocity) => b2Body_SetAngularVelocity(this, angularVelocity);
    
    /// <summary>
    /// The angular velocity of the body in radians per second.
    /// </summary>
    /// <remarks>In radians per second</remarks>
    public float AngularVelocity
    {
        get => b2Body_GetAngularVelocity(this);
        set => b2Body_SetAngularVelocity(this, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLocalPointVelocity")]
    private static extern Vec2 b2Body_GetLocalPointVelocity(Body bodyId, Vec2 localPoint);
    
    /// <summary>
    /// Get the linear velocity of a local point attached to a body
    /// </summary>
    /// <param name="localPoint">The local point</param>
    /// <returns>The linear velocity of the local point attached to the body, usually in meters per second</returns>
    /// <remarks>Usually in meters per second</remarks>
    public Vec2 GetLocalPointVelocity(Vec2 localPoint) => b2Body_GetLocalPointVelocity(this, localPoint);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetWorldPointVelocity")]
    private static extern Vec2 b2Body_GetWorldPointVelocity(Body bodyId, Vec2 worldPoint);
    
    /// <summary>
    /// Get the linear velocity of a world point attached to a body
    /// </summary>
    /// <param name="worldPoint">The world point</param>
    /// <returns>The linear velocity of the world point attached to the body, usually in meters per second</returns>
    /// <remarks>Usually in meters per second</remarks>
    public Vec2 GetWorldPointVelocity(Vec2 worldPoint) => b2Body_GetWorldPointVelocity(this, worldPoint);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyForce")]
    private static extern void b2Body_ApplyForce(Body bodyId, Vec2 force, Vec2 point, bool wake);
    
    /// <summary>
    /// Apply a force at a world point
    /// </summary>
    /// <param name="force">The world force vector, usually in newtons (N)</param>
    /// <param name="point">The world position of the point of application</param>
    /// <param name="wake">Option to wake up the body</param>
    /// <remarks>If the force is not applied at the center of mass, it will generate a torque and affect the angular velocity. The force is ignored if the body is not awake</remarks>
    public void ApplyForce(Vec2 force, Vec2 point, bool wake) => b2Body_ApplyForce(this, force, point, wake);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyForceToCenter")]
    private static extern void b2Body_ApplyForceToCenter(Body bodyId, Vec2 force, bool wake);
    
    /// <summary>
    /// Apply a force to the center of mass
    /// </summary>
    /// <param name="force">The world force vector, usually in newtons (N)</param>
    /// <param name="wake">Option to wake up the body</param>
    /// <remarks>This wakes up the body</remarks>
    /// <remarks>If the force is not applied at the center of mass, it will generate a torque and affect the angular velocity. The force is ignored if the body is not awake</remarks>
    public void ApplyForceToCenter(Vec2 force, bool wake) => b2Body_ApplyForceToCenter(this, force, wake);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyTorque")]
    private static extern void b2Body_ApplyTorque(Body bodyId, float torque, bool wake);
    
    /// <summary>
    /// Apply a torque
    /// </summary>
    /// <param name="torque">The torque about the z-axis (out of the screen), usually in N*m</param>
    /// <param name="wake">Option to wake up the body</param>
    /// <remarks>This affects the angular velocity without affecting the linear velocity. The torque is ignored if the body is not awake</remarks>
    public void ApplyTorque(float torque, bool wake) => b2Body_ApplyTorque(this, torque, wake);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyLinearImpulse")]
    private static extern void b2Body_ApplyLinearImpulse(Body bodyId, Vec2 impulse, Vec2 point, bool wake);
    
    /// <summary>
    /// Apply an impulse at a point
    /// </summary>
    /// <param name="impulse">The world impulse vector, usually in N*s or kg*m/s</param>
    /// <param name="point">The world position of the point of application</param>
    /// <param name="wake">Option to wake up the body</param>
    /// <remarks>This immediately modifies the velocity. It also modifies the angular velocity if the point of application is not at the center of mass. The impulse is ignored if the body is not awake
    /// <br/><br/><b>Warning: This should be used for one-shot impulses. If you need a steady force, use a force instead, which will work better with the sub-stepping solver</b></remarks>
    public void ApplyLinearImpulse(Vec2 impulse, Vec2 point, bool wake) => b2Body_ApplyLinearImpulse(this, impulse, point, wake);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyLinearImpulseToCenter")]
    private static extern void b2Body_ApplyLinearImpulseToCenter(Body bodyId, Vec2 impulse, bool wake);
    
    /// <summary>
    /// Apply an impulse to the center of mass
    /// </summary>
    /// <param name="impulse">The world impulse vector, usually in N*s or kg*m/s</param>
    /// <param name="wake">Option to wake up the body</param>
    /// <remarks>This immediately modifies the velocity. The impulse is ignored if the body is not awake
    /// <br/><br/><b>Warning: This should be used for one-shot impulses. If you need a steady force, use a force instead, which will work better with the sub-stepping solver</b></remarks>
    public void ApplyLinearImpulseToCenter(Vec2 impulse, bool wake) => b2Body_ApplyLinearImpulseToCenter(this, impulse, wake);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyAngularImpulse")]
    private static extern void b2Body_ApplyAngularImpulse(Body bodyId, float impulse, bool wake);
    
    /// <summary>
    /// Apply an angular impulse
    /// </summary>
    /// <param name="impulse">The angular impulse, usually in units of kg*m*m/s</param>
    /// <param name="wake">Option to wake up the body</param>
    /// <remarks>The impulse is ignored if the body is not awake
    /// <br/><br/><b>Warning: This should be used for one-shot impulses. If you need a steady force, use a force instead, which will work better with the sub-stepping solver</b></remarks>
    public void ApplyAngularImpulse(float impulse, bool wake) => b2Body_ApplyAngularImpulse(this, impulse, wake);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetMass")]
    private static extern float b2Body_GetMass(Body bodyId  );
    
    /// <summary>
    /// Get the mass of the body
    /// </summary>
    /// <returns>The mass of the body, usually in kilograms</returns>
    [Obsolete("Use the Mass property instead")]
    public float GetMass() => b2Body_GetMass(this);

    /// <summary>
    /// The mass of the body, usually in kilograms.
    /// </summary>
    public float Mass => b2Body_GetMass(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetRotationalInertia")]
    private static extern float b2Body_GetRotationalInertia(Body bodyId);
    
    /// <summary>
    /// Get the rotational inertia of the body
    /// </summary>
    /// <returns>The rotational inertia of the body, usually in kg*m²</returns>
    [Obsolete("Use the RotationalInertia property instead")]
    public float GetRotationalInertia() => b2Body_GetRotationalInertia(this);

    /// <summary>
    /// The rotational inertia of the body, usually in kg*m².
    /// </summary>
    public float RotationalInertia => b2Body_GetRotationalInertia(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLocalCenterOfMass")]
    private static extern Vec2 b2Body_GetLocalCenterOfMass(Body bodyId);
    
    /// <summary>
    /// Get the center of mass position of the body in local space
    /// </summary>
    /// <returns>The center of mass position of the body in local space</returns>
    [Obsolete("Use the LocalCenterOfMass property instead")]
    public Vec2 GetLocalCenterOfMass() => b2Body_GetLocalCenterOfMass(this);

    /// <summary>
    /// The center of mass position of the body in local space.
    /// </summary>
    public Vec2 LocalCenterOfMass => b2Body_GetLocalCenterOfMass(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetWorldCenterOfMass")]
    private static extern Vec2 b2Body_GetWorldCenterOfMass(Body bodyId);
    
    /// <summary>
    /// Get the center of mass position of the body in world space
    /// </summary>
    /// <returns>The center of mass position of the body in world space</returns>
    [Obsolete("Use the WorldCenterOfMass property instead")]
    public Vec2 GetWorldCenterOfMass() => b2Body_GetWorldCenterOfMass(this);

    /// <summary>
    /// The center of mass position of the body in world space.
    /// </summary>
    public Vec2 WorldCenterOfMass => b2Body_GetWorldCenterOfMass(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetMassData")]
    private static extern void b2Body_SetMassData(Body bodyId, MassData massData);
    
    /// <summary>
    /// Override the body's mass properties
    /// </summary>
    /// <param name="massData">The mass data</param>
    /// <remarks>Normally this is computed automatically using the shape geometry and density. This information is lost if a shape is added or removed or if the body type changes</remarks>
    [Obsolete("Use the MassData property instead")]
    public void SetMassData(MassData massData) => b2Body_SetMassData(this, massData);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetMassData")]
    private static extern MassData b2Body_GetMassData(Body bodyId);
    
    /// <summary>
    /// Get the mass data for a body
    /// </summary>
    /// <returns>The mass data for the body</returns>
    [Obsolete("Use the MassData property instead")]
    public MassData GetMassData() => b2Body_GetMassData(this);

    /// <summary>
    /// The mass data for this body.
    /// </summary>
    public MassData MassData
    {
        get => b2Body_GetMassData(this);
        set => b2Body_SetMassData(this, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyMassFromShapes")]
    private static extern void b2Body_ApplyMassFromShapes(Body bodyId);
    
    /// <summary>
    /// This updates the mass properties to the sum of the mass properties of the shapes
    /// </summary>
    /// <remarks>This normally does not need to be called unless you called SetMassData to override the mass and you later want to reset the mass. You may also use this when automatic mass computation has been disabled. You should call this regardless of body type</remarks>
    public void ApplyMassFromShapes() => b2Body_ApplyMassFromShapes(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetLinearDamping")]
    private static extern void b2Body_SetLinearDamping(Body bodyId, float linearDamping);
    
    /// <summary>
    /// Adjust the linear damping
    /// </summary>
    /// <param name="linearDamping">The linear damping</param>
    /// <remarks>Normally this is set in b2BodyDef before creation</remarks>
    [Obsolete("Use the LinearDamping property instead")]
    public void SetLinearDamping(float linearDamping) => b2Body_SetLinearDamping(this, linearDamping);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLinearDamping")]
    private static extern float b2Body_GetLinearDamping(Body bodyId);
    
    /// <summary>
    /// Get the current linear damping
    /// </summary>
    /// <returns>The current linear damping</returns>
    [Obsolete("Use the LinearDamping property instead")]
    public float GetLinearDamping() => b2Body_GetLinearDamping(this);

    /// <summary>
    /// The linear damping.
    /// </summary>
    /// <remarks>Normally this is set in BodyDef before creation</remarks>
    public float LinearDamping
    {
        get => b2Body_GetLinearDamping(this);
        set => b2Body_SetLinearDamping(this, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetAngularDamping")]
    private static extern void b2Body_SetAngularDamping(Body bodyId, float angularDamping);
    
    /// <summary>
    /// Adjust the angular damping
    /// </summary>
    /// <param name="angularDamping">The angular damping</param>
    /// <remarks>Normally this is set in b2BodyDef before creation</remarks>
    [Obsolete("Use the AngularDamping property instead")]
    public void SetAngularDamping(float angularDamping) => b2Body_SetAngularDamping(this, angularDamping);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetAngularDamping")]
    private static extern float b2Body_GetAngularDamping(Body bodyId);
    
    /// <summary>
    /// Get the current angular damping
    /// </summary>
    /// <returns>The current angular damping</returns>
    [Obsolete("Use the AngularDamping property instead")]
    public float GetAngularDamping() => b2Body_GetAngularDamping(this);

    /// <summary>
    /// The angular damping.
    /// </summary>
    /// <remarks>Normally this is set in BodyDef before creation</remarks>
    public float AngularDamping
    {
        get => b2Body_GetAngularDamping(this);
        set => b2Body_SetAngularDamping(this, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetGravityScale")]
    private static extern void b2Body_SetGravityScale(Body bodyId, float gravityScale);
    
    /// <summary>
    /// Adjust the gravity scale
    /// </summary>
    /// <param name="gravityScale">The gravity scale</param>
    /// <remarks>Normally this is set in b2BodyDef before creation</remarks>
    [Obsolete("Use the GravityScale property instead")]
    public void SetGravityScale(float gravityScale) => b2Body_SetGravityScale(this, gravityScale);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetGravityScale")]
    private static extern float b2Body_GetGravityScale(Body bodyId);
    
    /// <summary>
    /// Get the gravity scale
    /// </summary>
    /// <returns>The gravity scale</returns>
    [Obsolete("Use the GravityScale property instead")]
    public float GetGravityScale() => b2Body_GetGravityScale(this);

    /// <summary>
    /// The gravity scale.
    /// </summary>
    /// <remarks>Normally this is set in BodyDef before creation</remarks>
    public float GravityScale
    {
        get => b2Body_GetGravityScale(this);
        set => b2Body_SetGravityScale(this, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsAwake")]
    private static extern bool b2Body_IsAwake(Body bodyId);
    
    /// <summary>
    /// Check if this body is awake
    /// </summary>
    /// <returns>true if this body is awake</returns>
    [Obsolete("Use the Awake property instead")]
    public bool IsAwake() => b2Body_IsAwake(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetAwake")]
    private static extern void b2Body_SetAwake(Body bodyId, bool awake);
    
    /// <summary>
    /// Wake a body from sleep
    /// </summary>
    /// <param name="awake">Option to wake up the body</param>
    /// <remarks>
    /// This wakes the entire island the body is touching.
    /// <b>Warning: Putting a body to sleep will put the entire island of bodies touching this body to sleep, which can be expensive and possibly unintuitive.</b>
    /// </remarks>
    [Obsolete("Use the Awake property instead")]
    public void SetAwake(bool awake) => b2Body_SetAwake(this, awake);

    /// <summary>
    /// The body awake state.
    /// </summary>
    /// <remarks>
    /// This wakes the entire island the body is touching.
    /// <b>Warning: Putting a body to sleep will put the entire island of bodies touching this body to sleep, which can be expensive and possibly unintuitive.</b>
    /// </remarks>
    public bool Awake
    {
        get => b2Body_IsAwake(this);
        set => b2Body_SetAwake(this, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_EnableSleep")]
    private static extern void b2Body_EnableSleep(Body bodyId, bool enableSleep);
    
    /// <summary>
    /// Enable or disable sleeping for this body
    /// </summary>
    /// <param name="enableSleep">Option to enable or disable sleeping</param>
    /// <remarks>If sleeping is disabled the body will wake</remarks>
    [Obsolete("Use the SleepEnabled property instead")]
    public void EnableSleep(bool enableSleep) => b2Body_EnableSleep(this, enableSleep);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsSleepEnabled")]
    private static extern bool b2Body_IsSleepEnabled(Body bodyId);
    
    /// <summary>
    /// Check if sleeping is enabled for this body
    /// </summary>
    /// <returns>true if sleeping is enabled for this body</returns>
    [Obsolete("Use the SleepEnabled property instead")]
    public bool IsSleepEnabled() => b2Body_IsSleepEnabled(this);

    /// <summary>
    /// Option to enable or disable sleeping for this body.
    /// </summary>
    /// <remarks>If sleeping is disabled the body will wake</remarks>
    public bool SleepEnabled
    {
        get => b2Body_IsSleepEnabled(this);
        set => b2Body_EnableSleep(this, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetSleepThreshold")]
    private static extern void b2Body_SetSleepThreshold(Body bodyId, float sleepThreshold);
    
    /// <summary>
    /// Set the sleep threshold
    /// </summary>
    /// <param name="sleepThreshold">The sleep threshold, usually in meters per second</param>
    [Obsolete("Use the SleepThreshold property instead")]
    public void SetSleepThreshold(float sleepThreshold) => b2Body_SetSleepThreshold(this, sleepThreshold);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetSleepThreshold")]
    private static extern float b2Body_GetSleepThreshold(Body bodyId);
    
    /// <summary>
    /// Get the sleep threshold
    /// </summary>
    /// <returns>The sleep threshold, usually in meters per second</returns>
    [Obsolete("Use the SleepThreshold property instead")]
    public float GetSleepThreshold() => b2Body_GetSleepThreshold(this);

    /// <summary>
    /// The sleep threshold, usually in meters per second.
    /// </summary>
    public float SleepThreshold
    {
        get => b2Body_GetSleepThreshold(this);
        set => b2Body_SetSleepThreshold(this, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsEnabled")]
    private static extern bool b2Body_IsEnabled(Body bodyId);
    
    /// <summary>
    /// Check if this body is enabled
    /// </summary>
    /// <returns>true if this body is enabled</returns>
    [Obsolete("Use the Enabled property instead")]
    public bool IsEnabled() => b2Body_IsEnabled(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_Disable")]
    private static extern void b2Body_Disable(Body bodyId);
    
    /// <summary>
    /// Disable a body
    /// </summary>
    /// <remarks>Disable a body by removing it completely from the simulation. <b>This is expensive</b></remarks>
    [Obsolete("Use the Enabled method instead")]
    public void Disable() => b2Body_Disable(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_Enable")]
    private static extern void b2Body_Enable(Body bodyId);
    
    /// <summary>
    /// Enable a body
    /// </summary>
    /// <remarks>Enable a body by adding it to the simulation. <b>This is expensive</b></remarks>
    [Obsolete("Use the Enabled method instead")]
    public void Enable() => b2Body_Enable(this);

    /// <summary>
    /// The body enabled flag. 
    /// </summary>
    public bool Enabled
    {
        get => b2Body_IsEnabled(this);
        set
        {
            if (value)
                b2Body_Enable(this);
            else
                b2Body_Disable(this);
        }
    }


    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetFixedRotation")]
    private static extern void b2Body_SetFixedRotation(Body bodyId, bool flag);
    
    /// <summary>
    /// Set this body to have fixed rotation
    /// </summary>
    /// <param name="flag">Option to set the body to have fixed rotation</param>
    /// <remarks>This causes the mass to be reset in all cases</remarks>
    [Obsolete("Use the FixedRotation property instead")]
    public void SetFixedRotation(bool flag) => b2Body_SetFixedRotation(this, flag);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsFixedRotation")]
    private static extern bool b2Body_IsFixedRotation(Body bodyId);
    
    /// <summary>
    /// Check if this body has fixed rotation
    /// </summary>
    /// <returns>true if this body has fixed rotation</returns>
    [Obsolete("Use the FixedRotation property instead")]
    public bool IsFixedRotation() => b2Body_IsFixedRotation(this);

    /// <summary>
    /// The fixed rotation flag of the body.
    /// </summary>
    /// <remarks>Setting this causes the mass to be reset in all cases</remarks>
    public bool FixedRotation
    {
        get => b2Body_IsFixedRotation(this);
        set => b2Body_SetFixedRotation(this, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetBullet")]
    private static extern void b2Body_SetBullet(Body bodyId, bool flag);
    
    /// <summary>
    /// Set this body to be a bullet
    /// </summary>
    /// <param name="flag">Option to set the body to be a bullet</param>
    /// <remarks>A bullet does continuous collision detection against dynamic bodies (but not other bullets)</remarks>
    [Obsolete("Use the Bullet property instead")]
    public void SetBullet(bool flag) => b2Body_SetBullet(this, flag);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsBullet")]
    private static extern bool b2Body_IsBullet(Body bodyId);
    
    /// <summary>
    /// Check if this body is a bullet
    /// </summary>
    /// <returns>true if this body is a bullet</returns>
    [Obsolete("Use the Bullet property instead")]
    public bool IsBullet() => b2Body_IsBullet(this);

    /// <summary>
    /// The bullet flag of the body.
    /// </summary>
    /// <remarks>A bullet does continuous collision detection against dynamic bodies (but not other bullets)</remarks>
    public bool Bullet
    {
        get => b2Body_IsBullet(this);
        set => b2Body_SetBullet(this, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_EnableContactEvents")]
    private static extern void b2Body_EnableContactEvents(Body bodyId, bool flag);

    /// <summary>
    /// Enable/disable contact events on all shapes
    /// </summary>
    /// <param name="flag">Option to enable or disable contact events on all shapes</param>
    /// <remarks><b>Warning: Changing this at runtime may cause mismatched begin/end touch events.</b></remarks>
    public void EnableContactEvents(bool flag) => b2Body_EnableContactEvents(this, flag);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_EnableHitEvents")]
    private static extern void b2Body_EnableHitEvents(Body bodyId, bool flag);
    
    /// <summary>
    /// Enable/disable hit events on all shapes
    /// </summary>
    /// <param name="flag">Option to enable or disable hit events on all shapes</param>
    public void EnableHitEvents(bool flag) => b2Body_EnableHitEvents(this, flag);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetWorld")]
    private static extern World b2Body_GetWorld(Body bodyId);
    
    /// <summary>
    /// Get the world that owns this body
    /// </summary>
    /// <returns>The world that owns this body</returns>
    [Obsolete("Use the World property instead")]
    public World GetWorld() => b2Body_GetWorld(this);

    /// <summary>
    /// The world that owns this body.
    /// </summary>
    public World World => b2Body_GetWorld(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetShapeCount")]
    private static extern int b2Body_GetShapeCount(Body bodyId);
    
    /// <summary>
    /// Get the number of shapes on this body
    /// </summary>
    /// <returns>The number of shapes on this body</returns>
    [Obsolete("Use the Shapes property instead")]
    public int GetShapeCount() => b2Body_GetShapeCount(this);
    
    /// <summary>
    /// The number of shapes on this body.
    /// </summary>
    [Obsolete("Use the Shapes property instead")]
    public int ShapeCount => b2Body_GetShapeCount(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetShapes")]
    private static extern int b2Body_GetShapes(Body bodyId, nint shapeArray, int capacity);
    
    /// <summary>
    /// Get the shape ids for all shapes on this body, up to the provided capacity
    /// </summary>
    /// <param name="shapeArray">The shape array</param>
    /// <returns>The number of shape ids stored in the user array</returns>
    [Obsolete("Use the Shapes property instead")]
    public int GetShapes(ref Shape[] shapeArray)
    {
        int capacity = shapeArray.Length;
        nint shapeArrayPtr = Marshal.UnsafeAddrOfPinnedArrayElement(shapeArray, 0);
        int count = b2Body_GetShapes(this, shapeArrayPtr, capacity);
        return count;
    }

    /// <summary>
    /// The shapes attached to this body.
    /// </summary>
    public Shape[] Shapes
    {
        get
        {
            int shapeCount = b2Body_GetShapeCount(this);
            Shape[] shapes = new Shape[shapeCount];
            nint shapeArrayPtr = Marshal.UnsafeAddrOfPinnedArrayElement(shapes, 0);
            b2Body_GetShapes(this, shapeArrayPtr, shapeCount);
            return shapes;
        }
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetJointCount")]
    private static extern int b2Body_GetJointCount(Body bodyId);
    
    /// <summary>
    /// Get the number of joints on this body
    /// </summary>
    /// <returns>The number of joints on this body</returns>
    [Obsolete("Use the Jointsproperty instead")]
    public int GetJointCount() => b2Body_GetJointCount(this);

    /// <summary>
    /// The number of joints on this body.
    /// </summary>
    [Obsolete("Use the Joints property instead")]
    public int JointCount => b2Body_GetJointCount(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetJoints")]
    private static extern int b2Body_GetJoints(Body bodyId, nint jointArray, int capacity);
    
    /// <summary>
    /// Get the joint ids for all joints on this body, up to the provided capacity
    /// </summary>
    /// <param name="jointArray">The joint array</param>
    /// <returns>The number of joint ids stored in the user array</returns>
    [Obsolete("Use the Joints property instead")]
    public int GetJoints(ref Joint[] jointArray)
    {
        int capacity = jointArray.Length;
        nint jointArrayPtr = Marshal.UnsafeAddrOfPinnedArrayElement(jointArray, 0);
        int count = b2Body_GetJoints(this, jointArrayPtr, capacity);
        return count;
    }
    
    /// <summary>
    /// The joints attached to this body.
    /// </summary>
    public Joint[] Joints
    {
        get
        {
            int jointCount = b2Body_GetJointCount(this);
            Joint[] joints = new Joint[jointCount];
            nint jointArrayPtr = Marshal.UnsafeAddrOfPinnedArrayElement(joints, 0);
            b2Body_GetJoints(this, jointArrayPtr, jointCount);
            return joints;
        }
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetContactCapacity")]
    private static extern int b2Body_GetContactCapacity(Body bodyId);
    
    /// <summary>
    /// Get the maximum capacity required for retrieving all the touching contacts on a body
    /// </summary>
    /// <returns>The maximum capacity required for retrieving all the touching contacts on a body</returns>
    [Obsolete("Use the Contacts property instead")]
    public int GetContactCapacity() => b2Body_GetContactCapacity(this);

    /// <summary>
    /// The maximum capacity required for retrieving all the touching contacts on a body.
    /// </summary>
    [Obsolete("Use the Contacts property instead")]
    public int ContactCapacity => b2Body_GetContactCapacity(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetContactData")]
    private static extern int b2Body_GetContactData(Body bodyId, nint contactData, int capacity);
    
    /// <summary>
    /// Get the touching contact data for a body
    /// </summary>
    /// <param name="contactData">The contact data</param>
    /// <returns>The number of elements filled in the provided array</returns>
    [Obsolete("Use the Contacts property instead")]
    public int GetContactData(ref ContactData[] contactData)
    {
        int capacity = contactData.Length;
        nint contactDataPtr = Marshal.UnsafeAddrOfPinnedArrayElement(contactData, 0);
        int count = b2Body_GetContactData(this, contactDataPtr, capacity);
        return count;
    }
    
    /// <summary>
    /// The touching contact data for this body.
    /// </summary>
    public ContactData[] Contacts
    {
        get
        {
            int contactCapacity = b2Body_GetContactCapacity(this);
            ContactData[] contactData = new ContactData[contactCapacity];
            nint contactDataPtr = Marshal.UnsafeAddrOfPinnedArrayElement(contactData, 0);
            b2Body_GetContactData(this, contactDataPtr, contactCapacity);
            return contactData;
        }
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ComputeAABB")]
    private static extern AABB b2Body_ComputeAABB(Body bodyId);
    
    /// <summary>
    /// Get the current world AABB that contains all the attached shapes
    /// </summary>
    /// <returns>The current world AABB that contains all the attached shapes</returns>
    /// <remarks>Note that this may not encompass the body origin. If there are no shapes attached then the returned AABB is empty and centered on the body origin</remarks>
    [Obsolete("Use the AABB property instead")]
    public AABB ComputeAABB() => b2Body_ComputeAABB(this);

    /// <summary>
    /// The current world AABB that contains all the attached shapes.
    /// </summary>
    /// <remarks>Note that this may not encompass the body origin. If there are no shapes attached then the returned AABB is empty and centered on the body origin</remarks>
    public AABB AABB => b2Body_ComputeAABB(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateCircleShape")]
    private static extern Shape b2CreateCircleShape(Body bodyId, in ShapeDefInternal def, in Circle circle);
    
    /// <summary>
    /// Creates a circle shape and attaches it to this body
    /// </summary>
    /// <param name="def">The shape definition</param>
    /// <param name="circle">The circle</param>
    /// <returns>The shape</returns>
    /// <remarks>The shape definition and geometry are fully cloned. Contacts are not created until the next time step</remarks>
    public Shape CreateShape(ShapeDef def, in Circle circle) => b2CreateCircleShape(this, def._internal, circle);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateSegmentShape")]
    private static extern Shape b2CreateSegmentShape(Body bodyId, in ShapeDefInternal def, in Segment segment);
    
    /// <summary>
    /// Creates a line segment shape and attaches it to this body
    /// </summary>
    /// <param name="def">The shape definition</param>
    /// <param name="segment">The segment</param>
    /// <returns>The shape</returns>
    /// <remarks>The shape definition and geometry are fully cloned. Contacts are not created until the next time step</remarks>
    public Shape CreateShape(ShapeDef def, in Segment segment) => b2CreateSegmentShape(this, def._internal, segment);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateCapsuleShape")]
    private static extern Shape b2CreateCapsuleShape(Body bodyId, in ShapeDefInternal def, in Capsule capsule);
    
    /// <summary>
    /// Creates a capsule shape and attaches it to this body
    /// </summary>
    /// <param name="def">The shape definition</param>
    /// <param name="capsule">The capsule</param>
    /// <returns>The shape</returns>
    /// <remarks>The shape definition and geometry are fully cloned. Contacts are not created until the next time step</remarks>
    public Shape CreateShape(ShapeDef def, in Capsule capsule) => b2CreateCapsuleShape(this, def._internal, capsule);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreatePolygonShape")]
    private static extern Shape b2CreatePolygonShape(Body bodyId, in ShapeDefInternal def, in Polygon polygon);
    
    /// <summary>
    /// Creates a polygon shape and attaches it to this body
    /// </summary>
    /// <param name="def">The shape definition</param>
    /// <param name="polygon">The polygon</param>
    /// <returns>The shape</returns>
    /// <remarks>The shape definition and geometry are fully cloned. Contacts are not created until the next time step</remarks>
    public Shape CreateShape(ShapeDef def, in Polygon polygon) => b2CreatePolygonShape(this, def._internal, polygon);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateChain")]
    private static extern ChainShape b2CreateChain(Body bodyId, in ChainDefInternal def);
    
    /// <summary>
    /// Creates a chain shape
    /// </summary>
    /// <param name="def">The chain definition</param>
    /// <returns>The chain shape</returns>
    public ChainShape CreateChain(ChainDef def) => b2CreateChain(this, def._internal);

}