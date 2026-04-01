using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	internal class P1629
	{


		static void Main(string[] args)
		{
			string[] input = Console.ReadLine().Split(' ');

			int A, B, C;
			A = int.Parse(input[0]);
			B = int.Parse(input[1]);
			C = int.Parse(input[2]);

			// R = (A * B) % C, Q = (A * B) / C
			// (A * B) = C * Q + R 의 R
			// R = (A * B) - C * Q
		}
	}
}
