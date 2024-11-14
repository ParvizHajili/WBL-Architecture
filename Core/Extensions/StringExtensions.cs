namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static string[] SplitStringBySeperator(this string str)
        {
            return str.Split("*#");
        }
    }
}
