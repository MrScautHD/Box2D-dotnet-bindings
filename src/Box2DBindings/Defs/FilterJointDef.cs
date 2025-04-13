using System;

namespace Box2D;

/// <summary>
/// The filter joint is used to disable collision between two bodies. As a side effect of being a joint, it also keeps the two bodies in the same simulation island.
/// </summary>
public class FilterJointDef
{
    internal FilterJointDefInternal _internal;

    public FilterJointDef()
    {
        _internal = FilterJointDefInternal.Default;
    }
    
    /// <summary>
    /// The first attached body.
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
    /// User data pointer
    /// </summary>
    public object? UserData
    {
        get => Box2D.GetObjectAtPointer(_internal.UserData);
        set => Box2D.SetObjectAtPointer(ref _internal.UserData, value);
    }
}
