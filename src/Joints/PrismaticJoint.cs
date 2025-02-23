using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A prismatic joint allows for translation along a single axis with no rotation.
///
/// The prismatic joint is useful for things like pistons and moving platforms, where you want a body to translate
/// along an axis and have no rotation. Also called a <i>slider</i> joint.
/// </summary>
public class PrismaticJoint : Joint
{
    internal PrismaticJoint(JointId id) : base(id)
    { }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableSpring")]
    private static extern void b2PrismaticJoint_EnableSpring(JointId jointId, bool enableSpring);
    
    /// <summary>
    /// Enables/disables the joint spring
    /// </summary>
    /// <param name="enableSpring">True to enable the joint spring, false to disable the joint spring</param>
    public void EnableSpring(bool enableSpring) => b2PrismaticJoint_EnableSpring(_id, enableSpring);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsSpringEnabled")]
    private static extern bool b2PrismaticJoint_IsSpringEnabled(JointId jointId);
    
    /// <summary>
    /// Checks if the prismatic joint spring is enabled
    /// </summary>
    /// <returns>True if the prismatic joint spring is enabled</returns>
    public bool IsSpringEnabled() => b2PrismaticJoint_IsSpringEnabled(_id);

    public bool SpringEnabled
    {
        get => IsSpringEnabled();
        set => EnableSpring(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetSpringHertz")]
    private static extern void b2PrismaticJoint_SetSpringHertz(JointId jointId, float hertz);
    
    /// <summary>
    /// Sets the prismatic joint stiffness in Hertz
    /// </summary>
    /// <param name="hertz">The prismatic joint stiffness in Hertz</param>
    /// <remarks>This should usually be less than a quarter of the simulation rate. For example, if the simulation runs at 60Hz then the joint stiffness should be 15Hz or less</remarks>
    public void SetSpringHertz(float hertz) => b2PrismaticJoint_SetSpringHertz(_id, hertz);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpringHertz")]
    private static extern float b2PrismaticJoint_GetSpringHertz(JointId jointId);
    
    /// <summary>
    /// Gets the prismatic joint stiffness in Hertz
    /// </summary>
    /// <returns>The prismatic joint stiffness in Hertz</returns>
    public float GetSpringHertz() => b2PrismaticJoint_GetSpringHertz(_id);
    
    public float SpringHertz
    {
        get => GetSpringHertz();
        set => SetSpringHertz(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetSpringDampingRatio")]
    private static extern void b2PrismaticJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);
    
    /// <summary>
    /// Sets the prismatic joint damping ratio
    /// </summary>
    /// <param name="dampingRatio">The prismatic joint damping ratio</param>
    public void SetSpringDampingRatio(float dampingRatio) => b2PrismaticJoint_SetSpringDampingRatio(_id, dampingRatio);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpringDampingRatio")]
    private static extern float b2PrismaticJoint_GetSpringDampingRatio(JointId jointId);
        
    /// <summary>
    /// Gets the prismatic joint damping ratio
    /// </summary>
    /// <returns>The prismatic joint damping ratio</returns>
    public float GetSpringDampingRatio() => b2PrismaticJoint_GetSpringDampingRatio(_id);
    
    public float SpringDampingRatio
    {
        get => GetSpringDampingRatio();
        set => SetSpringDampingRatio(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableLimit")]
    private static extern void b2PrismaticJoint_EnableLimit(JointId jointId, bool enableLimit);
    
    /// <summary>
    /// Enables/disables the prismatic joint limit
    /// </summary>
    /// <param name="enableLimit">True to enable the prismatic joint limit, false to disable the prismatic joint limit</param>
    public void EnableLimit(bool enableLimit) => b2PrismaticJoint_EnableLimit(_id, enableLimit);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsLimitEnabled")]
    private static extern bool b2PrismaticJoint_IsLimitEnabled(JointId jointId);
    
    /// <summary>
    /// Checks if the prismatic joint limit is enabled
    /// </summary>
    /// <returns>True if the prismatic joint limit is enabled</returns>
    public bool IsLimitEnabled() => b2PrismaticJoint_IsLimitEnabled(_id);
    
    public bool LimitEnabled
    {
        get => IsLimitEnabled();
        set => EnableLimit(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetLimits")]
    private static extern void b2PrismaticJoint_SetLimits(JointId jointId, float lower, float upper);
    
    /// <summary>
    /// Sets the prismatic joint limits
    /// </summary>
    /// <param name="lower">The lower prismatic joint limit</param>
    /// <param name="upper">The upper prismatic joint limit</param>
    public void SetLimits(float lower, float upper) => b2PrismaticJoint_SetLimits(_id, lower, upper);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetLowerLimit")]
    private static extern float b2PrismaticJoint_GetLowerLimit(JointId jointId);
    
    /// <summary>
    /// Gets the lower prismatic joint limit
    /// </summary>
    /// <returns>The lower prismatic joint limit</returns>
    public float GetLowerLimit() => b2PrismaticJoint_GetLowerLimit(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetUpperLimit")]
    private static extern float b2PrismaticJoint_GetUpperLimit(JointId jointId);
    
    /// <summary>
    /// Gets the upper prismatic joint limit
    /// </summary>
    /// <returns>The upper prismatic joint limit</returns>
    public float GetUpperLimit() => b2PrismaticJoint_GetUpperLimit(_id);
    
    public float LowerLimit => GetLowerLimit();
    public float UpperLimit => GetUpperLimit();
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableMotor")]
    private static extern void b2PrismaticJoint_EnableMotor(JointId jointId, bool enableMotor);
    
    /// <summary>
    /// Enables/disables the prismatic joint motor
    /// </summary>
    /// <param name="enableMotor">True to enable the prismatic joint motor, false to disable the prismatic joint motor</param>
    public void EnableMotor(bool enableMotor) => b2PrismaticJoint_EnableMotor(_id, enableMotor);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsMotorEnabled")]
    private static extern bool b2PrismaticJoint_IsMotorEnabled(JointId jointId);
    
    /// <summary>
    /// Checks if the prismatic joint motor is enabled
    /// </summary>
    /// <returns>True if the prismatic joint motor is enabled</returns>
    public bool IsMotorEnabled() => b2PrismaticJoint_IsMotorEnabled(_id);
    
    public bool MotorEnabled
    {
        get => IsMotorEnabled();
        set => EnableMotor(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetMotorSpeed")]
    private static extern void b2PrismaticJoint_SetMotorSpeed(JointId jointId, float motorSpeed);
    
    /// <summary>
    /// Sets the prismatic joint motor speed
    /// </summary>
    /// <param name="motorSpeed">The prismatic joint motor speed, usually in meters per second</param>
    public void SetMotorSpeed(float motorSpeed) => b2PrismaticJoint_SetMotorSpeed(_id, motorSpeed);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMotorSpeed")]
    private static extern float b2PrismaticJoint_GetMotorSpeed(JointId jointId);
    
    /// <summary>
    /// Gets the prismatic joint motor speed
    /// </summary>
    /// <returns>The prismatic joint motor speed</returns>
    public float GetMotorSpeed() => b2PrismaticJoint_GetMotorSpeed(_id);
    
    public float MotorSpeed
    {
        get => GetMotorSpeed();
        set => SetMotorSpeed(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetMaxMotorForce")]
    private static extern void b2PrismaticJoint_SetMaxMotorForce(JointId jointId, float force);
    
    /// <summary>
    /// Sets the prismatic joint maximum motor force
    /// </summary>
    /// <param name="force">The prismatic joint maximum motor force, usually in newtons</param>
    public void SetMaxMotorForce(float force) => b2PrismaticJoint_SetMaxMotorForce(_id, force);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMaxMotorForce")]
    private static extern float b2PrismaticJoint_GetMaxMotorForce(JointId jointId);
    
    /// <summary>
    /// Gets the prismatic joint maximum motor force
    /// </summary>
    /// <returns>The prismatic joint maximum motor force</returns>
    public float GetMaxMotorForce() => b2PrismaticJoint_GetMaxMotorForce(_id);
    
    public float MaxMotorForce
    {
        get => GetMaxMotorForce();
        set => SetMaxMotorForce(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMotorForce")]
    private static extern float b2PrismaticJoint_GetMotorForce(JointId jointId);
    
    /// <summary>
    /// Gets the prismatic joint current motor force
    /// </summary>
    /// <returns>The prismatic joint current motor force</returns>
    public float GetMotorForce() => b2PrismaticJoint_GetMotorForce(_id);
    
    public float MotorForce => GetMotorForce();
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetTranslation")]
    private static extern float b2PrismaticJoint_GetTranslation(JointId jointId);
    
    /// <summary>
    /// Gets the current joint translation
    /// </summary>
    /// <returns>The current joint translation, usually in meters</returns>
    public float GetTranslation() => b2PrismaticJoint_GetTranslation(_id);
    
    public float Translation => GetTranslation();
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpeed")]
    private static extern float b2PrismaticJoint_GetSpeed(JointId jointId);
    
    /// <summary>
    /// Gets the current joint translation speed
    /// </summary>
    /// <returns>The current joint translation speed, usually in meters per second</returns>
    public float GetSpeed() => b2PrismaticJoint_GetSpeed(_id);
    
    public float Speed => GetSpeed();
}