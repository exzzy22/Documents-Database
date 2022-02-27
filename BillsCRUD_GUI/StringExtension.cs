namespace BillsCRUD_GUI
{
    public static class StringExtension
    {
        public static string GetString(this List<string> source)
        {
            return string.Join(",", source);
        }
    }
}
