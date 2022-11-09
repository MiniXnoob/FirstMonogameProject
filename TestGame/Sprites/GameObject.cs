using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestGame.Models;

namespace TestGame.Sprites
{
    public class GameObject
    {
        protected Texture2D _texture;


        public Vector2 Position;
        public Vector2 Velocity;
        public Color Colour = Color.White;
        public float Speed;
        public Input Input;

        public Rectangle RectangleCollider
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public GameObject(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<GameObject> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Colour);
        }

        protected bool IsTouchingLeft(GameObject sprite)
        {
            return this.RectangleCollider.Right + this.Velocity.X > sprite.RectangleCollider.Left &&
              this.RectangleCollider.Left < sprite.RectangleCollider.Left &&
              this.RectangleCollider.Bottom > sprite.RectangleCollider.Top &&
              this.RectangleCollider.Top < sprite.RectangleCollider.Bottom;
        }

        protected bool IsTouchingRight(GameObject sprite)
        {
            return this.RectangleCollider.Left + this.Velocity.X < sprite.RectangleCollider.Right &&
              this.RectangleCollider.Right > sprite.RectangleCollider.Right &&
              this.RectangleCollider.Bottom > sprite.RectangleCollider.Top &&
              this.RectangleCollider.Top < sprite.RectangleCollider.Bottom;
        }

        protected bool IsTouchingTop(GameObject sprite)
        {
            return this.RectangleCollider.Bottom + this.Velocity.Y > sprite.RectangleCollider.Top &&
              this.RectangleCollider.Top < sprite.RectangleCollider.Top &&
              this.RectangleCollider.Right > sprite.RectangleCollider.Left &&
              this.RectangleCollider.Left < sprite.RectangleCollider.Right;
        }

        protected bool IsTouchingBottom(GameObject sprite)
        {
            return this.RectangleCollider.Top + this.Velocity.Y < sprite.RectangleCollider.Bottom &&
              this.RectangleCollider.Bottom > sprite.RectangleCollider.Bottom &&
              this.RectangleCollider.Right > sprite.RectangleCollider.Left &&
              this.RectangleCollider.Left < sprite.RectangleCollider.Right;
        }

    }
}