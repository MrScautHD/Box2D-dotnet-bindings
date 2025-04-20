using JetBrains.Annotations;
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
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetTarget")]
    private static extern void b2MouseJoint_SetTarget(JointId jointId, Vec2 target);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetTarget")]
    private static extern Vec2 b2MouseJoint_GetTarget(JointId jointId);
    
    [PublicAPI]
    public Vec2 Target
    {
        get => b2MouseJoint_GetTarget(id);
        set => b2MouseJoint_SetTarget(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetSpringHertz")]
    private static extern void b2MouseJoint_SetSpringHertz(JointId jointId, float hertz);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetSpringHertz")]
    private static extern float b2MouseJoint_GetSpringHertz(JointId jointId);
    
    [PublicAPI]
    public float SpringHertz
    {
        get => b2MouseJoint_GetSpringHertz(id);
        set => b2MouseJoint_SetSpringHertz(id, value);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetSpringDampingRatio")]
    private static extern void b2MouseJoint_SetSpringDampingRatio(JointId jointId, float ratio);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetSpringDampingRatio")]
    private static extern float b2MouseJoint_GetSpringDampingRatio(JointId jointId);
    
    [PublicAPI]
    public float SpringDampingRatio
    {
        get => b2MouseJoint_GetSpringDampingRatio(id);
        set => b2MouseJoint_SetSpringDampingRatio(id, value);
    }
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetMaxForce")]
    private static extern void b2MouseJoint_SetMaxForce(JointId jointId, float maxForce);
    
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetMaxForce")]
    private static extern float b2MouseJoint_GetMaxForce(JointId jointId);
    
    [PublicAPI]
    public float MaxForce
    {
        get => b2MouseJoint_GetMaxForce(id);
        set => b2MouseJoint_SetMaxForce(id, value);
    }
}