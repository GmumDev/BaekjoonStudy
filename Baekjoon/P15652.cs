using System;
using System.Text;

namespace Baekjoon
{
	internal class P15652
	{

		/*
		
		 백트래킹 방식 구현? 은 잘 모르겠고

		일단 Que<Stack> 방식은 필요 없다. 
		row마다 출력하면 되므로. 

		 
		 */

		static StringBuilder buf = new StringBuilder();
		public static void Render(int[] row)
		{
			for(int i = 0; i < row.Length; i++)
			{
				buf.Append(row[i]);
				buf.Append(' ');
			}
			buf.Append('\n');
		}
		public static void Track(int[] row, int start, int m, int N, int M)
		{
			if (m > M) return;

			for (int i = start; i <= N; i++)
			{
				row[m - 1] = i;
				Track(row, i, m + 1, N, M);
				if(m == M)
				{
					Render(row);
				}
			}
		}

		public static void Main(string[] args)
		{
			int N;
			int M;
			string[] input = Console.ReadLine().Split(' ');

			N = int.Parse(input[0]);
			M = int.Parse(input[1]);

			int[] row = new int[M];
			Track(row, 1, 1, N, M);
			Console.Write(buf);

		}
	}
}
