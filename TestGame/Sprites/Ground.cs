using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TestGame.Models;

namespace TestGame.Sprites
{
    public class Ground : GameObject
    {
        public Ground()
        {
            KeyboardActions.Add(new KeyboardAction(Keys.Space, () =>
            {
                Console.WriteLine(RectangleCollider);
            }));
        }

        public static Ground Default(Texture2D? texture) => new()
        {
            Color = Color.White,
            Position = new Vector2(0, 450),
            Texture = texture,
            RectangleCollider = new Rectangle(new Point(0, 450), new Point(800, 10)),
        };
    }
}