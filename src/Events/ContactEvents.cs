using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Contact events are buffered in the Box2D world and are available
/// as event arrays after the time step is complete.
/// <i>Note: these may become invalid if bodies and/or shapes are destroyed</i>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct ContactEvents
{
    private nint beginEvents;
	
    /// <summary>
    /// Array of begin touch events
    /// </summary>
    public ReadOnlySpan<ContactBeginTouchEvent> BeginEvents
    {
        get
        {
            unsafe
            {
                return new ReadOnlySpan<ContactBeginTouchEvent>((ContactBeginTouchEvent*)beginEvents, beginCount);
            }
        }
    }

	
    private nint endEvents;
	
    /// <summary>
    /// Array of end touch events
    /// </summary>
    public ReadOnlySpan<ContactEndTouchEvent> EndEvents
    {
        get
        {
            unsafe
            {
                return new ReadOnlySpan<ContactEndTouchEvent>((ContactEndTouchEvent*)endEvents, endCount);
            }
        }
    }

    private nint hitEvents;
	
    /// <summary>
    /// Array of hit events
    /// </summary>
    public ReadOnlySpan<ContactHitEvent> HitEvents
    {
        get
        {
            unsafe
            {
                return new ReadOnlySpan<ContactHitEvent>((ContactHitEvent*)hitEvents, hitCount);
            }
        }
    }

    /// Number of begin touch events
    private int beginCount;

    /// Number of end touch events
    private int endCount;

    /// Number of hit events
    private int hitCount;
}