using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Input for ShapeDistance
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct DistanceInput
{
    /// <summary>
    /// The proxy for shape A
    /// </summary>
    [FieldOffset(0)]
    public ShapeProxy ProxyA;

    /// <summary>
    /// The proxy for shape B
    /// </summary>
    [FieldOffset(16)]
    public ShapeProxy ProxyB;

    /// <summary>
    /// The world transform for shape A
    /// </summary>
    [FieldOffset(32)]
    public Transform TransformA;

    /// <summary>
    /// The world transform for shape B
    /// </summary>
    [FieldOffset(48)]
    public Transform TransformB;

    /// <summary>
    /// Should the proxy radius be considered?
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(64)]
    public bool UseRadii;
}