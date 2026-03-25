using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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

			재귀인데 Que 안에 Stack을 넣으
					 
		 
		 */


		public static Queue<Stack<int>> Jag(int M, int m, int start, int end)
		{
			if(m == M)
			{
				Queue<Stack<int>> queue = new Queue<Stack<int>>();
				for (int i = start; i <= end; i++)
				{
					var tmp = new Stack<int>();
					tmp.Push(i);
					queue.Enqueue(tmp);
				}
				return queue;
			}
			else
			{
				Queue<Stack<int>> queue = new Queue<Stack<int>>();
				for (int i = start; i <= end; i++)
				{
					var que = Jag(M, m + 1, i + 1, end);
					while (que.Count > 0)
					{
						var tmp = que.Dequeue();
						tmp.Push(i);
						queue.Enqueue(tmp);
					}	
				}
				return queue;
			}

		}
		public static void Main(string[] args)
		{
			int N;
			int M;
			string[] input = Console.ReadLine().Split(' ');

			N = int.Parse(input[0]);
			M = int.Parse(input[1]);

			StringBuilder buf = new StringBuilder();


			Queue<Stack<int>> que = Jag(M, 1, 1, N);
			while(que.Count > 0)
			{
				Stack<int> stack = que.Dequeue();
				while(stack.Count > 0)
				{
					int elem = stack.Pop();
					buf.Append(elem);
					buf.Append(' ');
				}
				buf.Append('\n');
			}
			Console.WriteLine(buf);	
		}
	}
}
