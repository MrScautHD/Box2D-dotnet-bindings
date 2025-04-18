using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A solid capsule can be viewed as two semicircles connected
/// by a rectangle.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Capsule
{
    /// <summary>
    /// Local center of the first semicircle
    /// </summary>
    [FieldOffset(0)]
    public Vec2 Center1;

    /// <summary>
    /// Local center of the second semicircle
    /// </summary>
    [FieldOffset(8)]
    public Vec2 Center2;

    /// <summary>
    /// The radius of the semicircles
    /// </summary>
    [FieldOffset(16)]
    public float Radius;
    
    /// <summary>
    /// Compute mass properties of a capsule
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeCapsuleMass")]
    private static extern MassData ComputeCapsuleMass(in Capsule shape, float density);

    /// <summary>
    /// Compute mass properties of this capsule
    /// </summary>
    public MassData ComputeMass(float density) => ComputeCapsuleMass(in this, density);
    
    /// <summary>
    /// Compute the bounding box of a transformed capsule
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeCapsuleAABB")]
    private static extern AABB ComputeCapsuleAABB(in Capsule shape, Transform transform);
    
    /// <summary>
    /// Compute the bounding box of this transformed capsule
    /// </summary>
    public AABB ComputeAABB(in Transform transform) => ComputeCapsuleAABB(in this, transform);
    
    /// <summary>
    /// Test a point for overlap with a capsule in local space
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInCapsule")]
    private static extern bool PointInCapsule(Vec2 point, in Capsule shape);
    
    /// <summary>
    /// Test a point for overlap with this capsule in local space
    /// </summary>
    public bool TestPoint(in Vec2 point) => PointInCapsule(point, in this);
    
    /// <summary>
    /// Ray cast versus capsule shape in local space. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastCapsule")]
    private static extern CastOutput RayCastCapsule(in RayCastInput input, in Capsule shape);
    
    /// <summary>
    /// Ray cast versus this capsule shape in local space. Initial overlap is treated as a miss.
    /// </summary>
    public CastOutput RayCast(in RayCastInput input) => RayCastCapsule(in input, in this);

    /// <summary>
    /// Shape cast versus a capsule. Initial overlap is treated as a miss.
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastCapsule")]
    private static extern CastOutput ShapeCastCapsule(in ShapeCastInputInternal input, in Capsule shape);

    /// <summary>
    /// Shape cast versus this capsule. Initial overlap is treated as a miss.
    /// </summary>
    public CastOutput ShapeCast(in ShapeCastInput input) => ShapeCastCapsule(in input._internal, in this);

}