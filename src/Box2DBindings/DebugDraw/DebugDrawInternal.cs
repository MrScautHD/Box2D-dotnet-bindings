using Box2D.Delegates.Unsafe;
using System.Runtime.InteropServices;

namespace Box2D
{
    /// <summary>
    /// This struct holds callbacks you can implement to draw a Box2D world.
    /// This structure should be zero initialized.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct DebugDrawInternal
    {
        /// <summary>
        /// Callback function to draw a closed polygon provided in CCW order.
        /// </summary>
        [FieldOffset(0)]
        internal DrawPolygonDelegate DrawPolygon;

        /// <summary>
        /// Callback function to draw a solid closed polygon provided in CCW order.
        /// </summary>
        [FieldOffset(8)]
        internal DrawSolidPolygonDelegate DrawSolidPolygon;
    
        /// <summary>
        /// Callback function to draw a circle.
        /// </summary>
        [FieldOffset(16)]
        internal DrawCircleDelegate DrawCircle;
    
        /// <summary>
        /// Callback function to draw a solid circle.
        /// </summary>
        [FieldOffset(24)]
        internal DrawSolidCircleDelegate DrawSolidCircle;
    
        /// <summary>
        /// Callback function to draw a solid capsule.
        /// </summary>
        [FieldOffset(32)]
        internal DrawSolidCapsuleDelegate DrawSolidCapsule;
    
        /// <summary>
        /// Callback function to draw a line segment.
        /// </summary>
        [FieldOffset(40)]
        internal DrawSegmentDelegate DrawSegment;

        /// <summary>
        /// Callback function to draw a transform. Choose your own length scale.
        /// </summary>
        [FieldOffset(48)]
        internal DrawTransformDelegate DrawTransform;

        /// <summary>
        /// Callback function to draw a point.
        /// </summary>
        [FieldOffset(56)]
        internal DrawPointDelegate DrawPoint;

        /// <summary>
        /// Callback function to draw a string in world space
        /// </summary>
        [FieldOffset(64)]
        internal DrawStringDelegate DrawString;

        /// <summary>
        /// Drawing bounds
        /// </summary>
        [FieldOffset(72)]
        internal AABB DrawingBounds;

        /// <summary>
        /// Option to restrict drawing to a rectangular region. May suffer from unstable depth sorting.
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(88)]
        internal bool UseDrawingBounds;

        /// <summary>
        /// Option to draw shapes
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(89)]
        internal bool DrawShapes;

        /// <summary>
        /// Option to draw joints
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(90)]
        internal bool DrawJoints;

        /// <summary>
        /// Option to draw additional information for joints
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(91)]
        internal bool DrawJointExtras;

        /// <summary>
        /// Option to draw the bounding boxes for shapes
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(92)]
        internal bool DrawBounds;

        /// <summary>
        /// Option to draw the mass and center of mass of dynamic bodies
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(93)]
        internal bool DrawMass;

        /// <summary>
        /// Option to draw body names
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(94)]
        internal bool DrawBodyNames;

        /// <summary>
        /// Option to draw contact points
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(95)]
        internal bool DrawContacts;

        /// <summary>
        /// Option to visualize the graph coloring used for contacts and joints
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(96)]
        internal bool DrawGraphColors;

        /// <summary>
        /// Option to draw contact normals
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(97)]
        internal bool DrawContactNormals;

        /// <summary>
        /// Option to draw contact normal impulses
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(98)]
        internal bool DrawContactImpulses;
    
        /// <summary>
        /// Option to draw contact friction impulses
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(99)]
        internal bool DrawFrictionImpulses;

        /// <summary>
        /// Option to draw contact feature ids
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(100)]
        internal bool DrawContactFeatures;
    
        /// <summary>
        /// Option to draw contact friction impulses
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(101)]
        internal bool DrawIslands;
    
        /// <summary>
        /// User context that is passed as an argument to drawing callback functions
        /// </summary>
        [FieldOffset(104)] // align to next 4 byte boundary
        internal nint context;
    
        public DebugDrawInternal()
        {
            this = DefaultDebugDraw();
        }

        /// <summary>
        /// The default debug draw settings.
        /// </summary>
        [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultDebugDraw")]
        public static extern DebugDrawInternal DefaultDebugDraw();

    }
}