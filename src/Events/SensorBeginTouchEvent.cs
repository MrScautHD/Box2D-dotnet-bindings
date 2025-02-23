using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A begin touch event is generated when a shape starts to overlap a sensor shape.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct SensorBeginTouchEvent
{
    /// <summary>
    /// The id of the sensor shape
    /// </summary>
    [FieldOffset(0)]
    public Shape SensorShape;

    /// <summary>
    /// The id of the dynamic shape that began touching the sensor shape
    /// </summary>
    [FieldOffset(8)]
    public Shape VisitorShape;
}