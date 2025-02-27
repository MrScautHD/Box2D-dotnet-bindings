using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Distance joint definition<br/>
///
/// This requires defining an anchor point on both
/// bodies and the non-zero distance of the distance joint. The definition uses
/// local anchor points so that the initial configuration can violate the
/// constraint slightly. This helps when saving and loading a game.
/// </summary>
public class DistanceJointDef
{
    internal DistanceJointDefInternal _internal;

    /// <summary>
    /// Creates a distance joint definition with the default values.
    /// </summary>
    public DistanceJointDef()
    {
        _internal = new DistanceJointDefInternal();
    }
    
    ~DistanceJointDef()
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
    /// The rest length of this joint. Clamped to a stable minimum value.
    /// </summary>
    public float Length
    {
        get => _internal.Length;
        set => _internal.Length = value;
    }

    /// <summary>
    /// Enable the distance constraint to behave like a spring. If false
    /// then the distance joint will be rigid, overriding the limit and motor.
    /// </summary>
    public bool EnableSpring
    {
        get => _internal.EnableSpring;
        set => _internal.EnableSpring = value;
    }

    /// <summary>
    /// The spring linear stiffness Hertz, cycles per second
    /// </summary>
    public float Hertz
    {
        get => _internal.Hertz;
        set => _internal.Hertz = value;
    }

    /// <summary>
    /// The spring linear damping ratio, non-dimensional
    /// </summary>
    public float DampingRatio
    {
        get => _internal.DampingRatio;
        set => _internal.DampingRatio = value;
    }

    /// <summary>
    /// Enable/disable the joint limit
    /// </summary>
    public bool EnableLimit
    {
        get => _internal.EnableLimit;
        set => _internal.EnableLimit = value;
    }
    
    /// <summary>
    /// Minimum length. Clamped to a stable minimum value.
    /// </summary>
    public float MinLength
    {
        get => _internal.MinLength;
        set => _internal.MinLength = value;
    }
    
    /// <summary>
    /// Maximum length. Must be greater than or equal to the minimum length.
    /// </summary>
    public float MaxLength
    {
        get => _internal.MaxLength;
        set => _internal.MaxLength = value;
    }
    
    /// <summary>
    /// Enable/disable the joint motor
    /// </summary>
    public bool EnableMotor
    {
        get => _internal.EnableMotor;
        set => _internal.EnableMotor = value;
    }
    
    /// <summary>
    /// The maximum motor force, usually in newtons
    /// </summary>
    public float MaxMotorForce
    {
        get => _internal.MaxMotorForce;
        set => _internal.MaxMotorForce = value;
    }
    
    /// <summary>
    /// The desired motor speed, usually in meters per second
    /// </summary>
    public float MotorSpeed
    {
        get => _internal.MotorSpeed;
        set => _internal.MotorSpeed = value;
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
    /// Use this to store application specific shape data.
    /// </summary>
    public object? UserData
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