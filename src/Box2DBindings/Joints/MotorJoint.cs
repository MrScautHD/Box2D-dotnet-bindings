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
    
    /// <summary>
    /// Sets the linear offset target on this motor joint
    /// </summary>
    /// <param name="linearOffset">The linear offset target</param>
    public void SetLinearOffset(Vec2 linearOffset)
    {
        b2MotorJoint_SetLinearOffset(_id, linearOffset);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetLinearOffset")]
    private static extern Vec2 b2MotorJoint_GetLinearOffset(JointId jointId);
    
    /// <summary>
    /// Gets the linear offset target on this motor joint
    /// </summary>
    /// <returns>The linear offset target</returns>
    public Vec2 GetLinearOffset() => b2MotorJoint_GetLinearOffset(_id);

    public Vec2 LinearOffset
    {
        get => GetLinearOffset();
        set => SetLinearOffset(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetAngularOffset")]
    private static extern void b2MotorJoint_SetAngularOffset(JointId jointId, float angularOffset);
    
    /// <summary>
    /// Sets the angular offset target in radians on this motor joint
    /// </summary>
    /// <param name="angularOffset">The angular offset target in radians</param>
    public void SetAngularOffset(float angularOffset) => b2MotorJoint_SetAngularOffset(_id, angularOffset);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetAngularOffset")]
    private static extern float b2MotorJoint_GetAngularOffset(JointId jointId);
    
    /// <summary>
    /// Gets the angular offset target in radians on this motor joint
    /// </summary>
    /// <returns>The angular offset target in radians</returns>
    public float GetAngularOffset() => b2MotorJoint_GetAngularOffset(_id);

    public float AngularOffset
    {
        get => GetAngularOffset();
        set => SetAngularOffset(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetMaxForce")]
    private static extern void b2MotorJoint_SetMaxForce(JointId jointId, float maxForce);
    
    /// <summary>
    /// Sets the maximum force on this motor joint
    /// </summary>
    /// <param name="maxForce">The maximum force, usually in Newtons</param>
    public void SetMaxForce(float maxForce) => b2MotorJoint_SetMaxForce(_id, maxForce);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetMaxForce")]
    private static extern float b2MotorJoint_GetMaxForce(JointId jointId);
    
    /// <summary>
    /// Gets the maximum force on this motor joint
    /// </summary>
    /// <returns>The maximum force, usually in Newtons</returns>
    public float GetMaxForce() => b2MotorJoint_GetMaxForce(_id);

    public float MaxForce
    {
        get => GetMaxForce();
        set => SetMaxForce(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetMaxTorque")]
    private static extern void b2MotorJoint_SetMaxTorque(JointId jointId, float maxTorque);
    
    /// <summary>
    /// Sets the maximum torque on this motor joint
    /// </summary>
    /// <param name="maxTorque">The maximum torque, usually in Newton-meters</param>
    public void SetMaxTorque(float maxTorque) => b2MotorJoint_SetMaxTorque(_id, maxTorque);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetMaxTorque")]
    private static extern float b2MotorJoint_GetMaxTorque(JointId jointId);
    
    /// <summary>
    /// Gets the maximum torque on this motor joint
    /// </summary>
    /// <returns>The maximum torque, usually in Newton-meters</returns>
    public float GetMaxTorque() => b2MotorJoint_GetMaxTorque(_id);

    public float MaxTorque
    {
        get => GetMaxTorque();
        set => SetMaxTorque(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetCorrectionFactor")]
    private static extern void b2MotorJoint_SetCorrectionFactor(JointId jointId, float factor);
    
    /// <summary>
    /// Sets the correction factor on this motor joint
    /// </summary>
    /// <param name="factor">The correction factor in the range [0,1]</param>
    /// <remarks>0 means no correction, 1 means full correction</remarks>
    public void SetCorrectionFactor(float factor) => b2MotorJoint_SetCorrectionFactor(_id, factor);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetCorrectionFactor")]
    private static extern float b2MotorJoint_GetCorrectionFactor(JointId jointId);
    
    /// <summary>
    /// Gets the correction factor on this motor joint
    /// </summary>
    /// <returns>The correction factor in the range [0,1]</returns>
    /// <remarks>0 means no correction, 1 means full correction</remarks>
    public float GetCorrectionFactor() => b2MotorJoint_GetCorrectionFactor(_id);

    public float CorrectionFactor
    {
        get => GetCorrectionFactor();
        set => SetCorrectionFactor(value);
    }
}