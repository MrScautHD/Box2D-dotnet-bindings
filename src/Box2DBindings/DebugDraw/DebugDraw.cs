namespace Box2D
{
    public abstract class DebugDraw
    {
        protected internal DebugDrawInternal _internal;

        protected DebugDraw()
        {
            _internal = new DebugDrawInternal();
        }

        /// <summary>
        /// Drawing bounds for the debug draw.
        /// </summary>
        public ref AABB DrawingBounds => ref _internal.DrawingBounds;

        /// <summary>
        /// Option to restrict drawing to a rectangular region. May suffer from unstable depth sorting.
        /// </summary>
        public ref bool UseDrawingBounds => ref _internal.UseDrawingBounds;

        /// <summary>
        /// Option to draw shapes
        /// </summary>
        public ref bool DrawShapes => ref _internal.DrawShapes;

        /// <summary>
        /// Option to draw joints
        /// </summary>
        public ref bool DrawJoints => ref _internal.DrawJoints;

        /// <summary>
        /// Option to draw additional information for joints
        /// </summary>
        public ref bool DrawJointExtras => ref _internal.DrawJointExtras;

        /// <summary>
        /// Option to draw the bounding boxes for shapes
        /// </summary>
        public ref bool DrawBounds => ref _internal.DrawBounds;

        /// <summary>
        /// Option to draw the mass and center of mass of dynamic bodies
        /// </summary>
        public ref bool DrawMass => ref _internal.DrawMass;

        /// <summary>
        /// Option to draw body names
        /// </summary>
        public ref bool DrawBodyNames => ref _internal.DrawBodyNames;

        /// <summary>
        /// Option to draw contact points
        /// </summary>
        public ref bool DrawContacts => ref _internal.DrawContacts;

        /// <summary>
        /// Option to visualize the graph coloring used for contacts and joints
        /// </summary>
        public ref bool DrawGraphColors => ref _internal.DrawGraphColors;

        /// <summary>
        /// Option to draw contact normals
        /// </summary>
        public ref bool DrawContactNormals => ref _internal.DrawContactNormals;

        /// <summary>
        /// Option to draw contact normal impulses
        /// </summary>
        public ref bool DrawContactImpulses => ref _internal.DrawContactImpulses;

        /// <summary>
        /// Option to draw contact friction impulses
        /// </summary>
        public ref bool DrawFrictionImpulses => ref _internal.DrawFrictionImpulses;

        /// <summary>
        /// Option to draw contact feature ids
        /// </summary>
        public ref bool DrawContactFeatures => ref _internal.DrawContactFeatures;

        /// <summary>
        /// Option to draw contact friction impulses
        /// </summary>
        public ref bool DrawIslands => ref _internal.DrawIslands;
    }
}
