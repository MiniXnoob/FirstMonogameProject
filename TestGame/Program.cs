using System;
using TestGame;
using TestGame.Physics;

namespace TestGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine(Euler.ExplicitEuler(1, 5));
            using (var game = new Game1())
                game.Run();
        }
    }
}