using System;
using System.Runtime.InteropServices;

namespace Box2D.Character_Movement;

public static unsafe class Solver
{
    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SolvePlanes")]
    private static extern PlaneSolverResult SolvePlanes(in Vec2 position, [In] CollisionPlane* planes, int count);

    public static PlaneSolverResult SolvePlanes(in Vec2 position, CollisionPlane[] planes)
    {
        if (planes is not { Length: not 0 })
            throw new ArgumentNullException(nameof(planes));

        fixed (CollisionPlane* planesPtr = planes)
            return SolvePlanes(position, planesPtr, planes.Length);
    }

    [DllImport(Core.libraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ClipVector")]
    private static extern Vec2 ClipVector(in Vec2 vector, [In] CollisionPlane* planes, int count);

    public static Vec2 ClipVector(in Vec2 vector, CollisionPlane[] planes)
    {
        if (planes is not { Length: not 0 })
            throw new ArgumentNullException(nameof(planes));

        fixed (CollisionPlane* planesPtr = planes)
        {
            return ClipVector(vector, planesPtr, planes.Length);
        }
    }
}
