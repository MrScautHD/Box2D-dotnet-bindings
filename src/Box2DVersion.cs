using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Box2DVersion
{
    /// Significant changes
    int major;

    /// Incremental changes
    int minor;

    /// Bug fixes
    int revision;
}
