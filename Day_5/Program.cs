namespace Day_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1,1,1,1 };
            var r = new Solution().FindLHS(arr);
            Console.WriteLine(r);
        }
    }
    public class Solution
    {
        public long CountSubarrays(int[] nums, int k)
        {
            long max = nums.Max(), l = 0, r = nums.Length-1, ans = 0, count = 0;
            while (r < nums.Length)
            {
                if (nums[r] == max)
                {
                    count++;
                }
                while (count >= k)
                {
                    if (nums[l] == max)
                        count--;
                    ans += nums.Length - r;
                    l++;
                }
                r++;
            }
            return ans;
        }
        public int FindLHS(int[] nums)
        {
            int ans = 0;
            int r = 0, l = 0, n = nums.Length;
            Array.Sort(nums);
            while (r<n)
            {
                if (nums[r] == nums[l] || nums[r] - nums[l] == 1)
                {
                    r++;
                }
                else
                {
                    l++;
                }
                ans = nums[r-1] - nums[l] == 1 ? Math.Max(ans, r - l) : ans;
            }
            return ans;
        }

    }
}
