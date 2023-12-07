using System.Diagnostics;
using System.Text.RegularExpressions;
using aoc2023.UtilsNS;

namespace aoc2023.Day04;    
public class Day04
{

    public static int Solve_01(string input) {
        return Utils.SplitByLines(input)
            .Select(cardString => ComputeCardPoints(ParseScratchCard(cardString)))
            .Aggregate(0, (total, cardResult) => total + cardResult);
    }

    public static int Solve_02(string input) {
        SimpleCard[] simpleCards = ParseIntoSimpleCards(input);
        int numberOfCards = simpleCards.Length;
        int wins = 0;

        for (int i = 0; i < numberOfCards; i++) {
            var newWins = ComputeWinsForCard(simpleCards, i);
            Debug.WriteLine($"Card {i + 1} wins {newWins}");
            wins += newWins;
        }

        return wins;
    }

    public static int Solve_02_02(string input) {
        SimpleCard[] simpleCards = ParseIntoSimpleCards(input);
        int numberOfCards = simpleCards.Length;
        int[] results = new int[simpleCards.Length];

        for (int i = simpleCards.Length - 1; i >= 0; i--) {
            var result2 = 1;
            for (int j = 1; j <= simpleCards[i].Matches; j ++) {
                var newIndex = i + j;
                if (newIndex <= results.Length) {
                    result2 += results[newIndex];
                }
            }
            results[i] = result2;
        }

        return results.Aggregate(0, (total, current) => total + current);
    }

    private static int ComputeWinsForCard(
        SimpleCard[] scratchcards,
        int currentIndex
    ) {
        int wins = 1;

        var points = scratchcards[currentIndex].Matches;
        
        for (int j = 1; j <= points; j++) {
            var nextCardIndex = currentIndex + j;
            if (nextCardIndex < scratchcards.Length) {
                wins += ComputeWinsForCard(scratchcards, nextCardIndex);
            }
        }

        return wins;
    }

    public static SimpleCard[] ParseIntoSimpleCards(string input) {
        return Utils.SplitByLines(input).Select(ParseScratchCard).Select(card => new SimpleCard(ComputeCardMatches(card))).ToArray();
    }

    public static Scratchcard ParseScratchCard(string input) {
        var splitted = input.Split(':');
        string[] allNumbers = splitted[1].Split('|');
        int[] winningNumbers = GetNumbersFromString(allNumbers[0]);
        int[] myNumbers = GetNumbersFromString(allNumbers[1]);

        return new(winningNumbers, myNumbers);

        static int[] GetNumbersFromString(string numberString) {
            return numberString.Replace("  ", " ").Trim().Split(null).Select(numberString => int.Parse(numberString.Trim())).ToArray();
        }
    }

    public static int ComputeCardPoints(Scratchcard scratchcard) {
        return scratchcard.Winning.Aggregate(0, (result, current) => {
            if (!scratchcard.Mine.Contains(current)) {
                return result;
            }

            return result == 0 ? 1 : result * 2;
        });
    }

    public static int ComputeCardMatches(Scratchcard scratchcard) {
        return scratchcard.Winning.Aggregate(0, (result, current) => 
            scratchcard.Mine.Contains(current)
                ? ++ result
                : result
        );
    }
}

public record Scratchcard(int[] Winning, int[] Mine);
public record SimpleCard(int Matches);