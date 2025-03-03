namespace Box2D;

/// <summary>
/// Joint type enumeration
/// </summary>
public enum JointType
{
    Distance,
    Motor,
    Mouse,
#if !BOX2D_300    
    Null,
#endif
    Prismatic,
    Revolute,
    Weld,
    Wheel,
}