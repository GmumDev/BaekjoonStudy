using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	/// <summary>
	/// 일단 R, D 함수 구현해서 list에서 하나씩 실행
	/// 1. [런타임 에러] n == 0일 때, string.Select(f(x)) 함수에서 람다 함수가 x를 찾지 못하는 에러 수정
	/// 2. [런타임 에러] 함수 R()에 count == 0 예외처리
	/// 3. [오답] 출력시 list의 count == 0 예외처리
	/// 4. [시간초과] R이 홀수번 등장했을 때, D는 last를 pop하고, 짝수번 등장했을 때 first를 pop하도록 변경
	/// 
	/// 1. [오답] if R else 에서 if R elif D else로 변경
	/// 2. [오답] R이 홀수번 등장한 채 끝났을 때, 최종 list를 reverse하도록 변경
	/// 3. [시간초과] string.Select 제거. int형으로 변환할 필요 없음. 
	///		D_first 대신 start++, D_last 대신 end--하여 start..end 만 출력
	///		문제를 읽으면 R or D 외의 입력은 없을 것으로 예상되므로 다시 if R else 구조로 변경.
	///	4. [오답] string.Select 추가(혹시몰라서), 출력 인덱싱 수정 	
	///	5. [오답] start == end에서 error를 출력하지 않도록 수정([])
	/// 6. [시간초과] string.Select 제거.
	/// 7. [시간초과] Trim을 TrimStart와 TrimEnd로 변경
	/// 8. [시간초과] stringbuilder를 사용
	/// 9. [정답]
	/// 
	/// </summary>
	internal class P5430
	{
		static void Main(string[] args)
		{
			int T = int.Parse(Console.ReadLine());

			for(int i = 0; i < T; i++)
			{
				string func = Console.ReadLine();
				int n = int.Parse(Console.ReadLine());
				string str = Console.ReadLine();
				str = str.TrimStart('[');
				str = str.TrimEnd(']');
				string[] list;
				list = str.Split(',');
				bool isREven = true;
				int start = 0;
				int end = n;

			
				foreach (char c in func)
				{
					if (c == 'R')
						isREven = !isREven;
					else
					{
						if (isREven)
							start++;
						else
							end--;
					}
				}
				StringBuilder sb = new StringBuilder();
				if (start <= end)
				{
					sb.Append('[');
					if (isREven)
					{
						for (int k = start; k < end; k++)
						{
							if (k + 1 < end) {
								sb.Append(list[k]);
								sb.Append(',');
							}
							else
								sb.Append(list[k]);
						}
					}
					else
					{
						for (int k = end - 1; k >= start; k--)
						{
							if (k - 1 >= start)
							{
								sb.Append(list[k]);
								sb.Append(',');
							}
							else
								sb.Append(list[k]);
						}
					}
					sb.Append(']');
					Console.WriteLine(sb);

				}
				else
					Console.WriteLine("error");


			}
		}
	}
}
