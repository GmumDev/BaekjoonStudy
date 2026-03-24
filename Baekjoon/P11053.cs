using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	internal class P11053
	{
		/*
		 

		
		 
		 */
		static void Main(string[] args)
		{
			int N = int.Parse(Console.ReadLine());
			int[] arr = Console.ReadLine().Split(' ').Select((x) => int.Parse(x)).ToArray();

			(int, int)[] parentID_length_pair = new (int, int)[N];
			int max = 0;
			for(int i = 0; i < N; i++)
			{
					
				int parent = i - 1;
				parentID_length_pair[i] = (parent, 1);
				(int, int) max_parent_cnt_pair = (-1, 1);
				while (parent != -1)
				{
					if (arr[i] > arr[parent])
					{
						if (parentID_length_pair[i].Item2 < parentID_length_pair[parent].Item2 + 1)
						{
							parentID_length_pair[i] = (parent, parentID_length_pair[parent].Item2 + 1);
							max_parent_cnt_pair = (parent, parentID_length_pair[i].Item2);
						}
					}
					parent--;
				}
				parentID_length_pair[i] = max_parent_cnt_pair;
				max = Math.Max(max, parentID_length_pair[i].Item2);
			}
			Console.WriteLine(max);
		}
	}
}
