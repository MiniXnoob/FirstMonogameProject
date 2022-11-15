using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TestGame.Models;

namespace TestGame.Sprites
{
    public class Player : GameObject
    {
        public static Player One(Texture2D? texture) => new Player()
        {
            Texture = texture,
            RectangleCollider = Rectangle.Empty,
            Position = new Vector2(300, 400),
            Speed = 5,
        };

        public static Player Two(Texture2D? texture) => new()
        {
            Texture = texture,
            RectangleCollider = Rectangle.Empty,
            Input = new Input()
            {
                Left = Keys.Left,
                Right = Keys.Right,
                Up = Keys.Up,
                Down = Keys.Down,
            },
            Position = new Vector2(400, 400),
            Color = Color.Blue,
            Speed = 5,
        };
    }
}