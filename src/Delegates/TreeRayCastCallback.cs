namespace Box2D;

/// <summary>
/// This function receives clipped ray cast input for a proxy. The function returns the new ray fraction.
/// </summary>
/// <param name="input">The ray cast input</param>
/// <param name="proxyId">The proxy ID</param>
/// <param name="userData">The user data</param>
/// <param name="context">The context</param>
/// <returns>A value of 0 to terminate the ray cast, a value less than input.MaxFraction to clip the ray, or a value of input.MaxFraction to continue the ray cast without clipping</returns>
public delegate float TreeRayCastCallback(in RayCastInput input, int proxyId, int userData, nint context);