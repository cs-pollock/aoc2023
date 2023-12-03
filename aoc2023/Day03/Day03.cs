using aoc2023.UtilsNS;

namespace aoc2023.Day03NS;
public class Day03
{
    private const int NumberForSymbol = -1;
    private const int NumberForGear = -2;

    public static int Solve_1(string input) {
        var matrix = ConvertInputToMatrix(input);
        var numbersWithPositions = GetNumberWithPositions(input);
        
        return numbersWithPositions.Aggregate(0, (agg, current) => 
            IsNumberValid(matrix, current) ? agg + current.Number : agg
        );
    }

    public static int Solve_2(string input) {
        return GetGears(input).Aggregate(0, (acc, current) => acc + GetGearRatio(current));
    }

    private static int GetGearRatio(NumberWithPositions[] numbersForGears) {
        return numbersForGears.Aggregate(1, (acc, current) => acc * current.Number);
    }

    public static List<NumberWithPositions[]> GetGears(string input) {
        var matrix = ConvertInputToMatrix(input);
        var allNumbers = GetNumberWithPositions(input);

        List<NumberWithPositions[]> numbersForGearsFound = new();
        for (int y = 0; y < matrix.GetLength(0); y++) {
            for (int x = 0; x < matrix.GetLength(1); x++) {
                // Find each gear
                var currentChar = matrix[y, x];
                if (currentChar != NumberForGear) {
                    continue;
                }

                List<Coordinate> coordsWithNumbers = GetCoordsWithNumbersAroundPoint(new Coordinate(y, x));
                NumberWithPositions[] numbersInCoords = coordsWithNumbers.Select(coords => allNumbers.Find(number => number.Coords.Any(numCoords => numCoords == coords))).ToArray()!;

                // Remove possible number duplicates by ID
                NumberWithPositions[] uniqueNumbersInCoords = numbersInCoords.GroupBy(numbers => numbers.Id).Select(x => x.First()).ToArray();

                if (uniqueNumbersInCoords.Length != 2) {
                    continue;
                }
                numbersForGearsFound.Add(uniqueNumbersInCoords);
            }
        }

        return numbersForGearsFound;

        List<Coordinate> GetCoordsWithNumbersAroundPoint(Coordinate centralCoord) {
            List<Coordinate> coordsWithNumbers = new();
            foreach (Coordinate coord in MakeCoordinatesToCheck(centralCoord)) {
                int? numberInCoord = matrix[coord.Y, coord.X];
                if (numberInCoord != null && numberInCoord != NumberForGear && numberInCoord != NumberForSymbol) {
                    coordsWithNumbers.Add(coord);
                }
            }

            return coordsWithNumbers;
        }
    }

    public static bool IsNumberValid(int?[,] matrix, NumberWithPositions number) {
        foreach (int x in number.Positions) {
            if (IsPositionValid(matrix, number.LineNumber, x)) {
                return true;
            }
        }

        return false;
    }

    private static Coordinate[] MakeCoordinatesToCheck(Coordinate centralCoord) {
        var y = centralCoord.Y;
        var x = centralCoord.X;

        Coordinate[] coordinatesToCheck = {
            new(y - 1, x - 1),
            new(y - 1, x),
            new(y - 1, x + 1),

            new(y, x - 1),
            new(y, x + 1),

            new(y + 1, x - 1),
            new(y + 1, x),
            new(y + 1, x + 1),
        };

        return coordinatesToCheck;
    }

    public static bool IsPositionValid(int?[,] matrix, int y, int x) {
        foreach (Coordinate coord in MakeCoordinatesToCheck(new Coordinate(y, x))) {
            try {
                if (matrix[coord.Y, coord.X] == NumberForSymbol || matrix[coord.Y, coord.X] == NumberForGear) {
                    return true;
                }
            } catch {}
        }

        return false;
    }

    public static bool IsPositionNextToGear(int?[,] matrix, int y, int x) {
        foreach (Coordinate coord in MakeCoordinatesToCheck(new Coordinate(y, x))) {
            try {
                if (matrix[coord.Y, coord.X] == NumberForGear) {
                    return true;
                }
            } catch {}
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
                        :  entry == '*'
                            ? NumberForGear
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
                    continue;
                }

                var foundNumber = GroupNumbersInLine(line, y, x);
                foundNumbers.Add(foundNumber);
                x = foundNumber.Positions.Last();
            }
        }

        return foundNumbers;
    }

    public static NumberWithPositions GroupNumbersInLine(string line, int yPos, int xStartPosition) {
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
            Guid.NewGuid(),
            int.Parse(number),
            yPos,
            consecutivePositions.ToArray(),
            consecutivePositions.Select(xPos => new Coordinate(yPos, X: xPos)).ToArray()
        );
    }
}

public record NumberWithPositions (Guid Id, int Number, int LineNumber, int[] Positions, Coordinate[] Coords);
public record NumberNextToGear (int Number, Coordinate GearCoord);
public record Coordinate(int Y, int X);