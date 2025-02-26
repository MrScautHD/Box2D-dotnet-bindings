using System.Runtime.InteropServices;

namespace Box2D;

/// <summary>
/// A null joint is used to disable collision between two specific bodies.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct NullJointDef
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
    public nint UserData;

    /// <summary>
    /// Used internally to detect a valid definition. DO NOT SET.
    /// </summary>
    [FieldOffset(24)]
    private readonly int internalValue;

    [DllImport(Box2D.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultNullJointDef")]
    public static extern NullJointDef Default();
    
    public NullJointDef()
    {
        this = Default();
    }
}