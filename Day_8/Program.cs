using System.Text;

namespace Day_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MinRemoveToMakeValid("a)b(c)d"));
        }
    }
    public class Solution
    {
        public string MinRemoveToMakeValid(string s)
        {
            var open = '(';
            var close = ')';
            var ans = new StringBuilder();
            var stackOpen = new Stack<int>();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == open)
                {
                    stackOpen.Push(i);
                    ans.Append(s[i]);
                    continue;
                }
                if (s[i] == close)
                {
                    if(stackOpen.Count > 0)
                    {
                        stackOpen.Pop();
                        ans.Append(s[i]);
                        continue;
                    }
                    else
                    {
                        count++;
                        continue; 
                    }
                }
                ans.Append(s[i]);
            }
            while (stackOpen.Count > 0)
            {
                var item = stackOpen.Pop();
                item -= count;
                ans.Remove(item, 1);
            }
            return ans.ToString();
        }
        public string MakeGood(string s)
        {
            var ans = new StringBuilder();
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (stack.Count > 0 && Math.Abs(stack.Peek() - s[i]) == 32)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
            while (stack.Count > 0)
            {
                ans.Insert(0, stack.Pop());
            }
            return ans.ToString();
        }
    }
   
}
