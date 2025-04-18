using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A body definition holds all the data needed to construct a rigid body.
/// You can safely re-use body definitions. Shapes are added to a body after construction.
/// Body definitions are temporary objects used to bundle creation parameters.
/// </summary>
public class BodyDef
{
    internal BodyDefInternal _internal;
    
    public BodyDef()
    {
        _internal = new BodyDefInternal();
    }
    
    ~BodyDef()
    {
        if (_internal.Name != 0)
        {
            Marshal.FreeHGlobal(_internal.Name);
            _internal.Name = 0;
        }
    }

    /// <summary>
    /// The body type: static, kinematic, or dynamic.
    /// </summary>
    public BodyType Type
    {
        get => _internal.Type;
        set => _internal.Type = value;
    }
    
    /// <summary>
    /// The initial world position of the body. Bodies should be created with the desired position.
    /// <i>Note: Creating bodies at the origin and then moving them nearly doubles the cost of body creation, especially
    /// if the body is moved after shapes have been added.</i>
    /// </summary>
    public Vec2 Position
    {
        get => _internal.Position;
        set => _internal.Position = value;
    }
    
    /// <summary>
    /// The initial world rotation of the body.
    /// </summary>
    public Rotation Rotation
    {
        get => _internal.Rotation;
        set => _internal.Rotation = value;
    }
    
    /// <summary>
    /// The initial linear velocity of the body's origin. Usually in meters per second.
    /// </summary>
    public Vec2 LinearVelocity
    {
        get => _internal.LinearVelocity;
        set => _internal.LinearVelocity = value;
    }
    
    /// <summary>
    /// The initial angular velocity of the body. Radians per second.
    /// </summary>
    public float AngularVelocity
    {
        get => _internal.AngularVelocity;
        set => _internal.AngularVelocity = value;
    }
    
    /// <summary>
    /// Linear damping is used to reduce the linear velocity. The damping parameter
    /// can be larger than 1 but the damping effect becomes sensitive to the
    /// time step when the damping parameter is large.
    /// Generally linear damping is undesirable because it makes objects move slowly
    /// as if they are floating.
    /// </summary>
    public float LinearDamping
    {
        get => _internal.LinearDamping;
        set => _internal.LinearDamping = value;
    }
    
    /// <summary>
    /// Angular damping is used to reduce the angular velocity. The damping parameter
    /// can be larger than 1.0f but the damping effect becomes sensitive to the
    /// time step when the damping parameter is large.
    /// Angular damping can be use slow down rotating bodies.
    /// </summary>
    public float AngularDamping
    {
        get => _internal.AngularDamping;
        set => _internal.AngularDamping = value;
    }
    
    /// <summary>
    /// Scale the gravity applied to this body. Non-dimensional.
    /// </summary>
    public float GravityScale
    {
        get => _internal.GravityScale;
        set => _internal.GravityScale = value;
    }
    
    /// <summary>
    /// Sleep speed threshold, default is 0.05 meters per second
    /// </summary>
    public float SleepThreshold
    {
        get => _internal.SleepThreshold;
        set => _internal.SleepThreshold = value;
    }
    
    /// <summary>
    /// Optional body name for debugging. Up to 31 characters (excluding null termination)
    /// </summary>
    public string? Name
    {
        get => Marshal.PtrToStringAnsi(_internal.Name);
        set
        {
            if (_internal.Name != 0)
            {
                Marshal.FreeHGlobal(_internal.Name);
                _internal.Name = 0;
            }
            if (value != null)
            {
                if (value.Length > 31)
                    throw new ArgumentOutOfRangeException(nameof(value), "Name must be 31 characters or less");
                _internal.Name = Marshal.StringToHGlobalAnsi(value);
            }
        }
    }
    
    /// <summary>
    /// Use this to store application specific body data.
    /// </summary>
    public object? UserData
    {
        get => Core.GetObjectAtPointer(_internal.UserData);
        set => Core.SetObjectAtPointer(ref _internal.UserData, value);
    }

    /// <summary>
    /// Set this flag to false if this body should never fall asleep.
    /// </summary>
    public bool EnableSleep
    {
        get => _internal.EnableSleep;
        set => _internal.EnableSleep = value;
    }
    
    /// <summary>
    /// Is this body initially awake or sleeping?
    /// </summary>
    public bool IsAwake
    {
        get => _internal.IsAwake;
        set => _internal.IsAwake = value;
    }
    
    /// <summary>
    /// Should this body be prevented from rotating? Useful for characters.
    /// </summary>
    public bool FixedRotation
    {
        get => _internal.FixedRotation;
        set => _internal.FixedRotation = value;
    }
    
    /// <summary>
    /// Treat this body as high speed object that performs continuous collision detection
    /// against dynamic and kinematic bodies, but not other bullet bodies.
    /// <b>Warning: Bullets should be used sparingly. They are not a solution for general dynamic-versus-dynamic</b>
    /// continuous collision. They may interfere with joint constraints.
    /// </summary>
    public bool IsBullet
    {
        get => _internal.IsBullet;
        set => _internal.IsBullet = value;
    }
    
    /// <summary>
    /// Used to disable a body. A disabled body does not move or collide.
    /// </summary>
    public bool IsEnabled
    {
        get => _internal.IsEnabled;
        set => _internal.IsEnabled = value;
    }
    
    /// <summary>
    /// This allows this body to bypass rotational speed limits. Should only be used
    /// for circular objects, like wheels.
    /// </summary>
    public bool AllowFastRotation
    {
        get => _internal.AllowFastRotation;
        set => _internal.AllowFastRotation = value;
    }
}