using System;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // array
            // 형태: 자료형[] ([]는 인덱서라고 함)
            // 자료형이 정적으로, 연속적으로 나열되어있는 형태
            // 한번 크기를 정하면 일반적으로는 바꿀 수 없음

            int[] arrInt = new int[3]; // 4 byte * 3
            int[] arrInt2 = { 1, 2, 3 };
            float[] arrFloat = new float[4];

            arrInt[0] = 3; //arrInt 의 첫번째 주소 + 0 * 자료형 크기의 주소부터 자료형크기 만큼 접근
            arrInt[1] = 4; //arrInt 의 첫번째 주소 + 1 * 자료형 크기의 주소부터 자료형크기 만큼 접근

            Console.WriteLine(arrInt2[2]); // 결과: 3
            
            // 배열의 크기
            Console.WriteLine($"arrInt.Length: {arrInt.Length}");
            
        }
    }
}
