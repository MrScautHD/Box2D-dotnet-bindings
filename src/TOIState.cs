namespace Box2D;

/// <summary>
/// Describes the TOI output
/// </summary>
public enum TOIState : int
{
    /// <summary>
    /// Unknown state
    /// </summary>
    Unknown,

    /// <summary>
    /// Failed state
    /// </summary>
    Failed,

    /// <summary>
    /// Overlapped state
    /// </summary>
    Overlapped,

    /// <summary>
    /// Hit state
    /// </summary>
    Hit,

    /// <summary>
    /// Separated state
    /// </summary>
    Separated
}