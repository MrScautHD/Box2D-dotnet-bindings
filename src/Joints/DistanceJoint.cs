using System.Runtime.InteropServices;

namespace Box2D;

public class DistanceJoint : Joint
{
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetLength")]
    private static extern void b2DistanceJoint_SetLength(JointId jointId, float length);
    
    /// <summary>
    /// Sets the rest length of this distance joint
    /// </summary>
    /// <param name="length">The new distance joint length</param>
    public void SetLength(float length)
    {
        b2DistanceJoint_SetLength(_id, length);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetLength")]
    private static extern float b2DistanceJoint_GetLength(JointId jointId);
    
    /// <summary>
    /// Gets the rest length of this distance joint
    /// </summary>
    /// <returns>The rest length of this distance joint</returns>
    public float GetLength()
    {
        return b2DistanceJoint_GetLength(_id);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_EnableSpring")]
    private static extern void b2DistanceJoint_EnableSpring(JointId jointId, bool enableSpring);
    
    /// <summary>
    /// Enables/disables the spring on this distance joint
    /// </summary>
    /// <param name="enableSpring">True to enable the spring, false to disable the spring</param>
    public void EnableSpring(bool enableSpring)
    {
        b2DistanceJoint_EnableSpring(_id, enableSpring);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsSpringEnabled")]
    private static extern bool b2DistanceJoint_IsSpringEnabled(JointId jointId);
    
    /// <summary>
    /// Checks if the spring is enabled on this distance joint
    /// </summary>
    /// <returns>True if the spring is enabled</returns>
    public bool IsSpringEnabled() => b2DistanceJoint_IsSpringEnabled(_id);

    public bool SpringEnabled
    {
        get => IsSpringEnabled();
        set => EnableSpring(value);
    }

    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetSpringHertz")]
    private static extern void b2DistanceJoint_SetSpringHertz(JointId jointId, float hertz);
    
    /// <summary>
    /// Sets the spring stiffness in Hertz on this distance joint
    /// </summary>
    /// <param name="hertz">The spring stiffness in Hertz</param>
    public void SetSpringHertz(float hertz) => b2DistanceJoint_SetSpringHertz(_id, hertz);


    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetSpringHertz")]
    private static extern float b2DistanceJoint_GetSpringHertz(JointId jointId);
    
    /// <summary>
    /// Gets the spring stiffness in Hertz on this distance joint
    /// </summary>
    /// <returns>The spring stiffness in Hertz</returns>
    public float GetSpringHertz() => b2DistanceJoint_GetSpringHertz(_id);

    public float SpringHertz
    {
        get => GetSpringHertz();
        set => SetSpringHertz(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetSpringDampingRatio")]
    private static extern void b2DistanceJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);
    
    /// <summary>
    /// Sets the spring damping ratio on this distance joint
    /// </summary>
    /// <param name="dampingRatio">The spring damping ratio, non-dimensional</param>
    public void SetSpringDampingRatio(float dampingRatio) => b2DistanceJoint_SetSpringDampingRatio(_id, dampingRatio);


    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetSpringDampingRatio")]
    private static extern float b2DistanceJoint_GetSpringDampingRatio(JointId jointId);
    
    /// <summary>
    /// Gets the spring damping ratio on this distance joint
    /// </summary>
    /// <returns>The spring damping ratio</returns>
    public float GetSpringDampingRatio() => b2DistanceJoint_GetSpringDampingRatio(_id);

    public float SpringDampingRatio
    {
        get => GetSpringDampingRatio();
        set => SetSpringDampingRatio(value);
    }
    
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_EnableLimit")]
    private static extern void b2DistanceJoint_EnableLimit(JointId jointId, bool enableLimit);
    
    /// <summary>
    /// Enables/disables the limit on this distance joint
    /// </summary>
    /// <param name="enableLimit">True to enable the limit, false to disable the limit</param>
    /// <remarks>The limit only works if the joint spring is enabled. Otherwise the joint is rigid and the limit has no effect</remarks>
    public void EnableLimit(bool enableLimit) => b2DistanceJoint_EnableLimit(_id, enableLimit);


    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsLimitEnabled")]
    private static extern bool b2DistanceJoint_IsLimitEnabled(JointId jointId);
    
    /// <summary>
    /// Checks if the limit is enabled on this distance joint
    /// </summary>
    /// <returns>True if the limit is enabled</returns>
    /// <remarks>The limit only works if the joint spring is enabled. Otherwise the joint is rigid and the limit has no effect</remarks>
    public bool IsLimitEnabled() => b2DistanceJoint_IsLimitEnabled(_id);

    public bool LimitEnabled
    {
        get => IsLimitEnabled();
        set => EnableLimit(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetLengthRange")]
    private static extern void b2DistanceJoint_SetLengthRange(JointId jointId, float minLength, float maxLength);
    
    /// <summary>
    /// Sets the minimum and maximum length parameters on this distance joint
    /// </summary>
    /// <param name="minLength">The minimum length</param>
    /// <param name="maxLength">The maximum length</param>
    public void SetLengthRange(float minLength, float maxLength) => b2DistanceJoint_SetLengthRange(_id, minLength, maxLength);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMinLength")]
    private static extern float b2DistanceJoint_GetMinLength(JointId jointId);
    
    /// <summary>
    /// Gets the minimum length of this distance joint
    /// </summary>
    /// <returns>The minimum length</returns>
    public float GetMinLength() => b2DistanceJoint_GetMinLength(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMaxLength")]
    private static extern float b2DistanceJoint_GetMaxLength(JointId jointId);
    
    /// <summary>
    /// Gets the maximum length of this distance joint
    /// </summary>
    /// <returns>The maximum length</returns>
    public float GetMaxLength() => b2DistanceJoint_GetMaxLength(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetCurrentLength")]
    private static extern float b2DistanceJoint_GetCurrentLength(JointId jointId);
    
    /// <summary>
    /// Gets the current length of this distance joint
    /// </summary>
    /// <returns>The current length</returns>
    public float GetCurrentLength() => b2DistanceJoint_GetCurrentLength(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_EnableMotor")]
    private static extern void b2DistanceJoint_EnableMotor(JointId jointId, bool enableMotor);
    
    /// <summary>
    /// Enables/disables the motor on this distance joint
    /// </summary>
    /// <param name="enableMotor">True to enable the motor, false to disable the motor</param>
    public void EnableMotor(bool enableMotor) => b2DistanceJoint_EnableMotor(_id, enableMotor);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsMotorEnabled")]
    private static extern bool b2DistanceJoint_IsMotorEnabled(JointId jointId);
    
    /// <summary>
    /// Checks if the motor is enabled on this distance joint
    /// </summary>
    /// <returns>True if the motor is enabled</returns>
    public bool IsMotorEnabled() => b2DistanceJoint_IsMotorEnabled(_id);

    public bool MotorEnabled
    {
        get => IsMotorEnabled();
        set => EnableMotor(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetMotorSpeed")]
    private static extern void b2DistanceJoint_SetMotorSpeed(JointId jointId, float motorSpeed);
    
    /// <summary>
    /// Sets the motor speed on this distance joint
    /// </summary>
    /// <param name="motorSpeed">The motor speed, usually in meters per second</param>
    public void SetMotorSpeed(float motorSpeed) => b2DistanceJoint_SetMotorSpeed(_id, motorSpeed);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMotorSpeed")]
    private static extern float b2DistanceJoint_GetMotorSpeed(JointId jointId);
    
    /// <summary>
    /// Gets the motor speed on this distance joint
    /// </summary>
    /// <returns>The motor speed, usually in meters per second</returns>
    public float GetMotorSpeed() => b2DistanceJoint_GetMotorSpeed(_id);

    public float MotorSpeed
    {
        get => GetMotorSpeed();
        set => SetMotorSpeed(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetMaxMotorForce")]
    private static extern void b2DistanceJoint_SetMaxMotorForce(JointId jointId, float force);
    
    /// <summary>
    /// Sets the maximum motor force on this distance joint
    /// </summary>
    /// <param name="force">The maximum motor force, usually in Newtons</param>
    public void SetMaxMotorForce(float force) => b2DistanceJoint_SetMaxMotorForce(_id, force);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMaxMotorForce")]
    private static extern float b2DistanceJoint_GetMaxMotorForce(JointId jointId);
    
    /// <summary>
    /// Gets the maximum motor force on this distance joint
    /// </summary>
    /// <returns>The maximum motor force, usually in Newtons</returns>
    public float GetMaxMotorForce() => b2DistanceJoint_GetMaxMotorForce(_id);

    public float MaxMotorForce
    {
        get => GetMaxMotorForce();
        set => SetMaxMotorForce(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMotorForce")]
    private static extern float b2DistanceJoint_GetMotorForce(JointId jointId);
    
    /// <summary>
    /// Gets the current motor force on this distance joint
    /// </summary>
    /// <returns>The current motor force, usually in Newtons</returns>
    public float GetMotorForce() => b2DistanceJoint_GetMotorForce(_id);
}