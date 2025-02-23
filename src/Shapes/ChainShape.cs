using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
public struct ChainShape
{
    [FieldOffset(0)]
    private int index1;
    [FieldOffset(4)]
    private ushort world0;
    [FieldOffset(6)]
    private ushort generation;
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyChain")]
    private static extern void b2DestroyChain(ChainShape chainId);
    
    /// <summary>
    /// Destroys this chain shape
    /// </summary>
    /// <remarks>This will remove the chain shape from the world and destroy all contacts associated with this shape</remarks>
    public void Destroy() => b2DestroyChain(this);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetWorld")]
    private static extern World b2Chain_GetWorld(ChainShape chainId);
    
    /// <summary>
    /// Gets the world that owns this chain shape
    /// </summary>
    /// <returns>The world that owns this chain shape</returns>
    public World GetWorld() => b2Chain_GetWorld(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetSegmentCount")]
    private static extern int b2Chain_GetSegmentCount(ChainShape chainId);
    
    /// <summary>
    /// Gets the number of segments on this chain
    /// </summary>
    /// <returns>The number of segments on this chain</returns>
    public int GetSegmentCount() => b2Chain_GetSegmentCount(this);

    public int SegmentCount => GetSegmentCount();

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetSegments")]
    private static extern int b2Chain_GetSegments(ChainShape chainId, nint segmentArray, int capacity);
    
    /// <summary>
    /// Fills a user array with chain segment shape ids up to the specified capacity
    /// </summary>
    /// <param name="segmentArray">The segment array</param>
    /// <returns>The actual number of segments returned</returns>
    public int GetSegments(ref Shape[] segmentArray)
    {
        int capacity = segmentArray.Length;
        nint segmentArrayPtr = Marshal.UnsafeAddrOfPinnedArrayElement(segmentArray, 0);
        int count = b2Chain_GetSegments(this, segmentArrayPtr, capacity);
        return count;
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_SetFriction")]
    private static extern void b2Chain_SetFriction(ChainShape chainId, float friction);
    
    /// <summary>
    /// Sets the chain friction
    /// </summary>
    /// <param name="friction">The friction</param>
    public void SetFriction(float friction) => b2Chain_SetFriction(this, friction);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetFriction")]
    private static extern float b2Chain_GetFriction(ChainShape chainId);
    
    /// <summary>
    /// Gets the chain friction
    /// </summary>
    /// <returns>The chain friction</returns>
    public float GetFriction() => b2Chain_GetFriction(this);

    public float Friction
    {
        get => GetFriction();
        set => SetFriction(value);
    }
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_SetRestitution")]
    private static extern void b2Chain_SetRestitution(ChainShape chainId, float restitution);
    
    /// <summary>
    /// Sets the chain restitution (bounciness)
    /// </summary>
    /// <param name="restitution">The restitution</param>
    public void SetRestitution(float restitution) => b2Chain_SetRestitution(this, restitution);

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetRestitution")]
    private static extern float b2Chain_GetRestitution(ChainShape chainId);
    
    /// <summary>
    /// Gets the chain restitution
    /// </summary>
    /// <returns>The chain restitution</returns>
    public float GetRestitution()
    {
        return b2Chain_GetRestitution(this);
    }
    
    public float Restitution
    {
        get => GetRestitution();
        set => SetRestitution(value);
    }
    
}