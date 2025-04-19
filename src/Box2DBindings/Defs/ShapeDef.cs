using System;

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

    /// <summary>
    /// Use this to store application specific shape data.
    /// </summary>
    public object? UserData
    {
        get => Core.GetObjectAtPointer(_internal.UserData);
        set => Core.SetObjectAtPointer(ref _internal.UserData, value);
    }

    /// <summary>
    /// User material identifier. This is passed with query results and to friction and restitution
    /// combining functions. It is not used internally.
    /// </summary>
    public ref SurfaceMaterial Material => ref _internal.Material;

    /// <summary>
    /// The density, usually in kg/m².
    /// </summary>
    public ref float Density => ref _internal.Density;

    /// <summary>
    /// Collision filtering data.
    /// </summary>
    public ref Filter Filter => ref _internal.Filter;

    /// <summary>
    /// A sensor shape generates overlap events but never generates a collision response.
    /// Sensors do not have continuous collision. Instead, use a ray or shape cast for those scenarios.
    /// <i>Note: Sensor events are disabled by default.</i>
    /// </summary>
    public ref bool IsSensor => ref _internal.IsSensor;

    /// <summary>
    /// Enable sensor events for this shape. This applies to sensors and non-sensors. False by default, even for sensors.
    /// </summary>
    public ref bool EnableSensorEvents => ref _internal.EnableSensorEvents;

    /// <summary>
    /// Enable contact events for this shape. Only applies to kinematic and dynamic bodies. Ignored for sensors. False by default.
    /// </summary>
    public ref bool EnableContactEvents => ref _internal.EnableContactEvents;

    /// <summary>
    /// Enable hit events for this shape. Only applies to kinematic and dynamic bodies. Ignored for sensors. False by default.
    /// </summary>
    public ref bool EnableHitEvents => ref _internal.EnableHitEvents;

    /// <summary>
    /// Enable pre-solve contact events for this shape. Only applies to dynamic bodies. These are expensive
    /// and must be carefully handled due to threading. Ignored for sensors.
    /// </summary>
    public ref bool EnablePreSolveEvents => ref _internal.EnablePreSolveEvents;

    /// <summary>
    /// Normally shapes on static bodies don't invoke contact creation when they are added to the world. This overrides
    /// that behavior and causes contact creation. This significantly slows down static body creation which can be important
    /// when there are many static shapes.
    /// This is implicitly always true for sensors, dynamic bodies, and kinematic bodies.
    /// </summary>
    public ref bool InvokeContactCreation => ref _internal.InvokeContactCreation;

    /// <summary>
    /// Should the body update the mass properties when this shape is created. Default is true.
    /// </summary>
    public ref bool UpdateBodyMass => ref _internal.UpdateBodyMass;
}