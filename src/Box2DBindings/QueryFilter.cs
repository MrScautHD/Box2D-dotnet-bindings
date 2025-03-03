using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// The query filter is used to filter collisions between queries and shapes. For example,
/// you may want a ray-cast representing a projectile to hit players and the static environment
/// but not debris.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct QueryFilter
{
#if BOX2D_300
    
    /// <summary>
    /// The collision category bits of this query. Normally you would just set one bit.
    /// </summary>
    [FieldOffset(0)]
    public uint CategoryBits;

    /// <summary>
    /// The collision mask bits. This states the shape categories that this
    /// query would accept for collision.
    /// </summary>
    [FieldOffset(4)]
    public uint MaskBits;    
    
#else
    
    /// <summary>
    /// The collision category bits of this query. Normally you would just set one bit.
    /// </summary>
    [FieldOffset(0)]
    public ulong CategoryBits;

    /// <summary>
    /// The collision mask bits. This states the shape categories that this
    /// query would accept for collision.
    /// </summary>
    [FieldOffset(8)]
    public ulong MaskBits;

#endif    

    /// <summary>
    /// The default query filter settings.
    /// </summary>
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultQueryFilter")]
    public static extern QueryFilter DefaultQueryFilter();

    public QueryFilter()
    {
        this = DefaultQueryFilter();
    }
}