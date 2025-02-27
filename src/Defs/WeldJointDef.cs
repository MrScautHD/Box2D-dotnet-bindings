using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Weld joint definition<br/>
///
/// A weld joint connect to bodies together rigidly. This constraint provides springs to mimic
/// soft-body simulation.
/// <i>Note: The approximate solver in Box2D cannot hold many bodies together rigidly</i>.
/// </summary>
public class WeldJointDef
{
    internal WeldJointDefInternal _internal;
    
    public WeldJointDef()
    {
        _internal = new WeldJointDefInternal();
    }
    
    ~WeldJointDef()
    {
        if (_internal.UserData != 0)
            GCHandle.FromIntPtr(_internal.UserData).Free();
    }
    
    /// <summary>
    /// The first attached body
    /// </summary>
    public Body BodyA
    {
        get => _internal.BodyA;
        set => _internal.BodyA = value;
    }
    
    /// <summary>
    /// The second attached body
    /// </summary>
    public Body BodyB
    {
        get => _internal.BodyB;
        set => _internal.BodyB = value;
    }
    
    /// <summary>
    /// The local anchor point relative to bodyA's origin
    /// </summary>
    public Vec2 LocalAnchorA
    {
        get => _internal.LocalAnchorA;
        set => _internal.LocalAnchorA = value;
    }
    
    /// <summary>
    /// The local anchor point relative to bodyB's origin
    /// </summary>
    public Vec2 LocalAnchorB
    {
        get => _internal.LocalAnchorB;
        set => _internal.LocalAnchorB = value;
    }
    
    /// <summary>
    /// The bodyB angle minus bodyA angle in the reference state (radians)
    /// </summary>
    public float ReferenceAngle
    {
        get => _internal.ReferenceAngle;
        set => _internal.ReferenceAngle = value;
    }
    
    /// <summary>
    /// Linear stiffness expressed as Hertz (cycles per second). Use zero for maximum stiffness.
    /// </summary>
    public float LinearHertz
    {
        get => _internal.LinearHertz;
        set => _internal.LinearHertz = value;
    }
    
    /// <summary>
    /// Angular stiffness as Hertz (cycles per second). Use zero for maximum stiffness.
    /// </summary>
    public float AngularHertz
    {
        get => _internal.AngularHertz;
        set => _internal.AngularHertz = value;
    }
    
    /// <summary>
    /// Linear damping ratio, non-dimensional. Use 1 for critical damping.
    /// </summary>
    public float LinearDampingRatio
    {
        get => _internal.LinearDampingRatio;
        set => _internal.LinearDampingRatio = value;
    }

    /// <summary>
    /// Linear damping ratio, non-dimensional. Use 1 for critical damping.
    /// </summary>
    public float AngularDampingRatio
    {
        get => _internal.AngularDampingRatio;
        set => _internal.AngularDampingRatio = value;
    }
    
    /// <summary>
    /// Set this flag to true if the attached bodies should collide
    /// </summary>
    public bool CollideConnected
    {
        get => _internal.CollideConnected;
        set => _internal.CollideConnected = value;
    }
    
    /// <summary>
    /// User data
    /// </summary>
    public object UserData
    {
        get => GCHandle.FromIntPtr(_internal.UserData).Target;
        set
        {
            if (_internal.UserData != 0)
            {
                GCHandle.FromIntPtr(_internal.UserData).Free();
                _internal.UserData = 0;
            }
            if (value != null)
                _internal.UserData = GCHandle.ToIntPtr(GCHandle.Alloc(value));
        }
    }
}