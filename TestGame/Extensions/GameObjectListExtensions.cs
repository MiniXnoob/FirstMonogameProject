using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TestGame.Models;
using TestGame.Sprites;

namespace TestGame.Extensions;

public static class GameObjectListExtensions
{
    public static void Update(this GameObjectsList gameObjectsList, GameTime gameTime)
    {
        foreach (GameObject gameObject in gameObjectsList)
        {
            gameObject.SetCollisions(gameObjectsList);

            gameObject.Update(gameTime);
        }
    }

    public static void Draw(this GameObjectsList gameObjectsList, SpriteBatch spriteBatch)
    {
        foreach (GameObject gameObject in gameObjectsList)
        {
            spriteBatch.Draw(gameObject);
        }
    }

    public static IEnumerable<Collision> GetCollisions(this GameObjectsList gameObjectsList, GameObject self)
    {
        var list = new List<Collision>();
        if (gameObjectsList.Any()) list.AddRange(from gameObject in gameObjectsList where self.IsTouching(gameObject) && self.Id != gameObject.Id select new Collision(self, gameObject));
        return list;
    }

    public static bool IsColliding(this GameObjectsList gameObjectsList, GameObject self)
    {
        return gameObjectsList.GetCollisions(self).SelectMany(y => y.GetCollidingDirections()).Any();
    }

    public static bool IsColliding(this GameObjectsList gameObjectsList, GameObject self, Direction direction)
    {
        return gameObjectsList.GetCollisions(self).SelectMany(y => y.GetCollidingDirections()).Contains(direction);
    }

    //public static void ApplyGravity(this GameObjectsList gameObjectsList, GameTime gameTime)
    //{
    //    foreach (GameObject gameObject in gameObjectsList)
    //    {
    //        if (!gameObject.UseGravity) continue;

    //        if (gameObjectsList.IsColliding(gameObject, Direction.Top))
    //        {
    //            gameObject.Bounce();
    //        }
    //        else
    //        {
    //            gameObject.ApplyGravity(gameTime);
    //        }

    //var dt = gameTime.GetElapsedSeconds();
    //var gravity = gameObject.Mass * -PhysicsHelper.G;
    //var accelleration = gravity * dt;
    //var accellerationVector = new Vector2(0, accelleration);
    //gameObject.Velocity += accellerationVector;
    //    }
    //}
}