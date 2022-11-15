using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TestGame.Extensions;
using TestGame.Models;
using TestGame.Sprites;

namespace TestGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private readonly GameObjectsList _gameObjects;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _gameObjects = new GameObjectsList();
            Content.RootDirectory = "Content";
            base.IsMouseVisible = true;
            base.IsFixedTimeStep = false;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var playerTexture = Content.Load<Texture2D>("Block");
            var ballTexture = Content.Load<Texture2D>("smileball");
            var groundTexture = Content.Load<Texture2D>("Cross Screen obstacle");
            var font = Content.Load<SpriteFont>("Consolas16");

            _gameObjects.Add(Ground.Default(groundTexture));
            _gameObjects.Add(Player.One(playerTexture));
            _gameObjects.Add(Player.Two(playerTexture));
            _gameObjects.Add(Ball.Default(ballTexture));
        }

        protected override void Update(GameTime gameTime)
        {
            _gameObjects.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(_gameObjects);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}