using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	internal class P9019
	{
		/*
		 
		 이것도 생긴게 BFS같은데
		ROOT -> (D, S, L, R) -> Other Node 1 ~ 4 -> 
		 
		 1. [시간초과] S n==1에서 n==0으로 수정
		 2. [시간초과] 혹시 T가 많은가 buf로 출력해보기로 ㅏㅎㅁ
		3. [시간초과] 생각해보니 step을 구분해서 visited를 파악할 필요가 없음. visited를 하나 더 추가함. 
		4. [메모리 초과] 직전 스텝의 메모리만 참조하도록 변경
		5. [메모리 초과] BFS를 잘못 이해하고 있는 것 같아 다시 공부했다.
		6. [메모리 초과] que만 씀
		7. [메모리 초과] 갈아엎기
		8. [정답]
		string을 누적하여 저장했던 것이 가장 큰 원인. 
			- 근본적으로는, 숫자 범위가 0~9999이므로 10000칸의 visited, path, parents 배열로 해결할 수 있었음. 
			- 역추적 문제. 경로를 누적하여 저장하면 메모리가 오버나므로 누적하지 않은 경로만 저장하고 최종적으로 역추적
				- 역추적시 경로를 저장한 배열과 부모 노드의 위치를 저장한 배열이 동시에 필요함. 
				- 즉 2n 만큼의 공간이 필요. n은 숫자의 범위
			- 탐색 단계에서 n 만큼의 visited 배열이 필요하므로 최종적으로는 3n의 공간 필요

			- C#은 string 오버헤드가 매우 큰 편이다. 특히 + 연산이 Copy를 포함해서 메모리를 겁나 잡는다. 
				- pulling?

		 */


		static void Main(string[] args)
		{
			int T = int.Parse(Console.ReadLine());

			int[] arr = new int[4];
			while(T-->0)
			{
				string[] s = Console.ReadLine().Split(' ');
				int start = int.Parse(s[0]);
				arr[0] = start / 1000;
				arr[1] = start % 1000 / 100;
				arr[2] = start % 100 / 10;
				arr[3] = start % 10;

				int dest = int.Parse(s[1]);

				bool[] isVisited = new bool[10000];
				int[] parent = new int[10000];
				string[] path = new string[10000];

				Queue<int> que = new Queue<int>();
				que.Enqueue(start);
				isVisited[start] = true;
				while(true)
				{
					int n = que.Dequeue();

					// D
					int nn = (n * 2) % 10000;
					if (isVisited[nn] == false)
					{
						que.Enqueue(nn);
						isVisited[nn] = true;
						parent[nn] = n;
						path[nn] = "D";
						if (nn == dest) break;
					}

					// S
					nn = n == 0 ? 9999 : n - 1;
					if (isVisited[nn] == false)
					{
						que.Enqueue(nn);
						isVisited[nn] = true;
						parent[nn] = n;
						path[nn] = "S";
						if (nn == dest) break;
					}

					// L
					nn = (n % 1000 / 100) * 1000 + (n % 100 / 10)*100 + (n % 10)*10 + (n / 1000);
					if (isVisited[nn] == false)
					{
						que.Enqueue(nn);
						isVisited[nn] = true;
						parent[nn] = n;
						path[nn] = "L";
						if (nn == dest) break;
					}

					// R
					nn = (n % 10) * 1000 + (n / 1000) * 100 + (n % 1000 / 100) * 10 + (n % 100 / 10);
					if (isVisited[nn] == false)
					{
						que.Enqueue(nn);
						isVisited[nn] = true;
						parent[nn] = n;
						path[nn] = "R";
						if (nn == dest) break;
					}
				}

				int rev = dest;
				string result = "";

				while(start != rev)
				{
					result += path[rev];
					rev = parent[rev];
				}
				StringBuilder buf = new StringBuilder();
				for (int i = 0; i < result.Length; i++)
					buf.Append(result[result.Length - 1 - i]);
				Console.WriteLine(buf);
			}
		}
	}
}
