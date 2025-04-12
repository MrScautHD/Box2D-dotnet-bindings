using System;
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
    public void Destroy()
    {
        nint userDataPtr = b2Joint_GetUserData(_id);
        Box2D.FreeHandle(userDataPtr);
        
        b2DestroyJoint(_id);
    }

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
    public JointType GetJointType() => b2Joint_GetType(_id);

    public JointType Type => GetJointType();

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
    public World World => b2Joint_GetWorld(_id);
    
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
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetCollideConnected")]
    private static extern bool b2Joint_GetCollideConnected(JointId jointId);
    
    public bool CollideConnected
    {
        get => b2Joint_GetCollideConnected(_id);
        set => b2Joint_SetCollideConnected(_id, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_SetUserData")]
    private static extern void b2Joint_SetUserData(JointId jointId, nint userData);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetUserData")]
    private static extern nint b2Joint_GetUserData(JointId jointId);
    
    /// <summary>
    /// The user data object for this joint.
    /// </summary>
    public object? UserData
    {
        get => Box2D.GetObjectAtPointer(b2Joint_GetUserData, _id);
        set => Box2D.SetObjectAtPointer(b2Joint_GetUserData, b2Joint_SetUserData, _id, value);
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