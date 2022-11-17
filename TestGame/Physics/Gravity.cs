//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework;
//using MonoGame.Extended;
//using TestGame.Models;
//namespace TestGame.Physics
//{
//    internal class GravityClass
//    {
//        public bool UseGravity { get; set; }

//        public virtual void Gravity(GameTime gameTime)
//        {
//            var dt = (float)gameTime.GetElapsedSeconds();
//            var mass = 1f;
//            var g = 9.81f;
//            var gravity = mass * g;
//            var accelleration = gravity * dt;

//            if (UseGravity)
//            {
//                if (!IsTouchingBottom())
//                    Velocity.Y += accelleration;
//                else if (IsTouchingBottom())
//                    Velocity.Y = Velocity.Y * -1 * 1.0f;
//                if (IsTouchingRight() || IsTouchingLeft())
//                {
//                    Velocity.X = Velocity.X * -1 * 1.0f;

//                }

//                Position += Velocity;
//            }

//            if (Keyboard.GetState().IsKeyDown(Keys.O))
//                Velocity.Y = 0f;

//        }
//    }
//}
