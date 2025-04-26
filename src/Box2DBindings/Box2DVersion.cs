using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct Box2DVersion
{
    /// <summary>
    /// Significant changes
    /// </summary>
    public int Major;

    /// <summary>
    /// Incremental changes
    /// </summary>
    public int Minor;

    /// <summary>
    /// Bug fixes
    /// </summary>
    public int Revision;
}
