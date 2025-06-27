namespace task01;

public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
        if (input == null) return false;

        var cleaned = new string(input
            .Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c))
            .ToArray())
            .ToLower();

        if (cleaned.Length == 0) return false;

        return cleaned.SequenceEqual(cleaned.Reverse());
    }
}
