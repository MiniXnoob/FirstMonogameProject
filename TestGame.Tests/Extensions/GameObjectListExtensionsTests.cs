using FluentAssertions;

using Microsoft.Xna.Framework;

using TestGame.Extensions;
using TestGame.Models;
using TestGame.Sprites;

namespace TestGame.Tests.Extensions
{
    public class GameObjectListExtensionsTests
    {
        [Fact]
        public void GetCollisions_OverlappingGround_ShouldHaveCollision()
        {
            // Arrange
            var gameObjectsList = new GameObjectsList();
            var ground = Ground.Default(null);
            var self = Ball.Default(null);

            self.Position = ground.Position;

            var point = self.Position.ToPoint();

            self.RectangleCollider = new Rectangle(point, new Point(100, 100));


            gameObjectsList.Add(ground);

            // Act
            var result = gameObjectsList.GetCollisions(self);

            // Assert
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void IsColliding_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            GameObjectsList gameObjectsList = new GameObjectsList();
            GameObject self = null;

            // Act
            var result = gameObjectsList.IsColliding(self);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void IsColliding_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            GameObjectsList gameObjectsList = new GameObjectsList();
            GameObject self = null;
            Direction direction = default(global::TestGame.Models.Direction);

            // Act
            var result = gameObjectsList.IsColliding(
                self,
                direction);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void ApplyGravity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            GameObjectsList gameObjectsList = new GameObjectsList();
            GameTime gameTime = CreateGameTime();

            // Act
            gameObjectsList.ApplyGravity(gameTime);

            // Assert
            Assert.True(false);
        }

        private GameTime CreateGameTime()
        {
            var totalGameTime = TimeSpan.FromSeconds(42);
            var elapsedGameTime = TimeSpan.FromMilliseconds(10);
            return new GameTime(totalGameTime, elapsedGameTime);
        }
    }
}