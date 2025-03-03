using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// The motor joint is used to drive the relative transform between two bodies. It takes
/// a relative position and rotation and applies the forces and torques needed to achieve
/// that relative transform over time.
/// </summary>
public class MotorJoint : Joint
{
    internal MotorJoint(JointId id) : base(id)
    { }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetLinearOffset")]
    private static extern void b2MotorJoint_SetLinearOffset(JointId jointId, Vec2 linearOffset);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetLinearOffset")]
    private static extern Vec2 b2MotorJoint_GetLinearOffset(JointId jointId);

    /// <summary>
    /// The linear offset target on this motor joint
    /// </summary>
    public Vec2 LinearOffset
    {
        get => b2MotorJoint_GetLinearOffset(_id);
        set => b2MotorJoint_SetLinearOffset(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetAngularOffset")]
    private static extern void b2MotorJoint_SetAngularOffset(JointId jointId, float angularOffset);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetAngularOffset")]
    private static extern float b2MotorJoint_GetAngularOffset(JointId jointId);

    /// <summary>
    /// The angular offset target in radians on this motor joint
    /// </summary>
    public float AngularOffset
    {
        get => b2MotorJoint_GetAngularOffset(_id);
        set => b2MotorJoint_SetAngularOffset(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetMaxForce")]
    private static extern void b2MotorJoint_SetMaxForce(JointId jointId, float maxForce);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetMaxForce")]
    private static extern float b2MotorJoint_GetMaxForce(JointId jointId);

    public float MaxForce
    {
        get => b2MotorJoint_GetMaxForce(_id);
        set => b2MotorJoint_SetMaxForce(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetMaxTorque")]
    private static extern void b2MotorJoint_SetMaxTorque(JointId jointId, float maxTorque);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetMaxTorque")]
    private static extern float b2MotorJoint_GetMaxTorque(JointId jointId);

    /// <summary>
    /// The maximum torque on this motor joint
    /// </summary>
    public float MaxTorque
    {
        get => b2MotorJoint_GetMaxTorque(_id);
        set => b2MotorJoint_SetMaxTorque(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetCorrectionFactor")]
    private static extern void b2MotorJoint_SetCorrectionFactor(JointId jointId, float factor);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetCorrectionFactor")]
    private static extern float b2MotorJoint_GetCorrectionFactor(JointId jointId);
    
    /// <summary>
    /// The correction factor on this motor joint
    /// </summary>
    /// <remarks>0 means no correction, 1 means full correction</remarks>
    public float CorrectionFactor
    {
        get => b2MotorJoint_GetCorrectionFactor(_id);
        set => b2MotorJoint_SetCorrectionFactor(_id, value);
    }
}
