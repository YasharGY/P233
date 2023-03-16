public static class StringExtensions
{
    public static int MatchCount(this string str, string pattern)
    {
        int count = 0;
        int i = 0;
        while ((i = str.IndexOf(pattern, i)) != -1)
        {
            i += pattern.Length;
            count++;
        }
        return count;
    }
}
