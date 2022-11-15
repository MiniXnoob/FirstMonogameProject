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
            KeyboardActions.Add(new KeyboardAction(Keys.NumPad8, () =>
            {
                this.AddForce(Vector2.UnitY);
            }));
            KeyboardActions.Add(new KeyboardAction(Keys.NumPad4, () =>
            {
                this.AddForce(Vector2.UnitY * -1);
            }));
            KeyboardActions.Add(new KeyboardAction(Keys.NumPad6, () =>
            {
                this.AddForce(Vector2.UnitX);
            }));
        }

        public static Ball Default(Texture2D? texture) => new()
        {
            Texture = texture,
            UseGravity = true,
            Bouncyness = 0.85f,
            Input = new Input()
            {
                Left = Keys.A,
                Right = Keys.D,
                Up = Keys.W,
                Down = Keys.S,
            },
            Position = new Vector2(100, 100),
            RectangleCollider = texture?.GetRectangleCollider(new Vector2(100, 100))
        };
    }
}