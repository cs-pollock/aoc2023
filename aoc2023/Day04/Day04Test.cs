using FluentAssertions;

namespace aoc2023.Day04;
[TestClass]
public class Day04Test
{
    [TestMethod]
    public void Test() {
        var result = Day04.ParseScratchCard("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");
        result.Id.Should().Be(1);

        result.Winning.Should().Equal(41, 48, 83, 86, 17);
        result.Mine.Should().Equal(83, 86, 6, 31, 17, 9, 48, 53);
    }

}