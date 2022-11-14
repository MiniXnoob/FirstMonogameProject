using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace TestGame.Sprites
{
    public class Walll : GameObject
    {
        public Walll(Texture2D texture) : base(texture)
        {
            Bounds = new Size2(10, 800);
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