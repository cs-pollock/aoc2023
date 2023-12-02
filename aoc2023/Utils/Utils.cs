namespace aoc2023.Utils;
public class StringUtils
{
    public static string[] SplitByLines(string input)
    {
        var splitted = input.Split(
            new string[] { Environment.NewLine },
            StringSplitOptions.None
        );

        var clean = splitted.Select(a => a.Trim()).Where(a => !string.IsNullOrEmpty(a)).ToArray();
        return clean;
    }
}