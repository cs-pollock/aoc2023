using System.Text.RegularExpressions;
using aoc2023.UtilsNS;

namespace aoc2023.Day04;    
public class Day04
{
    public static int Solve_01(string input) {
        return Utils.SplitByLines(input)
            .Select(cardString => ComputeCardResult(ParseScratchCard(cardString)))
            .Aggregate(0, (total, cardResult) => total + cardResult);
    }

    public static Scratchcard ParseScratchCard(string input) {
        var splitted = input.Split(':');
        int id = int.Parse(Regex.Split(splitted[0].Trim(), @"\s+")[1]);
        string[] allNumbers = splitted[1].Split('|');
        int[] winningNumbers = GetNumbersFromString(allNumbers[0]);
        int[] myNumbers = GetNumbersFromString(allNumbers[1]);

        return new(id, winningNumbers, myNumbers);

        static int[] GetNumbersFromString(string numberString) {
            return numberString.Replace("  ", " ").Trim().Split(null).Select(numberString => int.Parse(numberString.Trim())).ToArray();
        }
    }

    public static int ComputeCardResult(Scratchcard scratchcard) {
        return scratchcard.Winning.Aggregate(0, (result, current) => {
            if (!scratchcard.Mine.Contains(current)) {
                return result;
            }

            return result == 0 ? 1 : result * 2;
        });
    }
}

public record Scratchcard(int Id, int[] Winning, int[] Mine);