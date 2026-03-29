using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
    internal class P15654
    {
        /*
         
         
         
         
         
         
         */

        static StringBuilder buf = new StringBuilder();
        static bool isVisited(int[] row, int depth, int n)
        {
            for(int i = 0; i < row.Length && i < depth; i++)
            {
                if (row[i] == n) return true;
            }
            return false;
        }
        static void Render(int[] row, int M)
        {
            for(int i = 0; i < M; i++)
            {
                buf.Append(row[i]);
                buf.Append(" ");
            }
            buf.Append('\n');
        }
        static void Track(int[] row, int[] arr, int N, int M, int depth)
        {
            if (depth == M)
            {
                Render(row, M);
                return;
            }

            for (int i = 0; i < N; i++)
            {
                if (isVisited(row, depth, arr[i])) continue;
                
                row[depth] = arr[i];

                Track(row, arr, N, M, depth + 1);
            }
        }
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);


            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            // N <= 8
            Array.Sort(arr);
            int[] row = new int[N];
            HashSet<int> visited = new HashSet<int>();

            Track(row, arr, N, M, 0);

            Console.WriteLine(buf);

        }
    }
}
