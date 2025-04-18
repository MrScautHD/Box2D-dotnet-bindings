using System.Runtime.InteropServices;

namespace Box2D.Character_Movement
{
    /// <summary>
    /// A plane in 2D space.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Plane
    {
        /// <summary>
        /// The normal vector of the plane.
        /// </summary>
        [FieldOffset(0)]
        public Vec2 Normal;

        /// <summary>
        /// The offset of the plane.
        /// </summary>
        [FieldOffset(8)]
        public float Offset;
    
        [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2IsValidPlane")]
        private static extern bool IsValidPlane(Plane a);
    
        /// <summary>
        /// Checks if the plane is valid.
        /// </summary>
        /// <returns>True if the plane is valid, false otherwise.</returns>
        /// <remarks>
        /// A plane is valid if its normal is a unit vector and it is not NaN or infinity.
        /// </remarks>
        public bool IsValid()
        {
            return IsValidPlane(this);
        }
    }
}