using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	internal class P14500
	{

		/*
		I 2, O 1, S 2, Z 2, L 4, J 4, T 4 ...19종
		
		1. 19종의 마스크를 만들고 다 씌워서 최댓값 찾기
			I...O((N-3)*M + (M-3)*N) -> O(N*M) 
			O...O((N-1)*(M-1)) -> O(N*M)
			SZLJT...O((N-2)*2*(M-1) + (M-2)*2*(N-2)) -> O(N*M)
			
			TOTALLY...O(23*N*M)
		
		1. [정답] ㅇㅅㅇ;;;
		
		 */

		public enum Mino
		{
			I, O, S, Z, L, J, T
		}

		static void DrawAllMask((int, int)[,] masks)
		{
			StringBuilder buf = new StringBuilder();
			for(int i = 0; i < masks.GetLength(0); i++)
			{
				HashSet<(int, int)> mask = new HashSet<(int, int)>
				{
					masks[i, 0],
					masks[i, 1],
					masks[i, 2],
					masks[i, 3],
				};
				for (int r = 0; r < 4; r++)
				{
					for (int c = 0; c < 4; c++)
					{
						if(mask.Contains((c, r)))
						{
							buf.Append('#');
						}
						else
						{
							buf.Append('O');
						}
					}
					buf.Append('\n');
				}
				buf.Append('\n');
			}
			Console.Write(buf);
		}
		static void Main(string[] args)
		{
			string[] input = Console.ReadLine().Split(' ');
			int N = int.Parse(input[0]);
			int M = int.Parse(input[1]);

			int[,] arr = new int[N, M];

			for (int i = 0; i < N; i++)
			{
				string[] row = Console.ReadLine().Split(' ');
				for (int j = 0; j < M; j++)
				{
					arr[i, j] = int.Parse(row[j]);
				}
			}

			// left-top pivot. 
			(int, int)[,] mino_mask =	// loop
			{
				// i mino
				{ (0, 0), (0, 1), (0, 2), (0, 3) },
				{ (0, 0), (1, 0), (2, 0), (3, 0) },
				// o mino
				{ (0, 0), (0, 1), (1, 0), (1, 1) },
				// s mino
				{ (0, 0), (0, 1), (1, 1), (1, 2) },
				{ (1, 0), (2, 0), (1, 1), (0, 1) },
				// z mino
				{ (0, 0), (1, 0), (1, 1), (2, 1) },
				{ (1, 0), (1, 1), (0, 1), (0, 2) },
				// j mino
				{ (0, 0), (1, 0), (2, 0), (2, 1) },
				{ (1, 0), (1, 1), (1, 2), (0, 2) },
				{ (0, 0), (1, 0), (0, 1), (0, 2) },
				{ (0, 0), (0, 1), (1, 1), (2, 1) },
				// L mino
				{ (0, 0), (1, 0), (2, 0), (0, 1) },
				{ (0, 0), (0, 1), (0, 2), (1, 2) },
				{ (0, 0), (1, 0), (1, 1), (1, 2) },
				{ (2, 0), (0, 1), (1, 1), (2, 1) },
				// T mino
				{ (1, 0), (0, 1), (1, 1), (2, 1) },
				{ (0, 0), (0, 1), (0, 2), (1, 1) },
				{ (0, 0), (1, 0), (2, 0), (1, 1) },
				{ (0, 1), (1, 0), (1, 1), (1, 2) },
			};

			//DrawAllMask(mino_mask);

			int max = 0;
			for(int r = 0; r < N; r++)
			{
				for(int c = 0; c < M; c++)
				{
					for (int i = 0; i < mino_mask.GetLength(0); i++)
					{
						(int, int)[] mask = new (int, int)[4]
						{
							mino_mask[i, 0],
							mino_mask[i, 1],
							mino_mask[i, 2],
							mino_mask[i, 3],
						};
						bool flag = false;
						int sum = 0;
						for(int k = 0; k < 4; k++)
						{
							int y = mask[k].Item2 + r;
							int x = mask[k].Item1 + c;
							if (x < 0 || x > M-1 || y < 0 || y > N - 1)
							{
								flag = true;
								break;
							}
							sum += arr[y, x];
						}
						if (flag) continue;

						max = max < sum ? sum : max;
					}
				}
			}
			Console.WriteLine(max);

		}
	}
}
