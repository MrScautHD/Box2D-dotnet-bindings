namespace Box2D;

/// <summary>
/// This function receives proxies found in the AABB query.
/// </summary>
/// <param name="proxyId">The proxy ID</param>
/// <param name="userData">The user data</param>
/// <param name="context">The context</param>
/// <returns>True if the query should continue</returns>
public delegate bool TreeQueryCallback(int proxyId, int userData, nint context);