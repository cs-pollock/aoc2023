namespace aoc2023.Second;
public class Second
{
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