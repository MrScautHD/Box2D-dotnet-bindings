using System;
using System.Runtime.InteropServices;

namespace Box2D
{
    [StructLayout(LayoutKind.Explicit)]
    public struct AABB : IEquatable<AABB>
    {
        [FieldOffset(0)]
        public Vec2 LowerBound;
        [FieldOffset(8)]
        public Vec2 UpperBound;
    
        public float Width => UpperBound.X - LowerBound.X;
        public float Height => UpperBound.Y - LowerBound.Y;
    
        public override string ToString()
        {
            return $"AABB(Lower: {LowerBound}, Upper: {UpperBound}, Width: {Width}, Height: {Height})";
        }
        public bool Equals(AABB other) =>
            LowerBound.Equals(other.LowerBound) && UpperBound.Equals(other.UpperBound);
        
        public override bool Equals(object? obj) => obj is AABB other && Equals(other);
        
        public override int GetHashCode() =>
            HashCode.Combine(LowerBound, UpperBound);
        
        public static AABB MakeAABB(ReadOnlySpan<Vec2> points, float radius)
        {
            if (points is not { Length: not 0 })
                throw new ArgumentNullException(nameof(points));

            var aabb = new AABB
            {
                LowerBound = points[0],
                UpperBound = points[0]
            };

            for (int i = 1; i < points.Length; ++i)
            {
                aabb.LowerBound = Vec2.Min(aabb.LowerBound, points[i]);
                aabb.UpperBound = Vec2.Max(aabb.UpperBound, points[i]);
            }

            var r = new Vec2(radius, radius);
            aabb.LowerBound -= r;
            aabb.UpperBound += r;

            return aabb;
        }
    }
}