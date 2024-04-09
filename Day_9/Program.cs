namespace Day_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new int[] { 1, 1, 1, 0, 0, 1 };
            var sandwiches = new int[] { 1, 0, 0, 0, 1, 1 };

            var r = new Solution().CountStudents(students, sandwiches);

        }
    }
    public class Solution
    {
        public int CountStudents(int[] students, int[] sandwiches)
        {
            var sIndex = 0;
            var queue = new Queue<int>();

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] == sandwiches[sIndex])
                {
                    sIndex++;
                }
                else
                {
                    queue.Enqueue(students[i]);
                }
            }
            int count = 0;
            while (queue.Count > 0 && queue.Count > count)
            {
                var i = queue.Dequeue();
                if (i == sandwiches[sIndex])
                {
                    count = 0;
                    sIndex++;
                }
                else
                {
                    queue.Enqueue((int)i);
                    count++;
                }
            }
            return sandwiches.Length - sIndex;
        }

        public int[] CountBits(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                dp[i] = dp[i >> 1] + i % 2;
            }
            return dp;
        }

        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            var ans = 0;

            for(int i = 0; i< tickets.Length; i++)
            {
                if(i > k)
                {
                    // Vì ở sau k nên nếu lớn hơn thì sẽ mất 1 lượt
                    ans += tickets[i] < tickets[k] ? tickets[i] : tickets[k] - 1;
                }
                else
                {
                    ans += tickets[i] < tickets[k] ? tickets[i] : tickets[k];
                }
            }

            return ans;
        }
    }
}
