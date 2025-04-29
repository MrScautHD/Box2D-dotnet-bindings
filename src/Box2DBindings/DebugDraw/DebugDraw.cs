namespace Box2D;

/// <summary>
/// Debug Draw base class. You cannot set DebugDraw delegates with this class. Use an instance of one of these implementations:
/// <ul>
/// <li><see cref="DebugDrawSimple" /></li>
/// <li><see cref="DebugDrawGeneric{TContext}" /></li>
/// <li><see cref="DebugDrawUnsafe" /></li>
/// </ul>
/// <i>or</i> implement one of these base classes:
/// <ul>
/// <li><see cref="DebugDrawSimpleBase" /></li>
/// <li><see cref="DebugDrawGenericBase{TContext}" /></li>
/// <li><see cref="DebugDrawUnsafeBase" /></li>
/// </ul>
/// </summary>
/// <remarks>
/// Pass your DebugDraw to <see cref="World"/>.<see cref="World.Draw" /> to draw the world.
/// Abstract base classes default to all drawing options enabled.
/// </remarks>
public abstract class DebugDraw
{
    internal DebugDrawInternal @internal = new();
        
    internal abstract ref DebugDrawInternal Internal { get; }
    
    /// <summary>
    /// Drawing bounds for the debug draw.
    /// </summary>
    public ref AABB DrawingBounds => ref @internal.DrawingBounds;

    /// <summary>
    /// Option to restrict drawing to a rectangular region. May suffer from unstable depth sorting.
    /// </summary>
    public ref bool UseDrawingBounds => ref @internal.UseDrawingBounds;

    /// <summary>
    /// Option to draw shapes
    /// </summary>
    public ref bool DrawShapes => ref @internal.DrawShapes;

    /// <summary>
    /// Option to draw joints
    /// </summary>
    public ref bool DrawJoints => ref @internal.DrawJoints;

    /// <summary>
    /// Option to draw additional information for joints
    /// </summary>
    public ref bool DrawJointExtras => ref @internal.DrawJointExtras;

    /// <summary>
    /// Option to draw the bounding boxes for shapes
    /// </summary>
    public ref bool DrawBounds => ref @internal.DrawBounds;

    /// <summary>
    /// Option to draw the mass and center of mass of dynamic bodies
    /// </summary>
    public ref bool DrawMass => ref @internal.DrawMass;

    /// <summary>
    /// Option to draw body names
    /// </summary>
    public ref bool DrawBodyNames => ref @internal.DrawBodyNames;

    /// <summary>
    /// Option to draw contact points
    /// </summary>
    public ref bool DrawContacts => ref @internal.DrawContacts;

    /// <summary>
    /// Option to visualize the graph coloring used for contacts and joints
    /// </summary>
    public ref bool DrawGraphColors => ref @internal.DrawGraphColors;

    /// <summary>
    /// Option to draw contact normals
    /// </summary>
    public ref bool DrawContactNormals => ref @internal.DrawContactNormals;

    /// <summary>
    /// Option to draw contact normal impulses
    /// </summary>
    public ref bool DrawContactImpulses => ref @internal.DrawContactImpulses;

    /// <summary>
    /// Option to draw contact friction impulses
    /// </summary>
    public ref bool DrawFrictionImpulses => ref @internal.DrawFrictionImpulses;

    /// <summary>
    /// Option to draw contact feature ids
    /// </summary>
    public ref bool DrawContactFeatures => ref @internal.DrawContactFeatures;

    /// <summary>
    /// Option to draw contact friction impulses
    /// </summary>
    public ref bool DrawIslands => ref @internal.DrawIslands;
}