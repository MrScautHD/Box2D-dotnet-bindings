#if !BOX2D_300

using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A null joint is used to disable collision between two specific bodies.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
struct NullJointDefInternal
{
    /// <summary>
    /// The first attached body.
    /// </summary>
    [FieldOffset(0)]
    public Body BodyA;
    
    /// <summary>
    /// The second attached body.
    /// </summary>
    [FieldOffset(8)]
    public Body BodyB;

    /// <summary>
    /// User data pointer
    /// </summary>
    [FieldOffset(16)]
    internal nint UserData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(24)]
    private readonly int internalValue;

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultNullJointDef")]
    private static extern NullJointDefInternal GetDefault();
    
    /// <summary>
    /// The default null joint definition.
    /// </summary>
    public static NullJointDefInternal Default => GetDefault();
    
    public NullJointDefInternal()
    {
        this = Default;
    }
}
#endif