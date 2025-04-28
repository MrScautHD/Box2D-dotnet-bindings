using Box2D.Delegates.Generic;
using System;
using System.Runtime.InteropServices;

namespace Box2D
{
    /// <summary>
    /// This class holds callbacks you can implement to draw a Box2D world.
    /// </summary>
    public class DebugDrawGeneric<TContext> : DebugDraw where TContext:class
    {
        private TContext context;

        public DebugDrawGeneric(TContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Callback function to draw a closed polygon provided in CCW order.
        /// </summary>
        public unsafe DrawPolygonDelegate<TContext> DrawPolygon
        {
            set
            {
                var del = value;
                var ctx = context;
                void Wrapper(Vec2* vertices, int vertexCount, HexColor color, nint _) =>
                    del(new ReadOnlySpan<Vec2>(vertices, vertexCount), color, ctx);
                _internal.DrawPolygon = Wrapper;
            }
        }

        /// <summary>
        /// Callback function to draw a solid closed polygon provided in CCW order.
        /// </summary>
        public unsafe DrawSolidPolygonDelegate<TContext> DrawSolidPolygon
        {
            set
            {
                var del = value;
                var ctx = context;
                void Wrapper(Transform transform, Vec2* vertices, int vertexCount, float radius, HexColor color, nint _) =>
                    del(transform, new ReadOnlySpan<Vec2>(vertices, vertexCount), radius, color, ctx);
                _internal.DrawSolidPolygon = Wrapper;
            }
        }

        /// <summary>
        /// Callback function to draw a circle.
        /// </summary>
        public DrawCircleDelegate<TContext> DrawCircle
        {
            set
            {
                var del = value;
                var ctx = context;
                void Wrapper(Vec2 center, float radius, HexColor color, nint _) =>
                    del(center, radius, color, ctx);
                _internal.DrawCircle = Wrapper;
            }
        }

        /// <summary>
        /// Callback function to draw a solid circle.
        /// </summary>
        public DrawSolidCircleDelegate<TContext> DrawSolidCircle
        {
            set
            {
                var del = value;
                var ctx = context;
                void Wrapper(Transform transform, float radius, HexColor color, nint _) =>
                    del(transform, radius, color, ctx);
                _internal.DrawSolidCircle = Wrapper;
            }
        }


        /// <summary>
        /// Callback function to draw a solid capsule.
        /// </summary>
        public DrawSolidCapsuleDelegate<TContext> DrawSolidCapsule
        {
            set
            {
                var del = value;
                var ctx = context;
                void Wrapper(Vec2 p1, Vec2 p2, float radius, HexColor color, nint _) =>
                    del(p1, p2, radius, color, ctx);
                _internal.DrawSolidCapsule = Wrapper;
            }
        }

        /// <summary>
        /// Callback function to draw a line segment.
        /// </summary>
        public DrawSegmentDelegate<TContext> DrawSegment
        {
            set
            {
                var del = value;
                var ctx = context;
                void Wrapper(Vec2 p1, Vec2 p2, HexColor color, nint _) =>
                    del(p1, p2, color, ctx);
                _internal.DrawSegment = Wrapper;
            }
        }

        /// <summary>
        /// Callback function to draw a transform. Choose your own length scale.
        /// </summary>
        public DrawTransformDelegate<TContext> DrawTransform
        {
            set
            {
                var del = value;
                var ctx = context;
                void Wrapper(Transform transform, nint _) =>
                    del(transform, ctx);
                _internal.DrawTransform = Wrapper;
            }
        }

        /// <summary>
        /// Callback function to draw a point.
        /// </summary>
        public DrawPointDelegate<TContext> DrawPoint
        {
            set
            {
                var del = value;
                var ctx = context;
                void Wrapper(Vec2 p, float size, HexColor color, nint _) =>
                    del(p, size, color, ctx);
                _internal.DrawPoint = Wrapper;
            }
        }

        /// <summary>
        /// Callback function to draw a string in world space
        /// </summary>
        public DrawStringDelegate<TContext> DrawString
        {
            set
            {
                var del = value;
                var ctx = context;
                void Wrapper(Vec2 p, nint s, HexColor color, nint _)
                {
                    string? str = Marshal.PtrToStringUTF8(s);
                    del(p, str, color, ctx);
                }
                _internal.DrawString = Wrapper;
            }
        }
    }
}
