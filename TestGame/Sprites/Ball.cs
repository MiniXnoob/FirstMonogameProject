using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TestGame.Extensions;
using TestGame.Models;

namespace TestGame.Sprites
{
    public class Ball : GameObject
    {
        public Ball()
        {
            KeyboardActions.Add(new KeyboardAction(Keys.Escape, () =>
            {
                Position = new Vector2(100, 100);
                Velocity = Vector2.Zero;
            }));
            KeyboardActions.Add(new KeyboardAction(Keys.Space, () =>
            {
                Console.WriteLine(RectangleCollider);
            }));
        }

        public static Ball Default(Texture2D? texture) => new() { Texture = texture, UseGravity = true, Position = new Vector2(100, 100), RectangleCollider = texture?.GetRectangleCollider(new Vector2(100, 100)) };
    }
}