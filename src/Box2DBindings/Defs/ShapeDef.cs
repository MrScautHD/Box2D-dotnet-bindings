using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Used to create a shape.
/// This is a temporary object used to bundle shape creation parameters. You may use
/// the same shape definition to create multiple shapes.
/// </summary>
public class ShapeDef
{
    internal ShapeDefInternal _internal;
 
    public ShapeDef()
    {
        _internal = ShapeDefInternal.Default;
    }
    
    ~ShapeDef()
    {
        Box2D.FreeHandle(_internal.UserData);
    }
    
    /// <summary>
    /// Use this to store application specific shape data.
    /// </summary>
    public object? UserData
    {
        get => Box2D.GetObjectAtPointer(_internal.UserData);
        set => Box2D.SetObjectAtPointer(ref _internal.UserData, value);
    }

    /// <summary>
    /// The Coulomb (dry) friction coefficient, usually in the range [0,1].
    /// </summary>
    public float Friction
    {
        get => _internal.Friction;
        set => _internal.Friction = value;
    }

    /// <summary>
    /// The coefficient of restitution (bounce) usually in the range [0,1].<br/>
    /// https://en.wikipedia.org/wiki/Coefficient_of_restitution
    /// </summary>
    public float Restitution
    {
        get => _internal.Restitution;
        set => _internal.Restitution = value;
    }

    /// <summary>
    /// The rolling resistance usually in the range [0,1].
    /// </summary>
    public float RollingResistance
    {
        get => _internal.RollingResistance;
        set => _internal.RollingResistance = value;
    }

    /// <summary>
    /// The tangent speed for conveyor belts
    /// </summary>
    public float TangentSpeed
    {
        get => _internal.TangentSpeed;
        set => _internal.TangentSpeed = value;
    }

    /// <summary>
    /// User material identifier. This is passed with query results and to friction and restitution
    /// combining functions. It is not used internally.
    /// </summary>
    public int Material
    {
        get => _internal.Material;
        set => _internal.Material = value;
    }

    /// <summary>
    /// The density, usually in kg/m².
    /// </summary>
    public float Density
    {
        get => _internal.Density;
        set => _internal.Density = value;
    }

    /// <summary>
    /// Collision filtering data.
    /// </summary>
    public Filter Filter
    {
        get => _internal.Filter;
        set => _internal.Filter = value;
    }

    /// <summary>
    /// Custom debug draw color.
    /// </summary>
    public HexColor CustomColor
    {
        get => _internal.CustomColor;
        set => _internal.CustomColor = value;
    }
    
    /// <summary>
    /// A sensor shape generates overlap events but never generates a collision response.
    /// Sensors do not collide with other sensors and do not have continuous collision.
    /// Instead, use a ray or shape cast for those scenarios.
    /// </summary>
    public bool IsSensor
    {
        get => _internal.IsSensor;
        set => _internal.IsSensor = value;
    }

    /// <summary>
    /// Enable contact events for this shape. Only applies to kinematic and dynamic bodies. Ignored for sensors.
    /// </summary>
    public bool EnableContactEvents
    {
        get => _internal.EnableContactEvents;
        set => _internal.EnableContactEvents = value;
    }

    /// <summary>
    /// Enable hit events for this shape. Only applies to kinematic and dynamic bodies. Ignored for sensors.
    /// </summary>
    public bool EnableHitEvents
    {
        get => _internal.EnableHitEvents;
        set => _internal.EnableHitEvents = value;
    }

    /// <summary>
    /// Enable pre-solve contact events for this shape. Only applies to dynamic bodies. These are expensive
    /// and must be carefully handled due to threading. Ignored for sensors.
    /// </summary>
    public bool EnablePreSolveEvents
    {
        get => _internal.EnablePreSolveEvents;
        set => _internal.EnablePreSolveEvents = value;
    }

    /// <summary>
    /// Normally shapes on static bodies don't invoke contact creation when they are added to the world. This overrides
    /// that behavior and causes contact creation. This significantly slows down static body creation which can be important
    /// when there are many static shapes.
    /// This is implicitly always true for sensors, dynamic bodies, and kinematic bodies.
    /// </summary>
    public bool InvokeContactCreation
    {
        get => _internal.InvokeContactCreation;
        set => _internal.InvokeContactCreation = value;
    }

    /// <summary>
    /// Should the body update the mass properties when this shape is created. Default is true.
    /// </summary>
    public bool UpdateBodyMass
    {
        get => _internal.UpdateBodyMass;
        set => _internal.UpdateBodyMass = value;
    }

}