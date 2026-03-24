using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	internal class P30804
	{

		/*
		 
		1<= N <= 200,000
		1 <= S <= 9	// 탕후루 종류(Value) 

		0. [초기 아이디어]
		dict에 키를 1~9로 하고
		양 끝에서 하나 씩 pop하기 : LinkedList
		
		각 요소를 순회 돌면서 dict에 추가: O(n)
		while(dict.key	> 2)
			arr[first] < arr[last] then, pop first else pop last
		
		
		1. [시간초과] 
		while 문에서 이루어지는 모든 작업(linkedlist.pop(0), pop(last), dict.remove(key))는 모두 O(1)이므로 얘는 범인이 아님
		그럼 처음 입력받은 arr를 foreach 돌면서 각 elem을 dict에 추가하는게 문제인듯. 

		그리고 LinkedList<int> arr = new LinkedList<int>(Console.ReadLine().Split(' ').Select<string, int>((x) => { return int.Parse(x); }));
		이것도 문제. 애초에 키값이라 parseInt 할 필요 없거니와 Split도 O(n) 만큼 소요됨. 

		입력받은 문자열을 O(n) 순회하며 각 char를 arr과 dict에 추가하도록 개선
		 
		2. [시간초과]
		이러면 루프를 돌면서 dict[key]를 가감하는게 아니라, 처음부터 루트를 돌 필요 없이 계산해서 하는건가
		애초에 입력받는 O(n) 안에서 출력이 나오는 구조일지도. 

		3. [틀림 많이 틀림]
		찾아보니 투포인터 문제라고 한다. 투포인터가 무엇이냐. 
		그냥 링크드리스트임; 
		근데 나는 프로그램이 끝나는 시점에 arr에 두종류의 과일만 남아있길 원했고, 그게 최대길이가 되길 바랬음. 
		근데 그냥 루프마다 최대길이를 갱신하면 되는거였던거임;;;;

		4. [정답]
		아이디어는 반만 맞았어


		 */


		static void Main(string[] args)
		{
			int N = int.Parse(Console.ReadLine());
			string[] s = Console.ReadLine().Split(' ').ToArray();
			LinkedList<string> arr = new LinkedList<string>();
			Dictionary<string, int> dict = new Dictionary<string, int>();

			int max = 0;
			foreach (string c in s)
			{
				arr.AddLast(c);
				if (dict.ContainsKey(c))
					dict[c]++;
				else
					dict.Add(c, 1);

				while (dict.Count >= 3)
				{
					dict[arr.First()]--;
					if (dict[arr.First()] == 0) dict.Remove(arr.First());
					arr.RemoveFirst();
				}

				max = max > arr.Count ? max : arr.Count;
			}
			Console.WriteLine(max);
		}
	}
}
