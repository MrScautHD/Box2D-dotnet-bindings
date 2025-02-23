using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Sensor events are buffered in the Box2D world and are available
/// as begin/end overlap event arrays after the time step is complete.
/// Note: these may become invalid if bodies and/or shapes are destroyed
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct SensorEvents
{
    /// <summary>
    /// Array of sensor begin touch events
    /// </summary>
    private nint beginEvents;

    /// <summary>
    /// Array of sensor end touch events
    /// </summary>
    private nint endEvents;

    private int beginCount;
	
    private int endCount;
	
    public ReadOnlySpan<SensorBeginTouchEvent> BeginEvents
    {
        get
        {
            unsafe
            {
                return new ReadOnlySpan<SensorBeginTouchEvent>((SensorBeginTouchEvent*)beginEvents, beginCount);
            }
        }
        set
        {
            unsafe
            {
                beginEvents = Marshal.AllocHGlobal(value.Length * sizeof(SensorBeginTouchEvent));
                beginCount = value.Length;
                for (int i = 0; i < value.Length; i++)
                {
                    ((SensorBeginTouchEvent*)beginEvents)[i] = value[i];
                }
            }
        }
    }
	
    public ReadOnlySpan<SensorEndTouchEvent> EndEvents
    {
        get
        {
            unsafe
            {
                return new ReadOnlySpan<SensorEndTouchEvent>((SensorEndTouchEvent*)endEvents, endCount);
            }
        }
        set
        {
            unsafe
            {
                endEvents = Marshal.AllocHGlobal(value.Length * sizeof(SensorEndTouchEvent));
                endCount = value.Length;
                for (int i = 0; i < value.Length; i++)
                {
                    ((SensorEndTouchEvent*)endEvents)[i] = value[i];
                }
            }
        }
    }
}