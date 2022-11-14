using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended;

using TestGame.Models;
using TestGame.Sprites;

namespace TestGame.Extensions;

public static class SpriteBatchExtensions
{
    public static void Draw(this SpriteBatch spriteBatch, GameObjectsList gameObjectsList)
    {
        gameObjectsList.Draw(spriteBatch);
    }

    public static void DrawRectangle(this SpriteBatch spriteBatch, Rectangle rectangle, Color color)
    {
        ShapeExtensions.DrawRectangle(spriteBatch, (float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height, color);
    }

    public static void Draw(this SpriteBatch spriteBatch, GameObject gameObject)
    {
        if (gameObject.Texture != null)
        {
            spriteBatch.Draw(gameObject.Texture, gameObject.Position, gameObject.Colour);
        }
        else if (gameObject.RectangleCollider != null)
        {
            spriteBatch.DrawRectangle(gameObject.RectangleCollider.Value, gameObject.Colour);
        }
    }
}