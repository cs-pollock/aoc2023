namespace aoc2023.Second;

[TestClass]
public class SecondTest
{
    [TestMethod]
    public void Test() {
        var line = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        var gameResult = Second.StringToGameResult(line);
        Assert.AreEqual(3, gameResult.Sets.Length);
        Assert.AreEqual(gameResult.Sets[0], new ColorSet(Red: 4, Green: 0, Blue: 3));
        Assert.AreEqual(gameResult.Sets[2], new ColorSet(Red: 0, Green: 2, Blue: 0));
    }
}