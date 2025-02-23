using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A weld joint fully constrains the relative transform between two bodies while allowing for springiness
/// A weld joint constrains the relative rotation and translation between two bodies. Both rotation and translation
/// can have damped springs.<br/>
/// <b>Note: The accuracy of weld joint is limited by the accuracy of the solver. Long chains of weld joints may flex.</b>
/// </summary>
public class WeldJoint : Joint
{
    internal WeldJoint(JointId id) : base(id)
    { }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetReferenceAngle")]
    private static extern float b2WeldJoint_GetReferenceAngle(JointId jointId);
    
    /// <summary>
    /// Get the weld joint reference angle in radians
    /// </summary>
    /// <returns>The weld joint reference angle in radians</returns>
    public float GetReferenceAngle() => b2WeldJoint_GetReferenceAngle(_id);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetReferenceAngle")]
    private static extern void b2WeldJoint_SetReferenceAngle(JointId jointId, float angleInRadians);
    
    /// <summary>
    /// Set the weld joint reference angle in radians, must be in [-pi,pi].
    /// </summary>
    /// <param name="angleInRadians">The reference angle in radians</param>
    public void SetReferenceAngle(float angleInRadians)
    {
        while(angleInRadians < -MathF.PI)
            angleInRadians += MathF.PI * 2;
        
        while(angleInRadians > MathF.PI)
            angleInRadians -= MathF.PI * 2;
        
        b2WeldJoint_SetReferenceAngle(_id, angleInRadians);
    }
    
    public float ReferenceAngle
    {
        get => GetReferenceAngle();
        set => SetReferenceAngle(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetLinearHertz")]
    private static extern void b2WeldJoint_SetLinearHertz(JointId jointId, float hertz);
    
    /// <summary>
    /// Set the weld joint linear stiffness in Hertz.
    /// </summary>
    /// <param name="hertz">The linear stiffness in Hertz.</param>
    /// <remarks>0 is rigid</remarks>
    public void SetLinearHertz(float hertz) => b2WeldJoint_SetLinearHertz(_id, hertz);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetLinearHertz")]
    private static extern float b2WeldJoint_GetLinearHertz(JointId jointId);
    
    /// <summary>
    /// Get the weld joint linear stiffness in Hertz.
    /// </summary>
    /// <returns>The linear stiffness in Hertz</returns>
    public float GetLinearHertz() => b2WeldJoint_GetLinearHertz(_id);

    public float LinearHertz
    {
        get => GetLinearHertz();
        set => SetLinearHertz(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetLinearDampingRatio")]
    private static extern void b2WeldJoint_SetLinearDampingRatio(JointId jointId, float dampingRatio);
    
    /// <summary>
    /// Set the weld joint linear damping ratio (non-dimensional)
    /// </summary>
    /// <param name="dampingRatio">The linear damping ratio</param>
    public void SetLinearDampingRatio(float dampingRatio) => b2WeldJoint_SetLinearDampingRatio(_id, dampingRatio);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetLinearDampingRatio")]
    private static extern float b2WeldJoint_GetLinearDampingRatio(JointId jointId);
    
    /// <summary>
    /// Get the weld joint linear damping ratio (non-dimensional)
    /// </summary>
    /// <returns>The linear damping ratio</returns>
    public float GetLinearDampingRatio() => b2WeldJoint_GetLinearDampingRatio(_id);

    public float LinearDampingRatio
    {
        get => GetLinearDampingRatio();
        set => SetLinearDampingRatio(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetAngularHertz")]
    private static extern void b2WeldJoint_SetAngularHertz(JointId jointId, float hertz);
    
    /// <summary>
    /// Set the weld joint angular stiffness in Hertz.
    /// </summary>
    /// <param name="hertz">The angular stiffness in Hertz</param>
    /// <remarks>0 is rigid</remarks>
    public void SetAngularHertz(float hertz) => b2WeldJoint_SetAngularHertz(_id, hertz);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetAngularHertz")]
    private static extern float b2WeldJoint_GetAngularHertz(JointId jointId);
    
    /// <summary>
    /// Get the weld joint angular stiffness in Hertz.
    /// </summary>
    /// <returns>The angular stiffness in Hertz</returns>
    public float GetAngularHertz() => b2WeldJoint_GetAngularHertz(_id);

    public float AngularHertz
    {
        get => GetAngularHertz();
        set => SetAngularHertz(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetAngularDampingRatio")]
    private static extern void b2WeldJoint_SetAngularDampingRatio(JointId jointId, float dampingRatio);
    
    /// <summary>
    /// Set the weld joint angular damping ratio (non-dimensional)
    /// </summary>
    /// <param name="dampingRatio">The angular damping ratio</param>
    public void SetAngularDampingRatio(float dampingRatio) => b2WeldJoint_SetAngularDampingRatio(_id, dampingRatio);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetAngularDampingRatio")]
    private static extern float b2WeldJoint_GetAngularDampingRatio(JointId jointId);
    
    /// <summary>
    /// Get the weld joint angular damping ratio (non-dimensional)
    /// </summary>
    /// <returns>The angular damping ratio</returns>
    public float GetAngularDampingRatio() => b2WeldJoint_GetAngularDampingRatio(_id);

    public float AngularDampingRatio
    {
        get => GetAngularDampingRatio();
        set => SetAngularDampingRatio(value);
    }
}