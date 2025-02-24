using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A null joint is used to disable collision between two specific bodies.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct NullJointDef
{
    [FieldOffset(0)]
    private BodyId bodyA;
    
    /// <summary>
    /// The first attached body.
    /// </summary>
    public Body? BodyA => World.GetBody(bodyA);

    [FieldOffset(8)]
    private BodyId bodyB;
    
    /// <summary>
    /// The second attached body.
    /// </summary>
    public Body? BodyB => World.GetBody(bodyB);

    /// <summary>
    /// User data pointer
    /// </summary>
    [FieldOffset(16)]
    public nint UserData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(24)]
    private readonly int internalValue = Box2D.B2_SECRET_COOKIE;
    
    public NullJointDef()
    {
        bodyA = default;
        bodyB = default;
        UserData = 0;
    }
}