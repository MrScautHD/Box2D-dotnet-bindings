global using Vec2 = System.Numerics.Vector2;
global using uint64_t = System.UInt64;
global using static Box2D.Constants;

namespace Box2D;

public static class Constants
{
    public const float PI = 3.14159265358979323846f;
    public const float TWO_PI = 2.0f * PI;
    public const float PI_OVER_2 = PI / 2.0f;
    public const float PI_OVER_4 = PI / 4.0f;
    public const float EPSILON = 1e-5f;
    public const float MAX_FLOAT = float.MaxValue;
    public const float MIN_FLOAT = float.MinValue;

    public const int MAX_MANIFOLD_POINTS = 2;
    public const int MAX_POLYGON_VERTICES = 8;
    public const int MAX_SHAPE_VERTICES = 8;
    public const int MAX_SHAPE_EDGES = 8;

    public const int INVALID_INDEX = -1;
    public const int NULL_INDEX = -1;
    public const int NULL_NODE = -1;
    public const int NULL_PAIR = -1;

    public const ulong DEFAULT_CATEGORY_BITS = 0x0001;
    public const ulong DEFAULT_MASK_BITS = 0xFFFF;
}