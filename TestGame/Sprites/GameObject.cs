using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestGame.Models;
using TestGame.Physics;

namespace TestGame.Sprites
{
    public class GameObject
    {
        protected Texture2D _texture;

        private readonly Collider _collider = new();

        public Vector2 Position = new();
        public Vector2 Velocity = new();
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

        public virtual void Move(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(_texture, Position, Colour);

        protected bool IsTouchingLeft(GameObject sprite) => _collider.IsTouchingLeft(this, sprite);

        protected bool IsTouchingRight(GameObject sprite) => _collider.IsTouchingRight(this, sprite);

        protected bool IsTouchingTop(GameObject sprite) => _collider.IsTouchingTop(this, sprite);

        protected bool IsTouchingBottom(GameObject sprite) => _collider.IsTouchingBottom(this, sprite);
    }
}