using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestGame.Models;
using TestGame.Physics;
using TestGame.Sprites;

namespace TestGame.Sprites
{
    public class GameObject
    {
        protected Texture2D _texture;

        private readonly Collider _collider = new();

        public Vector2 Position = new();
        public Vector2 Velocity = new(10, 0.001f);
        public Color Colour = Color.White;
        public float Speed;
        public Input Input;

        public bool UseGravity { get; set; }

        public Rectangle RectangleCollider
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public GameObject(Texture2D texture, List<GameObject> gameObjects)
        {
            _texture = texture;
            _collider = new Collider(gameObjects);
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
        
        public virtual void Gravity(GameTime gameTime)
        {
            var dt = (float)gameTime.GetElapsedSeconds();
            var mass = 1f;
            var g = 9.81f;
            var gravity = mass * g;
            var accelleration = gravity * dt;
            

            if (UseGravity)
            {
                if (!IsTouchingBottom())
                    Velocity.Y += accelleration;
                else if (IsTouchingBottom())
                    Velocity.Y = Velocity.Y * -1 * 0.99f;

                if (IsTouchingRight())
                {
                    Velocity.X = Velocity.X * -1 * 0.99f;
                    gravity *= -1;
                }
              
               
                if (IsTouchingLeft())
                {
                    Velocity.X = Velocity.X * 1 * 0.99f;
                    gravity *= -1;
                }
                 

                Position += Velocity;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.O))
                Velocity.Y = 0f;
            //Console.WriteLine(Velocity.Y);
            Console.WriteLine(Velocity.X);

        }

        public virtual void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(_texture, Position, Colour);

        protected bool IsTouchingLeft(GameObject sprite) => _collider.IsTouchingLeft(this, sprite);

        protected bool IsTouchingRight(GameObject sprite) => _collider.IsTouchingRight(this, sprite);

        protected bool IsTouchingTop(GameObject sprite) => _collider.IsTouchingTop(this, sprite);

        protected bool IsTouchingBottom(GameObject sprite) => _collider.IsTouchingBottom(this, sprite);
        
        protected bool IsTouchingBottom() => _collider.GetTouchingDirections(this).Any(x => x == Direction.Top);
        protected bool IsTouchingLeft() => _collider.GetTouchingDirections(this).Any(x => x == Direction.Left);
        protected bool IsTouchingRight() => _collider.GetTouchingDirections(this).Any(x => x == Direction.Right);

    }
}