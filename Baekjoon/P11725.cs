using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
    internal class P11725
    {
        /*
         
         문제

            루트 없는 트리가 주어진다. 이때, 트리의 루트를 1이라고 정했을 때, 각 노드의 부모를 구하는 프로그램을 작성하시오.

            입력
            첫째 줄에 노드의 개수 N (2 ≤ N ≤ 100,000)이 주어진다. 둘째 줄부터 N-1개의 줄에 트리 상에서 연결된 두 정점이 주어진다.

            출력
            첫째 줄부터 N-1개의 줄에 각 노드의 부모 노드 번호를 2번 노드부터 순서대로 출력한다.

         */


        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            // 노드의 개수 N
            // 간선의 개수 N-1

            List<int>[] fromto = new List<int>[N + 1];
            Queue<int> que = new Queue<int>();
            int[] answ = new int[N + 1];
            for (int i = 0; i < N-1; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int a = int.Parse(input[0]);
                int b = int.Parse(input[1]);

                if (a == 1)
                {
                    que.Enqueue(b);
                    answ[b] = 1;
                }
                else if (b == 1)
                {
                    que.Enqueue(a);
                    answ[a] = 1;
                }

                if (fromto[a] == null) fromto[a] = new List<int>();
                fromto[a].Add(b);

                if (fromto[b] == null) fromto[b] = new List<int>();
                fromto[b].Add(a);
            }

            bool[] isConnected = new bool[N + 1];
            isConnected[1] = true;

            while(que.Count > 0)
            {
                int par = que.Dequeue();
                isConnected[par] = true;

                if (fromto[par] != null)
                    foreach(var c in fromto[par])
                    {
                        if (isConnected[c]) 
                            continue;
                        answ[c] = par;
                        que.Enqueue(c);
                    }
            }

            StringBuilder buf = new StringBuilder();
            for (int i = 2; i < N + 1; i++)
            {
                buf.Append(answ[i]); buf.Append('\n');
            }
            Console.WriteLine(buf);
            
            
            
        }
    }
}
