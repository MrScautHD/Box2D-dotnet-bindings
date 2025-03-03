using System;
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
    
#if !BOX2D_300

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetWorld")]
    private static extern World b2Chain_GetWorld(ChainShape chainId);
    
    /// <summary>
    /// Gets the world that owns this chain shape
    /// </summary>
    /// <returns>The world that owns this chain shape</returns>
    public World GetWorld() => b2Chain_GetWorld(this);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetSegmentCount")]
    private static extern int b2Chain_GetSegmentCount(ChainShape chainId);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetSegments")]
    private static extern int b2Chain_GetSegments(ChainShape chainId, nint segmentArray, int capacity);
    
    /// <summary>
    /// The chain segments
    /// </summary>
    public Shape[] Segments
    {
        get
        {
            Shape[] segments = new Shape[b2Chain_GetSegmentCount(this)];
            nint segmentArrayPtr = Marshal.UnsafeAddrOfPinnedArrayElement(segments, 0);
            b2Chain_GetSegments(this, segmentArrayPtr, segments.Length);
            return segments;
        }
    }
    
#endif

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_SetFriction")]
    private static extern void b2Chain_SetFriction(ChainShape chainId, float friction);
#if BOX2D_300    
    /// <summary>
    /// Sets the chain friction
    /// </summary>
    /// <param name="friction">The friction</param>
    public void SetFriction(float friction) => b2Chain_SetFriction(this, friction);

#else
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetFriction")]
    private static extern float b2Chain_GetFriction(ChainShape chainId);
    
/// <summary>
/// The chain friction
/// </summary>
    public float Friction
    {
        get => b2Chain_GetFriction(this);
        set => b2Chain_SetFriction(this, value);
    }

#endif

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_SetRestitution")]
    private static extern void b2Chain_SetRestitution(ChainShape chainId, float restitution);
#if BOX2D_300
    /// <summary>
    /// Sets the chain restitution (bounciness)
    /// </summary>
    /// <param name="restitution">The restitution</param>
    public void SetRestitution(float restitution) => b2Chain_SetRestitution(this, restitution);

#else
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetRestitution")]
    private static extern float b2Chain_GetRestitution(ChainShape chainId);
    
/// <summary>
/// The chain restitution (bounciness)
/// </summary>
    public float Restitution
    {
        get => b2Chain_GetRestitution(this);
        set => b2Chain_SetRestitution(this, value);
    }

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_SetMaterial")]
    private static extern void b2Chain_SetMaterial(ChainShape chainId, int material);
    
    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_GetMaterial")]
    private static extern int b2Chain_GetMaterial(ChainShape chainId);
    
    /// <summary>
    /// The chain material
    /// </summary>
    public int Material
    {
        get => b2Chain_GetMaterial(this);
        set => b2Chain_SetMaterial(this, value);
    }
    
#endif
}