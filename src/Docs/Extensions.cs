﻿using System.Text;

namespace Docs
{
    public static class Extensions
    {
        public static string InsertSpaceBeforeUpperCase(this string str)
        {
            var sb = new StringBuilder();

            var previousChar = char.MinValue; // Unicode '\0'

            foreach (var c in str)
            {
                if (char.IsUpper(c))
                {
                    // If not the first character and previous character is not a space, insert a space before uppercase
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
