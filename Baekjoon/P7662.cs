using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baekjoon
{
	/// <summary>
	/// Heap: Complete Binary Tree
	/// Add: append element
	/// Sort: while Comparer(elem, elem.parent) or elem is not root/leaf, then Swap(elem, elem.parent)
	/// 
	/// </summary>
	internal class Heap<T> where T:IComparable
	{
		private T[] arr;
		private int cnt;
		private int curLeafIdx;

		public delegate long CompareToCallback(T obj);
		public CompareToCallback orderBy;

		public int Count
		{
			get { return cnt; }
		}

		public Heap(int size, CompareToCallback orderBy)
		{
			this.orderBy = orderBy;
			arr = new T[size];
			cnt = 0;
			curLeafIdx = 0;
		}
		public void Add(T elem)
		{
			// add first elem. idx 0 not used
			if(cnt == 0)
			{
				arr[++curLeafIdx] = elem;
				cnt++;
				return;
			}

			// resize array. idx 0 not used so fully occupied when cnt == length - 1
			if (cnt == arr.Length - 1)
			{
				Array.Resize(ref arr, arr.Length * 2);
			}
			arr[++curLeafIdx] = elem;
			cnt++;


			ShiftUp(curLeafIdx);
		}

		public T GetRootElement()
		{
			if (curLeafIdx > 0)
				return arr[1];
			else
				return default(T);
		}
		public T PopRootElement()
		{

			if (curLeafIdx > 0)
			{
				T returnVal = arr[1];

				arr[1] = arr[curLeafIdx--];

				cnt--;

				ShiftDown();

				return returnVal;
			}
			else
				return default(T);
		}
		private void ShiftUp(int idx)
		{
			if (idx > 1 && Compare(arr[idx], arr[idx / 2]) > 0)
			{
				Swap(idx, idx / 2);
				ShiftUp(idx / 2);
			}
		}
		private void ShiftDown(int idx = 1)
		{
			if (idx * 2 <= curLeafIdx)
			{
				if (idx * 2 + 1 <= curLeafIdx)
				{
					// two child
					int biggeridx = Compare(arr[idx * 2], arr[idx * 2 + 1]) < 0 ? idx * 2 + 1 : idx * 2;
					if (Compare(arr[idx], arr[biggeridx]) < 0)
					{
						Swap(idx, biggeridx);
						ShiftDown(biggeridx);
					}
				}
				else if(Compare(arr[idx], arr[idx * 2]) < 0)
				{
					// single child

					Swap(idx, idx * 2);
					ShiftDown(idx * 2);
				}
			}
			// no child
		}
		private void Swap(int idx1, int idx2)
		{
			(arr[idx2], arr[idx1]) = (arr[idx1], arr[idx2]);
		}

		public int Compare(T e1, T e2)
		{

			return orderBy(e1).CompareTo(orderBy(e2));
		}
	}
	internal class P7662
	{
		/*
		List: RemoveAt, Insert, append, prepend 있으나 POP이 없음. 
		LinkedList: removeFirst, removeLast 있으나 Insert 없음.
		Queue: Enque, Deque 있으나 그게 다임. ㅇㅅㅇ;;
		 
		 
		 */

		///
		public delegate int OrderByCallback<T>(T x);
		static int BinarySearchInOrderedList<T>(T[] list, int cnt, T n, OrderByCallback<T> f)
		{
			int startIdx = 0;
			int endidxp1 = cnt;
			if(cnt == 0)
			{
				return 0;
			}
			for (int i = 0; i < cnt; i++)
			{
				int midIdx = (startIdx + endidxp1) / 2;

				if (f(n) < f(list[midIdx]))
				{
					endidxp1 = midIdx;
				}
				else if (f(n) > f(list[midIdx]))
				{
					startIdx = midIdx + 1;
				}
				else
				{
					return midIdx;
				}

				if (startIdx == endidxp1)
				{
					return startIdx;
				}
			}

			return -1;
			
		}
		/// <summary>
		/// 1. [시간초과] 리스트 -> 배열로 변경, insert와 pop(0) 구현
		/// 2. [시간초과] Heap 구현. 
		/// 3. [틀렸습니다] 이런! 자식 노드 둘 중 뭐가 더 작을지는 모른다! 최대 최소 힙 두개를 만들고 어쩌고 저쩌고...
		/// 4. [틀렸습니다] 
		/// 5. [틀렸습니다] (n, idx) 둘다 일치해야 delete하는데, n만 일치하더라도 delete해야함... 
		/// 6. [틀ㄹㄴㅇㅁㄹㅇㄴ] 
		///	
		/// 
		///		//		[Edge Case]
		///		//		1
		///		//		1
		///		//		I 2147483647
		///		//		I -2147483648
		///		//		I 0
		///		//		I 1
		///		//		D 1
		///		//		D -1
		///		//		1 1		// answer: 1 0
		///		//		원인: -2147483648은 max_heap에는 들어가나 min_heap에는 안 들어감
		/// 7. [정답]
		/// 
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			int T = int.Parse(Console.ReadLine());

			for(int i = 0; i < T; i++)
			{
				
				int k = int.Parse(Console.ReadLine());	// max 1,000,000

				int cnt = 0;

				Heap<(long, int)> Q_Max = new Heap<(long, int)>(k + 1, (x) => {
					(long n, int idx) = x; return n; }
				); // orderby callback set to own element value. So Max heap. 

				Heap<(long, int)> Q_Min = new Heap<(long, int)>(k + 1, (x) => {
					(long n, int idx) = x; return -n;}
				); // Min heap.

				Dictionary<(long, int), bool> deleted = new Dictionary<(long, int), bool>();

				for (int j = 0; j < k; j++)
				{
					string[] s = Console.ReadLine().Split(' ');
					string DI = s[0];
					int n = int.Parse(s[1]);
					if(DI == "I")
					{
						Q_Max.Add((n, j));
						Q_Min.Add((n, j));

						deleted.Add((n, j), false);
						
						cnt++;
					}
					else
					{
						if(cnt == 0)
						{
							// do nothing
						}
						else {
							cnt--;
							if (n == 1)
							{
								while(deleted[Q_Max.GetRootElement()])
								{
									Q_Max.PopRootElement();
								}

								(long val, int idx) = Q_Max.PopRootElement();
								deleted[(val, idx)] = true;

							}
							else if (n == -1)
							{
								while (deleted[Q_Min.GetRootElement()])
								{
									Q_Min.PopRootElement();
								}

								(long val, int idx) = Q_Min.PopRootElement();
								deleted[(val, idx)] = true;
							}
						}

					}

				}
				while (cnt != 0 && deleted[Q_Max.GetRootElement()])
				{
					Q_Max.PopRootElement();
				}
				while (cnt != 0 && deleted[Q_Min.GetRootElement()])
				{
					Q_Min.PopRootElement();
				}


				if (cnt == 0)
					Console.WriteLine("EMPTY");
				else
					Console.WriteLine(Q_Max.GetRootElement().Item1 + " " + Q_Min.GetRootElement().Item1);
				// print max min
				// or EMPTY
			}

		}
	}
}
