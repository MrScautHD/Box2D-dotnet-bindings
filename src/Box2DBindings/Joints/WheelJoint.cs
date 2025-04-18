using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// The wheel joint can be used to simulate wheels on vehicles.
///
/// The wheel joint restricts body B to move along a local axis in body A. Body B is free to
/// rotate. Supports a linear spring, linear limits, and a rotational motor.
/// </summary>
public class WheelJoint : Joint
{
    internal WheelJoint(JointId id) : base(id)
    { }
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_EnableSpring")]
    private static extern void b2WheelJoint_EnableSpring(JointId jointId, bool enableSpring);
    
    /// <summary>
    /// Enable/disable the wheel joint spring
    /// </summary>
    /// <param name="enableSpring">True to enable the spring, false to disable the spring</param>
    public void EnableSpring(bool enableSpring) => b2WheelJoint_EnableSpring(_id, enableSpring);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_IsSpringEnabled")]
    private static extern bool b2WheelJoint_IsSpringEnabled(JointId jointId);
    
    /// <summary>
    /// Gets whether the wheel joint spring is enabled
    /// </summary>
    /// <returns>True if the spring is enabled</returns>
    public bool IsSpringEnabled() => b2WheelJoint_IsSpringEnabled(_id);

    public bool SpringEnabled
    {
        get => IsSpringEnabled();
        set => EnableSpring(value);
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetSpringHertz")]
    private static extern void b2WheelJoint_SetSpringHertz(JointId jointId, float hertz);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetSpringHertz")]
    private static extern float b2WheelJoint_GetSpringHertz(JointId jointId);
    
    /// <summary>
    /// Set the wheel joint spring frequency in hertz
    /// </summary>
    public float SpringHertz
    {
        get => b2WheelJoint_GetSpringHertz(_id);
        set => b2WheelJoint_SetSpringHertz(_id, value);
    }
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetSpringDampingRatio")]
    private static extern void b2WheelJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetSpringDampingRatio")]
    private static extern float b2WheelJoint_GetSpringDampingRatio(JointId jointId);
    
    /// <summary>
    /// The wheel joint damping ratio, non-dimensional
    /// </summary>
    public float SpringDampingRatio
    {
        get => b2WheelJoint_GetSpringDampingRatio(_id);
        set => b2WheelJoint_SetSpringDampingRatio(_id, value);
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_EnableLimit")]
    private static extern void b2WheelJoint_EnableLimit(JointId jointId, bool enableLimit);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_IsLimitEnabled")]
    private static extern bool b2WheelJoint_IsLimitEnabled(JointId jointId);
    
    /// <summary>
    /// The wheel joint limit enabled flag
    /// </summary>
    public bool LimitEnabled
    {
        get => b2WheelJoint_IsLimitEnabled(_id);
        set => b2WheelJoint_EnableLimit(_id, value);
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetLimits")]
    private static extern void b2WheelJoint_SetLimits(JointId jointId, float lower, float upper);
    
    /// <summary>
    /// Set the wheel joint limits
    /// </summary>
    /// <param name="lower">The lower limit</param>
    /// <param name="upper">The upper limit</param>
    public void SetLimits(float lower, float upper) => b2WheelJoint_SetLimits(_id, lower, upper);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetLowerLimit")]
    private static extern float b2WheelJoint_GetLowerLimit(JointId jointId);
    
    /// <summary>
    /// The lower wheel joint limit
    /// </summary>
    public float LowerLimit => b2WheelJoint_GetLowerLimit(_id);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetUpperLimit")]
    private static extern float b2WheelJoint_GetUpperLimit(JointId jointId);
    
    /// <summary>
    /// The upper wheel joint limit
    /// </summary>
    public float UpperLimit => b2WheelJoint_GetUpperLimit(_id);

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_EnableMotor")]
    private static extern void b2WheelJoint_EnableMotor(JointId jointId, bool enableMotor);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_IsMotorEnabled")]
    private static extern bool b2WheelJoint_IsMotorEnabled(JointId jointId);
    
    /// <summary>
    /// The wheel joint motor enabled flag
    /// </summary>
    public bool MotorEnabled
    {
        get => b2WheelJoint_IsMotorEnabled(_id);
        set => b2WheelJoint_EnableMotor(_id, value);
    }
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetMotorSpeed")]
    private static extern void b2WheelJoint_SetMotorSpeed(JointId jointId, float motorSpeed);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetMotorSpeed")]
    private static extern float b2WheelJoint_GetMotorSpeed(JointId jointId);
    
    /// <summary>
    /// The wheel joint motor speed in radians per second
    /// </summary>
    public float MotorSpeed
    {
        get => b2WheelJoint_GetMotorSpeed(_id);
        set => b2WheelJoint_SetMotorSpeed(_id, value);
    }
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetMaxMotorTorque")]
    private static extern void b2WheelJoint_SetMaxMotorTorque(JointId jointId, float torque);
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetMaxMotorTorque")]
    private static extern float b2WheelJoint_GetMaxMotorTorque(JointId jointId);
    
    /// <summary>
    /// The wheel joint maximum motor torque, usually in newton-meters
    /// </summary>
    public float MaxMotorTorque
    {
        get => b2WheelJoint_GetMaxMotorTorque(_id);
        set => b2WheelJoint_SetMaxMotorTorque(_id, value);
    }
    
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetMotorTorque")]
    private static extern float b2WheelJoint_GetMotorTorque(JointId jointId);
    
    /// <summary>
    /// The current wheel joint motor torque, usually in newton-meters
    /// </summary>
    public float MotorTorque => b2WheelJoint_GetMotorTorque(_id);
}