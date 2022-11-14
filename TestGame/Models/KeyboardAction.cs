using Microsoft.Xna.Framework.Input;

namespace TestGame.Models;

public readonly record struct KeyboardAction(Keys Key, Action Func);