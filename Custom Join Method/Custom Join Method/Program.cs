 string CustomJoin(string[] arr, string separator)
{
    string result = string.Empty;

    for (int i = 0; i < arr.Length; i++)
    {
        result += arr[i];
        if (i < arr.Length - 1)
        {
            result += separator;
        }
    }

    return result;
}
