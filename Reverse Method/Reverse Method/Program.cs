public void ReverseArray(ref int[] arr)
{
    int temp;
    int start = 0;
    int end = arr.Length - 1;

    while (start < end)
    {
        temp = arr[start];
        arr[start] = arr[end];
        arr[end] = temp;
        start++;
        end--;
    }
}
