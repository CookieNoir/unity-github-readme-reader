public static class StringHelper
{
    public static bool IsFilled(string value)
    {
        return value != null && value.Length > 0;
    }
}
