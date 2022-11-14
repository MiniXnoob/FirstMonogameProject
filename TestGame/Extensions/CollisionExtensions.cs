using TestGame.Models;

namespace TestGame.Extensions;

public static class CollisionExtensions
{
    public static IEnumerable<Direction> GetCollidingDirections(this Collision collision)
    {
        return collision.Other.GetTouchingDirections(collision.Self);
    }
}