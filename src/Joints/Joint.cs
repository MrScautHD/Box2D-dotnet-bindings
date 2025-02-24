using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Joints allow you to connect rigid bodies together while allowing various forms of relative motions.
/// </summary>
public class Joint
{
	internal JointId _id;
    
    internal Joint(JointId id)
    {
        _id = id;
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyJoint")]
    private static extern void b2DestroyJoint(JointId jointId);
    
    /// <summary>
    /// Destroys this joint
    /// </summary>
    public void Destroy() => b2DestroyJoint(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_IsValid")]
    private static extern bool b2Joint_IsValid(JointId jointId);
    
    /// <summary>
    /// Checks if this joint is valid
    /// </summary>
    /// <returns>true if this joint is valid</returns>
    /// <remarks>Provides validation for up to 64K allocations</remarks>
    public bool IsValid() => b2Joint_IsValid(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetType")]
    private static extern JointType b2Joint_GetType(JointId jointId);
    
    /// <summary>
    /// Gets the joint type
    /// </summary>
    /// <returns>The joint type</returns>
    public JointType GetType() => b2Joint_GetType(_id);

    public JointType Type => GetType();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetBodyA")]
    private static extern Body b2Joint_GetBodyA(JointId jointId);

    /// <summary>
    /// Gets body A on this joint
    /// </summary>
    /// <returns>The body A on this joint</returns>
    public Body GetBodyA() => b2Joint_GetBodyA(_id);

    public Body BodyA => GetBodyA();
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetBodyB")]
    private static extern Body b2Joint_GetBodyB(JointId jointId);
    
    /// <summary>
    /// Gets body B on this joint
    /// </summary>
    /// <returns>The body B on this joint</returns>
    public Body GetBodyB() => b2Joint_GetBodyB(_id);

    public Body BodyB => GetBodyB();
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetWorld")]
    private static extern World b2Joint_GetWorld(JointId jointId);
    
    /// <summary>
    /// Gets the world that owns this joint
    /// </summary>
    /// <returns>The world that owns this joint</returns>
    public World GetWorld() => b2Joint_GetWorld(_id);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetLocalAnchorA")]
    private static extern Vec2 b2Joint_GetLocalAnchorA(JointId jointId);
    
    /// <summary>
    /// Gets the local anchor on body A
    /// </summary>
    /// <returns>The local anchor on body A</returns>
    public Vec2 GetLocalAnchorA() => b2Joint_GetLocalAnchorA(_id);

    public Vec2 LocalAnchorA => GetLocalAnchorA();
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetLocalAnchorB")]
    private static extern Vec2 b2Joint_GetLocalAnchorB(JointId jointId);
    
    /// <summary>
    /// Gets the local anchor on body B
    /// </summary>
    /// <returns>The local anchor on body B</returns>
    public Vec2 GetLocalAnchorB() => b2Joint_GetLocalAnchorB(_id);

    public Vec2 LocalAnchorB => GetLocalAnchorB();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_SetCollideConnected")]
    private static extern void b2Joint_SetCollideConnected(JointId jointId, bool shouldCollide);
    
    /// <summary>
    /// Toggles collision between connected bodies
    /// </summary>
    /// <param name="shouldCollide">Option to toggle collision between connected bodies</param>
    public void SetCollideConnected(bool shouldCollide) => b2Joint_SetCollideConnected(_id, shouldCollide);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetCollideConnected")]
    private static extern bool b2Joint_GetCollideConnected(JointId jointId);
    
    /// <summary>
    /// Checks if collision is allowed between connected bodies
    /// </summary>
    /// <returns>true if collision is allowed between connected bodies</returns>
    public bool GetCollideConnected() => b2Joint_GetCollideConnected(_id);

    public bool CollideConnected
    {
        get => GetCollideConnected();
        set => SetCollideConnected(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_SetUserData")]
    private static extern void b2Joint_SetUserData(JointId jointId, nint userData);

    /// <summary>
    /// Sets the user data on this joint
    /// </summary>
    /// <param name="userData">The user data</param>
    public void SetUserData<T>(ref T userData)
    {
        GCHandle handle = GCHandle.Alloc(userData);
        nint userDataPtr = GCHandle.ToIntPtr(handle);
        b2Joint_SetUserData(_id, userDataPtr);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetUserData")]
    private static extern nint b2Joint_GetUserData(JointId jointId);
    
    /// <summary>
    /// Gets the user data on this joint
    /// </summary>
    /// <returns>The user data on this joint</returns>
    public T? GetUserData<T>()
    {
        nint userDataPtr = b2Joint_GetUserData(_id);
        if (userDataPtr == 0) return default;
        GCHandle handle = GCHandle.FromIntPtr(userDataPtr);
        if (!handle.IsAllocated) return default;
        T? userData = (T?)handle.Target;
        return userData;
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_WakeBodies")]
    private static extern void b2Joint_WakeBodies(JointId jointId);
    
    /// <summary>
    /// Wakes the bodies connected to this joint
    /// </summary>
    public void WakeBodies() => b2Joint_WakeBodies(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetConstraintForce")]
    private static extern Vec2 b2Joint_GetConstraintForce(JointId jointId);
    
    /// <summary>
    /// Gets the current constraint force for this joint
    /// </summary>
    /// <returns>The current constraint force for this joint</returns>
    /// <remarks>Usually in Newtons</remarks>
    public Vec2 GetConstraintForce() => b2Joint_GetConstraintForce(_id);

    public Vec2 ConstraintForce => GetConstraintForce();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetConstraintTorque")]
    private static extern float b2Joint_GetConstraintTorque(JointId jointId);
    
    /// <summary>
    /// Gets the current constraint torque for this joint
    /// </summary>
    /// <returns>The current constraint torque for this joint</returns>
    /// <remarks>Usually in Newton * meters</remarks>
    public float GetConstraintTorque() => b2Joint_GetConstraintTorque(_id);

    public float ConstraintTorque => GetConstraintTorque();
}