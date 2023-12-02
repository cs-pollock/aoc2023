using aoc2023.UtilsNS;

namespace aoc2023.Day02NS;
public class Day02
{
    public const int RedLimit = 12;
    public const int GreenLimit = 13;
    public const int BlueLimit = 14;

    public static bool IsGameWithinLimit(ColorSet[] sets) {
        return !sets.Any(set =>
            set.Blue > BlueLimit
            || set.Green > GreenLimit
            || set.Red > RedLimit
        );
    }

    public static ColorSet GetMinimumInSets(ColorSet[] sets) {
        int red = 0;
        int green = 0;
        int blue = 0;

        foreach(ColorSet set in sets) {
            if (set.Red > red) {
                red = set.Red;
            }

            if (set.Green > green) {
                green = set.Green;
            }

            if (set.Blue > blue) {
                blue = set.Blue;
            }
        }

        return new (red, green, blue);
    }

    public static int GetPower(ColorSet colorSet) {
        return colorSet.Green * colorSet.Blue * colorSet.Red;
    }

    public static int Resolve_1(string input) {
        string[] inputLines = Utils.SplitByLines(input);
        var gameResults = inputLines.Select(StringToGameResult);
        return gameResults.Aggregate(0, (agg, game) => IsGameWithinLimit(game.Sets) ? agg + game.Id : agg);
    }

    public static int Resolve_2(string input) {
        string[] inputLines = Utils.SplitByLines(input);
        var gameResults = inputLines.Select(StringToGameResult);
        return gameResults.Aggregate(0, (agg, game) => agg + GetPower(GetMinimumInSets(game.Sets)));
    }

    public static GameResult StringToGameResult(string input) {
        var splitted = input.Split(':');
        
        var gameString = splitted[0];
        var gameId = int.Parse(gameString.Split(null)[1]);

        string cubeSetsString = splitted[1];
        string[] cubeSets = cubeSetsString.Split(';');

        List<ColorSet> colorSets = new();

        foreach(string cubeSet in cubeSets) {
            var colorNumberPairs = cubeSet.Split(',');

            int red = 0;
            int green = 0;
            int blue = 0;
            foreach(string pair in colorNumberPairs) {
                var trimmed = pair.Trim();

                if (trimmed.Contains("red")) {
                    red = int.Parse(trimmed.Split(null)[0]);
                }

                else if (trimmed.Contains("green")) {
                    green = int.Parse(trimmed.Split(null)[0]);
                }

                else if (trimmed.Contains("blue")) {
                    blue = int.Parse(trimmed.Split(null)[0]);
                }
            }
            colorSets.Add(new(red, green, blue));
        }

        return new GameResult(
            gameId,
            colorSets.ToArray()
        );
    }

    public static readonly string SimpleInput = @"
        Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
        Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
        Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
        Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
    ";
}

public record GameResult(int Id, ColorSet[] Sets);
public record ColorSet(int Red, int Green, int Blue);