namespace System
{
    public static class ToUpperRemovingBreaklinesExtension
    {
        public static string ToUpperRemovingBreaklines(this string text)
        {
            return text.ToUpperInvariant().Replace("\n", " ");
        }
    }
}
