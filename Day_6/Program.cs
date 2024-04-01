namespace Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ans = new Solution().CountGoodSubstrings("aababcabc");
        }
    }

    public class Solution
    {
        public int CountGoodSubstrings(string s)
        {
            int ans = 0, l = 0, r = 0, n = s.Length;
            var dct = new Dictionary<char, int>();
            while (r < n)
            {
                if (!dct.ContainsKey(s[r])) 
                {
                    dct.Add(s[r], r);
                }
                else
                {
                    int i = dct[s[r]];
                    while (l < i)
                    {
                        dct.Remove(s[l++]);
                    }
                    dct[s[r]] = r;
                    l++;
                }
                if (dct.Count == 3)
                {
                    ans += r - l + 1 == 3 ? 1 : 0;
                    dct.Remove(s[l++]);
                }
                r++;
            }
            return ans;
        }

        public int LengthOfLastWord(string s)
        {
            s = s.TrimEnd();
            int length = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    break;
                }
                length++;
            }

            return length;
        }
    }
}
