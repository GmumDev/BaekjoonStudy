using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	internal class P11660
	{
		/*
		 
			M이 100,000인데 N*N을 순회하며 더하는건 문제로서 말이 안되고

			누적 합을 저장해두면 편하다. 

			다이나믹 느낌

		 */
		static void Main(string[] args)
		{
			string[] input = Console.ReadLine().Split(' ');
			int N = int.Parse(input[0]);
			int M = int.Parse(input[1]);
			int[,] arr = new int[N, N];
			for (int i = 0; i < N; i++)
			{
				var tmp = Console.ReadLine().Split(' ');
				for (int j = 0; j < N; j++)
				{
					var curVal = int.Parse(tmp[j]);
					int up, left, upleft;
					up = left = upleft = 0;

					if(j != 0)
					{
						left = arr[i, j - 1];
					}
					if(i != 0)
					{
						up = arr[i - 1, j];
					}
					if(i != 0 && j != 0)
					{
						upleft = arr[i - 1, j - 1];
					}
					arr[i, j] = curVal + up + left - upleft;
				}
			}

			int x1, y1, x2, y2;
			StringBuilder buf = new StringBuilder();
			while(M-- > 0)
			{
				var tmp = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
				(x1, y1, x2, y2) = (tmp[0] - 1, tmp[1] - 1, tmp[2] - 1, tmp[3] - 1);

				// arr[y, x]에 (0, 0)~(x, y)누적된 값 저장
				x1--;
				y1--;
				int cur, up, left, upleft;
				cur = arr[x2, y2];
				up = left = upleft = 0;

				up = y1 < 0 ? 0 : arr[x2, y1];
				left = x1 < 0 ? 0 : arr[x1, y2];
				upleft = y1 < 0 || x1 < 0 ? 0 : arr[x1, y1];

				int result = cur - up - left + upleft;
				buf.Append(result);
				buf.Append('\n');
				
			}
			Console.WriteLine(buf);


		}
	}
}
