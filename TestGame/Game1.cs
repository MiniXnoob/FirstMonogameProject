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
            var ballTexture = Content.Load<Texture2D>("StianPexel");
            var groundTexture = Content.Load<Texture2D>("Cross Screen obstacle");
            var walllTexture = Content.Load<Texture2D>("Longstaclewall");
            var font = Content.Load<SpriteFont>("Consolas16");

            _sprites = new List<GameObject>()
              {
                new Player(playerTexture)
                {
                    Position = new Vector2(0, 790) 
                    
                },
                new Player(playerTexture)
                {
                    Position = new Vector2(40, 790)
                },
                new Player(playerTexture)
                {
                    Position = new Vector2(80, 790)
                },
                new Player(playerTexture)
                {
                    Position = new Vector2(120, 790)
                },
                new Player(playerTexture)
                {
                    Position = new Vector2(160, 790)
                },
                new Ground(groundTexture),
                new Walll(walllTexture)
                {
                    Position = new Vector2(0, 0),
                },
                new Walll(walllTexture)
                {
                    Position = new Vector2(790, 0)
                }

                
          };
            _sprites.Add(new Ball(ballTexture, _sprites)
            {
                UseGravity = true,
                Position = new Vector2(100, 100),
            });
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
                sprite.Gravity(gameTime);
            }

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