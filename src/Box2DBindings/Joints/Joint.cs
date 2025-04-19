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
    
    internal static Joint GetJoint(JointId id)
    {
        JointType t = b2Joint_GetType(id);
        switch (t)
        {
            case JointType.Distance:
                return new DistanceJoint(id);
            case JointType.Motor:
                return new MotorJoint(id);
            case JointType.Mouse:
                return new MouseJoint(id);
            case JointType.Prismatic:
                return new PrismaticJoint(id);
            case JointType.Revolute:
                return new RevoluteJoint(id);
            case JointType.Weld:
                return new WeldJoint(id);
            case JointType.Wheel:
                return new WheelJoint(id);
            case JointType.Filter:
                return new Joint(id);
            default:
                throw new NotSupportedException($"Joint type {t} is not supported");
            
        }
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyJoint")]
    private static extern void b2DestroyJoint(JointId jointId);
    
    /// <summary>
    /// Destroys this joint
    /// </summary>
    public void Destroy()
    {
        nint userDataPtr = b2Joint_GetUserData(_id);
        Core.FreeHandle(ref userDataPtr);
        b2Joint_SetUserData(_id, 0);
        
        b2DestroyJoint(_id);
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_IsValid")]
    private static extern bool b2Joint_IsValid(JointId jointId);
    
    /// <summary>
    /// Checks if this joint is valid
    /// </summary>
    /// <returns>true if this joint is valid</returns>
    /// <remarks>Provides validation for up to 64K allocations</remarks>
    public bool Valid => b2Joint_IsValid(_id);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetType")]
    private static extern JointType b2Joint_GetType(JointId jointId);
    
    /// <summary>
    /// Gets the joint type
    /// </summary>
    /// <returns>The joint type</returns>
    public JointType Type => b2Joint_GetType(_id);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetBodyA")]
    private static extern Body b2Joint_GetBodyA(JointId jointId);

    /// <summary>
    /// Gets body A on this joint
    /// </summary>
    /// <returns>The body A on this joint</returns>
    public Body BodyA => b2Joint_GetBodyA(_id);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetBodyB")]
    private static extern Body b2Joint_GetBodyB(JointId jointId);
    
    /// <summary>
    /// Gets body B on this joint
    /// </summary>
    /// <returns>The body B on this joint</returns>
    public Body BodyB => b2Joint_GetBodyB(_id);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetWorld")]
    private static extern World b2Joint_GetWorld(JointId jointId);
    
    /// <summary>
    /// Gets the world that owns this joint
    /// </summary>
    public World World => b2Joint_GetWorld(_id);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetLocalAnchorA")]
    private static extern Vec2 b2Joint_GetLocalAnchorA(JointId jointId);
    
    /// <summary>
    /// Gets the local anchor on body A
    /// </summary>
    /// <returns>The local anchor on body A</returns>
    public Vec2 LocalAnchorA => b2Joint_GetLocalAnchorA(_id);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetLocalAnchorB")]
    private static extern Vec2 b2Joint_GetLocalAnchorB(JointId jointId);
    
    /// <summary>
    /// Gets the local anchor on body B
    /// </summary>
    /// <returns>The local anchor on body B</returns>
    public Vec2 LocalAnchorB => b2Joint_GetLocalAnchorB(_id);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_SetCollideConnected")]
    private static extern void b2Joint_SetCollideConnected(JointId jointId, bool shouldCollide);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetCollideConnected")]
    private static extern bool b2Joint_GetCollideConnected(JointId jointId);
    
    public bool CollideConnected
    {
        get => b2Joint_GetCollideConnected(_id);
        set => b2Joint_SetCollideConnected(_id, value);
    }
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_SetUserData")]
    private static extern void b2Joint_SetUserData(JointId jointId, nint userData);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetUserData")]
    private static extern nint b2Joint_GetUserData(JointId jointId);
    
    /// <summary>
    /// The user data object for this joint.
    /// </summary>
    public object? UserData
    {
        get => Core.GetObjectAtPointer(b2Joint_GetUserData, _id);
        set => Core.SetObjectAtPointer(b2Joint_GetUserData, b2Joint_SetUserData, _id, value);
    }
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_WakeBodies")]
    private static extern void b2Joint_WakeBodies(JointId jointId);
    
    /// <summary>
    /// Wakes the bodies connected to this joint
    /// </summary>
    public void WakeBodies() => b2Joint_WakeBodies(_id);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetConstraintForce")]
    private static extern Vec2 b2Joint_GetConstraintForce(JointId jointId);
    
    /// <summary>
    /// Gets the current constraint force for this joint
    /// </summary>
    /// <returns>The current constraint force for this joint</returns>
    /// <remarks>Usually in Newtons</remarks>
    public Vec2 ConstraintForce => b2Joint_GetConstraintForce(_id);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetConstraintTorque")]
    private static extern float b2Joint_GetConstraintTorque(JointId jointId);
    
    /// <summary>
    /// Gets the current constraint torque for this joint
    /// </summary>
    /// <returns>The current constraint torque for this joint</returns>
    /// <remarks>Usually in Newton * meters</remarks>
    public float ConstraintTorque => b2Joint_GetConstraintTorque(_id);
}