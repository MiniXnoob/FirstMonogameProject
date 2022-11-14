using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using MonoGame.Extended;

namespace TestGame.Physics
{
    internal static class Timestepping
    {
        public static void RunStepping(GameTime gameTime)
        {
            const float fps = 100;
            const float dt = 1 / fps;
            float accumulator = 0;

            float frameStart = gameTime.GetElapsedSeconds();

            while (true)
            {
                float currentTime = gameTime.GetElapsedSeconds();

                accumulator += currentTime - frameStart;

                frameStart = currentTime;

                while (accumulator > dt)
                {

                    accumulator -= dt;
                }
            }

        }
    }
}