using System;
using System.Collections;  // **
using System.Collections.Generic; // **

namespace Collections // 자료구조
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // < System.Collections >

            // 박싱: 기존 자료형을 객체로 변환하는 과정
            // 언박싱: 객체를 특정 자료형으로 변환하는 과정
            ArrayList arrayList = new ArrayList();
            arrayList.Add((object)1); // 명시적 형 변환
            arrayList.Add("문자열"); // 암시적 형 변환
            arrayList.Add('a');

            arrayList.Remove('a'); // 'a' 삭제
            arrayList.RemoveAt(0); // 0번째 삭제

            for(int i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine(arrayList[i]);
            }

            // 
            Hashtable hashtable = new Hashtable();
            hashtable.Add("철수", 90);
            Console.WriteLine(hashtable["철수"]); // 출력: 90

            // < System.Collections.Generic >
            // Generic: 일반화 (타입이 정해져있지 않은 경우에 대해 정의해놓은 타입)
            // 박싱,언박싱 일어나지 않음: 객체 변환이 없기 때문
            // 배열의 capacity가 부족하면 새로운 배열을 만들고 참조
            List<int> list = new List<int>();
            List<string> stringList = new List<string>();
            list.Add(1);
            list.Add(2);

            list.Remove(2);
            list.RemoveAt(0);

            list.Find(x=> x==1);
            list.FindIndex(x=> x==1);

            // c# 에서 Linkedlist는 doubly-LinkedList
            // 각 노드가 이전/다음 노드의 참조를 가지고 있음 (연속적인 데이터가 아님)
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddFirst(2);
            // linkedList[0] = 1; <= 불가능, 인덱스 접근 자체가 불가능

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("철수", "90");
            dictionary.Add("사과", "쌍떡잎식물~");
            Console.WriteLine(dictionary["사과"]);

            // Queue
            // FIFO(First - input, First - output System), 선입선출
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("철수");
            queue.Enqueue("영희");
            queue.Enqueue("지희");

            // queue[0] = 0; <= 불가능, 인덱스 접근 자체 불가능
            Console.WriteLine(queue.Peek()); // 맨 앞 자료 출력 => 철수
            Console.WriteLine(queue.Dequeue()); // 맨 앞 자료 출력 및 삭제 => 철수
            Console.WriteLine(queue.Peek()); // => 영희

            // Stack
            // LIFO (Last - Input, First - output system)
            Stack<string> stack = new Stack<string>();
            stack.Push("철수");
            stack.Push("영희");
            stack.Push("지희");

            Console.WriteLine(stack.Peek()); // 맨 뒤 자료 출력 => 지희
            Console.WriteLine(stack.Pop()); // 맨 뒤 자료 출력 및 삭제 => 지희
            Console.WriteLine(stack.Peek()); // => 영희

        }
    }
}
