namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 1, 2, 1, 2 };
            int count2 = new Solution().SingleNumber(nums);
            Console.WriteLine(count2);
            var a = 2;
            a = a ^ 5;
            Console.WriteLine(~1);

        }
    }

    public class Solution
    {
        public int RemoveDuplicatesEasy(int[] nums)
        {
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[count] = nums[i];
                    count++;
                }
            }
            return count;
        }

        public int RemoveDuplicatesMedium(int[] nums)
        {
            int count = 1;
            int count2 = 1;
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i-1] != nums[i])
                {
                    nums[count] = nums[i];
                    count++;
                    count2 = 1;
                }else if (nums[i-1] == nums[i] && count2 < 2)
                {
                    nums[count] = nums[i];
                    count2++;
                    count++;
                }
            }
            return count;
        }
        public int SingleNumber(int[] nums)
        {
            Array.Sort(nums);
            for(int i = 0; i < nums.Length-1; i+=2)
            {
                if (nums[i] != nums[i + 1])
                    return nums[i];
            }
            return nums[nums.Length-1];
        }

        public int SingleNumberMedium(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i += 3)
            {
                if (nums[i] != nums[i + 2])
                    return nums[i];
            }
            return nums[nums.Length - 1];
        }
    }
}
