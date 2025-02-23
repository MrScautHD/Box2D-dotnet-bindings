using System;
using System.Runtime.InteropServices;

namespace Box2D
{
    [StructLayout(LayoutKind.Explicit)]
    struct BodyId : IEquatable<BodyId>
    {
        [FieldOffset(0)]
        internal int index1;
        [FieldOffset(4)]
        internal ushort world0;
        [FieldOffset(6)]
        internal ushort generation;
        
        public bool Equals(BodyId other) => index1 == other.index1 && world0 == other.world0 && generation == other.generation;
        public override bool Equals(object? obj) => obj is BodyId other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(index1, world0, generation);
    }
}
