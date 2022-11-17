﻿using System;
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
    public bool onGround;
    Random r = new Random();
    private int dirRight;

        public Ball(Texture2D texture, List<GameObject> gameObjects)
      : base(texture, gameObjects)
    {
      Speed = 0.5f;
      Colour = Color.White;

     }

        public override void Update(GameTime gameTime, List<GameObject> sprites)
    {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Position.X = r.Next(20, 500);
                Position.Y = r.Next(20, 500);
                Thread.Sleep(20);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                Thread.Sleep(20);
                dirRight = r.Next(0, 2);
                if (dirRight == 0)
                {
                    Velocity.X = r.Next(10, 20);
                }
                else if (dirRight == 1)
                {
                    Velocity.X = r.Next(-20, -10);
                }

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