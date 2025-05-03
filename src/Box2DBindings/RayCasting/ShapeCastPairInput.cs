using JetBrains.Annotations;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Input parameters for ShapeCast
/// </summary>
[StructLayout(LayoutKind.Sequential)]
[PublicAPI]
public struct ShapeCastPairInput
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
    /// The translation of shape B
    /// </summary>
    public Vec2 TranslationB;

    /// <summary>
    /// The fraction of the translation to consider, typically 1
    /// </summary>
    public float MaxFraction;
    
    private byte canEncroach;
    
    /// <summary>
    /// Allows shapes with a radius to move slightly closer if already touching
    /// </summary>
    public bool CanEncroach
    {
        get => canEncroach != 0;
        set => canEncroach = value ? (byte)1 : (byte)0;
    }
}