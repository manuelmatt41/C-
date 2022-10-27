namespace SummationTriangle
{
    internal class Program
    {
        public static long GetSum(int n)
        {
            int[][] triangle = new int[n + 1][];
            GetTriangle(ref triangle, n, n);
            long sum = 0;
            RecursiveSum(ref sum, triangle, n, n);
            return sum;
        }
        public static void RecursiveSum(ref long a, int[][] triangle, int col, int row)
        {
            if (col >= 0)
            {
                a += triangle[col][row];
                RecursiveSum(ref a, triangle, row > 0 ? col : col - 1, row > 0 ? row - 1 : col - 1);
            }
        }

        public static void GetTriangle(ref int[][] triangle, int col, int row)
        {
            if (col >= 0)
            {
                if (triangle[col] == null)
                {
                    triangle[col] = new int[row + 1];
                }
                triangle[col][row] = (2 * row + col + 1);
                triangle[col][row] *= col % 2 == 0 ? 1 : -1;
                GetTriangle(ref triangle, row > 0 ? col : col - 1, row > 0 ? row - 1 : col - 1);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetSum(500));
        }
    }
}