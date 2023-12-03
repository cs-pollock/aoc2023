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

        matrix.GetLength(0).Should().Be(12);
        matrix.GetLength(1).Should().Be(11);
        matrix[3, 10].Should().Be(-1);
        matrix[4, 10].Should().Be(1);
    }

    [TestMethod]
    public void TestSingleNumber() {
        var matrix = Day03.ConvertInputToMatrix(Day03Data.SimpleInput02);
        Day03.IsPositionValid(matrix, 4, 10).Should().Be(true);
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
        numbers.Count.Should().Be(10);
        Assert.AreEqual(467, numbers[0].Number);
        CollectionAssert.AreEqual(new int[] {0, 1, 2}, numbers[0].Positions);
        Assert.AreEqual(598, numbers[numbers.Count - 1].Number);

        var numbers2 = Day03.GetNumberWithPositions(Day03Data.SimpleInput02);
        numbers2.Count.Should().Be(11);
        numbers2[5].Number.Should().Be(1);
    }

    [TestMethod]
    public void GetNumberInLine() {
        var numbers = Day03.GroupNumbersInLine("617*......1", 0, 10);
        numbers.Number.Should().Be(1);
    }

    [TestMethod]
    public void TestPositionValidator() {
        var matrix = Day03.ConvertInputToMatrix(Day03Data.SimpleInput02);
        Day03.IsPositionValid(matrix, 0, 0).Should().Be(false);
        Day03.IsPositionValid(matrix, 0, 1).Should().Be(false);
        Day03.IsPositionValid(matrix, 0, 2).Should().Be(true);
        Day03.IsPositionValid(matrix, 1, 2).Should().Be(true);
        Day03.IsPositionValid(matrix, 3, 1).Should().Be(false);
        Day03.IsPositionValid(matrix, 3, 2).Should().Be(true);
    }

    [TestMethod]
    public void TestNumberValidator() {
        var input = Day03Data.SimpleInput02;
        var matrix = Day03.ConvertInputToMatrix(input);
        var numbersWithPositions = Day03.GetNumberWithPositions(input);
        Assert.AreEqual(true, Day03.IsNumberValid(matrix, numbersWithPositions[0]));
        Assert.AreEqual(false, Day03.IsNumberValid(matrix, numbersWithPositions[1]));
        // Assert.AreEqual(false, Day03.IsNumberValid(matrix, numbersWithPositions[5]));
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
        Assert.AreEqual(4362, Day03.Solve(Day03Data.SimpleInput02));

        Debug.WriteLine("Solution 1 = " + Day03.Solve(Day03Data.FullInput));
    }

    [TestMethod]
    public void SolveExampleSparring() {
        Assert.AreEqual(3467, Day03.Solve(Day03Data.FullInputPartial_A));
    }
}