using JetBrains.Annotations;
using System;
using System.Runtime.InteropServices;

namespace Box2D.Character_Movement;

public static class Mover
{
    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SolvePlanes")]
    private static extern PlaneSolverResult b2SolvePlanes(Vec2 position, [In] CollisionPlane[] planes, int count);

    [PublicAPI]
    public static PlaneSolverResult SolvePlanes(in Vec2 position, CollisionPlane[] planes)
    {
        if (planes is not { Length: not 0 })
            throw new ArgumentNullException(nameof(planes));
        return b2SolvePlanes(position, planes, planes.Length);
    }
    
    [PublicAPI]
    public static PlaneSolverResult SolvePlanes(in Vec2 position, CollisionPlane[] planes, int planeCount)
    {
        if (planes is not { Length: not 0 })
            throw new ArgumentNullException(nameof(planes));

        return b2SolvePlanes(position, planes, planeCount);
    }

    [DllImport(libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ClipVector")]
    private static extern Vec2 b2ClipVector(Vec2 vector, [In] CollisionPlane[] planes, int count);

    [PublicAPI]
    public static Vec2 ClipVector(in Vec2 vector, CollisionPlane[] planes)
    {
        if (planes is not { Length: not 0 })
            throw new ArgumentNullException(nameof(planes));

        return b2ClipVector(vector, planes, planes.Length);
    }
    
    [PublicAPI]
    public static Vec2 ClipVector(in Vec2 vector, CollisionPlane[] planes, int planeCount)
    {
        if (planes is not { Length: not 0 })
            throw new ArgumentNullException(nameof(planes));
        
        return b2ClipVector(vector, planes, planeCount);
    }
}
