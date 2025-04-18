namespace Box2D
{
    /// <summary>
    /// This function receives clipped ray cast input for a proxy. The function
    /// returns the new ray fraction.<br/>
    /// - return a value of 0 to terminate the ray cast<br/>
    /// - return a value less than input->maxFraction to clip the ray<br/>
    /// - return a value of input->maxFraction to continue the ray cast without clipping
    /// </summary>
    /// <returns>Ray cast input</returns>
    public delegate float TreeShapeCastCallbackFcn(in ShapeCastInput input, int proxyId, uint64_t userData, nint context);
}