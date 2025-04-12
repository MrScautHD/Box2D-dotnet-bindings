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

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpringHertz")]
    private static extern float b2PrismaticJoint_GetSpringHertz(JointId jointId);

    public float SpringHertz
    {
        get => b2PrismaticJoint_GetSpringHertz(_id);
        set => b2PrismaticJoint_SetSpringHertz(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetSpringDampingRatio")]
    private static extern void b2PrismaticJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpringDampingRatio")]
    private static extern float b2PrismaticJoint_GetSpringDampingRatio(JointId jointId);

    public float SpringDampingRatio
    {
        get => b2PrismaticJoint_GetSpringDampingRatio(_id);
        set => b2PrismaticJoint_SetSpringDampingRatio(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableLimit")]
    private static extern void b2PrismaticJoint_EnableLimit(JointId jointId, bool enableLimit);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsLimitEnabled")]
    private static extern bool b2PrismaticJoint_IsLimitEnabled(JointId jointId);

    public bool LimitEnabled
    {
        get => b2PrismaticJoint_IsLimitEnabled(_id);
        set => b2PrismaticJoint_EnableLimit(_id, value);
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
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetUpperLimit")]
    private static extern float b2PrismaticJoint_GetUpperLimit(JointId jointId);
    
    /// <summary>
    /// The lower joint limit of this prismatic joint
    /// </summary>
    public float LowerLimit => b2PrismaticJoint_GetLowerLimit(_id);
    
    /// <summary>
    /// The upper joint limit of this prismatic joint
    /// </summary>
    public float UpperLimit => b2PrismaticJoint_GetUpperLimit(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableMotor")]
    private static extern void b2PrismaticJoint_EnableMotor(JointId jointId, bool enableMotor);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsMotorEnabled")]
    private static extern bool b2PrismaticJoint_IsMotorEnabled(JointId jointId);

    /// <summary>
    /// The prismatic joint motor enabled state
    /// </summary>
    public bool MotorEnabled
    {
        get => b2PrismaticJoint_IsMotorEnabled(_id);
        set => b2PrismaticJoint_EnableMotor(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetMotorSpeed")]
    private static extern void b2PrismaticJoint_SetMotorSpeed(JointId jointId, float motorSpeed);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMotorSpeed")]
    private static extern float b2PrismaticJoint_GetMotorSpeed(JointId jointId);

    /// <summary>
    /// The prismatic joint motor speed
    /// </summary>
    public float MotorSpeed
    {
        get => b2PrismaticJoint_GetMotorSpeed(_id);
        set => b2PrismaticJoint_SetMotorSpeed(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetMaxMotorForce")]
    private static extern void b2PrismaticJoint_SetMaxMotorForce(JointId jointId, float force);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMaxMotorForce")]
    private static extern float b2PrismaticJoint_GetMaxMotorForce(JointId jointId);

    /// <summary>
    /// The prismatic joint maximum motor force
    /// </summary>
    public float MaxMotorForce
    {
        get => b2PrismaticJoint_GetMaxMotorForce(_id);
        set => b2PrismaticJoint_SetMaxMotorForce(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMotorForce")]
    private static extern float b2PrismaticJoint_GetMotorForce(JointId jointId);
    
    /// <summary>
    /// The prismatic joint current motor force
    /// </summary>
    public float MotorForce => b2PrismaticJoint_GetMotorForce(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetTranslation")]
    private static extern float b2PrismaticJoint_GetTranslation(JointId jointId);

    /// <summary>
    /// The current joint translation
    /// </summary>
    public float Translation =>  b2PrismaticJoint_GetTranslation(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpeed")]
    private static extern float b2PrismaticJoint_GetSpeed(JointId jointId);

    /// <summary>
    /// The current joint translation speed
    /// </summary>
    public float Speed => b2PrismaticJoint_GetSpeed(_id);
}
