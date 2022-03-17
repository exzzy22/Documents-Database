namespace BillsCRUD_GUI
{
    public static class Extensions
    {
        /// <summary>
        /// Converts List<string> to string with ',' seperator beetween elements
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetString(this List<string> source)
        {
            return string.Join("", source);
        }

        /// <summary>
        /// Converts stream to byte array
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this Stream stream)
        {
            using (stream)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    stream.CopyTo(memStream);
                    return memStream.ToArray();
                }
            }
        }
        /// <summary>
        /// Converts stream to byte array
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task<byte[]> ToByteArrayAsync(this Stream stream)
        {
            using (stream)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memStream);
                    return memStream.ToArray();
                }
            }
        }
    }
}
