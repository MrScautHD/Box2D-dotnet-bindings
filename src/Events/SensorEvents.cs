using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Sensor events are buffered in the Box2D world and are available
/// as begin/end overlap event arrays after the time step is complete.
/// Note: these may become invalid if bodies and/or shapes are destroyed
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public unsafe struct SensorEvents
{
    /// <summary>
    /// Array of sensor begin touch events
    /// </summary>
    [FieldOffset(0)]
    private nint beginEvents;

    /// <summary>
    /// Array of sensor end touch events
    /// </summary>
    [FieldOffset(8)]
    private nint endEvents;

    [FieldOffset(16)]
    private int beginCount;
	
    [FieldOffset(20)]
    private int endCount;
	
    public ReadOnlySpan<SensorBeginTouchEvent> BeginEvents => new((SensorBeginTouchEvent*)beginEvents, beginCount);

    public ReadOnlySpan<SensorEndTouchEvent> EndEvents => new((SensorEndTouchEvent*)endEvents, endCount);
}