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
        if (_internal.UserData != 0)
            GCHandle.FromIntPtr(_internal.UserData).Free();
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
