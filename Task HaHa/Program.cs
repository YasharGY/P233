  string Repeat(string word, int count)
{
    string repeatedString = "";
    for (int i = 0; i < count; i++)
    {
        repeatedString += word;
    }
    return repeatedString;
}
string repeatedString = Repeat("Ha!", 3);
Console.WriteLine(repeatedString);
