using System.Diagnostics;
using aoc2023.Day03NS;
using FluentAssertions;

namespace aoc2023.Day03NS;

[TestClass]
public class Day03Test
{
    [TestMethod]
    public void TestMatrixConverter() 
    {
        var matrix = Day03.ConvertInputToMatrix(Day03Data.SimpleInput02);

        // Assert.AreEqual(100, matrix.Length);
        matrix.GetLength(0).Should().Be(11);
        matrix.GetLength(1).Should().Be(10);
        // Assert.AreEqual(11, matrix.GetLength(0));
        // Assert.AreEqual(10, matrix.GetLength(1));

        // Assert.AreEqual(4, matrix[0, 0]);
        // Assert.AreEqual(6, matrix[0, 1]);
        // Assert.AreEqual(7, matrix[0, 2]);
        // Assert.AreEqual(null, matrix[0, 3]);
        // Assert.AreEqual(null, matrix[0, 4]);
        // Assert.AreEqual(1, matrix[0, 5]);
        // Assert.AreEqual(1, matrix[0, 6]);
        // Assert.AreEqual(4, matrix[0, 7]);
        // Assert.AreEqual(null, matrix[0, 8]);
    }

    [TestMethod]
    public void TestMatrixConverter02() 
    {
        var matrix = Day03.ConvertInputToMatrix(Day03Data.FullInput);
        matrix.GetLength(0).Should().Be(140);
        matrix.GetLength(1).Should().Be(140);
    }

    [TestMethod]
    public void TestNumberGrouper() 
    {
        var numbers = Day03.GetNumberWithPositions(Day03Data.SimpleInput);
        Assert.AreEqual(10, numbers.Count);
        Assert.AreEqual(467, numbers[0].Number);
        CollectionAssert.AreEqual(new int[] {0, 1, 2}, numbers[0].Positions);
        Assert.AreEqual(598, numbers[numbers.Count - 1].Number);
    }

    [TestMethod]
    // [DataRow(false, 0, 0)]
    // [DataRow(true, 0, 2)]
    // [DataRow(true, 1, 3)]
    // [DataRow(true, 2, 3)]
    // public void TestPositionValidator(bool isValid, int xPos, int yPos) {
    public void TestPositionValidator() {
        var matrix = Day03.ConvertInputToMatrix(Day03Data.SimpleInput);
        Day03.IsPositionValid(matrix, 0, 0).Should().Be(false);
        Day03.IsPositionValid(matrix, 0, 1).Should().Be(false);
        Day03.IsPositionValid(matrix, 0, 2).Should().Be(true);
        Day03.IsPositionValid(matrix, 1, 2).Should().Be(true);
        Day03.IsPositionValid(matrix, 3, 1).Should().Be(false);
        Day03.IsPositionValid(matrix, 3, 2).Should().Be(true);
        // Assert.AreEqual(isValid, Day03.IsPositionValid(matrix, xPos, yPos));
    }

    [TestMethod]
    public void TestNumberValidator() {
        var input = Day03Data.SimpleInput02;
        var matrix = Day03.ConvertInputToMatrix(input);
        var numbersWithPositions = Day03.GetNumberWithPositions(input);
        Assert.AreEqual(true, Day03.IsNumberValid(matrix, numbersWithPositions[0]));
        Assert.AreEqual(false, Day03.IsNumberValid(matrix, numbersWithPositions[1]));
        Assert.AreEqual(false, Day03.IsNumberValid(matrix, numbersWithPositions[5]));
    }

    [TestMethod]
    public void TestNumberValidator02() {
        var input = Day03Data.FullInput;
        var matrix = Day03.ConvertInputToMatrix(input);
        var numbersWithPositions = Day03.GetNumberWithPositions(input);

        numbersWithPositions[0].Number.Should().Be(440);
        Day03.IsNumberValid(matrix, numbersWithPositions[0]).Should().Be(false);
        
        numbersWithPositions[1].Number.Should().Be(418);
        Day03.IsNumberValid(matrix, numbersWithPositions[1]).Should().Be(false);

        numbersWithPositions[3].Number.Should().Be(438);
        Day03.IsNumberValid(matrix, numbersWithPositions[3]).Should().Be(true);

        numbersWithPositions[7].Number.Should().Be(870);
        numbersWithPositions[7].LineNumber.Should().Be(0);

        numbersWithPositions[8].Number.Should().Be(338);
        numbersWithPositions[8].LineNumber.Should().Be(1);
    }

    [TestMethod]
    public void SolveExample() {
        Assert.AreEqual(4361, Day03.Solve(Day03Data.SimpleInput02));

        Debug.WriteLine("Solution 1 = " + Day03.Solve(Day03Data.FullInput));
    }
}