using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Input parameters for ShapeCast
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ShapeCastPairInput
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
    /// The translation of shape B
    /// </summary>
    [FieldOffset(64)]
    public Vec2 TranslationB;

    /// <summary>
    /// The fraction of the translation to consider, typically 1
    /// </summary>
    [FieldOffset(72)]
    public float MaxFraction;
    
    /// <summary>
    /// Allows shapes with a radius to move slightly closer if already touching
    /// </summary>
    [FieldOffset(76)]
    [MarshalAs(UnmanagedType.I1)]
    public bool CanEncroach;
}