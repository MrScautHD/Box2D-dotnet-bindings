using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct Box2DVersion
{
    /// <summary>
    /// Significant changes
    /// </summary>
    public readonly int Major;

    /// <summary>
    /// Incremental changes
    /// </summary>
    public readonly int Minor;

    /// <summary>
    /// Bug fixes
    /// </summary>
    public readonly int Revision;
}
