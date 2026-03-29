using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	internal class P11725
	{
		/*
		 
		N개의 노드가 존재. 각 노드의 idx는 1부터 시작하여 N까지 포함. 
		간선도 N개 주어짐. 
				// 입력마다 반드시 새로운 노드가 포함됨. 
		 
		1. [오답]
			간선 입력시 이전에 입력된 간선이 하나라도 포함되어 있지 않다면 누가 부모인지 알 수 없다 
		
			- 입력 단계에서 부모/자식 여부를 확정할 수 있는지?
				: 불가능. 
		2. [메모리 초과]
			- N * N 크기의 isConnected 배열
			- 그야? N이 최대 100,000인데? N * N 그리드를 만들면 메모리가 초과되겠지 아무래도

		3. [시간 초과]
			입력 받는데 N
			탐색하는데 N*N
			출력하는데 N

			입력 저장 방법?
			부모-자식여럿 가능
			부모인지 자식인지 입력때는 모름

			그럼 node -> [node, node, ...]식으로 참조해야됨. 

			걍 트리를 만들어
		 */


		public class Node
		{
			public int val;
			public List<Node> connectTo;
			public Node() { connectTo = new List<Node>(); }
		}
		public static void Main(string[] args)
		{
			StringBuilder buf = new StringBuilder();

			int N = int.Parse(Console.ReadLine());

			List<int>[] connection = new List<int>[N + 1];
			for(int i = 0; i< N-1; i++)
			{
				string[] input = Console.ReadLine().Split(' ');
				int a = int.Parse(input[0]);
				int b = int.Parse(input[1]);
				// let a < b
				if (a > b) (a, b) = (b, a);
				if (connection[a] == null) connection[a] = new List<int>();
				connection[a].Add(b);
			}

			int[] parent = new int[N + 1];
			Queue<int> que = new Queue<int>();
			que.Enqueue(1);
			while(que.Count > 0)
			{
				int par = que.Dequeue();
				for(int i = 0; i < connection[par].Count; i++)
				{
					//connection[par][i];
				}
			}
			



			Console.Write(buf);

		}
	}
}
