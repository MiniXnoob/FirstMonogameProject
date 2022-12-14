using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using TestGame.Models;


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
                var currentVelocityY = Velocity.Y;

                if (!IsTouchingBottom())
                    Velocity.Y += accelleration;
                else if (IsTouchingBottom())
                    Velocity.Y = Velocity.Y * -1f * 0.95f;
                if (IsTouchingRight() || IsTouchingLeft())
                {
                    Velocity.X = Velocity.X * -1 * 0.95f;
                }

                var diff = Velocity.Y - currentVelocityY;

                if (MathF.Abs(diff) < 0.1f && MathF.Abs(diff) > -0.1f)
                {
                    Velocity.Y = 0f;
                }
                Velocity *= 0.998f;
                Position += Velocity;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.O))
                Velocity.Y = 0f;
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