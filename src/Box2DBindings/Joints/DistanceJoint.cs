using System.Runtime.InteropServices;

namespace Box2D;

public class DistanceJoint : Joint
{
    internal DistanceJoint(JointId id) : base(id)
    { }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetLength")]
    private static extern void b2DistanceJoint_SetLength(JointId jointId, float length);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetLength")]
    private static extern float b2DistanceJoint_GetLength(JointId jointId);
    
    /// <summary>
    /// The rest length of this distance joint
    /// </summary>
    public float Length
    {
        get => b2DistanceJoint_GetLength(_id);
        set => b2DistanceJoint_SetLength(_id, value);
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
    
#if BOX2D_300
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetHertz")]
#else    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetSpringHertz")]
#endif
    private static extern float b2DistanceJoint_GetSpringHertz(JointId jointId);
    
    /// <summary>
    /// The spring stiffness in Hertz on this distance joint
    /// </summary>
    public float SpringHertz
    {
        get => b2DistanceJoint_GetSpringHertz(_id);
        set => b2DistanceJoint_SetSpringHertz(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetSpringDampingRatio")]
    private static extern void b2DistanceJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);
    
#if BOX2D_300
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetDampingRatio")]
#else    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetSpringDampingRatio")]
#endif
    private static extern float b2DistanceJoint_GetSpringDampingRatio(JointId jointId);
    
    /// <summary>
    /// The spring damping ratio on this distance joint
    /// </summary>
    public float SpringDampingRatio
    {
        get => b2DistanceJoint_GetSpringDampingRatio(_id);
        set => b2DistanceJoint_SetSpringDampingRatio(_id, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_EnableLimit")]
    private static extern void b2DistanceJoint_EnableLimit(JointId jointId, bool enableLimit);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsLimitEnabled")]
    private static extern bool b2DistanceJoint_IsLimitEnabled(JointId jointId);
    
    /// <summary>
    /// The limit enabled state of this distance joint
    /// </summary>
    /// <remarks>The limit only works if the joint spring is enabled. Otherwise the joint is rigid and the limit has no effect</remarks>
    public bool LimitEnabled
    {
        get => b2DistanceJoint_IsLimitEnabled(_id);
        set => b2DistanceJoint_EnableLimit(_id, value);
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
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsMotorEnabled")]
    private static extern bool b2DistanceJoint_IsMotorEnabled(JointId jointId);

    /// <summary>
    /// The motor enabled state of this distance joint
    /// </summary>
    public bool MotorEnabled
    {
        get => b2DistanceJoint_IsMotorEnabled(_id);
        set => b2DistanceJoint_EnableMotor(_id, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetMotorSpeed")]
    private static extern void b2DistanceJoint_SetMotorSpeed(JointId jointId, float motorSpeed);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMotorSpeed")]
    private static extern float b2DistanceJoint_GetMotorSpeed(JointId jointId);

    public float MotorSpeed
    {
        get => b2DistanceJoint_GetMotorSpeed(_id);
        set => b2DistanceJoint_SetMotorSpeed(_id, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetMaxMotorForce")]
    private static extern void b2DistanceJoint_SetMaxMotorForce(JointId jointId, float force);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMaxMotorForce")]
    private static extern float b2DistanceJoint_GetMaxMotorForce(JointId jointId);
    
    /// <summary>
    /// The maximum motor force on this distance joint
    /// </summary>
    public float MaxMotorForce
    {
        get => b2DistanceJoint_GetMaxMotorForce(_id);
        set => b2DistanceJoint_SetMaxMotorForce(_id, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMotorForce")]
    private static extern float b2DistanceJoint_GetMotorForce(JointId jointId);
    
    /// <summary>
    /// Gets the current motor force on this distance joint
    /// </summary>
    /// <returns>The current motor force, usually in Newtons</returns>
    public float GetMotorForce() => b2DistanceJoint_GetMotorForce(_id);
}