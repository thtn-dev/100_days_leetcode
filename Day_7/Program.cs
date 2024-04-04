namespace Day_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MaxDepth("(1+(2*3)+((8)/4))+1"));
        }
    }
    public class Solution
    {
        public int MaxDepth(string s)
        {
            char open = '(', close = ')';
            int count = 0;
            int max = int.MinValue;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
               if(c == open)
                {
                    count++;
                }
               if(c == close)
                {
                    max = Math.Max(count, max);
                    count--;
                }    

            }
            return max;
        }

        public bool Exist(char[][] board, string word)
        {
            var col = board[0].Length;
            var row = board.Length;
            
            bool backTracking(int i, int j, int k)
            {
                if (k == word.Length)
                {
                    return true;
                }
                if (i < 0 || i >= row || j < 0 || j >= col || board[i][j] != word[k])
                {
                    return false;
                }
                char temp = board[i][j];
                board[i][j] = '\0';

                bool up = backTracking(i, j - 1, k+1);
                bool down = backTracking(i, j + 1, k+1);
                bool left = backTracking(i - 1, j, k + 1);
                bool right = backTracking(i + 1, j, k + 1);

                if(up || down || left || right)
                {
                    return true;
                }
                board[i][j] = temp;
                return false;
            }

            for (int i = 0; i<row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (backTracking(i, j, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

       
    }
}
