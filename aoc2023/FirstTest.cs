using System.Diagnostics;

namespace aoc2023;

[TestClass]
public class FirstTest
{
    [TestMethod]
    public void SplitByLines()
    {
        string[] splitted = First.SplitByLines(First.FirstInput);
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
        var solution = First.SolveFirstChallenge(simple);
        Assert.AreEqual(142, solution);
    }

    [TestMethod]
    public void SolveFirst()
    {
        var solution = First.SolveFirstChallenge(First.FirstInput);
        Debug.Write($"Solution 1 = {solution}");
    }

    [TestMethod]
    public void SolveSecond()
    {
        var solution = First.SolveSecondChallenge(First.SecondInput);
        Debug.Write($"Solution 2 = {solution}");
    }

    [TestMethod]
    public void Sparring() {
        Assert.AreEqual(2, First.GetFirstNumber("two934seven1", false));
        Assert.AreEqual(21, First.SolveLineWithStrings("two934seven1"));
        Assert.AreEqual(88, First.SolveLineWithStrings("8fmmthreeeight6fiveight"));
    }

    private readonly string simple = @"
        1abc2
        pqr3stu8vwx
        a1b2c3d4e5f
        treb7uchet
    ";
}