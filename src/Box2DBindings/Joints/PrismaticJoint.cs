using JetBrains.Annotations;
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

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableSpring")]
    private static extern void b2PrismaticJoint_EnableSpring(JointId jointId, bool enableSpring);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsSpringEnabled")]
    private static extern bool b2PrismaticJoint_IsSpringEnabled(JointId jointId);

    /// <summary>
    /// Gets or sets the prismatic joint spring enabled state
    /// </summary>
    /// <returns>True if the prismatic joint spring is enabled</returns>
    [PublicAPI]
    public bool SpringEnabled
    {
        get => b2PrismaticJoint_IsSpringEnabled(id);
        set => b2PrismaticJoint_EnableSpring(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetSpringHertz")]
    private static extern void b2PrismaticJoint_SetSpringHertz(JointId jointId, float hertz);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpringHertz")]
    private static extern float b2PrismaticJoint_GetSpringHertz(JointId jointId);

    [PublicAPI]
    public float SpringHertz
    {
        get => b2PrismaticJoint_GetSpringHertz(id);
        set => b2PrismaticJoint_SetSpringHertz(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetSpringDampingRatio")]
    private static extern void b2PrismaticJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpringDampingRatio")]
    private static extern float b2PrismaticJoint_GetSpringDampingRatio(JointId jointId);

    [PublicAPI]
    public float SpringDampingRatio
    {
        get => b2PrismaticJoint_GetSpringDampingRatio(id);
        set => b2PrismaticJoint_SetSpringDampingRatio(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableLimit")]
    private static extern void b2PrismaticJoint_EnableLimit(JointId jointId, bool enableLimit);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsLimitEnabled")]
    private static extern bool b2PrismaticJoint_IsLimitEnabled(JointId jointId);

    [PublicAPI]
    public bool LimitEnabled
    {
        get => b2PrismaticJoint_IsLimitEnabled(id);
        set => b2PrismaticJoint_EnableLimit(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetLimits")]
    private static extern void b2PrismaticJoint_SetLimits(JointId jointId, float lower, float upper);

    /// <summary>
    /// Sets the prismatic joint limits
    /// </summary>
    /// <param name="lower">The lower prismatic joint limit</param>
    /// <param name="upper">The upper prismatic joint limit</param>
    [PublicAPI]
    public void SetLimits(float lower, float upper) => b2PrismaticJoint_SetLimits(id, lower, upper);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetLowerLimit")]
    private static extern float b2PrismaticJoint_GetLowerLimit(JointId jointId);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetUpperLimit")]
    private static extern float b2PrismaticJoint_GetUpperLimit(JointId jointId);
    
    /// <summary>
    /// The lower joint limit of this prismatic joint
    /// </summary>
    [PublicAPI]
    public float LowerLimit => b2PrismaticJoint_GetLowerLimit(id);
    
    /// <summary>
    /// The upper joint limit of this prismatic joint
    /// </summary>
    [PublicAPI]
    public float UpperLimit => b2PrismaticJoint_GetUpperLimit(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableMotor")]
    private static extern void b2PrismaticJoint_EnableMotor(JointId jointId, bool enableMotor);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsMotorEnabled")]
    private static extern bool b2PrismaticJoint_IsMotorEnabled(JointId jointId);

    /// <summary>
    /// The prismatic joint motor enabled state
    /// </summary>
    [PublicAPI]
    public bool MotorEnabled
    {
        get => b2PrismaticJoint_IsMotorEnabled(id);
        set => b2PrismaticJoint_EnableMotor(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetMotorSpeed")]
    private static extern void b2PrismaticJoint_SetMotorSpeed(JointId jointId, float motorSpeed);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMotorSpeed")]
    private static extern float b2PrismaticJoint_GetMotorSpeed(JointId jointId);

    /// <summary>
    /// The prismatic joint motor speed
    /// </summary>
    [PublicAPI]
    public float MotorSpeed
    {
        get => b2PrismaticJoint_GetMotorSpeed(id);
        set => b2PrismaticJoint_SetMotorSpeed(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetMaxMotorForce")]
    private static extern void b2PrismaticJoint_SetMaxMotorForce(JointId jointId, float force);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMaxMotorForce")]
    private static extern float b2PrismaticJoint_GetMaxMotorForce(JointId jointId);

    /// <summary>
    /// The prismatic joint maximum motor force
    /// </summary>
    [PublicAPI]
    public float MaxMotorForce
    {
        get => b2PrismaticJoint_GetMaxMotorForce(id);
        set => b2PrismaticJoint_SetMaxMotorForce(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMotorForce")]
    private static extern float b2PrismaticJoint_GetMotorForce(JointId jointId);
    
    /// <summary>
    /// The prismatic joint current motor force
    /// </summary>
    [PublicAPI]
    public float MotorForce => b2PrismaticJoint_GetMotorForce(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetTranslation")]
    private static extern float b2PrismaticJoint_GetTranslation(JointId jointId);

    /// <summary>
    /// The current joint translation
    /// </summary>
    [PublicAPI]
    public float Translation =>  b2PrismaticJoint_GetTranslation(id);

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpeed")]
    private static extern float b2PrismaticJoint_GetSpeed(JointId jointId);

    /// <summary>
    /// The current joint translation speed
    /// </summary>
    [PublicAPI]
    public float Speed => b2PrismaticJoint_GetSpeed(id);
}
