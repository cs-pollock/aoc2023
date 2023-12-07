namespace aoc2023.Day04;    
public class Day04
{
    public static Scratchcard ParseScratchCard(string input) {
        var splitted = input.Split(':');
        int id = int.Parse(input.Split(':')[0].Trim().Split(null)[1]);
        string[] allNumbers = splitted[1].Split('|');
        int[] winningNumbers = GetNumbersFromString(allNumbers[0]);
        int[] myNumbers = GetNumbersFromString(allNumbers[1]);

        return new(id, winningNumbers, myNumbers);

        static int[] GetNumbersFromString(string numberString) {
            return numberString.Replace("  ", " ").Trim().Split(null).Select((string number) => int.Parse(number.Trim())).ToArray();
        }
    }
}

public record Scratchcard(int Id, int[] Winning, int[] Mine);