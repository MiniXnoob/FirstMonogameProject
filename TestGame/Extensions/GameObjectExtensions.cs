using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;

using TestGame.Helpers;
using TestGame.Models;
using TestGame.Sprites;

namespace TestGame.Extensions
{
    public static class GameObjectExtensions
    {
        public static void Smooth(this GameObject gameObject)
        {
            if (gameObject.Velocity.X < 0.001f && gameObject.Velocity.X > -0.001f)
            {
                gameObject.Velocity.X = 0f;
            }

            if (gameObject.Velocity.Y < 0.001f && gameObject.Velocity.Y > -0.001f)
            {
                gameObject.Velocity.Y = 0f;
            }
        }

        public static void ApplyGravity(this GameObject gameObject, GameTime gameTime)
        {
            if (!gameObject.UseGravity) return;
            var dt = gameTime.GetElapsedSeconds();
            var gravity = gameObject.Mass * -PhysicsHelper.G;
            var accelleration = gravity * dt;
            var accellerationVector = new Vector2(0, accelleration);
            gameObject.Velocity += accellerationVector;
        }

        //public static void Reverse(this GameObject gameObject, Direction direction)
        //{


        //    gameObject.ReverseX();
        //    gameObject.ReverseY();
        //}

        public static void ReverseX(this GameObject gameObject)
        {
            gameObject.Velocity.X *= -1;
        }
        public static void ReverseY(this GameObject gameObject)
        {
            gameObject.Velocity.Y *= -1;
        }

        public static void Bounce(this GameObject gameObject, Direction direction)
        {
            switch (direction)
            {
                case Direction.Right or Direction.Left:
                    gameObject.ReverseX();
                    break;
                case Direction.Top or Direction.Bottom:
                    gameObject.ReverseY();
                    break;
            }

            gameObject.Velocity *= gameObject.Bouncyness;
        }

        //public static void Bounce(this GameObject gameObject)
        //{
        //    gameObject.Reverse();
        //    gameObject.Velocity *= gameObject.Bouncyness;
        //}

        public static void Collide(this GameObject gameObject)
        {
            if (gameObject.Velocity.X > 0 && gameObject.IsColliding(Direction.Right))
            {
                gameObject.Bounce(Direction.Right);
                //gameObject.Velocity.X = 0;
            }
            if (gameObject.Velocity.X < 0 && gameObject.IsColliding(Direction.Left))
            {
                gameObject.Bounce(Direction.Left);
                //gameObject.Velocity.X = 0;
            }
            if (gameObject.Velocity.Y > 0 && gameObject.IsColliding(Direction.Top))
            {
                gameObject.Bounce(Direction.Top);
                //gameObject.Velocity.Y = 0;
            }
            if (gameObject.Velocity.Y > 0 && gameObject.IsColliding(Direction.Bottom))
            {
                gameObject.Bounce(Direction.Bottom);
                //gameObject.Velocity.Y = 0;
            }
        }

        public static void ApplyFriction(this GameObject gameObject)
        {
            //gameObject.Velocity.X = gameObject.Velocity.X *= gameObject.Friction;
        }

        public static void HandleInput(this GameObject gameObject, GameTime gameTime)
        {
            if (gameObject.Input == null)
            {
                return;
            }

            if (Keyboard.GetState().IsKeyDown(gameObject.Input.Left))
            {
                gameObject.Velocity.X += -(gameObject.Speed * gameTime.GetElapsedSeconds());
            }
            else if (Keyboard.GetState().IsKeyDown(gameObject.Input.Right))
            {
                gameObject.Velocity.X += gameObject.Speed * gameTime.GetElapsedSeconds();
            }

            if (Keyboard.GetState().IsKeyDown(gameObject.Input.Up))
            {
                gameObject.Velocity.Y += -(gameObject.Speed * gameTime.GetElapsedSeconds());
            }
            else if (Keyboard.GetState().IsKeyDown(gameObject.Input.Down))
            {
                gameObject.Velocity.Y += gameObject.Speed * gameTime.GetElapsedSeconds();
            }

        }

        public static void Move(this GameObject gameObject)
        {
            gameObject.Position += gameObject.Velocity;

            if (gameObject.RectangleCollider.HasValue)
            {
                var size = gameObject.RectangleCollider.Value.Size;
                gameObject.RectangleCollider = size.Equals(Point.Zero) ? gameObject.Texture?.GetRectangleCollider(gameObject.Position) : new Rectangle(gameObject.Position.ToPoint(), size);
            }
        }

        public static void AddForce(this GameObject gameObject, Vector2 accelleration)
        {
            gameObject.Velocity += accelleration;
            gameObject.Position += gameObject.Velocity;
        }

        public static void SetCollisions(this GameObject self, GameObjectsList gameObjects)
        {
            self.Collisions.Clear();
            var collisons = gameObjects.GetCollisions(self);
            self.Collisions.AddRange(collisons);
        }

        public static IEnumerable<Collision> GetCollisions(this GameObject self, GameObjectsList gameObjects) => gameObjects.GetCollisions(self);

        public static bool IsColliding(this GameObject self, Direction direction) => self.GetTouchingDirections().Any(x => x == direction);
        public static bool IsColliding(this GameObject self) => self.Collisions.Any();

        public static bool IsColliding(this GameObject self, GameObject other) => IsTouching(self, other);

        public static IEnumerable<Direction> GetTouchingDirections(this GameObject self)
        {
            var directions = new List<Direction>();

            self.Collisions.ForEach(x => directions.AddRange(x.GetCollidingDirections()));

            return directions.Distinct();
        }

        public static IEnumerable<Direction> GetTouchingDirections(this GameObject self, GameObject other)
        {
            var directions = new List<Direction>();

            if (IsTouchingLeft(self, other)) directions.Add(Direction.Left);
            if (IsTouchingRight(self, other)) directions.Add(Direction.Right);
            if (IsTouchingTop(self, other)) directions.Add(Direction.Top);
            if (IsTouchingBottom(self, other)) directions.Add(Direction.Bottom);

            return directions;
        }

        public static bool IsTouching(this GameObject self, GameObject gameObject) => GetTouchingDirections(self, gameObject).Any();
        public static bool IsTouchingLeft(this GameObject self, GameObject other) => IsTouchingRight(self.RectangleCollider, self.Velocity.X, other.RectangleCollider);
        public static bool IsTouchingBottom(this GameObject self, GameObject other) => IsTouchingTop(self.RectangleCollider, self.Velocity.Y, other.RectangleCollider);
        public static bool IsTouchingRight(this GameObject self, GameObject other) => IsTouchingLeft(self.RectangleCollider, self.Velocity.X, other.RectangleCollider);
        public static bool IsTouchingTop(this GameObject self, GameObject other) => IsTouchingBottom(self.RectangleCollider, self.Velocity.Y, other.RectangleCollider);

        private static bool IsTouchingLeft(Rectangle? selfRectangle, float x, Rectangle? otherRectangle) =>
            selfRectangle.HasValue &&
            otherRectangle.HasValue &&
            selfRectangle.Value.Right + x > otherRectangle.Value.Left &&
            selfRectangle.Value.Left < otherRectangle.Value.Left &&
            selfRectangle.Value.Bottom > otherRectangle.Value.Top &&
            selfRectangle.Value.Top < otherRectangle.Value.Bottom;

        private static bool IsTouchingRight(Rectangle? selfRectangle, float x, Rectangle? otherRectangle) =>
            selfRectangle.HasValue &&
            otherRectangle.HasValue &&
            selfRectangle.Value.Left + x < otherRectangle.Value.Right &&
            selfRectangle.Value.Right > otherRectangle.Value.Right &&
            selfRectangle.Value.Bottom > otherRectangle.Value.Top &&
            selfRectangle.Value.Top < otherRectangle.Value.Bottom;

        private static bool IsTouchingTop(Rectangle? selfRectangle, float y, Rectangle? otherRectangle) =>
            selfRectangle.HasValue &&
            otherRectangle.HasValue &&
            selfRectangle.Value.Bottom + y > otherRectangle.Value.Top &&
            selfRectangle.Value.Top < otherRectangle.Value.Top &&
            selfRectangle.Value.Right > otherRectangle.Value.Left &&
            selfRectangle.Value.Left < otherRectangle.Value.Right;

        private static bool IsTouchingBottom(Rectangle? selfRectangle, float y, Rectangle? otherRectangle) =>
            selfRectangle.HasValue &&
            otherRectangle.HasValue &&
            selfRectangle.Value.Top + y < otherRectangle.Value.Bottom &&
            selfRectangle.Value.Bottom > otherRectangle.Value.Bottom &&
            selfRectangle.Value.Right > otherRectangle.Value.Left &&
            selfRectangle.Value.Left < otherRectangle.Value.Right;
    }
}