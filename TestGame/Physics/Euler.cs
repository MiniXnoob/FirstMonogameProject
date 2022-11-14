using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame.Physics
{
    /// <summary>
    /// Euler equations
    /// </summary>
    internal static class Euler
    {
        /// <summary>
        /// Calculate Explicit Euler for X direction
        /// </summary>
        /// <param name="v">Velocity in X direction</param>
        /// <param name="dt">ΔTime</param>
        /// <returns>Product of Explicit Euler</returns>
        public static float ExplicitEuler(float v, float dt)
        {
            var result = v * dt;
            return result;
        }

        public static float ExplicitEuler(float m, float f, float dt)
        {
            var result = (1/m * f) * dt;
            return result;

        }

        public static float SympleticEuler(float m, float f, float dt)
        {
            var v = (1 / m * f) * dt;
            var result = v * dt;
            return result;

        }
    }
}
