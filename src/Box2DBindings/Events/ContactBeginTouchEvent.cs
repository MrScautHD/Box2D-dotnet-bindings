using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A begin touch event is generated when two shapes begin touching.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ContactBeginTouchEvent
{
    /// <summary>
    /// The first shape
    /// </summary>
    [FieldOffset(0)]
    public Shape ShapeA;

    /// <summary>
    /// The second shape
    /// </summary>
    [FieldOffset(8)]
    public Shape ShapeB;

    /// <summary>
    /// The initial contact manifold. This is recorded before the solver is called,
    /// so all the impulses will be zero.
    /// </summary>
    [FieldOffset(16)]
    public Manifold manifold;
}