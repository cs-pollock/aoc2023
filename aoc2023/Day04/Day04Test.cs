using FluentAssertions;

namespace aoc2023.Day04;
[TestClass]
public class Day04Test
{
    [TestMethod]
    public void Test_parser() {
        var result = Day04.ParseScratchCard("Card  1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");
        result.Id.Should().Be(1);

        result.Winning.Should().Equal(41, 48, 83, 86, 17);
        result.Mine.Should().Equal(83, 86, 6, 31, 17, 9, 48, 53);
    }

    [TestMethod]
    [DataRow("Card  1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8 )]
    [DataRow("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
    [DataRow("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
    [DataRow("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
    [DataRow("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
    [DataRow("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
    public void Test_matcher(string input,int expectedMatches) {
        var card = Day04.ParseScratchCard(input);
        var result = Day04.ComputeCardPoints(card);
        result.Should().Be(expectedMatches);
    }

    [TestMethod]
    [DataRow("Card  1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 4)]
    [DataRow("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
    [DataRow("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
    [DataRow("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
    [DataRow("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
    [DataRow("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
    public void Test_matcher_2(string input,int expectedMatches) {
        var card = Day04.ParseScratchCard(input);
        var result = Day04.ComputeCardMatches(card);
        result.Should().Be(expectedMatches);
    }

    [TestMethod]
    [DataRow("Card  1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 5)]
    [DataRow("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
    [DataRow("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
    [DataRow("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
    [DataRow("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
    [DataRow("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
    public void Test_parser_2(string input,int expectedPoints) {
        var result = Day04.ParseIntoSimpleCards(input);
        result.Length.Should().Be(1);
        result[0].Points.Should().Be(expectedPoints);
    }

    [TestMethod]
    public void Resolve_1() {
        Day04.Solve_01(Day04Data.SimpleInput_01).Should().Be(13);
        Day04.Solve_01(Day04Data.FullInput_01).Should().Be(26218);
    }

    [TestMethod]
    public void Resolve_2() {
        Day04.Solve_02(Day04Data.SimpleInput_01).Should().Be(30);
        Day04.Solve_02(Day04Data.SimpleInput_02).Should().Be(4);
        Day04.Solve_02(Day04Data.FullInput_01).Should().Be(9997537);
    }

}