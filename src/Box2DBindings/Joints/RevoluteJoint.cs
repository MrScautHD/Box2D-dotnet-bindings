using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A revolute joint allows for relative rotation in the 2D plane with no relative translation.
///
/// The revolute joint is probably the most common joint. It can be used for ragdolls and chains.
/// Also called a <i>hinge</i> or <i>pin</i> joint.
/// </summary>
public class RevoluteJoint : Joint
{
    internal RevoluteJoint(JointId id) : base(id)
    { }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_EnableSpring")]
    private static extern void b2RevoluteJoint_EnableSpring(JointId jointId, bool enableSpring);
    
    /// <summary>
    /// Enables/disables the revolute joint spring
    /// </summary>
    /// <param name="enableSpring">True to enable the spring, false to disable the spring</param>
    public void EnableSpring(bool enableSpring) => b2RevoluteJoint_EnableSpring(_id, enableSpring);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_IsSpringEnabled")]
    private static extern bool b2RevoluteJoint_IsSpringEnabled(JointId jointId);
    
    public bool SpringEnabled
    {
        get => b2RevoluteJoint_IsSpringEnabled(_id);
        set => EnableSpring(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetSpringHertz")]
    private static extern void b2RevoluteJoint_SetSpringHertz(JointId jointId, float hertz);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetSpringHertz")]
    private static extern float b2RevoluteJoint_GetSpringHertz(JointId jointId);

    /// <summary>
    /// The revolute joint spring stiffness in Hertz
    /// </summary>
    public float SpringHertz
    {
        get => b2RevoluteJoint_GetSpringHertz(_id);
        set => b2RevoluteJoint_SetSpringHertz(_id, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetSpringDampingRatio")]
    private static extern void b2RevoluteJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetSpringDampingRatio")]
    private static extern float b2RevoluteJoint_GetSpringDampingRatio(JointId jointId);
    
    /// <summary>
    /// The revolute joint spring damping ratio
    /// </summary>
    public float SpringDampingRatio
    {
        get => b2RevoluteJoint_GetSpringDampingRatio(_id);
        set => b2RevoluteJoint_SetSpringDampingRatio(_id, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetAngle")]
    private static extern float b2RevoluteJoint_GetAngle(JointId jointId);
    
    /// <summary>
    /// The current joint angle in radians
    /// </summary>
    public float Angle => b2RevoluteJoint_GetAngle(_id);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_EnableLimit")]
    private static extern void b2RevoluteJoint_EnableLimit(JointId jointId, bool enableLimit);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_IsLimitEnabled")]
    private static extern bool b2RevoluteJoint_IsLimitEnabled(JointId jointId);
    
    /// <summary>
    /// The revolute joint limit enabled state
    /// </summary>
    public bool LimitEnabled
    {
        get => b2RevoluteJoint_IsLimitEnabled(_id);
        set => b2RevoluteJoint_EnableLimit(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetLimits")]
    private static extern void b2RevoluteJoint_SetLimits(JointId jointId, float lower, float upper);
    
    /// <summary>
    /// Sets the revolute joint limits in radians
    /// </summary>
    /// <param name="lower">The lower limit in radians</param>
    /// <param name="upper">The upper limit in radians</param>
    public void SetLimits(float lower, float upper) => b2RevoluteJoint_SetLimits(_id, lower, upper);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetLowerLimit")]
    private static extern float b2RevoluteJoint_GetLowerLimit(JointId jointId);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetUpperLimit")]
    private static extern float b2RevoluteJoint_GetUpperLimit(JointId jointId);
    
    /// <summary>
    /// The lower joint limit of this revolute joint in radians
    /// </summary>
    public float LowerLimit => b2RevoluteJoint_GetLowerLimit(_id);
    /// <summary>
    /// The upper joint limit of this revolute joint in radians
    /// </summary>
    public float UpperLimit => b2RevoluteJoint_GetUpperLimit(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_EnableMotor")]
    private static extern void b2RevoluteJoint_EnableMotor(JointId jointId, bool enableMotor);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_IsMotorEnabled")]
    private static extern bool b2RevoluteJoint_IsMotorEnabled(JointId jointId);
    
    /// <summary>
    /// The revolute joint motor enabled state
    /// </summary>
    public bool MotorEnabled
    {
        get => b2RevoluteJoint_IsMotorEnabled(_id);
        set => b2RevoluteJoint_EnableMotor(_id, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetMotorSpeed")]
    private static extern void b2RevoluteJoint_SetMotorSpeed(JointId jointId, float motorSpeed);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetMotorSpeed")]
    private static extern float b2RevoluteJoint_GetMotorSpeed(JointId jointId);
    
    /// <summary>
    /// The revolute joint motor speed in radians per second
    /// </summary>
    public float MotorSpeed
    {
        get => b2RevoluteJoint_GetMotorSpeed(_id);
        set => b2RevoluteJoint_SetMotorSpeed(_id, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetMotorTorque")]
    private static extern float b2RevoluteJoint_GetMotorTorque(JointId jointId);
    
    /// <summary>
    /// The revolute joint current motor torque, usually in newton-meters
    /// </summary>
    public float MotorTorque => b2RevoluteJoint_GetMotorTorque(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetMaxMotorTorque")]
    private static extern void b2RevoluteJoint_SetMaxMotorTorque(JointId jointId, float torque);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetMaxMotorTorque")]
    private static extern float b2RevoluteJoint_GetMaxMotorTorque(JointId jointId);
    
    /// <summary>
    /// The revolute joint maximum motor torque, usually in newton-meters
    /// </summary>
    public float MaxMotorTorque
    {
        get => b2RevoluteJoint_GetMaxMotorTorque(_id);
        set => b2RevoluteJoint_SetMaxMotorTorque(_id, value);
    }
}