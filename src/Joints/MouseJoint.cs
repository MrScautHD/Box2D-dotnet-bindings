using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// The mouse joint is designed for use in the samples application, but you may find it useful in applications where
/// the user moves a rigid body with a cursor.
/// </summary>
public class MouseJoint:Joint
{
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetTarget")]
    private static extern void b2MouseJoint_SetTarget(JointId jointId, Vec2 target);
    
    /// <summary>
    /// Sets the mouse joint target
    /// </summary>
    /// <param name="target">The target</param>
    public void SetTarget(Vec2 target) => b2MouseJoint_SetTarget(_id, target);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetTarget")]
    private static extern Vec2 b2MouseJoint_GetTarget(JointId jointId);
    
    /// <summary>
    /// Gets the mouse joint target
    /// </summary>
    /// <returns>The target</returns>
    public Vec2 GetTarget() => b2MouseJoint_GetTarget(_id);

    public Vec2 Target
    {
        get => GetTarget();
        set => SetTarget(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetSpringHertz")]
    private static extern void b2MouseJoint_SetSpringHertz(JointId jointId, float hertz);
    
    /// <summary>
    /// Sets the mouse joint spring stiffness in Hertz
    /// </summary>
    /// <param name="hertz">The spring stiffness in Hertz</param>
    public void SetSpringHertz(float hertz) => b2MouseJoint_SetSpringHertz(_id, hertz);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetSpringHertz")]
    private static extern float b2MouseJoint_GetSpringHertz(JointId jointId);
    
    /// <summary>
    /// Gets the mouse joint spring stiffness in Hertz
    /// </summary>
    /// <returns>The spring stiffness in Hertz</returns>
    public float GetSpringHertz() => b2MouseJoint_GetSpringHertz(_id);

    public float SpringHertz
    {
        get => GetSpringHertz();
        set => SetSpringHertz(value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetSpringDampingRatio")]
    private static extern void b2MouseJoint_SetSpringDampingRatio(JointId jointId, float ratio);
    
    /// <summary>
    /// Sets the mouse joint spring damping ratio, non-dimensional
    /// </summary>
    /// <param name="ratio">The spring damping ratio, non-dimensional</param>
    public void SetSpringDampingRatio(float ratio) => b2MouseJoint_SetSpringDampingRatio(_id, ratio);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetSpringDampingRatio")]
    private static extern float b2MouseJoint_GetSpringDampingRatio(JointId jointId);
    
    /// <summary>
    /// Gets the mouse joint spring damping ratio, non-dimensional
    /// </summary>
    /// <returns>The spring damping ratio, non-dimensional</returns>
    public float GetSpringDampingRatio() => b2MouseJoint_GetSpringDampingRatio(_id);

    public float SpringDampingRatio
    {
        get => GetSpringDampingRatio();
        set => SetSpringDampingRatio(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetMaxForce")]
    private static extern void b2MouseJoint_SetMaxForce(JointId jointId, float maxForce);
    
    /// <summary>
    /// Sets the mouse joint maximum force, usually in Newtons
    /// </summary>
    /// <param name="maxForce">The maximum force, usually in Newtons</param>
    public void SetMaxForce(float maxForce)
    {
        b2MouseJoint_SetMaxForce(_id, maxForce);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetMaxForce")]
    private static extern float b2MouseJoint_GetMaxForce(JointId jointId);
    
    /// <summary>
    /// Gets the mouse joint maximum force, usually in Newtons
    /// </summary>
    /// <returns>The maximum force, usually in Newtons</returns>
    public float GetMaxForce()
    {
        return b2MouseJoint_GetMaxForce(_id);
    }
    
    public float MaxForce
    {
        get => GetMaxForce();
        set => SetMaxForce(value);
    }
}