using Minefield;
using Minefield.Interfaces;
using Moq;

namespace MinefieldUnitTest
{
    [TestClass]
    public class MinefieldMovementUnitTest
    {
        private MinefieldMovement _minefieldMovement;

        [TestInitialize]
        public void SetUp()
        {
            // Initialize the MinefieldMovement object before each test.
            _minefieldMovement = new MinefieldMovement();
        }

        [TestMethod]
        public void Movement_ValidUpMove_UpdatesRow()
        {
            // Arrange
            int currentRow = 0;
            int currentCol = 0;
            int maxRow = 5;
            int maxCol = 5;

            // Simulate user input for 'U' (up move)
            string simulatedInput = "U";
            Console.SetIn(new StringReader(simulatedInput));

            // Act
            _minefieldMovement.Movement(ref currentRow, ref currentCol, maxRow, maxCol);

            // Assert
            Assert.AreEqual(1, currentRow); // The row should increment by 1
            Assert.AreEqual(0, currentCol); // The column should remain unchanged
        }

        [TestMethod]
        public void Movement_ValidDownMove_UpdatesRow()
        {
            // Arrange
            int currentRow = 1;
            int currentCol = 0;
            int maxRow = 5;
            int maxCol = 5;

            // Simulate user input for 'D' (down move)
            string simulatedInput = "D";
            Console.SetIn(new StringReader(simulatedInput));

            // Act
            _minefieldMovement.Movement(ref currentRow, ref currentCol, maxRow, maxCol);

            // Assert
            Assert.AreEqual(0, currentRow); // The row should decrement by 1
            Assert.AreEqual(0, currentCol); // The column should remain unchanged
        }

        [TestMethod]
        public void Movement_ValidLeftMove_UpdatesColumn()
        {
            // Arrange
            int currentRow = 0;
            int currentCol = 1;
            int maxRow = 5;
            int maxCol = 5;

            // Simulate user input for 'L' (left move)
            string simulatedInput = "L";
            Console.SetIn(new StringReader(simulatedInput));

            // Act
            _minefieldMovement.Movement(ref currentRow, ref currentCol, maxRow, maxCol);

            // Assert
            Assert.AreEqual(0, currentRow); // The row should remain unchanged
            Assert.AreEqual(0, currentCol); // The column should decrement by 1
        }

        [TestMethod]
        public void Movement_ValidRightMove_UpdatesColumn()
        {
            // Arrange
            int currentRow = 0;
            int currentCol = 0;
            int maxRow = 5;
            int maxCol = 5;

            // Simulate user input for 'R' (right move)
            string simulatedInput = "R";
            Console.SetIn(new StringReader(simulatedInput));

            // Act
            _minefieldMovement.Movement(ref currentRow, ref currentCol, maxRow, maxCol);

            // Assert
            Assert.AreEqual(0, currentRow); // The row should remain unchanged
            Assert.AreEqual(1, currentCol); // The column should increment by 1
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Movement_InvalidUpMove_ThrowsException()
        {
            // Arrange
            int currentRow = 5; // At the bottom row
            int currentCol = 0;
            int maxRow = 5;
            int maxCol = 5;

            // Simulate user input for 'U' (up move)
            string simulatedInput = "U";
            Console.SetIn(new StringReader(simulatedInput));

            // Act
            _minefieldMovement.Movement(ref currentRow, ref currentCol, maxRow, maxCol);
            // Assert: Exception should be thrown, so no assert is needed here
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Movement_InvalidDownMove_ThrowsException()
        {
            // Arrange
            int currentRow = 0; // At the top row
            int currentCol = 0;
            int maxRow = 5;
            int maxCol = 5;

            // Simulate user input for 'D' (down move)
            string simulatedInput = "D";
            Console.SetIn(new StringReader(simulatedInput));

            // Act
            _minefieldMovement.Movement(ref currentRow, ref currentCol, maxRow, maxCol);
            // Assert: Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Movement_InvalidLeftMove_ThrowsException()
        {
            // Arrange
            int currentRow = 0;
            int currentCol = 0; // At the leftmost column
            int maxRow = 5;
            int maxCol = 5;

            // Simulate user input for 'L' (left move)
            string simulatedInput = "L";
            Console.SetIn(new StringReader(simulatedInput));

            // Act
            _minefieldMovement.Movement(ref currentRow, ref currentCol, maxRow, maxCol);
            // Assert: Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Movement_InvalidRightMove_ThrowsException()
        {
            // Arrange
            int currentRow = 0;
            int currentCol = 5; // At the rightmost column
            int maxRow = 5;
            int maxCol = 5;

            // Simulate user input for 'R' (right move)
            string simulatedInput = "R";
            Console.SetIn(new StringReader(simulatedInput));

            // Act
            _minefieldMovement.Movement(ref currentRow, ref currentCol, maxRow, maxCol);
            // Assert: Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Movement_InvalidMove_ThrowsException()
        {
            // Arrange
            int currentRow = 0;
            int currentCol = 0;
            int maxRow = 5;
            int maxCol = 5;

            // Simulate user input for an invalid move (e.g., 'X')
            string simulatedInput = "X";
            Console.SetIn(new StringReader(simulatedInput));

            // Act
            _minefieldMovement.Movement(ref currentRow, ref currentCol, maxRow, maxCol);
            // Assert: Exception should be thrown
        }



    }
}