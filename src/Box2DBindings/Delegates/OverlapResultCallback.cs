namespace Box2D;

/// <summary>
/// Prototype callback for overlap queries.<br/>
/// Called for each shape found in the query.<br/>
/// Return false to terminate the query.<br/>
/// </summary>
/// <param name="shape">The Shape</param>
/// <param name="context">The context</param>
/// <returns>true to continue the query, false to terminate</returns>
public delegate bool OverlapResultNintCallback(Shape shapeId, nint context);

/// <summary>
/// Prototype callback for overlap queries.<br/>
/// Called for each shape found in the query.<br/>
/// Return false to terminate the query.<br/>
/// </summary>
/// <param name="shape">The Shape</param>
/// <param name="context">The context</param>
/// <returns>true to continue the query, false to terminate</returns>
public delegate bool OverlapResultCallback<in TContext>(Shape shapeId, TContext context) where TContext : class;

/// <summary>
/// Prototype callback for overlap queries.<br/>
/// Called for each shape found in the query.<br/>
/// Return false to terminate the query.<br/>
/// </summary>
/// <param name="shape">The Shape</param>
/// <param name="context">The context</param>
/// <returns>true to continue the query, false to terminate</returns>
public delegate bool OverlapResultRefCallback<TContext>(Shape shapeId, ref TContext context) where TContext : unmanaged;

/// <summary>
/// Prototype callback for overlap queries.<br/>
/// Called for each shape found in the query.<br/>
/// Return false to terminate the query.<br/>
/// </summary>
/// <param name="shape">The Shape</param>
/// <returns>true to continue the query, false to terminate</returns>
public delegate bool OverlapResultCallback(Shape shapeId);