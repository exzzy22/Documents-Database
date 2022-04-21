namespace BillsCRUD_GUI
{
    public static class Extensions
    {
        /// <summary>
        /// Capitalize first letter of string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string input)
        {
            if (!String.IsNullOrEmpty(input) && !String.IsNullOrWhiteSpace(input))
            {
                return input.ToLower().First().ToString().ToUpper() + input.Substring(1);
            }
            else return String.Empty;
        }
        /// <summary>
        /// Loads all distinct categories from document list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<string?> GetCategories(this IEnumerable<DocumentDTO> list)
        {
            return list.Select(d => d.Category).Distinct();
        }
    }
}
