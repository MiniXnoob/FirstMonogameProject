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
        public Color Color = Color.White;

        public Guid Id { get; } = Guid.NewGuid();
        protected List<KeyboardAction> KeyboardActions { get; } = new();
        public float Friction { get; set; } = 0.85f;
        public float Mass { get; set; } = 1.0f;
        public float Bouncyness { get; set; } = 1.0f;
        public bool UseGravity { get; set; }

        [JsonIgnore] public Texture2D? Texture { get; set; }

        public Input? Input { get; set; }
        public float Speed = 5f;

        [JsonIgnore] public Rectangle? RectangleCollider { get; set; }
        public List<Collision> Collisions { get; } = new List<Collision>();

        public void Update(GameTime gameTime)
        {
            if (Input != null)
            {
                this.HandleInput(gameTime);
            }
            foreach (var keyboardAction in KeyboardActions.Where(keyboardAction => Keyboard.GetState().IsKeyDown(keyboardAction.Key)))
            {
                keyboardAction.Func.Invoke();
            }

            this.ApplyGravity(gameTime);
            this.ApplyFriction();
            this.Collide();
            this.Smooth();
            this.Move();
        }
    }
}