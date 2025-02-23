using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// The query filter is used to filter collisions between queries and shapes. For example,
/// you may want a ray-cast representing a projectile to hit players and the static environment
/// but not debris.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct QueryFilter
{
    /// <summary>
    /// The collision category bits of this query. Normally you would just set one bit.
    /// </summary>
    public ulong CategoryBits = 0x00000001;

    /// <summary>
    /// The collision mask bits. This states the shape categories that this
    /// query would accept for collision.
    /// </summary>
    public ulong MaskBits = 0x00000001;
    public QueryFilter()
    { }
}