using System.Diagnostics;

namespace aoc2023;

[TestClass]
public class FirstTest
{
    [TestMethod]
    public void SplitByLines()
    {
        string[] splitted = First.SplitByLines(First.Input);
        Assert.AreEqual("two934seven1", splitted[0]);
    }

    [TestMethod]
    public void SplitByLines2()
    {
        string[] splitted = First.SplitByLines(simple);
        Assert.AreEqual(4, splitted.Length);
    }

    [TestMethod]
    public void GetFirstNumberFromString()
    {
        var lineNumber = First.GetFirstNumber("1abc2");
        Assert.AreEqual(1, lineNumber);
    }

    [TestMethod]
    public void GetLineNumber()
    {
        var lineNumber = First.GetLineNumber("1abc2");
        Assert.AreEqual(12, lineNumber);
    }

    [TestMethod]
    public void CheckSolve()
    {
        var solution = First.Solve(simple);
        Assert.AreEqual(142, solution);
    }

    [TestMethod]
    public void Solve()
    {
        var solution = First.Solve(First.Input);
        Debug.Write($"Solution = {solution}");
    }

    private readonly string simple = @"
        1abc2
        pqr3stu8vwx
        a1b2c3d4e5f
        treb7uchet
    ";
}