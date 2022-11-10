using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended;

namespace TestGame.Sprites
{
    public class Ground : GameObject
    {
        public Ground(Texture2D texture) : base(texture)
        {
            Bounds = new Size2(800, 10);
            Colour = Color.White;
            Position = new Vector2(0, 450);
        }

        public Size2 Bounds { get; set; }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(base.Position, Bounds, base.Colour);
        }
    }
}