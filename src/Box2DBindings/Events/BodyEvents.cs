using System;
using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// Body events are buffered in the Box2D world and are available
/// as event arrays after the time step is complete.
/// <i>Note: this data becomes invalid if bodies are destroyed</i>
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public unsafe struct BodyEvents
{
    [FieldOffset(0)]
    private nint moveEvents;

    /// <summary>
    /// Array of move events
    /// </summary>
    public ReadOnlySpan<BodyMoveEvent> MoveEvents => new((BodyMoveEvent*)moveEvents, moveCount);

    /// Number of move events
    [FieldOffset(8)]
    private int moveCount;
}