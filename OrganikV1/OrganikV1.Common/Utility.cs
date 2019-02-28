using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace OrganikV1.Common
{
    public static class Utility
    {
        private static readonly char[] Chars = "abcdefghijklmnpqrstuvwxyz1234567890".ToCharArray();
        public static string GetRandomStr(int stringSize = 10)
        {
            var returns = "";
            var rnd = new Random();
            for (var i = 0; i < stringSize; i++)
            {
                returns += Chars[rnd.Next(Chars.Length)];
            }
            return returns;
        }
        public static string ToCleanUrl(this string s)
        {
            var sb = new StringBuilder(
                Regex.Replace(HttpUtility.HtmlDecode(s), @"(?!W+$)W+(?<!^W+)", "").Trim());

            sb.Replace(" ", "-").Replace(":", "").Replace(".", "")
                .Replace(";", "").Replace("&", "").Replace("#", "")
                .Replace("'", "").Replace("\"", "").Replace("%", "")
                .Replace("^", "").Replace(")", "").Replace("}", "")
                .Replace("(", "").Replace("{", "").Replace("<", "")
                .Replace(">", "").Replace(",", "").Replace(":", "")
                .Replace("+", "").Replace("*", "").Replace("/", "")
                .Replace("ü", "u").Replace("Ü", "U")
                .Replace("ö", "o").Replace("Ö", "O")
                .Replace("ı", "i").Replace("İ", "I")
                .Replace("ç", "c").Replace("Ç", "C")
                .Replace("ğ", "g").Replace("Ğ", "G")
                .Replace("ş", "s").Replace("Ş", "S");

            return sb.ToString().ToLower();
        }

        public static readonly  string  productKey = "productList";
        public static readonly string categoryKey = "categoryList";
        public static readonly string productPhotoKey = "productPhotoKey";
        public static readonly string commentKey = "commentList";


    }
}
