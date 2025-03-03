using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// The mouse joint is designed for use in the samples application, but you may find it useful in applications where
/// the user moves a rigid body with a cursor.
/// </summary>
public class MouseJoint:Joint
{
    internal MouseJoint(JointId id) : base(id)
    { }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetTarget")]
    private static extern void b2MouseJoint_SetTarget(JointId jointId, Vec2 target);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetTarget")]
    private static extern Vec2 b2MouseJoint_GetTarget(JointId jointId);
    
    public Vec2 Target
    {
        get => b2MouseJoint_GetTarget(_id);
        set => b2MouseJoint_SetTarget(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetSpringHertz")]
    private static extern void b2MouseJoint_SetSpringHertz(JointId jointId, float hertz);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetSpringHertz")]
    private static extern float b2MouseJoint_GetSpringHertz(JointId jointId);
    
    public float SpringHertz
    {
        get => b2MouseJoint_GetSpringHertz(_id);
        set => b2MouseJoint_SetSpringHertz(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetSpringDampingRatio")]
    private static extern void b2MouseJoint_SetSpringDampingRatio(JointId jointId, float ratio);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetSpringDampingRatio")]
    private static extern float b2MouseJoint_GetSpringDampingRatio(JointId jointId);
    
    public float SpringDampingRatio
    {
        get => b2MouseJoint_GetSpringDampingRatio(_id);
        set => b2MouseJoint_SetSpringDampingRatio(_id, value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetMaxForce")]
    private static extern void b2MouseJoint_SetMaxForce(JointId jointId, float maxForce);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetMaxForce")]
    private static extern float b2MouseJoint_GetMaxForce(JointId jointId);
    
    public float MaxForce
    {
        get => b2MouseJoint_GetMaxForce(_id);
        set => b2MouseJoint_SetMaxForce(_id, value);
    }
}