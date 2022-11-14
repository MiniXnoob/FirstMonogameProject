using System.Text.Json.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TestGame.Extensions;
using TestGame.Models;

namespace TestGame.Sprites
{
    public abstract class GameObject
    {
        public Vector2 Position = new();
        public Vector2 Velocity = new(0, 0.001f);
        public Color Colour = Color.White;
        public float Speed;

        public Guid Id { get; } = Guid.NewGuid();
        protected List<KeyboardAction> KeyboardActions { get; } = new();
        public float Friction { get; set; } = 1.0f;
        public float Mass { get; set; } = 1.0f;
        public float Bouncyness { get; set; } = 0.85f;
        public bool UseGravity { get; set; }

        [JsonIgnore] public Texture2D? Texture { get; set; }
        public Input? Input { get; set; }
        public Rectangle? RectangleCollider { get; set; }

        public void Update(GameTime gameTime)
        {
            if (RectangleCollider.HasValue)
            {
                RectangleCollider = new Rectangle(Position.ToPoint(), RectangleCollider.Value.Size);
            }

            if (Input != null)
            {
                this.Move(gameTime);
            }

            foreach (var keyboardAction in KeyboardActions.Where(keyboardAction => Keyboard.GetState().IsKeyDown(keyboardAction.Key)))
            {
                keyboardAction.Func.Invoke();
            }

            this.ApplyFriction();
        }
    }
}