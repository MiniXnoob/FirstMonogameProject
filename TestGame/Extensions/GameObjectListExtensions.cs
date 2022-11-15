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

    public static IEnumerable<Rectangle> GetCollidingRectangles(this GameObjectsList gameObjectsList, GameObject self) => (from otherGameObject in gameObjectsList where self.RectangleCollider.HasValue && otherGameObject.RectangleCollider.HasValue && self.RectangleCollider.Value.Intersects(otherGameObject.RectangleCollider.Value) select otherGameObject.RectangleCollider!.Value).ToList();

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
}