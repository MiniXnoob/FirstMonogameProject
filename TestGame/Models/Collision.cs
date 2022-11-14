using TestGame.Sprites;

namespace TestGame.Models;

public readonly record struct Collision(GameObject Self, GameObject Other);