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

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetReferenceAngle")]
    private static extern void b2WeldJoint_SetReferenceAngle(JointId jointId, float angleInRadians);

    public float ReferenceAngle
    {
        get => b2WeldJoint_GetReferenceAngle(_id);
        set
        {
            float angleInRadians = value;
            while (angleInRadians < -MathF.PI)
                angleInRadians += MathF.PI * 2;

            while (angleInRadians > MathF.PI)
                angleInRadians -= MathF.PI * 2;

            b2WeldJoint_SetReferenceAngle(_id, angleInRadians);
        }
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetLinearHertz")]
    private static extern void b2WeldJoint_SetLinearHertz(JointId jointId, float hertz);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetLinearHertz")]
    private static extern float b2WeldJoint_GetLinearHertz(JointId jointId);

    /// <summary>
    /// The weld joint linear stiffness in Hertz.
    /// </summary>
    public float LinearHertz
    {
        get => b2WeldJoint_GetLinearHertz(_id);
        set => b2WeldJoint_SetLinearHertz(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetLinearDampingRatio")]
    private static extern void b2WeldJoint_SetLinearDampingRatio(JointId jointId, float dampingRatio);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetLinearDampingRatio")]
    private static extern float b2WeldJoint_GetLinearDampingRatio(JointId jointId);

    /// <summary>
    /// The weld joint linear damping ratio.
    /// </summary>
    public float LinearDampingRatio
    {
        get => b2WeldJoint_GetLinearDampingRatio(_id);
        set => b2WeldJoint_SetLinearDampingRatio(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetAngularHertz")]
    private static extern void b2WeldJoint_SetAngularHertz(JointId jointId, float hertz);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetAngularHertz")]
    private static extern float b2WeldJoint_GetAngularHertz(JointId jointId);

    /// <summary>
    /// The weld joint angular stiffness in Hertz.
    /// </summary>
    public float AngularHertz
    {
        get => b2WeldJoint_GetAngularHertz(_id);
        set => b2WeldJoint_SetAngularHertz(_id, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetAngularDampingRatio")]
    private static extern void b2WeldJoint_SetAngularDampingRatio(JointId jointId, float dampingRatio);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetAngularDampingRatio")]
    private static extern float b2WeldJoint_GetAngularDampingRatio(JointId jointId);

    /// <summary>
    /// The weld joint angular damping ratio.
    /// </summary>
    public float AngularDampingRatio
    {
        get => b2WeldJoint_GetAngularDampingRatio(_id);
        set => b2WeldJoint_SetAngularDampingRatio(_id, value);
    }
}
