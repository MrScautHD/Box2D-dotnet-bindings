using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
public struct Box2DVersion
{
    /// <summary>
    /// Significant changes
    /// </summary>
    [FieldOffset(0)]
    public int Major;

    /// <summary>
    /// Incremental changes
    /// </summary>
    [FieldOffset(4)]
    public int Minor;

    /// <summary>
    /// Bug fixes
    /// </summary>
    [FieldOffset(8)]
    public int Revision;
}
