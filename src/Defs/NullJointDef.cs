using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A null joint is used to disable collision between two specific bodies.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct NullJointDef
{
    /// <summary>
    /// The first attached body.
    /// </summary>
    public Body BodyA;

    /// <summary>
    /// The second attached body.
    /// </summary>
    public Body BodyB;

    /// <summary>
    /// User data pointer
    /// </summary>
    public nint UserData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    private readonly int InternalValue = Box2D.B2_SECRET_COOKIE;
    
    public NullJointDef()
    {
        BodyA = default;
        BodyB = default;
        UserData = 0;
    }
}