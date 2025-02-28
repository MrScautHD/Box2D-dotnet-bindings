using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Contact events are buffered in the Box2D world and are available
/// as event arrays after the time step is complete.
/// <i>Note: these may become invalid if bodies and/or shapes are destroyed</i>
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public unsafe struct ContactEvents
{
    [FieldOffset(0)]
    private nint beginEvents;
	
    /// <summary>
    /// Array of begin touch events
    /// </summary>
    public ReadOnlySpan<ContactBeginTouchEvent> BeginEvents => new((ContactBeginTouchEvent*)beginEvents, beginCount);

    [FieldOffset(8)]
    private nint endEvents;
	
    /// <summary>
    /// Array of end touch events
    /// </summary>
    public ReadOnlySpan<ContactEndTouchEvent> EndEvents => new((ContactEndTouchEvent*)endEvents, endCount);

    [FieldOffset(16)]
    private nint hitEvents;
	
    /// <summary>
    /// Array of hit events
    /// </summary>
    public ReadOnlySpan<ContactHitEvent> HitEvents => new((ContactHitEvent*)hitEvents, hitCount);

    /// Number of begin touch events
    [FieldOffset(24)]
    private int beginCount;

    /// Number of end touch events
    [FieldOffset(28)]
    private int endCount;

    /// Number of hit events
    [FieldOffset(32)]
    private int hitCount;
}