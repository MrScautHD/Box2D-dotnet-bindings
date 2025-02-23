using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// This struct holds callbacks you can implement to draw a Box2D world.
/// This structure should be zero initialized.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct DebugDraw
{
    /// Draw a closed polygon provided in CCW order.
    //void ( *DrawPolygon )( const b2Vec2* vertices, int vertexCount, b2HexColor color, void* context );
    private nint drawPolygon;
	
    /// <summary>
    /// Draw a closed polygon provided in CCW order.
    /// </summary>
    public DrawPolygonDelegate? DrawPolygon
    {
        get => drawPolygon == 0 ? null : Marshal.GetDelegateForFunctionPointer<DrawPolygonDelegate>(drawPolygon);
        set => drawPolygon = value == null ? 0 : Marshal.GetFunctionPointerForDelegate(value);
    }

    /// Draw a solid closed polygon provided in CCW order.
    // void ( *DrawSolidPolygon )( b2Transform transform, const b2Vec2* vertices, int vertexCount, float radius, b2HexColor color,
    // 							void* context );
    private nint drawSolidPolygon;
	
    /// <summary>
    /// Draw a solid closed polygon provided in CCW order.
    /// </summary>
    public DrawSolidPolygonDelegate? DrawSolidPolygon
    {
        get => drawSolidPolygon == 0 ? null : Marshal.GetDelegateForFunctionPointer<DrawSolidPolygonDelegate>(drawSolidPolygon);
        set => drawSolidPolygon = value == null ? 0 : Marshal.GetFunctionPointerForDelegate(value);
    }
	
    /// Draw a circle.
    //void ( *DrawCircle )( b2Vec2 center, float radius, b2HexColor color, void* context );
    private nint drawCircle;
	
    /// <summary>
    /// Draw a circle.
    /// </summary>
    public DrawCircleDelegate? DrawCircle
    {
        get => drawCircle == 0 ? null : Marshal.GetDelegateForFunctionPointer<DrawCircleDelegate>(drawCircle);
        set => drawCircle = value == null ? 0 : Marshal.GetFunctionPointerForDelegate(value);
    }

    /// Draw a solid circle.
    //void ( *DrawSolidCircle )( b2Transform transform, float radius, b2HexColor color, void* context );
    private nint drawSolidCircle;
	
    /// <summary>
    /// Draw a solid circle.
    /// </summary>
    public DrawSolidCircleDelegate? DrawSolidCircle
    {
        get => drawSolidCircle == 0 ? null : Marshal.GetDelegateForFunctionPointer<DrawSolidCircleDelegate>(drawSolidCircle);
        set => drawSolidCircle = value == null ? 0 : Marshal.GetFunctionPointerForDelegate(value);
    }

    /// Draw a solid capsule.
    //void ( *DrawSolidCapsule )( b2Vec2 p1, b2Vec2 p2, float radius, b2HexColor color, void* context );
    private nint drawSolidCapsule;
	
    /// <summary>
    /// Draw a solid capsule.
    /// </summary>
    public DrawSolidCapsuleDelegate? DrawSolidCapsule
    {
        get => drawSolidCapsule == 0 ? null : Marshal.GetDelegateForFunctionPointer<DrawSolidCapsuleDelegate>(drawSolidCapsule);
        set => drawSolidCapsule = value == null ? 0 : Marshal.GetFunctionPointerForDelegate(value);
    }
	
    /// Draw a line segment.
    // void ( *DrawSegment )( b2Vec2 p1, b2Vec2 p2, b2HexColor color, void* context );
    private nint drawSegment;
	
    /// <summary>
    /// Draw a line segment.
    /// </summary>
    public DrawSegmentDelegate? DrawSegment
    {
        get => drawSegment == 0 ? null : Marshal.GetDelegateForFunctionPointer<DrawSegmentDelegate>(drawSegment);
        set => drawSegment = value == null ? 0 : Marshal.GetFunctionPointerForDelegate(value);
    }

    /// Draw a transform. Choose your own length scale.
    //void ( *DrawTransform )( b2Transform transform, void* context );
    private nint drawTransform;
	
    /// <summary>
    /// Draw a transform. Choose your own length scale.
    /// </summary>
    public DrawTransformDelegate? DrawTransform
    {
        get => drawTransform == 0 ? null : Marshal.GetDelegateForFunctionPointer<DrawTransformDelegate>(drawTransform);
        set => drawTransform = value == null ? 0 : Marshal.GetFunctionPointerForDelegate(value);
    }

    /// Draw a point.
    //void ( *DrawPoint )( b2Vec2 p, float size, b2HexColor color, void* context );
    private nint drawPoint;
	
    /// <summary>
    /// Draw a point.
    /// </summary>
    public DrawPointDelegate? DrawPoint
    {
        get => drawPoint == 0 ? null : Marshal.GetDelegateForFunctionPointer<DrawPointDelegate>(drawPoint);
        set => drawPoint = value == null ? 0 : Marshal.GetFunctionPointerForDelegate(value);
    }

    /// Draw a string in world space
    //void ( *DrawString )( b2Vec2 p, const char* s, b2HexColor color, void* context );
    private nint drawString;
	
    /// <summary>
    /// Draw a string in world space
    /// </summary>
    public DrawStringDelegate? DrawString
    {
        get => drawString == 0 ? null : Marshal.GetDelegateForFunctionPointer<DrawStringDelegate>(drawString);
        set => drawString = value == null ? 0 : Marshal.GetFunctionPointerForDelegate(value);
    }

    /// <summary>
    /// Bounds to use if restricting drawing to a rectangular region
    /// </summary>
    public AABB DrawingBounds;

    /// <summary>
    /// Option to restrict drawing to a rectangular region. May suffer from unstable depth sorting.
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool UseDrawingBounds;

    /// <summary>
    /// Option to draw shapes
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawShapes;

    /// <summary>
    /// Option to draw joints
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawJoints;

    /// <summary>
    /// Option to draw additional information for joints
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawJointExtras;

    /// <summary>
    /// Option to draw the bounding boxes for shapes
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawAABBs;

    /// <summary>
    /// Option to draw the mass and center of mass of dynamic bodies
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawMass;

    /// <summary>
    /// Option to draw body names
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawBodyNames;

    /// <summary>
    /// Option to draw contact points
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawContacts;

    /// <summary>
    /// Option to visualize the graph coloring used for contacts and joints
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawGraphColors;

    /// <summary>
    /// Option to draw contact normals
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawContactNormals;

    /// <summary>
    /// Option to draw contact normal impulses
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawContactImpulses;

    /// <summary>
    /// Option to draw contact friction impulses
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawFrictionImpulses;

    /// <summary>
    /// User context that is passed as an argument to drawing callback functions
    /// </summary>
    public nint context;
    
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
    public unsafe delegate void DrawPolygonDelegate(Vec2* vertices, int vertexCount, HexColor color, nint context);
    
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
    public unsafe delegate void DrawSolidPolygonDelegate(Transform transform, Vec2* vertices, int vertexCount, float radius, HexColor color, nint context);
    
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