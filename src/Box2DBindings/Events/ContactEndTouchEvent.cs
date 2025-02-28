using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// An end touch event is generated when two shapes stop touching.
///	You will get an end event if you do anything that destroys contacts previous to the last
///	world step. These include things like setting the transform, destroying a body
///	or shape, or changing a filter or body type.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct ContactEndTouchEvent
{
    /// <summary>
    /// The first shape
    ///	<b>Warning: this shape may have been destroyed. Use Shape.IsValid</b>
    /// </summary>
    [FieldOffset(0)]
    public Shape ShapeA;

    /// <summary>
    /// The second shape
    ///	<b>Warning: this shape may have been destroyed. Use Shape.IsValid</b>
    /// </summary>
    [FieldOffset(8)]
    public Shape ShapeB;
}