using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minefield.Interfaces;
using Minefield;
using Moq;
namespace MinefieldUnitTest
{   

    [TestClass]
    public class MinefieldServiceUnitTest
    {
        private Mock<IDisplayService> _mockDisplayService;
        private IMinefieldMovement _minefieldMovement;
        private Mock<IMinefieldBoard> _mockMinefieldBoard;
        private MinefieldService _minefieldService;

        [TestInitialize]
        public void SetUp()
        {
            // Initialize the mocks
            _mockDisplayService = new Mock<IDisplayService>();
            _mockMinefieldBoard = new Mock<IMinefieldBoard>();
            _minefieldMovement = new MinefieldMovement();
            // Setup the mock for board
            var mockBoard = new bool[3, 3]; // Simple 3x3 board
            mockBoard[1, 1] = true; // Adding a mine at (1, 1)
            _mockMinefieldBoard.Setup(b => b.board).Returns(mockBoard);

            // Create the MinefieldService instance
            _minefieldService = new MinefieldService(
                _mockDisplayService.Object,
                _minefieldMovement,
                _mockMinefieldBoard.Object
            );
        }

        [TestMethod]
        public void TestRunAsync_ValidGamePlay()
        {
            // Arrange
            int rows = 3, cols = 3, numberOfLives = 3, numberOfMines = 1;
            var inputs = new Queue<char>(new[] { 'R', 'R', 'U', 'U' });
            Console.SetIn(new System.IO.StringReader(string.Join(Environment.NewLine, inputs)));

            // Act
            int finalScore = _minefieldService.RunAsync(rows, cols, numberOfLives, numberOfMines);

            // Assert
            Assert.AreEqual(4, finalScore);
        }

        [TestMethod]
        public void TestRunAsync_InvalidMovement_HandlesGracefully()
        {
            // Arrange
            int rows = 3, cols = 3, numberOfLives = 3, numberOfMines = 1;

            // Simulate input with invalid movement (e.g., 'X' is not a valid direction)
            var inputs = new Queue<char>(new[] { 'X', 'R', 'R', 'U', 'U' });
            Console.SetIn(new System.IO.StringReader(string.Join(Environment.NewLine, inputs)));

            // Act
            int finalScore = _minefieldService.RunAsync(rows, cols, numberOfLives, numberOfMines);

            // Assert
            Assert.AreEqual(4, finalScore); // 4 moves to reach the other corner
        }

        [TestMethod]
        public void Test_RunAsync_WhenExplosion_LossesLife()
        {
            // Arrange
            int finalScore = 0, livesLeft = 0, rows = 3, cols = 3, numberOfLives = 3;
            var inputs = new Queue<char>(new[] { 'R', 'U', 'R', 'U' });
            Console.SetIn(new System.IO.StringReader(string.Join(Environment.NewLine, inputs)));

            // Act
            (finalScore, livesLeft) = _minefieldService.PlayMineField(rows, cols, numberOfLives);

            // Assert
            Assert.AreEqual(4, finalScore); // 4 moves to reach the other corner
            Assert.AreEqual(2, livesLeft); // Number of lives decremented by 1
        }

        [TestMethod]
        public void Test_RunAsync_WhenNoExplosionAndWin()
        {
            // Arrange
            int finalScore = 0, livesLeft = 0, rows = 3, cols = 3, numberOfLives = 3;
            var inputs = new Queue<char>(new[] { 'R', 'R', 'U', 'U' });
            Console.SetIn(new System.IO.StringReader(string.Join(Environment.NewLine, inputs)));

            // Act
            (finalScore, livesLeft) = _minefieldService.PlayMineField(rows, cols, numberOfLives);

            // Assert
            Assert.AreEqual(4, finalScore); // 4 moves to reach the other corner
            Assert.AreEqual(3, livesLeft); // Number of lives 3 as initialized
        }

        [TestMethod]
        public void Test_PlayMineField_ShouldEndWhenNoLivesLeft()
        {
            // Arrange
            int finalScore = 0, livesLeft = 0, rows = 3, cols = 3, numberOfLives = 1;
            var inputs = new Queue<char>(new[] { 'R', 'U' });
            Console.SetIn(new System.IO.StringReader(string.Join(Environment.NewLine, inputs)));

            // Act
            (finalScore, livesLeft) = _minefieldService.PlayMineField(rows, cols, numberOfLives);

            // Assert
            Assert.AreEqual(2, finalScore); // The number of moves should be 2 as the game ends after 2 move (Explosion).
            Assert.AreEqual(0, livesLeft); // Number of lives 0
        }
    }
}