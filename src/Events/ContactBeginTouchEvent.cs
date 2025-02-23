using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A begin touch event is generated when two shapes begin touching.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct ContactBeginTouchEvent
{
    /// <summary>
    /// The first shape
    /// </summary>
    public Shape ShapeA;

    /// <summary>
    /// The second shape
    /// </summary>
    public Shape ShapeB;

    /// <summary>
    /// The initial contact manifold. This is recorded before the solver is called,
    /// so all the impulses will be zero.
    /// </summary>
    public Manifold manifold;
}