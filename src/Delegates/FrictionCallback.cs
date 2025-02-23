namespace Box2D;

/// <summary>
/// Optional friction mixing callback. This intentionally provides no context objects because this is called
/// from a worker thread.
/// </summary>
/// <param name="frictionA">The friction A</param>
/// <param name="materialA">The material A</param>
/// <param name="frictionB">The friction B</param>
/// <param name="materialB">The material B</param>
/// <returns>The mixed friction</returns>
public delegate float FrictionCallback(float frictionA, int materialA, float frictionB, int materialB);