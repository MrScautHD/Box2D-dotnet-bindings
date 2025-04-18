using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// This struct holds callbacks you can implement to draw a Box2D world.
/// This structure should be zero initialized.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct DebugDraw
{
    /// <summary>
    /// Callback function to draw a closed polygon provided in CCW order.
    /// </summary>
    [FieldOffset(0)]
    public DrawPolygonDelegate DrawPolygon;

    /// <summary>
    /// Callback function to draw a solid closed polygon provided in CCW order.
    /// </summary>
    [FieldOffset(8)]
    public DrawSolidPolygonDelegate DrawSolidPolygon;

    /// <summary>
    /// Callback function to draw a circle.
    /// </summary>
    [FieldOffset(16)]
    public DrawCircleDelegate DrawCircle;

    /// <summary>
    /// Callback funciton to draw a solid circle.
    /// </summary>
    [FieldOffset(24)]
    public DrawSolidCircleDelegate DrawSolidCircle;
    
    /// <summary>
    /// Callback function to draw a solid capsule.
    /// </summary>
    [FieldOffset(32)]
    public DrawSolidCapsuleDelegate DrawSolidCapsule;

    /// <summary>
    /// Callback function to draw a line segment.
    /// </summary>
    [FieldOffset(40)]
    public DrawSegmentDelegate DrawSegment;

    /// <summary>
    /// Callback function to draw a transform. Choose your own length scale.
    /// </summary>
    [FieldOffset(48)]
    public DrawTransformDelegate DrawTransform;

    /// <summary>
    /// Callback function to draw a point.
    /// </summary>
    [FieldOffset(56)]
    public DrawPointDelegate DrawPoint;

    /// <summary>
    /// Callback function to draw a string in world space
    /// </summary>
    [FieldOffset(64)]
    public DrawStringDelegate DrawString;

    /// <summary>
    /// Callback function to draw an axis-aligned bounding box.
    /// </summary>
    [FieldOffset(72)]
    public AABB DrawingBounds;

    /// <summary>
    /// Option to restrict drawing to a rectangular region. May suffer from unstable depth sorting.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(88)]
    public bool UseDrawingBounds;

    /// <summary>
    /// Option to draw shapes
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(89)]
    public bool DrawShapes;

    /// <summary>
    /// Option to draw joints
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(90)]
    public bool DrawJoints;

    /// <summary>
    /// Option to draw additional information for joints
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(91)]
    public bool DrawJointExtras;

    /// <summary>
    /// Option to draw the bounding boxes for shapes
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(92)]
    public bool DrawBounds;

    /// <summary>
    /// Option to draw the mass and center of mass of dynamic bodies
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(93)]
    public bool DrawMass;

    /// <summary>
    /// Option to draw body names
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(94)]
    public bool DrawBodyNames;

    /// <summary>
    /// Option to draw contact points
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(95)]
    public bool DrawContacts;

    /// <summary>
    /// Option to visualize the graph coloring used for contacts and joints
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(96)]
    public bool DrawGraphColors;

    /// <summary>
    /// Option to draw contact normals
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(97)]
    public bool DrawContactNormals;

    /// <summary>
    /// Option to draw contact normal impulses
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(98)]
    public bool DrawContactImpulses;
    
    /// <summary>
    /// Option to draw contact friction impulses
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(99)]
    public bool DrawFrictionImpulses;

    /// <summary>
    /// Option to draw contact feature ids
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(100)]
    public bool DrawContactFeatures;
    
    /// <summary>
    /// Option to draw contact friction impulses
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(101)]
    public bool DrawIslands;
    
    /// <summary>
    /// User context that is passed as an argument to drawing callback functions
    /// </summary>
    [FieldOffset(104)] // align to next 4 byte boundary
    public nint context;
    
    public DebugDraw()
    {
        this = DefaultDebugDraw();
    }

    /// <summary>
    /// The default debug draw settings.
    /// </summary>
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultDebugDraw")]
    public static extern DebugDraw DefaultDebugDraw();


    


#region Delegates
    
    /// <summary>
    /// Draw a circle.
    /// </summary>
    /// <param name="center">The circle center</param>
    /// <param name="radius">The radius</param>
    /// <param name="color">The color</param>
    /// <param name="context">The context</param>
    public delegate void DrawCircleDelegate(Vec2 center, float radius, HexColor color, nint context);
    
    /// <summary>
    /// Draw a point.
    /// </summary>
    /// <param name="p">The point</param>
    /// <param name="size">The size</param>
    /// <param name="color">The color</param>
    /// <param name="context">The context</param>
    public delegate void DrawPointDelegate(Vec2 p, float size, HexColor color, nint context);
    
    /// <summary>
    /// Draw a closed polygon provided in CCW order.
    /// </summary>
    /// <param name="vertices">The vertices</param>
    /// <param name="vertexCount">The vertex count</param>
    /// <param name="color">The color</param>
    /// <param name="context">The context</param>
    public unsafe delegate void DrawPolygonDelegate(in Vec2* vertices, int vertexCount, HexColor color, nint context);
    
    /// <summary>
    /// Draw a line segment.
    /// </summary>
    /// <param name="p1">The first point</param>
    /// <param name="p2">The second point</param>
    /// <param name="color">The color</param>
    /// <param name="context">The context</param>
    public delegate void DrawSegmentDelegate(Vec2 p1, Vec2 p2, HexColor color, nint context);
    
    /// <summary>
    /// Draw a solid capsule.
    /// </summary>
    /// <param name="p1">The first point</param>
    /// <param name="p2">The second point</param>
    /// <param name="radius">The radius</param>
    /// <param name="color">The color</param>
    /// <param name="context">The context</param>
    public delegate void DrawSolidCapsuleDelegate(Vec2 p1, Vec2 p2, float radius, HexColor color, nint context);
    
    
    /// <summary>
    /// Draw a solid circle.
    /// </summary>
    /// <param name="transform">The transform</param>
    /// <param name="radius">The radius</param>
    /// <param name="color">The color</param>
    /// <param name="context">The context</param>
    public delegate void DrawSolidCircleDelegate(Transform transform, float radius, HexColor color, nint context);
    
    /// <summary>
    /// Draw a solid closed polygon provided in CCW order.
    /// </summary>
    /// <param name="transform">The transform</param>
    /// <param name="vertices">The vertices</param>
    /// <param name="vertexCount">The vertex count</param>
    /// <param name="radius">The radius</param>
    /// <param name="color">The color</param>
    /// <param name="context">The context</param>
    public unsafe delegate void DrawSolidPolygonDelegate(Transform transform, in Vec2* vertices, int vertexCount, float radius, HexColor color, nint context);
    
    /// <summary>
    /// Draw a string in world space
    /// </summary>
    /// <param name="p">The point</param>
    /// <param name="s">The string</param>
    /// <param name="color">The color</param>
    /// <param name="context">The context</param>
    public delegate void DrawStringDelegate(Vec2 p, string s, HexColor color, nint context);
    
    /// <summary>
    /// Draw a transform.
    /// </summary>
    /// <param name="transform">The transform</param>
    /// <param name="context">The context</param>
    /// <remarks>Choose your own length scale</remarks>
    public delegate void DrawTransformDelegate(Transform transform, nint context);
    
    #endregion
}