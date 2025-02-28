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
    
    /// <summary>
    /// Gets whether the revolute angular spring is enabled
    /// </summary>
    /// <returns>True if the spring is enabled</returns>
    public bool IsSpringEnabled() => b2RevoluteJoint_IsSpringEnabled(_id);

    public bool SpringEnabled
    {
        get => IsSpringEnabled();
        set => EnableSpring(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetSpringHertz")]
    private static extern void b2RevoluteJoint_SetSpringHertz(JointId jointId, float hertz);
    
    /// <summary>
    /// Sets the revolute joint spring stiffness in Hertz
    /// </summary>
    /// <param name="hertz">The spring stiffness in Hertz</param>
    public void SetSpringHertz(float hertz) => b2RevoluteJoint_SetSpringHertz(_id, hertz);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetSpringHertz")]
    private static extern float b2RevoluteJoint_GetSpringHertz(JointId jointId);
    
    /// <summary>
    /// Gets the revolute joint spring stiffness in Hertz
    /// </summary>
    /// <returns>The spring stiffness in Hertz</returns>
    public float GetSpringHertz() => b2RevoluteJoint_GetSpringHertz(_id);

    public float SpringHertz
    {
        get => GetSpringHertz();
        set => SetSpringHertz(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetSpringDampingRatio")]
    private static extern void b2RevoluteJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);
    
    /// <summary>
    /// Sets the revolute joint spring damping ratio, non-dimensional
    /// </summary>
    /// <param name="dampingRatio">The spring damping ratio, non-dimensional</param>
    public void SetSpringDampingRatio(float dampingRatio)
    {
        b2RevoluteJoint_SetSpringDampingRatio(_id, dampingRatio);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetSpringDampingRatio")]
    private static extern float b2RevoluteJoint_GetSpringDampingRatio(JointId jointId);
    
    /// <summary>
    /// Gets the revolute joint spring damping ratio, non-dimensional
    /// </summary>
    /// <returns>The spring damping ratio, non-dimensional</returns>
    public float GetSpringDampingRatio() => b2RevoluteJoint_GetSpringDampingRatio(_id);

    public float SpringDampingRatio
    {
        get => GetSpringDampingRatio();
        set => SetSpringDampingRatio(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetAngle")]
    private static extern float b2RevoluteJoint_GetAngle(JointId jointId);
    
    /// <summary>
    /// Gets the revolute joint current angle in radians relative to the reference angle
    /// </summary>
    /// <returns>The current angle in radians</returns>
    public float GetAngle() => b2RevoluteJoint_GetAngle(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_EnableLimit")]
    private static extern void b2RevoluteJoint_EnableLimit(JointId jointId, bool enableLimit);
    
    /// <summary>
    /// Enables/disables the revolute joint limit
    /// </summary>
    /// <param name="enableLimit">True to enable the limit, false to disable the limit</param>
    public void EnableLimit(bool enableLimit) => b2RevoluteJoint_EnableLimit(_id, enableLimit);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_IsLimitEnabled")]
    private static extern bool b2RevoluteJoint_IsLimitEnabled(JointId jointId);
    
    /// <summary>
    /// Gets whether the revolute joint limit is enabled
    /// </summary>
    /// <returns>True if the limit is enabled</returns>
    public bool IsLimitEnabled() => b2RevoluteJoint_IsLimitEnabled(_id);

    public bool LimitEnabled
    {
        get => IsLimitEnabled();
        set => EnableLimit(value);
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
    
    /// <summary>
    /// Gets the revolute joint lower limit in radians
    /// </summary>
    /// <returns>The lower limit in radians</returns>
    public float GetLowerLimit() => b2RevoluteJoint_GetLowerLimit(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetUpperLimit")]
    private static extern float b2RevoluteJoint_GetUpperLimit(JointId jointId);
    
    /// <summary>
    /// Gets the revolute joint upper limit in radians
    /// </summary>
    /// <returns>The upper limit in radians</returns>
    public float GetUpperLimit() => b2RevoluteJoint_GetUpperLimit(_id);

    public float LowerLimit => GetLowerLimit();
    public float UpperLimit => GetUpperLimit();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_EnableMotor")]
    private static extern void b2RevoluteJoint_EnableMotor(JointId jointId, bool enableMotor);
    
    /// <summary>
    /// Enables/disables the revolute joint motor
    /// </summary>
    /// <param name="enableMotor">True to enable the motor, false to disable the motor</param>
    public void EnableMotor(bool enableMotor) => b2RevoluteJoint_EnableMotor(_id, enableMotor);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_IsMotorEnabled")]
    private static extern bool b2RevoluteJoint_IsMotorEnabled(JointId jointId);
    
    /// <summary>
    /// Gets whether the revolute joint motor is enabled
    /// </summary>
    /// <returns>True if the motor is enabled</returns>
    public bool IsMotorEnabled() => b2RevoluteJoint_IsMotorEnabled(_id);

    public bool MotorEnabled
    {
        get => IsMotorEnabled();
        set => EnableMotor(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetMotorSpeed")]
    private static extern void b2RevoluteJoint_SetMotorSpeed(JointId jointId, float motorSpeed);
    
    /// <summary>
    /// Sets the revolute joint motor speed in radians per second
    /// </summary>
    /// <param name="motorSpeed">The motor speed in radians per second</param>
    public void SetMotorSpeed(float motorSpeed) => b2RevoluteJoint_SetMotorSpeed(_id, motorSpeed);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetMotorSpeed")]
    private static extern float b2RevoluteJoint_GetMotorSpeed(JointId jointId);
    
    /// <summary>
    /// Gets the revolute joint motor speed in radians per second
    /// </summary>
    /// <returns>The motor speed in radians per second</returns>
    public float GetMotorSpeed() => b2RevoluteJoint_GetMotorSpeed(_id);

    public float MotorSpeed
    {
        get => GetMotorSpeed();
        set => SetMotorSpeed(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetMotorTorque")]
    private static extern float b2RevoluteJoint_GetMotorTorque(JointId jointId);
    
    /// <summary>
    /// Gets the revolute joint current motor torque, usually in newton-meters
    /// </summary>
    /// <returns>The current motor torque, usually in newton-meters</returns>
    public float GetMotorTorque() => b2RevoluteJoint_GetMotorTorque(_id);

    public float MotorTorque => GetMotorTorque();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetMaxMotorTorque")]
    private static extern void b2RevoluteJoint_SetMaxMotorTorque(JointId jointId, float torque);
    
    /// <summary>
    /// Sets the revolute joint maximum motor torque, usually in newton-meters
    /// </summary>
    /// <param name="torque">The maximum motor torque, usually in newton-meters</param>
    public void SetMaxMotorTorque(float torque) => b2RevoluteJoint_SetMaxMotorTorque(_id, torque);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetMaxMotorTorque")]
    private static extern float b2RevoluteJoint_GetMaxMotorTorque(JointId jointId);
    
    /// <summary>
    /// Gets the revolute joint maximum motor torque, usually in newton-meters
    /// </summary>
    /// <returns>The maximum motor torque, usually in newton-meters</returns>
    public float GetMaxMotorTorque() => b2RevoluteJoint_GetMaxMotorTorque(_id);

    public float MaxMotorTorque
    {
        get => GetMaxMotorTorque();
        set => SetMaxMotorTorque(value);
    }
}