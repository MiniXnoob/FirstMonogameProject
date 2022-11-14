using Microsoft.Xna.Framework;
using TestGame.Sprites;

namespace TestGame.Models
{
    internal class Collider
    {
        public bool IsTouching(GameObject self, GameObject gameObject) => GetTouchingDirections(self, gameObject).Any();

        public IEnumerable<Direction> GetTouchingDirections(GameObject self, GameObject other)
        {
            var directions = new List<Direction>();
            
            if(IsTouchingLeft(self, other)) directions.Add(Direction.Left);
            if(IsTouchingRight(self, other)) directions.Add(Direction.Right);
            if(IsTouchingTop(self, other)) directions.Add(Direction.Top);
            if(IsTouchingBottom(self, other)) directions.Add(Direction.Bottom);

            return directions;
        }

        public bool IsTouchingLeft(Rectangle selfRectangle, float x, Rectangle otherRectangle) =>
            selfRectangle.Right + x > otherRectangle.Left &&
            selfRectangle.Left < otherRectangle.Left &&
            selfRectangle.Bottom > otherRectangle.Top &&
            selfRectangle.Top < otherRectangle.Bottom;

        public bool IsTouchingLeft(GameObject self, GameObject other) => IsTouchingLeft(self.RectangleCollider, self.Velocity.X, other.RectangleCollider);

        //public bool IsTouchingLeft(GameObject self, GameObject other) =>
        //    self.RectangleCollider.Right + self.Velocity.X > other.RectangleCollider.Left &&
        //    self.RectangleCollider.Left < other.RectangleCollider.Left &&
        //    self.RectangleCollider.Bottom > other.RectangleCollider.Top &&
        //    self.RectangleCollider.Top < other.RectangleCollider.Bottom;

        public bool IsTouchingRight(GameObject self, GameObject other) =>
            self.RectangleCollider.Left + self.Velocity.X < other.RectangleCollider.Right &&
            self.RectangleCollider.Right > other.RectangleCollider.Right &&
            self.RectangleCollider.Bottom > other.RectangleCollider.Top &&
            self.RectangleCollider.Top < other.RectangleCollider.Bottom;

        public bool IsTouchingTop(GameObject self, GameObject other) =>
            self.RectangleCollider.Bottom + self.Velocity.Y > other.RectangleCollider.Top &&
            self.RectangleCollider.Top < other.RectangleCollider.Top &&
            self.RectangleCollider.Right > other.RectangleCollider.Left &&
            self.RectangleCollider.Left < other.RectangleCollider.Right;

        public bool IsTouchingBottom(GameObject self, GameObject other) =>
            self.RectangleCollider.Top + self.Velocity.Y < other.RectangleCollider.Bottom &&
            self.RectangleCollider.Bottom > other.RectangleCollider.Bottom &&
            self.RectangleCollider.Right > other.RectangleCollider.Left &&
            self.RectangleCollider.Left < other.RectangleCollider.Right;
    }



    public enum Direction
    {
        None,
        Left,
        Right,
        Top,
        Bottom
    }
}
