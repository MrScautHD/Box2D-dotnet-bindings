namespace Box2D
{
    /// <summary>
    /// This function receives proxies found in the AABB query.
    /// </summary>
    /// <returns>True if the query should continue</returns>
    public delegate bool TreeQueryCallbackFcn(int proxyId, uint64_t userData, nint context);
}