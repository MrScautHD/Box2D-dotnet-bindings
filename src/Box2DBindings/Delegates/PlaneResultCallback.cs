using Box2D.Character_Movement;

namespace Box2D;

/// <summary>
/// Used to collect collision planes for character movers.
/// </summary>
/// <param name="shapeId">The shape ID</param>
/// <param name="plane">The plane</param>
/// <param name="context">The user context</param>
/// <returns>True to continue gathering planes</returns>
public delegate bool PlaneResultCallback(Shape shapeId, in CollisionPlane plane, nint context);