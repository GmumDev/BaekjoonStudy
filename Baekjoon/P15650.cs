using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Baekjoon
{
	internal class P15650
	{
		/*
		 
		 4 3
		1 2 3
		1 2 4
		1 3 4
		2 3 4

		 
		 
		 */

		public static int nCr(int n, int r)
		{
			r = Math.Min(r, (n - r));

			int bunmo = 1;
			for(int i = 0; i < r; i++)
			{
				bunmo *= n--;
			}
			int bunza = 1;
			for(int i = 0; i < r; i++)
			{
				bunza *= r--;
			}
			return bunmo / bunza;
		}
		public static void Main(string[] args)
		{
			int N;
			int M;
			string[] input = Console.ReadLine().Split(' ');

			N = int.Parse(input[0]);
			M = int.Parse(input[1]);

			StringBuilder buf = new StringBuilder();

			int[] row = new int[M];
			for (int i = 0; i < M; i++)
				row[i] = i + 1;
			for(int i = 0; i < nCr(N, M); i++)
			{

			}

		}
	}
}
