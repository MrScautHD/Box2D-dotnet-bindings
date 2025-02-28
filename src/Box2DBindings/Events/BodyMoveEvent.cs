using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Body move events triggered when a body moves.
/// Triggered when a body moves due to simulation. Not reported for bodies moved by the user.
/// This also has a flag to indicate that the body went to sleep so the application can also
/// sleep that actor/entity/object associated with the body.
/// On the other hand if the flag does not indicate the body went to sleep then the application
/// can treat the actor/entity/object associated with the body as awake.
/// This is an efficient way for an application to update game object transforms rather than
/// calling functions such as Body.GetTransform() because this data is delivered as a contiguous array
/// and it is only populated with bodies that have moved.
/// <i>Note: If sleeping is disabled all dynamic and kinematic bodies will trigger move events.</i>
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct BodyMoveEvent
{
    [FieldOffset(0)]
    public Transform Transform; // 16 bytes
    
    [FieldOffset(16)]
    public Body Body;
    
    [FieldOffset(24)]
    private nint userData;
    
    public object? UserData => Box2D.GetObjectAtPointer(userData);

    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(32)]
    public bool FellAsleep;
}