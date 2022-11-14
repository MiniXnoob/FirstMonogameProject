using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;

using TestGame.Models;
using TestGame.Sprites;

namespace TestGame.Extensions
{
    public static class GameObjectExtensions
    {
        public static void ApplyFriction(this GameObject gameObject)
        {
            //gameObject.Accellerate(new Vector2(gameObject.Mass * PhysicsHelper.G, gameObject.Mass * PhysicsHelper.G));
        }

        public static void Move(this GameObject gameObject, GameTime gameTime)
        {
            if (gameObject.Input == null) return;

            var accelleration = new Vector2();

            if (Keyboard.GetState().IsKeyDown(gameObject.Input.Left))
                accelleration.X = -gameObject.Speed;
            else if (Keyboard.GetState().IsKeyDown(gameObject.Input.Right))
                accelleration.X = gameObject.Speed;

            if (Keyboard.GetState().IsKeyDown(gameObject.Input.Up))
                accelleration.Y = -gameObject.Speed;
            else if (Keyboard.GetState().IsKeyDown(gameObject.Input.Down))
                accelleration.Y = gameObject.Speed;

            gameObject.Accellerate(accelleration * gameTime.GetElapsedSeconds());
        }

        public static void Accellerate(this GameObject gameObject, Vector2 accelleration)
        {
            //if (!gameObject.IsTouchingBottom())
            //gameObject.Velocity.Y += accelleration;
            //else if (this.IsTouchingBottom())
            //gameObject.Velocity.Y = gameObject.Velocity.Y * -1 * gameObject.Bounce;

            gameObject.Velocity += accelleration;
            gameObject.Position += gameObject.Velocity;

            //Console.WriteLine(gameObject.Velocity.Y);
        }

        public static bool IsColliding(this GameObject self, GameObject other) => IsTouching(self, other);

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
        public static bool IsTouchingLeft(this GameObject self, GameObject other) => IsTouchingLeft(self.RectangleCollider, self.Velocity.X, other.RectangleCollider);
        public static bool IsTouchingBottom(this GameObject self, GameObject other) => IsTouchingBottom(self.RectangleCollider, self.Velocity.Y, other.RectangleCollider);
        public static bool IsTouchingRight(this GameObject self, GameObject other) => IsTouchingRight(self.RectangleCollider, self.Velocity.X, other.RectangleCollider);
        public static bool IsTouchingTop(this GameObject self, GameObject other) => IsTouchingTop(self.RectangleCollider, self.Velocity.Y, other.RectangleCollider);

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