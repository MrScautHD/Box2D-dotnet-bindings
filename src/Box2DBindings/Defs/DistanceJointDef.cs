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
    public ref Body BodyA => ref _internal.BodyA;

    /// <summary>
    /// The second attached body
    /// </summary>
    public ref Body BodyB => ref _internal.BodyB;

    /// <summary>
    /// The local anchor point relative to bodyA's origin
    /// </summary>
    public ref Vec2 LocalAnchorA => ref _internal.LocalAnchorA;

    /// <summary>
    /// The local anchor point relative to bodyB's origin
    /// </summary>
    public ref Vec2 LocalAnchorB => ref _internal.LocalAnchorB;

    /// <summary>
    /// The rest length of this joint. Clamped to a stable minimum value.
    /// </summary>
    public ref float Length => ref _internal.Length;

    /// <summary>
    /// Enable the distance constraint to behave like a spring. If false
    /// then the distance joint will be rigid, overriding the limit and motor.
    /// </summary>
    public ref bool EnableSpring => ref _internal.EnableSpring;

    /// <summary>
    /// The spring linear stiffness Hertz, cycles per second
    /// </summary>
    public ref float Hertz => ref _internal.Hertz;

    /// <summary>
    /// The spring linear damping ratio, non-dimensional
    /// </summary>
    public ref float DampingRatio => ref _internal.DampingRatio;

    /// <summary>
    /// Enable/disable the joint limit
    /// </summary>
    public ref bool EnableLimit => ref _internal.EnableLimit;

    /// <summary>
    /// Minimum length. Clamped to a stable minimum value.
    /// </summary>
    public ref float MinLength => ref _internal.MinLength;

    /// <summary>
    /// Maximum length. Must be greater than or equal to the minimum length.
    /// </summary>
    public ref float MaxLength => ref _internal.MaxLength;

    /// <summary>
    /// Enable/disable the joint motor
    /// </summary>
    public ref bool EnableMotor => ref _internal.EnableMotor;

    /// <summary>
    /// The maximum motor force, usually in newtons
    /// </summary>
    public ref float MaxMotorForce => ref _internal.MaxMotorForce;

    /// <summary>
    /// The desired motor speed, usually in meters per second
    /// </summary>
    public ref float MotorSpeed => ref _internal.MotorSpeed;

    /// <summary>
    /// Set this flag to true if the attached bodies should collide
    /// </summary>
    public ref bool CollideConnected => ref _internal.CollideConnected;

    /// <summary>
    /// Use this to store application specific shape data.
    /// </summary>
    public object? UserData
    {
        get => Core.GetObjectAtPointer(_internal.UserData);
        set => Core.SetObjectAtPointer(ref _internal.UserData, value);
    }
}