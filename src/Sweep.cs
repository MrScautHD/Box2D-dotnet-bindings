using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// This describes the motion of a body/shape for TOI computation. Shapes are defined with respect to the body origin,
/// which may not coincide with the center of mass. However, to support dynamics we must interpolate the center of mass
/// position.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Sweep
{
    /// <summary>
    /// Local center of mass position
    /// </summary>
    [FieldOffset(0)]
    public Vec2 LocalCenter;

    /// <summary>
    /// Starting center of mass world position
    /// </summary>
    [FieldOffset(8)]
    public Vec2 C1;

    /// <summary>
    /// Ending center of mass world position
    /// </summary>
    [FieldOffset(16)]
    public Vec2 C2;

    /// <summary>
    /// Starting world rotation
    /// </summary>
    [FieldOffset(24)]
    public Rotation Q1;

    /// <summary>
    /// Ending world rotation
    /// </summary>
    [FieldOffset(32)]
    public Rotation Q2;
}