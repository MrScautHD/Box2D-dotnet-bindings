using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Input for ShapeDistance
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct DistanceInput
{
    /// <summary>
    /// The proxy for shape A
    /// </summary>
    public ShapeProxy ProxyA;

    /// <summary>
    /// The proxy for shape B
    /// </summary>
    public ShapeProxy ProxyB;

    /// <summary>
    /// The world transform for shape A
    /// </summary>
    public Transform TransformA;

    /// <summary>
    /// The world transform for shape B
    /// </summary>
    public Transform TransformB;

    /// <summary>
    /// Should the proxy radius be considered?
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool UseRadii;
}