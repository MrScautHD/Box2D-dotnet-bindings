using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Explicit)]
unsafe struct ChainDefInternal
{
    [FieldOffset(0)]
    internal nint UserData;

    [FieldOffset(8)]
    internal Vec2* Points;
	
    /// <summary>
    /// The point count, must be 4 or more.
    /// </summary>
    [FieldOffset(16)]
    internal int Count;

    [FieldOffset(24)]
    internal SurfaceMaterial* Materials;
	
    /// <summary>
    /// The material count. Must be 1 or count. This allows you to provide one
    /// material for all segments or a unique material per segment.
    /// </summary>
    [FieldOffset(28)]
    internal int MaterialCount;
    
    [FieldOffset(32)]
    internal Filter Filter; // 20 bytes

    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(64)]
    internal bool IsLoop;

    [MarshalAs(UnmanagedType.U1)]
    [FieldOffset(65)]
    internal bool EnableSensorEvents;
    
    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(68)]
    private readonly int internalValue;
 
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultChainDef")]
    private static extern ChainDefInternal GetDefault();
    
    /// <summary>
    /// The default chain definition.
    /// </summary>
    internal static ChainDefInternal Default => GetDefault();
    
    public ChainDefInternal()
    {
        this = Default;
    }
}