using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame.Extensions;

public static class Texture2DExtensions
{
    public static Rectangle GetRectangleCollider(this Texture2D texture, Vector2 position) => new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
}