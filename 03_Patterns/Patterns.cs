using System;

class Patterns
{
    static void Main()
    {
        //input
        int n = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            string[] lineArr = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
                arr[i, j] = int.Parse(lineArr[j]);
        }

        //check
        long maxSum = long.MinValue;
        bool found = false;
        for (int row = 0; row < n - 2; row++)
        {
            for (int col = 0; col < n - 4; col++)
            {
                if((arr[row,col] - arr[row, col+1]) == -1 &&
                   (arr[row,col] - arr[row, col+2]) == -2 &&
                   (arr[row,col] - arr[row+1, col+2]) == -3 &&
                   (arr[row,col] - arr[row+2, col+2]) == -4 &&
                   (arr[row,col] - arr[row+2, col+3]) == -5 &&
                   (arr[row,col] - arr[row+2, col+4]) == -6
                  )
                {
                    long sum = (long)arr[row, col] + (long)arr[row, col + 1] +
                        (long)arr[row, col + 2] + (long)arr[row + 1, col + 2] +
                        (long)arr[row + 2, col + 2] + (long)arr[row + 2, col + 3] +
                        (long)arr[row + 2, col + 4];
                    maxSum = Math.Max(sum, maxSum);
                    found = true;

                }
            }

        }
        if (found)
            Console.WriteLine("YES {0}", maxSum);
        else
        {
            maxSum = 0;
            for (int i = 0; i < n; i++)
                maxSum += (long)arr[i, i];
            Console.WriteLine("NO {0}", maxSum);
        }
    }
}