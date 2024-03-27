using System.Collections;

namespace Day_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "abcabcdebb";
            var r = new Solution().LengthOfLongestSubstring(s);
            Console.WriteLine(r);
        }
    }

    public class Solution
    {
        #region LengthOfLongestSubstring
        ///// <summary>
        ///// Bad 
        ///// </summary>
        //public int LengthOfLongestSubstring(string s)
        //{
        //    int result = 0;
        //    var maxSliding = 0;
        //    for (int i = 0; i< s.Length; i++)
        //    {
        //        var sliding = 1;
        //        Dictionary<char, int> map = new Dictionary<char, int>();
        //        map.Add(s[i], 1);
        //        for (int j = i+1; j<s.Length; j++)
        //        {
        //            if (!map.ContainsKey(s[j]))
        //            {
        //                map.Add(s[j], 1);
        //                sliding++;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //        if(sliding > maxSliding)
        //            maxSliding = sliding;
        //    }
        //    return maxSliding;
        //}

        //// Bad
        //public int LengthOfLongestSubstring(string s)
        //{
        //    if (string.IsNullOrEmpty(s)) return 0;
        //    int max = 0;
        //    HashSet<char> chars = new HashSet<char>();
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (chars.Contains(s[i]))
        //        {
        //            max = Math.Max(max, chars.Count);
        //            i -= (chars.Count-1);
        //            chars = new HashSet<char>();
        //            chars.Add(s[i]);
        //            continue;
        //        }
        //        chars.Add(s[i]);
        //    }

        //    return Math.Max(max, chars.Count);
        //}

        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            if (s.Length == 1) return 1;
            int result = 0;
            int step = 0;
            var hs = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                while (hs.Contains(s[i]))
                {
                    hs.Remove(s[step++]);
                    if (step == i) break;
                }
                result = Math.Max(result, i - step + 1);
                hs.Add(s[i]);
            }
            return result;
        }
        #endregion

        #region FindDuplicates
        public IList<int> FindDuplicates(int[] nums)
        {
            var lst = new List<int>();
            int totalSwap = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0) continue;
                var index = nums[i] - 1;
                if (nums[index] == nums[i] && nums[index] - 1 != i)
                {
                    lst.Add(nums[i]);
                    nums[i] = -1;
                }
                else if (nums[index] - 1 != i)
                {
                    (nums[index], nums[i]) = (nums[i], nums[index]);
                    totalSwap++;
                    if (nums[i] - 1 == i)
                    {
                        i += totalSwap - 1;
                        totalSwap = 0;
                    }
                    else
                    {
                        i--;
                    }

                }
            }
            return lst;
        }
        #endregion
    }
}
