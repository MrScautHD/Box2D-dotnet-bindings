using JetBrains.Annotations;
using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Contact events are buffered in the Box2D world and are available
/// as event arrays after the time step is complete.
/// <i>Note: these may become invalid if bodies and/or shapes are destroyed</i>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ContactEvents
{
    private ContactBeginTouchEvent* beginEvents;
	
    /// <summary>
    /// Array of begin touch events
    /// </summary>
    [PublicAPI]
    public ReadOnlySpan<ContactBeginTouchEvent> BeginEvents => new(beginEvents, beginCount);

    private ContactEndTouchEvent* endEvents;
	
    /// <summary>
    /// Array of end touch events
    /// </summary>
    [PublicAPI]
    public ReadOnlySpan<ContactEndTouchEvent> EndEvents => new(endEvents, endCount);

    private ContactHitEvent* hitEvents;
	
    /// <summary>
    /// Array of hit events
    /// </summary>
    [PublicAPI]
    public ReadOnlySpan<ContactHitEvent> HitEvents => new(hitEvents, hitCount);

    /// Number of begin touch events
    private int beginCount;

    /// Number of end touch events
    private int endCount;

    /// Number of hit events
    private int hitCount;
}