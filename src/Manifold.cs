using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A contact manifold describes the contact points between colliding shapes.
/// </summary>
/// <remarks>Box2D uses speculative collision so some contact points may be separated.</remarks>
[StructLayout(LayoutKind.Explicit)]
public struct Manifold
{
    /// <summary>
    /// The unit normal vector in world space, points from shape A to bodyB
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Normal;

    /// <summary>
    /// Angular impulse applied for rolling resistance. N * m * s = kg * m^2 / s
    /// </summary>
    [FieldOffset(8)]
    public float RollingImpulse;

    /// <summary>
    /// The manifold points, up to two are possible in 2D
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    [FieldOffset(12)]
    public ManifoldPoint[] Points; // 50 bytes each
	
    /// <summary>
    /// The number of contacts points, will be 0, 1, or 2
    /// </summary>
    [FieldOffset(112)]
    public int PointCount;
	
}