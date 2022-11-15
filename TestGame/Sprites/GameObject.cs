using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
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
        public Vector2 Velocity = new(0, 0.001f);
        public Color Colour = Color.White;
        public float Speed;
        public Input Input;
        private bool wasOnGround = false;

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

                {
                    Velocity.Y += accelleration;
                    
                    //Velocity.X = Euler.ExplicitEuler(1, 1, (float)gameTime.TotalGameTime.TotalSeconds);


                    //Console.WriteLine(onGround);

                }
                else if (IsTouchingBottom())
                {
                    //var reverseVelocity = accelleration * -1;
                    //accelleration = reverseVelocity * 0.8f;
                    //Velocity.Y = accelleration;
                    //Position += Velocity;
                    Velocity.Y = Velocity.Y * -1 * 0.85f;
                    
                }
    
                Position += Velocity;
            }
            if (accelleration <= 0.0004 && accelleration >= -0.0004)
            Console.WriteLine(Velocity.Y);
        }

        public virtual void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(_texture, Position, Colour);

        protected bool IsTouchingLeft(GameObject sprite) => _collider.IsTouchingLeft(this, sprite);

        protected bool IsTouchingRight(GameObject sprite) => _collider.IsTouchingRight(this, sprite);

        protected bool IsTouchingTop(GameObject sprite) => _collider.IsTouchingTop(this, sprite);

        protected bool IsTouchingBottom(GameObject sprite) => _collider.IsTouchingBottom(this, sprite);
        
        protected bool IsTouchingBottom() => _collider.GetTouchingDirections(this).Any(x => x == Direction.Top);
    }
}