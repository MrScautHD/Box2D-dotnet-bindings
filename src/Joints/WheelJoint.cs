using System.Runtime.CompilerServices;
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
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_EnableSpring")]
    private static extern void b2WheelJoint_EnableSpring(JointId jointId, bool enableSpring);
    
    /// <summary>
    /// Enable/disable the wheel joint spring
    /// </summary>
    /// <param name="enableSpring">True to enable the spring, false to disable the spring</param>
    public void EnableSpring(bool enableSpring) => b2WheelJoint_EnableSpring(_id, enableSpring);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_IsSpringEnabled")]
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

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetSpringHertz")]
    private static extern void b2WheelJoint_SetSpringHertz(JointId jointId, float hertz);
    
    /// <summary>
    /// Set the wheel joint stiffness in Hertz
    /// </summary>
    /// <param name="hertz">The stiffness in Hertz</param>
    public void SetSpringHertz(float hertz) => b2WheelJoint_SetSpringHertz(_id, hertz);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetSpringHertz")]
    private static extern float b2WheelJoint_GetSpringHertz(JointId jointId);
    
    /// <summary>
    /// Get the wheel joint stiffness in Hertz
    /// </summary>
    /// <returns>The stiffness in Hertz</returns>
    public float GetSpringHertz() => b2WheelJoint_GetSpringHertz(_id);

    public float SpringHertz
    {
        get => GetSpringHertz();
        set => SetSpringHertz(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetSpringDampingRatio")]
    private static extern void b2WheelJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);
    
    /// <summary>
    /// Set the wheel joint damping ratio, non-dimensional
    /// </summary>
    /// <param name="dampingRatio">The damping ratio</param>
    public void SetSpringDampingRatio(float dampingRatio) => b2WheelJoint_SetSpringDampingRatio(_id, dampingRatio);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetSpringDampingRatio")]
    private static extern float b2WheelJoint_GetSpringDampingRatio(JointId jointId);
    
    /// <summary>
    /// Get the wheel joint damping ratio, non-dimensional
    /// </summary>
    /// <returns>The damping ratio</returns>
    public float GetSpringDampingRatio() => b2WheelJoint_GetSpringDampingRatio(_id);

    public float SpringDampingRatio
    {
        get => GetSpringDampingRatio();
        set => SetSpringDampingRatio(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_EnableLimit")]
    private static extern void b2WheelJoint_EnableLimit(JointId jointId, bool enableLimit);
    
    /// <summary>
    /// Enables/disables the wheel joint limit
    /// </summary>
    /// <param name="enableLimit">True to enable the limit, false to disable the limit</param>
    public void EnableLimit(bool enableLimit) => b2WheelJoint_EnableLimit(_id, enableLimit);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_IsLimitEnabled")]
    private static extern bool b2WheelJoint_IsLimitEnabled(JointId jointId);
    
    /// <summary>
    /// Gets whether the wheel joint limit is enabled
    /// </summary>
    /// <returns>True if the limit is enabled</returns>
    public bool IsLimitEnabled() => b2WheelJoint_IsLimitEnabled(_id);

    public bool LimitEnabled
    {
        get => IsLimitEnabled();
        set => EnableLimit(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetLimits")]
    private static extern void b2WheelJoint_SetLimits(JointId jointId, float lower, float upper);
    
    /// <summary>
    /// Set the wheel joint limits
    /// </summary>
    /// <param name="lower">The lower limit</param>
    /// <param name="upper">The upper limit</param>
    public void SetLimits(float lower, float upper) => b2WheelJoint_SetLimits(_id, lower, upper);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetLowerLimit")]
    private static extern float b2WheelJoint_GetLowerLimit(JointId jointId);
    
    /// <summary>
    /// Get the lower wheel joint limit
    /// </summary>
    /// <returns>The lower limit</returns>
    public float GetLowerLimit() => b2WheelJoint_GetLowerLimit(_id);

    public float LowerLimit => GetLowerLimit();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetUpperLimit")]
    private static extern float b2WheelJoint_GetUpperLimit(JointId jointId);
    
    /// <summary>
    /// Get the upper wheel joint limit
    /// </summary>
    /// <returns>The upper limit</returns>
    public float GetUpperLimit() => b2WheelJoint_GetUpperLimit(_id);

    public float UpperLimit => GetUpperLimit();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_EnableMotor")]
    private static extern void b2WheelJoint_EnableMotor(JointId jointId, bool enableMotor);
    
    /// <summary>
    /// Enable/disable the wheel joint motor
    /// </summary>
    /// <param name="enableMotor">True to enable the motor, false to disable the motor</param>
    public void EnableMotor(bool enableMotor) => b2WheelJoint_EnableMotor(_id, enableMotor);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_IsMotorEnabled")]
    private static extern bool b2WheelJoint_IsMotorEnabled(JointId jointId);
    
    /// <summary>
    /// Gets whether the wheel joint motor is enabled
    /// </summary>
    /// <returns>True if the motor is enabled</returns>
    public bool IsMotorEnabled() => b2WheelJoint_IsMotorEnabled(_id);

    public bool MotorEnabled
    {
        get => IsMotorEnabled();
        set => EnableMotor(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetMotorSpeed")]
    private static extern void b2WheelJoint_SetMotorSpeed(JointId jointId, float motorSpeed);
    
    /// <summary>
    /// Set the wheel joint motor speed in radians per second
    /// </summary>
    /// <param name="motorSpeed">The motor speed in radians per second</param>
    public void SetMotorSpeed(float motorSpeed) => b2WheelJoint_SetMotorSpeed(_id, motorSpeed);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetMotorSpeed")]
    private static extern float b2WheelJoint_GetMotorSpeed(JointId jointId);
    
    /// <summary>
    /// Get the wheel joint motor speed in radians per second
    /// </summary>
    /// <returns>The motor speed in radians per second</returns>
    public float GetMotorSpeed() => b2WheelJoint_GetMotorSpeed(_id);

    public float MotorSpeed
    {
        get => GetMotorSpeed();
        set => SetMotorSpeed(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetMaxMotorTorque")]
    private static extern void b2WheelJoint_SetMaxMotorTorque(JointId jointId, float torque);
    
    /// <summary>
    /// Set the wheel joint maximum motor torque, usually in newton-meters
    /// </summary>
    /// <param name="torque">The maximum motor torque</param>
    public void SetMaxMotorTorque(float torque) => b2WheelJoint_SetMaxMotorTorque(_id, torque);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetMaxMotorTorque")]
    private static extern float b2WheelJoint_GetMaxMotorTorque(JointId jointId);
    
    /// <summary>
    /// Get the wheel joint maximum motor torque, usually in newton-meters
    /// </summary>
    /// <returns>The maximum motor torque</returns>
    public float GetMaxMotorTorque() => b2WheelJoint_GetMaxMotorTorque(_id);

    public float MaxMotorTorque
    {
        get => GetMaxMotorTorque();
        set => SetMaxMotorTorque(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetMotorTorque")]
    private static extern float b2WheelJoint_GetMotorTorque(JointId jointId);
    
    /// <summary>
    /// Get the current wheel joint motor torque, usually in newton-meters
    /// </summary>
    /// <returns>The current motor torque</returns>
    public float GetMotorTorque() => b2WheelJoint_GetMotorTorque(_id);

    public float MotorTorque => GetMotorTorque();
}