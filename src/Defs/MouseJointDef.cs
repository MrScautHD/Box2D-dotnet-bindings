using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A mouse joint is used to make a point on a body track a specified world point.<br/>
///
/// This a soft constraint and allows the constraint to stretch without
/// applying huge forces. This also applies rotation constraint heuristic to improve control.
/// </summary>
public class MouseJointDef
{
    internal MouseJointDefInternal _internal;

    public MouseJointDef()
    {
        _internal = MouseJointDefInternal.Default;
    }
    
    ~MouseJointDef()
    {
        if (_internal.UserData != 0)
            GCHandle.FromIntPtr(_internal.UserData).Free();
    }
    
    /// <summary>
    /// The first attached body. This is assumed to be static.
    /// </summary>
    public Body BodyA
    {
        get => _internal.BodyA;
        set => _internal.BodyA = value;
    }

    /// <summary>
    /// The second attached body.
    /// </summary>
    public Body BodyB
    {
        get => _internal.BodyB;
        set => _internal.BodyB = value;
    }

    /// <summary>
    /// The initial target point in world space
    /// </summary>
    public Vec2 Target
    {
        get => _internal.Target;
        set => _internal.Target = value;
    }

    /// <summary>
    /// Stiffness in hertz
    /// </summary>
    public float Hertz
    {
        get => _internal.Hertz;
        set => _internal.Hertz = value;
    }

    /// <summary>
    /// Damping ratio, non-dimensional
    /// </summary>
    public float DampingRatio
    {
        get => _internal.DampingRatio;
        set => _internal.DampingRatio = value;
    }

    /// <summary>
    /// Maximum force, typically in newtons
    /// </summary>
    public float MaxForce
    {
        get => _internal.MaxForce;
        set => _internal.MaxForce = value;
    }

    /// <summary>
    /// Set this flag to true if the attached bodies should collide.
    /// </summary>
    public bool CollideConnected
    {
        get => _internal.CollideConnected;
        set => _internal.CollideConnected = value;
    }

    /// <summary>
    /// User data pointer
    /// </summary>
    public object? UserData
    {
        get => GCHandle.FromIntPtr(_internal.UserData).Target;
        set => _internal.UserData = GCHandle.ToIntPtr(GCHandle.Alloc(value));
    }
}