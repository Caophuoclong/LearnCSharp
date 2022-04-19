namespace learncsharp;

static class LearnMethod
{
    // PASS VALUE
    public static int[] swap(int x1, int y)
    {
        int[] arr = new int[2];
        int temp = x1;
        x1 = y;
        y = temp;
        arr[0] = x1;
        arr[1] = y;
        return arr;
    }
    // PASS REFERENCE
    public static void swap(ref int x1, ref int y)
    {
        int temp = x1;
        x1 = y;
        y = temp;
    }

}