using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	internal class P10026
	{
		/*
		 
		 
		1. 각각 셈
		2. 큰거 세고 쪼개서 또 셈

		...ㅋㅋ 고민오래했는데
		그냥 재귀 두개 만들면 되네...
		 
		 
		 */

		static bool isOut(int N, int x, int y)
		{
			return x < 0 || y < 0 || x >= N || y >= N;
		}
		static void UpdateVisited(int N, char[,] arr, bool[,] isVisited,int x, int y, char c)
		{
			int[,] dirs =
			{
				{-1, 0 }, {1, 0 }, {0, 1 }, {0, -1 }
			};

			isVisited[y, x] = true;

			for (int i = 0; i < 4; i++)
			{
				int dx = x + dirs[i, 0];
				int dy = y + dirs[i, 1];
				if (isOut(N, dx, dy)) continue;
				if (isVisited[dy, dx]) continue;
				if (arr[dy, dx] == c)
				{
					UpdateVisited(N, arr, isVisited, dx, dy, c);
				}
			}
		}
		static void UpdateVisited_E(int N, char[,] arr, bool[,] isVisited, int x, int y, char c)
		{
			int[,] dirs =
			{
				{-1, 0 }, {1, 0 }, {0, 1 }, {0, -1 }
			};

			isVisited[y, x] = true;

			for (int i = 0; i < 4; i++)
			{
				int dx = x + dirs[i, 0];
				int dy = y + dirs[i, 1];
				if (isOut(N, dx, dy)) continue;
				if (isVisited[dy, dx]) continue;
				if (arr[dy, dx] == c || arr[dy, dx] == 'R' && c == 'G' || arr[dy,dx] == 'G' && c == 'R' )
				{
					UpdateVisited_E(N, arr, isVisited, dx, dy, c);
				}
			}
		}
		static void Main(string[] args)
		{
			int N = int.Parse(Console.ReadLine());

			char[,] arr = new char[N,N];
			bool[,] isVisited = new bool[N,N];
			bool[,] isVisitedByEyeless = new bool[N,N];

			int cnt = 0;
			int cnt_E = 0;

			for (int r = 0; r < N; r++)
			{
				char[] row = Console.ReadLine().ToArray();
				for(int c = 0; c < N; c++)
				{
					arr[r, c] = row[c];
				}
			}

			for(int r = 0; r < N; r++)
			{
				for(int c = 0; c < N; c++)
				{
					if (isVisited[r, c] == false)
					{
						cnt++;
						UpdateVisited(N, arr, isVisited, c, r, arr[r, c]);
					}

					if (isVisitedByEyeless[r, c] == false)
					{
						cnt_E++;
						UpdateVisited_E(N, arr, isVisitedByEyeless, c, r, arr[r, c]);
					}
				}
			}
			Console.WriteLine(cnt + " " + cnt_E);
		}
	}
}
