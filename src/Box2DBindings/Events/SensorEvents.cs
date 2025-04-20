using JetBrains.Annotations;
using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Sensor events are buffered in the Box2D world and are available
/// as begin/end overlap event arrays after the time step is complete.
/// Note: these may become invalid if bodies and/or shapes are destroyed
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct SensorEvents
{
    private SensorBeginTouchEvent* beginEvents;

    private SensorEndTouchEvent* endEvents;

    private int beginCount;
	
    private int endCount;
	
    /// <summary>
    /// Array of sensor begin touch events
    /// </summary>
    [PublicAPI]
    public ReadOnlySpan<SensorBeginTouchEvent> BeginEvents => new(beginEvents, beginCount);

    /// <summary>
    /// Array of sensor end touch events
    /// </summary>
    [PublicAPI]
    public ReadOnlySpan<SensorEndTouchEvent> EndEvents => new(endEvents, endCount);
}