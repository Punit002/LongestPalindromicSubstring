namespace LongestPalindromicSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.LongestPalindrome("ac"));
            Console.ReadKey();
        }
    }

    public static class Solution
    {
        public static string LongestPalindrome(string s)
        {
            var palindromeString = new List<string>();
         
            CheckAndAddPalindrome(s, palindromeString);

            return palindromeString.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
        }

        private static void CheckAndAddPalindrome(string s, List<string> plindromeString)
        {
            var lsString = s.Select(item => item).ToList();

            var reverseString = new List<char>();

            for (int i = 0, j = lsString.Count - 1; i < lsString.Count; i++)
            {
                reverseString.Add(lsString[(lsString.Count - 1) - i]);
            }

            if (s == new string(reverseString.ToArray()))
            {
                plindromeString.Add(s);
            }

            if(lsString.Count > 2)
            {
                lsString.RemoveAt(0);
                lsString.RemoveAt(lsString.Count - 1);
                CheckAndAddPalindrome(new string(lsString.ToArray()), plindromeString);
            }

            if (lsString.Count == 2)
            {
                CheckAndAddPalindrome(lsString[0].ToString(), plindromeString);
                CheckAndAddPalindrome(lsString[1].ToString(), plindromeString);
            }
        }
    }
}