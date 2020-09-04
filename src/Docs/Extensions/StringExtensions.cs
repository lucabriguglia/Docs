using System.Text;

namespace Docs.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string InsertSpaceBeforeUpperCase(this string str)
        {
            var sb = new StringBuilder();

            var previousChar = char.MinValue;

            foreach (var c in str)
            {
                if (char.IsUpper(c))
                {
                    if (sb.Length != 0 && previousChar != ' ')
                    {
                        sb.Append(' ');
                    }
                }

                sb.Append(c);

                previousChar = c;
            }

            return sb.ToString();
        }
    }
}
