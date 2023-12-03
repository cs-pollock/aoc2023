using System.Diagnostics;
using aoc2023.UtilsNS;

namespace aoc2023.Day03NS;
public class Day03
{
    private const int NumberForSymbol = -1; 

    public static int Solve(string input) {
        var matrix = ConvertInputToMatrix(input);
        var numbersWithPositions = GetNumberWithPositions(input);
        
        return numbersWithPositions.Aggregate(0, (agg, current) => 
            IsNumberValid(matrix, current) ? agg + current.Number : agg
        );
    }

    public static bool IsNumberValid(int?[,] matrix, NumberWithPositions number) {
        foreach (int x in number.Positions) {
            if (IsPositionValid(matrix, number.LineNumber, x)) {
                return true;
            }
        }

        return false;
    }

    public static bool IsPositionValid(int?[,] matrix, int y, int x) {
        var top = y - 1;
        var middle = y;
        var bottom = y + 1;

        int[] yPositions = {top, middle, bottom};
        int[] xPositions = {x - 1, x + 1};

        foreach (int yPos in yPositions) {
            foreach (int xPos in xPositions) {
                try {
                    if (matrix[yPos, xPos] == NumberForSymbol) {
                        return true;
                    }
                } catch {}
            }
        }

        return false;
    }

    public static int?[,] ConvertInputToMatrix(string input) {
        var lines = Utils.SplitByLines(input);
        int matrixX = lines[0].Length;
        int matrixY = lines.Length;
        var matrix = new int?[matrixY, matrixX];

        for (int y = 0; y < matrixY; y ++) {
            for (int x = 0; x < matrixX; x++) {
                char entry = lines[y][x];
                matrix[y, x] =
                    char.IsNumber(entry)
                    ? (int) char.GetNumericValue(entry)
                    : entry == '.'
                        ? null
                        : NumberForSymbol;
            }
        }

        return matrix;
    }

    public static List<NumberWithPositions> GetNumberWithPositions(string input) {
        var lines = Utils.SplitByLines(input);
        List<NumberWithPositions> foundNumbers = new(); 
        for (int y = 0; y < lines.Length; y ++) {
            var line = lines[y];
            for (int x = 0; x < line.Length; x++) {
                if (!char.IsNumber(line[x])) {
                    // Debug.WriteLine("Symbol = " + line[x]);
                    continue;
                }

                var foundNumber = GroupNumbers(line, y, x);
                foundNumbers.Add(foundNumber);
                x = foundNumber.Positions.Last();
            }
        }

        return foundNumbers;
    }

    private static NumberWithPositions GroupNumbers(string line, int yPos, int xStartPosition) {
        List<int> consecutivePositions = new() { xStartPosition };
        string number = "" + line[xStartPosition];

        for (int i = xStartPosition + 1; i < line.Length; i++) {
            if (!char.IsNumber(line[i])) {
                break;
            }
            number += line[i];
            consecutivePositions.Add(i);
        }

        return new NumberWithPositions(
            int.Parse(number),
            yPos,
            consecutivePositions.ToArray());
    }
}

public record NumberWithPositions (int Number, int LineNumber, int[] Positions);