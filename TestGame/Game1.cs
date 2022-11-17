using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGame.Sprites;

namespace TestGame
{
    public class Game1 : Game
    {
        private int _height = 1000;
        private int _width = 1000;
        Random r = new Random();
        private int potato = 20;
        private int smallPotato = 9;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<GameObject> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = _height;
            graphics.PreferredBackBufferWidth = _width;
            Content.RootDirectory = "Content";
            base.IsMouseVisible = true;
            base.IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var playerTexture = Content.Load<Texture2D>("Block");
            var sBallTexture = Content.Load<Texture2D>("StianPexel");
            var sPBallTexture = Content.Load<Texture2D>("StianpPexel");
            var kBallTexture = Content.Load<Texture2D>("KristerPexel");
            var bBallTexture = Content.Load<Texture2D>("BenjaminPexel");
            var groundTexture = Content.Load<Texture2D>("GroundLongstcle");
            var walllTexture = Content.Load<Texture2D>("WallLongstcle");
            var font = Content.Load<SpriteFont>("Consolas16");

            _sprites = new List<GameObject>()
              {
                new Ground(groundTexture)
                {
                    Position = new Vector2(0, 0)
                },
                new Ground(groundTexture)
                {
                    Position = new Vector2(0, _height - 10)
                },
                new Walll(walllTexture)
                {
                    Position = new Vector2(0, 0),
                },
                new Walll(walllTexture)
                {
                    Position = new Vector2(_width - 10, 0)
                }
          };
            _sprites.Add(new Ball(sBallTexture, _sprites)
            {
                UseGravity = true,
                Position = new Vector2((r.Next(10, _width - 20)), (r.Next(10, _height - 20))),
                Velocity = new Vector2((r.Next(smallPotato, potato)), 0.001f)
                //Colour = Color.Aqua,
            });
            _sprites.Add(new Ball(kBallTexture, _sprites)
            {
                UseGravity = true,
                Position = new Vector2((r.Next(10, _width - 20)), (r.Next(10, _height - 20))),
                Velocity = new Vector2((r.Next(smallPotato, potato)), 0.001f)
                //Colour = Color.Orange,
            });
            _sprites.Add(new Ball(bBallTexture, _sprites)
            {
                UseGravity = true,
                Position = new Vector2((r.Next(10, _width - 20)), (r.Next(10, _height - 20))),
                Velocity = new Vector2((r.Next(smallPotato, potato)), 0.001f)
                //Colour = Color.Red,
            });
            //_sprites.Add(new Ball(sBallTexture, _sprites)
            //{
            //    UseGravity = true,
            //    Position = new Vector2((r.Next(10, _width - 20)), (r.Next(10, _height - 20))),
            //    Colour = Color.Green,
            //});
            _sprites.Add(new Ball(sPBallTexture, _sprites)
            {
                UseGravity = true,
                Position = new Vector2((r.Next(10, _width - 20)), (r.Next(10, _height - 20))),
                Velocity = new Vector2((r.Next(smallPotato, potato)), 0.001f)
                //Colour = Color.Yellow,
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