#if !BOX2D_300
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A null joint is used to disable collision between two specific bodies.
/// </summary>
public class NullJointDef
{
    internal NullJointDefInternal _internal;

    public NullJointDef()
    {
        _internal = NullJointDefInternal.Default;
    }

    ~NullJointDef()
    {
        Box2D.FreeHandle(_internal.UserData);
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

#endif