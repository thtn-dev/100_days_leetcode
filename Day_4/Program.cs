namespace Day_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 10, 5,2,6 };
            int k = 100;
            int result = new Solution().NumSubarrayProductLessThanK(arr, k);
            Console.WriteLine($"res {result}" );
        }
    }
    public class Solution
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            int result = 0;
            Queue<int> q = new Queue<int>();
            int target = 1;
            for (int i = 0; i<nums.Length; i++)
            {
                
                    target *= nums[i];
                    q.Enqueue(nums[i]);
                    while(target >= k && q.Count > 0)
                    {
                        var x = q.Dequeue();
                        result += q.Count;
                        target /= x;
                   }
                
            }
            result += (q.Count * (q.Count + 1)) / 2;
            return result;
        }
        public int NumSubarrayProductLessThanK2(int[] nums, int k)
        {
            int l = 0, r = 0, p = 1, res = 0;
            while (r < nums.Length)
            {
                p *= nums[r];
                while (p >= k && l <= r)
                {
                    p /= nums[l];
                    l++;
                }
                res += r - l + 1;
                r++;
            }
            return res;
        }
        public int FirstMissingPositive(int[] nums)
        {
            int result = 0;
            int n = nums.Length;
            int[] lst = new int[n];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && nums[i] < n + 1)
                {
                    //nums[nums[i] - 1] = nums[i];
                    lst[nums[i] - 1] = nums[i];
                }
                else
                {
                    nums[i] = 0;
                }
            }
            for (int i = 0; i < lst.Length; i++)
            {
                if (lst[i] == 0)
                {
                    result = i + 1;
                    break;
                }
            }
            return result == 0 ? n + 1 : result;
        }
    }
}
