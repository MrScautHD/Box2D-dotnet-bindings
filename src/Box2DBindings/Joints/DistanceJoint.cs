using JetBrains.Annotations;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A distance joint definition.<br/>
/// This requires defining an anchor point on both
/// bodies and the non-zero distance of the distance joint. The definition uses
/// local anchor points so that the initial configuration can violate the
/// constraint slightly. This helps when saving and loading a game.
/// </summary>
public class DistanceJoint : Joint
{
    internal DistanceJoint(JointId id) : base(id)
    { }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetLength")]
    private static extern void b2DistanceJoint_SetLength(JointId jointId, float length);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetLength")]
    private static extern float b2DistanceJoint_GetLength(JointId jointId);
    
    /// <summary>
    /// The rest length of this distance joint
    /// </summary>
    [PublicAPI]
    public float Length
    {
        get => b2DistanceJoint_GetLength(id);
        set => b2DistanceJoint_SetLength(id, value);
    }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_EnableSpring")]
    private static extern void b2DistanceJoint_EnableSpring(JointId jointId, bool enableSpring);
    
    /// <summary>
    /// Enables/disables the spring on this distance joint
    /// </summary>
    /// <param name="enableSpring">True to enable the spring, false to disable the spring</param>
    [PublicAPI]
    public void EnableSpring(bool enableSpring)
    {
        b2DistanceJoint_EnableSpring(id, enableSpring);
    }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsSpringEnabled")]
    private static extern bool b2DistanceJoint_IsSpringEnabled(JointId jointId);
    
    /// <summary>
    /// Gets or sets the spring enabled state on this distance joint
    /// </summary>
    /// <returns>True if the spring is enabled</returns>
    [PublicAPI]
    public bool SpringEnabled
    {
        get => b2DistanceJoint_IsSpringEnabled(id);
        set => EnableSpring(value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetSpringHertz")]
    private static extern void b2DistanceJoint_SetSpringHertz(JointId jointId, float hertz);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetSpringHertz")]
    private static extern float b2DistanceJoint_GetSpringHertz(JointId jointId);
    
    /// <summary>
    /// The spring stiffness in Hertz on this distance joint
    /// </summary>
    [PublicAPI]
    public float SpringHertz
    {
        get => b2DistanceJoint_GetSpringHertz(id);
        set => b2DistanceJoint_SetSpringHertz(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetSpringDampingRatio")]
    private static extern void b2DistanceJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetSpringDampingRatio")]
    private static extern float b2DistanceJoint_GetSpringDampingRatio(JointId jointId);
    
    /// <summary>
    /// The spring damping ratio on this distance joint
    /// </summary>
    [PublicAPI]
    public float SpringDampingRatio
    {
        get => b2DistanceJoint_GetSpringDampingRatio(id);
        set => b2DistanceJoint_SetSpringDampingRatio(id, value);
    }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_EnableLimit")]
    private static extern void b2DistanceJoint_EnableLimit(JointId jointId, bool enableLimit);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsLimitEnabled")]
    private static extern bool b2DistanceJoint_IsLimitEnabled(JointId jointId);
    
    /// <summary>
    /// The limit enabled state of this distance joint
    /// </summary>
    /// <remarks>The limit only works if the joint spring is enabled. Otherwise the joint is rigid and the limit has no effect</remarks>
    [PublicAPI]
    public bool LimitEnabled
    {
        get => b2DistanceJoint_IsLimitEnabled(id);
        set => b2DistanceJoint_EnableLimit(id, value);
    }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetLengthRange")]
    private static extern void b2DistanceJoint_SetLengthRange(JointId jointId, float minLength, float maxLength);
    
    /// <summary>
    /// Sets the minimum and maximum length parameters on this distance joint
    /// </summary>
    /// <param name="minLength">The minimum length</param>
    /// <param name="maxLength">The maximum length</param>
    [PublicAPI]
    public void SetLengthRange(float minLength, float maxLength) => b2DistanceJoint_SetLengthRange(id, minLength, maxLength);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMinLength")]
    private static extern float b2DistanceJoint_GetMinLength(JointId jointId);
    
    /// <summary>
    /// Gets the minimum length of this distance joint
    /// </summary>
    /// <returns>The minimum length</returns>
    [PublicAPI]
    public float MinLength => b2DistanceJoint_GetMinLength(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMaxLength")]
    private static extern float b2DistanceJoint_GetMaxLength(JointId jointId);
    
    /// <summary>
    /// Gets the maximum length of this distance joint
    /// </summary>
    /// <returns>The maximum length</returns>
    public float MaxLength => b2DistanceJoint_GetMaxLength(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetCurrentLength")]
    private static extern float b2DistanceJoint_GetCurrentLength(JointId jointId);
    
    /// <summary>
    /// Gets the current length of this distance joint
    /// </summary>
    /// <returns>The current length</returns>
    [PublicAPI]
    public float CurrentLength => b2DistanceJoint_GetCurrentLength(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_EnableMotor")]
    private static extern void b2DistanceJoint_EnableMotor(JointId jointId, bool enableMotor);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsMotorEnabled")]
    private static extern bool b2DistanceJoint_IsMotorEnabled(JointId jointId);

    /// <summary>
    /// The motor enabled state of this distance joint
    /// </summary>
    [PublicAPI]
    public bool MotorEnabled
    {
        get => b2DistanceJoint_IsMotorEnabled(id);
        set => b2DistanceJoint_EnableMotor(id, value);
    }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetMotorSpeed")]
    private static extern void b2DistanceJoint_SetMotorSpeed(JointId jointId, float motorSpeed);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMotorSpeed")]
    private static extern float b2DistanceJoint_GetMotorSpeed(JointId jointId);

    /// <summary>
    /// The desired motor speed, usually in meters per second
    /// </summary>
    [PublicAPI]
    public float MotorSpeed
    {
        get => b2DistanceJoint_GetMotorSpeed(id);
        set => b2DistanceJoint_SetMotorSpeed(id, value);
    }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetMaxMotorForce")]
    private static extern void b2DistanceJoint_SetMaxMotorForce(JointId jointId, float force);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMaxMotorForce")]
    private static extern float b2DistanceJoint_GetMaxMotorForce(JointId jointId);
    
    /// <summary>
    /// The maximum motor force on this distance joint
    /// </summary>
    [PublicAPI]
    public float MaxMotorForce
    {
        get => b2DistanceJoint_GetMaxMotorForce(id);
        set => b2DistanceJoint_SetMaxMotorForce(id, value);
    }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMotorForce")]
    private static extern float b2DistanceJoint_GetMotorForce(JointId jointId);
    
    /// <summary>
    /// Gets the current motor force on this distance joint
    /// </summary>
    /// <returns>The current motor force, usually in Newtons</returns>
    [PublicAPI]
    public float MotorForce => b2DistanceJoint_GetMotorForce(id);
}