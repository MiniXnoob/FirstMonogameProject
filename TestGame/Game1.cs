using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TestGame.Models;
using TestGame.Sprites;

namespace TestGame
{
    public class Game1 : Game
    {
        private float ballsX;
        private float ballsY;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<GameObject> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            base.IsMouseVisible = true;
            base.IsFixedTimeStep = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var playerTexture = Content.Load<Texture2D>("Block");
            var ballTexture = Content.Load<Texture2D>("smileball");
            var groundTexture = Content.Load<Texture2D>("Cross Screen obstacle");
            var font = Content.Load<SpriteFont>("Consolas16");

            _sprites = new List<GameObject>()
              {
                new Ground(groundTexture),
                new Player(playerTexture)
                {
                  Input = new Input()
                  {
                    Left = Keys.A,
                    Right = Keys.D,
                    Up = Keys.W,
                    Down = Keys.S,
                  },
                  Position = new Vector2(300, 400),
                  Speed = 5,
                },
                new Player(playerTexture)
                {
                  Input = new Input()
                  {
                    Left = Keys.Left,
                    Right = Keys.Right,
                    Up = Keys.Up,
                    Down = Keys.Down,
                  },
                  Position = new Vector2(400, 400),
                  Colour = Color.Blue,
                  Speed = 5,
                },
                 new Ball(ballTexture)
                {
                    Position = new Vector2(100, 100),
                }
          };
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();


            foreach (var sprite in _sprites)
            sprite.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
} 