using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	internal class P16928
	{
		/*
		 
		 
		 
		 엌ㅋ 원트 개꿀
		 
		 
		 */
		static void Main(string[] args)
		{
			string[] s = Console.ReadLine().Split(' ');
			int N = int.Parse(s[0]);
			int M = int.Parse(s[1]);

			Dictionary<int, int> baem = new Dictionary<int, int>();

			for(int i = 0; i < N; i++)
			{
				s = Console.ReadLine().Split(' ');
				int x = int.Parse(s[0]);
				int y = int.Parse(s[1]);
				baem.Add(x, y);
			}
			for (int i = 0; i < M; i++)
			{
				s = Console.ReadLine().Split(' ');
				int x = int.Parse(s[0]);
				int y = int.Parse(s[1]);
				baem.Add(x, y);
			}

			// +1 ~ +6으로 1에서 100가기
			// 최소를 구하는거니까 BFS
			int step = 0;
			HashSet<int>[] isVisited = new HashSet<int>[21];
			isVisited[0] = new HashSet<int>();
			isVisited[0].Add(1);	// 0번째 스텝에서 1을 거쳤음 == 시작점임. 

			for(step = 1; step <= 20; step++)
			{
				isVisited[step] = new HashSet<int>();
				foreach(var cur in isVisited[step - 1])
				{
					for (int dice = 1; dice <= 6; dice++)
					{
						// 주사위굴린 목적지인데 뱀있으면 타고감
						int dest = baem.Keys.Contains(cur + dice) ? baem[cur + dice] : cur + dice;

						// 이전 step에서 이미 거쳐감? then continue;
						bool flag = false;
						for (int i = 0; i < step; i++)
						{
							flag = flag || isVisited[i].Contains(dest);
						}
						if (flag) continue;


						if (dest == 100) { Console.WriteLine(step); return; }

						isVisited[step].Add(dest);
					}
				}
			}
		}
	}
}
