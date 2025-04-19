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
    private BodyMoveEvent* moveEvents;

    /// <summary>
    /// Array of move events
    /// </summary>
    public ReadOnlySpan<BodyMoveEvent> MoveEvents => new(moveEvents, moveCount);
    
    [FieldOffset(8)]
    private int moveCount;
}