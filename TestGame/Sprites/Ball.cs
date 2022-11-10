using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame.Sprites
{
  public class Ball : GameObject
  {
    private Vector2? _startPosition = null;
    private float? _startSpeed;
    private bool onGround = false;

    public Ball(Texture2D texture)
      : base(texture)
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


                Gravity();

      foreach (var sprite in sprites)
      {
        if (sprite == this)
          continue;

        if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                {
                    this.Velocity.X = 0;
                }
        if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                {
                    this.Velocity.X = 0;
                }
        if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                {
                    this.Velocity.Y = 0;
                }
        if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                {
                    this.Velocity.Y = 0;
                    onGround = true;
                }
            }

            Position += Velocity;

    }
        private void Gravity()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;

            if (Keyboard.GetState().IsKeyDown(Input.Up))
                Velocity.Y = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y = Speed;

            if (onGround == false)
                {
                    Velocity.Y += Speed;
                }
            else
            {
                Speed += 0.5f;
            }
        }       

    }
  }