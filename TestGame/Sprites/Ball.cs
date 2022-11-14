using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;

using TestGame.Physics;

namespace TestGame.Sprites
{
  public class Ball : GameObject
  {
    private Vector2? _startPosition = null;
    private float? _startSpeed;
    public bool onGround;
    
    

    public Ball(Texture2D texture, List<GameObject> gameObjects)
      : base(texture, gameObjects)
    {
      Speed = 0.5f;
    }

    public override void Update(GameTime gameTime, List<GameObject> sprites)
    {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Position.X = 100;
                Position.Y = 100;
            }

            //if (_startPosition == null)
            //{
            //  _startPosition = Position;
            //  _startSpeed = Speed;

            //}

        foreach (var sprite in sprites)
        {
        if (sprite == this)
          continue;

            if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
              onGround = true;
            if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
              onGround = true;
            if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
              onGround = true;
            if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
              onGround = true;

        }

        //Position += Velocity;

    }  

    }
  }