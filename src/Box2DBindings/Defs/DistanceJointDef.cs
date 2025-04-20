using JetBrains.Annotations;

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
    
    /// <summary>
    /// The first attached body
    /// </summary>
    [PublicAPI]
    public ref Body BodyA => ref _internal.BodyA;

    /// <summary>
    /// The second attached body
    /// </summary>
    [PublicAPI]
    public ref Body BodyB => ref _internal.BodyB;

    /// <summary>
    /// The local anchor point relative to bodyA's origin
    /// </summary>
    [PublicAPI]
    public ref Vec2 LocalAnchorA => ref _internal.LocalAnchorA;

    /// <summary>
    /// The local anchor point relative to bodyB's origin
    /// </summary>
    [PublicAPI]
    public ref Vec2 LocalAnchorB => ref _internal.LocalAnchorB;

    /// <summary>
    /// The rest length of this joint. Clamped to a stable minimum value.
    /// </summary>
    [PublicAPI]
    public ref float Length => ref _internal.Length;

    /// <summary>
    /// Enable the distance constraint to behave like a spring. If false
    /// then the distance joint will be rigid, overriding the limit and motor.
    /// </summary>
    [PublicAPI]
    public ref bool EnableSpring => ref _internal.EnableSpring;

    /// <summary>
    /// The spring linear stiffness Hertz, cycles per second
    /// </summary>
    [PublicAPI]
    public ref float Hertz => ref _internal.Hertz;

    /// <summary>
    /// The spring linear damping ratio, non-dimensional
    /// </summary>
    [PublicAPI]
    public ref float DampingRatio => ref _internal.DampingRatio;

    /// <summary>
    /// Enable/disable the joint limit
    /// </summary>
    [PublicAPI]
    public ref bool EnableLimit => ref _internal.EnableLimit;

    /// <summary>
    /// Minimum length. Clamped to a stable minimum value.
    /// </summary>
    [PublicAPI]
    public ref float MinLength => ref _internal.MinLength;

    /// <summary>
    /// Maximum length. Must be greater than or equal to the minimum length.
    /// </summary>
    [PublicAPI]
    public ref float MaxLength => ref _internal.MaxLength;

    /// <summary>
    /// Enable/disable the joint motor
    /// </summary>
    [PublicAPI]
    public ref bool EnableMotor => ref _internal.EnableMotor;

    /// <summary>
    /// The maximum motor force, usually in newtons
    /// </summary>
    [PublicAPI]
    public ref float MaxMotorForce => ref _internal.MaxMotorForce;

    /// <summary>
    /// The desired motor speed, usually in meters per second
    /// </summary>
    [PublicAPI]
    public ref float MotorSpeed => ref _internal.MotorSpeed;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide
    /// </summary>
    [PublicAPI]
    public ref bool CollideConnected => ref _internal.CollideConnected;

    /// <summary>
    /// Use this to store application specific shape data.
    /// </summary>
    [PublicAPI]
    public object? UserData
    {
        get => GetObjectAtPointer(_internal.UserData);
        set => SetObjectAtPointer(ref _internal.UserData, value);
    }
}