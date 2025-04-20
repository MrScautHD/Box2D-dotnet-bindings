using System.Runtime.InteropServices;

namespace Box2D.Character_Movement;

/// <summary>
/// These are collision planes that can be fed to b2SolvePlanes. Normally
/// this is assembled by the user from plane results in b2PlaneResult.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct CollisionPlane
{
    /// <summary>
    /// The collision plane between the mover and some shape.
    /// </summary>
    public Plane Plane;

    /// <summary>
    /// Setting this to FLT_MAX makes the plane as rigid as possible. Lower values can
    /// make the plane collision soft. Usually in meters.
    /// </summary>
    public float PushLimit;

    /// <summary>
    /// The push on the mover determined by b2SolvePlanes. Usually in meters.
    /// </summary>
    public float Push;

    /// <summary>
    /// Indicates if b2ClipVector should clip against this plane. Should be false for soft collision.
    /// </summary>
    [MarshalAs(UnmanagedType.I1)]
    public bool ClipVelocity;
}