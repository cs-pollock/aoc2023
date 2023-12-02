using System.Diagnostics;
using aoc2023.UtilsNS;

namespace aoc2023.Day01NS;

[TestClass]
public class Day01Test
{
    [TestMethod]
    public void SplitByLines()
    {
        string[] splitted = Utils.SplitByLines(Day01.FirstInput);
        Assert.AreEqual("two934seven1", splitted[0]);
    }

    [TestMethod]
    public void SplitByLines2()
    {
        string[] splitted = Utils.SplitByLines(simple);
        Assert.AreEqual(4, splitted.Length);
    }

    [TestMethod]
    public void GetFirstNumberFromString()
    {
        var lineNumber = Day01.GetFirstNumber("1abc2");
        Assert.AreEqual(1, lineNumber);
    }

    [TestMethod]
    public void GetLineNumber()
    {
        var lineNumber = Day01.GetLineNumber("1abc2");
        Assert.AreEqual(12, lineNumber);
    }

    [TestMethod]
    public void CheckSolve()
    {
        var solution = Day01.SolveFirstChallenge(simple);
        Assert.AreEqual(142, solution);
    }

    [TestMethod]
    public void SolveFirst()
    {
        var solution = Day01.SolveFirstChallenge(Day01.FirstInput);
        Debug.Write($"Solution 1 = {solution}");
    }

    [TestMethod]
    public void SolveSecond()
    {
        var solution = Day01.SolveSecondChallenge(Day01.SecondInput);
        Debug.Write($"Solution 2 = {solution}");
    }

    [TestMethod]
    public void Sparring() {
        Assert.AreEqual(2, Day01.GetFirstNumber("two934seven1", false));
        Assert.AreEqual(21, Day01.SolveLineWithStrings("two934seven1"));
        Assert.AreEqual(88, Day01.SolveLineWithStrings("8fmmthreeeight6fiveight"));
    }

    private readonly string simple = @"
        1abc2
        pqr3stu8vwx
        a1b2c3d4e5f
        treb7uchet
    ";
}