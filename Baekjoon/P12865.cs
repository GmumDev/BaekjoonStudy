using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon 
{
	internal class P12865
	{
		/*
			
			
			명확한 정렬 기준이 있다면 우선순위 큐로 구현할 수 있다. 

			가방에 넣을 물건을 정렬한다고 하자. 우선순위는 어떨까?
			1. 물건의 무게 W가 최대 무게 K 보다 작거나 같은 것만 정렬
			2. V/W 즉, Value per weight가 큰 것부터 정렬
			3. weight가 작은 것부터 정렬
			
			위 정렬 방법이 최대 Value를 보장하는지? 
			... No. 
		 
			1. weight가 작은 것부터 정렬
			2. value가 큰 것부터 정렬

			... 흠 애매하다.

			1. 일단 Value가 같고 weight가 다른 것에 대해서는 분할 정복 느낌으로 정렬이 된다. 
			2. 마찬가지로 Weight가 같고 value가 다른 것에 대해서도 분할 정복이 된다. 
			3. 이제 남은 요소들은 Value와 Weight가 모두 다르다. 
			4. 이들의 순서를 정렬하는 함수는 인자로 '가방의 남은 용량', 'Item A'(Value, Weight), 'Item B'(Value, Weight)을 받을 것이다.
			5. 그럼 int Compare(int leftK, int AValue, int AWeight, int BValue, int BWeight) 가 된다. 
			6. 그런데 leftK는 가변적이라 정렬 못해!!



			모든 경우의 수를 돈다면?
			N <= 100 이므로, 모든 경우의 수 Sigma (N-i)!을 다 보는건 말이 안된다. 패스.
			
			
			List<int>[] arr = new List<int>[M]. M <= 100000은 어떤지
			일단 100,000 * 4Byte로 400,000Byte는 먹고 들어가지만
			안에 리스트는 안 생길수도 있다. 
		
			사실 딕셔너리도 ㄱㅊ다. 이게 더 낫네. 이 dict는 weight를 키로 하고 Value를 Value list에 담는다. 
			Dictionary<int, List<int>> dict = new Dict<int, List<int>>();
			    
			최대 크기가 정해져있고 그 dict의 요소 개수는 최대 100이다. 
			dict 요소들의 List 길이를 다 합쳐도 100을 넘지 않는다. 
		
			
		 */
		static void Main(string[] args)
		{
			string[] input = Console.ReadLine().Split(' ');
			int N = int.Parse(input[0]);
			int K = int.Parse(input[1]);
			for(int i = 0; i < N; i++)
			{
				input = Console.ReadLine().Split(' ');
				int W = int.Parse(input[0]);
				int V = int.Parse(input[1]);
			
				// W1 + W2 + ... + Wn <= K
				// V1 + V2 + ... + Vn = MaxV
				

			}
		}
	}
}
