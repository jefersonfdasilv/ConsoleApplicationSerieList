using System.Text.RegularExpressions;

namespace AppSerie.Domain
{
    internal class CleanInput
    {
        public static string Sanitize(string input)
        {
            try
            {
                return Regex.Replace(input, @"[\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5)).Trim();
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }
    }
}
